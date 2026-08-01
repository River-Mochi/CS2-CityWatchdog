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

    public sealed class LocalePL : IDictionarySource
    {
        private readonly CwdSettings m_Settings;

        public LocalePL(CwdSettings setting)
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
                { m_Settings.GetOptionTabLocaleID(CwdSettings.Actions), "Akcje" },
                { m_Settings.GetOptionTabLocaleID(CwdSettings.MiniHudTab), "Mini-HUD" },
                { m_Settings.GetOptionTabLocaleID(CwdSettings.MoneyTab), "Start miasta" },
                { m_Settings.GetOptionTabLocaleID(CwdSettings.About), "O modzie" },
                { m_Settings.GetOptionGroupLocaleID(CwdSettings.AboutUsage), "UŻYCIE" },
                { m_Settings.GetOptionGroupLocaleID(CwdSettings.Notifications), "Powiadomienia" },
                { m_Settings.GetOptionGroupLocaleID(CwdSettings.MoneyViewGroup), "Info w mieście" },
                { m_Settings.GetOptionGroupLocaleID(CwdSettings.MiniHudGroup), "Alerty Mini HUD" },
                { m_Settings.GetOptionGroupLocaleID(CwdSettings.Milestone), "START NOWEGO MIASTA" },
                { m_Settings.GetOptionGroupLocaleID(CwdSettings.Money), "Pieniądze" },
                { m_Settings.GetOptionGroupLocaleID(CwdSettings.SaveConversion), "Konwersja zapisu bez limitu" },
                { m_Settings.GetOptionGroupLocaleID(CwdSettings.AboutInfo), "" },
                { m_Settings.GetOptionGroupLocaleID(CwdSettings.AboutLinks), "" },
                { m_Settings.GetOptionGroupLocaleID(CwdSettings.AboutDiagnostics), "DIAGNOSTYKA" },
                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.ShowUsage)), "Pokaż instrukcje" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.ShowUsage)), "Pokazuje lub ukrywa instrukcje poniżej." },
                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.UsageText)),
                    "A. Kliknij ikonę łapy w lewym górnym rogu miasta albo naciśnij Shift+N, aby otworzyć panel.\n" +
                    "<Przełączniki widoku>\n" +
                    "1. Ikona na pasku tytułu: pokaż/ukryj podpowiedzi City Watchdog.\n" +
                    "\n" +
                    "2. Przycisk **[i]**: ukryj/pokaż <WSZYSTKIE> podpowiedzi gry: budynki, mieszkańcy, narzędzia, dolne menu.\n" +
                    "3. Przycisk dróg: ukryj/pokaż nazwy dróg. Skrót: \\.\n" +
                    "4. Przycisk dzielnic: ukryj/pokaż nazwy dzielnic.\n" +
                    "5. Przycisk strzałek: wymusza pokazanie/ukrycie strzałek jednokierunkowych (ukrywa też nazwy dróg).\n" +
                    "\n" +
                    "<Alerty>\n" +
                    "1. Sortowanie: A→Z, Z→A, tylko aktywne.\n" +
                    "2. <[0/62]> = widoczne ikony/razem. Klik: rozwiń/zwiń wszystkie wiersze.\n" +
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
                    "Start miasta > START NOWEGO MIASTA ustawia startowe pieniądze lub kamienie przed wczytaniem/startem." },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.UsageText)), "" },
                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.ToggleNotificationsKeyboardBinding)), "Przełącz ikony alertów" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.ToggleNotificationsKeyboardBinding)),
                    "<Skrót> działa jak przycisk <[Przełącz wszystko]> w grze.\n" +
                    "Od razu pokazuje lub ukrywa wszystkie wymienione ikony alertów." },
                { m_Settings.GetBindingKeyLocaleID(CwdSettings.ToggleNotificationsAction), "Pokaż/ukryj wszystkie ikony alertów" },
                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.ToggleNotificationPanelKeyboardBinding)), "Otwórz/zamknij panel alertów" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.ToggleNotificationPanelKeyboardBinding)),
                    "<Skrót> do otwierania lub zamykania\n" +
                    "<panelu alertów> w mieście.\n" +
                    "Jak kliknięcie ikony w lewym górnym rogu." },
                { m_Settings.GetBindingKeyLocaleID(CwdSettings.ToggleNotificationPanelAction), "Otwórz/zamknij panel alertów" },
                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.PanelButtonsOnlyStart)), "Start tylko z przyciskami" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.PanelButtonsOnlyStart)),
                    "Gdy włączone [ ✓ ], City Watchdog otwiera mały widok tylko z przyciskami.\n" +
                    "Strzałka tytułu lub licznik wierszy otwiera pełny panel." },
                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.ToggleRoadNamesKeyboardBinding)), "Ukryj/pokaż nazwy dróg" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.ToggleRoadNamesKeyboardBinding)),
                    "<Skrót> natychmiast ukrywa/pokazuje nazwy dróg z gry.\n" +
                    "Jak ikona nazw dróg w panelu City Watchdog." },
                { m_Settings.GetBindingKeyLocaleID(CwdSettings.ToggleRoadNamesAction), "Ukryj/pokaż nazwy dróg" },
                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.ToggleAllTooltipsKeyboardBinding)), "Wyłącz wszystkie podpowiedzi" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.ToggleAllTooltipsKeyboardBinding)),
                    "<Skrót> ukrywa/pokazuje WSZYSTKIE podpowiedzi gry: budynki, mieszkańcy, narzędzia i dolne ikony.\n" +
                    "<Okna pieniędzy/populacji City Watchdog zostają>; steruje nimi Widok pieniędzy.\n" +
                    "Jak ikona [i] w panelu City Watchdog." },
                { m_Settings.GetBindingKeyLocaleID(CwdSettings.ToggleAllTooltipsAction), "Ukryj/pokaż podpowiedzi gry" },
                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.MainPanelOpacity)), "Krycie głównego panelu" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.MainPanelOpacity)),
                    "Dostosowuje przezroczystość tła głównego panelu powiadomień.\n" +
                    "Niższe wartości zwiększają przezroczystość. Wyższe dają ciemniejsze, bardziej kryjące tło." },
                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.MoneyView)), "Trendy pieniędzy + populacji" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.MoneyView)),
                    "<Zalecane>\n" +
                    "Dolne menu: pokazuje trendy przy strzałkach <pieniędzy i populacji>.\n" +
                    "Lekka funkcja po najechaniu <tylko widok>;\n" +
                    "oszczędza czas i może działać lepiej niż panel informacji gry." },
                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.MoneyViewMode)), "Częstotliwość Widoku pieniędzy" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.MoneyViewMode)),
                    "Wybierz wartości godzinowe lub miesięczne w dolnym pasku.\n" +
                    "Miesięcznie używa dochodów minus wydatki i prognozy populacji 24 h." },
                { m_Settings.GetOptionLocaleID("MoneyViewModeHourly"), "Godzinowo (/h)" },
                { m_Settings.GetOptionLocaleID("MoneyViewModeMonthly"), "Miesięcznie (/mo)" },
                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.MoneyTooltipMode)), "Styl podpowiedzi pieniędzy" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.MoneyTooltipMode)),
                    "Wybierz ilość szczegółów w podpowiedzi pieniędzy.\n" +
                    "Kompakt = domyślnie po instalacji.\n" +
                    "<Mini> pokazuje tylko 2 wartości netto dla /mo i /h.\n" +
                    "<Kompakt> skraca duże liczby (15.21M zamiast 15,212,318).\n" +
                    "<Pełne dane> pokazuje długie wartości i sumy." },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeMini"), "Mini" },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeCompact"), "Kompakt" },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeFullData"), "Pełne dane" },
                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.MoneyTooltipFontScale)), "Rozmiar tekstu pieniędzy" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.MoneyTooltipFontScale)),
                    "Zmienia <rozmiar tekstu> liczb Widoku pieniędzy.\n" +
                    "Domyślnie gra = 100%\n" +
                    "<Domyślnie mod = 120%>\n" +
                    "Najedź na Pieniądze na dole ekranu.\n" +
                    "Dla graczy, którym małe podpowiedzi są trudne do czytania." },
                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.PopulationTooltipFontScale)), "Rozmiar tekstu populacji" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.PopulationTooltipFontScale)),
                    "Zmienia <rozmiar tekstu> liczb populacji.\n" +
                    "Domyślnie gra = 100%\n" +
                    "<Domyślnie mod = 120%>\n" +
                    "Najedź na Populację na dole ekranu." },
                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.MiniHudEnabled)), "Mini HUD" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.MiniHudEnabled)),
                    "Pokazuje mały HUD z najważniejszymi licznikami alertów.\n" +
                    "Szybki pasek alertów bez otwierania pełnego panelu.\n" +
                    "Kliknięcie ikony przenosi do pasującego problemu.\n" +
                    "Kolejne kliknięcia przełączają pasujące miejsca i wracają do pierwszego." },
                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.ApplyMiniHudRecommendedPreset)), "Klik: szybki start" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.ApplyMiniHudRecommendedPreset)),
                    "Stosuje <szybki start> dla mini panelu:\n" +
                    "Zawiera **początkowy wybór niebieskich gwiazdek**.\n" +
                    "Alert z **niebieską gwiazdką** może pojawić się w mini panelu, jeśli należy do 5 lub 10 najwyższych według łącznej liczby.\n" +
                    "Dodawaj/usuwaj **niebieskie gwiazdki** w rozwiniętym panelu Watchdog.\n" +
                    "Ustawienie zawiera: Ulubione, 5 ikon, pionowo, przeciągane, rozmiar 100 %, ciemny panel i ukryte ikony z liczbą 0."
                  },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.MiniHudMode)), "Tryb mini panelu" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.MiniHudMode)),
                    "Wybierz, które wiersze alertów ma używać mini panel.\n" +
                    "**Najaktywniejsze** pokazuje najwyższe bieżące liczniki.\n" +
                    "**Ulubione** używa wierszy z **niebieską gwiazdką** w głównym panelu City Watchdog.\n" +
                    "Możesz wybrać tyle ulubionych, ile chcesz,\n" +
                    "ale mini panel pokaże tylko 5 lub 10 najwyższych liczników z tej listy **niebieskich gwiazdek**."
                  },
                { m_Settings.GetOptionLocaleID("MiniHudModeTopActive"), "Najaktywniejsze alerty" },
                { m_Settings.GetOptionLocaleID("MiniHudModeFavorites"), "Ulubione" },
                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.MiniHudItemCount)), "Liczba ikon" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.MiniHudItemCount)), "Wybierz, ile ikon może pokazać Mini HUD." },
                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.MiniHudScale)), "Rozmiar ikon" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.MiniHudScale)),
                    "Skaluje ikony i liczby Mini HUD.\n" +
                    "90% = kompakt. 100% = domyślnie. Do 130% dla lepszej widoczności." },
                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.MiniHudOrientation)), "Układ" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.MiniHudOrientation)), "Wybierz wiersz lub kolumnę." },
                { m_Settings.GetOptionLocaleID("MiniHudOrientationHorizontal"), "Poziomo" },
                { m_Settings.GetOptionLocaleID("MiniHudOrientationVertical"), "Pionowo" },
                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.MiniHudPlacement)), "Pozycja HUD" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.MiniHudPlacement)),
                    "Wybierz, gdzie pojawia się Mini HUD.\n" +
                    "Przeciągany pozwala przesuwać go w interfejsie miasta." },
                { m_Settings.GetOptionLocaleID("MiniHudPlacementTopCenter"), "Góra środek" },
                { m_Settings.GetOptionLocaleID("MiniHudPlacementTopRight"), "Góra prawo" },
                { m_Settings.GetOptionLocaleID("MiniHudPlacementDraggable"), "Przeciągany" },
                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.MiniHudPanelStyle)), "Styl ciemny lub szkło" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.MiniHudPanelStyle)),
                    "Wybierz tło Mini HUD.\n" +
                    "Szkło przechodzi od czystego do mlecznego; nie robi się ciemniejsze.\n" +
                    "Ciemny panel daje ciemniejszy HUD w stylu gry." },
                { m_Settings.GetOptionLocaleID("MiniHudPanelStyleDark"), "Ciemny panel" },
                { m_Settings.GetOptionLocaleID("MiniHudPanelStyleGlass"), "Szklany panel" },
                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.MiniHudPanelOpacity)), "Krycie tła" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.MiniHudPanelOpacity)),
                    "Reguluje przezroczystość tła Mini HUD.\n" +
                    "Niżej = bardziej przezroczyste. Wyżej = bardziej pełne.\n" +
                    "Szkło robi się bielsze. Ciemny panel bardziej ciemny/pełny." },
                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.MiniHudHideZero)), "Ukryj alerty 0" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.MiniHudHideZero)), "Gdy włączone [ ✓ ], Mini HUD ukrywa wiersze z licznikiem 0." },
                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.InitialMoney)), "Pieniądze startowe" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.InitialMoney)),
                    "Ustawia saldo startowe dla nowego miasta z <ograniczonymi pieniędzmi> lub pierwszego wczytanego miasta,\n" +
                    "potem wraca do domyślnego gry.\n" +
                    "Wyszarzone, jeśli miasto jest już wczytane.\n" +
                    "Ustaw przed startem/wczytaniem. Potem użyj <Kwoty skrótu pieniędzy> lub <Automatycznych pieniędzy>." },
                { m_Settings.GetOptionLocaleID("GameDefault"), "Domyślne gry" },
                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.CustomMilestone)), "Wybór kamienia milowego" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.CustomMilestone)),
                    "Włącz <przed wczytaniem lub startem>, aby odblokować wybrany kamień po wczytaniu.\n" +
                    "- Nie da się włączyć w już wczytanym mieście, ale da się wyłączyć.\n" +
                    "- Jeśli zapomniano, uruchom grę ponownie i wybierz przed wejściem do miasta.\n" +
                    "- Mod nie cofa zmian zapisanych w mieście; użyj starszego zapisu." },
                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.MilestoneLevel)), "Kamień milowy" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.MilestoneLevel)),
                    "Wybierz kamień milowy do odblokowania przy następnym wczytaniu.\n" +
                    "Dostępne <tylko poza wczytanym miastem> i z [Wybór kamienia] aktywnym [ ✓ ].\n" +
                    "Jeśli miasto już jest na tym poziomie lub wyżej, nic się nie stanie.\n" +
                    "Zmiana tylko, gdy wybrany kamień jest wyższy." },
                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.ManualMoneyAmount)), "Kwota skrótu pieniędzy" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.ManualMoneyAmount)),
                    "Użyj tej kwoty z klawiszami Dodaj i Odejmij pieniądze.\n" +
                    "<Domyślnie mod = 40 000>\n" +
                    "Nic nie robi bez użycia skrótu w mieście.\n" +
                    "Do automatyzacji włącz Automatyczne pieniądze." },
                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.AddMoneyKeyboardBinding)), "Dodaj pieniądze" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.AddMoneyKeyboardBinding)), "Skrót do <Dodaj pieniądze> w mieście." },
                { m_Settings.GetBindingKeyLocaleID(CwdSettings.AddMoneyAction), "Dodaj pieniądze" },
                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.SubtractMoneyKeyboardBinding)), "Odejmij pieniądze" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.SubtractMoneyKeyboardBinding)), "Skrót do <Odejmij pieniądze> w mieście." },
                { m_Settings.GetBindingKeyLocaleID(CwdSettings.SubtractMoneyAction), "Odejmij pieniądze" },
                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.AutomaticAddMoney)), "Automatyczne pieniądze" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.AutomaticAddMoney)),
                    "Gdy włączone [ ✓ ], City Watchdog sprawdza saldo miasta.\n" +
                    "- Jeśli saldo jest <poniżej progu>,\n" +
                    "  dodaje wybraną kwotę.\n" +
                    "- Zalecane raczej ręcznie skrótem (<[> lub <]>) w razie potrzeby\n" +
                    "  zamiast automatu; opcja jest, jeśli chcesz." },
                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.AutomaticAddMoneyThreshold)), "Próg automatycznych pieniędzy" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.AutomaticAddMoneyThreshold)),
                    "Jeśli włączone i saldo spadnie poniżej tej wartości,\n" +
                    "dodaje wybraną kwotę." },
                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.AutomaticAddMoneyAmount)), "Kwota automatyczna" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.AutomaticAddMoneyAmount)),
                    "Kwota dodawana przy każdym automatycznym uruchomieniu.\n" +
                    "Wybierz tyle, by bezpiecznie przekroczyć próg." },
                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.ConfirmUnlimitedMoneySaveConversion)), "Konwerter pieniędzy bez limitu" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.ConfirmUnlimitedMoneySaveConversion)),
                    "<Najpierw zrób kopię zapasową miasta>.\n" +
                    "Konwertuje miasto zaczęte z pieniędzmi bez limitu na normalne miasto.\n" +
                    "Włączenie odblokuje <[Konwertuj zapis bez limitu]> gdy wczytane miasto jest typu <Bez limitu pieniędzy>.\n" +
                    "City Watchdog nie może tego cofnąć.\n" +
                    "Dla normalnych miast niepotrzebne." },
                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.ConvertUnlimitedMoneySave)), "Konwertuj miasto bez limitu na normalne" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.ConvertUnlimitedMoneySave)),
                    "Dla miast zaczętych z <Pieniędzmi bez limitu>.\n" +
                    "Gdy to miasto jest wczytane, zapis przechodzi na normalny ograniczony budżet.\n" +
                    "Przycisk jest <wyłączony/szary>, chyba że miasto jest typu <Bez limitu pieniędzy>\n" +
                    "i <Konwerter pieniędzy bez limitu> jest WŁĄCZONY [ ✓ ].\n" +
                    "Zrób kopię zapasową i używaj na własne ryzyko; City Watchdog nie cofa." },
                { m_Settings.GetOptionWarningLocaleID(nameof(CwdSettings.ConvertUnlimitedMoneySave)),
                    "Konwertować to miasto z pieniędzy bez limitu na normalne ograniczone pieniądze?\n" +
                    "Najpierw zapisz kopię zapasową; City Watchdog nie może cofnąć.\n" +
                    "Na pewno?" },
                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.NameText)), "Nazwa moda" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.NameText)), "Wyświetlana nazwa tego moda." },
                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.VersionText)), "Wersja" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.VersionText)), "Aktualna wersja moda." },
                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.OpenParadox)), "Paradox Mods" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.OpenParadox)), "Otwiera stronę autora w Paradox Mods." },
                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.WriteNotificationAuditLog)), "Raport diagnostyczny" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.WriteNotificationAuditLog)),
                    "<Niepotrzebne do normalnej gry.>\n" +
                    "Do testów i kontroli po aktualizacjach gry: zapisuje raport w <Logs/CityWatchdog.log>\n" +
                    "porównujący alerty gry z ikonami kontrolowanymi przez Watchdog." },
                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.OpenLog)), "Otwórz dziennik" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.OpenLog)),
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
