// <copyright file="Setting.Money.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the MIT License. You may not use this file except in compliance with this License.
// See LICENSE file in the project root for full license information.
// This notice and the MIT License notice must be kept with
// all copies or substantial portions of this code.
// ================= </copyright> ======================

// File: src/Settings/Setting.Money.cs
// Purpose: Defines City Watchdog money, milestone, and money-view Options settings.

namespace CityWatchdog
{
    using System.Collections.Generic;
    using CityWatchdog.Systems;
    using Game.Input;
    using Game.Settings;
    using Game.UI;
    using Game.UI.Widgets;
    using Unity.Entities;

    public partial class Setting
    {
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
        // Money conditions and helpers
        // --------------------------------------------------------------------

        private bool CannotEnableCustomMilestoneInGame()
        {
            return IsInGame() && !CustomMilestone;
        }

        public bool EnsureAutomaticAddMoneyEnabled()
        {
            return !AutomaticAddMoney;
        }

        public bool EnsureMoneyViewEnabled()
        {
            return !MoneyView;
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


        // --------------------------------------------------------------------
        // Money dropdown data
        // --------------------------------------------------------------------

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



        public void ResetInitialMoney()
        {
            InitialMoney = 0;
        }


        private void ApplyMoneyDefaults()
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
    }
}
