// <copyright file="LocalePL.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the MIT License. You may not use this file except in compliance with this License.
// See LICENSE file in the project root for full license information.
// This notice and the MIT License notice must be kept with
// all copies or substantial portions of this code.
// ================= </copyright> ======================

// File: src/Localization/LocalePL.cs
// Purpose: Polish (pl-PL) for City Watchdog Options UI menu.

namespace CityWatchdog
{
    using System.Collections.Generic; // Dictionary and KeyValuePair
    using Colossal;                   // IDictionarySource
    using Game.UI.Editor;

    public sealed class LocalePL : IDictionarySource
    {
        private readonly Setting m_Settings;

        public LocalePL(Setting setting)
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
                { m_Settings.GetOptionTabLocaleID(Setting.Actions), "Akcje" },
                { m_Settings.GetOptionTabLocaleID(Setting.MiniHudTab), "Mini-HUD" },
                { m_Settings.GetOptionTabLocaleID(Setting.MoneyTab), "Pieniądze i kamienie milowe" },
                { m_Settings.GetOptionTabLocaleID(Setting.About), "O modzie" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutUsage), "UŻYCIE" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Notifications), "Powiadomienia" },
                { m_Settings.GetOptionGroupLocaleID(Setting.MoneyViewGroup), "Podgląd informacji w mieście" },
                { m_Settings.GetOptionGroupLocaleID(Setting.MiniHudGroup), "Powiadomienia Mini HUD" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Milestone), "USTAWIENIA STARTU NOWEGO MIASTA" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Money), "Pieniądze" },
                { m_Settings.GetOptionGroupLocaleID(Setting.SaveConversion), "Konwertuj zapis z nieograniczonymi pieniędzmi" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutInfo), "" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutLinks), "" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutDiagnostics), "DIAGNOSTYKA" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ShowUsage)), "Pokaż instrukcje" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ShowUsage)), "Pokaż lub ukryj the usage instructions below." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.UsageText)), "<Display toggles>\n1. [i] button: show/hide all game hover tooltips.\n2. Road Name button: show/hide road name labels. Skrót: \\.\n3. District Name button: show/hide district names without changing boundaries.\n4. Road Arrow button: show/hide one-way road arrows and also hide road names.\n5. CWD title icon: show/hide panel tooltips.\n\n<Notification alerts>\nOtwórz City Watchdog with the top-left button or Shift+N. Sort, Toggle All, or expand sections to change specific icons. This hides icons only; it does not fix city problems.\n\n<Pieniądze helpers>\nUse [ and ] to add/subtract money. Automatic money adds money below your chosen limit. Nieograniczone pieniądze conversion is not reversible.\n\n<Bottom menu tooltips>\nPieniądze View adds money and population trend values to the bottom toolbar.\n\n<Custom milestone>\nSet Początkowe pieniądze and milestones before loading or starting a city." },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.UsageText)), "" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleNotificationsKeyboardBinding)), "Przełącz ikony powiadomień" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleNotificationsKeyboardBinding)), "<Skrót> for the same action as the in-game <[TOGGLE ALL]> icon button.\nIt shows or hides all listed city notification icons instantly." },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleNotificationsAction), "Natychmiast pokaż/ukryj wszystkie ikony powiadomień" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleNotificationPanelKeyboardBinding)), "Otwórz/zamknij panel powiadomień" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleNotificationPanelKeyboardBinding)), "<Skrót> for opening or closing the\n<panel powiadomień> w mieście.\nWorks the same as clicking Top Left icon to open the full panel." },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleNotificationPanelAction), "Otwórz/zamknij panel powiadomień" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.PanelButtonsOnlyStart)), "Start tylko z przyciskami" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.PanelButtonsOnlyStart)), "Gdy włączone [ ✓ ], opening City Watchdog from the top-left button starts in the smaller buttons-only view.\nUse the title-bar arrow or the row-count button to expand the full panel." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleRoadNamesKeyboardBinding)), "Ukryj/pokaż nazwy dróg" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleRoadNamesKeyboardBinding)), "<Skrót> to instantly hide or show the vanilla road name labels w mieście.\nSame as clicking the Road-Name icon in the City Watchdog panel toolbar." },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleRoadNamesAction), "Ukryj/pokaż nazwy dróg" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleAllTooltipsKeyboardBinding)), "Wyłącz wszystkie podpowiedzi po najechaniu" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleAllTooltipsKeyboardBinding)), "<Skrót> to instantly hide or show ALL game hover tooltips — buildings, cims, tools, and bottom menu icons.\n<City Watchdog's own money/population popups stay on>; those are controlled by the Pieniądze View option above.\nSame as clicking the [i] icon on the City Watchdog panel inside the city." },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleAllTooltipsAction), "Ukryj/pokaż wszystkie podpowiedzi gry" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyView)), "Pokaż podpowiedzi pieniędzy i populacji" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyView)), "<Recommend Enable>\nBottom game menu: Shows trend values with the game's bottom toolbar <money and population arrows>.\nThis is a lightweight hover over toolbar feature <display only>;\nSaves time and possible better performance than opening game's Info view panel." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyViewMode)), "Częstotliwość Money View" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyViewMode)), "Wybierz whether the bottom-toolbar trend text shows hourly or monthly values for money and population.\nMonthly uses budget income minus expenses for money, and a 24-hour projection for population." },
                { m_Settings.GetOptionLocaleID("MoneyViewModeHourly"), "Godzinowo (/h)" },
                { m_Settings.GetOptionLocaleID("MoneyViewModeMonthly"), "Miesięcznie (/mo)" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyTooltipMode)), "Styl podpowiedzi pieniędzy" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyTooltipMode)), "Wybierz how much detail appears in the money hover tooltip.\nKompaktowy = default on first install.\n<Mini> shows only 2 Net values for /mo and /h.\n<Kompaktowy> shortens large values (15.21M instead of 15,212,318).\n<Pełne dane> shows long values and Total fields." },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeMini"), "Mini" },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeCompact"), "Kompaktowy" },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeFullData"), "Pełne dane" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyTooltipFontScale)), "Rozmiar czcionki pieniędzy" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyTooltipFontScale)), "Adjusts <font size> of Pieniądze View tooltip numbers.\nDomyślne gry = 100%\n<Domyślne moda = 120%>\nHover over Pieniądze at bottom of the screen.\nRequested by players who have hard time seeing smaller tooltips in the game." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.PopulationTooltipFontScale)), "Rozmiar czcionki populacji" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.PopulationTooltipFontScale)), "Adjusts <font size> of population tooltip numbers.\nDomyślne gry = 100%\n<Domyślne moda = 120%>\nHover over Population at bottom of the screen." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudEnabled)), "Mini HUD" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudEnabled)), "Pokazuje mały HUD w mieście with the most important notification counts.\nUse it as a quick alert strip without opening the full City Watchdog panel.\nClicking an icon jumps to one matching problem spot.\nKeep clicking the same icon to rotate through matching spots, then back to the first one." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ApplyMiniHudRecommendedPreset)), "Zalecane ustawienie" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ApplyMiniHudRecommendedPreset)), "Applies a recommended Mini HUD setup:\nFavorites, 5 icons, horizontal, top center, 100% size, dark panel.\nZero-count alerts stay visible.\nAdd/remove **Blue Star** favorites anytime in the expanded Watchdog panel.\nStarter set Blue-Star favorites are included with **[Recommended]**." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudMode)), "Tryb Mini HUD" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudMode)), "Wybierz which notification rows the Mini HUD uses.\n**Top active** alerts shows the highest current counts.\n**Ulubione** includes all rows marked with **Niebieska gwiazdka** in the main City Watchdog panel.\nYou can pick as many favorites as you want,\nbut Mini HUD still shows only the top 5 or top 10 current counts from that **favorites blue-star** list." },
                { m_Settings.GetOptionLocaleID("MiniHudModeTopActive"), "Najaktywniejsze alerty" },
                { m_Settings.GetOptionLocaleID("MiniHudModeFavorites"), "Ulubione" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudItemCount)), "Liczba ikon Mini HUD" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudItemCount)), "Wybierz how many notification icons the Mini HUD can show at once." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudScale)), "Mini HUD size" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudScale)), "Scale Mini HUD icons and numbers.\n90% = compact. 100% = default. Increase up to 130% for better visibility." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudOrientation)), "Orientacja Mini HUD" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudOrientation)), "Wybierz whether Mini HUD icons are arranged in a row or a column." },
                { m_Settings.GetOptionLocaleID("MiniHudOrientationHorizontal"), "Poziomo" },
                { m_Settings.GetOptionLocaleID("MiniHudOrientationVertical"), "Pionowo" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudPlacement)), "Położenie Mini HUD" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudPlacement)), "Wybierz where the Mini HUD appears.\nPrzeciągane lets you move it w mieście UI." },
                { m_Settings.GetOptionLocaleID("MiniHudPlacementTopCenter"), "U góry na środku" },
                { m_Settings.GetOptionLocaleID("MiniHudPlacementTopRight"), "U góry po prawej" },
                { m_Settings.GetOptionLocaleID("MiniHudPlacementDraggable"), "Przeciągane" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudPanelStyle)), "Mini HUD style" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudPanelStyle)), "Choose the Mini HUD background style.\nGlass panel goes from clear to a cloudy white tint; it does not get darker.\nUse Dark panel for a darker vanilla-style HUD." },
                { m_Settings.GetOptionLocaleID("MiniHudPanelStyleDark"), "Dark panel" },
                { m_Settings.GetOptionLocaleID("MiniHudPanelStyleGlass"), "Glass panel" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudPanelOpacity)), "Mini HUD opacity" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudPanelOpacity)), "Adjusts Mini HUD background transparency.\nLower values are more transparent. Higher values are more solid.\nGlass becomes more white/cloudy. Dark becomes more solid/dark." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudHideZero)), "Ukryj alerty zerowe" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudHideZero)), "Gdy włączone [ ✓ ], the Mini HUD hides notification rows with a count of 0." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.InitialMoney)), "Początkowe pieniądze" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.InitialMoney)), "Sets the starting balance for a new <limited money> city or the first loaded city,\nthen resets to Domyślne gry after it applies.\nThis is grayed out if a city is already loaded.\nSet this before starting/loading a city. It applies once, then use <Kwota skrótu pieniędzy> or <Automatyczne dodawanie pieniędzy> afterward." },
                { m_Settings.GetOptionLocaleID("GameDefault"), "Domyślne gry" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.CustomMilestone)), "Wybór kamienia milowego" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.CustomMilestone)), "Enable <before loading or starting a city> to unlock a chosen milestone immediately after the city loads.\n- Cannot be turned ON after a city is loaded, but it can be turned OFF if it was left enabled by mistake.\n- If you forgot and loaded a city, just restart the game, and pick milestone before entering a city.\n- Mod nie może cofnąć milestone changes already saved into a city; use an earlier save if needed." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MilestoneLevel)), "Kamień milowy" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MilestoneLevel)), "Pick a milestone level to unlock on the next city load.\nThis is <only adjustable outside a loaded city>, and only after [Wybór kamienia milowego] is enabled [ ✓ ].\nIf the city is already at or past the milestone selected, then nothing will happen.\nA change only happens if the milestone selected here is higher than what the city has." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ManualMoneyAmount)), "Kwota skrótu pieniędzy" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ManualMoneyAmount)), "Use this amount with the Dodaj pieniądze and Odejmij pieniądze hotkeys.\n<Domyślne moda = 40,000>\nThis does nothing unless you use the hotkey to add/subtract money (w mieście).\nFor automated money, enable the Automatyczne dodawanie pieniędzy option." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AddMoneyKeyboardBinding)), "Dodaj pieniądze" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AddMoneyKeyboardBinding)), "Skrót to <Dodaj pieniądze> inside the city." },
                { m_Settings.GetBindingKeyLocaleID(Setting.AddMoneyAction), "Dodaj pieniądze" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.SubtractMoneyKeyboardBinding)), "Odejmij pieniądze" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.SubtractMoneyKeyboardBinding)), "Skrót to <Odejmij pieniądze> inside the city." },
                { m_Settings.GetBindingKeyLocaleID(Setting.SubtractMoneyAction), "Odejmij pieniądze" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoney)), "Automatyczne dodawanie pieniędzy" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoney)), "Gdy włączone [ ✓ ], City Watchdog checks the city balance while a city is loaded.\n- If the balance is <below the threshold>, \n  it adds the selected automatic amount.\n- Recommend to use Manual money with hotkey (<[> or <]>) as needed  instead of this automated option, but this is here if you want it." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoneyThreshold)), "Próg automatycznych pieniędzy" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoneyThreshold)), "If Automatyczne dodawanie pieniędzy is enabled and the city balance falls below this value,\nAdd the selected automatic amount." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoneyAmount)), "Kwota automatyczna" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoneyAmount)), "Amount added each time Automatyczne dodawanie pieniędzy triggers.\nWybierz a value high enough to bring the city safely above the threshold." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ConfirmUnlimitedMoneySaveConversion)), "Konwerter nieograniczonych pieniędzy" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ConfirmUnlimitedMoneySaveConversion)), "<Najpierw zrób kopię miasta>.\nConverts a city that started as Nieograniczone pieniądze to a normal city with regular money challenges.\nEnabling this unlocks the <[Convert Nieograniczone pieniądze Save]> button when the loaded city is <Nieograniczone pieniądze> type.\nCity Watchdog nie może cofnąć this conversion.\nIf you have normal cities, do not worry about this; it is not needed." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)), "Konwertuj miasto z nieograniczonymi pieniędzmi na normalne" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)), "For cities started with <Nieograniczone pieniądze>.\nWhile that city is loaded, this converts the save to normal limited-money budgeting so the city has regular money challenges again.\nButton is <disabled/greyed-out> unless the loaded city is an <Nieograniczone pieniądze> type\nand <Konwerter nieograniczonych pieniędzy> is ON [ ✓ ].\nMake a backup save, and use at your own risk; City Watchdog nie może cofnąć this conversion." },
                { m_Settings.GetOptionWarningLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)), "Convert this city from Nieograniczone pieniądze to normal limited money?\nSave a backup FIRST; City Watchdog nie może cofnąć this.\nAre you sure?" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.NameText)), "Nazwa moda" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.NameText)), "Display name of this mod." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.VersionText)), "Wersja" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.VersionText)), "Current mod version." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.OpenParadox)), "Paradox Mods" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.OpenParadox)), "Otwórz the author's Paradox Mods page." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.WriteNotificationAuditLog)), "Raport debug do logu" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.WriteNotificationAuditLog)), "<Not needed for normal gameplay.>\nFor testers and post game-patch checks: writes a <Logs/CityWatchdog.log> report\ncomparing live game notification prefabs with the notification icons Watchdog currently controls." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.OpenLog)), "Otwórz log" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.OpenLog)), "Otwórzs </Logs/CityWatchdog.log> if it exists.\nIf the log file is missing, opens the Logs/ folder instead." },
            };

            return entries;
        }

        public void Unload()
        {
        }
    }
}
