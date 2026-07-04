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
                { m_Settings.GetOptionTabLocaleID(Setting.MiniHudTab), "Mini-HUD" },
                { m_Settings.GetOptionTabLocaleID(Setting.MoneyTab), "Pieniądze-Kamienie" },
                { m_Settings.GetOptionTabLocaleID(Setting.About), "O modzie" },

                // --- Groups, ordered by Options menu location ---
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutUsage), "UŻYCIE" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Notifications), "Powiadomienia" },
                { m_Settings.GetOptionGroupLocaleID(Setting.MoneyViewGroup), "Info w mieście" },
                { m_Settings.GetOptionGroupLocaleID(Setting.MiniHudGroup), "Powiadomienia Mini HUD" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Milestone), "USTAWIENIA NOWEGO MIASTA" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Money), "Pieniądze" },
                { m_Settings.GetOptionGroupLocaleID(Setting.SaveConversion), "Konwertuj zapis bez limitu" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutInfo), "" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutLinks), "" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutDiagnostics), "DIAGNOSTYKA" },

                // --------------------------------------------------------------------
                // Actions tab - Usage
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ShowUsage)), "Pokaż instrukcje" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ShowUsage)), "Pokaż lub ukryj instrukcje poniżej." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.UsageText)),
                    "<Przełączniki widoku>\n" +
                    "1. Przycisk [i]: ukrywa/pokazuje WSZYSTKIE podpowiedzi gry.\n" +
                    "2. Nazwy dróg: ukryj/pokaż nazwy. Skrót: \\.\n" +
                    "3. Nazwy dzielnic: ukryj/pokaż bez zmiany granic.\n" +
                    "4. Strzałki dróg: wymuś strzałki jednokierunkowe (ukrywa też nazwy dróg).\n" +
                    "5. Ikona CWD: ukryj/pokaż podpowiedzi panelu City Watchdog.\n\n" +
                    "<Alerty>\n" +
                    "1. Kliknij City Watchdog w lewym górnym rogu albo naciśnij Shift+N.\n" +
                    "2. Sortowanie: rosnąco/malejąco.\n" +
                    "3. Toggle All szybko włącza/wyłącza wszystko; sekcje dają wybór szczegółowy.\n" +
                    "4. Ukrywa tylko ikony; nie naprawia problemu miasta.\n\n" +
                    "<Pomoc z pieniędzmi>\n" +
                    "1. Dodaj lub odejmij pieniądze: domyślne klawisze [ i ].\n" +
                    "2. Automatyczne pieniądze dodają środki poniżej ustawionego limitu.\n" +
                    "3. Konwersja zapisu Unlimited Money działa tylko dla takich miast i jest <nieodwracalna>.\n\n" +
                    "<Podpowiedzi dolnego menu>\n" +
                    "Money View dodaje trendy pieniędzy/populacji i szczegóły po najechaniu.\n\n" +
                    "<Własny kamień milowy>\n" +
                    "Ustaw pieniądze początkowe i kamień milowy przed wczytaniem lub startem miasta."
                },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.UsageText)), "" },

                // --------------------------------------------------------------------
                // Actions tab - Notifications
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleNotificationsKeyboardBinding)), "Przełącz ikony alertów" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleNotificationsKeyboardBinding)),
                    "<Skrót> dla tej samej akcji co przycisk <[TOGGLE ALL]> w grze.\n" +
                    "Natychmiast pokazuje lub ukrywa wszystkie ikony z listy." },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleNotificationsAction), "Pokaż/ukryj wszystkie ikony alertów" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleNotificationPanelKeyboardBinding)), "Otwórz/zamknij panel alertów" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleNotificationPanelKeyboardBinding)),
                    "<Skrót> do otwierania lub zamykania\n" +
                    "<panelu alertów> w mieście.\n" +
                    "Działa jak kliknięcie ikony w lewym górnym rogu."
                },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleNotificationPanelAction), "Otwórz/zamknij panel alertów" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.PanelButtonsOnlyStart)), "Start tylko z przyciskami" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.PanelButtonsOnlyStart)),
                    "Gdy włączone [ ✓ ], City Watchdog otwiera się najpierw jako mały widok przycisków.\n" +
                    "Użyj strzałki tytułu lub licznika wierszy, aby rozwinąć panel." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleRoadNamesKeyboardBinding)), "Ukryj/pokaż nazwy dróg" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleRoadNamesKeyboardBinding)),
                    "<Skrót> do ukrycia/pokazania nazw dróg vanilla.\n" +
                    "To samo co ikona Nazwy dróg w panelu City Watchdog." },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleRoadNamesAction), "Ukryj/pokaż nazwy dróg" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleAllTooltipsKeyboardBinding)), "Wyłącz wszystkie podpowiedzi myszy" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleAllTooltipsKeyboardBinding)),
                    "<Skrót> do ukrycia/pokazania WSZYSTKICH podpowiedzi gry.\n" +
                    "<Popupy pieniędzy/populacji City Watchdog zostają aktywne>; steruje nimi Money View.\n" +
                    "To samo co ikona [i] w panelu City Watchdog." },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleAllTooltipsAction), "Ukryj/pokaż podpowiedzi gry" },

                // --------------------------------------------------------------------
                // Actions tab - In-City Info Viewer
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyView)), "Pokaż podpowiedzi pieniędzy + populacji" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyView)),
                    "<Zalecane>\n" +
                    "Dolne menu: pokazuje trendy przy strzałkach pieniędzy i populacji.\n" +
                    "Lekkie narzędzie po najechaniu <tylko wyświetlanie>;\n" +
                    "Oszczędza otwieranie panelu informacji gry."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyViewMode)), "Częstotliwość Money View" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyViewMode)),
                    "Wybierz trendy godzinowe lub miesięczne w dolnym menu.\n" +
                    "Miesięcznie = dochód minus wydatki i prognoza populacji 24 h." },
                { m_Settings.GetOptionLocaleID("MoneyViewModeHourly"), "Godzinowo (/h)" },
                { m_Settings.GetOptionLocaleID("MoneyViewModeMonthly"), "Miesięcznie (/mo)" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyTooltipMode)), "Styl podpowiedzi pieniędzy" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyTooltipMode)),
                    "Wybierz ilość szczegółów w podpowiedzi pieniędzy.\n" +
                    "Kompakt = domyślne przy pierwszej instalacji.\n" +
                    "<Mini> pokazuje tylko 2 wartości netto /mo i /h.\n" +
                    "<Kompakt> skraca duże liczby (15.21M zamiast 15,212,318).\n" +
                    "<Pełne dane> pokazuje długie wartości i sumy." },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeMini"), "Mini" },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeCompact"), "Kompakt" },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeFullData"), "Pełne dane" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyTooltipFontScale)), "Rozmiar czcionki pieniędzy" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyTooltipFontScale)),
                    "Zmienia <rozmiar czcionki> liczb Money View.\n" +
                    "Domyślne gry = 100%\n" +
                    "<Domyślne moda = 120%>\n" +
                    "Najedź na pieniądze na dole ekranu.\n" +
                    "Dla graczy, którym trudno czytać małe podpowiedzi."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.PopulationTooltipFontScale)), "Rozmiar czcionki populacji" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.PopulationTooltipFontScale)),
                    "Zmienia <rozmiar czcionki> liczb populacji.\n" +
                    "Domyślne gry = 100%\n" +
                    "<Domyślne moda = 120%>\n" +
                    "Najedź na populację na dole ekranu."
                },

                // --------------------------------------------------------------------
                // Mini-HUD tab - Mini HUD Notifications
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudEnabled)), "Mini HUD" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudEnabled)),
                    "Pokazuje mały HUD z ważnymi licznikami alertów.\n" +
                    "Szybki pasek alertów bez otwierania pełnego panelu.\n" +
                    "Kliknięcie ikony skacze do pasującego problemu.\n" +
                    "Kolejne kliknięcia przełączają następne miejsca i wracają do pierwszego."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ApplyMiniHudRecommendedPreset)), "Zalecany zestaw startowy" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ApplyMiniHudRecommendedPreset)),
                    "Stosuje zalecane ustawienia Mini HUD:\n" +
                    "Ulubione, 5 ikon, poziomo, góra środek, 100%, ciemny panel.\n" +
                    "Alerty z zerem zostają widoczne.\n" +
                    "Dodawaj/usuwaj ulubione **Niebieską gwiazdką** w pełnym panelu.\n" +
                    "Startowe **Niebieskie gwiazdki** są w **[Zalecane]**."
                  },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudMode)), "Tryb Mini HUD" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudMode)),
                    "Wybierz wiersze używane przez Mini HUD.\n" +
                    "**Najaktywniejsze** pokazuje najwyższe aktualne liczniki.\n" +
                    "**Ulubione** obejmuje wiersze z **Niebieską gwiazdką**.\n" +
                    "Możesz wybrać dowolnie dużo ulubionych,\n" +
                    "ale Mini HUD pokaże tylko top 5 lub top 10 liczników z tej listy." },
                { m_Settings.GetOptionLocaleID("MiniHudModeTopActive"), "Najaktywniejsze alerty" },
                { m_Settings.GetOptionLocaleID("MiniHudModeFavorites"), "Ulubione" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudItemCount)), "Liczba ikon Mini HUD" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudItemCount)),
                    "Wybierz, ile ikon może pokazać Mini HUD." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudScale)), "Rozmiar Mini HUD" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudScale)),
                    "Skaluje ikony i liczby Mini HUD.\n" +
                    "90% = kompakt. 100% = domyślne. Do 130% dla lepszej widoczności." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudOrientation)), "Orientacja Mini HUD" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudOrientation)),
                    "Wybierz rząd lub kolumnę." },
                { m_Settings.GetOptionLocaleID("MiniHudOrientationHorizontal"), "Poziomo" },
                { m_Settings.GetOptionLocaleID("MiniHudOrientationVertical"), "Pionowo" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudPlacement)), "Pozycja Mini HUD" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudPlacement)),
                    "Wybierz miejsce Mini HUD.\n" +
                    "Przeciąganie pozwala przesuwać go w UI miasta." },
                { m_Settings.GetOptionLocaleID("MiniHudPlacementTopCenter"), "Góra środek" },
                { m_Settings.GetOptionLocaleID("MiniHudPlacementTopRight"), "Góra prawa" },
                { m_Settings.GetOptionLocaleID("MiniHudPlacementDraggable"), "Przeciągalny" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudPanelStyle)), "Styl Mini HUD" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudPanelStyle)),
                    "Wybierz tło Mini HUD.\n" +
                    "Szkło przechodzi od przezroczystego do białawego; nie ciemnieje.\n" +
                    "Ciemny panel daje ciemniejszy styl vanilla." },
                { m_Settings.GetOptionLocaleID("MiniHudPanelStyleDark"), "Ciemny panel" },
                { m_Settings.GetOptionLocaleID("MiniHudPanelStyleGlass"), "Szklany panel" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudPanelOpacity)), "Przezroczystość Mini HUD" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudPanelOpacity)),
                    "Zmienia przezroczystość tła.\n" +
                    "Niżej = bardziej przezroczyste. Wyżej = bardziej pełne.\n" +
                    "Szkło robi się bielsze; ciemne robi się pełniejsze/ciemniejsze." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudHideZero)), "Ukryj alerty zerowe" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudHideZero)),
                    "Gdy włączone [ ✓ ], Mini HUD ukrywa wiersze z liczbą 0." },

                // --------------------------------------------------------------------
                // Money-Milestones tab - New City Start Settings
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.InitialMoney)), "Pieniądze początkowe" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.InitialMoney)),
                    "Ustawia saldo startowe dla nowego miasta z <ograniczonymi pieniędzmi>,\n" +
                    "potem wraca do domyślnych gry.\n" +
                    "Wyszarzone, gdy miasto jest już wczytane.\n" +
                    "Ustaw przed startem/wczytaniem. Potem używaj <Kwoty skrótu pieniędzy> lub <Automatycznych pieniędzy>." },
                { m_Settings.GetOptionLocaleID("GameDefault"), "Domyślne gry" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.CustomMilestone)), "Wybór kamienia milowego" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.CustomMilestone)),
                    "Włącz <przed wczytaniem lub startem>, aby odblokować kamień po wczytaniu.\n" +
                    "- Nie można włączyć po wczytaniu miasta, ale można wyłączyć.\n" +
                    "- Jeśli zapomnisz, zrestartuj grę i wybierz przed wejściem do miasta.\n" +
                    "- Mod nie cofnie zmian zapisanych w mieście; użyj starszego zapisu."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MilestoneLevel)), "Kamień milowy" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MilestoneLevel)),
                    "Wybierz kamień do odblokowania przy następnym wczytaniu.\n" +
                    "Dostępne <tylko poza wczytanym miastem> i po włączeniu [Wybór kamienia] [ ✓ ].\n" +
                    "Jeśli miasto już go ma lub jest dalej, nic się nie stanie.\n" +
                    "Zmiana tylko, gdy wybrany kamień jest wyższy."
                },

                // --------------------------------------------------------------------
                // Money-Milestones tab - Money
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ManualMoneyAmount)), "Kwota skrótu pieniędzy" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ManualMoneyAmount)),
                    "Użyj tej kwoty ze skrótami Dodaj/Odejmij pieniądze.\n" +
                    "<Domyślne moda = 40 000>\n" +
                    "Nic nie robi bez użycia skrótu w mieście.\n" +
                    "Dla automatu włącz Automatyczne pieniądze."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AddMoneyKeyboardBinding)), "Dodaj pieniądze" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AddMoneyKeyboardBinding)),
                    "Skrót do <Dodaj pieniądze> w mieście." },
                { m_Settings.GetBindingKeyLocaleID(Setting.AddMoneyAction), "Dodaj pieniądze" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.SubtractMoneyKeyboardBinding)), "Odejmij pieniądze" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.SubtractMoneyKeyboardBinding)),
                    "Skrót do <Odejmij pieniądze> w mieście." },
                { m_Settings.GetBindingKeyLocaleID(Setting.SubtractMoneyAction), "Odejmij pieniądze" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoney)), "Automatyczne dodawanie pieniędzy" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoney)),
                    "Gdy włączone [ ✓ ], City Watchdog sprawdza saldo miasta.\n" +
                    "- Jeśli saldo jest <poniżej progu>, \n" +
                    "  dodaje wybraną kwotę.\n" +
                    "- Lepiej używać ręcznie skrótów (<[> lub <]>) w razie potrzeby" +
                    "  zamiast automatu, ale opcja jest dostępna."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoneyThreshold)), "Próg automatycznych pieniędzy" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoneyThreshold)),
                    "Jeśli automat jest włączony i saldo spadnie poniżej tej wartości,\n" +
                    "dodaje wybraną kwotę." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoneyAmount)), "Kwota automatyczna" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoneyAmount)),
                    "Kwota dodawana przy każdym automacie.\n" +
                    "Wybierz dość dużo, aby bezpiecznie przekroczyć próg." },

                // --------------------------------------------------------------------
                // Money-Milestones tab - Save Conversion
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ConfirmUnlimitedMoneySaveConversion)), "Konwerter Unlimited Money" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ConfirmUnlimitedMoneySaveConversion)),
                    "<Najpierw zrób kopię zapisu>.\n" +
                    "Konwertuje miasto zaczęte z Unlimited Money na normalne miasto.\n" +
                    "Odblokowuje przycisk <[Konwertuj zapis Unlimited Money]>, gdy wczytane miasto ma typ <Unlimited Money>.\n" +
                    "City Watchdog nie może cofnąć konwersji.\n" +
                    "Dla normalnych miast nie jest potrzebne." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)), "Konwertuj miasto Unlimited Money na normalne" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)),
                    "Dla miast rozpoczętych z <Unlimited Money>.\n" +
                    "Gdy miasto jest wczytane, zmienia zapis na normalny budżet.\n" +
                    "Przycisk jest <wyłączony/wyszarzony>, chyba że miasto ma typ <Unlimited Money>\n" +
                    "i <Konwerter Unlimited Money> jest WŁ. [ ✓ ].\n" +
                    "Zrób kopię i używaj na własne ryzyko; City Watchdog nie cofnie tego." },

                { m_Settings.GetOptionWarningLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)),
                    "Konwertować to miasto z Unlimited Money na normalne ograniczone pieniądze?\n" +
                    "Najpierw zrób kopię; City Watchdog nie cofnie tego.\n" +
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
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.WriteNotificationAuditLog)),
                    "<Niepotrzebne w normalnej grze.>\n" +
                    "Dla testerów i po patchach: zapisuje raport <Logs/CityWatchdog.log>\n" +
                    "porównując prefaby powiadomień gry z ikonami kontrolowanymi przez Watchdog." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.OpenLog)), "Otwórz log" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.OpenLog)),
                    "Otwiera </Logs/CityWatchdog.log>, jeśli istnieje.\n" +
                    "Jeśli go nie ma, otwiera folder Logs/." },
            };

            return entries;
        }

        public void Unload()
        {
        }
    }
}
