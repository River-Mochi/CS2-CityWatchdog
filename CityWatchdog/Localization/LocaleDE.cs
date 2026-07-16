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
                { m_Settings.GetSettingsLocaleID(), title },
                { m_Settings.GetOptionTabLocaleID(Setting.Actions), "Aktionen" },
                { m_Settings.GetOptionTabLocaleID(Setting.MiniHudTab), "Mini-HUD" },
                { m_Settings.GetOptionTabLocaleID(Setting.MoneyTab), "Geld-Meilensteine" },
                { m_Settings.GetOptionTabLocaleID(Setting.About), "Über" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutUsage), "NUTZUNG" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Notifications), "Benachrichtigungen" },
                { m_Settings.GetOptionGroupLocaleID(Setting.MoneyViewGroup), "Stadt-Infoanzeige" },
                { m_Settings.GetOptionGroupLocaleID(Setting.MiniHudGroup), "Mini-HUD-Warnungen" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Milestone), "NEUE-STADT-START" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Money), "Geld" },
                { m_Settings.GetOptionGroupLocaleID(Setting.SaveConversion), "Unbegrenzt-Save umwandeln" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutInfo), "" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutLinks), "" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutDiagnostics), "DIAGNOSE" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ShowUsage)), "Anleitung anzeigen" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ShowUsage)), "Zeigt oder versteckt die Anleitung unten." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.UsageText)),
                    "A. Pfoten-Icon oben links klicken oder Shift+N drücken, um das Hauptpanel zu öffnen.\n" +
                    "<Anzeige-Schalter>\n" +
                    "1. Titelleisten-Icon: City-Watchdog-Tooltips ein-/ausblenden.\n" +
                    "\n" +
                    "2. **[i]**: <ALLE> Spiel-Hover-Tooltips aus-/einblenden: Gebäude, Bürger, Tools, untere Leiste.\n" +
                    "3. Straßen-Button: Straßennamen aus-/einblenden. Hotkey: \\.\n" +
                    "4. Bezirks-Button: Bezirksnamen aus-/einblenden.\n" +
                    "5. Straßenpfeil-Button: Einbahnstraßenpfeile an/aus (blendet auch Straßennamen aus).\n" +
                    "\n" +
                    "<Warnmeldungen>\n" +
                    "1. Sortierbutton wechselt A→Z, Z→A, Nur aktive Liste.\n" +
                    "2. <[0/62]> = Icons AN/Gesamt. Klick: alle Zeilen auf-/zuklappen.\n" +
                    "3a. [Alle umschalten] schaltet sofort alle Warn-Icons aus/an.\n" +
                    "3b. Blendet nur Icons aus; behebt nicht das Stadtproblem.\n" +
                    "\n" +
                    "<Geldhilfen>\n" +
                    "1. Geld hinzufügen/abziehen: Standardtasten <[ oder ]> für <Geld-Hotkey-Betrag>.\n" +
                    "2. Automatisches Geld fügt Geld hinzu, wenn die Stadt unter dein Limit fällt.\n" +
                    "3. Unbegrenzt-Geld-Save umwandeln gilt nur für solche Städte und ist <nicht umkehrbar>.\n" +
                    "\n" +
                    "<Tooltips unten>\n" +
                    "Geldansicht ergänzt beim Hover über Geld oder Bevölkerung Extra-Details wie Trends.\n" +
                    "\n" +
                    "<Eigener Meilenstein>\n" +
                    "Money-Meilensteine > NEUE-STADT-START setzt Startgeld oder Meilensteine vor dem Laden/Starten." },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.UsageText)), "" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleNotificationsKeyboardBinding)), "Warn-Icons umschalten" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleNotificationsKeyboardBinding)),
                    "<Hotkey> wie der <[Alle umschalten]>-Button im Spiel.\n" +
                    "Zeigt oder versteckt alle gelisteten Stadt-Warnicons sofort." },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleNotificationsAction), "Alle Warn-Icons sofort zeigen/verstecken" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleNotificationPanelKeyboardBinding)), "Warn-Panel öffnen/schließen" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleNotificationPanelKeyboardBinding)),
                    "<Hotkey> zum Öffnen/Schließen des\n" +
                    "<Warn-Panels> in der Stadt.\n" +
                    "Wie ein Klick auf das Icon oben links." },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleNotificationPanelAction), "Warn-Panel öffnen/schließen" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.PanelButtonsOnlyStart)), "Start nur mit Buttons" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.PanelButtonsOnlyStart)),
                    "Wenn aktiv [ ✓ ], öffnet City Watchdog zuerst die kleine Nur-Buttons-Ansicht.\n" +
                    "Titelleistenpfeil oder Zeilenzähler öffnet das volle Panel." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleRoadNamesKeyboardBinding)), "Straßennamen aus/ein" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleRoadNamesKeyboardBinding)),
                    "<Hotkey> blendet die originalen Straßennamen sofort aus/ein.\n" +
                    "Wie das Straßennamen-Icon im City-Watchdog-Panel." },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleRoadNamesAction), "Straßennamen aus/ein" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleAllTooltipsKeyboardBinding)), "Alle Hover-Tooltips deaktivieren" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleAllTooltipsKeyboardBinding)),
                    "<Hotkey> blendet ALLE Spiel-Hover-Tooltips aus/ein — Gebäude, Bürger, Tools und untere Icons.\n" +
                    "<City-Watchdog-Geld/Bevölkerungs-Popups bleiben an>; sie gehören zu Geldansicht.\n" +
                    "Wie das [i]-Icon im City-Watchdog-Panel." },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleAllTooltipsAction), "Alle Spiel-Hover-Tooltips aus/ein" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyView)), "Geldtrends + Bevölkerungs-Tooltips" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyView)),
                    "<Empfohlen>\n" +
                    "Untere Leiste: zeigt Trends bei <Geld- und Bevölkerungspfeilen>.\n" +
                    "Leichtes Hover-Feature <nur Anzeige>;\n" +
                    "spart Zeit und kann besser sein als das Info-Panel des Spiels." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyViewMode)), "Geldansicht-Frequenz" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyViewMode)),
                    "Wähle Stunden- oder Monatswerte unten in der Leiste.\n" +
                    "Monat nutzt Einnahmen minus Ausgaben und eine 24-h-Bevölkerungsprognose." },
                { m_Settings.GetOptionLocaleID("MoneyViewModeHourly"), "Stündlich (/h)" },
                { m_Settings.GetOptionLocaleID("MoneyViewModeMonthly"), "Monatlich (/mo)" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyTooltipMode)), "Geld-Tooltip-Stil" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyTooltipMode)),
                    "Wähle, wie viele Details der Geld-Tooltip zeigt.\n" +
                    "Kompakt = Standard bei Erstinstallation.\n" +
                    "<Mini> zeigt nur 2 Netto-Werte für /mo und /h.\n" +
                    "<Kompakt> kürzt große Werte (15.21M statt 15,212,318).\n" +
                    "<Volle Daten> zeigt lange Werte und Summen." },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeMini"), "Mini" },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeCompact"), "Kompakt" },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeFullData"), "Volle Daten" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyTooltipFontScale)), "Geld-Schriftgröße" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyTooltipFontScale)),
                    "Ändert die <Schriftgröße> der Money-View-Zahlen.\n" +
                    "Spielstandard = 100%\n" +
                    "<Mod-Standard = 120%>\n" +
                    "Über Geld unten im Bildschirm fahren.\n" +
                    "Für Spieler, denen kleine Tooltips schwer lesbar sind." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.PopulationTooltipFontScale)), "Bevölkerungs-Schriftgröße" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.PopulationTooltipFontScale)),
                    "Ändert die <Schriftgröße> der Bevölkerungszahlen.\n" +
                    "Spielstandard = 100%\n" +
                    "<Mod-Standard = 120%>\n" +
                    "Über Bevölkerung unten im Bildschirm fahren." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudEnabled)), "Mini HUD" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudEnabled)),
                    "Zeigt ein kleines Stadt-HUD mit wichtigen Warnzählern.\n" +
                    "Schnelle Warnleiste ohne das volle Panel.\n" +
                    "Icon anklicken: springt zu einem passenden Problem.\n" +
                    "Weiterklicken rotiert durch Treffer und zurück zum ersten." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ApplyMiniHudRecommendedPreset)), "Klick: Schnellstart" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ApplyMiniHudRecommendedPreset)),
                    "Wendet einen <Schnellstart> für die Mini-Anzeige an:\n" +
                    "Enthält ein **Starter-Set mit blauen Sternen**.\n" +
                    "Eine Warnung mit **blauem Stern** kann in der Mini-Anzeige erscheinen, wenn sie nach Gesamtzahl in den Top 5 oder 10 liegt.\n" +
                    "**Blaue Sterne** im geöffneten Watchdog-Panel hinzufügen/entfernen.\n" +
                    "Set enthält: Favoriten, 5 Icons, vertikal, verschiebbar, 100 % Größe, dunkles Panel, Icons mit 0 werden versteckt."
                  },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudMode)), "Mini-HUD-Modus" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudMode)),
                    "Wähle, welche Warnzeilen das Mini HUD nutzt.\n" +
                    "**Top aktiv** zeigt die höchsten aktuellen Zähler.\n" +
                    "**Favoriten** nutzt alle Zeilen mit **Blue Star** im City-Watchdog-Hauptpanel.\n" +
                    "Du kannst beliebig viele Favoriten wählen,\n" +
                    "aber Mini HUD zeigt nur Top 5 oder Top 10 aus dieser **Blue-Star**-Liste."
                  },
                { m_Settings.GetOptionLocaleID("MiniHudModeTopActive"), "Top aktive Warnungen" },
                { m_Settings.GetOptionLocaleID("MiniHudModeFavorites"), "Favoriten" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudItemCount)), "Icon-Anzahl" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudItemCount)), "Wähle, wie viele Warn-Icons das Mini HUD zeigt." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudScale)), "Icon-Größe" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudScale)),
                    "Skaliert Mini-HUD-Icons und Zahlen.\n" +
                    "90% = kompakt. 100% = Standard. Bis 130% für bessere Sicht." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudOrientation)), "Ausrichtung" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudOrientation)), "Wähle Reihe oder Spalte." },
                { m_Settings.GetOptionLocaleID("MiniHudOrientationHorizontal"), "Horizontal" },
                { m_Settings.GetOptionLocaleID("MiniHudOrientationVertical"), "Vertikal" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudPlacement)), "HUD-Position" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudPlacement)),
                    "Wähle, wo das Mini HUD erscheint.\n" +
                    "Verschiebbar lässt es in der Stadt-UI bewegen." },
                { m_Settings.GetOptionLocaleID("MiniHudPlacementTopCenter"), "Oben mittig" },
                { m_Settings.GetOptionLocaleID("MiniHudPlacementTopRight"), "Oben rechts" },
                { m_Settings.GetOptionLocaleID("MiniHudPlacementDraggable"), "Verschiebbar" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudPanelStyle)), "Dunkel- oder Glasstil" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudPanelStyle)),
                    "Wähle den Mini-HUD-Hintergrund.\n" +
                    "Glas geht von klar zu weißlich; es wird nicht dunkler.\n" +
                    "Nutze Dunkel für ein dunkleres Spiel-HUD." },
                { m_Settings.GetOptionLocaleID("MiniHudPanelStyleDark"), "Dunkles Panel" },
                { m_Settings.GetOptionLocaleID("MiniHudPanelStyleGlass"), "Glas-Panel" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudPanelOpacity)), "Hintergrund-Deckkraft" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudPanelOpacity)),
                    "Ändert die Transparenz des Mini-HUD-Hintergrunds.\n" +
                    "Niedriger = transparenter. Höher = solider.\n" +
                    "Glas wird weißlicher. Dunkel wird dunkler/solider." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudHideZero)), "0-Warnungen verstecken" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudHideZero)), "Wenn aktiv [ ✓ ], versteckt Mini HUD Zeilen mit Zähler 0." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.InitialMoney)), "Startgeld" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.InitialMoney)),
                    "Setzt das Startgeld für eine neue <begrenztes Geld>-Stadt oder die erste geladene Stadt,\n" +
                    "danach zurück auf Spielstandard.\n" +
                    "Ausgegraut, wenn eine Stadt geladen ist.\n" +
                    "Vor dem Laden/Starten setzen. Danach <Geld-Hotkey-Betrag> oder <Automatisches Geld> nutzen." },
                { m_Settings.GetOptionLocaleID("GameDefault"), "Spielstandard" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.CustomMilestone)), "Meilenstein-Wähler" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.CustomMilestone)),
                    "Vor dem Laden/Starten aktivieren, um einen Meilenstein beim Laden freizuschalten.\n" +
                    "- Kann in einer geladenen Stadt nicht EIN, aber wieder AUS geschaltet werden.\n" +
                    "- Vergessen? Spiel neu starten und vor dem Betreten wählen.\n" +
                    "- Der Mod kann gespeicherte Meilensteine nicht rückgängig machen; älteren Save nutzen." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MilestoneLevel)), "Meilenstein" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MilestoneLevel)),
                    "Wähle den Meilenstein fürs nächste Laden.\n" +
                    "Nur <außerhalb einer geladenen Stadt> und mit [Meilenstein-Wähler] aktiv [ ✓ ].\n" +
                    "Ist die Stadt schon dort oder weiter, passiert nichts.\n" +
                    "Änderung nur, wenn der gewählte Meilenstein höher ist." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ManualMoneyAmount)), "Geld-Hotkey-Betrag" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ManualMoneyAmount)),
                    "Dieser Betrag gilt für Geld hinzufügen/abziehen per Hotkey.\n" +
                    "<Mod-Standard = 40.000>\n" +
                    "Tut nichts ohne Hotkey in der Stadt.\n" +
                    "Für Automatik nutze Automatisches Geld." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AddMoneyKeyboardBinding)), "Geld hinzufügen" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AddMoneyKeyboardBinding)), "Hotkey für <Geld hinzufügen> in der Stadt." },
                { m_Settings.GetBindingKeyLocaleID(Setting.AddMoneyAction), "Geld hinzufügen" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.SubtractMoneyKeyboardBinding)), "Geld abziehen" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.SubtractMoneyKeyboardBinding)), "Hotkey für <Geld abziehen> in der Stadt." },
                { m_Settings.GetBindingKeyLocaleID(Setting.SubtractMoneyAction), "Geld abziehen" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoney)), "Automatisches Geld" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoney)),
                    "Wenn aktiv [ ✓ ], prüft City Watchdog den Stadtkontostand.\n" +
                    "- Liegt er <unter dem Limit>,\n" +
                    "  wird der gewählte Betrag hinzugefügt.\n" +
                    "- Besser bei Bedarf manuell mit Hotkey (<[> oder <]>) nutzen\n" +
                    "  statt Automatik; die Option ist trotzdem da." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoneyThreshold)), "Automatisches Geld-Limit" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoneyThreshold)),
                    "Wenn aktiv und das Stadtgeld unter diesen Wert fällt,\n" +
                    "wird der gewählte Betrag hinzugefügt." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoneyAmount)), "Automatischer Betrag" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoneyAmount)),
                    "Betrag pro automatischer Auslösung.\n" +
                    "Wähle genug, um sicher über das Limit zu kommen." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ConfirmUnlimitedMoneySaveConversion)), "Unbegrenzt-Geld-Konverter" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ConfirmUnlimitedMoneySaveConversion)),
                    "<Zuerst Stadt-Backup machen>.\n" +
                    "Wandelt eine Stadt mit Unbegrenzt Geld in eine normale Stadt um.\n" +
                    "Aktivieren schaltet <[Unbegrenzt-Geld-Save umwandeln]> frei, wenn die geladene Stadt <Unbegrenzt Geld> ist.\n" +
                    "City Watchdog kann das nicht rückgängig machen.\n" +
                    "Normale Städte brauchen das nicht." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)), "Unbegrenzt-Geld-Stadt normal machen" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)),
                    "Für Städte mit <Unbegrenzt Geld>.\n" +
                    "Wandelt den geladenen Save zu normalem begrenztem Geld um.\n" +
                    "Button ist <deaktiviert/grau>, außer die Stadt ist <Unbegrenzt Geld>\n" +
                    "und <Unbegrenzt-Geld-Konverter> ist AN [ ✓ ].\n" +
                    "Backup machen, eigenes Risiko; City Watchdog macht es nicht rückgängig." },
                { m_Settings.GetOptionWarningLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)),
                    "Diese Stadt von Unbegrenzt Geld zu normalem begrenztem Geld umwandeln?\n" +
                    "ZUERST Backup speichern; City Watchdog kann das nicht rückgängig machen.\n" +
                    "Sicher?" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.NameText)), "Mod-Name" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.NameText)), "Anzeigename dieses Mods." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.VersionText)), "Version" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.VersionText)), "Aktuelle Mod-Version." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.OpenParadox)), "Paradox Mods" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.OpenParadox)), "Öffnet die Paradox-Mods-Seite des Autors." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.WriteNotificationAuditLog)), "Debug-Bericht ins Log" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.WriteNotificationAuditLog)),
                    "<Nicht fürs normale Spielen nötig.>\n" +
                    "Für Tester und Spielpatch-Checks: schreibt einen Bericht in <Logs/CityWatchdog.log>\n" +
                    "und vergleicht Live-Spielwarnungen mit den Watchdog-Icons." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.OpenLog)), "Log öffnen" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.OpenLog)),
                    "Öffnet </Logs/CityWatchdog.log>, falls vorhanden.\n" +
                    "Sonst wird der Logs-Ordner geöffnet." },
            };

            return entries;
        }

        public void Unload()
        {
        }
    }
}
