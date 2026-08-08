// <copyright file="DayNightControlSystem.DayPreset.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the MIT License. You may not use this file except in compliance with this License.
// See LICENSE file in the project root for full license information.
// This notice and the MIT License notice must be kept with
// all copies or substantial portions of this code.
// ================= </copyright> ======================

// File: Systems/Controls/DayNightControlSystem.DayPreset.cs
// Purpose: Day visual preset clock + fixed vanilla Day runtime context.

namespace CityWatchdog.Systems
{
    using Game.Simulation;

    public partial class DayNightControlSystem
    {
        private const float kSoftDayTime = 15f + (40f / 60f);

        // Vanilla fixed-Day values, confirmed at runtime on CS2 1.6.*.
        // Never write these values into PlanetarySystem, doesn't change the map, just applies at runtime for Day visual.
        internal const float kVanillaDayLatitude = 51.2277f;
        internal const float kVanillaDayLongitude = 6.7735f;
        internal const float kVanillaFixedDayTime = 14.5f;
        internal const int kVanillaDay = 177;
        internal const int kVanillaDayYear = 2020;

        private DayVisualContextSystem? m_DayVisualContextSystem;

        private static int GetSelectedDayPreset()
        {
            int preset =
                CwdSettings.Instance.DayVisualPreset;

            return preset switch
            {
                CwdSettings.kDayVisualPresetBright =>
                    CwdSettings.kDayVisualPresetBright,
                CwdSettings.kDayVisualPresetSoft =>
                    CwdSettings.kDayVisualPresetSoft,
                _ =>
                    CwdSettings.kDayVisualPresetVanilla,
            };
        }

        private static float GetSelectedDayTime()
        {
            return GetSelectedDayPreset() switch
            {
                CwdSettings.kDayVisualPresetBright => kDayTime,
                CwdSettings.kDayVisualPresetSoft => kSoftDayTime,
                _ => kVanillaFixedDayTime,
            };
        }

        private void ApplySelectedDayContext(
            PlanetarySystem planetarySystem)
        {
            // day/year/time are runtime visual state only; PlanetarySystem serializes only map lat/lon.
            planetarySystem.overrideTime = true;
            planetarySystem.day = kVanillaDay;
            planetarySystem.year = kVanillaDayYear;
            planetarySystem.time = GetSelectedDayTime();

            m_DayVisualContextSystem ??=
                World.GetOrCreateSystemManaged<DayVisualContextSystem>();

            m_DayVisualContextSystem.Activate(
                GetSelectedDayPreset(),
                planetarySystem.time,
                planetarySystem.latitude,
                planetarySystem.longitude);
        }

        private void RestoreSimulationDateForNight(
            PlanetarySystem planetarySystem)
        {
            TimeSystem? timeSystem =
                m_TimeSystem;

            if (timeSystem == null)
            {
                return;
            }

            // Night keeps the live simulation date/year; only its visual clock is fixed at 1 AM.
            planetarySystem.normalizedDayOfYear =
                timeSystem.normalizedDate;
            planetarySystem.year =
                timeSystem.year;
        }

        private void DeactivateDayVisualContext()
        {
            m_DayVisualContextSystem?.Deactivate();
        }

        internal void RefreshDayPresetFromSettings()
        {
            if (m_AppliedMode != kModeDay)
            {
                return;
            }

            // Queue into PreCulling instead of changing PlanetarySystem from Options UI timing.
            QueueMode(
                kModeDay,
                useProtection: true,
                captureDebug: true,
                force: true);
        }
    }
}
