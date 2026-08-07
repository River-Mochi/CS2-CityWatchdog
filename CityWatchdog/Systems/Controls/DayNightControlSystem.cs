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
    using UnityEngine.Rendering.HighDefinition;

    // Day/Night state is runtime-only. Auto releases the vanilla clock without changing the save.
    public partial class DayNightControlSystem : UISystemBaseExtension
    {
        private const int kModeAuto = 0;
        private const int kModeDay = 1;
        private const int kModeNight = 2;

        private const float kDayTime = 12.5f;
        private const float kNightTime = 1f;
        private const float kVanillaFixedDayTime = 14.5f;
        private const float kHoursPerDay = 24f;
        private const float kHalfDay = 12f;
        private const float kMinimumLightingDifference = 0.05f;

        // Prevent a broken/missing UI callback from leaving the tint or mode request stuck.
        private const double kSafetyTintUiTimeoutSeconds = 1d;

        private const string kResetPostProcessingHistoryFieldName =
            "resetPostProcessingHistory";

        // HDCamera is public, but its narrow post-processing reset flag is internal.
        // Cache the lookup once; reflection runs only when switching to a brighter scene.
        private static readonly FieldInfo? s_ResetPostProcessingHistoryField =
            typeof(HDCamera).GetField(
                kResetPostProcessingHistoryFieldName,
                BindingFlags.Instance | BindingFlags.NonPublic);

        private static bool s_LoggedHistoryReset;

        private ValueBinding<int> m_DayNightModeBinding = null!;
        private ValueBinding<int> m_DayNightSafetyTintTokenBinding = null!;
        private PlanetarySystem? m_PlanetarySystem;
        private TimeSystem? m_TimeSystem;
        private CameraUpdateSystem? m_CameraUpdateSystem;
        private DayNightExposureBridgeSystem? m_ExposureBridgeSystem;
        private ProxyAction? m_ToggleDayNightAction;

        // The UI queues requests. OnUpdate applies them in PreCulling before PlanetarySystem.
        private bool m_HasPendingMode;
        private int m_PendingMode;
        private bool m_PendingUseProtection;
        private bool m_PendingCaptureDebug;
        private int m_AppliedMode = kModeAuto;


        // Test E1.2: the React shutter becomes opaque before C# applies Night.
        private bool m_SafetyTintActive;
        private bool m_SafetyTintNightApplied;
        private bool m_SafetyTintCaptureDebug;
        private int m_SafetyTintToken;
        private double m_SafetyTintDeadline;

        private bool m_SafetyTintReadyPending;
        private int m_SafetyTintReadyToken;

        // Only release overrideTime if CWD took control.
        private bool m_OverrideActive;

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
            m_ExposureBridgeSystem =
                World.GetOrCreateSystemManaged<DayNightExposureBridgeSystem>();
            m_ExposureBridgeSystem.AttachController(this);

            m_DayNightModeBinding =
                AddValueBinding("DayNightMode", kModeAuto);
            m_DayNightSafetyTintTokenBinding =
                AddValueBinding("DayNightSafetyTintToken", 0);

            AddTriggerBinding<int>(
                "SetDayNightMode",
                OnSetDayNightMode);
            AddTriggerBinding<int>(
                "DayNightSafetyTintReady",
                OnDayNightSafetyTintReady);
            AddTriggerBinding<int>(
                "DayNightSafetyTintComplete",
                OnDayNightSafetyTintComplete);

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

            // Mod.cs orders this update immediately before PlanetarySystem in PreCulling.
            ApplyPendingMode();
            ApplyPendingSafetyTintReady();
            CheckSafetyTintTimeout();
            AdvanceExposureDebug();

        }

        // Hotkey is Day <-> Night. From Auto, the first press selects Day.
        private void ToggleDayNight()
        {
            int targetMode =
                m_DayNightModeBinding.value == kModeDay
                    ? kModeNight
                    : kModeDay;

            QueueMode(
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
                CancelSafetyTintTransition(
                    restoreDisplayedMode: false);

                // A new city/map should not inherit the previous session's frozen time.
                QueueMode(
                    kModeAuto,
                    useProtection: false,
                    captureDebug: false,
                    force: true);
            }
        }

        protected override void OnDestroy()
        {
            StopExposureDebug();
            m_HasPendingMode = false;
            CancelSafetyTintTransition(restoreDisplayedMode: false);
            m_ExposureBridgeSystem?.CancelAll();
            m_ExposureBridgeSystem?.DetachController(this);

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
            QueueMode(
                mode,
                useProtection: true,
                captureDebug: true);
        }

        private void QueueMode(
            int mode,
            bool useProtection,
            bool captureDebug,
            bool force = false)
        {
            mode = Math.Max(kModeAuto, Math.Min(kModeNight, mode));

            if (m_SafetyTintActive)
            {
                if (!force)
                {
                    // Ignore extra clicks during the quarter-second safety tint.
                    return;
                }

                CancelSafetyTintTransition(
                    restoreDisplayedMode: false);
            }

            int displayedMode = m_DayNightModeBinding.value;
            if (!force &&
                displayedMode == mode &&
                (!m_HasPendingMode || m_PendingMode == mode))
            {
                return;
            }

            if (displayedMode != mode)
            {
                m_DayNightModeBinding.Update(mode);
            }

            // A newer button/hotkey request replaces an older request that was not rendered yet.
            m_PendingMode = mode;
            m_PendingUseProtection = useProtection;
            m_PendingCaptureDebug = captureDebug;
            m_HasPendingMode = true;
        }

        private void ApplyPendingMode()
        {
            if (!m_HasPendingMode)
            {
                return;
            }

            int mode = m_PendingMode;
            bool useProtection = m_PendingUseProtection;
            bool captureDebug = m_PendingCaptureDebug;
            m_HasPendingMode = false;

            bool smootherSwitch =
                useProtection &&
                ShouldUseSmootherSwitch();

            // Tests of safety shutter applies only to Day -> Night.
            if (smootherSwitch &&
                mode == kModeNight &&
                m_AppliedMode == kModeDay)
            {
                BeginSafetyTintNightTransition(
                    captureDebug);
                return;
            }

            // The failed Fixed-adaptation Night test is removed.
            m_ExposureBridgeSystem?.CancelNightTransition();

            if (smootherSwitch)
            {
                if (mode == kModeAuto)
                {
                    // Check the real vanilla exposure range after LightingSystem.
                    m_ExposureBridgeSystem?.ArmAutoBrighteningCheck();
                }
                else
                {
                    m_ExposureBridgeSystem?.CancelAutoBrighteningCheck();
                }
            }
            else
            {
                m_ExposureBridgeSystem?.CancelAll();
            }

            // Auto is evaluated after LightingSystem because its real state may be
            // Sunset/Dawn even when the simple sun-height estimate reports darkness.
            bool resetHistory =
                smootherSwitch &&
                mode != kModeAuto &&
                IsBrighterTransition(mode);

            if (captureDebug && m_AppliedMode != mode)
            {
                float beforeHour =
                    NormalizeHour(m_PlanetarySystem?.time ?? 0f);

                BeginExposureDebug(
                    m_AppliedMode,
                    mode,
                    beforeHour,
                    resetHistory);
            }

            ApplyMode(mode, resetHistory);
            m_AppliedMode = mode;
        }

        private void BeginSafetyTintNightTransition(
            bool captureDebug)
        {
            // Do not arm the bridge yet. The UI timing callback has not applied Night.
            m_ExposureBridgeSystem?.CancelAll();

            m_SafetyTintActive = true;
            m_SafetyTintNightApplied = false;
            m_SafetyTintCaptureDebug = captureDebug;
            m_SafetyTintDeadline =
                UnityEngine.Time.unscaledTimeAsDouble +
                kSafetyTintUiTimeoutSeconds;

            m_SafetyTintToken =
                m_SafetyTintToken == int.MaxValue
                    ? 1
                    : m_SafetyTintToken + 1;

            m_DayNightSafetyTintTokenBinding.Update(
                m_SafetyTintToken);

        #if DEBUG
            LogUtils.Info(
    $"[CWD-DN-BRIDGE] E2B waiting token={m_SafetyTintToken} values=3");
        #endif
        }


        private void OnDayNightSafetyTintReady(
            int token)
        {
            if (!m_SafetyTintActive ||
                m_SafetyTintNightApplied ||
                token != m_SafetyTintToken)
            {
                return;
            }

            // COHTML trigger callbacks are not PreCulling system update.
            // Queue this so the clock change happens in OnUpdate before PlanetarySystem.
            m_SafetyTintReadyPending = true;
            m_SafetyTintReadyToken = token;

        #if DEBUG
            LogUtils.Info(
    $"[CWD-DN-BRIDGE] E2B ready queued token={token} values=3");
        #endif
        }
       

        private void ApplyPendingSafetyTintReady()
        {
            if (!m_SafetyTintReadyPending)
            {
                return;
            }

            int token = m_SafetyTintReadyToken;
            m_SafetyTintReadyPending = false;
            m_SafetyTintReadyToken = 0;

            if (!m_SafetyTintActive ||
                m_SafetyTintNightApplied ||
                token != m_SafetyTintToken)
            {
                return;
            }

            bool resetHistory = false;

            if (m_SafetyTintCaptureDebug &&
                m_AppliedMode != kModeNight)
            {
                float beforeHour =
                    NormalizeHour(m_PlanetarySystem?.time ?? 0f);

                BeginExposureDebug(
                    m_AppliedMode,
                    kModeNight,
                    beforeHour,
                    resetHistory);
            }

            // We are now inside the PreCulling OnUpdate immediately before PlanetarySystem.
            m_ExposureBridgeSystem?.BeginNightTransition();

        #if DEBUG
        LogUtils.Info(
            $"[CWD-DN-BRIDGE] E2B armed token={token} values=3");
        #endif

            ApplyMode(
                kModeNight,
                resetHistory);
            m_AppliedMode = kModeNight;
            m_SafetyTintNightApplied = true;
            m_SafetyTintDeadline =
                UnityEngine.Time.unscaledTimeAsDouble +
                kSafetyTintUiTimeoutSeconds;

        #if DEBUG
            LogUtils.Info(
                $"[CWD-DN-TINT] covered token={token} appliedHour={kNightTime:F1}");
        #endif
        }



        private void OnDayNightSafetyTintComplete(
            int token)
        {
            if (!m_SafetyTintActive ||
                token != m_SafetyTintToken)
            {
                return;
            }

            if (!m_SafetyTintNightApplied)
            {
                // Never perform an uncovered fallback switch.
                m_DayNightModeBinding.Update(
                    m_AppliedMode);

                LogUtils.WarnOnce(
                    "day-night-safety-tint-ready-missed",
                    () =>
                        "Day/Night safety tint completed before its ready callback. The Night switch was canceled.");
            }

#if DEBUG
            LogUtils.Info(
                $"[CWD-DN-TINT] complete token={token} nightApplied={m_SafetyTintNightApplied}");
#endif

            CancelSafetyTintTransition(
                restoreDisplayedMode: false);
        }

        private void CheckSafetyTintTimeout()
        {
            if (!m_SafetyTintActive ||
                UnityEngine.Time.unscaledTimeAsDouble <
                    m_SafetyTintDeadline)
            {
                return;
            }

            if (!m_SafetyTintNightApplied)
            {
                // Safer to stay in Day than expose the player to an uncovered X-ray frame.
                m_DayNightModeBinding.Update(
                    m_AppliedMode);

                LogUtils.WarnOnce(
                    "day-night-safety-tint-ready-timeout",
                    () =>
                        "Day/Night safety tint did not report ready. The Night switch was canceled.");
            }
            else
            {
                LogUtils.WarnOnce(
                    "day-night-safety-tint-complete-timeout",
                    () =>
                        "Day/Night safety tint did not report completion. CWD forced the overlay binding off.");
            }

            CancelSafetyTintTransition(
                restoreDisplayedMode: false);
        }

        private void CancelSafetyTintTransition(
            bool restoreDisplayedMode)
        {
            if (restoreDisplayedMode &&
                m_DayNightModeBinding.value !=
                    m_AppliedMode)
            {
                m_DayNightModeBinding.Update(
                    m_AppliedMode);
            }


            m_SafetyTintActive = false;
            m_SafetyTintNightApplied = false;
            m_SafetyTintCaptureDebug = false;
            m_SafetyTintDeadline = 0d;
            m_SafetyTintReadyPending = false;
            m_SafetyTintReadyToken = 0;
            m_ExposureBridgeSystem?.CancelNightTransition();


            // Token zero tells React to cancel its timers.
            m_DayNightSafetyTintTokenBinding.Update(0);
        }

        private void ApplyMode(
            int mode,
            bool resetPostProcessingHistory)
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
                    // One direct time change. PlanetarySystem and LightingSystem run after this.
                    planetarySystem.overrideTime = true;
                    planetarySystem.time = kNightTime;
                    m_OverrideActive = true;
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

        internal void RequestBrighteningHistoryReset()
        {
            TryResetPostProcessingHistory();
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
