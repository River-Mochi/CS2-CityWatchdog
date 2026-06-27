// <copyright file="LocaleDE.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the MIT License. You may not use this file except in compliance with this License.
// See LICENSE file in the project root for full license information.
// This notice and the MIT License notice must be kept with
// all copies or substantial portions of this code.
// ================= </copyright> ======================

// File: src/Localization/LocaleDE.cs
// Purpose: English (en-US) for City Watchdog Options UI menu.

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
                { m_Settings.GetOptionTabLocaleID(Setting.Actions), "Aktionen" },
                { m_Settings.GetOptionTabLocaleID(Setting.MoneyTab), "Geld-Meilensteine" },
                { m_Settings.GetOptionTabLocaleID(Setting.About), "Über" },

                // --- Groups, ordered by Options menu location ---
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

                // --------------------------------------------------------------------
                // Actions tab - Usage
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ShowUsage)), "Anleitung anzeigen" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ShowUsage)), "Zeigt oder verbirgt die Anleitung unten." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.UsageText)),
                    "<Anzeige-Schalter>\n" +
                    "1. [i]-Taste: ALLE Hover-Tooltips des Spiels aus/einblenden – Gebäude, Cims, Werkzeuge und untere Menüicons.\n" +
                    "2. Straßennamen: Straßennamen aus/einblenden. Hotkey: \\.\n" +
                    "3. Bezirksnamen: Bezirksnamen aus/einblenden, ohne Bezirksgrenzen zu ändern.\n" +
                    "4. Straßenpfeile: Einbahnstraßen-Pfeile erzwingen (blendet auch Straßennamen aus).\n" +
                    "5. CWD-Titelleistenicon: Tooltips des City-Watchdog-Panels aus/einblenden.\n" +
                    "\n" +
                    "<Benachrichtigungen>\n" +
                    "1. Klicke oben links auf City Watchdog oder drücke Shift+N, um das Panel zu öffnen.\n" +
                    "2. Sortierbutton für auf-/absteigend.\n" +
                    "3. Toggle All schaltet alles schnell aus/ein; einzelne Bereiche lassen sich aufklappen.\n" +
                    "4. Blendet nur Icons aus; das eigentliche Stadtproblem wird nicht behoben.\n" +
                    "\n" +
                    "<Geldhilfen>\n" +
                    "1. Geld hinzufügen/abziehen: nutze <Geld-Hotkey-Betrag> mit den Standardtasten [ und ].\n" +
                    "2. Automatisches Geld fügt Geld hinzu, wenn die Stadt unter dein Limit fällt.\n" +
                    "3. Unbegrenztes-Geld-Saves konvertieren ist nur für Städte mit unbegrenztem Geld und <nicht umkehrbar>.\n" +
                    "\n" +
                    "<Tooltips im unteren Menü>\n" +
                    "Money View ergänzt Trends für Geld und Bevölkerung in der Toolbar und Details beim Hover.\n" +
                    "\n" +
                    "<Eigener Meilenstein>\n" +
                    "Startgeld und Meilenstein unter Geld-Meilensteine > EINSTELLUNGEN FÜR NEUE STADT setzen, bevor eine Stadt geladen oder gestartet wird."
                },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.UsageText)), "" },

                // --------------------------------------------------------------------
                // Actions tab - Notifications
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleNotificationsKeyboardBinding)), "Benachrichtigungsicons umschalten" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleNotificationsKeyboardBinding)),
                    "<Hotkey> für dieselbe Aktion wie der <[TOGGLE ALL]>-Button im Spiel.\n" +
                    "Blendet alle gelisteten Benachrichtigungsicons sofort ein oder aus." },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleNotificationsAction), "Alle Benachrichtigungsicons sofort ein-/ausblenden" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleNotificationPanelKeyboardBinding)), "Benachrichtigungspanel öffnen/schließen" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleNotificationPanelKeyboardBinding)),
                    "<Hotkey> zum Öffnen oder Schließen des\n" +
                    "<Benachrichtigungspanels> in der Stadt.\n" +
                    "Entspricht dem Button oben links."
                },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleNotificationPanelAction), "Benachrichtigungspanel öffnen/schließen" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.PanelButtonsOnlyStart)), "Start: nur Panel-Buttons" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.PanelButtonsOnlyStart)),
                    "Wenn aktiv [ ✓ ], startet City Watchdog über den Button oben links in der kleinen Buttons-Ansicht.\n" +
                    "Mit dem Pfeil in der Titelleiste oder dem Zeilenzähler öffnest du das volle Panel." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleRoadNamesKeyboardBinding)), "Straßennamen aus/einblenden" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleRoadNamesKeyboardBinding)),
                    "<Hotkey> zum sofortigen Aus- oder Einblenden der Vanilla-Straßennamen.\n" +
                    "Wie das Straßennamen-Icon in der City-Watchdog-Leiste." },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleRoadNamesAction), "Straßennamen aus/einblenden" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleAllTooltipsKeyboardBinding)), "Alle Mouseover-Tooltips deaktivieren" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleAllTooltipsKeyboardBinding)),
                    "<Hotkey> zum Aus- oder Einblenden ALLER Spiel-Hover-Tooltips — Gebäude, Cims, Werkzeuge und untere Menüicons.\n" +
                    "<City Watchdogs Geld-/Bevölkerungs-Popups bleiben aktiv>; sie werden über Money View gesteuert.\n" +
                    "Wie das [i]-Icon im City-Watchdog-Panel." },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleAllTooltipsAction), "Alle Spiel-Tooltips aus/einblenden" },

                // --------------------------------------------------------------------
                // Actions tab - In-City Info Viewer
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyView)), "Geld- + Bevölkerungs-ToolTips anzeigen" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyView)),
                    "<Empfohlen>\n" +
                    "Unteres Spielmenü: zeigt Trendwerte bei den Geld- und Bevölkerungs-Pfeilen.\n" +
                    "Leichte Toolbar-Hover-Funktion <nur Anzeige>;\n" +
                    "spart Zeit und kann besser laufen als das Info-Panel des Spiels."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyViewMode)), "Money-View-Frequenz" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyViewMode)),
                    "Wähle, ob Trends stündlich oder monatlich für Geld und Bevölkerung angezeigt werden.\n" +
                    "Monatlich nutzt Budgeteinnahmen minus Ausgaben und eine 24-Stunden-Projektion für Bevölkerung." },
                { m_Settings.GetOptionLocaleID("MoneyViewModeHourly"), "Stündlich (/h)" },
                { m_Settings.GetOptionLocaleID("MoneyViewModeMonthly"), "Monatlich (/mo)" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyTooltipMode)), "Geld-Tooltip-Stil" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyTooltipMode)),
                    "Wähle, wie viele Details im Geld-Tooltip erscheinen.\n" +
                    "Compact = Standard bei Erstinstallation.\n" +
                    "<Mini> zeigt nur 2 Netto-Werte für /mo und /h.\n" +
                    "<Compact> kürzt große Zahlen (15.21M statt 15,212,318).\n" +
                    "<Full data> zeigt lange Werte und Gesamtfelder." },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeMini"), "Mini" },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeCompact"), "Kompakt" },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeFullData"), "Alle Daten" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyTooltipFontScale)), "Geld-Schriftgröße" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyTooltipFontScale)),
                    "Passt die <Schriftgröße> der Money-View-Zahlen an.\n" +
                    "Spielstandard = 100%\n" +
                    "<Mod-Standard = 120%>\n" +
                    "Über Geld unten fahren.\n" +
                    "Für Spieler gewünscht, die kleine Tooltips schlecht lesen können."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.PopulationTooltipFontScale)), "Bevölkerungs-Schriftgröße" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.PopulationTooltipFontScale)),
                    "Passt die <Schriftgröße> der Bevölkerungszahlen an.\n" +
                    "Spielstandard = 100%\n" +
                    "<Mod-Standard = 120%>\n" +
                    "Über Bevölkerung unten fahren."
                },

                // --------------------------------------------------------------------
                // Actions tab - Mini HUD Notifications
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudEnabled)), "Mini-HUD-Benachrichtigungen" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudEnabled)),
                    "Zeigt ein kleines HUD in der Stadt mit den wichtigsten Benachrichtigungszahlen.\n" +
                    "Nutze es als schnelle Warnleiste, ohne das vollständige City-Watchdog-Panel zu öffnen." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ApplyMiniHudRecommendedPreset)), "Empfohlenes Preset" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ApplyMiniHudRecommendedPreset)),
                    "Setzt ein empfohlenes Mini-HUD:\n" +
                    "Top-Aktive, 5 Icons, vertikal, verschiebbar, Nullwerte ausblenden und Glasstil.\n" +
                    "Das verschiebbare vertikale Preset startet nahe rechts oben." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudMode)), "Mini-HUD-Modus" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudMode)),
                    "Wähle, welche Benachrichtigungszeilen das Mini-HUD nutzt.\n" +
                    "Top aktive Warnungen zeigt die höchsten aktuellen Zahlen.\n" +
                    "Favoriten zeigt nur Zeilen, die du im City-Watchdog-Panel markiert hast." },
                { m_Settings.GetOptionLocaleID("MiniHudModeTopActive"), "Top aktive Warnungen" },
                { m_Settings.GetOptionLocaleID("MiniHudModeFavorites"), "Favoriten" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudItemCount)), "Mini-HUD-Icon-Anzahl" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudItemCount)),
                    "Wähle, wie viele Benachrichtigungsicons das Mini-HUD gleichzeitig zeigen kann." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudOrientation)), "Mini-HUD-Ausrichtung" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudOrientation)),
                    "Wähle, ob die Mini-HUD-Icons als Reihe oder Spalte angeordnet werden." },
                { m_Settings.GetOptionLocaleID("MiniHudOrientationHorizontal"), "Horizontal" },
                { m_Settings.GetOptionLocaleID("MiniHudOrientationVertical"), "Vertikal" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudPlacement)), "Mini-HUD-Position" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudPlacement)),
                    "Wähle, wo das Mini-HUD erscheint.\n" +
                    "Mit Verschiebbar kannst du es in der Stadt-UI bewegen." },
                { m_Settings.GetOptionLocaleID("MiniHudPlacementTopCenter"), "Oben mittig" },
                { m_Settings.GetOptionLocaleID("MiniHudPlacementTopRight"), "Oben rechts" },
                { m_Settings.GetOptionLocaleID("MiniHudPlacementDraggable"), "Verschiebbar" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudHideZero)), "Null-Warnungen ausblenden" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudHideZero)),
                    "Wenn aktiviert [ ✓ ], blendet das Mini-HUD Benachrichtigungszeilen mit 0 aus." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudGlassStyle)), "Glas-Stil" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudGlassStyle)),
                    "Fügt zur besseren Lesbarkeit einen weichen glasartigen Hintergrund hinter dem Mini-HUD hinzu." },

                // --------------------------------------------------------------------
                // Money-Milestones tab - New City Start Settings
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.InitialMoney)), "Startgeld" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.InitialMoney)),
                    "Legt den Startbetrag für eine neue Stadt mit <begrenztem Geld> oder die erste geladene Stadt fest\n" +
                    "und wird danach auf Game Default zurückgesetzt.\n" +
                    "Ausgegraut, wenn bereits eine Stadt geladen ist.\n" +
                    "Vor dem Starten/Laden setzen. Danach <Geld-Hotkey-Betrag> oder <Automatisches Geld> nutzen." },
                { m_Settings.GetOptionLocaleID("GameDefault"), "Spielstandard" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.CustomMilestone)), "Meilenstein-Auswahl" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.CustomMilestone)),
                    "<Vor dem Laden oder Starten einer Stadt> aktivieren, um den gewählten Meilenstein nach dem Laden freizuschalten.\n" +
                    "Kann mit geladener Stadt nicht eingeschaltet werden, aber ausgeschaltet werden, falls es versehentlich aktiv blieb.\n" +
                    "Falls vergessen: Spiel neu starten und vor dem Betreten einer Stadt wählen.\n" +
                    "City Watchdog kann gespeicherte Meilensteinänderungen nicht rückgängig machen; nutze bei Bedarf einen älteren Save." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MilestoneLevel)), "Meilenstein" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MilestoneLevel)),
                    "Wähle den Meilenstein für das nächste Laden einer Stadt.\n" +
                    "Nur außerhalb einer geladenen Stadt und nur nach Aktivierung von [Meilenstein-Auswahl] [ ✓ ] änderbar." },

                // --------------------------------------------------------------------
                // Money-Milestones tab - Money
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ManualMoneyAmount)), "Geld-Hotkey-Betrag" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ManualMoneyAmount)),
                    "Dieser Betrag wird mit den Hotkeys Geld hinzufügen und Geld abziehen genutzt.\n" +
                    "<Mod-Standard = 40,000>\n" +
                    "Tut nichts, außer du nutzt den Hotkey in der Stadt.\n" +
                    "Für automatisches Geld die entsprechende Option aktivieren."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AddMoneyKeyboardBinding)), "Geld hinzufügen" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AddMoneyKeyboardBinding)),
                    "Hotkey für <Geld hinzufügen> in der Stadt." },
                { m_Settings.GetBindingKeyLocaleID(Setting.AddMoneyAction), "Geld hinzufügen" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.SubtractMoneyKeyboardBinding)), "Geld abziehen" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.SubtractMoneyKeyboardBinding)),
                    "Hotkey für <Geld abziehen> in der Stadt." },
                { m_Settings.GetBindingKeyLocaleID(Setting.SubtractMoneyAction), "Geld abziehen" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoney)), "Automatisch Geld hinzufügen" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoney)),
                    "Wenn aktiv [ ✓ ], prüft City Watchdog das Stadtguthaben bei geladener Stadt.\n" +
                    "- Liegt es <unter dem Schwellenwert>,\n" +
                    "  wird der gewählte automatische Betrag hinzugefügt.\n" +
                    "- Manuelles Geld per Hotkey (<[> oder <]>) wird empfohlen, aber diese Option ist verfügbar."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoneyThreshold)), "Automatischer Geld-Schwellenwert" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoneyThreshold)),
                    "Wenn automatisches Geld aktiv ist und das Guthaben unter diesen Wert fällt,\n" +
                    "wird der gewählte Betrag hinzugefügt." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoneyAmount)), "Automatischer Geldbetrag" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoneyAmount)),
                    "Betrag, der jedes Mal hinzugefügt wird.\n" +
                    "Wähle genug, um sicher über dem Schwellenwert zu liegen." },

                // --------------------------------------------------------------------
                // Money-Milestones tab - Save Conversion
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ConfirmUnlimitedMoneySaveConversion)), "Konverter für unbegrenztes Geld" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ConfirmUnlimitedMoneySaveConversion)),
                    "<Erst ein Backup der Stadt machen>.\n" +
                    "Konvertiert eine Stadt mit unbegrenztem Geld zu einer normalen Stadt mit regulärem Budget.\n" +
                    "Aktiviert den Button <[Unbegrenztes-Geld-Save konvertieren]>, wenn die geladene Stadt vom Typ <Unbegrenztes Geld> ist.\n" +
                    "City Watchdog kann dies nicht rückgängig machen.\n" +
                    "Normale Städte brauchen diese Option nicht." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)), "Unbegrenztes-Geld-Stadt zu normal konvertieren" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)),
                    "Für Städte, die mit <Unbegrenztes Geld> gestartet wurden.\n" +
                    "Bei geladener Stadt wird der Save auf normales begrenztes Budget umgestellt.\n" +
                    "Button ist <deaktiviert/ausgegraut>, außer die geladene Stadt ist <Unbegrenztes Geld>\n" +
                    "und <Konverter für unbegrenztes Geld> ist ON [ ✓ ].\n" +
                    "Backup machen und auf eigenes Risiko nutzen; City Watchdog kann es nicht rückgängig machen." },

                { m_Settings.GetOptionWarningLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)),
                    "Diese Stadt von unbegrenztem Geld zu normal begrenztem Geld konvertieren?\n" +
                    "ERST ein Backup speichern; City Watchdog kann es nicht rückgängig machen.\n" +
                    "Sicher?" },

                // --------------------------------------------------------------------
                // About tab
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.NameText)), "Mod-Name" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.NameText)), "Anzeigename dieses Mods." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.VersionText)), "Version" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.VersionText)), "Aktuelle Mod-Version." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.OpenParadox)), "Paradox Mods" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.OpenParadox)), "Öffnet die Paradox-Mods-Seite des Autors." },

                // --------------------------------------------------------------------
                // About tab - Diagnostics
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.WriteNotificationAuditLog)), "Debugbericht ins Log" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.WriteNotificationAuditLog)),
                    "<Für normales Spielen nicht nötig.>\n" +
                    "Für Tester und Checks nach Spielpatches: schreibt einen Bericht nach <Logs/CityWatchdog.log>\n" +
                    "und vergleicht Live-Benachrichtigungs-Prefabs mit den Icons, die Watchdog steuert." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.OpenLog)), "Log öffnen" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.OpenLog)),
                    "Öffnet </Logs/CityWatchdog.log>, falls vorhanden.\n" +
                    "Fehlt die Datei, wird stattdessen der Logs/-Ordner geöffnet." },
            };

            return entries;
        }

        public void Unload()
        {
        }
    }
}
