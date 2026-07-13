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
                { m_Settings.GetOptionTabLocaleID(Setting.MoneyTab), "Geld & Meilensteine" },
                { m_Settings.GetOptionTabLocaleID(Setting.About), "Über" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutUsage), "NUTZUNG" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Notifications), "Benachrichtigungen" },
                { m_Settings.GetOptionGroupLocaleID(Setting.MoneyViewGroup), "Infoanzeige in der Stadt" },
                { m_Settings.GetOptionGroupLocaleID(Setting.MiniHudGroup), "Mini-HUD-Benachrichtigungen" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Milestone), "START FÜR NEUE STADT" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Money), "Geld" },
                { m_Settings.GetOptionGroupLocaleID(Setting.SaveConversion), "Unbegrenzt-Speicherstand umwandeln" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutInfo), "" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutLinks), "" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutDiagnostics), "DIAGNOSE" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ShowUsage)), "Anleitung anzeigen" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ShowUsage)), "Zeigt oder verbirgt die Anleitung unten." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.UsageText)), "<Anzeige-Schalter>\n" +
                    "1. [i]-Button: ALLE Spiel-Hover-Infos ein-/ausblenden – Gebäude, Cims, Werkzeuge, untere Menü-Icons.\n" +
                    "2. Straßennamen-Button: Straßennamen ein-/ausblenden. Tastenkürzel: \\.\n" +
                    "3. Bezirksnamen-Button: Bezirksnamen ein-/ausblenden, ohne Grenzen zu ändern.\n" +
                    "4. Straßenpfeil-Button: Einbahnstraßenpfeile erzwingen ein/aus (blendet auch Straßennamen aus).\n" +
                    "5. CWD-Titelleisten-Icon: City-Watchdog-Paneltipps ein-/ausblenden.\n" +
                    "\n" +
                    "<Benachrichtigungen>\n" +
                    "1. City-Watchdog-Button oben links klicken oder Shift+N drücken, um das Panel zu öffnen.\n" +
                    "2. Sortierbutton für auf-/absteigend.\n" +
                    "3. Alles umschalten für schnelles Aus/Ein, oder Bereich öffnen und einzeln wählen.\n" +
                    "4. Blendet nur Icons aus; behebt nicht das Stadtproblem.\n" +
                    "\n" +
                    "<Geldhilfen>\n" +
                    "1. Geld hinzufügen/abziehen: <Geldbetrag pro Tastenkürzel> nutzt standardmäßig [ und ].\n" +
                    "2. Automatisches Geld fügt Geld hinzu, wenn die Stadt unter deine Grenze fällt.\n" +
                    "3. Unbegrenzt-Geld-Speicherstand umwandeln gilt nur für Städte mit unbegrenztem Geld und ist <nicht umkehrbar>.\n" +
                    "\n" +
                    "<Tooltips im unteren Menü>\n" +
                    "Die Geldanzeige ergänzt Geld- und Bevölkerungstrends sowie Hover-Details in der Toolbar.\n" +
                    "\n" +
                    "<Eigener Meilenstein>\n" +
                    "Startgeld und Meilenstein unter Geld & Meilensteine > START FÜR NEUE STADT setzen, bevor du eine Stadt lädst oder startest." },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.UsageText)), "" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleNotificationsKeyboardBinding)), "Benachrichtigungs-Icons umschalten" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleNotificationsKeyboardBinding)), "<Tastenkürzel> für dieselbe Aktion wie der <[Alles umschalten]>-Iconbutton im Spiel.\n" +
                    "Blendet alle gelisteten Stadtbenachrichtigungs-Icons sofort ein oder aus." },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleNotificationsAction), "Alle Benachrichtigungs-Icons sofort ein-/ausblenden" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleNotificationPanelKeyboardBinding)), "Benachrichtigungspanel öffnen/schließen" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleNotificationPanelKeyboardBinding)), "<Tastenkürzel> zum Öffnen oder Schließen des\n" +
                    "<Benachrichtigungspanels> in der Stadt.\n" +
                    "Funktioniert wie ein Klick auf das Icon oben links." },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleNotificationPanelAction), "Benachrichtigungspanel öffnen/schließen" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.PanelButtonsOnlyStart)), "Panel nur mit Buttons starten" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.PanelButtonsOnlyStart)), "Wenn aktiv [ ✓ ], startet City Watchdog über den Button oben links in der kleineren Nur-Buttons-Ansicht.\n" +
                    "Titelleistenpfeil oder Zeilenzähler öffnen das volle Panel." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleRoadNamesKeyboardBinding)), "Straßennamen aus-/einblenden" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleRoadNamesKeyboardBinding)), "<Tastenkürzel>, um die Straßennamen des Basisspiels sofort ein- oder auszublenden.\n" +
                    "Wie das Straßennamen-Icon in der City-Watchdog-Toolbar." },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleRoadNamesAction), "Straßennamen aus-/einblenden" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleAllTooltipsKeyboardBinding)), "Alle Mouseover-Infos deaktivieren" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleAllTooltipsKeyboardBinding)), "<Tastenkürzel>, um ALLE Hover-Infos des Spiels sofort ein- oder auszublenden — Gebäude, Cims, Werkzeuge und untere Menü-Icons.\n" +
                    "<City Watchdogs eigene Geld-/Bevölkerungs-Popups bleiben aktiv>; sie werden über die Geldanzeige oben gesteuert.\n" +
                    "Wie das [i]-Icon im City-Watchdog-Panel." },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleAllTooltipsAction), "Alle Spiel-Hover-Infos ein-/ausblenden" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyView)), "Geld- und Bevölkerungs-Tooltips anzeigen" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyView)), "<Empfohlen aktivieren>\n" +
                    "Unteres Spielmenü: zeigt Trendwerte bei den <Geld- und Bevölkerungspfeilen> der Toolbar.\n" +
                    "Leichte Hover-Funktion der Toolbar <nur Anzeige>;\n" +
                    "spart Zeit und kann schneller sein als das Infofenster des Spiels." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyViewMode)), "Frequenz der Geldanzeige" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyViewMode)), "Wähle, ob die Trendtexte unten stündliche oder monatliche Werte für Geld und Bevölkerung zeigen.\n" +
                    "Monatlich nutzt Budgeteinnahmen minus Ausgaben und eine 24-Stunden-Prognose für Bevölkerung." },
                { m_Settings.GetOptionLocaleID("MoneyViewModeHourly"), "Stündlich (/h)" },
                { m_Settings.GetOptionLocaleID("MoneyViewModeMonthly"), "Monatlich (/mo)" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyTooltipMode)), "Stil des Geld-Tooltips" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyTooltipMode)), "Wähle, wie viele Details im Geld-Tooltip angezeigt werden.\n" +
                    "Kompakt = Standard bei Erstinstallation.\n" +
                    "<Mini> zeigt nur 2 Nettowerte für /mo und /h.\n" +
                    "<Kompakt> kürzt große Werte (15.21M statt 15,212,318).\n" +
                    "<Vollständige Daten> zeigt lange Werte und Summen." },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeMini"), "Mini" },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeCompact"), "Kompakt" },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeFullData"), "Vollständige Daten" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyTooltipFontScale)), "Geld-Schriftgröße" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyTooltipFontScale)), "Passt die <Schriftgröße> der Zahlen im Geld-Tooltip an.\n" +
                    "Spielstandard = 100%\n" +
                    "<Mod-Standard = 120%>\n" +
                    "Mit der Maus über Geld unten fahren.\n" +
                    "Für Spieler, denen kleine Tooltips schwer lesbar sind." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.PopulationTooltipFontScale)), "Bevölkerungs-Schriftgröße" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.PopulationTooltipFontScale)), "Passt die <Schriftgröße> der Bevölkerungs-Tooltip-Zahlen an.\n" +
                    "Spielstandard = 100%\n" +
                    "<Mod-Standard = 120%>\n" +
                    "Mit der Maus über Bevölkerung unten fahren." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudEnabled)), "Mini-HUD" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudEnabled)), "Zeigt ein kleines Stadt-HUD mit den wichtigsten Benachrichtigungszählern.\n" +
                    "Nutze es als schnelle Warnleiste, ohne das volle City-Watchdog-Panel zu öffnen.\n" +
                    "Ein Klick auf ein Icon springt zu einer passenden Problemstelle.\n" +
                    "Weiterklicken rotiert durch passende Stellen und zurück zur ersten." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ApplyMiniHudRecommendedPreset)), "Schnellstart anwenden" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ApplyMiniHudRecommendedPreset)), "Wendet eine empfohlene Mini-HUD-Einstellung an:\n" +
                    "Favoriten, 5 Icons, horizontal, oben mittig, 100% Größe, dunkles Panel.\n" +
                    "Warnungen mit 0 bleiben sichtbar.\n" +
                    "**Blaue-Stern**-Favoriten kannst du jederzeit im erweiterten Watchdog-Panel ändern.\n" +
                    "Starter-Favoriten mit **Blauem Stern** sind in **[Empfohlen]** enthalten." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudMode)), "Mini-HUD-Modus" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudMode)), "Wähle, welche Benachrichtigungszeilen das Mini-HUD nutzt.\n" +
                    "**Top aktiv** zeigt die höchsten aktuellen Zähler.\n" +
                    "**Favoriten** enthält alle Zeilen mit **Blauem Stern** im Hauptpanel von City Watchdog.\n" +
                    "Du kannst beliebig viele Favoriten wählen,\n" +
                    "aber das Mini-HUD zeigt nur die Top 5 oder Top 10 aktuellen Zähler aus dieser **Blaue-Stern**-Favoritenliste." },
                { m_Settings.GetOptionLocaleID("MiniHudModeTopActive"), "Top aktive Warnungen" },
                { m_Settings.GetOptionLocaleID("MiniHudModeFavorites"), "Favoriten" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudItemCount)), "Icon-Anzahl" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudItemCount)), "Wähle, wie viele Benachrichtigungs-Icons das Mini-HUD gleichzeitig zeigen kann." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudScale)), "Icon-Größe" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudScale)), "Skaliert Mini-HUD-Icons und Zahlen.\n" +
                    "90% = kompakt. 100% = Standard. Bis 130% für bessere Sichtbarkeit." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudOrientation)), "Ausrichtung" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudOrientation)), "Wähle, ob Mini-HUD-Icons in einer Zeile oder Spalte angeordnet sind." },
                { m_Settings.GetOptionLocaleID("MiniHudOrientationHorizontal"), "Horizontal" },
                { m_Settings.GetOptionLocaleID("MiniHudOrientationVertical"), "Vertikal" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudPlacement)), "HUD-Position" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudPlacement)), "Wähle, wo das Mini-HUD erscheint.\n" +
                    "Verschiebbar lässt dich es in der Stadt-UI bewegen." },
                { m_Settings.GetOptionLocaleID("MiniHudPlacementTopCenter"), "Oben mittig" },
                { m_Settings.GetOptionLocaleID("MiniHudPlacementTopRight"), "Oben rechts" },
                { m_Settings.GetOptionLocaleID("MiniHudPlacementDraggable"), "Verschiebbar" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudPanelStyle)), "Dunkel oder Glas" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudPanelStyle)), "Wähle den Mini-HUD-Hintergrund.\n" +
                    "Glas reicht von klar bis wolkig weiß; es wird nicht dunkler.\n" +
                    "Nutze Dunkel für ein dunkleres Panel im Spielstil." },
                { m_Settings.GetOptionLocaleID("MiniHudPanelStyleDark"), "Dunkles Panel" },
                { m_Settings.GetOptionLocaleID("MiniHudPanelStyleGlass"), "Glas-Panel" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudPanelOpacity)), "Hintergrunddeckkraft" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudPanelOpacity)), "Passt die Transparenz des Mini-HUD-Hintergrunds an.\n" +
                    "Niedriger = transparenter. Höher = fester.\n" +
                    "Glas wird weißer/wolkiger. Dunkel wird fester/dunkler." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudHideZero)), "Null-Warnungen ausblenden" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudHideZero)), "Wenn aktiv [ ✓ ], blendet das Mini-HUD Benachrichtigungszeilen mit Zähler 0 aus." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.InitialMoney)), "Startgeld" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.InitialMoney)), "Setzt das Startguthaben für eine neue Stadt mit <begrenztem Geld> oder die erste geladene Stadt,\n" +
                    "danach zurück auf Spielstandard.\n" +
                    "Ausgegraut, wenn bereits eine Stadt geladen ist.\n" +
                    "Vor dem Starten/Laden setzen. Danach <Geldbetrag pro Tastenkürzel> oder <Automatisch Geld hinzufügen> nutzen." },
                { m_Settings.GetOptionLocaleID("GameDefault"), "Spielstandard" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.CustomMilestone)), "Meilenstein-Auswahl" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.CustomMilestone)), "<Vor dem Laden oder Starten einer Stadt> aktivieren, um den gewählten Meilenstein direkt nach dem Laden freizuschalten.\n" +
                    "- Kann nach dem Laden einer Stadt nicht aktiviert werden, aber deaktiviert werden, falls es versehentlich aktiv blieb.\n" +
                    "- Falls vergessen: Spiel neu starten und Meilenstein vor Betreten der Stadt wählen.\n" +
                    "- Der Mod kann bereits gespeicherte Meilensteinänderungen nicht rückgängig machen; nutze bei Bedarf einen älteren Spielstand." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MilestoneLevel)), "Meilenstein" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MilestoneLevel)), "Wähle den Meilenstein, der beim nächsten Laden der Stadt freigeschaltet wird.\n" +
                    "Nur <außerhalb einer geladenen Stadt> einstellbar und nur wenn [Meilenstein-Auswahl] aktiv ist [ ✓ ].\n" +
                    "Ist die Stadt bereits dort oder weiter, passiert nichts.\n" +
                    "Eine Änderung passiert nur, wenn der gewählte Meilenstein höher ist." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ManualMoneyAmount)), "Geldbetrag pro Tastenkürzel" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ManualMoneyAmount)), "Nutze diesen Betrag mit den Tastenkürzels Geld hinzufügen und Geld abziehen.\n" +
                    "<Mod-Standard = 40.000>\n" +
                    "Tut nichts, außer du nutzt den Tastenkürzel in der Stadt.\n" +
                    "Für automatisches Geld aktiviere Automatisch Geld hinzufügen." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AddMoneyKeyboardBinding)), "Geld hinzufügen" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AddMoneyKeyboardBinding)), "Tastenkürzel für <Geld hinzufügen> in der Stadt." },
                { m_Settings.GetBindingKeyLocaleID(Setting.AddMoneyAction), "Geld hinzufügen" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.SubtractMoneyKeyboardBinding)), "Geld abziehen" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.SubtractMoneyKeyboardBinding)), "Tastenkürzel für <Geld abziehen> in der Stadt." },
                { m_Settings.GetBindingKeyLocaleID(Setting.SubtractMoneyAction), "Geld abziehen" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoney)), "Automatisch Geld hinzufügen" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoney)), "Wenn aktiv [ ✓ ], prüft City Watchdog das Stadtguthaben, solange eine Stadt geladen ist.\n" +
                    "- Wenn das Guthaben <unter der Schwelle> liegt,\n" +
                    "  wird der gewählte Betrag hinzugefügt.\n" +
                    "- Empfohlen ist manuelles Geld per Tastenkürzel (<[> oder <]>) nach Bedarf\n" +
                    "  statt dieser Automatik, aber die Option ist verfügbar." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoneyThreshold)), "Automatische Geldschwelle" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoneyThreshold)), "Wenn Automatisch Geld hinzufügen aktiv ist und das Stadtguthaben unter diesen Wert fällt,\n" +
                    "wird der gewählte Betrag hinzugefügt." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoneyAmount)), "Automatischer Geldbetrag" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoneyAmount)), "Betrag, der bei jeder automatischen Auslösung hinzugefügt wird.\n" +
                    "Wähle genug, um die Stadt sicher über die Schwelle zu bringen." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ConfirmUnlimitedMoneySaveConversion)), "Konverter für unbegrenztes Geld" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ConfirmUnlimitedMoneySaveConversion)), "<ZUERST Backup der Stadt erstellen>.\n" +
                    "Wandelt eine Stadt, die mit unbegrenztem Geld gestartet wurde, in eine normale Stadt mit Geldherausforderungen um.\n" +
                    "Aktiviert den Button <[Unbegrenzt-Geld-Speicherstand umwandeln]>, wenn die geladene Stadt den Typ <Unbegrenztes Geld> hat.\n" +
                    "City Watchdog kann diese Umwandlung nicht rückgängig machen.\n" +
                    "Für normale Städte ist das nicht nötig." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)), "Unbegrenzt-Geld-Stadt zu normal umwandeln" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)), "Für Städte, die mit <Unbegrenztem Geld> gestartet wurden.\n" +
                    "Während diese Stadt geladen ist, wird der Speicherstand zu normalem begrenztem Geld umgewandelt.\n" +
                    "Button ist <deaktiviert/ausgegraut>, außer die geladene Stadt ist vom Typ <Unbegrenztes Geld>\n" +
                    "und <Konverter für unbegrenztes Geld> ist AN [ ✓ ].\n" +
                    "Backup erstellen und auf eigenes Risiko nutzen; City Watchdog kann das nicht rückgängig machen." },
                { m_Settings.GetOptionWarningLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)), "Diese Stadt von unbegrenztem Geld zu normalem begrenztem Geld umwandeln?\n" +
                    "ZUERST Backup speichern; City Watchdog kann das nicht rückgängig machen.\n" +
                    "Sicher?" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.NameText)), "Mod-Name" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.NameText)), "Anzeigename dieses Mods." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.VersionText)), "Version" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.VersionText)), "Aktuelle Mod-Version." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.OpenParadox)), "Paradox Mods" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.OpenParadox)), "Öffnet die Paradox-Mods-Seite des Autors." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.WriteNotificationAuditLog)), "Debugbericht ins Log" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.WriteNotificationAuditLog)), "<Für normales Spielen nicht nötig.>\n" +
                    "Für Tests und Prüfungen nach Spiel-Patches: schreibt einen Bericht nach <Logs/CityWatchdog.log>\n" +
                    "und vergleicht Live-Benachrichtigungen des Spiels mit den von Watchdog gesteuerten Icons." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.OpenLog)), "Log öffnen" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.OpenLog)), "Öffnet </Logs/CityWatchdog.log>, falls vorhanden.\n" +
                    "Fehlt die Logdatei, wird stattdessen der Logs-Ordner geöffnet." },
            };

            return entries;
        }

        public void Unload()
        {
        }
    }
}
