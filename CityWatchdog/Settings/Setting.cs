// <copyright file="Setting.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the MIT License. You may not use this file except in compliance with this License.
// See LICENSE file in the project root for full license information.
// This notice and the MIT License notice must be kept with
// all copies or substantial portions of this code.
// ================= </copyright> ======================

// File: src/Settings/Setting.cs
// Purpose: Defines City Watchdog settings, Options UI controls, and key bindings.

namespace CityWatchdog
{
    using System;
    using System.Collections.Generic;
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

        private const string AboutLinksRow = nameof(AboutLinksRow);
        private const string DebugButtonsRow = nameof(DebugButtonsRow);
        private const string UsageIconPath = "coui://ui-mods/images/NotificationIcon_PawOrgCir.svg";
        private const string UrlParadox =
            "https://mods.paradoxplaza.com/authors/River-mochi/cities_skylines_2?games=cities_skylines_2&orderBy=desc&sortBy=best&time=alltime";

        private static readonly string[] Milestones =
        {
            "TinyVillage",
            "SmallVillage",
            "LargeVillage",
            "GrandVillage",
            "TinyTown",
            "BoomTown",
            "BusyTown",
            "BigTown",
            "GreatTown",
            "SmallCity",
            "BigCity",
            "LargeCity",
            "HugeCity",
            "GrandCity",
            "Metropolis",
            "ThrivingMetropolis",
            "FlourishingMetropolis",
            "ExpansiveMetropolis",
            "MassiveMetropolis",
            "Megalopolis",
        };

        internal const int MoneyViewModeHourly = 0;
        internal const int MoneyViewModeMonthly = 1;
        internal const int MoneyTooltipModeFullData = 0;
        internal const int MoneyTooltipModeCompact = 1;
        internal const int MoneyTooltipModeMini = 2;
        internal const int MilestoneTinyVillage = 0;
        internal const int MiniHudModeTopActive = 0;
        internal const int MiniHudModeFavorites = 1;
        internal const int MiniHudOrientationHorizontal = 0;
        internal const int MiniHudOrientationVertical = 1;
        internal const int MiniHudPlacementTopCenter = 0;
        internal const int MiniHudPlacementTopRight = 1;
        internal const int MiniHudPlacementDraggable = 2;
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
            (1 << 20) | // Abandoned
            (1 << 23) | // High rent
            (1 << 24) | // Traffic jam
            (1 << 26);  // Road required / no road access
        private const int MiniHudRecommendedFavoriteMaskHigh =
            (1 << 0) |  // No pedestrian access
            (1 << 4) |  // Lack of labor
            (1 << 8) |  // Water damage
            (1 << 11) | // On fire
            (1 << 12) | // Burned down
            (1 << 13) | // Garbage piling up
            (1 << 18) | // Traffic accident
            (1 << 19) | // Crime scene
            (1 << 28) | // Pathfinding failed
            (1 << 30);  // No vehicles

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
        // Actions tab - Money View
        // --------------------------------------------------------------------

        [SettingsUISection(Actions, MoneyViewGroup)]
        [SettingsUISetter(typeof(Setting), nameof(OnMoneyViewChanged))]
        public bool MoneyView { get; set; }

        [SettingsUIDropdown(typeof(Setting), nameof(GetMoneyViewModeItems))]
        [SettingsUISection(Actions, MoneyViewGroup)]
        [SettingsUIDisableByCondition(typeof(Setting), nameof(EnsureMoneyViewEnabled))]
        [SettingsUISetter(typeof(Setting), nameof(OnMoneyViewModeChanged))]
        public int MoneyViewMode { get; set; }

        [SettingsUIDropdown(typeof(Setting), nameof(GetMoneyTooltipModeItems))]
        [SettingsUISection(Actions, MoneyViewGroup)]
        [SettingsUIDisableByCondition(typeof(Setting), nameof(EnsureMoneyViewEnabled))]
        [SettingsUISetter(typeof(Setting), nameof(OnMoneyTooltipModeChanged))]
        public int MoneyTooltipMode { get; set; }

        // UI converts 90..130 directly into 0.90em..1.30em for tooltip value text.
        [SettingsUISlider(min = 90, max = 130, step = 5, scalarMultiplier = 1, unit = Unit.kPercentage)]
        [SettingsUISection(Actions, MoneyViewGroup)]
        [SettingsUIDisableByCondition(typeof(Setting), nameof(EnsureMoneyViewEnabled))]
        [SettingsUISetter(typeof(Setting), nameof(OnMoneyTooltipFontScaleChanged))]
        public int MoneyTooltipFontScale { get; set; }

        [SettingsUISlider(min = 90, max = 130, step = 5, scalarMultiplier = 1, unit = Unit.kPercentage)]
        [SettingsUISection(Actions, MoneyViewGroup)]
        [SettingsUIDisableByCondition(typeof(Setting), nameof(EnsureMoneyViewEnabled))]
        [SettingsUISetter(typeof(Setting), nameof(OnPopulationTooltipFontScaleChanged))]
        public int PopulationTooltipFontScale { get; set; }

        // --------------------------------------------------------------------
        // Money-Milestones tab - Money
        // --------------------------------------------------------------------

        [SettingsUISlider(min = 20000, max = 2000000, step = 20000, scalarMultiplier = 1, unit = Unit.kInteger)]
        [SettingsUISection(MoneyTab, Money)]
        public int ManualMoneyAmount { get; set; }

        [SettingsUIKeyboardBinding(BindingKeyboard.LeftBracket, AddMoneyAction)]
        [SettingsUISection(MoneyTab, Money)]
        public ProxyBinding AddMoneyKeyboardBinding { get; set; }

        [SettingsUIKeyboardBinding(BindingKeyboard.RightBracket, SubtractMoneyAction)]
        [SettingsUISection(MoneyTab, Money)]
        public ProxyBinding SubtractMoneyKeyboardBinding { get; set; }

        [SettingsUISection(MoneyTab, Money)]
        public bool AutomaticAddMoney { get; set; }

        [SettingsUIDropdown(typeof(Setting), nameof(GetAutomaticAddMoneyThresholdItems))]
        [SettingsUISection(MoneyTab, Money)]
        [SettingsUIDisableByCondition(typeof(Setting), nameof(EnsureAutomaticAddMoneyEnabled))]
        public int AutomaticAddMoneyThreshold { get; set; }

        [SettingsUIDropdown(typeof(Setting), nameof(GetAutomaticAddMoneyAmountItems))]
        [SettingsUISection(MoneyTab, Money)]
        [SettingsUIDisableByCondition(typeof(Setting), nameof(EnsureAutomaticAddMoneyEnabled))]
        public int AutomaticAddMoneyAmount { get; set; }


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

        // Persisted across sessions but intentionally hidden from Options UI — controlled only
        // by the CWD title-bar icon on the in-game panel. Without [SettingsUIHidden] the
        // property still registers and falls into an unnamed default tab.
        [SettingsUIHidden]
        public bool DisableCwdTooltips { get; set; }

        // --------------------------------------------------------------------
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

                MiniHudEnabled = true;
                MiniHudMode = MiniHudModeFavorites;     // use blue-star recommended favorites
                MiniHudItemCount = 5;
                MiniHudScale = 100;
                MiniHudOrientation = MiniHudOrientationHorizontal;
                MiniHudPlacement = MiniHudPlacementTopCenter;
                MiniHudHideZero = false;
                MiniHudGlassStyle = false;
                SetMiniHudRecommendedFavorites();

                CityWatchdogUISystem? uiSystem = GetUISystem();
                uiSystem?.UpdateMiniHudEnabledBinding(MiniHudEnabled);
                uiSystem?.UpdateMiniHudModeBinding(MiniHudMode);
                uiSystem?.UpdateMiniHudItemCountBinding(MiniHudItemCount);
                uiSystem?.UpdateMiniHudScaleBinding(MiniHudScale);
                uiSystem?.UpdateMiniHudOrientationBinding(MiniHudOrientation);
                uiSystem?.UpdateMiniHudPlacementBinding(MiniHudPlacement);
                uiSystem?.UpdateMiniHudHideZeroBinding(MiniHudHideZero);
                uiSystem?.UpdateMiniHudGlassStyleBinding(MiniHudGlassStyle);
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

        [SettingsUISection(MiniHudTab, MiniHudGroup)]
        [SettingsUIDisableByCondition(typeof(Setting), nameof(EnsureMiniHudEnabled))]
        [SettingsUISetter(typeof(Setting), nameof(OnMiniHudGlassStyleChanged))]
        public bool MiniHudGlassStyle { get; set; }

        // Two 31-bit masks persist the 62 row favorites without exposing 62 Options toggles.
        [SettingsUIHidden]
        public int MiniHudFavoriteMaskLow { get; set; }

        [SettingsUIHidden]
        public int MiniHudFavoriteMaskHigh { get; set; }

        // --------------------------------------------------------------------
        // Money-Milestones tab - New city start settings
        // --------------------------------------------------------------------

        [SettingsUIDropdown(typeof(Setting), nameof(GetInitialMoneyItems))]
        [SettingsUISection(MoneyTab, Milestone)]
        [SettingsUIDisableByCondition(typeof(Setting), nameof(IsInGame))]
        public int InitialMoney { get; set; }

        // Safety rule:
        // - OFF while a city is loaded stays disabled, so milestone injection cannot be enabled mid-city.
        // - ON while a city is loaded stays enabled, so it can be turned OFF without rebooting.
        [SettingsUISection(MoneyTab, Milestone)]
        [SettingsUIDisableByCondition(typeof(Setting), nameof(CannotEnableCustomMilestoneInGame))]
        public bool CustomMilestone { get; set; }

        [SettingsUIDropdown(typeof(Setting), nameof(GetMilestoneLevelItems))]
        [SettingsUISection(MoneyTab, Milestone)]
        [SettingsUIDisableByCondition(typeof(Setting), nameof(GetMilestoneLevelStatus))]
        public int MilestoneLevel { get; set; }

        // --------------------------------------------------------------------
        // Money-Milestones tab - Unlimited Money Converter
        // --------------------------------------------------------------------

        [SettingsUISection(MoneyTab, SaveConversion)]
        public bool ConfirmUnlimitedMoneySaveConversion { get; set; }

        [SettingsUIButton]
        [SettingsUIConfirmation]
        [SettingsUISection(MoneyTab, SaveConversion)]
        [SettingsUIDisableByCondition(typeof(Setting), nameof(CannotConvertUnlimitedMoneySave))]
        public bool ConvertUnlimitedMoneySave
        {
            set
            {
                if (!value)
                {
                    return;
                }

                CityFinanceSystem? cityFinanceSystem = GetCityFinanceSystem();
                if (cityFinanceSystem?.CanConvertUnlimitedMoneySave() == true)
                {
                    cityFinanceSystem.SetUnlimitedMoneyToLimitedMoney();
                }
            }
        }

        // --------------------------------------------------------------------
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

        private bool CannotEnableCustomMilestoneInGame()
        {
            return IsInGame() && !CustomMilestone;
        }

        public bool NotInGame => !IsInGame();

        public bool InEditor => GameManager.instance != null && GameManager.instance.gameMode == GameMode.Editor;

        public bool InMainMenu => GameManager.instance != null && GameManager.instance.gameMode == GameMode.MainMenu;

        public bool EnsureAutomaticAddMoneyEnabled()
        {
            return !AutomaticAddMoney;
        }

        public bool EnsureMoneyViewEnabled()
        {
            return !MoneyView;
        }

        public bool EnsureMiniHudEnabled()
        {
            return !MiniHudEnabled;
        }

        private bool HideUsageText()
        {
            return !ShowUsage;
        }

        private bool CannotConvertUnlimitedMoneySave()
        {
            return !ConfirmUnlimitedMoneySaveConversion ||
                   GetCityFinanceSystem()?.CanConvertUnlimitedMoneySave() != true;
        }

        private static CityFinanceSystem? GetCityFinanceSystem()
        {
            return World.DefaultGameObjectInjectionWorld?
                .GetExistingSystemManaged<CityFinanceSystem>();
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

        // --------------------------------------------------------------------
        // Dropdown data
        // --------------------------------------------------------------------

        public DropdownItem<int>[] GetAutomaticAddMoneyThresholdItems()
        {
            return new[]
            {
                CreateDropdownItem(10000),
                CreateDropdownItem(100000),
                CreateDropdownItem(1000000),
                CreateDropdownItem(10000000),
            };
        }

        public DropdownItem<int>[] GetAutomaticAddMoneyAmountItems()
        {
            return new[]
            {
                CreateDropdownItem(10000),
                CreateDropdownItem(100000),
                CreateDropdownItem(1000000),
                CreateDropdownItem(10000000),
                CreateDropdownItem(100000000),
            };
        }

        public DropdownItem<int>[] GetInitialMoneyItems()
        {
            return new[]
            {
                new DropdownItem<int>
                {
                    value = 0,
                    displayName = GetOptionLocaleID("GameDefault"),
                },
                CreateDropdownItem(100000),
                CreateDropdownItem(500000),
                CreateDropdownItem(5000000),
                CreateDropdownItem(10000000),
                CreateDropdownItem(100000000),
            };
        }

        public DropdownItem<int>[] GetMoneyViewModeItems()
        {
            return new[]
            {
                new DropdownItem<int>
                {
                    value = MoneyViewModeHourly,
                    displayName = GetOptionLocaleID("MoneyViewModeHourly"),
                },
                new DropdownItem<int>
                {
                    value = MoneyViewModeMonthly,
                    displayName = GetOptionLocaleID("MoneyViewModeMonthly"),
                },
            };
        }

        public DropdownItem<int>[] GetMoneyTooltipModeItems()
        {
            return new[]
            {
                new DropdownItem<int>
                {
                    value = MoneyTooltipModeMini,
                    displayName = GetOptionLocaleID("MoneyTooltipModeMini"),
                },
                new DropdownItem<int>
                {
                    value = MoneyTooltipModeCompact,
                    displayName = GetOptionLocaleID("MoneyTooltipModeCompact"),
                },
                new DropdownItem<int>
                {
                    value = MoneyTooltipModeFullData,
                    displayName = GetOptionLocaleID("MoneyTooltipModeFullData"),
                },
            };
        }

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

        public void ResetInitialMoney()
        {
            InitialMoney = 0;
        }

        public override void SetDefaults()
        {
            MoneyView = true;
            MoneyViewMode = MoneyViewModeHourly;
            MoneyTooltipMode = MoneyTooltipModeCompact;
            // If defaults change, also update bindValue fallbacks in UI/src/bindings/bindings.tsx.
            MoneyTooltipFontScale = 120;
            PopulationTooltipFontScale = 120;

            ManualMoneyAmount = 40000;
            AutomaticAddMoney = false;
            AutomaticAddMoneyThreshold = 100000;
            AutomaticAddMoneyAmount = 10000;
            InitialMoney = 0;

            CustomMilestone = false;
            MilestoneLevel = MilestoneTinyVillage;

            ConfirmUnlimitedMoneySaveConversion = false;
            ShowUsage = false;

            DisableCwdTooltips = false;
            HideRoadNames = false;
            HideDistrictNames = false;
            ShowRoadArrows = false;
            PanelButtonsOnlyStart = false;

            MiniHudEnabled = true;
            MiniHudMode = MiniHudModeFavorites; // use blue-star recommended
            MiniHudItemCount = 5;
            MiniHudScale = 100;
            MiniHudOrientation = MiniHudOrientationVertical;
            MiniHudPlacement = MiniHudPlacementDraggable;
            MiniHudHideZero = true;
            MiniHudGlassStyle = false;
            SetMiniHudRecommendedFavorites();

            Notification.SetDefaults();
        }

        private void SetMiniHudRecommendedFavorites()
        {
            MiniHudFavoriteMaskLow = MiniHudRecommendedFavoriteMaskLow;
            MiniHudFavoriteMaskHigh = MiniHudRecommendedFavoriteMaskHigh;
        }

        private void OnMoneyViewChanged(bool value)
        {
            World.DefaultGameObjectInjectionWorld?
                .GetExistingSystemManaged<CityWatchdogUISystem>()?
                .UpdateMoneyViewBinding(value);
        }

        private void OnMoneyViewModeChanged(int value)
        {
            World.DefaultGameObjectInjectionWorld?
                .GetExistingSystemManaged<CityWatchdogUISystem>()?
                .UpdateMoneyViewModeBinding(value);
        }

        private void OnMoneyTooltipModeChanged(int value)
        {
            World.DefaultGameObjectInjectionWorld?
                .GetExistingSystemManaged<CityWatchdogUISystem>()?
                .UpdateMoneyTooltipModeBinding(value);
        }

        private void OnMoneyTooltipFontScaleChanged(int value)
        {
            World.DefaultGameObjectInjectionWorld?
                .GetExistingSystemManaged<CityWatchdogUISystem>()?
                .UpdateMoneyTooltipFontScaleBinding(value);
        }

        private void OnPopulationTooltipFontScaleChanged(int value)
        {
            World.DefaultGameObjectInjectionWorld?
                .GetExistingSystemManaged<CityWatchdogUISystem>()?
                .UpdatePopulationTooltipFontScaleBinding(value);
        }

        private void OnMiniHudEnabledChanged(bool value) => GetUISystem()?.UpdateMiniHudEnabledBinding(value);

        private void OnMiniHudModeChanged(int value) => GetUISystem()?.UpdateMiniHudModeBinding(value);

        private void OnMiniHudItemCountChanged(int value) => GetUISystem()?.UpdateMiniHudItemCountBinding(value);

        private void OnMiniHudScaleChanged(int value) => GetUISystem()?.UpdateMiniHudScaleBinding(value);

        private void OnMiniHudOrientationChanged(int value) => GetUISystem()?.UpdateMiniHudOrientationBinding(value);

        private void OnMiniHudPlacementChanged(int value) => GetUISystem()?.UpdateMiniHudPlacementBinding(value);

        private void OnMiniHudHideZeroChanged(bool value) => GetUISystem()?.UpdateMiniHudHideZeroBinding(value);

        private void OnMiniHudGlassStyleChanged(bool value) => GetUISystem()?.UpdateMiniHudGlassStyleBinding(value);

        private void OnPanelButtonsOnlyStartChanged(bool value) => GetUISystem()?.UpdatePanelButtonsOnlyStartBinding(value);

        private static CityWatchdogUISystem? GetUISystem()
        {
            return World.DefaultGameObjectInjectionWorld?
                .GetExistingSystemManaged<CityWatchdogUISystem>();
        }

        private bool GetMilestoneLevelStatus()
        {
            return IsInGame() || !CustomMilestone;
        }

        private DropdownItem<int>[] GetMilestoneLevelItems()
        {
            List<DropdownItem<int>> items = new List<DropdownItem<int>>();
            for (int i = 0; i < Milestones.Length; i++)
            {
                items.Add(new DropdownItem<int>
                {
                    value = i,
                    displayName = MilestoneDisplay.Get(i, Milestones[i]),
                });
            }

            return items.ToArray();
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
