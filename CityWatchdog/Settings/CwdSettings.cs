// <copyright file="CwdSettings.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the MIT License. You may not use this file except in compliance with this License.
// See LICENSE file in the project root for full license information.
// This notice and the MIT License notice must be kept with
// all copies or substantial portions of this code.
// ================= </copyright> ======================

// File: src/Settings/CwdSettings.cs
// Purpose: Defines shared City Watchdog settings shell, tabs, common Options UI, and key bindings.

namespace CityWatchdog
{
    using System;

    using CityWatchdog.Systems;

    using Colossal.IO.AssetDatabase;

    using CS2Shared.RiverMochi;

    using Game;
    using Game.Input;
    using Game.Modding;
    using Game.SceneFlow;
    using Game.Settings;
    using Game.UI;
    using Game.UI.Widgets;

    using Unity.Entities;

    using UnityEngine;

    [FileLocation("ModsSettings/CityWatchdog/CityWatchdog")]
    [SettingsUITabOrder(kActions, kMiniHudTab, kMoneyTab, kAbout)]
    [SettingsUIGroupOrder(kAboutUsage, kNotifications, kHotkeyActions, kMoneyViewGroup, kMiniHudGroup, kMilestone, kSaveConversion, kMoney, kAboutInfo, kAboutLinks, kAboutDiagnostics, kSerialize)]
    [SettingsUIShowGroupName(kAboutUsage, kNotifications, kHotkeyActions, kMoneyViewGroup, kMiniHudGroup, kMilestone, kMoney, kSaveConversion, kAboutDiagnostics, kSerialize)]
    public partial class CwdSettings : ModSetting
    {
        internal static CwdSettings Instance { get; set; } = null!;

        // Tab IDs.
        internal const string kActions = "Actions";
        internal const string kMiniHudTab = "MiniHud";
        internal const string kMoneyTab = "Money";
        internal const string kHotkeys = "Hotkeys";
        internal const string kAbout = "About";
        internal const string kDebug = "Debug";
        internal const string kSerialize = "Serialize";

        // Keybinding action IDs.
        public const string AddMoneyAction = nameof(AddMoneyAction);
        public const string SubtractMoneyAction = nameof(SubtractMoneyAction);
        public const string ToggleNotificationsAction = nameof(ToggleNotificationsAction);
        public const string ToggleNotificationPanelAction = nameof(ToggleNotificationPanelAction);
        public const string ToggleRoadNamesAction = nameof(ToggleRoadNamesAction);
        public const string ToggleAllTooltipsAction = nameof(ToggleAllTooltipsAction);
        public const string ToggleDayNightAction = nameof(ToggleDayNightAction);

        // Group IDs.
        internal const string kMoneyViewGroup = "MoneyViewGroup";
        internal const string kMoney = "Money";
        internal const string kNotifications = "Notifications";
        internal const string kMiniHudGroup = "MiniHudGroup";
        internal const string kMilestone = "Milestone";
        internal const string kSaveConversion = "SaveConversion";
        internal const string kHotkeyActions = "HotkeyActions";
        internal const string kAboutInfo = "AboutInfo";
        internal const string kAboutLinks = "AboutLinks";
        internal const string kAboutDiagnostics = "AboutDiagnostics";
        internal const string kAboutUsage = "AboutUsage";

        // Coarse sanity bound (pixels) for the stored draggable panel position. The UI does the
        // real on-screen clamping against the live viewport; this only guards absurd saved values.
        internal const int kPanelPositionLimit = 20000;
        internal const int kMainPanelOpacityDefault = 80;

        private const string kAboutLinksRow = "AboutLinksRow";
        private const string kDebugButtonsRow = "1DebugButtonsRow";
        private const string kUsageIconPath = "coui://ui-mods/images/NotificationIcon_PawRainbow.svg";
        private const string kUrlParadox =
            "https://mods.paradoxplaza.com/authors/River-mochi/cities_skylines_2?games=cities_skylines_2&orderBy=desc&sortBy=best&time=alltime";

        private int m_MainPanelOpacity = kMainPanelOpacityDefault;

        public CwdSettings(IMod mod) : base(mod)
        {
            SetDefaults();
        }

        // --------------------------------------------------------------------
        // Actions tab - Usage
        // --------------------------------------------------------------------

        [SettingsUISection(kActions, kAboutUsage)]
        public bool ShowUsage { get; set; }

        [SettingsUIMultilineText(kUsageIconPath)]
        [SettingsUIHideByCondition(typeof(CwdSettings), nameof(HideUsageText))]
        [SettingsUISection(kActions, kAboutUsage)]
        public string UsageText => string.Empty;

        // --------------------------------------------------------------------
        // Actions tab - Notifications and panel display
        // --------------------------------------------------------------------

        // Uses a short sunset path when darkening and resets HDRP exposure history only when
        // brightening. OFF keeps the game's instant lighting change for A/B testing.
        [SettingsUISection(kActions, kNotifications)]
        public bool SmoothDayNightTransition { get; set; }

        [SettingsUIDropdown(typeof(CwdSettings), nameof(GetDayVisualPresetItems))]
        [SettingsUISection(kActions, kNotifications)]
        [SettingsUISetter(typeof(CwdSettings), nameof(OnDayVisualPresetChanged))]
        public int DayVisualPreset { get; set; }


        // Mirrors vanilla "Interface Scaling (dev)" flag, which normally only appears in the game's
        // Options > Interface when launched with --developerMode. Turning it on makes the whole game
        // UI (+ mod panels) larger. CWD keeps no duplicate setting value.
        [SettingsUISection(kActions, kNotifications)]
        public bool InterfaceScaling
        {
            get => GameManager.instance?.settings?.userInterface?.interfaceScaling ?? false;
            set => World.DefaultGameObjectInjectionWorld?
                .GetExistingSystemManaged<InterfaceScaleControlSystem>()?
                .SetInterfaceScaling(value);
        }

        [SettingsUISlider(min = 30, max = 100, step = 5, scalarMultiplier = 1, unit = Unit.kPercentage)]
        [SettingsUISection(kActions, kNotifications)]
        [SettingsUISetter(typeof(CwdSettings), nameof(OnMainPanelOpacityChanged))]
        public int MainPanelOpacity
        {
            get => m_MainPanelOpacity;
            set => m_MainPanelOpacity = value <= 0
                ? kMainPanelOpacityDefault
                : Math.Clamp(value, 30, 100);
        }

        [SettingsUISection(kActions, kNotifications)]
        [SettingsUISetter(typeof(CwdSettings), nameof(OnPanelButtonsOnlyStartChanged))]
        public bool PanelButtonsOnlyStart { get; set; }

        // --------------------------------------------------------------------
        // Actions tab - Main panel keybinds
        // --------------------------------------------------------------------

        [SettingsUIKeyboardBinding(BindingKeyboard.N, ToggleNotificationPanelAction, shift: true)]
        [SettingsUISection(kActions, kHotkeyActions)]
        public ProxyBinding ToggleNotificationPanelKeyboardBinding { get; set; }

        [SettingsUIKeyboardBinding(BindingKeyboard.N, ToggleNotificationsAction)]
        [SettingsUISection(kActions, kHotkeyActions)]
        public ProxyBinding ToggleNotificationsKeyboardBinding { get; set; }

        [SettingsUIKeyboardBinding(BindingKeyboard.Backslash, ToggleRoadNamesAction)]
        [SettingsUISection(kActions, kHotkeyActions)]
        public ProxyBinding ToggleRoadNamesKeyboardBinding { get; set; }

        [SettingsUIKeyboardBinding(BindingKeyboard.Backslash, ToggleAllTooltipsAction, shift: true)]
        [SettingsUISection(kActions, kHotkeyActions)]
        public ProxyBinding ToggleAllTooltipsKeyboardBinding { get; set; }

        // Day/Night quick toggle (Day <-> Night, like TWA). BindingKeyboard.None ships it UNBOUND so
        // it can't collide with another mod on install — player picks their own key in Options > Actions.
        [SettingsUIKeyboardBinding(BindingKeyboard.None, ToggleDayNightAction)]
        [SettingsUISection(kActions, kHotkeyActions)]
        public ProxyBinding ToggleDayNightKeyboardBinding { get; set; }

        // Persisted across sessions but intentionally hidden from Options UI — controlled only
        // by the Road-Names button on the in-game panel (or the \ hotkey).
        [SettingsUIHidden]
        public bool HideRoadNames { get; set; }

        // Persisted across sessions and controlled by the in-game District Names button.
        [SettingsUIHidden]
        public bool HideDistrictNames { get; set; }

        // Show 1-way road direction arrows while no road tool is active.
        // Hidden from Options UI; toggled from the in-game panel button.
        [SettingsUIHidden]
        public bool ShowRoadArrows { get; set; }

        // Session-only now: the CWD title-bar tooltip toggle starts OFF (tooltips shown) each launch
        // so new mod tooltips are always seen first. Retained only so the binding name stays
        // "DisableCwdTooltips"; the stored value is no longer read to drive behavior.
        [SettingsUIHidden]
        public bool DisableCwdTooltips { get; set; }

        // Last position of the draggable main panel. Hidden from Options UI; written by the panel
        // drag and clamped back on-screen by the UI so a resolution change can't strand it off-view.
        [SettingsUIHidden]
        public int PanelPositionX { get; set; }

        [SettingsUIHidden]
        public int PanelPositionY { get; set; }

        // Which main-panel sections the player collapsed, as a bitmask over the section list
        // (bit set = collapsed). Default 0 = all expanded, so a fresh install shows every row.
        [SettingsUIHidden]
        public int PanelCollapsedSectionsMask { get; set; }

        // Main-panel sort mode the player last used: 0 = A->Z, 1 = Z->A, 2 = Active-first.
        // Default 0 so a fresh install opens grouped A->Z.
        [SettingsUIHidden]
        public int PanelSortMode { get; set; }

        // --------------------------------------------------------------------
        // About tab
        // --------------------------------------------------------------------

        [SettingsUISection(kAbout, kAboutInfo)]
        public string NameText => Mod.ModName;

        [SettingsUISection(kAbout, kAboutInfo)]
        public string VersionText =>
#if DEBUG
            Mod.ModVersion + " (DEBUG)";
#else
            Mod.ModVersion;
#endif

        [SettingsUIButtonGroup(kAboutLinksRow)]
        [SettingsUIButton]
        [SettingsUISection(kAbout, kAboutLinks)]
        public bool OpenParadox
        {
            set
            {
                if (value)
                {
                    TryOpenUrl(kUrlParadox);
                }
            }
        }

        // --------------------------------------------------------------------
        // About tab - Diagnostics
        // --------------------------------------------------------------------

        [SettingsUIButtonGroup(kDebugButtonsRow)]
        [SettingsUIButton]
        [SettingsUISection(kAbout, kAboutDiagnostics)]
        public bool WriteNotificationAuditLog
        {
            set
            {
                if (!value)
                {
                    return;
                }

                AlertIconSystem? alertIconSystem = World.DefaultGameObjectInjectionWorld?
                    .GetExistingSystemManaged<AlertIconSystem>();

                if (alertIconSystem == null)
                {
                    LogUtils.Info(() => "Notification audit skipped: AlertIconSystem is not available.");
                    return;
                }

                LogUtils.Info(() => "Notification audit requested from Options UI.");
                alertIconSystem.WriteNotificationAuditLog();
            }
        }

        [SettingsUIButtonGroup(kDebugButtonsRow)]
        [SettingsUIButton]
        [SettingsUISection(kAbout, kAboutDiagnostics)]
        public bool OpenLog
        {
            set
            {
                if (!value)
                {
                    return;
                }

                ShellOpen.OpenModLogOrLogsFolder();
            }
        }

        // --------------------------------------------------------------------
        // Conditions and helpers
        // --------------------------------------------------------------------

        private static bool IsInGame()
        {
            return GameManager.instance != null && GameManager.instance.gameMode == GameMode.Game;
        }

        public bool NotInGame => !IsInGame();

        public bool InEditor => GameManager.instance != null && GameManager.instance.gameMode == GameMode.Editor;

        public bool InMainMenu => GameManager.instance != null && GameManager.instance.gameMode == GameMode.MainMenu;

        private bool HideUsageText()
        {
            return !ShowUsage;
        }

        private static void TryOpenUrl(string url)
        {
            try
            {
                Application.OpenURL(url);
            }
            catch (Exception ex)
            {
                LogUtils.WarnOnce(
                    "open-url-" + url,
                    () => $"Failed to open URL '{url}': {ex.GetType().Name}: {ex.Message}",
                    ex);
            }
        }

        public override void SetDefaults()
        {
            ApplyMoneyDefaults();

            ShowUsage = false;

            DisableCwdTooltips = false;
            HideRoadNames = false;
            HideDistrictNames = false;
            ShowRoadArrows = false;
            SmoothDayNightTransition = true;
            PanelButtonsOnlyStart = false; 
            DayVisualPreset = kDayVisualPresetVanilla;

            MainPanelOpacity = kMainPanelOpacityDefault;
            PanelPositionX = 0;
            PanelPositionY = 0;
            PanelCollapsedSectionsMask = 0;
            PanelSortMode = 0;

            ApplyMiniHudStarterPresetValues();

            Notification.SetDefaults();
            ResetPresets();
        }

        private static void OnPanelButtonsOnlyStartChanged(bool value) => GetUISystem()?.UpdatePanelButtonsOnlyStartBinding(value);

        private static void OnMainPanelOpacityChanged(int value) => GetUISystem()?.UpdateMainPanelOpacityBinding(value);

        private static CityWatchdogUISystem? GetUISystem()
        {
            return World.DefaultGameObjectInjectionWorld?
                .GetExistingSystemManaged<CityWatchdogUISystem>();
        }

        private static DropdownItem<int> CreateDropdownItem(int value)
        {
            return new DropdownItem<int>
            {
                value = value,
                displayName = value.ToString("N0"),
            };
        }

        public string GetOptionLocaleID(string localeId)
        {
            return $"Options[{id}.{localeId}]";
        }

        public string GetUILocaleID(string entryId)
        {
            return $"{Mod.ModId}.UI[{entryId}]";
        }
    }
}
