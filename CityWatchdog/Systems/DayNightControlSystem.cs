// <copyright file="DayNightControlSystem.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the MIT License. You may not use this file except in compliance with this License.
// See LICENSE file in the project root for full license information.
// This notice and the MIT License notice must be kept with
// all copies or substantial portions of this code.
// ================= </copyright> ======================

// File: Systems/DayNightControlSystem.cs
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

        // Avoid a fast time-lapse. Jump once to the last stable dusk seen before the
        // game's late-twilight exposure spike, let exposure settle, then jump to Night.
        private const float kNightDuskTime = 20.25f; // 8:15 PM
        private const float kNightDuskHoldSeconds = 0.65f;

        private const string kResetPostProcessingHistoryFieldName = "resetPostProcessingHistory";

        // HDCamera is public, but its narrow post-processing reset flag is internal.
        // Cache the lookup once; reflection runs only when the player changes the lighting mode.
        private static readonly FieldInfo? s_ResetPostProcessingHistoryField =
            typeof(HDCamera).GetField(
                kResetPostProcessingHistoryFieldName,
                BindingFlags.Instance | BindingFlags.NonPublic);

        private static bool s_LoggedHistoryReset;

        private ValueBinding<int> m_DayNightModeBinding = null!;
        private PlanetarySystem? m_PlanetarySystem;
        private TimeSystem? m_TimeSystem;
        private CameraUpdateSystem? m_CameraUpdateSystem;
        private ProxyAction? m_ToggleDayNightAction;

        // Only release overrideTime if CWD took control.
        private bool m_OverrideActive;

        // Day -> Night uses two visual states only: stable dusk, then Night.
        private bool m_Darkening;
        private float m_DarkeningElapsed;

        // The hotkey also works in the map editor.
        public override GameMode gameMode => GameMode.GameOrEditor;

        protected override void OnCreate()
        {
            base.OnCreate();

            m_PlanetarySystem = World.GetOrCreateSystemManaged<PlanetarySystem>();
            m_TimeSystem = World.GetOrCreateSystemManaged<TimeSystem>();
            m_CameraUpdateSystem = World.GetOrCreateSystemManaged<CameraUpdateSystem>();

            m_DayNightModeBinding = AddValueBinding("DayNightMode", kModeAuto);
            AddTriggerBinding<int>("SetDayNightMode", OnSetDayNightMode);
            m_ToggleDayNightAction = EnableHotkey(CwdSettings.ToggleDayNightAction);
        }

        protected override void OnUpdate()
        {
            m_ToggleDayNightAction ??= EnableHotkey(CwdSettings.ToggleDayNightAction);

            if (IsInGameOrEditor() && m_ToggleDayNightAction?.WasReleasedThisFrame() == true)
            {
                ToggleDayNight();
            }

            if (m_Darkening)
            {
                // Wall-clock time keeps the lighting transition moving while the game is paused.
                AdvanceDarkening(UnityEngine.Time.unscaledDeltaTime);
            }
        }

        // Hotkey is Day <-> Night. From Auto, the first press selects Day.
        private void ToggleDayNight()
        {
            int targetMode = m_DayNightModeBinding.value == kModeDay
                ? kModeNight
                : kModeDay;

            SetMode(targetMode, useSmootherSwitch: true);
        }

        protected override void OnGameLoadingComplete(Purpose purpose, GameMode mode)
        {
            base.OnGameLoadingComplete(purpose, mode);

            if (m_ToggleDayNightAction != null)
            {
                m_ToggleDayNightAction.shouldBeEnabled = mode.IsGameOrEditor();
            }

            if (mode.IsGameOrEditor() &&
                (purpose == Purpose.NewGame || purpose == Purpose.LoadGame))
            {
                // A new city/map should not inherit the previous session's frozen time.
                SetMode(kModeAuto, useSmootherSwitch: false);
            }
        }

        protected override void OnDestroy()
        {
            StopDarkening();

            if (m_OverrideActive && m_PlanetarySystem != null)
            {
                m_PlanetarySystem.overrideTime = false;
                m_OverrideActive = false;
            }

            base.OnDestroy();
        }

        private void OnSetDayNightMode(int mode)
        {
            SetMode(mode, useSmootherSwitch: true);
        }

        private void SetMode(int mode, bool useSmootherSwitch)
        {
            mode = Math.Clamp(mode, kModeAuto, kModeNight);

            if (m_DayNightModeBinding.value != mode)
            {
                m_DayNightModeBinding.Update(mode);
            }

            if (!useSmootherSwitch || !ShouldUseSmootherSwitch())
            {
                StopDarkening();
                ApplyModeImmediate(mode, resetPostProcessingHistory: false);
                return;
            }

            ApplyModeProtected(mode);
        }

        private void ApplyModeProtected(int mode)
        {
            PlanetarySystem? planetarySystem = m_PlanetarySystem;
            if (planetarySystem == null)
            {
                return;
            }

            float startHour = NormalizeHour(planetarySystem.time);
            float targetHour = TargetHour(mode);
            float startLight = DaylightAmount(startHour);
            float targetLight = DaylightAmount(targetHour);
            float lightingDifference = targetLight - startLight;

            // Only the explicit Night mode uses the staged darkening path.
            // Auto remains an immediate release back to the vanilla clock.
            if (mode == kModeNight &&
                lightingDifference < -kMinimumLightingDifference)
            {
                StartDarkening();
                return;
            }

            StopDarkening();

            // Keep the tested HDRP reset only when moving to a brighter scene.
            bool resetHistory =
                lightingDifference > kMinimumLightingDifference;
            ApplyModeImmediate(mode, resetHistory);
        }

        private void StartDarkening()
        {
            PlanetarySystem? planetarySystem = m_PlanetarySystem;
            if (planetarySystem == null)
            {
                return;
            }

            // One discrete shadow/sun change instead of sweeping through 12 game hours.
            planetarySystem.overrideTime = true;
            planetarySystem.time = kNightDuskTime;
            m_OverrideActive = true;

            m_Darkening = true;
            m_DarkeningElapsed = 0f;
        }

        private void AdvanceDarkening(float deltaTime)
        {
            PlanetarySystem? planetarySystem = m_PlanetarySystem;
            if (planetarySystem == null)
            {
                StopDarkening();
                return;
            }

            if (!ShouldUseSmootherSwitch())
            {
                StopDarkening();
                ApplyModeImmediate(
                    kModeNight,
                    resetPostProcessingHistory: false);
                return;
            }

            // Hold one stable dusk frame-state long enough for normal HDRP exposure
            // to move toward darkness without showing a fast-moving sun or shadows.
            planetarySystem.overrideTime = true;
            planetarySystem.time = kNightDuskTime;

            m_DarkeningElapsed += Mathf.Max(0f, deltaTime);
            if (m_DarkeningElapsed < kNightDuskHoldSeconds)
            {
                return;
            }

            StopDarkening();

            // Exposure now comes from the already-dark dusk scene. Do not reset
            // history here; the reset's neutral frame caused the former white/X-ray flash.
            ApplyModeImmediate(
                kModeNight,
                resetPostProcessingHistory: false);
        }

        private void StopDarkening()
        {
            m_Darkening = false;
            m_DarkeningElapsed = 0f;
        }

        private void ApplyModeImmediate(int mode, bool resetPostProcessingHistory)
        {
            if (m_PlanetarySystem == null)
            {
                return;
            }

            switch (mode)
            {
                case kModeDay:
                    m_PlanetarySystem.overrideTime = true;
                    m_PlanetarySystem.time = kDayTime;
                    m_OverrideActive = true;
                    break;

                case kModeNight:
                    m_PlanetarySystem.overrideTime = true;
                    m_PlanetarySystem.time = kNightTime;
                    m_OverrideActive = true;
                    break;

                default:
                    if (!m_OverrideActive)
                    {
                        return;
                    }

                    // Match the live vanilla clock before releasing overrideTime, avoiding one
                    // rendered frame at the old fixed hour.
                    m_PlanetarySystem.overrideTime = true;
                    m_PlanetarySystem.time = GetNaturalHour();
                    break;
            }

            if (resetPostProcessingHistory)
            {
                TryResetPostProcessingHistory();
            }

            if (mode == kModeAuto)
            {
                m_PlanetarySystem.overrideTime = false;
                m_OverrideActive = false;
            }
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
                SharedSettings.instance?.gameplay is GameplaySettings gameplay &&
                !gameplay.dayNightVisual)
            {
                return kVanillaFixedDayTime;
            }

            return NormalizeHour(
                (m_TimeSystem?.normalizedTime ?? 0.5f) * kHoursPerDay);
        }

        private static float DaylightAmount(float hour)
        {
            float radians = (NormalizeHour(hour) - 6f) * Mathf.PI / kHalfDay;
            return Mathf.Max(0f, Mathf.Sin(radians));
        }

        private static float NormalizeHour(float hour)
        {
            return Mathf.Repeat(hour, kHoursPerDay);
        }

        private void TryResetPostProcessingHistory()
        {
            FieldInfo? resetField = s_ResetPostProcessingHistoryField;
            if (resetField == null)
            {
                LogUtils.WarnOnce(
                    "day-night-history-field-missing",
                    () => $"HDRP field '{kResetPostProcessingHistoryFieldName}' was not found. " +
                          "Day/Night still changes time, but its stale exposure history cannot be reset.");
                return;
            }

            Camera? camera = m_CameraUpdateSystem?.activeCamera ?? Camera.main;
            if (camera == null)
            {
                LogUtils.WarnOnce(
                    "day-night-active-camera-missing",
                    () => "Day/Night post-processing history reset skipped: no active game camera.");
                return;
            }

            try
            {
                HDCamera hdCamera = HDCamera.GetOrCreate(camera);
                resetField.SetValue(hdCamera, true);

                if (!s_LoggedHistoryReset)
                {
                    s_LoggedHistoryReset = true;
                    LogUtils.Info("[CWD] Day/Night HDRP brightening history reset active.");
                }
            }
            catch (Exception ex)
            {
                LogUtils.WarnOnce(
                    "day-night-history-reset-failed",
                    () => $"Day/Night HDRP history reset failed: {ex.GetType().Name}: {ex.Message}",
                    ex);
            }
        }

        private static bool ShouldUseSmootherSwitch()
        {
            return IsInGameOrEditor() &&
                (CwdSettings.Instance?.SmoothDayNightTransition ?? true);
        }

        private static bool IsInGameOrEditor()
        {
            return GameManager.instance != null &&
                GameManager.instance.gameMode.IsGameOrEditor();
        }

        private static ProxyAction? EnableHotkey(string actionName)
        {
            try
            {
                ProxyAction? action = CwdSettings.Instance?.GetAction(actionName);
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
                    () => $"Keybinding '{actionName}' unavailable: {ex.GetType().Name}: {ex.Message}",
                    ex);
                return null;
            }
        }

    }
}
