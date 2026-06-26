// <copyright file="MiniHudLocale.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the MIT License. You may not use this file except in compliance with this License.
// See LICENSE file in the project root for full license information.
// This notice and the MIT License notice must be kept with
// all copies or substantial portions of this code.
// ================= </copyright> ======================

// File: src/Localization/MiniHudLocale.cs
// Purpose: English fallback Options strings for the notification mini HUD.

namespace CityWatchdog
{
    using System.Collections.Generic;
    using Colossal;
    using Game.UI.Editor;

    internal sealed class MiniHudLocale : IDictionarySource
    {
        private readonly Setting settings;

        public MiniHudLocale(Setting settings)
        {
            this.settings = settings;
        }

        public IEnumerable<KeyValuePair<string, string>> ReadEntries(
            IList<IDictionaryEntryError> errors,
            Dictionary<string, int> indexCounts)
        {
            return new Dictionary<string, string>
            {
                { settings.GetOptionGroupLocaleID(Setting.MiniHudGroup), "Mini HUD Notifications" },
                { settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudEnabled)), "Show Mini HUD" },
                { settings.GetOptionDescLocaleID(nameof(Setting.MiniHudEnabled)), "Show a compact bar with notification icons and current city totals." },
                { settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudMode)), "Mini HUD Content" },
                { settings.GetOptionDescLocaleID(nameof(Setting.MiniHudMode)), "Top Active shows the largest current totals. Favorites uses stars selected in the expanded City Watchdog panel." },
                { settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudItemCount)), "Maximum Icons" },
                { settings.GetOptionDescLocaleID(nameof(Setting.MiniHudItemCount)), "Show up to 5 or 10 notification icons." },
                { settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudOrientation)), "Orientation" },
                { settings.GetOptionDescLocaleID(nameof(Setting.MiniHudOrientation)), "Arrange the mini HUD horizontally or vertically." },
                { settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudPlacement)), "Position" },
                { settings.GetOptionDescLocaleID(nameof(Setting.MiniHudPlacement)), "Use a fixed screen position or choose Draggable and move the grip." },
                { settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudHideZero)), "Hide Zero Totals" },
                { settings.GetOptionDescLocaleID(nameof(Setting.MiniHudHideZero)), "Hide notification types whose current city total is zero." },
                { settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudGlassStyle)), "Glass Style" },
                { settings.GetOptionDescLocaleID(nameof(Setting.MiniHudGlassStyle)), "Use a lighter glass-like mini HUD background instead of the darker gray panel." },
                { settings.GetOptionLocaleID("MiniHudModeTopActive"), "Top Active" },
                { settings.GetOptionLocaleID("MiniHudModeFavorites"), "Favorites" },
                { settings.GetOptionLocaleID("MiniHudOrientationHorizontal"), "Horizontal" },
                { settings.GetOptionLocaleID("MiniHudOrientationVertical"), "Vertical" },
                { settings.GetOptionLocaleID("MiniHudPlacementTopCenter"), "Top Center" },
                { settings.GetOptionLocaleID("MiniHudPlacementTopRight"), "Top Right" },
                { settings.GetOptionLocaleID("MiniHudPlacementDraggable"), "Draggable" },
            };
        }

        public void Unload()
        {
        }
    }
}
