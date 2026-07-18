// <copyright file="Setting.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the MIT License. You may not use this file except in compliance with this License.
// See LICENSE file in the project root for full license information.
// This notice and the MIT License notice must be kept with
// all copies or substantial portions of this code.
// ================= </copyright> ======================

// File: src/Settings/Setting.cs
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
    [SettingsUITabOrder(Actions, MiniHudTab, MoneyTab, About)]
    [SettingsUIGroupOrder(AboutUsage, Notifications, MoneyViewGroup, MiniHudGroup, Milestone, Money, SaveConversion, AboutInfo, AboutLinks, AboutDiagnostics, Serialize)]
    [SettingsUIShowGroupName(AboutUsage, Notifications, MoneyViewGroup, MiniHudGroup, Milestone, Money, SaveConversion, AboutDiagnostics, Serialize)]
    public partial class Setting : ModSetting
    {
        internal static Setting Instance { get; set; } = null!;

        // Tab IDs.
        internal const string Actions = nameof(Actions);
        internal const string MiniHudTab = "MiniHud";
        internal const string MoneyTab = "Money";
        internal const string Hotkeys = nameof(Hotkeys);
        internal const string About = nameof(About);
        internal const string Debug = nameof(Debug);
        internal const string Serialize = nameof(Serialize);

        // Keybinding action IDs.
        public const string AddMoneyAction = nameof(AddMoneyAction);
        public const string SubtractMoneyAction = nameof(SubtractMoneyAction);
        public const string ToggleNotificationsAction = nameof(ToggleNotificationsAction);
        public const string ToggleNotificationPanelAction = nameof(ToggleNotificationPanelAction);
        public const string ToggleRoadNamesAction = nameof(ToggleRoadNamesAction);
        public const string ToggleAllTooltipsAction = nameof(ToggleAllTooltipsAction);

        // Group IDs.
        internal const string MoneyViewGroup = nameof(MoneyViewGroup);
        internal const string Money = nameof(Money);
        internal const string Notifications = nameof(Notifications);
        internal const string MiniHudGroup = nameof(MiniHudGroup);
        internal const string Milestone = nameof(Milestone);
        internal const string SaveConversion = nameof(SaveConversion);
        internal const string HotkeyActions = nameof(HotkeyActions);
        internal const string AboutInfo = nameof(AboutInfo);
        internal const string AboutLinks = nameof(AboutLinks);
        internal const string AboutDiagnostics = nameof(AboutDiagnostics);
        internal const string AboutUsage = nameof(AboutUsage);

        // Coarse sanity bound (pixels) for the stored draggable panel position. The UI does the
        // real on-screen clamping against the live viewport; this only guards absurd saved values.
        internal const int PanelPositionLimit = 20000;
        internal const int MainPanelOpacityDefault = 70;

        private const string AboutLinksRow = nameof(AboutLinksRow);
        private const string DebugButtonsRow = nameof(DebugButtonsRow);
        private const string UsageIconPath = "coui://ui-mods/images/NotificationIcon_PawRainbow.svg";
        private const string UrlParadox =
            "https://mods.paradoxplaza.com/authors/River-mochi/cities_skylines_2?games=cities_skylines_2&orderBy=desc&sortBy=best&time=alltime";

        private int m_MainPanelOpacity = MainPanelOpacityDefault;

        public Setting(IMod mod) : base(mod)
        {
            SetDefaults();
        }

        // --------------------------------------------------------------------
        // Actions tab - Usage
        // --------------------------------------------------------------------

        [SettingsUISection(Actions, AboutUsage)]
        public bool ShowUsage { get; set; }

        [SettingsUIMultilineText(UsageIconPath)]
        [SettingsUIHideByCondition(typeof(Setting), nameof(HideUsageText))]
        [SettingsUISection(Actions, AboutUsage)]
        public string UsageText => string.Empty;

        // --------------------------------------------------------------------
        // Actions tab - Notifications
        // --------------------------------------------------------------------

        [SettingsUIKeyboardBinding(BindingKeyboard.N, ToggleNotificationsAction)]
        [SettingsUISection(Actions, Notifications)]
        public ProxyBinding ToggleNotificationsKeyboardBinding { get; set; }

        [SettingsUIKeyboardBinding(BindingKeyboard.N, ToggleNotificationPanelAction, shift: true)]
        [SettingsUISection(Actions, Notifications)]
        public ProxyBinding ToggleNotificationPanelKeyboardBinding { get; set; }

        [SettingsUISection(Actions, Notifications)]
        [SettingsUISetter(typeof(Setting), nameof(OnPanelButtonsOnlyStartChanged))]
        public bool PanelButtonsOnlyStart { get; set; }

        [SettingsUIKeyboardBinding(BindingKeyboard.Backslash, ToggleRoadNamesAction)]
        [SettingsUISection(Actions, Notifications)]
        public ProxyBinding ToggleRoadNamesKeyboardBinding { get; set; }

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

        [SettingsUIKeyboardBinding(BindingKeyboard.Backslash, ToggleAllTooltipsAction, shift: true)]
        [SettingsUISection(Actions, Notifications)]
        public ProxyBinding ToggleAllTooltipsKeyboardBinding { get; set; }

        [SettingsUISlider(min = 30, max = 100, step = 5, scalarMultiplier = 1, unit = Unit.kPercentage)]
        [SettingsUISection(Actions, Notifications)]
        [SettingsUISetter(typeof(Setting), nameof(OnMainPanelOpacityChanged))]
        public int MainPanelOpacity
        {
            get => m_MainPanelOpacity;
            set => m_MainPanelOpacity = value <= 0
                ? MainPanelOpacityDefault
                : Math.Clamp(value, 30, 100);
        }

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

        // About tab
        // --------------------------------------------------------------------

        [SettingsUISection(About, AboutInfo)]
        public string NameText => Mod.ModName;

        [SettingsUISection(About, AboutInfo)]
        public string VersionText =>
#if DEBUG
            Mod.ModVersion + " (DEBUG)";
#else
            Mod.ModVersion;
#endif

        [SettingsUIButtonGroup(AboutLinksRow)]
        [SettingsUIButton]
        [SettingsUISection(About, AboutLinks)]
        public bool OpenParadox
        {
            set
            {
                if (value)
                {
                    TryOpenUrl(UrlParadox);
                }
            }
        }


        // --------------------------------------------------------------------
        // About tab - Diagnostics
        // --------------------------------------------------------------------

        [SettingsUIButtonGroup(DebugButtonsRow)]
        [SettingsUIButton]
        [SettingsUISection(About, AboutDiagnostics)]
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

        [SettingsUIButtonGroup(DebugButtonsRow)]
        [SettingsUIButton]
        [SettingsUISection(About, AboutDiagnostics)]
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

        private bool IsInGame()
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
            PanelButtonsOnlyStart = false;
            MainPanelOpacity = MainPanelOpacityDefault;
            PanelPositionX = 0;
            PanelPositionY = 0;
            PanelCollapsedSectionsMask = 0;
            PanelSortMode = 0;

            ApplyMiniHudStarterPresetValues();

            Notification.SetDefaults();
        }

        private void OnPanelButtonsOnlyStartChanged(bool value) => GetUISystem()?.UpdatePanelButtonsOnlyStartBinding(value);

        private void OnMainPanelOpacityChanged(int value) => GetUISystem()?.UpdateMainPanelOpacityBinding(value);

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
