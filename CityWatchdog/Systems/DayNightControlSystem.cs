// <copyright file="DayNightControlSystem.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the MIT License. You may not use this file except in compliance with this License.
// See LICENSE file in the project root for full license information.
// This notice and the MIT License notice must be kept with
// all copies or substantial portions of this code.
// ================= </copyright> ======================

// File: Systems/DayNightControlSystem.cs
// Purpose: Day/Night control for the panel button (city) and the hotkey (city AND map editor). Freezes
//          the sun at noon or 2 AM, or lets the natural cycle run.

namespace CityWatchdog.Systems
{
    using System;

    using Colossal.Serialization.Entities;
    using Colossal.UI.Binding;
    using CS2Shared.RiverMochi;
    using Game;
    using Game.Input;
    using Game.SceneFlow;
    using Game.Simulation;

    // Day/Night state is never saved: overrideTime/time are runtime-only, so uninstalling CWD or a
    // reboot always returns to the normal cycle. See docs/internals.md.
    public partial class DayNightControlSystem : UISystemBaseExtension
    {
        private const int kModeAuto = 0;
        private const int kModeDay = 1;
        private const int kModeNight = 2;

        // Hours (0-24) fed into PlanetarySystem.time. 2 AM sits in the deepest dark.
        private const float kDayTime = 12f;
        private const float kNightTime = 2f;

        // Brightness ramp. The time changes instantly, then exposure compensation starts the new scene
        // at the OLD scene's brightness and eases to 0 — so day->night only ever gets darker and
        // night->day only ever gets brighter. No dip, no overshoot.
        private const float kTransitionSeconds = 1.1f;
        private const float kMaxCompensationEV = 3f;   // EV offset for a full noon <-> midnight swing

        private readonly DayNightExposureGuard m_ExposureGuard = new();

        private ValueBinding<int> m_DayNightModeBinding = null!;
        private PlanetarySystem? m_PlanetarySystem;
        private TimeSystem? m_TimeSystem;

        // Only release overrideTime if WE took control, so we never stomp another mod's override.
        private bool m_OverrideActive;

        private bool m_Ramping;
        private float m_RampElapsed;
        private float m_StartCompensation;

        // Optional hotkey — unbound by default (see CwdSettings.ToggleDayNightKeyboardBinding).
        private ProxyAction? m_ToggleDayNightAction;

        // Run in the map editor as well as in a city, so the hotkey works while editing maps.
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

            if (m_Ramping)
            {
                AdvanceRamp();
            }
        }

        // Day <-> Night only (like TWA). Auto stays button-only so the hotkey can't land on a mode that
        // drifts back to night on its own. From Auto, first press goes to Day.
        private void ToggleDayNight()
        {
            SetMode(m_DayNightModeBinding.value == kModeDay ? kModeNight : kModeDay, allowTransition: true);
        }

        // Fresh city/map shouldn't inherit a frozen sun from the previous one — back to Auto on real
        // loads. Also (re)enable the hotkey for whichever mode we entered.
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

            // Leaving to the main menu: drop our volume so nothing of ours sits in the render stack
            // while no city is loaded. Rebuilt on the next load.
            EndRamp();
            m_ExposureGuard.Dispose();
        }

        // Restore the natural cycle and drop our exposure volume on unload, so disabling CWD leaves
        // nothing behind.
        protected override void OnDestroy()
        {
            if (m_OverrideActive && m_PlanetarySystem != null)
            {
                m_PlanetarySystem.overrideTime = false;
                m_OverrideActive = false;
            }

            EndRamp();
            m_ExposureGuard.Dispose();

            base.OnDestroy();
        }

        private void OnSetDayNightMode(int mode) => SetMode(mode, allowTransition: true);

        private void SetMode(int mode, bool allowTransition)
        {
            if (mode < kModeAuto || mode > kModeNight)
            {
                mode = kModeAuto;
            }

            if (m_DayNightModeBinding.value != mode)
            {
                m_DayNightModeBinding.Update(mode);
            }

            if (!allowTransition || !ShouldSmooth())
            {
                EndRamp();
                ApplyMode(mode);
                return;
            }

            // Brightness difference between where we are and where we're going decides which way (and
            // how far) to offset exposure, so partial changes (dusk -> noon) ramp less than a full swing.
            float fromLight = DaylightAmount(m_PlanetarySystem?.time ?? 12f);
            float toLight = DaylightAmount(TargetHour(mode));
            m_StartCompensation = (fromLight - toLight) * kMaxCompensationEV;

            if (m_ExposureGuard.Begin())
            {
                m_ExposureGuard.SetCompensation(m_StartCompensation);
                m_RampElapsed = 0f;
                m_Ramping = true;
            }

            ApplyMode(mode);
        }

        private float TargetHour(int mode) => mode switch
        {
            kModeDay => kDayTime,
            kModeNight => kNightTime,
            _ => (m_TimeSystem?.normalizedTime ?? 0.5f) * 24f,
        };

        // 1 at noon, 0 at midnight — a cheap stand-in for how bright the scene will be at that hour.
        private static float DaylightAmount(float hour)
        {
            return (UnityEngine.Mathf.Cos((hour - 12f) / 12f * UnityEngine.Mathf.PI) + 1f) * 0.5f;
        }

        private void AdvanceRamp()
        {
            // Wall-clock delta so the ramp plays even while the sim is paused.
            m_RampElapsed += UnityEngine.Time.deltaTime;
            float k = m_RampElapsed / kTransitionSeconds;

            if (k >= 1f)
            {
                EndRamp();
                return;
            }

            // Ease-out: most of the correction happens early, then it settles gently.
            float eased = 1f - ((1f - k) * (1f - k));
            m_ExposureGuard.SetCompensation(m_StartCompensation * (1f - eased));
        }

        private void EndRamp()
        {
            if (m_Ramping)
            {
                m_Ramping = false;
            }

            m_ExposureGuard.End();
        }

        private static bool ShouldSmooth()
        {
            return IsInGameOrEditor() && (CwdSettings.Instance?.SmoothDayNightTransition ?? true);
        }

        // Set-once: with overrideTime=true, PlanetarySystem stops recomputing time from the sim clock,
        // so the value holds without us writing every frame (which would fight Photo Mode's own slider).
        private void ApplyMode(int mode)
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

                default: // Auto — hand the clock back only if we were the ones holding it.
                    if (m_OverrideActive)
                    {
                        m_PlanetarySystem.overrideTime = false;
                        m_OverrideActive = false;
                    }

                    break;
            }
        }

        private static bool IsInGameOrEditor()
        {
            return GameManager.instance != null &&
                   GameManager.instance.gameMode.IsGameOrEditor();
        }

        // Matches the EnableHotkey helper in RoadNameControlSystem / TooltipControlSystem.
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
