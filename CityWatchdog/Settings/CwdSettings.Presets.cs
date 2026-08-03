// <copyright file="CwdSettings.Presets.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the MIT License. You may not use this file except in compliance with this License.
// See LICENSE file in the project root for full license information.
// This notice and the MIT License notice must be kept with
// all copies or substantial portions of this code.
// ================= </copyright> ======================

// File: src/Settings/CwdSettings.Presets.cs
// Purpose: Saved notification-checkbox layouts for the in-city "1 | 2" preset buttons.

namespace CityWatchdog
{
    using Game.Settings;

    public partial class CwdSettings
    {
        // Click loads a slot; hold saves the current checkbox layout.
        // Full NotificationSetting copies avoid a separate index map to maintain.
        [SettingsUIHidden]
        public NotificationSetting Preset1 { get; set; } = new NotificationSetting();

        [SettingsUIHidden]
        public NotificationSetting Preset2 { get; set; } = new NotificationSetting();

        // Unsaved slots stay dim and ignore clicks until the player saves a layout.
        [SettingsUIHidden]
        public bool Preset1Saved { get; set; }

        [SettingsUIHidden]
        public bool Preset2Saved { get; set; }

        // Selected slot in the panel: 0 = none, 1 or 2.
        // Cleared when Show/Hide Icons or a manual checkbox changes the live layout.
        [SettingsUIHidden]
        public int ActivePreset { get; set; }

        // A full settings reset also clears both preset slots.
        private void ResetPresets()
        {
            Preset1 = new NotificationSetting();
            Preset2 = new NotificationSetting();
            Preset1Saved = false;
            Preset2Saved = false;
            ActivePreset = 0;
        }
    }
}
