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

    public sealed class LocaleEN : IDictionarySource
    {
        private readonly CwdSettings m_Settings;

        public LocaleEN(CwdSettings setting)
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

            Dictionary<string, string> entries = new()
            {
                // --- Mod title ---
                { m_Settings.GetSettingsLocaleID(), title },

                // --- Tabs ---
                { m_Settings.GetOptionTabLocaleID(CwdSettings.Actions), "Actions" },
                { m_Settings.GetOptionTabLocaleID(CwdSettings.MiniHudTab), "Mini-HUD" },
                { m_Settings.GetOptionTabLocaleID(CwdSettings.MoneyTab), "City Start" },
                { m_Settings.GetOptionTabLocaleID(CwdSettings.About), "About" },

                // --- Groups, ordered by Options menu location ---
                { m_Settings.GetOptionGroupLocaleID(CwdSettings.AboutUsage), "USAGE" },
                { m_Settings.GetOptionGroupLocaleID(CwdSettings.Notifications), "Notifications" },
                { m_Settings.GetOptionGroupLocaleID(CwdSettings.MoneyViewGroup), "In-City Info Viewer" },
                { m_Settings.GetOptionGroupLocaleID(CwdSettings.MiniHudGroup), "Mini HUD Notifications" },
                { m_Settings.GetOptionGroupLocaleID(CwdSettings.Milestone), "NEW CITY START SETTINGS" },
                { m_Settings.GetOptionGroupLocaleID(CwdSettings.Money), "Money" },
                { m_Settings.GetOptionGroupLocaleID(CwdSettings.SaveConversion), "Convert Unlimited Save" },
                { m_Settings.GetOptionGroupLocaleID(CwdSettings.AboutInfo), "" },
                { m_Settings.GetOptionGroupLocaleID(CwdSettings.AboutLinks), "" },
                { m_Settings.GetOptionGroupLocaleID(CwdSettings.AboutDiagnostics), "DIAGNOSTICS" },

                // --------------------------------------------------------------------
                // Actions tab - Usage
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.ShowUsage)), "Show Instructions" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.ShowUsage)), "Show or hide the usage instructions below." },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.UsageText)),
                    "A. Use Paw icon (city top left), or press Shift+N, to open the main panel.\n" +
                    "<Display toggles>\n" +
                    "1. Title bar icon: show/hide City Watchdog mod tooltips.\n\n" +
                    "2. **[i]** button: hide/show <ALL> game hover tooltips - buildings, cims, tools, bottom menu icons.\n" +
                    "3. Road button: hide/show road name labels. Hotkey: \\.\n" +
                    "4. District button: hide/show district name labels.\n" +
                    "5. Road Arrow button: force 1-way road arrows on/off (also hides road names).\n\n" +
                
                    "<Notification alerts>\n" +
                    "1. Sort button cycles A→Z, Z→A, Active-only list.\n" +
                    "2. <[0/62]> = icons ON/total. Click to expand/collapse all rows.\n" +
                    "3a. [Toggle All] instantly turns Off/On all notification icons.\n" +
                    "3b. Shows or hides icons only; does not fix the underlying city problem.\n\n" +
                    "<Money helpers>\n" +
                    "1. Add / Subtract Money: use the default keys <[ or ]> for <Money Hotkey Amount>.\n" +
                    "2. Automatic money adds money when a city goes lower than the limit you set.\n" +
                    "3. Convert Unlimited Money Save is only for cities that were started with Unlimited Money and is <not reversible>.\n\n" +
                    "<Bottom menu tooltips>\n" +
                    "Money View adds extra details like Trending on mouse hover over money or population tooltips.\n\n" +
                    "<Custom milestone>\n" +
                    "Money-Milestones > NEW CITY START SETTINGS sets Initial Money or Milestones before loading or starting a city."
                },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.UsageText)), "" },

                // --------------------------------------------------------------------
                // Actions tab - Notifications
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.ToggleNotificationsKeyboardBinding)), "Toggle Notification Icons" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.ToggleNotificationsKeyboardBinding)),
                    "<Hotkey> for the same action as the in-game <[TOGGLE ALL]> icon button.\n" +
                    "It shows or hides all listed city notification icons instantly." },
                { m_Settings.GetBindingKeyLocaleID(CwdSettings.ToggleNotificationsAction), "Instant Show/Hide all notification icons" },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.ToggleNotificationPanelKeyboardBinding)), "Open/Close Notification Panel" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.ToggleNotificationPanelKeyboardBinding)),
                    "<Hotkey> for opening or closing the\n" +
                    "<notification panel> in the city.\n" +
                    "Works the same as clicking Top Left icon to open the full panel."
                },
                { m_Settings.GetBindingKeyLocaleID(CwdSettings.ToggleNotificationPanelAction), "Open/Close notification panel" },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.PanelButtonsOnlyStart)), "Panel buttons-only start" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.PanelButtonsOnlyStart)),
                    "When enabled [ ✓ ], opening City Watchdog from the top-left button starts in the smaller buttons-only view.\n" +
                    "Use the title-bar arrow or the row-count button to expand the full panel." },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.ToggleRoadNamesKeyboardBinding)), "Hide/Show Road Names" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.ToggleRoadNamesKeyboardBinding)),
                    "<Hotkey> to instantly hide or show the vanilla road name labels in the city.\n" +
                    "Same as clicking the Road-Name icon in the City Watchdog panel toolbar." },
                { m_Settings.GetBindingKeyLocaleID(CwdSettings.ToggleRoadNamesAction), "Hide/Show road names" },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.ToggleAllTooltipsKeyboardBinding)), "Disable All Mouse over Tooltips" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.ToggleAllTooltipsKeyboardBinding)),
                    "<Hotkey> to instantly hide or show ALL game hover tooltips — buildings, cims, tools, and bottom menu icons.\n" +
                    "<City Watchdog's own money/population popups stay on>; those are controlled by the Money View option above.\n" +
                    "Same as clicking the [i] icon on the City Watchdog panel inside the city." },
                { m_Settings.GetBindingKeyLocaleID(CwdSettings.ToggleAllTooltipsAction), "Hide/Show all game hover tooltips" },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.MainPanelOpacity)), "Main panel opacity" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.MainPanelOpacity)),
                    "Adjusts the main notification panel background transparency.\n" +
                    "Lower values are more transparent. Higher values are darker and more solid." },

                // --------------------------------------------------------------------
                // Actions tab - In-City Info Viewer
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.MoneyView)), "Show Money Trends + Population ToolTips" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.MoneyView)),
                    "<Recommend Enable>\n" +
                    "Bottom game menu: Shows trend values with the game's bottom toolbar <money and population arrows>.\n" +
                    "This is a lightweight hover over toolbar feature <display only>;\n" +
                    "Saves time and possible better performance than opening game's Info view panel."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.MoneyViewMode)), "Money View Frequency" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.MoneyViewMode)),
                    "Choose whether the bottom-toolbar trend text shows hourly or monthly values for money and population.\n" +
                    "Monthly uses budget income minus expenses for money, and a 24-hour projection for population." },
                { m_Settings.GetOptionLocaleID("MoneyViewModeHourly"), "Hourly (/h)" },
                { m_Settings.GetOptionLocaleID("MoneyViewModeMonthly"), "Monthly (/mo)" },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.MoneyTooltipMode)), "Money Tooltip Style" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.MoneyTooltipMode)),
                    "Choose how much detail appears in the money hover tooltip.\n" +
                    "Compact = default on first install.\n" +
                    "<Mini> shows only 2 Net values for /mo and /h.\n" +
                    "<Compact> shortens large values (15.21M instead of 15,212,318).\n" +
                    "<Full data> shows long values and Total fields." },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeMini"), "Mini" },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeCompact"), "Compact" },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeFullData"), "Full data" },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.MoneyTooltipFontScale)), "Money font size" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.MoneyTooltipFontScale)),
                    "Adjusts <font size> of Money View tooltip numbers.\n" +
                    "Game default = 100%\n" +
                    "<Mod default = 120%>\n" +
                    "Hover over Money at bottom of the screen.\n" +
                    "Requested by players who have hard time seeing smaller tooltips in the game."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.PopulationTooltipFontScale)), "Population font size" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.PopulationTooltipFontScale)),
                    "Adjusts <font size> of population tooltip numbers.\n" +
                    "Game default = 100%\n" +
                    "<Mod default = 120%>\n" +
                    "Hover over Population at bottom of the screen."
                },

                // --------------------------------------------------------------------
                // Mini-HUD tab - Mini HUD Notifications
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.MiniHudEnabled)), "Mini HUD" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.MiniHudEnabled)),
                    "Shows a small city HUD with the most important notification counts.\n" +
                    "Use it as a quick alert strip without opening the full City Watchdog panel.\n" +
                    "Clicking an icon jumps to one matching problem spot.\n" +
                    "Keep clicking the same icon to rotate through matching spots, then back to the first one."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.ApplyMiniHudRecommendedPreset)), "Click This - Quick Start" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.ApplyMiniHudRecommendedPreset)),
                    "Applies a <quick start> for Mini HUD:\n" +
                    "Includes a **starter set of Blue Star favorites**.\n" +
                    "**Blue Star** favorites tags appear in the Mini-Hud if it is one of the top 5 or 10 by total count (and if Favorites style is selected).\n" +
                    "Add/remove **Blue Stars** in the city City Watchdog panel.\n" +
                    "Set includes: Favorites style, 5 icons, horizontal, draggable, 100% icon size, dark panel, zero count icons are hidden.\n" +
                    "Start with Quick Start, then tweak minor settings to your liking. You can always reset to Quick Start later."
                  },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.MiniHudMode)), "Mini HUD Mode" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.MiniHudMode)),
                    "Choose which notification rows the Mini HUD uses.\n" +
                    "**Top active** alerts shows the highest current counts.\n" +
                    "**Favorites** includes all rows marked with **Blue Star** in the main City Watchdog panel.\n" +
                    "You can pick as many favorites as you want,\n" +
                    "but Mini HUD still shows only the top 5 or top 10 current counts from that **favorites blue-star** list." },
                { m_Settings.GetOptionLocaleID("MiniHudModeTopActive"), "Top active alerts" },
                { m_Settings.GetOptionLocaleID("MiniHudModeFavorites"), "Favorites" },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.MiniHudItemCount)), "Icon count" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.MiniHudItemCount)),
                    "Choose how many notification icons the Mini HUD can show at once." },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.MiniHudScale)), "Icon size" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.MiniHudScale)),
                    "Scale Mini HUD icons and numbers.\n" +
                    "90% = compact. 100% = default. Increase up to 130% for better visibility." },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.MiniHudOrientation)), "Orientation" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.MiniHudOrientation)),
                    "Choose whether Mini HUD icons are arranged in a row or a column." },
                { m_Settings.GetOptionLocaleID("MiniHudOrientationHorizontal"), "Horizontal" },
                { m_Settings.GetOptionLocaleID("MiniHudOrientationVertical"), "Vertical" },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.MiniHudPlacement)), "HUD placement" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.MiniHudPlacement)),
                    "Choose where the Mini HUD appears.\n" +
                    "Draggable lets you move it in the city UI." },
                { m_Settings.GetOptionLocaleID("MiniHudPlacementTopCenter"), "Top center" },
                { m_Settings.GetOptionLocaleID("MiniHudPlacementTopRight"), "Top right" },
                { m_Settings.GetOptionLocaleID("MiniHudPlacementDraggable"), "Draggable" },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.MiniHudPanelStyle)), "Dark or Glass style" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.MiniHudPanelStyle)),
                    "Choose the Mini HUD background style.\n" +
                    "Glass panel goes from clear to a cloudy white tint; it does not get darker.\n" +
                    "Use Dark panel for a darker vanilla-style HUD." },
                { m_Settings.GetOptionLocaleID("MiniHudPanelStyleDark"), "Dark panel" },
                { m_Settings.GetOptionLocaleID("MiniHudPanelStyleGlass"), "Glass panel" },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.MiniHudPanelOpacity)), "Background opacity" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.MiniHudPanelOpacity)),
                    "Adjusts Mini HUD background transparency.\n" +
                    "Lower values are more transparent. Higher values are more solid.\n" +
                    "Glass becomes more white/cloudy. Dark becomes more solid/dark." },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.MiniHudHideZero)), "Hide zero alerts" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.MiniHudHideZero)),
                    "When enabled [ ✓ ], the Mini HUD hides notification rows with a count of 0." },

                // --------------------------------------------------------------------
                // Money-Milestones tab - New City Start Settings
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.InitialMoney)), "Initial Money" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.InitialMoney)),
                    "Sets the starting balance for a new <limited money> city or the first loaded city,\n" +
                    "then resets to Game Default after it applies.\n" +
                    "This is grayed out if a city is already loaded.\n" +
                    "Set this before starting/loading a city. It applies once, then use <Money Hotkey Amount> or <Automatic Add Money> afterward." },
                { m_Settings.GetOptionLocaleID("GameDefault"), "Game Default" },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.CustomMilestone)), "Milestone Selector" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.CustomMilestone)),
                    "Enable <before loading or starting a city> to unlock a chosen milestone immediately after the city loads.\n" +
                    "- Cannot be turned ON after a city is loaded, but it can be turned OFF if it was left enabled by mistake.\n" +
                    "- If you forgot and loaded a city, just restart the game, and pick milestone before entering a city.\n" +
                    "- Mod cannot undo milestone changes already saved into a city; use an earlier save if needed."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.MilestoneLevel)), "Milestone" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.MilestoneLevel)),
                    "Pick a milestone level to unlock on the next city load.\n" +
                    "This is <only adjustable outside a loaded city>, and only after [Milestone Selector] is enabled [ ✓ ].\n" +
                    "If the city is already at or past the milestone selected, then nothing will happen.\n" +
                    "A change only happens if the milestone selected here is higher than what the city has."
                },

                // --------------------------------------------------------------------
                // Money-Milestones tab - Money
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.ManualMoneyAmount)), "Money Hotkey Amount" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.ManualMoneyAmount)),
                    "Use this amount with the Add Money and Subtract Money hotkeys.\n" +
                    "<Mod default = 40,000>\n" +
                    "This does nothing unless you use the hotkey to add/subtract money (in the city).\n" +
                    "For automated money, enable the Automatic Add Money option."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.AddMoneyKeyboardBinding)), "Add Money" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.AddMoneyKeyboardBinding)),
                    "Hotkey to <Add Money> inside the city." },
                { m_Settings.GetBindingKeyLocaleID(CwdSettings.AddMoneyAction), "Add Money" },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.SubtractMoneyKeyboardBinding)), "Subtract Money" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.SubtractMoneyKeyboardBinding)),
                    "Hotkey to <Subtract Money> inside the city." },
                { m_Settings.GetBindingKeyLocaleID(CwdSettings.SubtractMoneyAction), "Subtract Money" },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.AutomaticAddMoney)), "Automatic Add Money" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.AutomaticAddMoney)),
                    "When enabled [ ✓ ], City Watchdog checks the city balance while a city is loaded.\n" +
                    "- If the balance is <below the threshold>, \n" +
                    "  it adds the selected automatic amount.\n" +
                    "- Recommend to use Manual money with hotkey (<[> or <]>) as needed" +
                    "  instead of this automated option, but this is here if you want it."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.AutomaticAddMoneyThreshold)), "Automatic Money Threshold" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.AutomaticAddMoneyThreshold)),
                    "If Automatic Add Money is enabled and the city balance falls below this value,\n" +
                    "Add the selected automatic amount." },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.AutomaticAddMoneyAmount)), "Automatic Money Amount" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.AutomaticAddMoneyAmount)),
                    "Amount added each time Automatic Add Money triggers.\n" +
                    "Choose a value high enough to bring the city safely above the threshold." },

                // --------------------------------------------------------------------
                // Money-Milestones tab - Save Conversion
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.ConfirmUnlimitedMoneySaveConversion)), "Unlimited Money Converter" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.ConfirmUnlimitedMoneySaveConversion)),
                    "<Make a Backup of city FIRST>.\n" +
                    "Converts a city that started as Unlimited Money to a normal city with regular money challenges.\n" +
                    "Enabling this unlocks the <[Convert Unlimited Money Save]> button when the loaded city is <Unlimited Money> type.\n" +
                    "City Watchdog cannot undo this conversion.\n" +
                    "If you have normal cities, do not worry about this; it is not needed." },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.ConvertUnlimitedMoneySave)), "Convert Unlimited Money Save City to Normal" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.ConvertUnlimitedMoneySave)),
                    "For cities started with <Unlimited Money>.\n" +
                    "While that city is loaded, this converts the save to normal limited-money budgeting so the city has regular money challenges again.\n" +
                    "Button is <disabled/greyed-out> unless the loaded city is an <Unlimited Money> type\n" +
                    "and <Unlimited Money Converter> is ON [ ✓ ].\n" +
                    "Make a backup save, and use at your own risk; City Watchdog cannot undo this conversion." },

                { m_Settings.GetOptionWarningLocaleID(nameof(CwdSettings.ConvertUnlimitedMoneySave)),
                    "Convert this city from Unlimited Money to normal limited money?\n" +
                    "Save a backup FIRST; City Watchdog cannot undo this.\n" +
                    "Are you sure?" },

                // --------------------------------------------------------------------
                // About tab
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.NameText)), "Mod name" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.NameText)), "Display name of this mod." },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.VersionText)), "Version" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.VersionText)), "Current mod version." },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.OpenParadox)), "Paradox Mods" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.OpenParadox)), "Open the author's Paradox Mods page." },

                // --------------------------------------------------------------------
                // About tab - Diagnostics
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.WriteNotificationAuditLog)), "Debug Report to Log" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.WriteNotificationAuditLog)),
                    "<Not needed for normal gameplay.>\n" +
                    "For testers and post game-patch checks: writes a <Logs/CityWatchdog.log> report\n" +
                    "comparing live game notification prefabs with the notification icons Watchdog currently controls." },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.OpenLog)), "Open Log" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.OpenLog)),
                    "Opens </Logs/CityWatchdog.log> if it exists.\n" +
                    "If the log file is missing, opens the Logs/ folder instead." },
            };

            return entries;
        }

        public void Unload()
        {
        }
    }
}
