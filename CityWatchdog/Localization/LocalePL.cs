// <copyright file="LocalePL.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the MIT License. You may not use this file except in compliance with this License.
// See LICENSE file in the project root for full license information.
// This notice and the MIT License notice must be kept with
// all copies or substantial portions of this code.
// ================= </copyright> ======================

//
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
            string title = Mod.ModName + " (Strażnik)";

            Dictionary<string, string> entries = new Dictionary<string, string>
            {
                // --- Mod title ---
                { m_Settings.GetSettingsLocaleID(), title },

                // --- Tabs ---
                { m_Settings.GetOptionTabLocaleID(Setting.Actions), "Akcje" },
                { m_Settings.GetOptionTabLocaleID(Setting.Hotkeys), "Skróty" },
                { m_Settings.GetOptionTabLocaleID(Setting.About), "Informacje" },
                { m_Settings.GetOptionTabLocaleID(Setting.Debug), "Debug" },

                // --- Groups ---
                { m_Settings.GetOptionGroupLocaleID(Setting.MoneyViewGroup), "Podgląd informacji" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Money), "Pieniądze" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Notifications), "Powiadomienia" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Milestone), "Kamień milowy" },
                { m_Settings.GetOptionGroupLocaleID(Setting.SaveConversion), "Konwersja zapisu" },
                { m_Settings.GetOptionGroupLocaleID(Setting.HotkeyActions), "Skróty" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutInfo), "" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutLinks), "" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutDiagnostics), "DIAGNOSTYKA" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutUsage), "UŻYCIE" },

                // --- Money View ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyView)), "Pokaż szczegóły po najechaniu" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyView)),
                    "Pokazuje wartości trendu obok domyślnych strzałek pieniędzy i populacji na dolnym pasku.\n" +
                    "To lekki podgląd po najechaniu na pasek <tylko wyświetlanie>;\n" +
                    "nie zmienia pieniędzy ani populacji miasta." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyViewMode)), "Częstotliwość Money View" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyViewMode)),
                    "Wybierz, czy trend na dolnym pasku pokazuje wartości godzinowe czy miesięczne dla pieniędzy i populacji.\n" +
                    "Miesięczne pieniądze to przychody budżetu minus wydatki, a populacja to prognoza na 24 godziny." },
                { m_Settings.GetOptionLocaleID("MoneyViewModeHourly"), "Godzinowo (/h)" },
                { m_Settings.GetOptionLocaleID("MoneyViewModeMonthly"), "Miesięcznie (/mo)" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyTooltipMode)), "Styl dymka pieniędzy" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyTooltipMode)),
                    "Wybierz, ile szczegółów ma pokazywać dymek pieniędzy po najechaniu.\n" +
                    "Kompaktowy = domyślny przy pierwszej instalacji.\n" +
                    "<Mini> pokazuje tylko 2 wartości netto dla /mo i /h.\n" +
                    "<Kompaktowy> skraca duże wartości (15.21M zamiast 15,212,318).\n" +
                    "<Pełne dane> pokazuje długie wartości i pola Łącznie." },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeMini"), "Mini" },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeCompact"), "Kompaktowy" },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeFullData"), "Pełne dane" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyTooltipFontScale)), "Rozmiar tekstu pieniędzy" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyTooltipFontScale)),
                    "Zmienia <rozmiar tekstu> liczb w dymku Money View.\n" +
                    "Domyślnie w grze = 100%\n" +
                    "<Domyślnie w modzie = 120%>\n" +
                    "Najedź na Pieniądze na dole ekranu.\n" +
                    "Dodane dla graczy, którym trudno czytać małe dymki w grze." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.PopulationTooltipFontScale)), "Rozmiar tekstu populacji" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.PopulationTooltipFontScale)),
                    "Zmienia <rozmiar tekstu> liczb w dymku populacji.\n" +
                    "Domyślnie w grze = 100%\n" +
                    "<Domyślnie w modzie = 120%>\n" +
                    "Najedź na Populację na dole ekranu." },

                // --- Money helpers ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ManualMoneyAmount)), "Kwota skrótu pieniędzy" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ManualMoneyAmount)),
                    "Użyj tej kwoty ze skrótami Dodaj pieniądze i Odejmij pieniądze.\n" +
                    "<Domyślnie w modzie = 40,000>\n" +
                    "Nic nie robi, dopóki nie użyjesz skrótu dodawania/odejmowania pieniędzy w mieście.\n" +
                    "Dla pieniędzy automatycznych włącz opcję Automatyczne dodawanie pieniędzy." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AddMoneyKeyboardBinding)), "Dodaj pieniądze" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AddMoneyKeyboardBinding)), "Skrót do <Dodaj pieniądze> w mieście." },
                { m_Settings.GetBindingKeyLocaleID(Setting.AddMoneyAction), "Dodaj pieniądze" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.SubtractMoneyKeyboardBinding)), "Odejmij pieniądze" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.SubtractMoneyKeyboardBinding)), "Skrót do <Odejmij pieniądze> w mieście." },
                { m_Settings.GetBindingKeyLocaleID(Setting.SubtractMoneyAction), "Odejmij pieniądze" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoney)), "Automatyczne dodawanie pieniędzy" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoney)),
                    "Gdy włączone [ ✓ ], City Watchdog sprawdza saldo miasta, gdy miasto jest wczytane.\n" +
                    "- Jeśli saldo jest <poniżej progu>, \n" +
                    "  dodaje wybraną automatyczną kwotę.\n" +
                    "- Zalecam używać ręcznego skrótu pieniędzy (<[> lub <]>) w razie potrzeby  zamiast tej automatycznej opcji, ale jest dostępna, jeśli jej chcesz." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoneyThreshold)), "Próg automatycznych pieniędzy" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoneyThreshold)),
                    "Jeśli automatyczne dodawanie pieniędzy jest włączone, a saldo miasta spadnie poniżej tej wartości,\n" +
                    "dodaje wybraną automatyczną kwotę." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoneyAmount)), "Kwota automatycznych pieniędzy" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoneyAmount)),
                    "Kwota dodawana za każdym uruchomieniem automatycznego dodawania pieniędzy.\n" +
                    "Wybierz wartość dość dużą, aby bezpiecznie podnieść miasto ponad próg." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.InitialMoney)), "Pieniądze początkowe" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.InitialMoney)),
                    "Ustawia saldo początkowe dla nowego miasta z <ograniczonymi pieniędzmi> albo pierwszego wczytanego miasta,\n" +
                    "a potem wraca do ustawień gry po zastosowaniu.\n" +
                    "Opcja jest wyszarzona, jeśli miasto jest już wczytane.\n" +
                    "Ustaw przed startem/wczytaniem miasta → zadziała raz → potem używaj <Kwoty skrótu pieniędzy> lub <Automatycznego dodawania pieniędzy>." },

                { m_Settings.GetOptionLocaleID("GameDefault"), "Domyślne gry" },

                // --- Notifications ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleNotificationsKeyboardBinding)), "Przełącz ikony powiadomień" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleNotificationsKeyboardBinding)),
                    "<Skrót> dla tej samej akcji co przycisk <[TOGGLE ALL]> w panelu gry.\n" +
                    "Od razu pokazuje lub ukrywa wszystkie wymienione ikony powiadomień miasta." },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleNotificationsAction), "Natychmiast pokaż/ukryj wszystkie ikony powiadomień" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleNotificationPanelKeyboardBinding)), "Otwórz/zamknij panel powiadomień" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleNotificationPanelKeyboardBinding)),
                    "<Skrót> do otwierania lub zamykania\n" +
                    "<panelu powiadomień> w mieście.\n" +
                    "Działa tak samo jak kliknięcie ikony w lewym górnym rogu, aby otworzyć pełny panel." },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleNotificationPanelAction), "Otwórz/zamknij panel powiadomień" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleRoadNamesKeyboardBinding)), "Ukryj/pokaż nazwy dróg" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleRoadNamesKeyboardBinding)),
                    "<Skrót> do natychmiastowego ukrycia lub pokazania domyślnych etykiet nazw dróg w mieście.\n" +
                    "To samo co kliknięcie ikony nazw dróg na pasku panelu City Watchdog." },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleRoadNamesAction), "Ukryj/pokaż nazwy dróg" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.DisableAllTooltips)), "Wyłącz wszystkie dymki po najechaniu" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.DisableAllTooltips)),
                    "Wyłącza dymki gry po najechaniu — te, które podążają za kursorem nad budynkami/mieszkańcami/narzędziami\n" +
                    " oraz małe wyskakujące okna na przyciskach UI gry (nazwy górnego paska, przyciski vanilla itd.).\n" +
                    "<Własne dymki pieniędzy/populacji City Watchdog zostają włączone>; kontroluje je opcja Money View powyżej.\n" +
                    "To samo co kliknięcie ikony [i] w panelu City Watchdog w mieście." },

                // --- Milestone selector ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.CustomMilestone)), "Wybór kamienia milowego" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.CustomMilestone)),
                    "Włącz przed wczytaniem lub rozpoczęciem miasta, aby od razu po wczytaniu odblokować wybrany kamień milowy.\n" +
                    "Nie można włączyć tego podczas wczytanego miasta, ale można wyłączyć, jeśli zostało włączone przez pomyłkę.\n" +
                    "City Watchdog nie może cofnąć zmian kamieni milowych zapisanych już w mieście; w razie potrzeby użyj wcześniejszego zapisu." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MilestoneLevel)), "Kamień milowy" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MilestoneLevel)),
                    "Wybierz poziom kamienia milowego do odblokowania przy następnym wczytaniu miasta.\n" +
                    "Można go zmieniać tylko poza wczytanym miastem i tylko po włączeniu [Wybór kamienia milowego] [ ✓ ]." },

                // --- Save conversion ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ConfirmUnlimitedMoneySaveConversion)), "Konwerter nielimitowanych pieniędzy" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ConfirmUnlimitedMoneySaveConversion)),
                    "<Najpierw zrób kopię zapasową miasta>.\n" +
                    "Konwertuje miasto rozpoczęte z nielimitowanymi pieniędzmi na normalne miasto ze zwykłymi wyzwaniami budżetu.\n" +
                    "Włączenie tego odblokowuje przycisk <[Konwertuj zapis nielimitowanych pieniędzy]>, gdy wczytane miasto jest typu <Nielimitowane pieniądze>.\n" +
                    "City Watchdog nie może cofnąć tej konwersji.\n" +
                    "Jeśli masz normalne miasta, nie przejmuj się tym; nie jest potrzebne." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)), "Zmień zapis z nielimitowanych pieniędzy na normalny" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)),
                    "Dla miast rozpoczętych z <Nielimitowanymi pieniędzmi>.\n" +
                    "Gdy takie miasto jest wczytane, konwertuje zapis na normalny budżet z ograniczonymi pieniędzmi, aby miasto znów miało zwykłe wyzwania finansowe.\n" +
                    "Przycisk jest <wyłączony/wyszarzony>, chyba że wczytane miasto jest typu <Nielimitowane pieniądze>\n" +
                    "i <Konwerter nielimitowanych pieniędzy> jest WŁ. [ ✓ ].\n" +
                    "Zrób zapis kopii zapasowej i używaj na własne ryzyko; City Watchdog nie może cofnąć tej konwersji." },

                { m_Settings.GetOptionWarningLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)),
                    "Przekonwertować to miasto z nielimitowanych pieniędzy na normalne ograniczone pieniądze?\n" +
                    "NAJPIERW zapisz kopię zapasową; City Watchdog nie może tego cofnąć.\n" +
                    "Na pewno?" },

                // --- About tab ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.NameText)), "Nazwa moda" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.NameText)), "Wyświetlana nazwa tego moda." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.VersionText)), "Wersja" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.VersionText)), "Obecna wersja moda." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.OpenParadox)), "Paradox Mods" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.OpenParadox)), "Otwiera stronę autora w Paradox Mods." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.WriteNotificationAuditLog)), "Raport debug do logu" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.WriteNotificationAuditLog)),
                    "<Niepotrzebne do normalnej gry.>\n" +
                    "Dla testerów i kontroli po patchach gry: zapisuje raport <Logs/CityWatchdog.log>\n" +
                    "porównujący aktywne prefaby powiadomień gry z ikonami powiadomień kontrolowanymi przez Watchdog." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.OpenLog)), "Otwórz log" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.OpenLog)),
                    "Otwiera </Logs/CityWatchdog.log>, jeśli istnieje.\n" +
                    "Jeśli pliku logu brakuje, otwiera zamiast tego folder Logs/." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ShowUsage)), "Pokaż instrukcje" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ShowUsage)), "Pokaż lub ukryj instrukcje użycia poniżej." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.UsageText)),
                    "<Przełączniki widoku>\n" +
                    "1. Przycisk [i]: ukryj/pokaż WSZYSTKIE dymki gry po najechaniu (budynki, cimy, narzędzia).\n" +
                    "2. Przycisk nazw dróg: ukryj/pokaż etykiety nazw dróg. Skrót: \\.\n" +
                    "3. Przycisk strzałek dróg: wymuś strzałki dróg jednokierunkowych wł./wył. (też ukrywa nazwy dróg).\n" +
                    "4. Ikona na pasku tytułu CWD: pokaż/ukryj dymki panelu City Watchdog.\n" +
                    "\n" +
                    "<Alerty powiadomień>\n" +
                    "1. Kliknij przycisk City Watchdog (lewy górny róg) albo naciśnij Shift+N, aby otworzyć panel.\n" +
                    "2. Przycisk sortowania dla rosnąco/malejąco.\n" +
                    "3. Toggle All szybko wyłącza/włącza wszystko, albo rozwiń sekcję, aby zmienić konkretne ikony.\n" +
                    "4. Tylko pokazuje lub ukrywa ikony; nie naprawia problemu miasta.\n" +
                    "\n" +
                    "<Pomoc z pieniędzmi>\n" +
                    "1. Dodaj lub odejmij pieniądze: użyj domyślnych klawiszy <Kwoty skrótu pieniędzy> [ i ].\n" +
                    "2. Automatyczne dodawanie pieniędzy dodaje pieniądze, gdy miasto spadnie poniżej ustawionego limitu.\n" +
                    "3. Konwersja zapisu nielimitowanych pieniędzy jest tylko dla miast rozpoczętych z nielimitowanymi pieniędzmi i jest <nieodwracalna>.\n" +
                    "\n" +
                    "<Dymki dolnego menu>\n" +
                    "Money View dodaje wartości trendu do paska pieniędzy i populacji oraz dodatkowe szczegóły po najechaniu.\n" +
                    "\n" +
                    "<Niestandardowy kamień milowy>\n" +
                    "Ustaw Pieniądze początkowe i wybierz Kamienie milowe w menu Opcje przed wczytaniem lub rozpoczęciem miasta." },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.UsageText)), "" },

            };

            return entries;
        }

        public void Unload()
        {
        }
    }
}
