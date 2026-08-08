// <copyright file="DayNightControlSystem.DayPreset.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the MIT License. You may not use this file except in compliance with this License.
// See LICENSE file in the project root for full license information.
// This notice and the MIT License notice must be kept with
// all copies or substantial portions of this code.
// ================= </copyright> ======================

// File: Systems/Controls/DayNightControlSystem.DayPreset.cs
// Purpose: Selects the configured Day clock time without touching map latitude/longitude.

namespace CityWatchdog.Systems
{
    public partial class DayNightControlSystem
    {
        private const float kSoftDayTime = 15f + (40f / 60f);

        private static float GetSelectedDayTime()
        {
            int preset =
                CwdSettings.Instance.DayVisualPreset;

            return preset switch
            {
                CwdSettings.kDayVisualPresetBright => kDayTime,
                CwdSettings.kDayVisualPresetSoft => kSoftDayTime,
                _ => kVanillaFixedDayTime,
            };
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
