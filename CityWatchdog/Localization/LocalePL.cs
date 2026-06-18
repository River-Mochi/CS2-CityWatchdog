// <copyright file="LocalePL.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi, MIT License.
// See LICENSE file in the project root for full license info.
// </copyright>
//
// File: src/Localization/LocalePL.cs
// Purpose: Polish (pl-PL) strings for City Watchdog Options UI (settings menu).

namespace CityWatchdog
{
    using System.Collections.Generic; // Dictionary and KeyValuePair
    using Colossal;                   // IDictionarySource

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
                { m_Settings.GetOptionTabLocaleID(Setting.Hotkeys), "Skróty" },
                { m_Settings.GetOptionTabLocaleID(Setting.About), "O modzie" },
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
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyView)), "Pokazuje liczbowe wartości trendu obok domyślnych strzałek pieniędzy i populacji na dolnym pasku narzędzi.\nTo lekki podgląd po najechaniu na pasek, <tylko wyświetlanie>;\nnie zmienia pieniędzy ani populacji miasta." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyViewMode)), "Częstotliwość Money View" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyViewMode)), "Wybierz, czy tekst trendu na dolnym pasku ma pokazywać wartości godzinowe czy miesięczne dla pieniędzy i populacji.\nMiesięcznie używa dochodów budżetu minus wydatki dla pieniędzy oraz 24-godzinnej projekcji dla populacji." },
                { m_Settings.GetOptionLocaleID("MoneyViewModeHourly"), "Godzinowo (/h)" },
                { m_Settings.GetOptionLocaleID("MoneyViewModeMonthly"), "Miesięcznie (/mo)" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyTooltipMode)), "Styl podpowiedzi pieniędzy" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyTooltipMode)), "Wybierz, ile szczegółów ma pojawiać się w podpowiedzi pieniędzy po najechaniu.\nKompaktowy = domyślnie przy pierwszej instalacji.\n<Mini> pokazuje tylko 2 wartości netto dla /mo i /h.\n<Kompaktowy> skraca duże wartości (15.21M zamiast 15,212,318).\n<Pełne dane> pokazuje długie wartości i pola Suma." },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeMini"), "Mini" },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeCompact"), "Kompaktowy" },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeFullData"), "Pełne dane" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyTooltipFontScale)), "Rozmiar czcionki pieniędzy" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyTooltipFontScale)), "Dostosowuje <rozmiar czcionki> liczb w podpowiedzi Money View.\nDomyślnie w grze = 100%\n<Domyślnie w modzie = 120%>\nNajedź na Pieniądze u dołu ekranu.\nOpcja dla graczy, którym trudno czytać mniejsze podpowiedzi w grze." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.PopulationTooltipFontScale)), "Rozmiar czcionki populacji" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.PopulationTooltipFontScale)), "Dostosowuje <rozmiar czcionki> liczb w podpowiedzi populacji.\nDomyślnie w grze = 100%\n<Domyślnie w modzie = 120%>\nNajedź na Populację u dołu ekranu." },

                // --- Money helpers ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ManualMoneyAmount)), "Kwota skrótu pieniędzy" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ManualMoneyAmount)), "Użyj tej kwoty ze skrótami Dodaj pieniądze i Odejmij pieniądze.\n<Domyślnie w modzie = 40,000>\nNic nie robi, dopóki nie użyjesz skrótu do dodania/odjęcia pieniędzy (w mieście).\nDla automatycznych pieniędzy włącz opcję Automatyczne dodawanie pieniędzy." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AddMoneyKeyboardBinding)), "Dodaj pieniądze" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AddMoneyKeyboardBinding)), "Skrót do <Dodaj pieniądze> w mieście." },
                { m_Settings.GetBindingKeyLocaleID(Setting.AddMoneyAction), "Dodaj pieniądze" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.SubtractMoneyKeyboardBinding)), "Odejmij pieniądze" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.SubtractMoneyKeyboardBinding)), "Skrót do <Odejmij pieniądze> w mieście." },
                { m_Settings.GetBindingKeyLocaleID(Setting.SubtractMoneyAction), "Odejmij pieniądze" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoney)), "Automatyczne dodawanie pieniędzy" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoney)), "Gdy włączone [ ✓ ], City Watchdog sprawdza saldo miasta, gdy miasto jest wczytane.\n- Jeśli saldo jest <poniżej progu>, \n  dodaje wybraną automatyczną kwotę.\n- Zalecane jest używanie ręcznych pieniędzy skrótem (<[> lub <]>) w razie potrzeby zamiast tej opcji automatycznej, ale jest dostępna, jeśli jej chcesz." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoneyThreshold)), "Próg automatycznych pieniędzy" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoneyThreshold)), "Jeśli Automatyczne dodawanie pieniędzy jest włączone i saldo miasta spadnie poniżej tej wartości,\ndodaje wybraną automatyczną kwotę." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoneyAmount)), "Automatyczna kwota pieniędzy" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoneyAmount)), "Kwota dodawana za każdym razem, gdy uruchomi się Automatyczne dodawanie pieniędzy.\nWybierz wartość wystarczająco wysoką, aby bezpiecznie podnieść miasto powyżej progu." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.InitialMoney)), "Pieniądze początkowe" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.InitialMoney)), "Ustawia saldo początkowe dla nowego miasta z <ograniczonymi pieniędzmi> lub pierwszego wczytanego miasta,\na następnie wraca do domyślnej wartości gry po zastosowaniu.\nOpcja jest wyszarzona, jeśli miasto jest już wczytane.\nUstaw przed rozpoczęciem/wczytaniem miasta → działa raz → potem użyj <Kwota skrótu pieniędzy> albo <Automatyczne dodawanie pieniędzy>." },
                { m_Settings.GetOptionLocaleID("GameDefault"), "Domyślne gry" },

                // --- Notifications ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleNotificationsKeyboardBinding)), "Przełącz ikony powiadomień" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleNotificationsKeyboardBinding)), "<Skrót> dla tej samej akcji co przycisk <[TOGGLE ALL]> w panelu gry.\nNatychmiast pokazuje lub ukrywa wszystkie wymienione ikony powiadomień miasta." },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleNotificationsAction), "Natychmiast pokaż/ukryj wszystkie ikony powiadomień" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleNotificationPanelKeyboardBinding)), "Otwórz/zamknij panel powiadomień" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleNotificationPanelKeyboardBinding)), "<Skrót> do otwierania lub zamykania\n<panelu powiadomień> w mieście.\nDziała tak samo jak kliknięcie ikony w lewym górnym rogu, aby otworzyć pełny panel." },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleNotificationPanelAction), "Otwórz/zamknij panel powiadomień" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleRoadNamesKeyboardBinding)), "Ukryj/pokaż nazwy dróg" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleRoadNamesKeyboardBinding)), "<Skrót> natychmiast ukrywa lub pokazuje domyślne etykiety nazw dróg w mieście.\nDziała tak samo jak kliknięcie ikony nazw dróg na pasku panelu City Watchdog." },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleRoadNamesAction), "Ukryj/pokaż nazwy dróg" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.DisableAllTooltips)), "Wyłącz wszystkie podpowiedzi po najechaniu" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.DisableAllTooltips)), "Wyłącza podpowiedzi gry po najechaniu — zarówno te, które podążają za kursorem nad budynkami/mieszkańcami/narzędziami, jak i małe wyskakujące okna na przyciskach UI gry (nazwy górnego paska, przyciski vanilla itd.).\n<Własne popupy pieniędzy/populacji City Watchdog pozostają włączone>; kontroluje je opcja Money View powyżej.\nDziała tak samo jak kliknięcie ikony [i] w panelu City Watchdog w mieście." },

                // --- Milestone selector ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.CustomMilestone)), "Wybór kamienia milowego" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.CustomMilestone)), "Włącz przed wczytaniem lub rozpoczęciem miasta, aby odblokować wybrany kamień milowy zaraz po wczytaniu miasta.\nNie można włączyć w trakcie wczytanego miasta, ale można wyłączyć, jeśli została włączona przez pomyłkę.\nCity Watchdog nie może cofnąć zmian kamieni milowych już zapisanych w mieście; w razie potrzeby użyj wcześniejszego zapisu." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MilestoneLevel)), "Kamień milowy" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MilestoneLevel)), "Wybierz poziom kamienia milowego do odblokowania przy następnym wczytaniu miasta.\nMożna go zmieniać tylko poza wczytanym miastem i dopiero po włączeniu [Wybór kamienia milowego] [ ✓ ]." },

                // --- Save conversion ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ConfirmUnlimitedMoneySaveConversion)), "Konwerter nieograniczonych pieniędzy" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ConfirmUnlimitedMoneySaveConversion)), "<Najpierw zrób kopię zapasową miasta>.\nKonwertuje miasto rozpoczęte z Nieograniczonymi pieniędzmi na normalne miasto ze zwykłymi wyzwaniami finansowymi.\nWłączenie odblokowuje przycisk <[Konwertuj zapis Nieograniczonych pieniędzy]>, gdy wczytane miasto jest typu <Nieograniczone pieniądze>.\nCity Watchdog nie może cofnąć tej konwersji.\nJeśli masz normalne miasta, nie martw się; to nie jest potrzebne." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)), "Konwertuj miasto z Nieograniczonych pieniędzy na normalne" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)), "Dla miast rozpoczętych z <Nieograniczonymi pieniędzmi>.\nGdy to miasto jest wczytane, konwertuje zapis na normalny budżet z ograniczonymi pieniędzmi, aby miasto znów miało zwykłe wyzwania finansowe.\nPrzycisk jest <wyłączony/wyszarzony>, chyba że wczytane miasto jest typu <Nieograniczone pieniądze>\ni <Konwerter nieograniczonych pieniędzy> jest ON [ ✓ ].\nZrób kopię zapasową i używaj na własne ryzyko; City Watchdog nie może cofnąć tej konwersji." },
                { m_Settings.GetOptionWarningLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)), "Przekonwertować to miasto z Nieograniczonych pieniędzy na normalne ograniczone pieniądze?\nNAJPIERW zapisz kopię zapasową; City Watchdog nie może tego cofnąć.\nNa pewno?" },

                // --- About tab ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.NameText)), "Nazwa moda" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.NameText)), "Wyświetlana nazwa tego moda." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.VersionText)), "Wersja" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.VersionText)), "Aktualna wersja moda." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.OpenParadox)), "Paradox Mods" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.OpenParadox)), "Otwiera stronę autora w Paradox Mods." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.WriteNotificationAuditLog)), "Raport debugowania do logu" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.WriteNotificationAuditLog)), "<Niepotrzebne podczas normalnej gry.>\nDla testerów i kontroli po patchach gry: zapisuje raport <Logs/CityWatchdog.log>\nporównujący aktywne prefabrykaty powiadomień gry z ikonami powiadomień obecnie kontrolowanymi przez Watchdog." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.OpenLog)), "Otwórz log" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.OpenLog)), "Otwiera </Logs/CityWatchdog.log>, jeśli istnieje.\nJeśli pliku logu brakuje, otwiera zamiast tego folder Logs/." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ShowUsage)), "Pokaż instrukcje" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ShowUsage)), "Pokaż lub ukryj poniższe instrukcje użycia." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.UsageText)), "<Panel powiadomień>\n1. Kliknij przycisk City Watchdog (lewy górny róg) albo naciśnij Shift+N, aby otworzyć panel.\n2. Sortuj ASC/DESC.\n3. Toggle All do szybkiego wszystkiego Off/On albo rozwiń sekcję, aby zmienić konkretne ikony.\n4. Tylko pokazuje lub ukrywa ikony; nie naprawia problemu miasta.\n\n<Pomoc pieniężna>\n1. Dodaj lub odejmij pieniądze: użyj domyślnej <Kwota skrótu pieniędzy> [ lub ].\n2. Automatyczne dodawanie pieniędzy obserwuje budżet, gdy miasto jest wczytane, i dodaje pieniądze poniżej progu.\n3. Money View dodaje wartości liczbowe do paska pieniędzy i populacji oraz podpowiedzi po najechaniu.\n4. Konwersja zapisu Nieograniczonych pieniędzy jest tylko dla miast rozpoczętych z Nieograniczonymi pieniędzmi i jest <nieodwracalna>.\n\n<Niestandardowy kamień milowy>\nUstaw Pieniądze początkowe i wybierz Kamienie milowe w menu Opcje przed wczytaniem lub rozpoczęciem miasta." },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.UsageText)), "" },
            };

            return entries;
        }

        public void Unload()
        {
        }
    }
}
