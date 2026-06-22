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
                // --- Mod title ---
                { m_Settings.GetSettingsLocaleID(), title },

                // --- Tabs ---
                { m_Settings.GetOptionTabLocaleID(Setting.Actions), "Aktionen"},
                { m_Settings.GetOptionTabLocaleID(Setting.MoneyTab), "Geld"},
                { m_Settings.GetOptionTabLocaleID(Setting.Hotkeys), "Hotkeys"},
                { m_Settings.GetOptionTabLocaleID(Setting.About), "Über"},
                { m_Settings.GetOptionTabLocaleID(Setting.Debug), "Debug"},

                // --- Groups, ordered by Options menu location ---
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutUsage), "NUTZUNG"},
                { m_Settings.GetOptionGroupLocaleID(Setting.Notifications), "Benachrichtigungen"},
                { m_Settings.GetOptionGroupLocaleID(Setting.Milestone), "EINSTELLUNGEN FÜR NEUE STADT"},
                { m_Settings.GetOptionGroupLocaleID(Setting.MoneyViewGroup), "Infoanzeige in der Stadt"},
                { m_Settings.GetOptionGroupLocaleID(Setting.Money), "Geld"},
                { m_Settings.GetOptionGroupLocaleID(Setting.SaveConversion), "Speicherstand-Konvertierung"},
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutInfo), ""},
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutLinks), ""},
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutDiagnostics), "DIAGNOSE"},
                { m_Settings.GetOptionGroupLocaleID(Setting.HotkeyActions), "Hotkeys"},

                // --------------------------------------------------------------------
                // Actions tab - Usage
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ShowUsage)), "Anleitung anzeigen"},
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ShowUsage)), "Zeigt oder verbirgt die Anleitung unten."},

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.UsageText)),
                    "<Anzeige-Schalter>\n" +
                    "1. [i]-Taste: ALLE Hover-Tooltips des Spiels aus/einblenden – Gebäude, Bürger, Werkzeuge und untere Menüicons.\n" +
                    "2. Straßennamen: Straßennamen aus/einblenden. Hotkey: \\.\n" +
                    "3. Straßenpfeile: Einbahnstraßen-Pfeile erzwingen (blendet auch Straßennamen aus).\n" +
                    "4. CWD-Titelleistenicon: Tooltips des City-Watchdog-Panels aus/einblenden.\n" +
                    "\n" +
                    "<Benachrichtigungen>\n" +
                    "1. City-Watchdog-Button oben links anklicken oder Shift+N drücken, um das Panel zu öffnen.\n" +
                    "2. Sortierbutton für auf-/absteigend.\n" +
                    "3. Toggle All schaltet alles schnell aus/ein; einzelne Bereiche lassen sich aufklappen.\n" +
                    "4. Blendet nur Icons aus; das eigentliche Stadtproblem wird nicht behoben.\n" +
                    "\n" +
                    "<Geldhilfen>\n" +
                    "1. Geld hinzufügen/abziehen: Standardtasten [ und ].\n" +
                    "2. Automatisches Geld fügt Geld hinzu, wenn die Stadt unter dein Limit fällt.\n" +
                    "3. Unbegrenztes-Geld-Saves konvertieren ist nur für Städte mit unbegrenztem Geld und <nicht umkehrbar>.\n" +
                    "\n" +
                    "<Tooltips im unteren Menü>\n" +
                    "Money View ergänzt Trends für Geld und Bevölkerung mit Details beim Hover.\n" +
                    "\n" +
                    "<Eigener Meilenstein>\n" +
                    "Startgeld und Meilenstein unter EINSTELLUNGEN FÜR NEUE STADT setzen, bevor eine Stadt geladen oder gestartet wird."},
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.UsageText)), ""},

                // --------------------------------------------------------------------
                // Actions tab - Notifications
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleNotificationsKeyboardBinding)), "Benachrichtigungsicons umschalten"},
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleNotificationsKeyboardBinding)),
                    "<Hotkey> für dieselbe Aktion wie der <[TOGGLE ALL]>-Button im Spiel.\n" +
                    "Blendet alle gelisteten Benachrichtigungsicons sofort ein oder aus."},
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleNotificationsAction), "Alle Benachrichtigungsicons sofort ein-/ausblenden"},

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleNotificationPanelKeyboardBinding)), "Benachrichtigungspanel öffnen/schließen"},
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleNotificationPanelKeyboardBinding)),
                    "<Hotkey> zum Öffnen oder Schließen des\n" +
                    "<Benachrichtigungspanels> in der Stadt.\n" +
                    "Entspricht dem Button oben links."},
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleNotificationPanelAction), "Benachrichtigungspanel öffnen/schließen"},

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleRoadNamesKeyboardBinding)), "Straßennamen aus/einblenden"},
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleRoadNamesKeyboardBinding)),
                    "<Hotkey> zum sofortigen Aus- oder Einblenden der Vanilla-Straßennamen.\n" +
                    "Wie das Straßennamen-Icon in der City-Watchdog-Leiste."},
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleRoadNamesAction), "Straßennamen aus/einblenden"},

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleAllTooltipsKeyboardBinding)), "Alle Mouseover-Tooltips deaktivieren"},
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleAllTooltipsKeyboardBinding)),
                    "<Hotkey> zum Aus- oder Einblenden ALLER Spiel-Hover-Tooltips — Gebäude, Cims, Werkzeuge und untere Menüicons.\n" +
                    "<City Watchdogs Geld-/Bevölkerungs-Popups bleiben aktiv>; sie werden über Money View gesteuert.\n" +
                    "Wie das [i]-Icon im City-Watchdog-Panel."},
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleAllTooltipsAction), "Alle Spiel-Tooltips aus/einblenden"},

                // --------------------------------------------------------------------
                // Actions tab - New City Start Settings
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.InitialMoney)), "Startgeld"},
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.InitialMoney)),
                    "Legt den Startbetrag für eine neue Stadt mit <begrenztem Geld> oder die erste geladene Stadt fest\n" +
                    "und wird danach auf Game Default zurückgesetzt.\n" +
                    "Ausgegraut, wenn bereits eine Stadt geladen ist.\n" +
                    "Vor dem Starten/Laden setzen. Danach <Geld-Hotkey-Betrag> oder <Automatisches Geld> nutzen."},
                { m_Settings.GetOptionLocaleID("GameDefault"), "Spielstandard"},

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.CustomMilestone)), "Meilenstein-Auswahl"},
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.CustomMilestone)),
                    "<Vor dem Laden oder Starten einer Stadt> aktivieren, um den gewählten Meilenstein nach dem Laden freizuschalten.\n" +
                    "Kann mit geladener Stadt nicht eingeschaltet werden, aber ausgeschaltet werden, falls es versehentlich aktiv blieb.\n" +
                    "Falls vergessen: Spiel neu starten und vor dem Betreten einer Stadt wählen.\n" +
                    "City Watchdog kann gespeicherte Meilensteinänderungen nicht rückgängig machen; nutze bei Bedarf einen älteren Save."},

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MilestoneLevel)), "Meilenstein"},
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MilestoneLevel)),
                    "Wähle den Meilenstein für das nächste Laden einer Stadt.\n" +
                    "Nur außerhalb einer geladenen Stadt und nur nach Aktivierung von [Meilenstein-Auswahl] [ ✓ ] änderbar."},

                // --------------------------------------------------------------------
                // Money tab - In City Info Viewer
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyView)), "Geld- + Bevölkerungs-ToolTips anzeigen"},
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyView)),
                    "<Empfohlen>\n" +
                    "Unteres Spielmenü: zeigt Trendwerte bei den Geld- und Bevölkerungs-Pfeilen.\n" +
                    "Leichte Toolbar-Hover-Funktion <nur Anzeige>;\n" +
                    "spart Zeit und kann besser laufen als das Info-Panel des Spiels."},

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyViewMode)), "Money-View-Frequenz"},
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyViewMode)),
                    "Wähle, ob Trends stündlich oder monatlich für Geld und Bevölkerung angezeigt werden.\n" +
                    "Monatlich nutzt Budgeteinnahmen minus Ausgaben und eine 24-Stunden-Projektion für Bevölkerung."},
                { m_Settings.GetOptionLocaleID("MoneyViewModeHourly"), "Stündlich (/h)"},
                { m_Settings.GetOptionLocaleID("MoneyViewModeMonthly"), "Monatlich (/mo)"},

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyTooltipMode)), "Geld-Tooltip-Stil"},
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyTooltipMode)),
                    "Wähle, wie viele Details im Geld-Tooltip erscheinen.\n" +
                    "Compact = Standard bei Erstinstallation.\n" +
                    "<Mini> zeigt nur 2 Netto-Werte für /mo und /h.\n" +
                    "<Compact> kürzt große Zahlen (15.21M statt 15,212,318).\n" +
                    "<Full data> zeigt lange Werte und Gesamtfelder."},
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeMini"), "Mini"},
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeCompact"), "Kompakt"},
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeFullData"), "Alle Daten"},

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyTooltipFontScale)), "Geld-Schriftgröße"},
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyTooltipFontScale)),
                    "Passt die <Schriftgröße> der Money-View-Zahlen an.\n" +
                    "Spielstandard = 100%\n" +
                    "<Mod-Standard = 120%>\n" +
                    "Über Geld unten fahren.\n" +
                    "Für Spieler gewünscht, die kleine Tooltips schlecht lesen können."},

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.PopulationTooltipFontScale)), "Bevölkerungs-Schriftgröße"},
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.PopulationTooltipFontScale)),
                    "Passt die <Schriftgröße> der Bevölkerungszahlen an.\n" +
                    "Spielstandard = 100%\n" +
                    "<Mod-Standard = 120%>\n" +
                    "Über Bevölkerung unten fahren."},

                // --------------------------------------------------------------------
                // Money tab - Money
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ManualMoneyAmount)), "Geld-Hotkey-Betrag"},
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ManualMoneyAmount)),
                    "Dieser Betrag wird mit den Hotkeys Geld hinzufügen und Geld abziehen genutzt.\n" +
                    "<Mod-Standard = 40,000>\n" +
                    "Tut nichts, außer du nutzt den Hotkey in der Stadt.\n" +
                    "Für automatisches Geld die entsprechende Option aktivieren."},

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AddMoneyKeyboardBinding)), "Geld hinzufügen"},
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AddMoneyKeyboardBinding)),
                    "Hotkey für <Geld hinzufügen> in der Stadt."},
                { m_Settings.GetBindingKeyLocaleID(Setting.AddMoneyAction), "Geld hinzufügen"},

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.SubtractMoneyKeyboardBinding)), "Geld abziehen"},
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.SubtractMoneyKeyboardBinding)),
                    "Hotkey für <Geld abziehen> in der Stadt."},
                { m_Settings.GetBindingKeyLocaleID(Setting.SubtractMoneyAction), "Geld abziehen"},

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoney)), "Automatisch Geld hinzufügen"},
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoney)),
                    "Wenn aktiv [ ✓ ], prüft City Watchdog das Stadtguthaben bei geladener Stadt.\n" +
                    "- Liegt es <unter dem Schwellenwert>,\n" +
                    "  wird der gewählte automatische Betrag hinzugefügt.\n" +
                    "- Manuelles Geld per Hotkey (<[> oder <]>) wird empfohlen, aber diese Option ist verfügbar."},

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoneyThreshold)), "Automatischer Geld-Schwellenwert"},
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoneyThreshold)),
                    "Wenn automatisches Geld aktiv ist und das Guthaben unter diesen Wert fällt,\n" +
                    "wird der gewählte Betrag hinzugefügt."},

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoneyAmount)), "Automatischer Geldbetrag"},
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoneyAmount)),
                    "Betrag, der jedes Mal hinzugefügt wird.\n" +
                    "Wähle genug, um sicher über dem Schwellenwert zu liegen."},

                // --------------------------------------------------------------------
                // Money tab - Save Conversion
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ConfirmUnlimitedMoneySaveConversion)), "Konverter für unbegrenztes Geld"},
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ConfirmUnlimitedMoneySaveConversion)),
                    "<Erst ein Backup der Stadt machen>.\n" +
                    "Konvertiert eine Stadt mit unbegrenztem Geld zu einer normalen Stadt mit regulärem Budget.\n" +
                    "Aktiviert den Button <[Unbegrenztes-Geld-Save konvertieren]>, wenn die geladene Stadt vom Typ <Unbegrenztes Geld> ist.\n" +
                    "City Watchdog kann dies nicht rückgängig machen.\n" +
                    "Normale Städte brauchen diese Option nicht."},

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)), "Unbegrenztes-Geld-Stadt zu normal konvertieren"},
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)),
                    "Für Städte, die mit <Unbegrenztes Geld> gestartet wurden.\n" +
                    "Bei geladener Stadt wird der Save auf normales begrenztes Budget umgestellt.\n" +
                    "Button ist <deaktiviert/ausgegraut>, außer die geladene Stadt ist <Unbegrenztes Geld>\n" +
                    "und <Konverter für unbegrenztes Geld> ist ON [ ✓ ].\n" +
                    "Backup machen und auf eigenes Risiko nutzen; City Watchdog kann es nicht rückgängig machen."},

                { m_Settings.GetOptionWarningLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)),
                    "Diese Stadt von unbegrenztem Geld zu normal begrenztem Geld konvertieren?\n" +
                    "ERST ein Backup speichern; City Watchdog kann es nicht rückgängig machen.\n" +
                    "Sicher?"},

                // --------------------------------------------------------------------
                // About tab
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.NameText)), "Mod-Name"},
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.NameText)), "Anzeigename dieses Mods."},

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.VersionText)), "Version"},
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.VersionText)), "Aktuelle Mod-Version."},

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.OpenParadox)), "Paradox Mods"},
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.OpenParadox)), "Öffnet die Paradox-Mods-Seite des Autors."},

                // --------------------------------------------------------------------
                // Debug tab - Diagnostics
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.WriteNotificationAuditLog)), "Debugbericht ins Log"},
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.WriteNotificationAuditLog)),
                    "<Für normales Spielen nicht nötig.>\n" +
                    "Für Tester und Checks nach Spielpatches: schreibt einen Bericht nach <Logs/CityWatchdog.log>\n" +
                    "und vergleicht Live-Benachrichtigungs-Prefabs mit den Icons, die Watchdog steuert."},

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.OpenLog)), "Log öffnen"},
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.OpenLog)),
                    "Öffnet </Logs/CityWatchdog.log>, falls vorhanden.\n" +
                    "Fehlt die Datei, wird stattdessen der Logs/-Ordner geöffnet."},
            };

            return entries;
        }

        public void Unload()
        {
        }
    }
}
