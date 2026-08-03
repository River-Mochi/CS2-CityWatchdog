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

    public sealed class LocaleDE : IDictionarySource
    {
        private readonly CwdSettings m_Settings;

        public LocaleDE(CwdSettings setting)
        {
            m_Settings = setting;
        }

        public IEnumerable<KeyValuePair<string, string>> ReadEntries(
            IList<IDictionaryEntryError> errors,
            Dictionary<string, int> indexCounts)
        {
            string title = Mod.ModName + " (Stadtwächter)";

            Dictionary<string, string> entries = new()
            {
                // --- Mod title ---
                { m_Settings.GetSettingsLocaleID(), title },

                // --- Tabs ---
                { m_Settings.GetOptionTabLocaleID(CwdSettings.kActions), "Aktionen" },
                { m_Settings.GetOptionTabLocaleID(CwdSettings.kMiniHudTab), "Mini-HUD" },
                { m_Settings.GetOptionTabLocaleID(CwdSettings.kMoneyTab), "Stadtstart" },
                { m_Settings.GetOptionTabLocaleID(CwdSettings.kAbout), "Über" },

                // --- Groups, ordered by Options menu location ---
                { m_Settings.GetOptionGroupLocaleID(CwdSettings.kAboutUsage), "NUTZUNG" },
                { m_Settings.GetOptionGroupLocaleID(CwdSettings.kNotifications), "Benachrichtigungen" },
                { m_Settings.GetOptionGroupLocaleID(CwdSettings.kMoneyViewGroup), "Stadt-Infoanzeige" },
                { m_Settings.GetOptionGroupLocaleID(CwdSettings.kMiniHudGroup), "Mini-HUD-Warnungen" },
                { m_Settings.GetOptionGroupLocaleID(CwdSettings.kMilestone), "NEUE-STADT-START" },
                { m_Settings.GetOptionGroupLocaleID(CwdSettings.kMoney), "Geld" },
                { m_Settings.GetOptionGroupLocaleID(CwdSettings.kSaveConversion), "Unbegrenzt-Spielstand umwandeln" },
                { m_Settings.GetOptionGroupLocaleID(CwdSettings.kAboutInfo), "" },
                { m_Settings.GetOptionGroupLocaleID(CwdSettings.kAboutLinks), "" },
                { m_Settings.GetOptionGroupLocaleID(CwdSettings.kAboutDiagnostics), "DIAGNOSE" },

                // --------------------------------------------------------------------
                // Actions tab - Usage
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.ShowUsage)), "Anleitung anzeigen" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.ShowUsage)), "Zeigt oder versteckt die Anleitung unten." },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.UsageText)),
                    "A. Pfoten-Icon oben links klicken oder Shift+N drücken, um das Hauptpanel zu öffnen.\n" +
                    "<Anzeige-Schalter>\n" +
                    "1. Titelleisten-Icon: City-Watchdog-Tooltips ein-/ausblenden.\n" +
                    "\n" +
                    "2. **[i]**: <ALLE> Spiel-Hover-Tooltips aus-/einblenden: Gebäude, Bürger, Tools, untere Leiste.\n" +
                    "3. Straßen-Button: Straßennamen aus-/einblenden. Tastenkürzel: \\.\n" +
                    "4. Bezirks-Button: Bezirksnamen aus-/einblenden.\n" +
                    "5. Straßenpfeil-Button: Einbahnstraßenpfeile an/aus (blendet auch Straßennamen aus).\n" +
                    "\n" +
                    "<Warnmeldungen>\n" +
                    "1. Sortierbutton wechselt A→Z, Z→A, Nur aktive Liste.\n" +
                    "2. <[0/63]> = Icons AN/Gesamt. Klick: alle Zeilen auf-/zuklappen.\n" +
                    "3a. [Icons anzeigen] schaltet alle Problem-Warnicons sofort aus/an.\n" +
                    "3b. Voreinstellungen [1 | 2]: klicken zum Laden; 1 Sekunde halten, um die aktuellen Kontrollkästchen zu speichern.\n" +
                    "3c. Ein ausgeblendetes Icon behebt das Stadtproblem nicht.\n" +
                    "\n" +
                    "<Hilfen>\n" +
                    "1. Geld hinzufügen/abziehen: Standardtasten <[ oder ]> für <Geldbetrag per Tastenkürzel>.\n" +
                    "2. Automatisches Geld fügt Geld hinzu, wenn die Stadt unter dein Limit fällt.\n" +
                    "3. Unbegrenzt-Geld-Spielstand umwandeln gilt nur für solche Städte und ist <nicht umkehrbar>.\n" +
                    "\n" +
                    "<Tooltips unten>\n" +
                    "Geldansicht ergänzt beim Hover über Geld oder Bevölkerung Extra-Details wie Trends.\n" +
                    "\n" +
                    "<Eigener Meilenstein>\n" +
                    "Stadtstart legt Startgeld oder Meilensteine vor dem Laden/Starten einer Stadt fest."
                },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.UsageText)), "" },

                // --------------------------------------------------------------------
                // Actions tab - Notifications
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.ToggleNotificationsKeyboardBinding)), "Warn-Icons umschalten" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.ToggleNotificationsKeyboardBinding)),
                    "<Tastenkürzel> wie der <[ICONS ANZEIGEN]>-Button im Spiel.\n" +
                    "Zeigt oder versteckt sofort alle Problem-Warnicons."
                },
                { m_Settings.GetBindingKeyLocaleID(CwdSettings.ToggleNotificationsAction), "Problem-Warnicons sofort zeigen/verstecken" },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.ToggleNotificationPanelKeyboardBinding)), "Warn-Panel öffnen/schließen" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.ToggleNotificationPanelKeyboardBinding)),
                    "<Tastenkürzel> zum Öffnen/Schließen des\n" +
                    "<Warn-Panels> in der Stadt.\n" +
                    "Wie ein Klick auf das Icon oben links."
                },
                { m_Settings.GetBindingKeyLocaleID(CwdSettings.ToggleNotificationPanelAction), "Warn-Panel öffnen/schließen" },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.PanelButtonsOnlyStart)), "Start nur mit Buttons" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.PanelButtonsOnlyStart)),
                    "Wenn aktiv [ ✓ ], öffnet City Watchdog zuerst die kleine Nur-Buttons-Ansicht.\n" +
                    "Titelleistenpfeil oder Zeilenzähler öffnet das volle Panel."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.ToggleRoadNamesKeyboardBinding)), "Straßennamen aus/ein" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.ToggleRoadNamesKeyboardBinding)),
                    "<Tastenkürzel> blendet die originalen Straßennamen sofort aus/ein.\n" +
                    "Wie das Straßennamen-Icon im City-Watchdog-Panel."
                },
                { m_Settings.GetBindingKeyLocaleID(CwdSettings.ToggleRoadNamesAction), "Straßennamen aus/ein" },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.ToggleAllTooltipsKeyboardBinding)), "Alle Hover-Tooltips deaktivieren" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.ToggleAllTooltipsKeyboardBinding)),
                    "<Tastenkürzel> blendet ALLE Spiel-Hover-Tooltips aus/ein — Gebäude, Bürger, Tools und untere Icons.\n" +
                    "<City-Watchdog-Geld/Bevölkerungs-Popups bleiben an>; sie gehören zu Geldansicht.\n" +
                    "Wie das [i]-Icon im City-Watchdog-Panel."
                },
                { m_Settings.GetBindingKeyLocaleID(CwdSettings.ToggleAllTooltipsAction), "Alle Spiel-Hover-Tooltips aus/ein" },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.InterfaceScaling)), "Größere Spieloberfläche" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.InterfaceScaling)),
                    "Wenn aktiv [ ✓ ], wird die <gesamte Spieloberfläche> größer — Spiel- und Mod-Panels.\n" +
                    "Nutzt die Spieloption <Interface-Skalierung> ohne den Startparameter <--developerMode>.\n" +
                    "Dieses [x]-Kontrollkästchen ist mit dem Skalierungsbutton in der City-Watchdog-Titelleiste synchronisiert.\n" +
                    "Nur für Textgröße: Optionen > Oberfläche > <Textskalierung>.\n" +
                    "Bleibt aktiv, bis du sie ausschaltest, auch wenn City Watchdog entfernt wird.\n" +
                    "- Vor dem Deinstallieren ausschalten, um die normale Größe wiederherzustellen.\n" +
                    "- Oder einmal mit <--developerMode> starten und Optionen > Oberfläche > Interface-Skalierung (dev) ausschalten."
                },


                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.MainPanelOpacity)), "Deckkraft des Hauptpanels" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.MainPanelOpacity)),
                    "Passt die Hintergrundtransparenz des Hauptbenachrichtigungsfensters an.\n" +
                    "Niedrigere Werte sind transparenter. Höhere Werte sind dunkler und deckender."
                },

                // --------------------------------------------------------------------
                // Actions tab - In-City Info Viewer
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.MoneyView)), "Geldtrends + Bevölkerungs-Tooltips" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.MoneyView)),
                    "<Empfohlen>\n" +
                    "Untere Leiste: zeigt Trends bei <Geld- und Bevölkerungspfeilen>.\n" +
                    "Leichtes Hover-Feature <nur Anzeige>;\n" +
                    "spart Zeit und kann besser sein als das Info-Panel des Spiels."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.MoneyViewMode)), "Geldansicht-Frequenz" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.MoneyViewMode)),
                    "Wähle Stunden- oder Monatswerte unten in der Leiste.\n" +
                    "Monat nutzt Einnahmen minus Ausgaben und eine 24-h-Bevölkerungsprognose."
                },
                { m_Settings.GetOptionLocaleID("MoneyViewModeHourly"), "Stündlich (/h)" },
                { m_Settings.GetOptionLocaleID("MoneyViewModeMonthly"), "Monatlich (/mo)" },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.MoneyTooltipMode)), "Geld-Tooltip-Stil" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.MoneyTooltipMode)),
                    "Wähle, wie viele Details der Geld-Tooltip zeigt.\n" +
                    "Kompakt = Standard bei Erstinstallation.\n" +
                    "<Mini> zeigt nur 2 Netto-Werte für /mo und /h.\n" +
                    "<Kompakt> kürzt große Werte (15.21M statt 15,212,318).\n" +
                    "<Volle Daten> zeigt lange Werte und Summen."
                },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeMini"), "Mini" },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeCompact"), "Kompakt" },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeFullData"), "Volle Daten" },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.MoneyTooltipFontScale)), "Geld-Schriftgröße" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.MoneyTooltipFontScale)),
                    "Ändert die <Schriftgröße> der Geldansicht-Zahlen.\n" +
                    "Spielstandard = 100%\n" +
                    "<Mod-Standard = 120%>\n" +
                    "Über Geld unten im Bildschirm fahren.\n" +
                    "Für Spieler, denen kleine Tooltips schwer lesbar sind."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.PopulationTooltipFontScale)), "Bevölkerungs-Schriftgröße" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.PopulationTooltipFontScale)),
                    "Ändert die <Schriftgröße> der Bevölkerungszahlen.\n" +
                    "Spielstandard = 100%\n" +
                    "<Mod-Standard = 120%>\n" +
                    "Über Bevölkerung unten im Bildschirm fahren."
                },

                // --------------------------------------------------------------------
                // Mini-HUD tab - Mini HUD Notifications
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.MiniHudEnabled)), "Mini HUD" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.MiniHudEnabled)),
                    "Zeigt ein kleines Stadt-HUD mit wichtigen Warnzählern.\n" +
                    "Schnelle Warnleiste ohne das volle Panel.\n" +
                    "Icon anklicken: springt zu einem passenden Problem.\n" +
                    "Weiterklicken rotiert durch Treffer und zurück zum ersten."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.ApplyMiniHudRecommendedPreset)), "Klick: Schnellstart" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.ApplyMiniHudRecommendedPreset)),
                    "Wendet einen <Schnellstart> für das Mini HUD an:\n" +
                    "Enthält eine **Startauswahl blauer Sterne**.\n" +
                    "Im Favoritenmodus zeigt das Mini HUD die 5 oder 10 höchsten aktuellen Zähler aus deiner **Blaue-Sterne-Liste**.\n" +
                    "**Blaue Sterne** im City-Watchdog-Panel hinzufügen/entfernen.\n" +
                    "Setzt: Favoriten, 5 Icons, horizontal, verschiebbar, 100 %, dunkles Panel und blendet Null-Zähler aus.\n" +
                    "Schnellstart kann jederzeit erneut angewendet werden."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.MiniHudMode)), "Mini-Anzeige-Modus" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.MiniHudMode)),
                    "Wähle, welche Warnzeilen die Mini-Anzeige nutzt.\n" +
                    "**Aktivste Warnungen** zeigt die höchsten aktuellen Zähler.\n" +
                    "**Favoriten** nutzt alle Zeilen mit **blauem Stern** im Hauptpanel von City Watchdog.\n" +
                    "Du kannst beliebig viele Favoriten wählen,\n" +
                    "aber die Mini-Anzeige zeigt nur die 5 oder 10 höchsten Zähler aus dieser **Blaue-Sterne-Liste**."
                },
                { m_Settings.GetOptionLocaleID("MiniHudModeTopActive"), "Aktivste Warnungen" },
                { m_Settings.GetOptionLocaleID("MiniHudModeFavorites"), "Favoriten" },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.MiniHudItemCount)), "Icon-Anzahl" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.MiniHudItemCount)), "Wähle, wie viele Warn-Icons das Mini HUD zeigt." },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.MiniHudScale)), "Icon-Größe" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.MiniHudScale)),
                    "Skaliert Mini-HUD-Icons und Zahlen.\n" +
                    "90% = kompakt. 100% = Standard. Bis 130% für bessere Sicht."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.MiniHudOrientation)), "Ausrichtung" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.MiniHudOrientation)), "Wähle Reihe oder Spalte." },
                { m_Settings.GetOptionLocaleID("MiniHudOrientationHorizontal"), "Horizontal" },
                { m_Settings.GetOptionLocaleID("MiniHudOrientationVertical"), "Vertikal" },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.MiniHudPlacement)), "HUD-Position" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.MiniHudPlacement)),
                    "Wähle, wo das Mini HUD erscheint.\n" +
                    "Verschiebbar erlaubt das Bewegen in der Spieloberfläche."
                },
                { m_Settings.GetOptionLocaleID("MiniHudPlacementTopCenter"), "Oben mittig" },
                { m_Settings.GetOptionLocaleID("MiniHudPlacementTopRight"), "Oben rechts" },
                { m_Settings.GetOptionLocaleID("MiniHudPlacementDraggable"), "Verschiebbar" },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.MiniHudPanelStyle)), "Dunkel- oder Glasstil" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.MiniHudPanelStyle)),
                    "Wähle den Mini-HUD-Hintergrund.\n" +
                    "Glas geht von klar zu weißlich; es wird nicht dunkler.\n" +
                    "Nutze Dunkel für ein dunkleres Spiel-HUD."
                },
                { m_Settings.GetOptionLocaleID("MiniHudPanelStyleDark"), "Dunkles Panel" },
                { m_Settings.GetOptionLocaleID("MiniHudPanelStyleGlass"), "Glas-Panel" },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.MiniHudPanelOpacity)), "Hintergrund-Deckkraft" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.MiniHudPanelOpacity)),
                    "Ändert die Transparenz des Mini-HUD-Hintergrunds.\n" +
                    "Niedriger = transparenter. Höher = solider.\n" +
                    "Glas wird weißlicher. Dunkel wird dunkler/solider."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.MiniHudHideZero)), "0-Warnungen verstecken" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.MiniHudHideZero)), "Wenn aktiv [ ✓ ], versteckt Mini HUD Zeilen mit Zähler 0." },

                // --------------------------------------------------------------------
                // City Start tab - New City Start Settings
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.InitialMoney)), "Startgeld" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.InitialMoney)),
                    "Setzt das Guthaben für die nächste geladene Stadt mit <begrenztem Geld> — neu oder bestehend.\n" +
                    "Nach einmaliger Anwendung wird diese Einstellung auf Spielstandard zurückgesetzt.\n" +
                    "Ausgegraut, sobald eine Stadt geladen ist.\n" +
                    "Vor dem Laden oder Starten setzen. Danach bei Bedarf <Geldbetrag per Tastenkürzel> verwenden."
                },

                { m_Settings.GetOptionLocaleID("GameDefault"), "Spielstandard" },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.CustomMilestone)), "Meilenstein-Wähler" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.CustomMilestone)),
                    "Vor dem Laden/Starten aktivieren, um einen Meilenstein beim Laden freizuschalten.\n" +
                    "- Kann in einer geladenen Stadt nicht EIN, aber wieder AUS geschaltet werden.\n" +
                    "- Vergessen? Spiel neu starten und vor dem Betreten wählen.\n" +
                    "- Der Mod kann gespeicherte Meilensteine nicht rückgängig machen; älteren Spielstand nutzen."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.MilestoneLevel)), "Meilenstein" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.MilestoneLevel)),
                    "Wähle den Meilenstein fürs nächste Laden.\n" +
                    "Nur <außerhalb einer geladenen Stadt> und mit [Meilenstein-Wähler] aktiv [ ✓ ].\n" +
                    "Ist die Stadt schon dort oder weiter, passiert nichts.\n" +
                    "Änderung nur, wenn der gewählte Meilenstein höher ist."
                },

                // --------------------------------------------------------------------
                // City Start tab - Money
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.ManualMoneyAmount)), "Geldbetrag per Tastenkürzel" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.ManualMoneyAmount)),
                    "Dieser Betrag gilt für Geld hinzufügen/abziehen per Tastenkürzel.\n" +
                    "<Mod-Standard = 40.000>\n" +
                    "Tut nichts ohne Tastenkürzel in der Stadt.\n" +
                    "Für Automatik nutze Automatisches Geld."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.AddMoneyKeyboardBinding)), "Geld hinzufügen" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.AddMoneyKeyboardBinding)), "Tastenkürzel für <Geld hinzufügen> in der Stadt." },
                { m_Settings.GetBindingKeyLocaleID(CwdSettings.AddMoneyAction), "Geld hinzufügen" },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.SubtractMoneyKeyboardBinding)), "Geld abziehen" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.SubtractMoneyKeyboardBinding)), "Tastenkürzel für <Geld abziehen> in der Stadt." },
                { m_Settings.GetBindingKeyLocaleID(CwdSettings.SubtractMoneyAction), "Geld abziehen" },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.AutomaticAddMoney)), "Automatisches Geld" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.AutomaticAddMoney)),
                    "Wenn aktiv [ ✓ ], prüft City Watchdog den Stadtkontostand.\n" +
                    "- Liegt er <unter dem Limit>, wird genug Geld hinzugefügt, um das Limit zu erreichen.\n" +
                    "- Mindestens wird immer der gewählte automatische Geldbetrag hinzugefügt.\n" +
                    "- Für gelegentlichen Bedarf werden die manuellen Tastenkürzel (<[> oder <]>) empfohlen."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.AutomaticAddMoneyThreshold)), "Automatisches Geld-Limit" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.AutomaticAddMoneyThreshold)),
                    "Wenn Automatisches Geld aktiv ist und der Stadtkontostand unter diesen Wert fällt,\n" +
                    "wird Geld hinzugefügt, bis mindestens dieses Limit erreicht ist."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.AutomaticAddMoneyAmount)), "Automatischer Betrag" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.AutomaticAddMoneyAmount)),
                    "Mindestbetrag, der bei jeder automatischen Auslösung hinzugefügt wird.\n" +
                    "Ist mehr nötig, um das Limit zu erreichen, fügt City Watchdog den größeren Betrag hinzu."
                },

                // --------------------------------------------------------------------
                // City Start tab - Save Conversion
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.ConfirmUnlimitedMoneySaveConversion)), "Unbegrenzt-Geld-Konverter" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.ConfirmUnlimitedMoneySaveConversion)),
                    "<Zuerst eine Sicherungskopie der Stadt anlegen>.\n" +
                    "Wandelt eine Stadt mit Unbegrenzt Geld in eine normale Stadt um.\n" +
                    "Aktivieren schaltet <[Unbegrenzt-Geld-Spielstand umwandeln]> frei, wenn die geladene Stadt <Unbegrenzt Geld> ist.\n" +
                    "City Watchdog kann das nicht rückgängig machen.\n" +
                    "Normale Städte brauchen das nicht."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.ConvertUnlimitedMoneySave)), "Unbegrenzt-Geld-Stadt normal machen" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.ConvertUnlimitedMoneySave)),
                    "Für Städte mit <Unbegrenzt Geld>.\n" +
                    "Wandelt den geladenen Spielstand zu normalem begrenztem Geld um.\n" +
                    "Button ist <deaktiviert/grau>, außer die Stadt ist <Unbegrenzt Geld>\n" +
                    "und <Unbegrenzt-Geld-Konverter> ist AN [ ✓ ].\n" +
                    "Sicherungskopie anlegen und auf eigenes Risiko verwenden; City Watchdog macht es nicht rückgängig."
                },

                { m_Settings.GetOptionWarningLocaleID(nameof(CwdSettings.ConvertUnlimitedMoneySave)),
                    "Diese Stadt von Unbegrenzt Geld zu normalem begrenztem Geld umwandeln?\n" +
                    "ZUERST eine Sicherungskopie speichern; City Watchdog kann das nicht rückgängig machen.\n" +
                    "Sicher?"
                },

                // --------------------------------------------------------------------
                // About tab
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.NameText)), "Mod-Name" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.NameText)), "Anzeigename dieses Mods." },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.VersionText)), "Version" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.VersionText)), "Aktuelle Mod-Version." },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.OpenParadox)), "Paradox Mods" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.OpenParadox)), "Öffnet die Paradox-Mods-Seite des Autors." },

                // --------------------------------------------------------------------
                // About tab - Diagnostics
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.WriteNotificationAuditLog)), "Diagnosebericht ins Protokoll" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.WriteNotificationAuditLog)),
                    "<Für normales Spielen nicht nötig.>\n" +
                    "Für Tester und Prüfungen nach Spielupdates: schreibt einen Bericht in <Logs/CityWatchdog.log>\n" +
                    "und vergleicht aktuelle Spielwarnungen mit den von Watchdog gesteuerten Icons."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.OpenLog)), "Protokoll öffnen" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.OpenLog)),
                    "Öffnet </Logs/CityWatchdog.log>, falls vorhanden.\n" +
                    "Sonst wird der Logs-Ordner geöffnet."
                },
            };

            return entries;
        }

        public void Unload()
        {
        }
    }
}
