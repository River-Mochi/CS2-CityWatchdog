// <copyright file="DayNightControlSystem.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the MIT License. You may not use this file except in compliance with this License.
// See LICENSE file in the project root for full license information.
// This notice and the MIT License notice must be kept with
// all copies or substantial portions of this code.
// ================= </copyright> ======================

// File: Systems/DayNightControlSystem.cs
// Purpose: Title-bar Day/Night button. Freezes the sun at noon or 2 AM, or lets the natural cycle run.

namespace CityWatchdog.Systems
{
    using Colossal.Serialization.Entities;
    using Colossal.UI.Binding;
    using CS2Shared.RiverMochi;
    using Game;
    using Game.Simulation;

    // Nothing here is saved. The whole feature is two live properties on the vanilla PlanetarySystem
    // (overrideTime + time), neither of which the game serializes — so a reboot, or uninstalling CWD,
    // always returns to the normal moving cycle. No save file is ever touched.
    public partial class DayNightControlSystem : UISystemBaseExtension
    {
        // 0/1/2 mirror TimeWeatherAnarchy's Default/Day/Night (minus its Custom + season/geo options).
        private const int kModeAuto = 0;
        private const int kModeDay = 1;
        private const int kModeNight = 2;

        // Hours (0-24) fed straight into PlanetarySystem.time. 2 AM sits in the deepest dark.
        private const float kDayTime = 12f;
        private const float kNightTime = 2f;

        private ValueBinding<int> m_DayNightModeBinding = null!;
        private PlanetarySystem? m_PlanetarySystem;

        // Only release overrideTime if WE took control, so we never stomp another mod's override.
        private bool m_OverrideActive;

        protected override void OnCreate()
        {
            base.OnCreate();

            m_PlanetarySystem = World.GetOrCreateSystemManaged<PlanetarySystem>();
            m_DayNightModeBinding = AddValueBinding("DayNightMode", kModeAuto);
            AddTriggerBinding<int>("SetDayNightMode", OnSetDayNightMode);
        }

        // Fresh city shouldn't inherit a frozen sun from the previous one — back to Auto on real loads.
        protected override void OnGameLoadingComplete(Purpose purpose, GameMode mode)
        {
            base.OnGameLoadingComplete(purpose, mode);

            if (mode == GameMode.Game && (purpose == Purpose.NewGame || purpose == Purpose.LoadGame))
            {
                SetMode(kModeAuto);
            }
        }

        // Restore the natural cycle on unload so disabling CWD can never leave the sun stuck.
        protected override void OnDestroy()
        {
            if (m_OverrideActive && m_PlanetarySystem != null)
            {
                m_PlanetarySystem.overrideTime = false;
                m_OverrideActive = false;
            }

            base.OnDestroy();
        }

        private void OnSetDayNightMode(int mode) => SetMode(mode);

        private void SetMode(int mode)
        {
            if (mode < kModeAuto || mode > kModeNight)
            {
                mode = kModeAuto;
            }

            if (m_DayNightModeBinding.value != mode)
            {
                m_DayNightModeBinding.Update(mode);
            }

            ApplyMode(mode);
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
    }
}
