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
                { m_Settings.GetOptionTabLocaleID(Setting.MoneyTab), "Pieniądze-Kamienie" },
                { m_Settings.GetOptionTabLocaleID(Setting.About), "O modzie" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutUsage), "UŻYCIE" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Notifications), "Powiadomienia" },
                { m_Settings.GetOptionGroupLocaleID(Setting.MoneyViewGroup), "Info w mieście" },
                { m_Settings.GetOptionGroupLocaleID(Setting.MiniHudGroup), "Powiadomienia Mini HUD" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Milestone), "START NOWEGO MIASTA" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Money), "Pieniądze" },
                { m_Settings.GetOptionGroupLocaleID(Setting.SaveConversion), "Konwersja zapisu bez limitu" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutInfo), "" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutLinks), "" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutDiagnostics), "DIAGNOSTYKA" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ShowUsage)), "Pokaż instrukcje" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ShowUsage)), "Pokazuje lub ukrywa instrukcje poniżej." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.UsageText)), "<Przełączniki widoku>\n" +
                    "1. Przycisk [i]: ukrywa/pokazuje WSZYSTKIE podpowiedzi gry — budynki, mieszkańców, narzędzia i ikony dolnego menu.\n" +
                    "2. Przycisk nazw dróg: ukrywa/pokazuje nazwy dróg. Skrót: \\.\n" +
                    "3. Przycisk nazw dzielnic: ukrywa/pokazuje nazwy bez zmiany granic.\n" +
                    "4. Przycisk strzałek dróg: wymusza strzałki jednokierunkowe wł./wył. (ukrywa też nazwy dróg).\n" +
                    "5. Ikona CWD na pasku tytułu: pokazuje/ukrywa podpowiedzi panelu City Watchdog.\n" +
                    "\n" +
                    "<Alerty>\n" +
                    "1. Kliknij przycisk City Watchdog w lewym górnym rogu albo naciśnij Shift+N, aby otworzyć panel.\n" +
                    "2. Przycisk sortowania: rosnąco/malejąco.\n" +
                    "3. Przełącz wszystko, aby szybko wyłączyć/włączyć całość, albo rozwiń sekcję i zmień wybrane.\n" +
                    "4. To tylko pokazuje lub ukrywa ikony; nie naprawia problemu miasta.\n" +
                    "\n" +
                    "<Pomoc z pieniędzmi>\n" +
                    "1. Dodaj lub odejmij pieniądze: użyj <Kwota skrótu pieniędzy>, domyślne klawisze [ i ].\n" +
                    "2. Automatyczne dodawanie pieniędzy dodaje środki, gdy miasto spadnie poniżej ustawionego limitu.\n" +
                    "3. Konwersja zapisu z pieniędzmi bez limitu działa tylko dla takich miast i jest <nieodwracalna>.\n" +
                    "\n" +
                    "<Podpowiedzi dolnego menu>\n" +
                    "Widok pieniędzy dodaje trendy pieniędzy i populacji oraz szczegóły po najechaniu.\n" +
                    "\n" +
                    "<Własny kamień milowy>\n" +
                    "Ustaw pieniądze startowe i kamień w Pieniądze-Kamienie > START NOWEGO MIASTA przed wczytaniem lub rozpoczęciem miasta." },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.UsageText)), "" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleNotificationsKeyboardBinding)), "Przełącz ikony powiadomień" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleNotificationsKeyboardBinding)), "<Skrót> dla tej samej akcji co przycisk <[Przełącz wszystko]> w grze.\n" +
                    "Natychmiast pokazuje lub ukrywa wszystkie wymienione ikony powiadomień." },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleNotificationsAction), "Pokaż/ukryj wszystkie ikony powiadomień" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleNotificationPanelKeyboardBinding)), "Otwórz/zamknij panel powiadomień" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleNotificationPanelKeyboardBinding)), "<Skrót> do otwierania lub zamykania\n" +
                    "<panelu powiadomień> w mieście.\n" +
                    "Działa jak kliknięcie ikony w lewym górnym rogu." },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleNotificationPanelAction), "Otwórz/zamknij panel powiadomień" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.PanelButtonsOnlyStart)), "Start panelu tylko z przyciskami" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.PanelButtonsOnlyStart)), "Gdy włączone [ ✓ ], City Watchdog otwiera się z lewego górnego przycisku w małym widoku samych przycisków.\n" +
                    "Użyj strzałki paska tytułu albo przycisku licznika, aby rozwinąć pełny panel." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleRoadNamesKeyboardBinding)), "Ukryj/pokaż nazwy dróg" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleRoadNamesKeyboardBinding)), "<Skrót>, aby natychmiast ukryć lub pokazać nazwy dróg z gry podstawowej.\n" +
                    "Tak samo jak ikona nazw dróg w panelu City Watchdog." },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleRoadNamesAction), "Ukryj/pokaż nazwy dróg" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleAllTooltipsKeyboardBinding)), "Wyłącz wszystkie podpowiedzi myszy" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleAllTooltipsKeyboardBinding)), "<Skrót>, aby natychmiast ukryć lub pokazać WSZYSTKIE podpowiedzi gry — budynki, mieszkańców, narzędzia i ikony dolnego menu.\n" +
                    "<Własne okienka pieniędzy/populacji City Watchdog zostają włączone>; steruje nimi opcja Widok pieniędzy.\n" +
                    "Tak samo jak ikona [i] w panelu City Watchdog." },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleAllTooltipsAction), "Ukryj/pokaż wszystkie podpowiedzi gry" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyView)), "Pokaż podpowiedzi pieniędzy + populacji" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyView)), "<Zalecane>\n" +
                    "Dolne menu gry: pokazuje trendy przy <strzałkach pieniędzy i populacji> na pasku.\n" +
                    "Lekka funkcja po najechaniu, <tylko wyświetlanie>;\n" +
                    "oszczędza czas i może działać szybciej niż panel informacji gry." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyViewMode)), "Częstotliwość widoku pieniędzy" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyViewMode)), "Wybierz, czy dolny tekst trendu pokazuje wartości godzinowe czy miesięczne dla pieniędzy i populacji.\n" +
                    "Miesięcznie używa dochodów minus wydatków budżetu i prognozy populacji 24 h." },
                { m_Settings.GetOptionLocaleID("MoneyViewModeHourly"), "Godzinowo (/h)" },
                { m_Settings.GetOptionLocaleID("MoneyViewModeMonthly"), "Miesięcznie (/mc)" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyTooltipMode)), "Styl podpowiedzi pieniędzy" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyTooltipMode)), "Wybierz ilość szczegółów w podpowiedzi pieniędzy.\n" +
                    "Kompaktowy = domyślny przy pierwszej instalacji.\n" +
                    "<Mini> pokazuje tylko 2 wartości netto dla /mc i /h.\n" +
                    "<Kompaktowy> skraca duże wartości (15.21M zamiast 15,212,318).\n" +
                    "<Pełne dane> pokazuje długie wartości i sumy." },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeMini"), "Mini" },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeCompact"), "Kompaktowy" },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeFullData"), "Pełne dane" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyTooltipFontScale)), "Rozmiar czcionki pieniędzy" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyTooltipFontScale)), "Zmienia <rozmiar czcionki> liczb w podpowiedzi pieniędzy.\n" +
                    "Domyślnie w grze = 100%\n" +
                    "<Domyślnie w modzie = 120%>\n" +
                    "Najedź na pieniądze u dołu ekranu.\n" +
                    "Dla graczy, którym trudno czytać małe podpowiedzi." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.PopulationTooltipFontScale)), "Rozmiar czcionki populacji" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.PopulationTooltipFontScale)), "Zmienia <rozmiar czcionki> liczb w podpowiedzi populacji.\n" +
                    "Domyślnie w grze = 100%\n" +
                    "<Domyślnie w modzie = 120%>\n" +
                    "Najedź na populację u dołu ekranu." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudEnabled)), "Mini HUD" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudEnabled)), "Pokazuje mały HUD miasta z najważniejszymi licznikami powiadomień.\n" +
                    "Używaj jako szybkiego paska alertów bez otwierania pełnego panelu City Watchdog.\n" +
                    "Kliknięcie ikony skacze do pasującego problemu.\n" +
                    "Kolejne kliknięcia tej samej ikony przechodzą po miejscach i wracają do pierwszego." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ApplyMiniHudRecommendedPreset)), "Szybki zestaw startowy" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ApplyMiniHudRecommendedPreset)), "Stosuje zalecaną konfigurację Mini HUD:\n" +
                    "Ulubione, 5 ikon, poziomo, góra środek, rozmiar 100%, ciemny panel.\n" +
                    "Alerty z zerem zostają widoczne.\n" +
                    "Dodawaj/usuwaj ulubione **Niebieska gwiazdka** w rozwiniętym panelu Watchdog kiedy chcesz.\n" +
                    "Startowe ulubione **Niebieska gwiazdka** są w **[Zalecane]**." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudMode)), "Tryb Mini HUD" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudMode)), "Wybierz, których wierszy powiadomień używa Mini HUD.\n" +
                    "**Najaktywniejsze** pokazuje najwyższe bieżące liczniki.\n" +
                    "**Ulubione** obejmuje wszystkie wiersze z **Niebieską gwiazdką** w głównym panelu.\n" +
                    "Możesz wybrać dowolnie dużo ulubionych,\n" +
                    "ale Mini HUD pokazuje tylko top 5 lub top 10 bieżących liczników z tej listy **niebieskich gwiazdek**." },
                { m_Settings.GetOptionLocaleID("MiniHudModeTopActive"), "Najaktywniejsze alerty" },
                { m_Settings.GetOptionLocaleID("MiniHudModeFavorites"), "Ulubione" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudItemCount)), "Liczba ikon" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudItemCount)), "Wybierz, ile ikon powiadomień Mini HUD może pokazać naraz." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudScale)), "Rozmiar ikon" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudScale)), "Skaluje ikony i liczby Mini HUD.\n" +
                    "90% = kompakt. 100% = domyślnie. Do 130% dla lepszej widoczności." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudOrientation)), "Układ" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudOrientation)), "Wybierz, czy ikony Mini HUD są w rzędzie czy w kolumnie." },
                { m_Settings.GetOptionLocaleID("MiniHudOrientationHorizontal"), "Poziomo" },
                { m_Settings.GetOptionLocaleID("MiniHudOrientationVertical"), "Pionowo" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudPlacement)), "Pozycja HUD" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudPlacement)), "Wybierz miejsce Mini HUD.\n" +
                    "Przeciągany pozwala przesuwać go w interfejsie miasta." },
                { m_Settings.GetOptionLocaleID("MiniHudPlacementTopCenter"), "Góra środek" },
                { m_Settings.GetOptionLocaleID("MiniHudPlacementTopRight"), "Góra prawa" },
                { m_Settings.GetOptionLocaleID("MiniHudPlacementDraggable"), "Przeciągany" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudPanelStyle)), "Styl ciemny lub szkło" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudPanelStyle)), "Wybierz tło Mini HUD.\n" +
                    "Panel szklany przechodzi od przezroczystego do mlecznobiałego; nie robi się ciemniejszy.\n" +
                    "Użyj ciemnego panelu dla ciemniejszego HUD w stylu gry." },
                { m_Settings.GetOptionLocaleID("MiniHudPanelStyleDark"), "Ciemny panel" },
                { m_Settings.GetOptionLocaleID("MiniHudPanelStyleGlass"), "Szklany panel" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudPanelOpacity)), "Nieprzezroczystość tła" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudPanelOpacity)), "Zmienia przezroczystość tła Mini HUD.\n" +
                    "Niżej = bardziej przezroczyste. Wyżej = bardziej zwarte.\n" +
                    "Szkło robi się bielsze/mleczne. Ciemny panel robi się ciemniejszy." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudHideZero)), "Ukryj alerty zerowe" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudHideZero)), "Gdy włączone [ ✓ ], Mini HUD ukrywa wiersze powiadomień z liczbą 0." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.InitialMoney)), "Pieniądze startowe" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.InitialMoney)), "Ustawia saldo początkowe dla nowego miasta z <ograniczonymi pieniędzmi> albo pierwszego wczytanego miasta,\n" +
                    "a potem wraca do domyślnej gry po zastosowaniu.\n" +
                    "Wyszarzone, jeśli miasto jest już wczytane.\n" +
                    "Ustaw przed startem/wczytaniem. Działa raz, potem użyj <Kwota skrótu pieniędzy> albo <Automatyczne pieniądze>." },
                { m_Settings.GetOptionLocaleID("GameDefault"), "Domyślne gry" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.CustomMilestone)), "Wybór kamienia milowego" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.CustomMilestone)), "Włącz <przed wczytaniem lub startem miasta>, aby odblokować wybrany kamień zaraz po wczytaniu.\n" +
                    "- Nie można włączyć po wczytaniu miasta, ale można wyłączyć, jeśli zostało przez pomyłkę.\n" +
                    "- Jeśli zapomniałeś i wczytałeś miasto, zrestartuj grę i wybierz kamień przed wejściem do miasta.\n" +
                    "- Mod nie cofa zmian kamieni już zapisanych w mieście; użyj starszego zapisu, jeśli trzeba." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MilestoneLevel)), "Kamień milowy" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MilestoneLevel)), "Wybierz poziom kamienia do odblokowania przy następnym wczytaniu miasta.\n" +
                    "Można zmieniać <tylko poza wczytanym miastem> i tylko po włączeniu [Wybór kamienia milowego] [ ✓ ].\n" +
                    "Jeśli miasto już jest na tym poziomie lub dalej, nic się nie stanie.\n" +
                    "Zmiana nastąpi tylko, gdy wybrany kamień jest wyższy." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ManualMoneyAmount)), "Kwota skrótu pieniędzy" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ManualMoneyAmount)), "Użyj tej kwoty ze skrótami Dodaj pieniądze i Odejmij pieniądze.\n" +
                    "<Domyślnie w modzie = 40 000>\n" +
                    "Nic nie robi, jeśli nie użyjesz skrótu w mieście.\n" +
                    "Dla automatyki włącz Automatyczne dodawanie pieniędzy." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AddMoneyKeyboardBinding)), "Dodaj pieniądze" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AddMoneyKeyboardBinding)), "Skrót do <Dodaj pieniądze> w mieście." },
                { m_Settings.GetBindingKeyLocaleID(Setting.AddMoneyAction), "Dodaj pieniądze" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.SubtractMoneyKeyboardBinding)), "Odejmij pieniądze" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.SubtractMoneyKeyboardBinding)), "Skrót do <Odejmij pieniądze> w mieście." },
                { m_Settings.GetBindingKeyLocaleID(Setting.SubtractMoneyAction), "Odejmij pieniądze" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoney)), "Automatyczne dodawanie pieniędzy" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoney)), "Gdy włączone [ ✓ ], City Watchdog sprawdza saldo miasta, gdy miasto jest wczytane.\n" +
                    "- Jeśli saldo jest <poniżej progu>,\n" +
                    "  dodaje wybraną automatyczną kwotę.\n" +
                    "- Zalecane jest ręczne użycie pieniędzy skrótem (<[> lub <]>) w razie potrzeby\n" +
                    "  zamiast automatyki, ale opcja jest dostępna." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoneyThreshold)), "Próg automatycznych pieniędzy" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoneyThreshold)), "Jeśli automatyczne dodawanie jest włączone i saldo spadnie poniżej tej wartości,\n" +
                    "dodana zostanie wybrana automatyczna kwota." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoneyAmount)), "Kwota automatyczna" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoneyAmount)), "Kwota dodawana przy każdym automatycznym uruchomieniu.\n" +
                    "Wybierz tyle, aby bezpiecznie podnieść saldo ponad próg." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ConfirmUnlimitedMoneySaveConversion)), "Konwerter pieniędzy bez limitu" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ConfirmUnlimitedMoneySaveConversion)), "<Najpierw zrób kopię miasta>.\n" +
                    "Konwertuje miasto rozpoczęte z pieniędzmi bez limitu na normalne miasto z budżetem.\n" +
                    "Włączenie odblokowuje przycisk <[Konwertuj zapis bez limitu]> gdy wczytane miasto ma typ <Pieniądze bez limitu>.\n" +
                    "City Watchdog nie może cofnąć tej konwersji.\n" +
                    "Dla normalnych miast nie jest potrzebne." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)), "Zmień miasto bez limitu na normalne" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)), "Dla miast rozpoczętych z <Pieniędzmi bez limitu>.\n" +
                    "Gdy to miasto jest wczytane, zapis zostaje zmieniony na normalny budżet z ograniczonymi pieniędzmi.\n" +
                    "Przycisk jest <wyłączony/wyszarzony>, chyba że wczytane miasto ma typ <Pieniądze bez limitu>\n" +
                    "i <Konwerter pieniędzy bez limitu> jest WŁ. [ ✓ ].\n" +
                    "Zrób kopię i używaj na własne ryzyko; City Watchdog nie może tego cofnąć." },
                { m_Settings.GetOptionWarningLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)), "Zmienić to miasto z pieniędzy bez limitu na normalne ograniczone pieniądze?\n" +
                    "NAJPIERW zapisz kopię; City Watchdog nie może tego cofnąć.\n" +
                    "Na pewno?" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.NameText)), "Nazwa moda" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.NameText)), "Wyświetlana nazwa tego moda." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.VersionText)), "Wersja" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.VersionText)), "Aktualna wersja moda." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.OpenParadox)), "Paradox Mods" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.OpenParadox)), "Otwiera stronę autora w Paradox Mods." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.WriteNotificationAuditLog)), "Raport debug do logu" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.WriteNotificationAuditLog)), "<Niepotrzebne do normalnej gry.>\n" +
                    "Dla testerów i kontroli po patchach gry: zapisuje raport w <Logs/CityWatchdog.log>\n" +
                    "porównujący aktywne prefabrykaty powiadomień gry z ikonami kontrolowanymi przez Watchdog." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.OpenLog)), "Otwórz log" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.OpenLog)), "Otwiera </Logs/CityWatchdog.log>, jeśli istnieje.\n" +
                    "Jeśli brakuje pliku logu, otwiera zamiast tego folder Logs/." },
            };

            return entries;
        }

        public void Unload()
        {
        }
    }
}
