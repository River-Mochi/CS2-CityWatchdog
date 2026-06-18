// <copyright file="LocaleDE.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi, MIT License.
// See LICENSE file in the project root for full license info.
// </copyright>
//
// File: src/Localization/LocaleDE.cs
// Purpose: German (de-DE) strings for City Watchdog Options UI (settings menu).

namespace CityWatchdog
{
    using System.Collections.Generic; // Dictionary and KeyValuePair
    using Colossal;                   // IDictionarySource

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
                { m_Settings.GetOptionTabLocaleID(Setting.Actions), "Aktionen" },
                { m_Settings.GetOptionTabLocaleID(Setting.Hotkeys), "Hotkeys" },
                { m_Settings.GetOptionTabLocaleID(Setting.About), "Info" },
                { m_Settings.GetOptionTabLocaleID(Setting.Debug), "Debug" },

                // --- Groups ---
                { m_Settings.GetOptionGroupLocaleID(Setting.MoneyViewGroup), "Info-Anzeige" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Money), "Geld" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Notifications), "Benachrichtigungen" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Milestone), "Meilenstein" },
                { m_Settings.GetOptionGroupLocaleID(Setting.SaveConversion), "Spielstand-Konvertierung" },
                { m_Settings.GetOptionGroupLocaleID(Setting.HotkeyActions), "Hotkeys" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutInfo), "" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutLinks), "" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutDiagnostics), "DIAGNOSE" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutUsage), "NUTZUNG" },

                // --- Money View ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyView)), "Details beim Darüberfahren anzeigen" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyView)), "Zeigt numerische Trendwerte neben den Vanilla-Pfeilen für Geld und Bevölkerung in der unteren Werkzeugleiste.\nDies ist eine leichte Hover-Anzeige der Werkzeugleiste, <nur Anzeige>;\nes ändert weder Stadtgeld noch Bevölkerung." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyViewMode)), "Money-View-Häufigkeit" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyViewMode)), "Wähle, ob der Trendtext in der unteren Leiste stündliche oder monatliche Werte für Geld und Bevölkerung zeigt.\nMonatlich nutzt Budgeteinnahmen minus Ausgaben für Geld und eine 24-Stunden-Projektion für Bevölkerung." },
                { m_Settings.GetOptionLocaleID("MoneyViewModeHourly"), "Stündlich (/h)" },
                { m_Settings.GetOptionLocaleID("MoneyViewModeMonthly"), "Monatlich (/mo)" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyTooltipMode)), "Geld-Tooltip-Stil" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyTooltipMode)), "Wähle, wie viele Details im Geld-Tooltip beim Darüberfahren angezeigt werden.\nKompakt = Standard bei Erstinstallation.\n<Mini> zeigt nur 2 Netto-Werte für /mo und /h.\n<Kompakt> kürzt große Werte (15.21M statt 15,212,318).\n<Vollständige Daten> zeigt lange Werte und Gesamtfelder." },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeMini"), "Mini" },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeCompact"), "Kompakt" },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeFullData"), "Vollständige Daten" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyTooltipFontScale)), "Geld-Schriftgröße" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyTooltipFontScale)), "Passt die <Schriftgröße> der Zahlen im Money-View-Tooltip an.\nSpielstandard = 100%\n<Mod-Standard = 120%>\nMit der Maus über Geld unten am Bildschirm fahren.\nGewünscht von Spielern, die kleinere Tooltips im Spiel schlecht lesen können." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.PopulationTooltipFontScale)), "Bevölkerungs-Schriftgröße" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.PopulationTooltipFontScale)), "Passt die <Schriftgröße> der Bevölkerungs-Tooltip-Zahlen an.\nSpielstandard = 100%\n<Mod-Standard = 120%>\nMit der Maus über Bevölkerung unten am Bildschirm fahren." },

                // --- Money helpers ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ManualMoneyAmount)), "Geld-Hotkey-Betrag" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ManualMoneyAmount)), "Diesen Betrag mit den Hotkeys Geld hinzufügen und Geld abziehen verwenden.\n<Mod-Standard = 40,000>\nDies bewirkt nichts, außer du nutzt den Hotkey zum Hinzufügen/Abziehen von Geld (in der Stadt).\nFür automatisches Geld die Option Automatisch Geld hinzufügen aktivieren." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AddMoneyKeyboardBinding)), "Geld hinzufügen" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AddMoneyKeyboardBinding)), "Hotkey für <Geld hinzufügen> in der Stadt." },
                { m_Settings.GetBindingKeyLocaleID(Setting.AddMoneyAction), "Geld hinzufügen" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.SubtractMoneyKeyboardBinding)), "Geld abziehen" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.SubtractMoneyKeyboardBinding)), "Hotkey für <Geld abziehen> in der Stadt." },
                { m_Settings.GetBindingKeyLocaleID(Setting.SubtractMoneyAction), "Geld abziehen" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoney)), "Automatisch Geld hinzufügen" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoney)), "Wenn aktiviert [ ✓ ], prüft City Watchdog den Stadtkontostand, während eine Stadt geladen ist.\n- Wenn der Kontostand <unter dem Schwellenwert> liegt, \n  wird der gewählte automatische Betrag hinzugefügt.\n- Empfohlen ist, bei Bedarf manuell Geld per Hotkey (<[> oder <]>) zu verwenden statt dieser automatischen Option; sie ist aber verfügbar, wenn du sie möchtest." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoneyThreshold)), "Schwellenwert für automatisches Geld" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoneyThreshold)), "Wenn Automatisch Geld hinzufügen aktiviert ist und der Stadtkontostand unter diesen Wert fällt,\nwird der gewählte automatische Betrag hinzugefügt." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoneyAmount)), "Automatischer Geldbetrag" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoneyAmount)), "Betrag, der jedes Mal hinzugefügt wird, wenn Automatisch Geld hinzufügen ausgelöst wird.\nWähle einen Wert, der die Stadt sicher über den Schwellenwert bringt." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.InitialMoney)), "Startgeld" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.InitialMoney)), "Legt den Startkontostand für eine neue Stadt mit <begrenztem Geld> oder die zuerst geladene Stadt fest,\nund setzt danach auf Spielstandard zurück.\nDies ist ausgegraut, wenn bereits eine Stadt geladen ist.\nVor dem Starten/Laden einer Stadt einstellen → wird einmal angewendet → danach <Geld-Hotkey-Betrag> oder <Automatisch Geld hinzufügen> verwenden." },
                { m_Settings.GetOptionLocaleID("GameDefault"), "Spielstandard" },

                // --- Notifications ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleNotificationsKeyboardBinding)), "Benachrichtigungssymbole umschalten" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleNotificationsKeyboardBinding)), "<Hotkey> für dieselbe Aktion wie die Symbolschaltfläche <[TOGGLE ALL]> im Spielpanel.\nZeigt oder versteckt sofort alle aufgeführten Stadt-Benachrichtigungssymbole." },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleNotificationsAction), "Alle Benachrichtigungssymbole sofort anzeigen/verstecken" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleNotificationPanelKeyboardBinding)), "Benachrichtigungsfenster öffnen/schließen" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleNotificationPanelKeyboardBinding)), "<Hotkey> zum Öffnen oder Schließen des\n<Benachrichtigungsfensters> in der Stadt.\nFunktioniert wie ein Klick auf das Symbol oben links, um das vollständige Fenster zu öffnen." },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleNotificationPanelAction), "Benachrichtigungsfenster öffnen/schließen" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleRoadNamesKeyboardBinding)), "Straßennamen aus-/einblenden" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleRoadNamesKeyboardBinding)), "<Hotkey> zum sofortigen Aus- oder Einblenden der Vanilla-Straßennamen in der Stadt.\nEntspricht dem Klick auf das Straßennamen-Symbol in der City-Watchdog-Panel-Toolbar." },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleRoadNamesAction), "Straßennamen aus-/einblenden" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.DisableAllTooltips)), "Alle Tooltips beim Darüberfahren deaktivieren" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.DisableAllTooltips)), "Schaltet die Hover-Tooltips des Spiels aus — sowohl die, die dem Cursor über Gebäuden/Bürgern/Werkzeugen folgen, als auch die kleinen Popups auf UI-Schaltflächen des Spiels (Namen in der oberen Leiste, Vanilla-Schaltflächen usw.).\n<City Watchdogs eigene Geld-/Bevölkerungs-Popups bleiben an>; sie werden über die Money-View-Option oben gesteuert.\nEntspricht dem Klick auf das [i]-Symbol im City-Watchdog-Panel in der Stadt." },

                // --- Milestone selector ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.CustomMilestone)), "Meilenstein-Auswahl" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.CustomMilestone)), "Vor dem Laden oder Starten einer Stadt aktivieren, um den gewählten Meilenstein direkt nach dem Laden der Stadt freizuschalten.\nDies kann nicht eingeschaltet werden, während eine Stadt geladen ist, kann aber ausgeschaltet werden, falls es versehentlich aktiv blieb.\nCity Watchdog kann Meilensteinänderungen, die bereits in einer Stadt gespeichert wurden, nicht rückgängig machen; bei Bedarf einen älteren Spielstand verwenden." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MilestoneLevel)), "Meilenstein" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MilestoneLevel)), "Wähle den Meilenstein, der beim nächsten Laden einer Stadt freigeschaltet werden soll.\nNur außerhalb einer geladenen Stadt einstellbar und erst, nachdem [Meilenstein-Auswahl] aktiviert ist [ ✓ ]." },

                // --- Save conversion ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ConfirmUnlimitedMoneySaveConversion)), "Unbegrenztes-Geld-Konverter" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ConfirmUnlimitedMoneySaveConversion)), "<Zuerst ein Backup der Stadt erstellen>.\nKonvertiert eine Stadt, die mit Unbegrenztem Geld gestartet wurde, in eine normale Stadt mit regulären Geldherausforderungen.\nAktivieren entsperrt die Schaltfläche <[Unbegrenztes-Geld-Spielstand konvertieren]>, wenn die geladene Stadt vom Typ <Unbegrenztes Geld> ist.\nCity Watchdog kann diese Konvertierung nicht rückgängig machen.\nBei normalen Städten ist dies nicht nötig." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)), "Unbegrenztes-Geld-Stadt in normal konvertieren" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)), "Für Städte, die mit <Unbegrenztem Geld> gestartet wurden.\nWährend diese Stadt geladen ist, wird der Spielstand auf normales begrenztes Geldbudget konvertiert, damit die Stadt wieder reguläre Geldherausforderungen hat.\nDie Schaltfläche ist <deaktiviert/ausgegraut>, außer die geladene Stadt ist vom Typ <Unbegrenztes Geld>\nund <Unbegrenztes-Geld-Konverter> ist ON [ ✓ ].\nBackup-Spielstand erstellen und auf eigenes Risiko verwenden; City Watchdog kann diese Konvertierung nicht rückgängig machen." },
                { m_Settings.GetOptionWarningLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)), "Diese Stadt von Unbegrenztem Geld zu normalem begrenztem Geld konvertieren?\nZUERST ein Backup speichern; City Watchdog kann dies nicht rückgängig machen.\nSicher?" },

                // --- About tab ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.NameText)), "Modname" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.NameText)), "Anzeigename dieser Mod." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.VersionText)), "Version" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.VersionText)), "Aktuelle Modversion." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.OpenParadox)), "Paradox Mods" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.OpenParadox)), "Öffnet die Paradox-Mods-Seite des Autors." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.WriteNotificationAuditLog)), "Debug-Bericht ins Log" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.WriteNotificationAuditLog)), "<Für normales Spielen nicht erforderlich.>\nFür Tester und Prüfungen nach Spiel-Patches: schreibt einen Bericht <Logs/CityWatchdog.log>,\nder Live-Benachrichtigungsprefabs des Spiels mit den aktuell von Watchdog kontrollierten Benachrichtigungssymbolen vergleicht." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.OpenLog)), "Log öffnen" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.OpenLog)), "Öffnet </Logs/CityWatchdog.log>, falls vorhanden.\nWenn die Logdatei fehlt, wird stattdessen der Logs/-Ordner geöffnet." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ShowUsage)), "Anweisungen anzeigen" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ShowUsage)), "Zeigt oder versteckt die Nutzungsanweisungen unten." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.UsageText)), "<Benachrichtigungsfenster>\n1. Klicke auf die City-Watchdog-Schaltfläche (oben links) oder drücke Shift+N, um das Fenster zu öffnen.\n2. ASC/DESC sortieren.\n3. Toggle All für schnelles Alles Aus/Ein, oder einen Abschnitt ausklappen, um bestimmte Symbole zu ändern.\n4. Zeigt oder versteckt nur Symbole; behebt nicht das zugrunde liegende Stadtproblem.\n\n<Geldhilfen>\n1. Geld hinzufügen oder abziehen: nutze den Standard <Geld-Hotkey-Betrag> [ oder ].\n2. Automatisch Geld hinzufügen überwacht das Budget, während eine Stadt geladen ist, und fügt Geld hinzu, wenn der Kontostand unter dem Schwellenwert liegt.\n3. Money View fügt numerische Werte zur Geld- und Bevölkerungsleiste sowie Tooltips beim Darüberfahren hinzu.\n4. Unbegrenztes-Geld-Spielstand konvertieren ist nur für Städte, die mit Unbegrenztem Geld gestartet wurden, und ist <nicht rückgängig machbar>.\n\n<Benutzerdefinierter Meilenstein>\nStartgeld einstellen und Meilensteine im Optionsmenü auswählen, bevor eine Stadt geladen oder gestartet wird." },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.UsageText)), "" },
            };

            return entries;
        }

        public void Unload()
        {
        }
    }
}
