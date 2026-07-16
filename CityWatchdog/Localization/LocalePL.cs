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
            string title = Mod.ModName + " (Strażnik miasta)";

            Dictionary<string, string> entries = new Dictionary<string, string>
            {
                { m_Settings.GetSettingsLocaleID(), title },
                { m_Settings.GetOptionTabLocaleID(Setting.Actions), "Akcje" },
                { m_Settings.GetOptionTabLocaleID(Setting.MiniHudTab), "Mini-HUD" },
                { m_Settings.GetOptionTabLocaleID(Setting.MoneyTab), "Pieniądze-Kamienie milowe" },
                { m_Settings.GetOptionTabLocaleID(Setting.About), "O modzie" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutUsage), "UŻYCIE" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Notifications), "Powiadomienia" },
                { m_Settings.GetOptionGroupLocaleID(Setting.MoneyViewGroup), "Info w mieście" },
                { m_Settings.GetOptionGroupLocaleID(Setting.MiniHudGroup), "Alerty Mini HUD" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Milestone), "START NOWEGO MIASTA" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Money), "Pieniądze" },
                { m_Settings.GetOptionGroupLocaleID(Setting.SaveConversion), "Konwersja zapisu bez limitu" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutInfo), "" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutLinks), "" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutDiagnostics), "DIAGNOSTYKA" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ShowUsage)), "Pokaż instrukcje" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ShowUsage)), "Pokazuje lub ukrywa instrukcje poniżej." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.UsageText)),
                    "A. Kliknij ikonę łapy w lewym górnym rogu miasta albo naciśnij Shift+N, aby otworzyć panel.\n" +
                    "<Przełączniki widoku>\n" +
                    "1. Ikona na pasku tytułu: pokaż/ukryj podpowiedzi City Watchdog.\n" +
                    "\n" +
                    "2. Przycisk **[i]**: ukryj/pokaż <WSZYSTKIE> podpowiedzi gry: budynki, mieszkańcy, narzędzia, dolne menu.\n" +
                    "3. Przycisk dróg: ukryj/pokaż nazwy dróg. Skrót: \\.\n" +
                    "4. Przycisk dzielnic: ukryj/pokaż nazwy dzielnic.\n" +
                    "5. Przycisk strzałek: wymusza strzałki jednokierunkowe ON/OFF (ukrywa też nazwy dróg).\n" +
                    "\n" +
                    "<Alerty>\n" +
                    "1. Sortowanie: A→Z, Z→A, tylko aktywne.\n" +
                    "2. <[0/62]> = ikony ON/razem. Klik: rozwiń/zwiń wszystkie wiersze.\n" +
                    "3a. [Przełącz wszystko] od razu wyłącza/włącza wszystkie ikony alertów.\n" +
                    "3b. Ukrywa tylko ikony; nie naprawia problemu w mieście.\n" +
                    "\n" +
                    "<Pomoc z pieniędzmi>\n" +
                    "1. Dodaj / odejmij pieniądze: użyj domyślnych klawiszy <[ lub ]> dla <Kwoty skrótu pieniędzy>.\n" +
                    "2. Automatyczne pieniądze dodają środki, gdy miasto spadnie poniżej limitu.\n" +
                    "3. Konwersja zapisu Bez limitu pieniędzy działa tylko dla takich miast i jest <nieodwracalna>.\n" +
                    "\n" +
                    "<Podpowiedzi dolnego menu>\n" +
                    "Widok pieniędzy dodaje szczegóły, np. trendy, po najechaniu na pieniądze lub populację.\n" +
                    "\n" +
                    "<Własny kamień milowy>\n" +
                    "Pieniądze-Kamienie milowe > START NOWEGO MIASTA ustawia startowe pieniądze lub kamienie przed wczytaniem/startem." },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.UsageText)), "" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleNotificationsKeyboardBinding)), "Przełącz ikony alertów" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleNotificationsKeyboardBinding)),
                    "<Skrót> działa jak przycisk <[Przełącz wszystko]> w grze.\n" +
                    "Od razu pokazuje lub ukrywa wszystkie wymienione ikony alertów." },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleNotificationsAction), "Pokaż/ukryj wszystkie ikony alertów" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleNotificationPanelKeyboardBinding)), "Otwórz/zamknij panel alertów" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleNotificationPanelKeyboardBinding)),
                    "<Skrót> do otwierania lub zamykania\n" +
                    "<panelu alertów> w mieście.\n" +
                    "Jak kliknięcie ikony w lewym górnym rogu." },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleNotificationPanelAction), "Otwórz/zamknij panel alertów" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.PanelButtonsOnlyStart)), "Start tylko z przyciskami" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.PanelButtonsOnlyStart)),
                    "Gdy włączone [ ✓ ], City Watchdog otwiera mały widok tylko z przyciskami.\n" +
                    "Strzałka tytułu lub licznik wierszy otwiera pełny panel." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleRoadNamesKeyboardBinding)), "Ukryj/pokaż nazwy dróg" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleRoadNamesKeyboardBinding)),
                    "<Skrót> natychmiast ukrywa/pokazuje nazwy dróg z gry.\n" +
                    "Jak ikona nazw dróg w panelu City Watchdog." },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleRoadNamesAction), "Ukryj/pokaż nazwy dróg" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleAllTooltipsKeyboardBinding)), "Wyłącz wszystkie podpowiedzi" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleAllTooltipsKeyboardBinding)),
                    "<Skrót> ukrywa/pokazuje WSZYSTKIE podpowiedzi gry: budynki, mieszkańcy, narzędzia i dolne ikony.\n" +
                    "<Popupy pieniędzy/populacji City Watchdog zostają>; steruje nimi Widok pieniędzy.\n" +
                    "Jak ikona [i] w panelu City Watchdog." },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleAllTooltipsAction), "Ukryj/pokaż podpowiedzi gry" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyView)), "Trendy pieniędzy + populacji" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyView)),
                    "<Zalecane>\n" +
                    "Dolne menu: pokazuje trendy przy strzałkach <pieniędzy i populacji>.\n" +
                    "Lekka funkcja po najechaniu <tylko widok>;\n" +
                    "oszczędza czas i może działać lepiej niż panel info gry." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyViewMode)), "Częstotliwość Widoku pieniędzy" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyViewMode)),
                    "Wybierz wartości godzinowe lub miesięczne w dolnym pasku.\n" +
                    "Miesięcznie używa dochodów minus wydatki i prognozy populacji 24 h." },
                { m_Settings.GetOptionLocaleID("MoneyViewModeHourly"), "Godzinowo (/h)" },
                { m_Settings.GetOptionLocaleID("MoneyViewModeMonthly"), "Miesięcznie (/mo)" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyTooltipMode)), "Styl podpowiedzi pieniędzy" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyTooltipMode)),
                    "Wybierz ilość szczegółów w podpowiedzi pieniędzy.\n" +
                    "Kompakt = domyślnie po instalacji.\n" +
                    "<Mini> pokazuje tylko 2 wartości netto dla /mo i /h.\n" +
                    "<Kompakt> skraca duże liczby (15.21M zamiast 15,212,318).\n" +
                    "<Pełne dane> pokazuje długie wartości i sumy." },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeMini"), "Mini" },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeCompact"), "Kompakt" },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeFullData"), "Pełne dane" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyTooltipFontScale)), "Rozmiar tekstu pieniędzy" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyTooltipFontScale)),
                    "Zmienia <rozmiar tekstu> liczb Widoku pieniędzy.\n" +
                    "Domyślnie gra = 100%\n" +
                    "<Domyślnie mod = 120%>\n" +
                    "Najedź na Pieniądze na dole ekranu.\n" +
                    "Dla graczy, którym małe podpowiedzi są trudne do czytania." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.PopulationTooltipFontScale)), "Rozmiar tekstu populacji" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.PopulationTooltipFontScale)),
                    "Zmienia <rozmiar tekstu> liczb populacji.\n" +
                    "Domyślnie gra = 100%\n" +
                    "<Domyślnie mod = 120%>\n" +
                    "Najedź na Populację na dole ekranu." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudEnabled)), "Mini HUD" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudEnabled)),
                    "Pokazuje mały HUD z najważniejszymi licznikami alertów.\n" +
                    "Szybki pasek alertów bez otwierania pełnego panelu.\n" +
                    "Kliknięcie ikony przenosi do pasującego problemu.\n" +
                    "Kolejne kliknięcia przełączają pasujące miejsca i wracają do pierwszego." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ApplyMiniHudRecommendedPreset)), "Klik: szybki start" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ApplyMiniHudRecommendedPreset)),
                    "Stosuje <szybki start> dla mini panelu:\n" +
                    "Zawiera **startowy zestaw niebieskich gwiazdek**.\n" +
                    "Alert z **niebieską gwiazdką** może pojawić się w mini panelu, jeśli jest w top 5 lub 10 według łącznej liczby.\n" +
                    "Dodawaj/usuwaj **niebieskie gwiazdki** w rozwiniętym panelu Watchdog.\n" +
                    "Zestaw zawiera: Ulubione, 5 ikon, pionowo, przeciągane, rozmiar 100 %, ciemny panel, ikony z liczbą 0 ukryte."
                  },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudMode)), "Tryb Mini HUD" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudMode)),
                    "Wybierz, które wiersze ma używać Mini HUD.\n" +
                    "**Najaktywniejsze** pokazuje najwyższe bieżące liczniki.\n" +
                    "**Ulubione** używa wierszy z **Blue Star** w głównym panelu City Watchdog.\n" +
                    "Możesz wybrać tyle ulubionych, ile chcesz,\n" +
                    "ale Mini HUD pokaże tylko top 5 lub top 10 z tej listy **Blue Star**."
                  },
                { m_Settings.GetOptionLocaleID("MiniHudModeTopActive"), "Top aktywne alerty" },
                { m_Settings.GetOptionLocaleID("MiniHudModeFavorites"), "Ulubione" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudItemCount)), "Liczba ikon" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudItemCount)), "Wybierz, ile ikon może pokazać Mini HUD." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudScale)), "Rozmiar ikon" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudScale)),
                    "Skaluje ikony i liczby Mini HUD.\n" +
                    "90% = kompakt. 100% = domyślnie. Do 130% dla lepszej widoczności." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudOrientation)), "Układ" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudOrientation)), "Wybierz wiersz lub kolumnę." },
                { m_Settings.GetOptionLocaleID("MiniHudOrientationHorizontal"), "Poziomo" },
                { m_Settings.GetOptionLocaleID("MiniHudOrientationVertical"), "Pionowo" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudPlacement)), "Pozycja HUD" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudPlacement)),
                    "Wybierz, gdzie pojawia się Mini HUD.\n" +
                    "Przeciągany pozwala przesuwać go w UI miasta." },
                { m_Settings.GetOptionLocaleID("MiniHudPlacementTopCenter"), "Góra środek" },
                { m_Settings.GetOptionLocaleID("MiniHudPlacementTopRight"), "Góra prawo" },
                { m_Settings.GetOptionLocaleID("MiniHudPlacementDraggable"), "Przeciągany" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudPanelStyle)), "Styl ciemny lub szkło" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudPanelStyle)),
                    "Wybierz tło Mini HUD.\n" +
                    "Szkło przechodzi od czystego do mlecznego; nie robi się ciemniejsze.\n" +
                    "Ciemny panel daje ciemniejszy HUD w stylu gry." },
                { m_Settings.GetOptionLocaleID("MiniHudPanelStyleDark"), "Ciemny panel" },
                { m_Settings.GetOptionLocaleID("MiniHudPanelStyleGlass"), "Szklany panel" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudPanelOpacity)), "Krycie tła" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudPanelOpacity)),
                    "Reguluje przezroczystość tła Mini HUD.\n" +
                    "Niżej = bardziej przezroczyste. Wyżej = bardziej pełne.\n" +
                    "Szkło robi się bielsze. Ciemny panel bardziej ciemny/pełny." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudHideZero)), "Ukryj alerty 0" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudHideZero)), "Gdy włączone [ ✓ ], Mini HUD ukrywa wiersze z licznikiem 0." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.InitialMoney)), "Pieniądze startowe" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.InitialMoney)),
                    "Ustawia saldo startowe dla nowego miasta z <ograniczonymi pieniędzmi> lub pierwszego wczytanego miasta,\n" +
                    "potem wraca do domyślnego gry.\n" +
                    "Wyszarzone, jeśli miasto jest już wczytane.\n" +
                    "Ustaw przed startem/wczytaniem. Potem użyj <Kwoty skrótu pieniędzy> lub <Automatycznych pieniędzy>." },
                { m_Settings.GetOptionLocaleID("GameDefault"), "Domyślne gry" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.CustomMilestone)), "Wybór kamienia milowego" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.CustomMilestone)),
                    "Włącz <przed wczytaniem lub startem>, aby odblokować wybrany kamień po wczytaniu.\n" +
                    "- Nie da się włączyć w już wczytanym mieście, ale da się wyłączyć.\n" +
                    "- Jeśli zapomniano, uruchom grę ponownie i wybierz przed wejściem do miasta.\n" +
                    "- Mod nie cofa zmian zapisanych w mieście; użyj starszego zapisu." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MilestoneLevel)), "Kamień milowy" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MilestoneLevel)),
                    "Wybierz kamień milowy do odblokowania przy następnym wczytaniu.\n" +
                    "Dostępne <tylko poza wczytanym miastem> i z [Wybór kamienia] aktywnym [ ✓ ].\n" +
                    "Jeśli miasto już jest na tym poziomie lub wyżej, nic się nie stanie.\n" +
                    "Zmiana tylko, gdy wybrany kamień jest wyższy." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ManualMoneyAmount)), "Kwota skrótu pieniędzy" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ManualMoneyAmount)),
                    "Użyj tej kwoty z klawiszami Dodaj i Odejmij pieniądze.\n" +
                    "<Domyślnie mod = 40 000>\n" +
                    "Nic nie robi bez użycia skrótu w mieście.\n" +
                    "Do automatyzacji włącz Automatyczne pieniądze." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AddMoneyKeyboardBinding)), "Dodaj pieniądze" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AddMoneyKeyboardBinding)), "Skrót do <Dodaj pieniądze> w mieście." },
                { m_Settings.GetBindingKeyLocaleID(Setting.AddMoneyAction), "Dodaj pieniądze" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.SubtractMoneyKeyboardBinding)), "Odejmij pieniądze" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.SubtractMoneyKeyboardBinding)), "Skrót do <Odejmij pieniądze> w mieście." },
                { m_Settings.GetBindingKeyLocaleID(Setting.SubtractMoneyAction), "Odejmij pieniądze" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoney)), "Automatyczne pieniądze" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoney)),
                    "Gdy włączone [ ✓ ], City Watchdog sprawdza saldo miasta.\n" +
                    "- Jeśli saldo jest <poniżej progu>,\n" +
                    "  dodaje wybraną kwotę.\n" +
                    "- Zalecane raczej ręcznie skrótem (<[> lub <]>) w razie potrzeby\n" +
                    "  zamiast automatu; opcja jest, jeśli chcesz." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoneyThreshold)), "Próg automatycznych pieniędzy" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoneyThreshold)),
                    "Jeśli włączone i saldo spadnie poniżej tej wartości,\n" +
                    "dodaje wybraną kwotę." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoneyAmount)), "Kwota automatyczna" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoneyAmount)),
                    "Kwota dodawana przy każdym automatycznym uruchomieniu.\n" +
                    "Wybierz tyle, by bezpiecznie przekroczyć próg." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ConfirmUnlimitedMoneySaveConversion)), "Konwerter pieniędzy bez limitu" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ConfirmUnlimitedMoneySaveConversion)),
                    "<Najpierw zrób backup miasta>.\n" +
                    "Konwertuje miasto zaczęte z pieniędzmi bez limitu na normalne miasto.\n" +
                    "Włączenie odblokuje <[Konwertuj zapis bez limitu]> gdy wczytane miasto jest typu <Bez limitu pieniędzy>.\n" +
                    "City Watchdog nie może tego cofnąć.\n" +
                    "Dla normalnych miast niepotrzebne." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)), "Konwertuj miasto bez limitu na normalne" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)),
                    "Dla miast zaczętych z <Pieniędzmi bez limitu>.\n" +
                    "Gdy to miasto jest wczytane, zapis przechodzi na normalny ograniczony budżet.\n" +
                    "Przycisk jest <wyłączony/szary>, chyba że miasto jest typu <Bez limitu pieniędzy>\n" +
                    "i <Konwerter pieniędzy bez limitu> jest ON [ ✓ ].\n" +
                    "Zrób backup i używaj na własne ryzyko; City Watchdog nie cofa." },
                { m_Settings.GetOptionWarningLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)),
                    "Konwertować to miasto z pieniędzy bez limitu na normalne ograniczone pieniądze?\n" +
                    "Najpierw zapisz backup; City Watchdog nie może cofnąć.\n" +
                    "Na pewno?" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.NameText)), "Nazwa moda" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.NameText)), "Wyświetlana nazwa tego moda." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.VersionText)), "Wersja" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.VersionText)), "Aktualna wersja moda." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.OpenParadox)), "Paradox Mods" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.OpenParadox)), "Otwiera stronę autora w Paradox Mods." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.WriteNotificationAuditLog)), "Raport debug do logu" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.WriteNotificationAuditLog)),
                    "<Niepotrzebne do normalnej gry.>\n" +
                    "Dla testerów i po patchach: zapisuje raport w <Logs/CityWatchdog.log>\n" +
                    "porównujący alerty gry z ikonami kontrolowanymi przez Watchdog." },
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
