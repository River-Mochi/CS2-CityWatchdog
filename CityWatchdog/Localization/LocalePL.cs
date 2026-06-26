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
                // --- Mod title ---
                { m_Settings.GetSettingsLocaleID(), title },

                // --- Tabs ---
                { m_Settings.GetOptionTabLocaleID(Setting.Actions), "Akcje" },
                { m_Settings.GetOptionTabLocaleID(Setting.MoneyTab), "Pieniądze i kamienie milowe" },
                { m_Settings.GetOptionTabLocaleID(Setting.About), "O modzie" },

                // --- Groups, ordered by Options menu location ---
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutUsage), "UŻYCIE" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Notifications), "Powiadomienia" },
                { m_Settings.GetOptionGroupLocaleID(Setting.MoneyViewGroup), "Podgląd informacji w mieście" },
                { m_Settings.GetOptionGroupLocaleID(Setting.MiniHudGroup), "Powiadomienia Mini HUD" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Milestone), "USTAWIENIA STARTU NOWEGO MIASTA" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Money), "Pieniądze" },
                { m_Settings.GetOptionGroupLocaleID(Setting.SaveConversion), "Konwersja zapisu bez limitu" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutInfo), "" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutLinks), "" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutDiagnostics), "DIAGNOSTYKA" },

                // --------------------------------------------------------------------
                // Actions tab - Usage
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ShowUsage)), "Pokaż instrukcje" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ShowUsage)), "Pokazuje lub ukrywa poniższe instrukcje." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.UsageText)), "<Przełączniki widoku>\n" +
                    "1. Przycisk [i]: ukrywa/pokazuje WSZYSTKIE podpowiedzi gry — budynki, mieszkańców, narzędzia i ikony dolnego menu.\n" +
                    "2. Nazwy dróg: ukrywa/pokazuje etykiety nazw dróg. Skrót: \\.\n" +
                    "3. Nazwy dzielnic: ukrywa/pokazuje nazwy dzielnic bez zmiany granic.\n" +
                    "4. Strzałki dróg: wymusza strzałki jednokierunkowe (ukrywa też nazwy dróg).\n" +
                    "5. Ikona paska CWD: pokazuje/ukrywa podpowiedzi panelu City Watchdog.\n" +
                    "\n" +
                    "<Alerty powiadomień>\n" +
                    "1. Kliknij przycisk City Watchdog w lewym górnym rogu albo naciśnij Shift+N, aby otworzyć panel.\n" +
                    "2. Przycisk sortowania rosnąco/malejąco.\n" +
                    "3. Toggle All szybko wyłącza/włącza wszystko; możesz też rozwinąć sekcję i zmienić konkretne ikony.\n" +
                    "4. Pokazuje lub ukrywa tylko ikony; nie naprawia problemu w mieście.\n" +
                    "\n" +
                    "<Pomoc z pieniędzmi>\n" +
                    "1. Dodaj lub odejmij pieniądze: użyj <Kwota skrótu pieniędzy> z domyślnymi klawiszami [ i ].\n" +
                    "2. Automatyczne dodawanie pieniędzy działa, gdy saldo miasta spadnie poniżej ustawionego limitu.\n" +
                    "3. Konwersja zapisu z nielimitowanymi pieniędzmi dotyczy tylko takich miast i jest <nieodwracalna>.\n" +
                    "\n" +
                    "<Podpowiedzi dolnego menu>\n" +
                    "Money View dodaje wartości trendów pieniędzy i populacji na pasku oraz szczegóły po najechaniu.\n" +
                    "\n" +
                    "<Własny kamień milowy>\n" +
                    "Ustaw początkowe pieniądze i kamienie milowe w Pieniądze i kamienie milowe > USTAWIENIA STARTU NOWEGO MIASTA przed wczytaniem lub rozpoczęciem miasta." },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.UsageText)), "" },

                // --------------------------------------------------------------------
                // Actions tab - Notifications
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleNotificationsKeyboardBinding)), "Przełącz ikony powiadomień" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleNotificationsKeyboardBinding)), "<Skrót> do tej samej akcji co przycisk <[TOGGLE ALL]> w grze.\n" +
                    "Natychmiast pokazuje lub ukrywa wszystkie wymienione ikony powiadomień." },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleNotificationsAction), "Natychmiast pokaż/ukryj wszystkie ikony powiadomień" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleNotificationPanelKeyboardBinding)), "Otwórz/zamknij panel powiadomień" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleNotificationPanelKeyboardBinding)), "<Skrót> do otwierania lub zamykania\n" +
                    "<panelu powiadomień> w mieście.\n" +
                    "Działa tak samo jak przycisk w lewym górnym rogu." },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleNotificationPanelAction), "Otwórz/Zamknij panel powiadomień" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleRoadNamesKeyboardBinding)), "Ukryj/pokaż nazwy dróg" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleRoadNamesKeyboardBinding)), "<Skrót> do natychmiastowego ukrywania lub pokazywania nazw dróg z gry.\n" +
                    "Tak samo jak ikona nazw dróg w pasku City Watchdog." },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleRoadNamesAction), "Ukryj/Pokaż nazwy dróg" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleAllTooltipsKeyboardBinding)), "Wyłącz wszystkie podpowiedzi po najechaniu" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleAllTooltipsKeyboardBinding)), "<Skrót> do ukrywania lub pokazywania WSZYSTKICH podpowiedzi gry — budynków, mieszkańców, narzędzi i ikon dolnego menu.\n" +
                    "<Okna pieniędzy/populacji City Watchdog zostają włączone>; kontroluje je Money View.\n" +
                    "Tak samo jak ikona [i] w panelu City Watchdog." },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleAllTooltipsAction), "Ukryj/Pokaż wszystkie podpowiedzi gry" },

                // --------------------------------------------------------------------
                // Actions tab - In-City Info Viewer
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyView)), "Pokaż ToolTips pieniędzy + populacji" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyView)), "<Zalecane>\n" +
                    "Dolne menu gry: pokazuje trendy przy strzałkach pieniędzy i populacji.\n" +
                    "Lekka funkcja najechania kursorem <tylko widok>;\n" +
                    "oszczędza czas i może działać lepiej niż panel informacji gry." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyViewMode)), "Częstotliwość Money View" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyViewMode)), "Wybierz, czy trendy mają pokazywać wartości godzinowe czy miesięczne dla pieniędzy i populacji.\n" +
                    "Miesięcznie używa dochodów minus wydatki budżetu oraz 24-godzinnej prognozy populacji." },
                { m_Settings.GetOptionLocaleID("MoneyViewModeHourly"), "Godzinowo (/h)" },
                { m_Settings.GetOptionLocaleID("MoneyViewModeMonthly"), "Miesięcznie (/mo)" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyTooltipMode)), "Styl podpowiedzi pieniędzy" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyTooltipMode)), "Wybierz ilość szczegółów w podpowiedzi pieniędzy.\n" +
                    "Compact = domyślnie przy pierwszej instalacji.\n" +
                    "<Mini> pokazuje tylko 2 wartości Netto dla /mo i /h.\n" +
                    "<Compact> skraca duże liczby (15.21M zamiast 15,212,318).\n" +
                    "<Full data> pokazuje długie wartości i pola Total." },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeMini"), "Mini" },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeCompact"), "Kompakt" },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeFullData"), "Pełne dane" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyTooltipFontScale)), "Rozmiar czcionki pieniędzy" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyTooltipFontScale)), "Zmienia <rozmiar czcionki> liczb Money View.\n" +
                    "Domyślnie gra = 100%\n" +
                    "<Domyślnie mod = 120%>\n" +
                    "Najedź na pieniądze na dole ekranu.\n" +
                    "Dla graczy, którym trudno czytać małe podpowiedzi." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.PopulationTooltipFontScale)), "Rozmiar czcionki populacji" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.PopulationTooltipFontScale)), "Zmienia <rozmiar czcionki> liczb populacji.\n" +
                    "Domyślnie gra = 100%\n" +
                    "<Domyślnie mod = 120%>\n" +
                    "Najedź na populację na dole ekranu." },

                // --------------------------------------------------------------------
                // Actions tab - Mini HUD Notifications
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudEnabled)), "Powiadomienia Mini HUD" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudEnabled)), "Pokazuje mały HUD w mieście z najważniejszymi licznikami powiadomień.\n" +
                    "Używaj go jako szybkiego paska alertów bez otwierania pełnego panelu City Watchdog." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudMode)), "Tryb Mini HUD" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudMode)), "Wybierz, których wierszy powiadomień używa Mini HUD.\n" +
                    "Najaktywniejsze alerty pokazują największe bieżące liczniki.\n" +
                    "Ulubione pokazują tylko wiersze oznaczone gwiazdką w panelu City Watchdog." },
                { m_Settings.GetOptionLocaleID("MiniHudModeTopActive"), "Najaktywniejsze alerty" },
                { m_Settings.GetOptionLocaleID("MiniHudModeFavorites"), "Ulubione" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudItemCount)), "Liczba ikon Mini HUD" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudItemCount)), "Wybierz, ile ikon powiadomień Mini HUD może pokazać naraz." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudOrientation)), "Orientacja Mini HUD" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudOrientation)), "Wybierz, czy ikony Mini HUD są ułożone w rzędzie czy w kolumnie." },
                { m_Settings.GetOptionLocaleID("MiniHudOrientationHorizontal"), "Poziomo" },
                { m_Settings.GetOptionLocaleID("MiniHudOrientationVertical"), "Pionowo" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudPlacement)), "Pozycja Mini HUD" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudPlacement)), "Wybierz, gdzie pojawia się Mini HUD.\n" +
                    "Przeciągalny pozwala przenieść go w interfejsie miasta." },
                { m_Settings.GetOptionLocaleID("MiniHudPlacementTopCenter"), "Góra środek" },
                { m_Settings.GetOptionLocaleID("MiniHudPlacementTopRight"), "Góra prawa" },
                { m_Settings.GetOptionLocaleID("MiniHudPlacementDraggable"), "Przeciągalny" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudHideZero)), "Ukryj zerowe alerty" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudHideZero)), "Gdy włączone [ ✓ ], Mini HUD ukrywa wiersze powiadomień z liczbą 0." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudGlassStyle)), "Styl szkła" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudGlassStyle)), "Dodaje miękkie tło w stylu szkła za Mini HUD dla lepszej czytelności." },

                // --------------------------------------------------------------------
                // Money-Milestones tab - New City Start Settings
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.InitialMoney)), "Pieniądze startowe" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.InitialMoney)), "Ustawia saldo początkowe dla nowego miasta z <ograniczonymi pieniędzmi> albo pierwszego wczytanego miasta,\n" +
                    "a potem wraca do Game Default po zastosowaniu.\n" +
                    "Jest wyszarzone, jeśli miasto jest już wczytane.\n" +
                    "Ustaw przed startem/wczytaniem miasta. Potem używaj <Kwoty skrótu pieniędzy> albo <Automatycznego dodawania pieniędzy>." },
                { m_Settings.GetOptionLocaleID("GameDefault"), "Domyślne gry" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.CustomMilestone)), "Wybór milestone" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.CustomMilestone)), "Włącz <przed wczytaniem lub rozpoczęciem miasta>, aby odblokować wybrany milestone zaraz po wczytaniu.\n" +
                    "Nie można włączyć w już wczytanym mieście, ale można wyłączyć, jeśli zostało aktywne przez pomyłkę.\n" +
                    "Jeśli zapomnisz, uruchom grę ponownie i wybierz milestone przed wejściem do miasta.\n" +
                    "City Watchdog nie cofnie milestone zapisanych w mieście; użyj wcześniejszego zapisu, jeśli trzeba." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MilestoneLevel)), "Milestone" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MilestoneLevel)), "Wybierz milestone do odblokowania przy następnym wczytaniu miasta.\n" +
                    "Można zmieniać tylko poza wczytanym miastem i po włączeniu [Wybór milestone] [ ✓ ]." },

                // --------------------------------------------------------------------
                // Money-Milestones tab - Money
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ManualMoneyAmount)), "Kwota skrótu pieniędzy" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ManualMoneyAmount)), "Użyj tej kwoty ze skrótami Dodaj pieniądze i Odejmij pieniądze.\n" +
                    "<Domyślnie mod = 40,000>\n" +
                    "Nic nie robi bez użycia skrótu w mieście.\n" +
                    "Dla automatycznych pieniędzy włącz odpowiednią opcję." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AddMoneyKeyboardBinding)), "Dodaj pieniądze" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AddMoneyKeyboardBinding)), "Skrót do <Dodaj pieniądze> w mieście." },
                { m_Settings.GetBindingKeyLocaleID(Setting.AddMoneyAction), "Dodaj pieniądze" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.SubtractMoneyKeyboardBinding)), "Odejmij pieniądze" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.SubtractMoneyKeyboardBinding)), "Skrót do <Odejmij pieniądze> w mieście." },
                { m_Settings.GetBindingKeyLocaleID(Setting.SubtractMoneyAction), "Odejmij pieniądze" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoney)), "Automatyczne dodawanie pieniędzy" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoney)), "Po włączeniu [ ✓ ] City Watchdog sprawdza saldo, gdy miasto jest wczytane.\n" +
                    "- Jeśli saldo jest <poniżej progu>,\n" +
                    "  dodaje wybraną kwotę automatyczną.\n" +
                    "- Zalecane jest ręczne użycie skrótów (<[> lub <]>), ale ta opcja jest dostępna." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoneyThreshold)), "Próg automatycznych pieniędzy" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoneyThreshold)), "Jeśli automatyczne pieniądze są włączone i saldo spadnie poniżej tej wartości,\n" +
                    "dodaje wybraną kwotę." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoneyAmount)), "Automatyczna kwota pieniędzy" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoneyAmount)), "Kwota dodawana przy każdym uruchomieniu automatu.\n" +
                    "Wybierz wartość wystarczająco dużą, by wrócić ponad próg." },

                // --------------------------------------------------------------------
                // Money-Milestones tab - Save Conversion
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ConfirmUnlimitedMoneySaveConversion)), "Konwerter Nieograniczonych pieniędzy" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ConfirmUnlimitedMoneySaveConversion)), "<Najpierw zrób kopię zapasową miasta>.\n" +
                    "Konwertuje miasto rozpoczęte z Nieograniczonymi pieniędzmi na normalne miasto z budżetem.\n" +
                    "Włączenie odblokowuje przycisk <[Konwertuj zapis Nieograniczonych pieniędzy]>, gdy wczytane miasto ma typ <Nieograniczone pieniądze>.\n" +
                    "City Watchdog nie może cofnąć tej konwersji.\n" +
                    "Normalne miasta tego nie potrzebują." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)), "Konwertuj miasto z Nieograniczonymi pieniędzmi na normalne" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)), "Dla miast rozpoczętych z <Nieograniczonymi pieniędzmi>.\n" +
                    "Gdy to miasto jest wczytane, zapis zostaje przełączony na normalny ograniczony budżet.\n" +
                    "Przycisk jest <wyłączony/wyszarzony>, chyba że miasto jest typu <Nieograniczone pieniądze>\n" +
                    "i <Konwerter Nieograniczonych pieniędzy> jest ON [ ✓ ].\n" +
                    "Zrób kopię i używaj na własne ryzyko; City Watchdog nie cofnie tego." },

                { m_Settings.GetOptionWarningLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)), "Przekonwertować to miasto z Nieograniczonych pieniędzy na normalne ograniczone pieniądze?\n" +
                    "NAJPIERW zrób kopię; City Watchdog nie może tego cofnąć.\n" +
                    "Na pewno?" },

                // --------------------------------------------------------------------
                // About tab
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.NameText)), "Nazwa moda" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.NameText)), "Wyświetlana nazwa tego moda." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.VersionText)), "Wersja" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.VersionText)), "Aktualna wersja moda." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.OpenParadox)), "Paradox Mods" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.OpenParadox)), "Otwiera stronę autora w Paradox Mods." },

                // --------------------------------------------------------------------
                // About tab - Diagnostics
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.WriteNotificationAuditLog)), "Raport debug do logu" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.WriteNotificationAuditLog)), "<Niepotrzebne do normalnej gry.>\n" +
                    "Dla testerów i kontroli po patchach: zapisuje raport <Logs/CityWatchdog.log>\n" +
                    "porównujący prefaby powiadomień gry z ikonami kontrolowanymi przez Watchdog." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.OpenLog)), "Otwórz log" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.OpenLog)), "Otwiera </Logs/CityWatchdog.log>, jeśli istnieje.\n" +
                    "Jeśli pliku nie ma, otwiera folder Logs/." },
            };

            return entries;
        }

        public void Unload()
        {
        }
    }
}
