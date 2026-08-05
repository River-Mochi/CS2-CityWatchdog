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
    using UnityEngine;      // Mathf
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
        private const float kMinimumDarkeningSeconds = 0.35f;

        private const float kMaximumDarkeningSeconds = 2.35f;
        // Day -> Night is visually nonlinear in game.
        private const float kDarkeningPhase1Portion = 0.38f; // 1 PM -> 6:30 PM; modest time in afternoon.
        private const float kDarkeningPhase2Portion = 0.37f; // 6:30 PM -> 8:45 PM; longer near dusk/twilight.
        private const float kDarkeningPhase3Portion = 0.25f; // 8:45 PM -> 1 AM; finish the step into Night.

        // For a full 1 PM -> 1 AM path, these positions correspond to 6:30 PM and 8:45 PM.
        // Path fractions also keep shorter darkening transitions working correctly.
        private const float kDarkeningPhase1PathEnd = 5.5f / kHalfDay;
        private const float kDarkeningPhase2PathEnd = 7.75f / kHalfDay;

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

        // Darkening uses a short sunset path so auto exposure can follow the lighting change.
        private bool m_Darkening;
        private float m_DarkeningElapsed;
        private float m_DarkeningDuration;
        private float m_DarkeningStartHour;
        private float m_DarkeningDistanceHours;
        private int m_DarkeningTargetMode;

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
            if (m_PlanetarySystem == null)
            {
                return;
            }

            float startHour = NormalizeHour(m_PlanetarySystem.time);
            float targetHour = TargetHour(mode);
            float startLight = DaylightAmount(startHour);
            float targetLight = DaylightAmount(targetHour);
            float lightingDifference = targetLight - startLight;

            if (lightingDifference < -kMinimumLightingDifference)
            {
                StartDarkening(mode, startHour, targetHour);
                return;
            }

            StopDarkening();

            // Resetting HDRP history is useful only when the target is meaningfully brighter.
            // During a darkening switch HDRP's neutral reset frame is itself the white/X-ray flash.
            bool resetHistory = lightingDifference > kMinimumLightingDifference;
            ApplyModeImmediate(mode, resetHistory);
        }

        private void StartDarkening(int targetMode, float startHour, float targetHour)
        {
            if (m_PlanetarySystem == null)
            {
                return;
            }

            float distanceHours = ChooseDarkerPathDistance(startHour, targetHour);
            if (Mathf.Abs(distanceHours) < 0.001f)
            {
                ApplyModeImmediate(targetMode, resetPostProcessingHistory: false);
                return;
            }

            float distanceRatio = Mathf.Clamp01(Mathf.Abs(distanceHours) / kHalfDay);

            m_PlanetarySystem.overrideTime = true;
            m_OverrideActive = true;

            m_Darkening = true;
            m_DarkeningElapsed = 0f;
            m_DarkeningDuration = Mathf.Lerp(
                kMinimumDarkeningSeconds,
                kMaximumDarkeningSeconds,
                distanceRatio);
            m_DarkeningStartHour = startHour;
            m_DarkeningDistanceHours = distanceHours;
            m_DarkeningTargetMode = targetMode;
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
                int targetMode = m_DarkeningTargetMode;
                StopDarkening();
                ApplyModeImmediate(targetMode, resetPostProcessingHistory: false);
                return;
            }

            m_DarkeningElapsed += Mathf.Max(0f, deltaTime);

            float duration = Mathf.Max(0.001f, m_DarkeningDuration);
            float progress = Mathf.Clamp01(m_DarkeningElapsed / duration);
            float phase1End = kDarkeningPhase1Portion;
            float phase2End = kDarkeningPhase1Portion + kDarkeningPhase2Portion;

            float pathProgress;

            if (progress < phase1End)
            {
                // Full Day -> Night path: 1 PM -> 6:30 PM.
                float t = Smooth01(progress / phase1End);
                pathProgress = Lerp01(0f, kDarkeningPhase1PathEnd, t);
            }
            else if (progress < phase2End)
            {
                // Full Day -> Night path: 6:30 PM -> 8:45 PM.
                float t = Smooth01(
                    (progress - phase1End) / kDarkeningPhase2Portion);
                pathProgress = Lerp01(
                    kDarkeningPhase1PathEnd,
                    kDarkeningPhase2PathEnd,
                    t);
            }
            else
            {
                // Full Day -> Night path: 8:45 PM -> 1 AM.
                float t = Smooth01(
                    (progress - phase2End) / kDarkeningPhase3Portion);
                pathProgress = Lerp01(kDarkeningPhase2PathEnd, 1f, t);
            }

            planetarySystem.overrideTime = true;
            planetarySystem.time = NormalizeHour(
                m_DarkeningStartHour +
                (m_DarkeningDistanceHours * pathProgress));

            if (progress >= 1f)
            {
                // Reuse the normal completion path, including Auto release.
                CompleteDarkening();
            }
        }

        private void CompleteDarkening()
        {
            if (m_PlanetarySystem == null)
            {
                StopDarkening();
                return;
            }

            int targetMode = m_DarkeningTargetMode;
            StopDarkening();

            if (targetMode == kModeAuto)
            {
                // Re-sample the live clock after the short transition, then release CWD's override.
                m_PlanetarySystem.time = GetNaturalHour();
                m_PlanetarySystem.overrideTime = false;
                m_OverrideActive = false;
                return;
            }

            m_PlanetarySystem.overrideTime = true;
            m_PlanetarySystem.time = TargetHour(targetMode);
            m_OverrideActive = true;
        }

        private void StopDarkening()
        {
            m_Darkening = false;
            m_DarkeningElapsed = 0f;
            m_DarkeningDuration = 0f;
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

        private static float ChooseDarkerPathDistance(float startHour, float targetHour)
        {
            float forwardDistance = Mathf.Repeat(targetHour - startHour, kHoursPerDay);
            float backwardDistance = forwardDistance - kHoursPerDay;

            if (Mathf.Abs(forwardDistance) < 0.001f)
            {
                return 0f;
            }

            float forwardPeak = PeakDaylightOnPath(startHour, forwardDistance);
            float backwardPeak = PeakDaylightOnPath(startHour, backwardDistance);

            if (forwardPeak < backwardPeak - 0.01f)
            {
                return forwardDistance;
            }

            if (backwardPeak < forwardPeak - 0.01f)
            {
                return backwardDistance;
            }

            return Mathf.Abs(forwardDistance) <= Mathf.Abs(backwardDistance)
                ? forwardDistance
                : backwardDistance;
        }

        private static float PeakDaylightOnPath(float startHour, float distanceHours)
        {
            const int sampleCount = 8;
            float peak = 0f;

            for (int i = 1; i <= sampleCount; i++)
            {
                float hour = startHour + (distanceHours * i / sampleCount);
                peak = Mathf.Max(peak, DaylightAmount(hour));
            }

            return peak;
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

        private static float Smooth01(float t)
        {
            t = Mathf.Clamp01(t);
            return t * t * (3f - (2f * t));
        }

        private static float Lerp01(float a, float b, float t)
        {
            return a + ((b - a) * Mathf.Clamp01(t));
        }

    }
}
