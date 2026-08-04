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

        // Wall-clock seconds that exposure adaptation stays instant after a switch — just long enough
        // for the histogram to settle on the new lighting.
        private const float kExposureGuardSeconds = 0.5f;

        // Light dim that softens the lighting cut. The exposure guard already removes the blowout, so
        // this only has to hide the one-frame jump — keep it gentle, never near-black.
        private const float kFadePeak = 0.55f;
        private const float kFadeInSeconds = 0.30f;
        private const float kFadeHoldSeconds = 0.08f;
        private const float kFadeOutSeconds = 0.50f;

        private readonly DayNightExposureGuard m_ExposureGuard = new();

        private ValueBinding<int> m_DayNightModeBinding = null!;
        private ValueBinding<float> m_FadeBinding = null!;
        private PlanetarySystem? m_PlanetarySystem;

        // Only release overrideTime if WE took control, so we never stomp another mod's override.
        private bool m_OverrideActive;

        private bool m_Fading;
        private float m_FadeElapsed;
        private int m_PendingMode;
        private bool m_ModeApplied;

        private bool m_GuardActive;
        private float m_GuardElapsed;

        // Optional hotkey — unbound by default (see CwdSettings.ToggleDayNightKeyboardBinding).
        private ProxyAction? m_ToggleDayNightAction;

        // Run in the map editor as well as in a city, so the hotkey works while editing maps.
        public override GameMode gameMode => GameMode.GameOrEditor;

        protected override void OnCreate()
        {
            base.OnCreate();

            m_PlanetarySystem = World.GetOrCreateSystemManaged<PlanetarySystem>();
            m_DayNightModeBinding = AddValueBinding("DayNightMode", kModeAuto);
            m_FadeBinding = AddValueBinding("DayNightFade", 0f);
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

            if (m_Fading)
            {
                AdvanceFade();
            }

            if (m_GuardActive)
            {
                // Wall-clock delta so the window also elapses while the sim is paused.
                m_GuardElapsed += UnityEngine.Time.deltaTime;
                if (m_GuardElapsed >= kExposureGuardSeconds)
                {
                    m_ExposureGuard.End();
                    m_GuardActive = false;
                }
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

            if (mode.IsGameOrEditor() && (purpose == Purpose.NewGame || purpose == Purpose.LoadGame))
            {
                SetMode(kModeAuto, allowTransition: false);
            }
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

            if (m_GuardActive)
            {
                m_ExposureGuard.End();
                m_GuardActive = false;
            }

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

            if (allowTransition && ShouldSmooth())
            {
                // The sun change is deferred to the dim's low point (see AdvanceFade).
                m_PendingMode = mode;
                m_ModeApplied = false;
                m_FadeElapsed = 0f;
                m_Fading = true;
                return;
            }

            CancelFade();
            ApplyMode(mode);
        }

        private static bool ShouldSmooth()
        {
            return IsInGameOrEditor() && (CwdSettings.Instance?.SmoothDayNightTransition ?? true);
        }

        private void CancelFade()
        {
            m_Fading = false;
            if (m_FadeBinding.value != 0f)
            {
                m_FadeBinding.Update(0f);
            }
        }

        private void AdvanceFade()
        {
            // Wall-clock delta so the dim plays even while the sim is paused.
            m_FadeElapsed += UnityEngine.Time.deltaTime;

            float holdEnd = kFadeInSeconds + kFadeHoldSeconds;
            float end = holdEnd + kFadeOutSeconds;
            float opacity;

            if (m_FadeElapsed < kFadeInSeconds)
            {
                opacity = kFadePeak * (m_FadeElapsed / kFadeInSeconds);
            }
            else if (m_FadeElapsed < holdEnd)
            {
                opacity = kFadePeak;
                ApplyPendingModeOnce();
            }
            else if (m_FadeElapsed < end)
            {
                opacity = kFadePeak * (1f - ((m_FadeElapsed - holdEnd) / kFadeOutSeconds));
            }
            else
            {
                ApplyPendingModeOnce();   // safety if the hold window was skipped by a long frame
                opacity = 0f;
                m_Fading = false;
            }

            m_FadeBinding.Update(opacity);
        }

        // Exposure must go instant BEFORE the time changes, or it ramps through the flash.
        private void ApplyPendingModeOnce()
        {
            if (m_ModeApplied)
            {
                return;
            }

            m_ModeApplied = true;

            if (m_ExposureGuard.Begin())
            {
                m_GuardActive = true;
                m_GuardElapsed = 0f;
            }

            ApplyMode(m_PendingMode);
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
