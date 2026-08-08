// <copyright file="CwdSettings.DayNight.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the MIT License. You may not use this file except in compliance with this License.
// See LICENSE file in the project root for full license information.
// This notice and the MIT License notice must be kept with
// all copies or substantial portions of this code.
// ================= </copyright> ======================

// File: Settings/CwdSettings.DayNight.cs
// Purpose: Day visual preset dropdown values and Options callback.

namespace CityWatchdog
{
    using CityWatchdog.Systems;

    using Game.UI.Widgets;

    using Unity.Entities;

    public partial class CwdSettings
    {
        // Zero is Vanilla so a newly added/missing saved value safely defaults to Vanilla Day.
        internal const int kDayVisualPresetVanilla = 0;
        internal const int kDayVisualPresetBright = 1;
        internal const int kDayVisualPresetSoft = 2;

        public DropdownItem<int>[] GetDayVisualPresetItems()
        {
            return new[]
            {
                new DropdownItem<int>
                {
                    value = kDayVisualPresetBright,
                    displayName = GetOptionLocaleID("DayVisualPresetBright"),
                },
                new DropdownItem<int>
                {
                    value = kDayVisualPresetVanilla,
                    displayName = GetOptionLocaleID("DayVisualPresetVanilla"),
                },
                new DropdownItem<int>
                {
                    value = kDayVisualPresetSoft,
                    displayName = GetOptionLocaleID("DayVisualPresetSoft"),
                },
            };
        }

        private static void OnDayVisualPresetChanged(int value)
        {
            _ = value;

            World.DefaultGameObjectInjectionWorld?
                .GetExistingSystemManaged<DayNightControlSystem>()?
                .RefreshDayPresetFromSettings();
        }
    }
}
