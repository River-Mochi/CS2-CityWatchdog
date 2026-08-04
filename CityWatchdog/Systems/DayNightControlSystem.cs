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

    using Colossal.Serialization.Entities;
    using Colossal.UI.Binding;

    using CS2Shared.RiverMochi;

    using Game;
    using Game.Input;
    using Game.SceneFlow;
    using Game.Settings;
    using Game.Simulation;

    // Day/Night mode is runtime-only. Auto releases the vanilla clock without changing the save.
    public partial class DayNightControlSystem : UISystemBaseExtension
    {
        private const int kModeAuto = 0;
        private const int kModeDay = 1;
        private const int kModeNight = 2;

        private const float kDayTime = 12f;
        private const float kNightTime = 2f;
        private const float kVanillaFixedDayTime = 14.5f;
        private const float kHoursPerDay = 24f;
        private const float kHalfDay = 12f;

        // Fast enough for building checks, but long enough to read as sunrise/sunset instead of a cut.
        private const float kTransitionSeconds = 1.2f;
        private const float kExposureSettleSeconds = 0.15f;

        private readonly DayNightExposureGuard m_ExposureGuard = new();

        private ValueBinding<int> m_DayNightModeBinding = null!;
        private PlanetarySystem? m_PlanetarySystem;
        private TimeSystem? m_TimeSystem;
        private ProxyAction? m_ToggleDayNightAction;

        // True only while CWD owns PlanetarySystem.overrideTime.
        private bool m_OverrideActive;

        private bool m_Transitioning;
        private float m_TransitionElapsed;
        private float m_TransitionStartHour;
        private float m_TransitionDistanceHours;
        private int m_TransitionTargetMode;
        private float m_ExposureSettleRemaining;

        // The hotkey also works in the map editor.
        public override GameMode gameMode => GameMode.GameOrEditor;

        protected override void OnCreate()
        {
            base.OnCreate();

            m_PlanetarySystem = World.GetOrCreateSystemManaged<PlanetarySystem>();
            m_TimeSystem = World.GetOrCreateSystemManaged<TimeSystem>();
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

            float deltaTime = UnityEngine.Time.unscaledDeltaTime;
            if (m_Transitioning)
            {
                AdvanceTransition(deltaTime);
            }
            else if (m_ExposureSettleRemaining > 0f)
            {
                AdvanceExposureSettle(deltaTime);
            }
        }

        // Hotkey is Day <-> Night. From Auto, the first press selects Day.
        private void ToggleDayNight()
        {
            int targetMode = m_DayNightModeBinding.value == kModeDay
                ? kModeNight
                : kModeDay;

            SetMode(targetMode, allowTransition: true);
        }

        protected override void OnGameLoadingComplete(Purpose purpose, GameMode mode)
        {
            base.OnGameLoadingComplete(purpose, mode);

            if (m_ToggleDayNightAction != null)
            {
                m_ToggleDayNightAction.shouldBeEnabled = mode.IsGameOrEditor();
            }

            if (mode.IsGameOrEditor())
            {
                m_ExposureGuard.Prepare();

                if (purpose == Purpose.NewGame || purpose == Purpose.LoadGame)
                {
                    SetMode(kModeAuto, allowTransition: false);
                }

                return;
            }

            StopVisualTransition();
            m_ExposureGuard.Dispose();
        }

        protected override void OnDestroy()
        {
            if (m_OverrideActive && m_PlanetarySystem != null)
            {
                m_PlanetarySystem.overrideTime = false;
                m_OverrideActive = false;
            }

            StopVisualTransition();
            m_ExposureGuard.Dispose();

            base.OnDestroy();
        }

        private void OnSetDayNightMode(int mode)
        {
            SetMode(mode, allowTransition: true);
        }

        private void SetMode(int mode, bool allowTransition)
        {
            mode = Math.Clamp(mode, kModeAuto, kModeNight);
            int previousMode = m_DayNightModeBinding.value;

            if (m_DayNightModeBinding.value != mode)
            {
                m_DayNightModeBinding.Update(mode);
            }

            if (!allowTransition || !ShouldSmooth())
            {
                StopVisualTransition();
                ApplyModeImmediate(mode);
                return;
            }

            if (mode == previousMode && !m_Transitioning)
            {
                return;
            }

            StartTransition(previousMode, mode);
        }

        private void StartTransition(int previousMode, int targetMode)
        {
            if (m_PlanetarySystem == null)
            {
                return;
            }

            bool wasTransitioning = m_Transitioning;
            float startHour = NormalizeHour(m_PlanetarySystem.time);
            float targetHour = TargetHour(targetMode);

            // Stable Day <-> Night switches move forward through sunset or sunrise.
            // Auto changes and rapid reversals take the shorter path.
            bool useForwardPath =
                !wasTransitioning &&
                ((previousMode == kModeDay && targetMode == kModeNight) ||
                 (previousMode == kModeNight && targetMode == kModeDay));

            float distanceHours = useForwardPath
                ? ForwardHourDistance(startHour, targetHour)
                : ShortestHourDistance(startHour, targetHour);

            m_ExposureGuard.Begin();

            m_PlanetarySystem.overrideTime = true;
            m_OverrideActive = true;

            m_TransitionStartHour = startHour;
            m_TransitionDistanceHours = distanceHours;
            m_TransitionTargetMode = targetMode;
            m_TransitionElapsed = 0f;
            m_ExposureSettleRemaining = 0f;
            m_Transitioning = true;

            if (Math.Abs(distanceHours) < 0.001f)
            {
                CompleteTransition();
            }
        }

        private void AdvanceTransition(float deltaTime)
        {
            if (m_PlanetarySystem == null)
            {
                StopVisualTransition();
                return;
            }

            m_TransitionElapsed += Math.Max(0f, deltaTime);
            float progress = UnityEngine.Mathf.Clamp01(m_TransitionElapsed / kTransitionSeconds);

            // SmoothStep gives a gentle start and finish without pausing at intermediate hours.
            float eased = progress * progress * (3f - (2f * progress));
            float hour = m_TransitionStartHour + (m_TransitionDistanceHours * eased);

            m_PlanetarySystem.overrideTime = true;
            m_PlanetarySystem.time = NormalizeHour(hour);

            if (progress >= 1f)
            {
                CompleteTransition();
            }
        }

        private void CompleteTransition()
        {
            if (m_PlanetarySystem == null)
            {
                StopVisualTransition();
                return;
            }

            m_Transitioning = false;

            if (m_TransitionTargetMode == kModeAuto)
            {
                // Match the live vanilla clock before releasing overrideTime.
                m_PlanetarySystem.time = GetNaturalHour();
                m_PlanetarySystem.overrideTime = false;
                m_OverrideActive = false;
            }
            else
            {
                m_PlanetarySystem.overrideTime = true;
                m_PlanetarySystem.time = TargetHour(m_TransitionTargetMode);
                m_OverrideActive = true;
            }

            // Keep instant exposure for a few rendered frames after the final lighting state lands.
            m_ExposureSettleRemaining = kExposureSettleSeconds;
        }

        private void AdvanceExposureSettle(float deltaTime)
        {
            m_ExposureSettleRemaining -= Math.Max(0f, deltaTime);
            if (m_ExposureSettleRemaining <= 0f)
            {
                m_ExposureSettleRemaining = 0f;
                m_ExposureGuard.End();
            }
        }

        private void StopVisualTransition()
        {
            m_Transitioning = false;
            m_TransitionElapsed = 0f;
            m_ExposureSettleRemaining = 0f;
            m_ExposureGuard.End();
        }

        private void ApplyModeImmediate(int mode)
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
                    if (m_OverrideActive)
                    {
                        m_PlanetarySystem.overrideTime = false;
                        m_OverrideActive = false;
                    }

                    break;
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
            // Vanilla uses a fixed 14:30 scene when its Day/night visuals option is off.
            if (GameManager.instance?.gameMode == GameMode.Game &&
                SharedSettings.instance?.gameplay is GameplaySettings gameplay &&
                !gameplay.dayNightVisual)
            {
                return kVanillaFixedDayTime;
            }

            return NormalizeHour((m_TimeSystem?.normalizedTime ?? 0.5f) * kHoursPerDay);
        }

        private static float NormalizeHour(float hour)
        {
            return UnityEngine.Mathf.Repeat(hour, kHoursPerDay);
        }

        private static float ForwardHourDistance(float fromHour, float toHour)
        {
            return UnityEngine.Mathf.Repeat(toHour - fromHour, kHoursPerDay);
        }

        private static float ShortestHourDistance(float fromHour, float toHour)
        {
            return UnityEngine.Mathf.Repeat(
                toHour - fromHour + kHalfDay,
                kHoursPerDay) - kHalfDay;
        }

        private static bool ShouldSmooth()
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
