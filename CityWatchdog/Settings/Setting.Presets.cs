// <copyright file="Setting.Presets.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the MIT License. You may not use this file except in compliance with this License.
// See LICENSE file in the project root for full license information.
// This notice and the MIT License notice must be kept with
// all copies or substantial portions of this code.
// ================= </copyright> ======================

// File: src/Settings/CwdSettings.Presets.cs
// Purpose: Two saved notification-checkbox presets driven by the in-city panel "1 | 2" buttons.

namespace CityWatchdog
{
    using Game.Settings;

    public partial class CwdSettings
    {
        // Two saved snapshots of the notification checkboxes. The in-city panel exposes them as a
        // "1 | 2" split button: click a slot to LOAD it, hold a slot to SAVE the current checkboxes
        // into it. Stored as full NotificationSetting copies so we reuse the same nested-object
        // serialization the live Notification set already uses — no countIndex bit-mapping to keep in
        // sync (unlike the Mini HUD favorite masks). [SettingsUIHidden] keeps them out of the Options
        // UI; they are panel-only state.
        [SettingsUIHidden]
        public NotificationSetting Preset1 { get; set; } = new NotificationSetting();

        [SettingsUIHidden]
        public NotificationSetting Preset2 { get; set; } = new NotificationSetting();

        // False until the player first saves into the slot. An unsaved slot renders dimmed and ignores
        // a load click, so a fresh install can never wipe the live set with an empty (all-off) preset.
        [SettingsUIHidden]
        public bool Preset1Saved { get; set; }

        [SettingsUIHidden]
        public bool Preset2Saved { get; set; }

        // Called from SetDefaults so a full settings reset also clears both preset slots.
        private void ResetPresets()
        {
            Preset1 = new NotificationSetting();
            Preset2 = new NotificationSetting();
            Preset1Saved = false;
            Preset2Saved = false;
        }
    }
}
