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
            string title = Mod.ModName + " (Stadtwächter)";

            Dictionary<string, string> entries = new Dictionary<string, string>
            {
                // --- Mod title ---
                { m_Settings.GetSettingsLocaleID(), title },

                // --- Tabs ---
                { m_Settings.GetOptionTabLocaleID(Setting.Actions), "Aktionen" },
                { m_Settings.GetOptionTabLocaleID(Setting.Hotkeys), "Tastenkürzel" },
                { m_Settings.GetOptionTabLocaleID(Setting.About), "Info" },
                { m_Settings.GetOptionTabLocaleID(Setting.Debug), "Debug" },

                // --- Groups ---
                { m_Settings.GetOptionGroupLocaleID(Setting.MoneyViewGroup), "Infoanzeige" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Money), "Geld" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Notifications), "Benachrichtigungen" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Milestone), "Meilenstein" },
                { m_Settings.GetOptionGroupLocaleID(Setting.SaveConversion), "Speicherstand-Umwandlung" },
                { m_Settings.GetOptionGroupLocaleID(Setting.HotkeyActions), "Tastenkürzel" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutInfo), "" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutLinks), "" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutDiagnostics), "DIAGNOSE" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutUsage), "NUTZUNG" },

                // --- Money View ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyView)), "Details beim Darüberfahren anzeigen" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyView)),
                    "Zeigt Zahlen-Trends neben den Vanilla-Pfeilen für Geld und Bevölkerung in der unteren Leiste.\n" +
                    "Das ist nur eine leichte Hover-Anzeige in der Toolbar;\n" +
                    "sie ändert weder Geld noch Bevölkerung der Stadt."
                },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyViewMode)), "Money-View-Frequenz" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyViewMode)),
                    "Wähle, ob der Trendtext in der unteren Leiste stündliche oder monatliche Werte für Geld und Bevölkerung zeigt.\n" +
                    "Monatlich nutzt Budgeteinnahmen minus Ausgaben für Geld und eine 24-Stunden-Projektion für Bevölkerung."
                },
                { m_Settings.GetOptionLocaleID("MoneyViewModeHourly"), "Stündlich (/h)" },
                { m_Settings.GetOptionLocaleID("MoneyViewModeMonthly"), "Monatlich (/mo)" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyTooltipMode)), "Stil des Geld-Tooltips" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyTooltipMode)),
                    "Wähle, wie viele Details im Geld-Tooltip beim Darüberfahren angezeigt werden.\n" +
                    "Kompakt = Standard bei der ersten Installation.\n" +
                    "<Mini> zeigt nur 2 Netto-Werte für /mo und /h.\n" +
                    "<Kompakt> kürzt große Werte (15.21M statt 15,212,318).\n" +
                    "<Vollständige Daten> zeigt lange Werte und Gesamt-Felder."
                },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeMini"), "Mini" },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeCompact"), "Kompakt" },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeFullData"), "Vollständige Daten" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyTooltipFontScale)), "Schriftgröße für Geld" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyTooltipFontScale)),
                    "Passt die <Schriftgröße> der Zahlen im Money-View-Tooltip an.\n" +
                    "Spielstandard = 100%\n" +
                    "<Mod-Standard = 120%>\n" +
                    "Fahre unten am Bildschirm mit der Maus über Geld.\n" +
                    "Gewünscht von Spielern, die kleine Tooltips im Spiel schwer lesen können."
                },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.PopulationTooltipFontScale)), "Schriftgröße für Bevölkerung" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.PopulationTooltipFontScale)),
                    "Passt die <Schriftgröße> der Zahlen im Bevölkerungs-Tooltip an.\n" +
                    "Spielstandard = 100%\n" +
                    "<Mod-Standard = 120%>\n" +
                    "Fahre unten am Bildschirm mit der Maus über Bevölkerung."
                },

                // --- Money helpers ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ManualMoneyAmount)), "Geldbetrag per Hotkey" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ManualMoneyAmount)),
                    "Verwende diesen Betrag mit den Hotkeys Geld hinzufügen und Geld abziehen.\n" +
                    "<Mod-Standard = 40,000>\n" +
                    "Das macht nichts, außer du nutzt den Hotkey zum Hinzufügen/Abziehen von Geld in der Stadt.\n" +
                    "Für automatisches Geld aktiviere die Option Automatisch Geld hinzufügen."
                },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AddMoneyKeyboardBinding)), "Geld hinzufügen" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AddMoneyKeyboardBinding)), "Hotkey für <Geld hinzufügen> in der Stadt." },
                { m_Settings.GetBindingKeyLocaleID(Setting.AddMoneyAction), "Geld hinzufügen" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.SubtractMoneyKeyboardBinding)), "Geld abziehen" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.SubtractMoneyKeyboardBinding)), "Hotkey für <Geld abziehen> in der Stadt." },
                { m_Settings.GetBindingKeyLocaleID(Setting.SubtractMoneyAction), "Geld abziehen" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoney)), "Automatisch Geld hinzufügen" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoney)),
                    "Wenn aktiviert [ ✓ ], prüft City Watchdog den Stadtkontostand, solange eine Stadt geladen ist.\n" +
                    "- Wenn der Kontostand <unter dem Grenzwert> liegt, \n" +
                    "  wird der gewählte automatische Betrag hinzugefügt.\n" +
                    "- Empfohlen ist eher manuelles Geld per Hotkey (<[> oder <]>) nach Bedarf\n" +
                    "  statt dieser Automatik; sie ist aber da, wenn du sie willst."
                },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoneyThreshold)), "Grenzwert für automatisches Geld" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoneyThreshold)),
                    "Wenn Automatisch Geld hinzufügen aktiviert ist und der Stadtkontostand unter diesen Wert fällt,\n" +
                    "wird der gewählte automatische Betrag hinzugefügt."
                },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoneyAmount)), "Automatischer Geldbetrag" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoneyAmount)),
                    "Betrag, der jedes Mal hinzugefügt wird, wenn Automatisch Geld hinzufügen auslöst.\n" +
                    "Wähle einen Wert, der hoch genug ist, um die Stadt sicher über den Grenzwert zu bringen."
                },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.InitialMoney)), "Startgeld" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.InitialMoney)),
                    "Legt das Startguthaben für eine neue Stadt mit <begrenztem Geld> oder die erste geladene Stadt fest,\n" +
                    "und setzt es nach der Anwendung wieder auf Spielstandard zurück.\n" +
                    "Dies ist ausgegraut, wenn bereits eine Stadt geladen ist.\n" +
                    "Vor dem Starten/Laden setzen → wird einmal angewendet → danach <Geldbetrag per Hotkey> oder <Automatisch Geld hinzufügen> verwenden."
                },
                { m_Settings.GetOptionLocaleID("GameDefault"), "Spielstandard" },

                // --- Notifications ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleNotificationsKeyboardBinding)), "Benachrichtigungssymbole umschalten" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleNotificationsKeyboardBinding)),
                    "<Hotkey> für dieselbe Aktion wie der Symbol-Button <[TOGGLE ALL]> im Spiel-Panel.\n" +
                    "Zeigt oder versteckt sofort alle aufgelisteten Stadt-Benachrichtigungssymbole."
                },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleNotificationsAction), "Alle Benachrichtigungssymbole sofort zeigen/verstecken" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleNotificationPanelKeyboardBinding)), "Benachrichtigungs-Panel öffnen/schließen" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleNotificationPanelKeyboardBinding)),
                    "<Hotkey> zum Öffnen oder Schließen des\n" +
                    "<Benachrichtigungs-Panels> in der Stadt.\n" +
                    "Funktioniert wie ein Klick auf das Symbol oben links, um das volle Panel zu öffnen."
                },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleNotificationPanelAction), "Benachrichtigungs-Panel öffnen/schließen" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleRoadNamesKeyboardBinding)), "Straßennamen aus-/einblenden" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleRoadNamesKeyboardBinding)),
                    "<Hotkey>, um die Vanilla-Straßennamen in der Stadt sofort aus- oder einzublenden.\n" +
                    "Dasselbe wie ein Klick auf das Straßennamen-Symbol in der City-Watchdog-Panelleiste."
                },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleRoadNamesAction), "Straßennamen aus-/einblenden" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.DisableAllTooltips)), "Alle Mouse-over-Tooltips deaktivieren" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.DisableAllTooltips)),
                    "Schaltet die Hover-Tooltips des Spiels aus — sowohl die, die dem Cursor über Gebäuden/Bürgern/Werkzeugen folgen\n" +
                    " als auch die kleinen Popups auf UI-Buttons des Spiels (Namen in der oberen Leiste, Vanilla-Buttons usw.).\n" +
                    "<City Watchdogs eigene Geld-/Bevölkerungs-Popups bleiben an>; sie werden über die Money-View-Option oben gesteuert.\n" +
                    "Dasselbe wie ein Klick auf das [i]-Symbol im City-Watchdog-Panel in der Stadt."
                },

                // --- Milestone selector ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.CustomMilestone)), "Meilenstein-Auswahl" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.CustomMilestone)),
                    "Vor dem Laden oder Starten einer Stadt aktivieren, um den gewählten Meilenstein direkt nach dem Laden freizuschalten.\n" +
                    "Kann nicht eingeschaltet werden, während eine Stadt geladen ist, aber ausgeschaltet werden, falls es versehentlich aktiv blieb.\n" +
                    "City Watchdog kann bereits gespeicherte Meilenstein-Änderungen nicht rückgängig machen; nutze bei Bedarf einen älteren Spielstand."
                },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MilestoneLevel)), "Meilenstein" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MilestoneLevel)),
                    "Wähle den Meilenstein-Level, der beim nächsten Laden der Stadt freigeschaltet wird.\n" +
                    "Dies ist nur außerhalb einer geladenen Stadt einstellbar und nur nachdem [Meilenstein-Auswahl] aktiviert ist [ ✓ ]."
                },

                // --- Save conversion ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ConfirmUnlimitedMoneySaveConversion)), "Unbegrenzt-Geld-Konverter" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ConfirmUnlimitedMoneySaveConversion)),
                    "<Erstelle ZUERST ein Backup der Stadt>.\n" +
                    "Wandelt eine Stadt, die mit Unbegrenzt Geld gestartet wurde, in eine normale Stadt mit normalen Geld-Herausforderungen um.\n" +
                    "Aktivieren schaltet den Button <[Unbegrenzt-Geld-Spielstand umwandeln]> frei, wenn die geladene Stadt vom Typ <Unbegrenzt Geld> ist.\n" +
                    "City Watchdog kann diese Umwandlung nicht rückgängig machen.\n" +
                    "Wenn du normale Städte hast, keine Sorge; das brauchst du nicht."
                },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)), "Unbegrenzt-Geld-Stadt in normal umwandeln" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)),
                    "Für Städte, die mit <Unbegrenzt Geld> gestartet wurden.\n" +
                    "Während diese Stadt geladen ist, wird der Spielstand auf normales begrenztes Budget umgestellt, damit es wieder normale Geld-Herausforderungen gibt.\n" +
                    "Der Button ist <deaktiviert/ausgegraut>, außer die geladene Stadt ist vom Typ <Unbegrenzt Geld>\n" +
                    "und <Unbegrenzt-Geld-Konverter> ist AN [ ✓ ].\n" +
                    "Erstelle ein Backup und nutze es auf eigenes Risiko; City Watchdog kann diese Umwandlung nicht rückgängig machen."
                },
                { m_Settings.GetOptionWarningLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)),
                    "Diese Stadt von Unbegrenzt Geld zu normalem begrenztem Geld umwandeln?\n" +
                    "Speichere ZUERST ein Backup; City Watchdog kann das nicht rückgängig machen.\n" +
                    "Bist du sicher?"
                },

                // --- About tab ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.NameText)), "Mod-Name" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.NameText)), "Anzeigename dieses Mods." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.VersionText)), "Version" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.VersionText)), "Aktuelle Mod-Version." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.OpenParadox)), "Paradox Mods" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.OpenParadox)), "Öffnet die Paradox-Mods-Seite des Autors." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.WriteNotificationAuditLog)), "Debug-Bericht ins Log" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.WriteNotificationAuditLog)),
                    "<Für normales Spielen nicht nötig.>\n" +
                    "Für Tester und Prüfungen nach Spiel-Patches: schreibt einen Bericht nach <Logs/CityWatchdog.log>\n" +
                    "und vergleicht Live-Benachrichtigungs-Prefabs des Spiels mit den Symbolen, die Watchdog aktuell steuert."
                },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.OpenLog)), "Log öffnen" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.OpenLog)),
                    "Öffnet </Logs/CityWatchdog.log>, wenn es existiert.\n" +
                    "Wenn die Logdatei fehlt, wird stattdessen der Logs/-Ordner geöffnet."
                },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ShowUsage)), "Anleitung anzeigen" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ShowUsage)), "Zeigt oder versteckt die Anleitung unten." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.UsageText)),
                    "<Anzeige-Schalter>\n" +
                    "1. [i]-Button: ALLE Hover-Tooltips des Spiels aus-/einblenden (Gebäude, Cims, Werkzeuge).\n" +
                    "2. Straßennamen-Button: Straßennamen aus-/einblenden. Hotkey: \\.\n" +
                    "3. Straßenpfeil-Button: Einbahnstraßen-Pfeile erzwingen an/aus (versteckt auch Straßennamen).\n" +
                    "4. CWD-Titelleisten-Symbol: Tooltips des City-Watchdog-Panels zeigen/verstecken.\n" +
                    "\n" +
                    "<Benachrichtigungen>\n" +
                    "1. Klicke auf den City-Watchdog-Button (oben links) oder drücke Shift+N, um das Panel zu öffnen.\n" +
                    "2. Sortier-Button für auf-/absteigend.\n" +
                    "3. Toggle All für schnell alles Aus/An, oder eine Sektion öffnen und einzelne Symbole ändern.\n" +
                    "4. Zeigt oder versteckt nur Symbole; das eigentliche Stadtproblem wird nicht behoben.\n" +
                    "\n" +
                    "<Geld-Hilfen>\n" +
                    "1. Geld hinzufügen oder abziehen: nutze die Standardtasten [ und ] für <Geldbetrag per Hotkey>.\n" +
                    "2. Automatisch Geld hinzufügen fügt Geld hinzu, wenn eine Stadt unter den von dir gesetzten Grenzwert fällt.\n" +
                    "3. Unbegrenzt-Geld-Spielstand umwandeln ist nur für Städte, die mit Unbegrenzt Geld gestartet wurden, und ist <nicht rückgängig zu machen>.\n" +
                    "\n" +
                    "<Tooltips im unteren Menü>\n" +
                    "Money View ergänzt Trendwerte in der Geld- und Bevölkerungsleiste und zeigt zusätzliche Details beim Darüberfahren.\n" +
                    "\n" +
                    "<Eigener Meilenstein>\n" +
                    "Lege Startgeld fest und wähle Meilensteine im Optionsmenü, bevor du eine Stadt lädst oder startest."
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
