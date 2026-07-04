// <copyright file="LocaleDE.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the MIT License. You may not use this file except in compliance with this License.
// See LICENSE file in the project root for full license information.
// This notice and the MIT License notice must be kept with
// all copies or substantial portions of this code.
// ================= </copyright> ======================

// File: src/Localization/LocaleDE.cs
// Purpose: German (de-DE) for City Watchdog Options UI menu.

namespace CityWatchdog
{
    using System.Collections.Generic; // Dictionary and KeyValuePair
    using Colossal;                   // IDictionarySource
    using Game.UI.Editor;

    public sealed class LocaleDE : IDictionarySource
    {
        private readonly Setting m_Settings;

        public LocaleDE(Setting setting)
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
                { m_Settings.GetSettingsLocaleID(), title },
                { m_Settings.GetOptionTabLocaleID(Setting.Actions), "Aktionen" },
                { m_Settings.GetOptionTabLocaleID(Setting.MiniHudTab), "Mini-HUD" },
                { m_Settings.GetOptionTabLocaleID(Setting.MoneyTab), "Geld-Meilensteine" },
                { m_Settings.GetOptionTabLocaleID(Setting.About), "Über" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutUsage), "NUTZUNG" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Notifications), "Benachrichtigungen" },
                { m_Settings.GetOptionGroupLocaleID(Setting.MoneyViewGroup), "Infoanzeige in der Stadt" },
                { m_Settings.GetOptionGroupLocaleID(Setting.MiniHudGroup), "Mini-HUD-Benachrichtigungen" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Milestone), "EINSTELLUNGEN FÜR NEUE STADT" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Money), "Geld" },
                { m_Settings.GetOptionGroupLocaleID(Setting.SaveConversion), "Unbegrenzten Save konvertieren" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutInfo), "" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutLinks), "" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutDiagnostics), "DIAGNOSE" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ShowUsage)), "Anleitung anzeigen" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ShowUsage)), "Ein- oder ausblenden the usage instructions below." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.UsageText)), "<Anzeige-Schalter>\n1. [i]-Button: ALLE Spiel-Tooltips aus/einblenden.\n2. Straßennamen-Button: Straßennamen aus/einblenden. Hotkey: \\.\n3. Bezirksnamen-Button: Bezirksnamen aus/einblenden, ohne Grenzen zu ändern.\n4. Straßenpfeil-Button: Einbahnstraßen-Pfeile erzwingen und auch Straßennamen ausblenden.\n5. CWD-Titelleistenicon: Panel-Tooltips aus/einblenden.\n\n<Benachrichtigungen>\n1. City Watchdog oben links anklicken oder Shift+N drücken.\n2. Sortierbutton wechselt auf-/absteigend.\n3. Toggle All schaltet alles schnell aus/ein; Bereiche öffnen für einzelne Icons.\n4. Blendet nur Icons aus und behebt nicht das Stadtproblem.\n\n<Geldhilfen>\n1. Geld hinzufügen/abziehen: Tasten [ und ] nutzen.\n2. Automatisches Geld fügt Geld unter deiner Grenze hinzu.\n3. Unbegrenztes-Geld-Saves konvertieren ist nicht umkehrbar.\n\n<Tooltips unten>\nMoney View ergänzt Geld-/Bevölkerungstrends und Hover-Details.\n\n<Eigener Meilenstein>\nStartgeld und Meilenstein vor dem Laden oder Starten einer Stadt setzen." },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.UsageText)), "" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleNotificationsKeyboardBinding)), "Benachrichtigungssymbole umschalten" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleNotificationsKeyboardBinding)), "<Hotkey> for the same action as the in-game <[TOGGLE ALL]> icon button.\nIt shows or hides all listed city notification icons instantly." },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleNotificationsAction), "Alle Benachrichtigungssymbole sofort ein-/ausblenden" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleNotificationPanelKeyboardBinding)), "Benachrichtigungs-Panel öffnen/schließen" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleNotificationPanelKeyboardBinding)), "<Hotkey> for opening or closing the\n<Benachrichtigungs-Panel> in der Stadt.\nWorks the same as clicking Top Left icon to open the full panel." },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleNotificationPanelAction), "Benachrichtigungs-Panel öffnen/schließen" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.PanelButtonsOnlyStart)), "Start nur mit Buttons" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.PanelButtonsOnlyStart)), "Wenn aktiviert [ ✓ ], opening City Watchdog from the top-left button starts in the smaller buttons-only view.\nUse the title-bar arrow or the row-count button to expand the full panel." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleRoadNamesKeyboardBinding)), "Straßennamen aus-/einblenden" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleRoadNamesKeyboardBinding)), "<Hotkey> to instantly hide or show the vanilla road name labels in der Stadt.\nSame as clicking the Road-Name icon in the City Watchdog panel toolbar." },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleRoadNamesAction), "Straßennamen aus-/einblenden" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleAllTooltipsKeyboardBinding)), "Alle Mouseover-Tooltips deaktivieren" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleAllTooltipsKeyboardBinding)), "<Hotkey> to instantly hide or show ALL game hover tooltips — buildings, cims, tools, and bottom menu icons.\n<City Watchdog's own money/population popups stay on>; those are controlled by the Geld View option above.\nSame as clicking the [i] icon on the City Watchdog panel inside the city." },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleAllTooltipsAction), "Alle Spiel-Hover-Tooltips aus-/einblenden" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyView)), "Geld- und Bevölkerungs-Tooltips anzeigen" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyView)), "<Recommend Enable>\nBottom game menu: Shows trend values with the game's bottom toolbar <money and population arrows>.\nThis is a lightweight hover over toolbar feature <display only>;\nSaves time and possible better performance than opening game's Info view panel." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyViewMode)), "Money-View-Frequenz" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyViewMode)), "Wähle whether the bottom-toolbar trend text shows hourly or monthly values for money and population.\nMonthly uses budget income minus expenses for money, and a 24-hour projection for population." },
                { m_Settings.GetOptionLocaleID("MoneyViewModeHourly"), "Stündlich (/h)" },
                { m_Settings.GetOptionLocaleID("MoneyViewModeMonthly"), "Monatlich (/mo)" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyTooltipMode)), "Geld-Tooltip-Stil" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyTooltipMode)), "Wähle how much detail appears in the money hover tooltip.\nKompakt = default on first install.\n<Mini> shows only 2 Net values for /mo and /h.\n<Kompakt> shortens large values (15.21M instead of 15,212,318).\n<Vollständige Daten> shows long values and Total fields." },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeMini"), "Mini" },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeCompact"), "Kompakt" },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeFullData"), "Vollständige Daten" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyTooltipFontScale)), "Geld-Schriftgröße" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyTooltipFontScale)), "Adjusts <font size> of Geld View tooltip numbers.\nSpielstandard = 100%\n<Mod-Standard = 120%>\nHover over Geld at bottom of the screen.\nRequested by players who have hard time seeing smaller tooltips in the game." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.PopulationTooltipFontScale)), "Bevölkerungs-Schriftgröße" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.PopulationTooltipFontScale)), "Adjusts <font size> of population tooltip numbers.\nSpielstandard = 100%\n<Mod-Standard = 120%>\nHover over Population at bottom of the screen." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudEnabled)), "Mini-HUD" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudEnabled)), "Zeigt ein kleines HUD in der Stadt with the most important notification counts.\nUse it as a quick alert strip without opening the full City Watchdog panel.\nClicking an icon jumps to one matching problem spot.\nKeep clicking the same icon to rotate through matching spots, then back to the first one." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ApplyMiniHudRecommendedPreset)), "Empfohlenes Preset" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ApplyMiniHudRecommendedPreset)), "Applies a recommended Mini HUD setup:\nFavorites, 5 icons, horizontal, top center, 100% size, dark panel.\nZero-count alerts stay visible.\nAdd/remove **Blue Star** favorites anytime in the expanded Watchdog panel.\nStarter set Blue-Star favorites are included with **[Recommended]**." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudMode)), "Mini-HUD-Modus" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudMode)), "Wähle which notification rows the Mini-HUD uses.\n**Top active** alerts shows the highest current counts.\n**Favoriten** includes all rows marked with **Blauer Stern** in the main City Watchdog panel.\nYou can pick as many favorites as you want,\nbut Mini-HUD still shows only the top 5 or top 10 current counts from that **favorites blue-star** list." },
                { m_Settings.GetOptionLocaleID("MiniHudModeTopActive"), "Top aktive Warnungen" },
                { m_Settings.GetOptionLocaleID("MiniHudModeFavorites"), "Favoriten" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudItemCount)), "Mini-HUD-Icon-Anzahl" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudItemCount)), "Wähle how many notification icons the Mini-HUD can show at once." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudScale)), "Mini HUD size" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudScale)), "Scale Mini HUD icons and numbers.\n90% = compact. 100% = default. Increase up to 130% for better visibility." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudOrientation)), "Mini-HUD-Ausrichtung" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudOrientation)), "Wähle whether Mini-HUD icons are arranged in a row or a column." },
                { m_Settings.GetOptionLocaleID("MiniHudOrientationHorizontal"), "Horizontal" },
                { m_Settings.GetOptionLocaleID("MiniHudOrientationVertical"), "Vertikal" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudPlacement)), "Mini-HUD-Position" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudPlacement)), "Wähle where the Mini-HUD appears.\nVerschiebbar lets you move it in der Stadt UI." },
                { m_Settings.GetOptionLocaleID("MiniHudPlacementTopCenter"), "Oben mittig" },
                { m_Settings.GetOptionLocaleID("MiniHudPlacementTopRight"), "Oben rechts" },
                { m_Settings.GetOptionLocaleID("MiniHudPlacementDraggable"), "Verschiebbar" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudPanelStyle)), "Mini HUD style" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudPanelStyle)), "Choose the Mini HUD background style." },
                { m_Settings.GetOptionLocaleID("MiniHudPanelStyleDark"), "Dark panel" },
                { m_Settings.GetOptionLocaleID("MiniHudPanelStyleGlass"), "Glass panel" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudPanelOpacity)), "Mini HUD opacity" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudPanelOpacity)), "Adjusts Mini HUD background transparency.\nLower values are more transparent. Higher values are more solid." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudHideZero)), "Null-Warnungen ausblenden" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudHideZero)), "Wenn aktiviert [ ✓ ], the Mini-HUD hides notification rows with a count of 0." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.InitialMoney)), "Startgeld" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.InitialMoney)), "Sets the starting balance for a new <limited money> city or the first loaded city,\nthen resets to Spielstandard after it applies.\nThis is grayed out if a city is already loaded.\nSet this before starting/loading a city. It applies once, then use <Geld-Hotkey-Betrag> or <Automatisch Geld hinzufügen> afterward." },
                { m_Settings.GetOptionLocaleID("GameDefault"), "Spielstandard" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.CustomMilestone)), "Meilenstein-Auswahl" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.CustomMilestone)), "Enable <before loading or starting a city> to unlock a chosen milestone immediately after the city loads.\n- Cannot be turned ON after a city is loaded, but it can be turned OFF if it was left enabled by mistake.\n- If you forgot and loaded a city, just restart the game, and pick milestone before entering a city.\n- Mod kann nicht rückgängig machen milestone changes already saved into a city; use an earlier save if needed." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MilestoneLevel)), "Meilenstein" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MilestoneLevel)), "Pick a milestone level to unlock on the next city load.\nThis is <only adjustable outside a loaded city>, and only after [Meilenstein-Auswahl] is enabled [ ✓ ].\nIf the city is already at or past the milestone selected, then nothing will happen.\nA change only happens if the milestone selected here is higher than what the city has." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ManualMoneyAmount)), "Geld-Hotkey-Betrag" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ManualMoneyAmount)), "Use this amount with the Geld hinzufügen and Geld abziehen hotkeys.\n<Mod-Standard = 40,000>\nThis does nothing unless you use the hotkey to add/subtract money (in der Stadt).\nFor automated money, enable the Automatisch Geld hinzufügen option." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AddMoneyKeyboardBinding)), "Geld hinzufügen" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AddMoneyKeyboardBinding)), "Hotkey to <Geld hinzufügen> inside the city." },
                { m_Settings.GetBindingKeyLocaleID(Setting.AddMoneyAction), "Geld hinzufügen" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.SubtractMoneyKeyboardBinding)), "Geld abziehen" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.SubtractMoneyKeyboardBinding)), "Hotkey to <Geld abziehen> inside the city." },
                { m_Settings.GetBindingKeyLocaleID(Setting.SubtractMoneyAction), "Geld abziehen" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoney)), "Automatisch Geld hinzufügen" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoney)), "Wenn aktiviert [ ✓ ], City Watchdog checks the city balance while a city is loaded.\n- If the balance is <below the threshold>, \n  it adds the selected automatic amount.\n- Recommend to use Manual money with hotkey (<[> or <]>) as needed  instead of this automated option, but this is here if you want it." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoneyThreshold)), "Automatische Geld-Schwelle" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoneyThreshold)), "If Automatisch Geld hinzufügen is enabled and the city balance falls below this value,\nAdd the selected automatic amount." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoneyAmount)), "Automatischer Geldbetrag" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoneyAmount)), "Amount added each time Automatisch Geld hinzufügen triggers.\nWähle a value high enough to bring the city safely above the threshold." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ConfirmUnlimitedMoneySaveConversion)), "Unbegrenztes-Geld-Konverter" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ConfirmUnlimitedMoneySaveConversion)), "<Erstelle zuerst ein Backup>.\nConverts a city that started as Unbegrenztes Geld to a normal city with regular money challenges.\nEnabling this unlocks the <[Convert Unbegrenztes Geld Save]> button when the loaded city is <Unbegrenztes Geld> type.\nCity Watchdog kann nicht rückgängig machen this conversion.\nIf you have normal cities, do not worry about this; it is not needed." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)), "Unbegrenzte-Geld-Stadt in normal umwandeln" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)), "For cities started with <Unbegrenztes Geld>.\nWhile that city is loaded, this converts the save to normal limited-money budgeting so the city has regular money challenges again.\nButton is <disabled/greyed-out> unless the loaded city is an <Unbegrenztes Geld> type\nand <Unbegrenztes-Geld-Konverter> is ON [ ✓ ].\nMake a backup save, and use at your own risk; City Watchdog kann nicht rückgängig machen this conversion." },
                { m_Settings.GetOptionWarningLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)), "Convert this city from Unbegrenztes Geld to normal limited money?\nSave a backup FIRST; City Watchdog kann nicht rückgängig machen this.\nAre you sure?" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.NameText)), "Mod-Name" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.NameText)), "Display name of this mod." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.VersionText)), "Version" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.VersionText)), "Current mod version." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.OpenParadox)), "Paradox Mods" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.OpenParadox)), "Öffnen the author's Paradox Mods page." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.WriteNotificationAuditLog)), "Debug-Bericht ins Log" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.WriteNotificationAuditLog)), "<Not needed for normal gameplay.>\nFor testers and post game-patch checks: writes a <Logs/CityWatchdog.log> report\ncomparing live game notification prefabs with the notification icons Watchdog currently controls." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.OpenLog)), "Log öffnen" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.OpenLog)), "Öffnens </Logs/CityWatchdog.log> if it exists.\nIf the log file is missing, opens the Logs/ folder instead." },
            };

            return entries;
        }

        public void Unload()
        {
        }
    }
}
