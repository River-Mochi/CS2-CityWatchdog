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
                { m_Settings.GetOptionTabLocaleID(Setting.Actions), "Aktionen" },
                { m_Settings.GetOptionTabLocaleID(Setting.MiniHudTab), "Mini-HUD" },
                { m_Settings.GetOptionTabLocaleID(Setting.MoneyTab), "Geld-Meilensteine" },
                { m_Settings.GetOptionTabLocaleID(Setting.About), "Über" },

                // --- Groups, ordered by Options menu location ---
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutUsage), "NUTZUNG" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Notifications), "Benachrichtigungen" },
                { m_Settings.GetOptionGroupLocaleID(Setting.MoneyViewGroup), "Stadt-Infoanzeige" },
                { m_Settings.GetOptionGroupLocaleID(Setting.MiniHudGroup), "Mini-HUD-Benachrichtigungen" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Milestone), "NEUE-STADT-START" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Money), "Geld" },
                { m_Settings.GetOptionGroupLocaleID(Setting.SaveConversion), "Unbegrenzt-Save umwandeln" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutInfo), "" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutLinks), "" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutDiagnostics), "DIAGNOSE" },

                // --------------------------------------------------------------------
                // Actions tab - Usage
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ShowUsage)), "Anleitung anzeigen" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ShowUsage)), "Zeigt oder versteckt die Anleitung unten." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.UsageText)),
                    "<Anzeige-Schalter>\n" +
                    "1. [i]-Button: ALLE Spiel-Tooltips aus/einblenden.\n" +
                    "2. Straßennamen-Button: Namen aus/einblenden. Hotkey: \\.\n" +
                    "3. Bezirksnamen-Button: Namen aus/einblenden, ohne Grenzen zu ändern.\n" +
                    "4. Straßenpfeil-Button: Einbahnstraßenpfeile erzwingen (blendet auch Straßennamen aus).\n" +
                    "5. CWD-Titelleistenicon: City-Watchdog-Tooltips aus/einblenden.\n\n" +
                    "<Warnmeldungen>\n" +
                    "1. City Watchdog oben links anklicken oder Shift+N drücken.\n" +
                    "2. Sortierbutton: auf-/absteigend.\n" +
                    "3. Toggle All schaltet schnell alles aus/ein; Bereiche öffnen für Details.\n" +
                    "4. Blendet nur Icons aus; behebt nicht das Stadtproblem.\n\n" +
                    "<Geldhilfen>\n" +
                    "1. Geld hinzufügen/abziehen: Standardtasten [ und ].\n" +
                    "2. Automatisches Geld fügt Geld unter deiner Grenze hinzu.\n" +
                    "3. Unbegrenzt-Geld-Save umwandeln gilt nur für solche Städte und ist <nicht umkehrbar>.\n\n" +
                    "<Tooltips unten>\n" +
                    "Money View ergänzt Geld-/Bevölkerungstrends und Hover-Details.\n\n" +
                    "<Eigener Meilenstein>\n" +
                    "Startgeld und Meilenstein vor dem Laden oder Starten einer Stadt setzen."
                },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.UsageText)), "" },

                // --------------------------------------------------------------------
                // Actions tab - Notifications
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleNotificationsKeyboardBinding)), "Benachrichtigungssymbole umschalten" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleNotificationsKeyboardBinding)),
                    "<Hotkey> für dieselbe Aktion wie der <[TOGGLE ALL]>-Button im Spiel.\n" +
                    "Zeigt oder versteckt alle gelisteten Stadtwarnsymbole sofort." },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleNotificationsAction), "Alle Benachrichtigungssymbole sofort ein-/ausblenden" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleNotificationPanelKeyboardBinding)), "Benachrichtigungs-Panel öffnen/schließen" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleNotificationPanelKeyboardBinding)),
                    "<Hotkey> zum Öffnen oder Schließen des\n" +
                    "<Benachrichtigungs-Panels> in der Stadt.\n" +
                    "Wie ein Klick auf das Symbol oben links."
                },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleNotificationPanelAction), "Benachrichtigungs-Panel öffnen/schließen" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.PanelButtonsOnlyStart)), "Start nur mit Buttons" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.PanelButtonsOnlyStart)),
                    "Wenn aktiv [ ✓ ], startet City Watchdog in der kleinen Nur-Buttons-Ansicht.\n" +
                    "Titelleistenpfeil oder Zeilenzähler öffnet das volle Panel." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleRoadNamesKeyboardBinding)), "Straßennamen aus-/einblenden" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleRoadNamesKeyboardBinding)),
                    "<Hotkey> zum sofortigen Aus-/Einblenden der Vanilla-Straßennamen.\n" +
                    "Wie das Straßennamen-Icon in City Watchdog." },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleRoadNamesAction), "Straßennamen aus-/einblenden" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleAllTooltipsKeyboardBinding)), "Alle Mouseover-Tooltips deaktivieren" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleAllTooltipsKeyboardBinding)),
                    "<Hotkey> zum Aus-/Einblenden ALLER Spiel-Tooltips.\n" +
                    "<City-Watchdog-Geld/Bevölkerungs-Popups bleiben an>; sie gehören zu Money View.\n" +
                    "Wie das [i]-Icon im City-Watchdog-Panel." },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleAllTooltipsAction), "Alle Spiel-Hover-Tooltips aus-/einblenden" },

                // --------------------------------------------------------------------
                // Actions tab - In-City Info Viewer
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyView)), "Geld- und Bevölkerungs-Tooltips anzeigen" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyView)),
                    "<Empfohlen>\n" +
                    "Unteres Menü: zeigt Trends bei den Geld- und Bevölkerungspfeilen.\n" +
                    "Leichtes Hover-Feature der Toolbar <nur Anzeige>;\n" +
                    "spart das Öffnen des Info-Panels."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyViewMode)), "Money-View-Frequenz" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyViewMode)),
                    "Wähle stündliche oder monatliche Trends im unteren Menü.\n" +
                    "Monatlich nutzt Einnahmen minus Ausgaben und eine 24-h-Bevölkerungsprojektion." },
                { m_Settings.GetOptionLocaleID("MoneyViewModeHourly"), "Stündlich (/h)" },
                { m_Settings.GetOptionLocaleID("MoneyViewModeMonthly"), "Monatlich (/mo)" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyTooltipMode)), "Geld-Tooltip-Stil" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyTooltipMode)),
                    "Wähle, wie viele Details der Geld-Tooltip zeigt.\n" +
                    "Kompakt = Standard bei Erstinstallation.\n" +
                    "<Mini> zeigt nur 2 Netto-Werte für /mo und /h.\n" +
                    "<Kompakt> kürzt große Werte (15.21M statt 15,212,318).\n" +
                    "<Vollständige Daten> zeigt lange Werte und Summen." },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeMini"), "Mini" },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeCompact"), "Kompakt" },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeFullData"), "Vollständige Daten" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyTooltipFontScale)), "Geld-Schriftgröße" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyTooltipFontScale)),
                    "Ändert die <Schriftgröße> der Money-View-Zahlen.\n" +
                    "Spielstandard = 100%\n" +
                    "<Mod-Standard = 120%>\n" +
                    "Über Geld unten im Bildschirm fahren.\n" +
                    "Für Spieler, denen kleine Tooltips schwer lesbar sind."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.PopulationTooltipFontScale)), "Bevölkerungs-Schriftgröße" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.PopulationTooltipFontScale)),
                    "Ändert die <Schriftgröße> der Bevölkerungszahlen.\n" +
                    "Spielstandard = 100%\n" +
                    "<Mod-Standard = 120%>\n" +
                    "Über Bevölkerung unten im Bildschirm fahren."
                },

                // --------------------------------------------------------------------
                // Mini-HUD tab - Mini HUD Notifications
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudEnabled)), "Mini HUD" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudEnabled)),
                    "Zeigt ein kleines HUD mit wichtigen Warnzählern.\n" +
                    "Schnelle Warnleiste ohne das volle Panel zu öffnen.\n" +
                    "Ein Klick auf ein Icon springt zu einem passenden Problem.\n" +
                    "Weiterklicken rotiert durch passende Stellen und zurück zur ersten."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ApplyMiniHudRecommendedPreset)), "Empfohlenes Starter-Set" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ApplyMiniHudRecommendedPreset)),
                    "Wendet ein empfohlenes Mini-HUD-Setup an:\n" +
                    "Favoriten, 5 Icons, horizontal, oben mittig, 100%, dunkles Panel.\n" +
                    "Warnungen mit 0 bleiben sichtbar.\n" +
                    "**Blaue Sterne** jederzeit im erweiterten Watchdog-Panel hinzufügen/entfernen.\n" +
                    "Starter-Favoriten mit **Blauem Stern** sind in **[Empfohlen]** enthalten."
                  },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudMode)), "Mini-HUD-Modus" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudMode)),
                    "Wähle, welche Zeilen das Mini HUD nutzt.\n" +
                    "**Top aktiv** zeigt die höchsten aktuellen Zähler.\n" +
                    "**Favoriten** nutzt alle Zeilen mit **Blauem Stern**.\n" +
                    "Du kannst beliebig viele Favoriten wählen,\n" +
                    "aber Mini HUD zeigt nur die Top 5 oder Top 10 aus dieser Favoritenliste." },
                { m_Settings.GetOptionLocaleID("MiniHudModeTopActive"), "Top aktive Warnungen" },
                { m_Settings.GetOptionLocaleID("MiniHudModeFavorites"), "Favoriten" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudItemCount)), "Mini-HUD-Icon-Anzahl" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudItemCount)),
                    "Wähle, wie viele Icons das Mini HUD zeigt." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudScale)), "Mini-HUD-Größe" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudScale)),
                    "Skaliert Icons und Zahlen des Mini HUD.\n" +
                    "90% = kompakt. 100% = Standard. Bis 130% für bessere Sichtbarkeit." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudOrientation)), "Mini-HUD-Ausrichtung" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudOrientation)),
                    "Zeile oder Spalte wählen." },
                { m_Settings.GetOptionLocaleID("MiniHudOrientationHorizontal"), "Horizontal" },
                { m_Settings.GetOptionLocaleID("MiniHudOrientationVertical"), "Vertikal" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudPlacement)), "Mini-HUD-Position" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudPlacement)),
                    "Wähle, wo das Mini HUD erscheint.\n" +
                    "Verschiebbar lässt dich es in der Stadt-UI bewegen." },
                { m_Settings.GetOptionLocaleID("MiniHudPlacementTopCenter"), "Oben mittig" },
                { m_Settings.GetOptionLocaleID("MiniHudPlacementTopRight"), "Oben rechts" },
                { m_Settings.GetOptionLocaleID("MiniHudPlacementDraggable"), "Verschiebbar" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudPanelStyle)), "Mini-HUD-Stil" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudPanelStyle)),
                    "Wähle den Mini-HUD-Hintergrund.\n" +
                    "Glas geht von klar zu wolkig weiß; es wird nicht dunkler.\n" +
                    "Dunkles Panel für ein dunkleres Vanilla-HUD." },
                { m_Settings.GetOptionLocaleID("MiniHudPanelStyleDark"), "Dunkles Panel" },
                { m_Settings.GetOptionLocaleID("MiniHudPanelStyleGlass"), "Glas-Panel" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudPanelOpacity)), "Mini-HUD-Deckkraft" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudPanelOpacity)),
                    "Ändert die Transparenz des Mini-HUD-Hintergrunds.\n" +
                    "Niedriger = transparenter. Höher = deckender.\n" +
                    "Glas wird weißer/wolkiger. Dunkel wird dunkler/deckender." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudHideZero)), "Null-Warnungen ausblenden" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudHideZero)),
                    "Wenn aktiv [ ✓ ], blendet das Mini HUD Zeilen mit 0 aus." },

                // --------------------------------------------------------------------
                // Money-Milestones tab - New City Start Settings
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.InitialMoney)), "Startgeld" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.InitialMoney)),
                    "Setzt das Startgeld für eine neue Stadt mit <begrenztem Geld>,\n" +
                    "danach zurück auf Spielstandard.\n" +
                    "Ausgegraut, wenn eine Stadt geladen ist.\n" +
                    "Vor dem Start/Laden setzen. Danach <Geld-Hotkey-Betrag> oder <Automatisch Geld hinzufügen> nutzen." },
                { m_Settings.GetOptionLocaleID("GameDefault"), "Spielstandard" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.CustomMilestone)), "Meilenstein-Auswahl" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.CustomMilestone)),
                    "<Vor dem Laden oder Starten> aktivieren, um einen Meilenstein beim Laden freizuschalten.\n" +
                    "- Kann nach Laden einer Stadt nicht aktiviert, aber deaktiviert werden.\n" +
                    "- Falls vergessen: Spiel neu starten und vor Betreten der Stadt wählen.\n" +
                    "- Der Mod kann gespeicherte Meilensteinänderungen nicht rückgängig machen; ältere Speicherung nutzen."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MilestoneLevel)), "Meilenstein" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MilestoneLevel)),
                    "Meilenstein für den nächsten Stadt-Ladevorgang wählen.\n" +
                    "Nur <außerhalb einer geladenen Stadt> und nach aktivierter [Meilenstein-Auswahl] [ ✓ ].\n" +
                    "Ist die Stadt schon dort oder weiter, passiert nichts.\n" +
                    "Änderung nur, wenn der gewählte Meilenstein höher ist."
                },

                // --------------------------------------------------------------------
                // Money-Milestones tab - Money
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ManualMoneyAmount)), "Geld-Hotkey-Betrag" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ManualMoneyAmount)),
                    "Dieser Betrag wird mit Geld hinzufügen/abziehen genutzt.\n" +
                    "<Mod-Standard = 40.000>\n" +
                    "Tut nichts, außer du nutzt den Hotkey in der Stadt.\n" +
                    "Für Automatik: Automatisch Geld hinzufügen aktivieren."
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
                    "Wenn aktiv [ ✓ ], prüft City Watchdog das Stadtguthaben.\n" +
                    "- Wenn das Guthaben <unter der Schwelle> liegt, \n" +
                    "  wird der gewählte Betrag hinzugefügt.\n" +
                    "- Besser manuell per Hotkey (<[> oder <]>) nach Bedarf nutzen" +
                    "  statt Automatik; die Option ist trotzdem da."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoneyThreshold)), "Automatische Geld-Schwelle" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoneyThreshold)),
                    "Wenn Automatik aktiv ist und Guthaben unter diesen Wert fällt,\n" +
                    "wird der gewählte Betrag hinzugefügt." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoneyAmount)), "Automatischer Geldbetrag" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoneyAmount)),
                    "Betrag pro automatischer Auslösung.\n" +
                    "Hoch genug wählen, um sicher über die Schwelle zu kommen." },

                // --------------------------------------------------------------------
                // Money-Milestones tab - Save Conversion
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ConfirmUnlimitedMoneySaveConversion)), "Unbegrenztes-Geld-Konverter" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ConfirmUnlimitedMoneySaveConversion)),
                    "<ZUERST Backup erstellen>.\n" +
                    "Wandelt eine Stadt mit Unbegrenzt Geld in eine normale Stadt um.\n" +
                    "Aktiviert den Button <[Unbegrenzt-Geld-Save umwandeln]>, wenn die geladene Stadt <Unbegrenzt Geld> ist.\n" +
                    "City Watchdog kann diese Umwandlung nicht rückgängig machen.\n" +
                    "Für normale Städte ist diese Option nicht nötig." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)), "Unbegrenzt-Geld-Stadt in normal umwandeln" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)),
                    "Für Städte, die mit <Unbegrenzt Geld> gestartet wurden.\n" +
                    "Während die Stadt geladen ist, wird der Save auf normales begrenztes Geld umgestellt.\n" +
                    "Button ist <deaktiviert/ausgegraut>, außer die Stadt ist <Unbegrenzt Geld>\n" +
                    "und <Unbegrenztes-Geld-Konverter> ist AN [ ✓ ].\n" +
                    "Backup machen und auf eigenes Risiko nutzen; City Watchdog kann es nicht rückgängig machen." },

                { m_Settings.GetOptionWarningLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)),
                    "Diese Stadt von Unbegrenzt Geld zu normal begrenztem Geld umwandeln?\n" +
                    "ZUERST Backup speichern; City Watchdog kann es nicht rückgängig machen.\n" +
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

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.WriteNotificationAuditLog)), "Debug-Bericht ins Log" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.WriteNotificationAuditLog)),
                    "<Nicht für normales Spielen nötig.>\n" +
                    "Für Tester und nach Spiel-Patches: schreibt einen Bericht nach <Logs/CityWatchdog.log>\n" +
                    "und vergleicht Live-Benachrichtigungen mit den von Watchdog kontrollierten Icons." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.OpenLog)), "Log öffnen" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.OpenLog)),
                    "Öffnet </Logs/CityWatchdog.log>, falls vorhanden.\n" +
                    "Fehlt die Logdatei, wird der Logs-Ordner geöffnet." },
            };

            return entries;
        }

        public void Unload()
        {
        }
    }
}
