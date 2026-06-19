// <copyright file="LocaleEN.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the MIT License. You may not use this file except in compliance with this License.
// See LICENSE file in the project root for full license information.
// This notice and the MIT License notice must be kept with
// all copies or substantial portions of this code.
// ================= </copyright> ======================

// File: src/Localization/LocaleEN.cs
// Purpose: English (en-US) for City Watchdog Options UI menu.

namespace CityWatchdog
{
    using System.Collections.Generic; // Dictionary and KeyValuePair
    using Colossal;                   // IDictionarySource
    using Game.UI.Editor;

    public sealed class LocaleEN : IDictionarySource
    {
        private readonly Setting m_Settings;

        public LocaleEN(Setting setting)
        {
            m_Settings = setting;
        }

        public IEnumerable<KeyValuePair<string, string>> ReadEntries(
            IList<IDictionaryEntryError> errors,
            Dictionary<string, int> indexCounts)
        {
            string title = Mod.ModName;
            if (!string.IsNullOrEmpty(Mod.ModVersion))
            {
                title += " (" + Mod.ModVersion + ")";
            }

            Dictionary<string, string> entries = new Dictionary<string, string>
            {
                // --- Mod title ---
                { m_Settings.GetSettingsLocaleID(), title },

                // --- Tabs ---
                { m_Settings.GetOptionTabLocaleID(Setting.Actions), "Actions" },
                { m_Settings.GetOptionTabLocaleID(Setting.Hotkeys), "Hotkeys" },
                { m_Settings.GetOptionTabLocaleID(Setting.About), "About" },
                { m_Settings.GetOptionTabLocaleID(Setting.Debug), "Debug" },

                // --- Groups ---
                { m_Settings.GetOptionGroupLocaleID(Setting.MoneyViewGroup), "Info Viewer" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Money), "Money" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Notifications), "Notifications" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Milestone), "Milestone" },
                { m_Settings.GetOptionGroupLocaleID(Setting.SaveConversion), "Save Conversion" },
                { m_Settings.GetOptionGroupLocaleID(Setting.HotkeyActions), "Hotkeys" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutInfo), "" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutLinks), "" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutDiagnostics), "DIAGNOSTICS" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutUsage), "USAGE" },

                // --- Money View ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyView)), "Show details on hover" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyView)),
                    "Shows numeric trend values beside the vanilla bottom-toolbar <money and population arrows>.\n" +
                    "This is a lightweight toolbar hover <display only>;\n" +
                    "it does not change city money or population." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyViewMode)), "Money View Frequency" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyViewMode)),
                    "Choose whether the bottom-toolbar trend text shows hourly or monthly values for money and population.\n" +
                    "Monthly uses budget income minus expenses for money, and a 24-hour projection for population." },
                { m_Settings.GetOptionLocaleID("MoneyViewModeHourly"), "Hourly (/h)" },
                { m_Settings.GetOptionLocaleID("MoneyViewModeMonthly"), "Monthly (/mo)" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyTooltipMode)), "Money Tooltip Style" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyTooltipMode)),
                    "Choose how much detail appears in the money hover tooltip.\n" +
                    "Compact = default on first install.\n"+
                    "<Mini> shows only 2 Net values for /mo and /h.\n" +
                    "<Compact> shortens large values (15.21M instead of 15,212,318).\n" +
                    "<Full data> shows long values and Total fields." },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeMini"), "Mini" },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeCompact"), "Compact" },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeFullData"), "Full data" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyTooltipFontScale)), "Money font size" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyTooltipFontScale)),
                    "Adjusts <font size> of Money View tooltip numbers.\n" +
                    "Game default = 100%\n" +
                    "<Mod default = 120%>\n" +
                    "Hover over Money at bottom of the screen.\n"+
                    "Requested by players who have hard time seeing smaller tooltips in the game."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.PopulationTooltipFontScale)), "Population font size" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.PopulationTooltipFontScale)),
                    "Adjusts <font size> of population tooltip numbers.\n" +
                    "Game default = 100%\n" +
                    "<Mod default = 120%>\n" +
                    "Hover over Population at bottom of the screen."   
                },

                // --- Money helpers ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ManualMoneyAmount)), "Money Hotkey Amount" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ManualMoneyAmount)),
                    "Use this amount with the Add Money and Subtract Money hotkeys.\n" +
                    "<Mod default = 40,000>\n" +
                    "This does nothing unless you use the hotkey to add/subtract money (in the city).\n"+
                    "For automated money, enable the Automatic Add Money option."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AddMoneyKeyboardBinding)), "Add Money" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AddMoneyKeyboardBinding)),
                    "Hotkey to <Add Money> inside the city." },
                { m_Settings.GetBindingKeyLocaleID(Setting.AddMoneyAction), "Add Money" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.SubtractMoneyKeyboardBinding)), "Subtract Money" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.SubtractMoneyKeyboardBinding)),
                    "Hotkey to <Subtract Money> inside the city." },
                { m_Settings.GetBindingKeyLocaleID(Setting.SubtractMoneyAction), "Subtract Money" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoney)), "Automatic Add Money" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoney)),
                    "When enabled [ ✓ ], City Watchdog checks the city balance while a city is loaded.\n" +
                    "- If the balance is <below the threshold>, \n" +
                    "  it adds the selected automatic amount.\n" +
                    "- Recommend to use Manual money with hotkey (<[> or <]>) as needed" +
                    "  instead of this automated option, but this is here if you want it."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoneyThreshold)), "Automatic Money Threshold" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoneyThreshold)),
                    "If Automatic Add Money is enabled and the city balance falls below this value,\n" +
                    "Add the selected automatic amount." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoneyAmount)), "Automatic Money Amount" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoneyAmount)),
                    "Amount added each time Automatic Add Money triggers.\n" +
                    "Choose a value high enough to bring the city safely above the threshold." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.InitialMoney)), "Initial Money" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.InitialMoney)),
                    "Sets the starting balance for a new <limited money> city or the first loaded city,\n" +
                    "then resets to Game Default after it applies.\n" +
                    "This is grayed out if a city is already loaded.\n" +
                    "Set before starting/loading a city → applies once → then use <Money Hotkey Amount> or <Automatic Add Money> afterward." },

                { m_Settings.GetOptionLocaleID("GameDefault"), "Game Default" },

                // --- Notifications ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleNotificationsKeyboardBinding)), "Toggle Notification Icons" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleNotificationsKeyboardBinding)),
                    "<Hotkey> for the same action as the in-game <[TOGGLE ALL]> icon button.\n" +
                    "It shows or hides all listed city notification icons instantly." },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleNotificationsAction), "Instant Show/Hide all notification icons" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleNotificationPanelKeyboardBinding)), "Open/Close Notification Panel" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleNotificationPanelKeyboardBinding)),
                    "<Hotkey> for opening or closing the\n" +
                    "<notification panel> in the city.\n" +
                    "Works the same as clicking Top Left icon to open the full panel."
                },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleNotificationPanelAction), "Open/Close notification panel" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleRoadNamesKeyboardBinding)), "Hide/Show Road Names" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleRoadNamesKeyboardBinding)),
                    "<Hotkey> to instantly hide or show the vanilla road name labels in the city.\n" +
                    "Same as clicking the Road-Name icon in the City Watchdog panel toolbar." },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleRoadNamesAction), "Hide/Show road names" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.DisableAllTooltips)), "Disable All Mouse over Tooltips" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.DisableAllTooltips)),
                    "Turns off the game's hover tooltips — both the ones that follow your cursor over buildings/citizens/tools\n" +
                    " and the small popups on game UI buttons (top bar names, vanilla buttons, etc.).\n" +
                    "<City Watchdog's own money/population popups stay on>; those are controlled by the Money View option above.\n" +
                    "Same as clicking the [i] icon on the City Watchdog panel inside the city." },

                // --- Milestone selector ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.CustomMilestone)), "Milestone Selector" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.CustomMilestone)),
                    "Enable before loading or starting a city to unlock a chosen milestone immediately after the city loads.\n" +
                    "This cannot be turned ON while a city is loaded, but it can be turned OFF if it was left enabled by mistake.\n" +
                    "City Watchdog cannot undo milestone changes already saved into a city; use an earlier save if needed." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MilestoneLevel)), "Milestone" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MilestoneLevel)),
                    "Pick the milestone level to unlock on the next city load.\n" +
                    "This is only adjustable outside a loaded city, and only after [Milestone Selector] is enabled [ ✓ ]." },

                // --- Save conversion ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ConfirmUnlimitedMoneySaveConversion)), "Unlimited Money Converter" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ConfirmUnlimitedMoneySaveConversion)),
                    "<Make a Backup of city FIRST>.\n" +
                    "Converts a city that started as Unlimited Money to a normal city with regular money challenges.\n" +
                    "Enabling this unlocks the <[Convert Unlimited Money Save]> button when the loaded city is <Unlimited Money> type.\n" +
                    "City Watchdog cannot undo this conversion.\n" +
                    "If you have normal cities, do not worry about this; it is not needed." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)), "Convert Unlimited Money Save City to Normal" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)),
                    "For cities started with <Unlimited Money>.\n" +
                    "While that city is loaded, this converts the save to normal limited-money budgeting so the city has regular money challenges again.\n" +
                    "Button is <disabled/greyed-out> unless the loaded city is an <Unlimited Money> type\n" +
                    "and <Unlimited Money Converter> is ON [ ✓ ].\n" +
                    "Make a backup save, and use at your own risk; City Watchdog cannot undo this conversion." },

                { m_Settings.GetOptionWarningLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)),
                    "Convert this city from Unlimited Money to normal limited money?\n" +
                    "Save a backup FIRST; City Watchdog cannot undo this.\n" +
                    "Are you sure?" },

                // --- About tab ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.NameText)), "Mod name" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.NameText)), "Display name of this mod." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.VersionText)), "Version" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.VersionText)), "Current mod version." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.OpenParadox)), "Paradox Mods" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.OpenParadox)), "Open the author's Paradox Mods page." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.WriteNotificationAuditLog)), "Debug Report to Log" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.WriteNotificationAuditLog)),
                    "<Not needed for normal gameplay.>\n" +
                    "For testers and post game-patch checks: writes a <Logs/CityWatchdog.log> report\n" +
                    "comparing live game notification prefabs with the notification icons Watchdog currently controls." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.OpenLog)), "Open Log" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.OpenLog)),
                    "Opens </Logs/CityWatchdog.log> if it exists.\n" +
                    "If the log file is missing, opens the Logs/ folder instead." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ShowUsage)), "Show Instructions" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ShowUsage)), "Show or hide the usage instructions below." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.UsageText)),
                    "<Display toggles>\n" +
                    "1. [i] button: hide/show ALL game hover tooltips - buildings, cims, tools, bottom menu icons.\n" +
                    "2. Road Name button: hide/show road name labels. Hotkey: \\.\n" +
                    "3. Road Arrow button: force 1-way road arrows on/off (also hides road names).\n" +
                    "4. CWD Title bar icon: show/hide City Watchdog panel tooltips.\n\n" +
                    "<Notification alerts>\n" +
                    "1. Click the City Watchdog button (Top Left), or press Shift+N, to open the panel.\n" +
                    "2. Sort button for ascending/descending.\n" +
                    "3. Toggle All for quick all Off/On, or expand a section to change specific ones.\n" +
                    "4. Shows or hides icons only; does not fix the underlying city problem.\n\n" +
                    "<Money helpers>\n" +
                    "1. Add or Subtract Money: use the <Money Hotkey Amount> default keys [ and ].\n" +
                    "2. Automatic add money adds money when a city goes lower than the limit you set.\n" +
                    "3. Convert Unlimited Money Save is only for cities that were started with Unlimited Money and is <not reversible>.\n\n" +
                    "<Bottom menu tooltips>\n"+
                    "Money View adds trend values to money and population toolbar and extra details on mouse hover.\n\n" +
                    "<Custom milestone>\n" +
                    "Set Initial Money and select Milestones from the Options menu before loading or starting a city."
                },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.UsageText)), "" },
            };

            return entries;
        }

        public void Unload()
        {
        }
    }
}
