// <copyright file="Setting.MiniHud.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the MIT License. You may not use this file except in compliance with this License.
// See LICENSE file in the project root for full license information.
// This notice and the MIT License notice must be kept with
// all copies or substantial portions of this code.
// ================= </copyright> ======================

// File: src/Settings/Setting.MiniHud.cs
// Purpose: Defines City Watchdog Mini HUD Options settings, defaults, and bindings.

namespace CityWatchdog
{
    using System;
    using CityWatchdog.Systems;
    using CS2Shared.RiverMochi;
    using Game.Settings;
    using Game.UI;
    using Game.UI.Widgets;

    public partial class Setting
    {
        internal const int MiniHudModeTopActive = 0;
        internal const int MiniHudModeFavorites = 1;
        internal const int MiniHudOrientationHorizontal = 0;
        internal const int MiniHudOrientationVertical = 1;
        internal const int MiniHudPlacementTopCenter = 0;
        internal const int MiniHudPlacementTopRight = 1;
        internal const int MiniHudPlacementDraggable = 2;
        internal const int MiniHudPanelStyleDark = 0;
        internal const int MiniHudPanelStyleGlass = 1;
        internal const int MiniHudPanelOpacityDefault = 30;
        internal const int MiniHudPositionLimit = 20000;
        // Bit positions are raw countIndex values (see notificationData.ts) — NOT re-derived from
        // any enum, so they must be hand-verified against the current index table whenever items are
        // inserted/removed. Bit 24 (Leveling Building) is deliberately NOT included: it's an optional,
        // positive-status row the player opts into manually, not a recommended "problem" alert.
        private const int MiniHudRecommendedFavoriteMaskLow =
            (1 << 0) |  // Not enough electricity
            (1 << 1) |  // Electricity bottleneck
            (1 << 6) |  // Battery depleted
            (1 << 7) |  // Electric cable not connected
            (1 << 8) |  // Power line not connected
            (1 << 9) |  // Not enough water
            (1 << 11) | // Backed up sewer
            (1 << 12) | // Water pipe not connected
            (1 << 13) | // Sewer pipe not connected
            (1 << 19) | // Collapsed
            (1 << 20) | // Abandoned
            (1 << 21) | // Condemned
            (1 << 22) | // Deactivated
            (1 << 23) | // High rent
            (1 << 25) | // Traffic jam
            (1 << 27) | // Road required / no road access
            (1 << 28) | // Track not connected
            (1 << 29);  // No car access
        private const int MiniHudRecommendedFavoriteMaskHigh =
            (1 << 1) |  // No pedestrian access
            (1 << 5) |  // Lack of labor
            (1 << 7) |  // Weather damage
            (1 << 9) |  // Water damage
            (1 << 12) | // On fire
            (1 << 13) | // Burned down
            (1 << 14) | // Garbage piling up
            (1 << 15) | // Facility full (Garbage)
            (1 << 17) | // Waiting for a hearse
            (1 << 18) | // Facility full (Healthcare)
            (1 << 19) | // Traffic accident
            (1 << 20) | // Crime scene
            (1 << 24) | // Low supplies
            (1 << 25) | // Out of fuel
            (1 << 29) | // Pathfinding failed
            (1 << 31);  // No vehicles



        // Mini-HUD tab - Mini HUD Notifications
        // --------------------------------------------------------------------

        [SettingsUISection(MiniHudTab, MiniHudGroup)]
        [SettingsUISetter(typeof(Setting), nameof(OnMiniHudEnabledChanged))]
        public bool MiniHudEnabled { get; set; }

        [SettingsUIButton]
        [SettingsUISection(MiniHudTab, MiniHudGroup)]
        public bool ApplyMiniHudRecommendedPreset
        {
            set
            {
                if (!value)
                {
                    return;
                }

                ApplyMiniHudStarterPresetValues();

                CityWatchdogUISystem? uiSystem = GetUISystem();
                uiSystem?.UpdateMiniHudEnabledBinding(MiniHudEnabled);
                uiSystem?.UpdateMiniHudModeBinding(MiniHudMode);
                uiSystem?.UpdateMiniHudItemCountBinding(MiniHudItemCount);
                uiSystem?.UpdateMiniHudScaleBinding(MiniHudScale);
                uiSystem?.UpdateMiniHudOrientationBinding(MiniHudOrientation);
                uiSystem?.UpdateMiniHudPlacementBinding(MiniHudPlacement);
                uiSystem?.UpdateMiniHudHideZeroBinding(MiniHudHideZero);
                uiSystem?.UpdateMiniHudPanelStyleBinding(MiniHudPanelStyle);
                uiSystem?.UpdateMiniHudPanelOpacityBinding(MiniHudPanelOpacity);
                uiSystem?.UpdateMiniHudPositionBindings();
                uiSystem?.UpdateMiniHudFavoritesBinding();

                try
                {
                    ApplyAndSave();
                }
                catch (Exception ex)
                {
                    LogUtils.WarnOnce(
                        "mini-hud-recommended-preset-save",
                        () => $"Failed to save Mini HUD recommended preset: {ex.GetType().Name}: {ex.Message}",
                        ex);
                }
            }
        }

        [SettingsUIDropdown(typeof(Setting), nameof(GetMiniHudModeItems))]
        [SettingsUISection(MiniHudTab, MiniHudGroup)]
        [SettingsUIDisableByCondition(typeof(Setting), nameof(EnsureMiniHudEnabled))]
        [SettingsUISetter(typeof(Setting), nameof(OnMiniHudModeChanged))]
        public int MiniHudMode { get; set; }

        [SettingsUIDropdown(typeof(Setting), nameof(GetMiniHudItemCountItems))]
        [SettingsUISection(MiniHudTab, MiniHudGroup)]
        [SettingsUIDisableByCondition(typeof(Setting), nameof(EnsureMiniHudEnabled))]
        [SettingsUISetter(typeof(Setting), nameof(OnMiniHudItemCountChanged))]
        public int MiniHudItemCount { get; set; }

        [SettingsUISection(MiniHudTab, MiniHudGroup)]
        [SettingsUIDisableByCondition(typeof(Setting), nameof(EnsureMiniHudEnabled))]
        [SettingsUISetter(typeof(Setting), nameof(OnMiniHudHideZeroChanged))]
        public bool MiniHudHideZero { get; set; }

        [SettingsUISlider(min = 90, max = 130, step = 5, scalarMultiplier = 1, unit = Unit.kPercentage)]
        [SettingsUISection(MiniHudTab, MiniHudGroup)]
        [SettingsUIDisableByCondition(typeof(Setting), nameof(EnsureMiniHudEnabled))]
        [SettingsUISetter(typeof(Setting), nameof(OnMiniHudScaleChanged))]
        public int MiniHudScale { get; set; }

        [SettingsUIDropdown(typeof(Setting), nameof(GetMiniHudOrientationItems))]
        [SettingsUISection(MiniHudTab, MiniHudGroup)]
        [SettingsUIDisableByCondition(typeof(Setting), nameof(EnsureMiniHudEnabled))]
        [SettingsUISetter(typeof(Setting), nameof(OnMiniHudOrientationChanged))]
        public int MiniHudOrientation { get; set; }

        [SettingsUIDropdown(typeof(Setting), nameof(GetMiniHudPlacementItems))]
        [SettingsUISection(MiniHudTab, MiniHudGroup)]
        [SettingsUIDisableByCondition(typeof(Setting), nameof(EnsureMiniHudEnabled))]
        [SettingsUISetter(typeof(Setting), nameof(OnMiniHudPlacementChanged))]
        public int MiniHudPlacement { get; set; }

        [SettingsUIDropdown(typeof(Setting), nameof(GetMiniHudPanelStyleItems))]
        [SettingsUISection(MiniHudTab, MiniHudGroup)]
        [SettingsUIDisableByCondition(typeof(Setting), nameof(EnsureMiniHudEnabled))]
        [SettingsUISetter(typeof(Setting), nameof(OnMiniHudPanelStyleChanged))]
        public int MiniHudPanelStyle { get; set; }

        [SettingsUISlider(min = 30, max = 100, step = 5, scalarMultiplier = 1, unit = Unit.kPercentage)]
        [SettingsUISection(MiniHudTab, MiniHudGroup)]
        [SettingsUIDisableByCondition(typeof(Setting), nameof(EnsureMiniHudEnabled))]
        [SettingsUISetter(typeof(Setting), nameof(OnMiniHudPanelOpacityChanged))]
        public int MiniHudPanelOpacity { get; set; }

        [SettingsUIHidden]
        public bool MiniHudGlassStyle { get; set; }

        // Two 31-bit masks persist the 62 row favorites without exposing 62 Options toggles.
        [SettingsUIHidden]
        public int MiniHudFavoriteMaskLow { get; set; }

        [SettingsUIHidden]
        public int MiniHudFavoriteMaskHigh { get; set; }

        [SettingsUIHidden]
        public int MiniHudPositionX { get; set; }

        [SettingsUIHidden]
        public int MiniHudPositionY { get; set; }

        [SettingsUIHidden]
        public int MiniHudPositionOrientation { get; set; }

        [SettingsUIHidden]
        public int MiniHudHorizontalPositionX { get; set; }

        [SettingsUIHidden]
        public int MiniHudHorizontalPositionY { get; set; }

        [SettingsUIHidden]
        public int MiniHudVerticalPositionX { get; set; }

        [SettingsUIHidden]
        public int MiniHudVerticalPositionY { get; set; }



        // --------------------------------------------------------------------
        // Mini HUD conditions and helpers
        // --------------------------------------------------------------------

        public bool EnsureMiniHudEnabled()
        {
            return !MiniHudEnabled;
        }


        // --------------------------------------------------------------------
        // Mini HUD dropdown data
        // --------------------------------------------------------------------

        public DropdownItem<int>[] GetMiniHudModeItems()
        {
            return new[]
            {
                new DropdownItem<int>
                {
                    value = MiniHudModeTopActive,
                    displayName = GetOptionLocaleID("MiniHudModeTopActive"),
                },
                new DropdownItem<int>
                {
                    value = MiniHudModeFavorites,
                    displayName = GetOptionLocaleID("MiniHudModeFavorites"),
                },
            };
        }

        public DropdownItem<int>[] GetMiniHudItemCountItems()
        {
            return new[]
            {
                CreateDropdownItem(5),
                CreateDropdownItem(10),
            };
        }

        public DropdownItem<int>[] GetMiniHudOrientationItems()
        {
            return new[]
            {
                new DropdownItem<int>
                {
                    value = MiniHudOrientationHorizontal,
                    displayName = GetOptionLocaleID("MiniHudOrientationHorizontal"),
                },
                new DropdownItem<int>
                {
                    value = MiniHudOrientationVertical,
                    displayName = GetOptionLocaleID("MiniHudOrientationVertical"),
                },
            };
        }

        public DropdownItem<int>[] GetMiniHudPlacementItems()
        {
            return new[]
            {
                new DropdownItem<int>
                {
                    value = MiniHudPlacementTopCenter,
                    displayName = GetOptionLocaleID("MiniHudPlacementTopCenter"),
                },
                new DropdownItem<int>
                {
                    value = MiniHudPlacementTopRight,
                    displayName = GetOptionLocaleID("MiniHudPlacementTopRight"),
                },
                new DropdownItem<int>
                {
                    value = MiniHudPlacementDraggable,
                    displayName = GetOptionLocaleID("MiniHudPlacementDraggable"),
                },
            };
        }

        public DropdownItem<int>[] GetMiniHudPanelStyleItems()
        {
            return new[]
            {
                new DropdownItem<int>
                {
                    value = MiniHudPanelStyleDark,
                    displayName = GetOptionLocaleID("MiniHudPanelStyleDark"),
                },
                new DropdownItem<int>
                {
                    value = MiniHudPanelStyleGlass,
                    displayName = GetOptionLocaleID("MiniHudPanelStyleGlass"),
                },
            };
        }

        private void ApplyMiniHudStarterPresetValues()
        {
            MiniHudEnabled = true;
            MiniHudMode = MiniHudModeFavorites;
            MiniHudItemCount = 5;
            MiniHudScale = 100;
            MiniHudOrientation = MiniHudOrientationVertical;
            MiniHudPlacement = MiniHudPlacementDraggable;
            MiniHudHideZero = true;
            MiniHudPanelStyle = MiniHudPanelStyleDark;
            MiniHudPanelOpacity = MiniHudPanelOpacityDefault;
            MiniHudGlassStyle = false;
            MiniHudPositionX = 0;
            MiniHudPositionY = 0;
            MiniHudPositionOrientation = MiniHudOrientation;
            MiniHudHorizontalPositionX = 0;
            MiniHudHorizontalPositionY = 0;
            MiniHudVerticalPositionX = 0;
            MiniHudVerticalPositionY = 0;
            SetMiniHudRecommendedFavorites();
        }


        public void NormalizeLoadedSettings()
        {
            if (MiniHudPanelStyle != MiniHudPanelStyleDark && MiniHudPanelStyle != MiniHudPanelStyleGlass)
            {
                MiniHudPanelStyle = MiniHudPanelStyleDark;
            }

            MiniHudPanelOpacity = MiniHudPanelOpacity <= 0
                ? MiniHudPanelOpacityDefault
                : Math.Clamp(MiniHudPanelOpacity, 30, 100);
            MiniHudPositionX = Math.Clamp(MiniHudPositionX, -MiniHudPositionLimit, MiniHudPositionLimit);
            MiniHudPositionY = Math.Clamp(MiniHudPositionY, -MiniHudPositionLimit, MiniHudPositionLimit);
            if (MiniHudPositionOrientation != MiniHudOrientationHorizontal &&
                MiniHudPositionOrientation != MiniHudOrientationVertical)
            {
                MiniHudPositionOrientation = MiniHudOrientation;
            }

            if ((MiniHudPositionX != 0 || MiniHudPositionY != 0) &&
                MiniHudHorizontalPositionX == 0 &&
                MiniHudHorizontalPositionY == 0 &&
                MiniHudVerticalPositionX == 0 &&
                MiniHudVerticalPositionY == 0)
            {
                if (MiniHudPositionOrientation == MiniHudOrientationHorizontal)
                {
                    MiniHudHorizontalPositionX = MiniHudPositionX;
                    MiniHudHorizontalPositionY = MiniHudPositionY;
                }
                else
                {
                    MiniHudVerticalPositionX = MiniHudPositionX;
                    MiniHudVerticalPositionY = MiniHudPositionY;
                }
            }

            MiniHudHorizontalPositionX = Math.Clamp(MiniHudHorizontalPositionX, -MiniHudPositionLimit, MiniHudPositionLimit);
            MiniHudHorizontalPositionY = Math.Clamp(MiniHudHorizontalPositionY, -MiniHudPositionLimit, MiniHudPositionLimit);
            MiniHudVerticalPositionX = Math.Clamp(MiniHudVerticalPositionX, -MiniHudPositionLimit, MiniHudPositionLimit);
            MiniHudVerticalPositionY = Math.Clamp(MiniHudVerticalPositionY, -MiniHudPositionLimit, MiniHudPositionLimit);

            PanelPositionX = Math.Clamp(PanelPositionX, -PanelPositionLimit, PanelPositionLimit);
            PanelPositionY = Math.Clamp(PanelPositionY, -PanelPositionLimit, PanelPositionLimit);
        }

        private void SetMiniHudRecommendedFavorites()
        {
            MiniHudFavoriteMaskLow = MiniHudRecommendedFavoriteMaskLow;
            MiniHudFavoriteMaskHigh = MiniHudRecommendedFavoriteMaskHigh;
        }

        private void OnMiniHudEnabledChanged(bool value) => GetUISystem()?.UpdateMiniHudEnabledBinding(value);

        private void OnMiniHudModeChanged(int value) => GetUISystem()?.UpdateMiniHudModeBinding(value);

        private void OnMiniHudItemCountChanged(int value) => GetUISystem()?.UpdateMiniHudItemCountBinding(value);

        private void OnMiniHudScaleChanged(int value) => GetUISystem()?.UpdateMiniHudScaleBinding(value);

        private void OnMiniHudOrientationChanged(int value) => GetUISystem()?.UpdateMiniHudOrientationBinding(value);

        private void OnMiniHudPlacementChanged(int value) => GetUISystem()?.UpdateMiniHudPlacementBinding(value);

        private void OnMiniHudHideZeroChanged(bool value) => GetUISystem()?.UpdateMiniHudHideZeroBinding(value);

        private void OnMiniHudPanelStyleChanged(int value) => GetUISystem()?.UpdateMiniHudPanelStyleBinding(value);

        private void OnMiniHudPanelOpacityChanged(int value) => GetUISystem()?.UpdateMiniHudPanelOpacityBinding(value);
    }
}
