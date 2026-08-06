// <copyright file="DayNightControlSystem.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the MIT License. You may not use this file except in compliance with this License.
// See LICENSE file in the project root for full license information.
// This notice and the MIT License notice must be kept with
// all copies or substantial portions of this code.
// ================= </copyright> ======================

// File: Systems/Controls/DayNightControlSystem.cs
// Purpose: Day/Night control for the panel button and optional hotkey.

namespace CityWatchdog.Systems
{
    using System;
    using System.Reflection;

    using Colossal.Serialization.Entities;
    using Colossal.UI.Binding;

    using CS2Shared.RiverMochi;

    using Game;
    using Game.Input;
    using Game.Rendering;
    using Game.SceneFlow;
    using Game.Settings;
    using Game.Simulation;

    using UnityEngine;
    using UnityEngine.Rendering;
    using UnityEngine.Rendering.HighDefinition;

    // Day/Night state is runtime-only. Auto releases the vanilla clock without changing the save.
    public partial class DayNightControlSystem : UISystemBaseExtension
    {
        private const int kModeAuto = 0;
        private const int kModeDay = 1;
        private const int kModeNight = 2;

        private const float kDayTime = 13f;
        private const float kNightTime = 1f;
        private const float kVanillaFixedDayTime = 14.5f;
        private const float kHoursPerDay = 24f;
        private const float kHalfDay = 12f;
        private const float kMinimumLightingDifference = 0.05f;

        // Passive Debug showed the first acceptable recovering Night frames near EV 1.
        // Seed both HDRP histories there so Day -> Night skips EV 6 and the X-ray/black pair.
        private const float kNightExposureSeedEv = 1f;
        private const int kNightExposureSeedMaximumWaitFrames = 8;
        private const float kNightExposureReadyMinimumEv = 0.5f;
        private const float kNightExposureReadyMaximumEv = 6.5f;

        private const string kResetPostProcessingHistoryFieldName =
            "resetPostProcessingHistory";
        private const string kExposureTexturesFieldName =
            "m_ExposureTextures";
        private const string kExposureCurrentFieldName =
            "current";
        private const string kExposurePreviousFieldName =
            "previous";

        // HDCamera is public, but its narrow post-processing reset flag is internal.
        // Cache the lookup once; reflection runs only when switching to a brighter scene.
        private static readonly FieldInfo? s_ResetPostProcessingHistoryField =
            typeof(HDCamera).GetField(
                kResetPostProcessingHistoryFieldName,
                BindingFlags.Instance | BindingFlags.NonPublic);

        private static readonly FieldInfo? s_NightExposureTexturesField =
            typeof(HDCamera).GetField(
                kExposureTexturesFieldName,
                BindingFlags.Instance | BindingFlags.NonPublic);

        private static readonly FieldInfo? s_NightExposureCurrentField =
            s_NightExposureTexturesField?.FieldType.GetField(
                kExposureCurrentFieldName,
                BindingFlags.Instance |
                BindingFlags.Public |
                BindingFlags.NonPublic);

        private static readonly FieldInfo? s_NightExposurePreviousField =
            s_NightExposureTexturesField?.FieldType.GetField(
                kExposurePreviousFieldName,
                BindingFlags.Instance |
                BindingFlags.Public |
                BindingFlags.NonPublic);

        private static bool s_LoggedHistoryReset;
        private static bool s_LoggedNightExposureSeed;

        private ValueBinding<int> m_DayNightModeBinding = null!;
        private PlanetarySystem? m_PlanetarySystem;
        private TimeSystem? m_TimeSystem;
        private CameraUpdateSystem? m_CameraUpdateSystem;
        private ProxyAction? m_ToggleDayNightAction;

        // Only release overrideTime if CWD took control.
        private bool m_OverrideActive;

        // Day -> Night first renders one unmodified darker frame. On the next UI update,
        // seed only after HDRP's volume stack has switched from the Day EV limits to Night.
        private bool m_NightExposureSeedPending;
        private int m_NightExposureSeedStartFrame;

        // The hotkey also works in the map editor.
        public override GameMode gameMode => GameMode.GameOrEditor;

        protected override void OnCreate()
        {
            base.OnCreate();

            m_PlanetarySystem =
                World.GetOrCreateSystemManaged<PlanetarySystem>();
            m_TimeSystem =
                World.GetOrCreateSystemManaged<TimeSystem>();
            m_CameraUpdateSystem =
                World.GetOrCreateSystemManaged<CameraUpdateSystem>();

            m_DayNightModeBinding =
                AddValueBinding("DayNightMode", kModeAuto);
            AddTriggerBinding<int>(
                "SetDayNightMode",
                OnSetDayNightMode);
            m_ToggleDayNightAction =
                EnableHotkey(CwdSettings.ToggleDayNightAction);
        }

        protected override void OnUpdate()
        {
            m_ToggleDayNightAction ??=
                EnableHotkey(CwdSettings.ToggleDayNightAction);

            if (IsInGameOrEditor() &&
                m_ToggleDayNightAction?.WasReleasedThisFrame() == true)
            {
                ToggleDayNight();
            }

            AdvanceNightExposureSeed();
            AdvanceExposureDebug();
        }

        // Hotkey is Day <-> Night. From Auto, the first press selects Day.
        private void ToggleDayNight()
        {
            int targetMode =
                m_DayNightModeBinding.value == kModeDay
                    ? kModeNight
                    : kModeDay;

            SetMode(
                targetMode,
                useProtection: true,
                captureDebug: true);
        }

        protected override void OnGameLoadingComplete(
            Purpose purpose,
            GameMode mode)
        {
            base.OnGameLoadingComplete(purpose, mode);

            if (m_ToggleDayNightAction != null)
            {
                m_ToggleDayNightAction.shouldBeEnabled =
                    mode.IsGameOrEditor();
            }

            if (mode.IsGameOrEditor() &&
                (purpose == Purpose.NewGame ||
                 purpose == Purpose.LoadGame))
            {
                // A new city/map should not inherit the previous session's frozen time.
                SetMode(
                    kModeAuto,
                    useProtection: false,
                    captureDebug: false);
            }
        }

        protected override void OnDestroy()
        {
            StopExposureDebug();
            CancelNightExposureSeed();

            PlanetarySystem? planetarySystem = m_PlanetarySystem;
            if (m_OverrideActive && planetarySystem != null)
            {
                planetarySystem.overrideTime = false;
                m_OverrideActive = false;
            }

            base.OnDestroy();
        }

        private void OnSetDayNightMode(int mode)
        {
            SetMode(
                mode,
                useProtection: true,
                captureDebug: true);
        }

        private void SetMode(
            int mode,
            bool useProtection,
            bool captureDebug)
        {
            mode = Math.Max(kModeAuto, Math.Min(kModeNight, mode));

            int previousMode = m_DayNightModeBinding.value;

            if (mode != kModeNight)
            {
                CancelNightExposureSeed();
            }

            bool useSmootherSwitch =
                useProtection &&
                ShouldUseSmootherSwitch();

            bool resetHistory =
                useSmootherSwitch &&
                IsBrighterTransition(mode);

            bool seedNightExposure =
                useSmootherSwitch &&
                mode == kModeNight &&
                IsDarkerTransition(mode);

            if (captureDebug && previousMode != mode)
            {
                float beforeHour =
                    NormalizeHour(m_PlanetarySystem?.time ?? 0f);

                BeginExposureDebug(
                    previousMode,
                    mode,
                    beforeHour,
                    resetHistory);
            }

            if (previousMode != mode)
            {
                m_DayNightModeBinding.Update(mode);
            }

            ApplyMode(mode, resetHistory, seedNightExposure);
        }

        private void ApplyMode(
            int mode,
            bool resetPostProcessingHistory,
            bool seedNightExposure)
        {
            PlanetarySystem? planetarySystem = m_PlanetarySystem;
            if (planetarySystem == null)
            {
                return;
            }

            switch (mode)
            {
                case kModeDay:
                    planetarySystem.overrideTime = true;
                    planetarySystem.time = kDayTime;
                    m_OverrideActive = true;
                    break;

                case kModeNight:
                    // Jump the sun/shadows directly once. Do not seed while HDRP still has
                    // the Day volume stack; that produced the full-screen white frame.
                    planetarySystem.overrideTime = true;
                    planetarySystem.time = kNightTime;
                    m_OverrideActive = true;

                    if (seedNightExposure)
                    {
                        ScheduleNightExposureSeed();
                    }

                    break;

                default:
                    if (!m_OverrideActive)
                    {
                        return;
                    }

                    // Match the live vanilla clock before releasing overrideTime, avoiding one
                    // rendered frame at the old fixed hour.
                    planetarySystem.overrideTime = true;
                    planetarySystem.time = GetNaturalHour();
                    break;
            }

            if (resetPostProcessingHistory)
            {
                TryResetPostProcessingHistory();
            }

            if (mode == kModeAuto)
            {
                planetarySystem.overrideTime = false;
                m_OverrideActive = false;
            }
        }

        private bool IsBrighterTransition(int targetMode)
        {
            PlanetarySystem? planetarySystem = m_PlanetarySystem;
            if (planetarySystem == null)
            {
                return false;
            }

            float currentLight =
                DaylightAmount(NormalizeHour(planetarySystem.time));
            float targetLight =
                DaylightAmount(TargetHour(targetMode));

            return targetLight - currentLight >
                kMinimumLightingDifference;
        }

        private bool IsDarkerTransition(int targetMode)
        {
            PlanetarySystem? planetarySystem = m_PlanetarySystem;
            if (planetarySystem == null)
            {
                return false;
            }

            float currentLight =
                DaylightAmount(NormalizeHour(planetarySystem.time));
            float targetLight =
                DaylightAmount(TargetHour(targetMode));

            return targetLight - currentLight <
                -kMinimumLightingDifference;
        }

        private float TargetHour(int mode)
        {
            return mode switch
            {
                kModeDay => kDayTime,
                kModeNight => kNightTime,
                _ => GetNaturalHour(),
            };
        }

        private float GetNaturalHour()
        {
            // Vanilla uses a fixed 14:30 scene when Day/night visuals is disabled.
            if (GameManager.instance?.gameMode == GameMode.Game &&
                SharedSettings.instance?.gameplay
                    is GameplaySettings gameplay &&
                !gameplay.dayNightVisual)
            {
                return kVanillaFixedDayTime;
            }

            return NormalizeHour(
                (m_TimeSystem?.normalizedTime ?? 0.5f) *
                kHoursPerDay);
        }

        private static float DaylightAmount(float hour)
        {
            float radians =
                (NormalizeHour(hour) - 6f) *
                Mathf.PI /
                kHalfDay;

            return Mathf.Max(0f, Mathf.Sin(radians));
        }

        private static float NormalizeHour(float hour)
        {
            return Mathf.Repeat(hour, kHoursPerDay);
        }

        private Camera? GetActiveCamera()
        {
            return
                m_CameraUpdateSystem?.activeCamera ??
                Camera.main;
        }

        private void ScheduleNightExposureSeed()
        {
            m_NightExposureSeedPending = true;
            m_NightExposureSeedStartFrame = UnityEngine.Time.frameCount;
        }

        private void CancelNightExposureSeed()
        {
            m_NightExposureSeedPending = false;
            m_NightExposureSeedStartFrame = 0;
        }

        private void AdvanceNightExposureSeed()
        {
            if (!m_NightExposureSeedPending ||
                m_DayNightModeBinding.value != kModeNight)
            {
                return;
            }

            int waitedFrames =
                UnityEngine.Time.frameCount -
                m_NightExposureSeedStartFrame;

            // Always allow the first direct 1 AM frame to render without CWD changing exposure.
            if (waitedFrames < 1)
            {
                return;
            }

            Camera? camera = GetActiveCamera();
            if (camera == null)
            {
                if (waitedFrames >= kNightExposureSeedMaximumWaitFrames)
                {
                    CancelNightExposureSeed();
                }

                return;
            }

            HDCamera hdCamera;
            try
            {
                hdCamera = HDCamera.GetOrCreate(camera);
            }
            catch
            {
                if (waitedFrames >= kNightExposureSeedMaximumWaitFrames)
                {
                    CancelNightExposureSeed();
                }

                return;
            }

            Exposure? exposure =
                hdCamera.volumeStack?.GetComponent<Exposure>();

            bool nightVolumeReady =
                exposure != null &&
                exposure.limitMin.value <=
                    kNightExposureReadyMinimumEv &&
                exposure.limitMax.value <=
                    kNightExposureReadyMaximumEv;

            if (!nightVolumeReady)
            {
                if (waitedFrames >= kNightExposureSeedMaximumWaitFrames)
                {
                    CancelNightExposureSeed();

                    LogUtils.WarnOnce(
                        "day-night-night-volume-not-ready",
                        () =>
                            "Day/Night exposure seed skipped because HDRP did not switch to the Night EV limits in time.");
                }

                return;
            }

            CancelNightExposureSeed();
            TrySeedNightExposure(hdCamera);
        }

        private void TrySeedNightExposure(HDCamera hdCamera)
        {
            FieldInfo? texturesField = s_NightExposureTexturesField;
            FieldInfo? currentField = s_NightExposureCurrentField;
            FieldInfo? previousField = s_NightExposurePreviousField;

            if (texturesField == null ||
                currentField == null ||
                previousField == null)
            {
                LogUtils.WarnOnce(
                    "day-night-exposure-history-fields-missing",
                    () =>
                        "Day/Night could not find HDRP's paired exposure-history fields. " +
                        "The switch will use the game's normal Day -> Night exposure.");
                return;
            }

            try
            {
                object? exposureTextures =
                    texturesField.GetValue(hdCamera);

                RTHandle? current =
                    exposureTextures == null
                        ? null
                        : currentField.GetValue(exposureTextures)
                            as RTHandle;

                RTHandle? previous =
                    exposureTextures == null
                        ? null
                        : previousField.GetValue(exposureTextures)
                            as RTHandle;

                RenderTexture? currentTexture = current?.rt;
                RenderTexture? previousTexture = previous?.rt;

                if (currentTexture == null ||
                    previousTexture == null ||
                    !currentTexture.IsCreated() ||
                    !previousTexture.IsCreated())
                {
                    LogUtils.WarnOnce(
                        "day-night-exposure-history-unavailable",
                        () =>
                            "Day/Night exposure-history seed skipped: HDRP history textures are not ready.");
                    return;
                }

                float exposureMultiplier =
                    ColorUtils.ConvertEV100ToExposure(
                        kNightExposureSeedEv);

                Color seedValue =
                    new(
                        exposureMultiplier,
                        kNightExposureSeedEv,
                        0f,
                        0f);

                CommandBuffer commandBuffer =
                    CommandBufferPool.Get(
                        "CWD Day/Night exposure seed");

                try
                {
                    commandBuffer.SetRenderTarget(currentTexture);
                    commandBuffer.ClearRenderTarget(
                        clearDepth: false,
                        clearColor: true,
                        backgroundColor: seedValue);

                    if (!ReferenceEquals(
                            currentTexture,
                            previousTexture))
                    {
                        commandBuffer.SetRenderTarget(
                            previousTexture);
                        commandBuffer.ClearRenderTarget(
                            clearDepth: false,
                            clearColor: true,
                            backgroundColor: seedValue);
                    }

                    Graphics.ExecuteCommandBuffer(
                        commandBuffer);
                }
                finally
                {
                    CommandBufferPool.Release(
                        commandBuffer);
                }

                if (!s_LoggedNightExposureSeed)
                {
                    s_LoggedNightExposureSeed = true;
                    LogUtils.Info(
                        $"[CWD] Day/Night seeded both HDRP exposure histories at EV {kNightExposureSeedEv:F1} after the Night volume became active.");
                }
            }
            catch (Exception ex)
            {
                LogUtils.WarnOnce(
                    "day-night-exposure-seed-failed",
                    () =>
                        $"Day/Night HDRP exposure-history seed failed: {ex.GetType().Name}: {ex.Message}",
                    ex);
            }
        }

        private void TryResetPostProcessingHistory()
        {
            FieldInfo? resetField =
                s_ResetPostProcessingHistoryField;

            if (resetField == null)
            {
                LogUtils.WarnOnce(
                    "day-night-history-field-missing",
                    () =>
                        $"HDRP field '{kResetPostProcessingHistoryFieldName}' was not found. " +
                        "Day/Night still changes time, but stale brightening history cannot be reset.");
                return;
            }

            Camera? camera = GetActiveCamera();
            if (camera == null)
            {
                LogUtils.WarnOnce(
                    "day-night-active-camera-missing",
                    () =>
                        "Day/Night post-processing history reset skipped: no active game camera.");
                return;
            }

            try
            {
                HDCamera hdCamera =
                    HDCamera.GetOrCreate(camera);

                resetField.SetValue(hdCamera, true);

                if (!s_LoggedHistoryReset)
                {
                    s_LoggedHistoryReset = true;
                    LogUtils.Info(
                        "[CWD] Day/Night HDRP brightening history reset active.");
                }
            }
            catch (Exception ex)
            {
                LogUtils.WarnOnce(
                    "day-night-history-reset-failed",
                    () =>
                        $"Day/Night HDRP history reset failed: {ex.GetType().Name}: {ex.Message}",
                    ex);
            }
        }

        private static bool ShouldUseSmootherSwitch()
        {
            return IsInGameOrEditor() &&
                (CwdSettings.Instance?
                    .SmoothDayNightTransition ?? true);
        }

        private static bool IsInGameOrEditor()
        {
            return
                GameManager.instance != null &&
                GameManager.instance.gameMode.IsGameOrEditor();
        }

        private static string ModeName(int mode)
        {
            return mode switch
            {
                kModeAuto => "Auto",
                kModeDay => "Day",
                kModeNight => "Night",
                _ => "Unknown",
            };
        }

        private static ProxyAction? EnableHotkey(
            string actionName)
        {
            try
            {
                ProxyAction? action =
                    CwdSettings.Instance?.GetAction(actionName);

                if (action != null)
                {
                    action.shouldBeEnabled = true;
                }

                return action;
            }
            catch (Exception ex)
            {
                LogUtils.WarnOnce(
                    "day-night-hotkey-" + actionName,
                    () =>
                        $"Keybinding '{actionName}' unavailable: {ex.GetType().Name}: {ex.Message}",
                    ex);
                return null;
            }
        }

        // Implemented only in Debug builds. Calls disappear from Release.
        partial void BeginExposureDebug(
            int previousMode,
            int targetMode,
            float beforeHour,
            bool resetHistory);

        partial void AdvanceExposureDebug();

        partial void StopExposureDebug();
    }
}
