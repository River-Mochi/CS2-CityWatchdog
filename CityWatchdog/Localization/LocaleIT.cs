// <copyright file="LocaleIT.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi, MIT License.
// See LICENSE file in the project root for full license info.
// </copyright>
//
// File: src/Localization/LocaleIT.cs
// Purpose: Italian (it-IT) strings for City Watchdog Options UI (settings menu).

namespace CityWatchdog
{
    using System.Collections.Generic; // Dictionary and KeyValuePair
    using Colossal;                   // IDictionarySource

    public sealed class LocaleIT : IDictionarySource
    {
        private readonly Setting m_Settings;

        public LocaleIT(Setting setting)
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
                { m_Settings.GetOptionTabLocaleID(Setting.Actions), "Azioni" },
                { m_Settings.GetOptionTabLocaleID(Setting.Hotkeys), "Tasti rapidi" },
                { m_Settings.GetOptionTabLocaleID(Setting.About), "Info" },
                { m_Settings.GetOptionTabLocaleID(Setting.Debug), "Debug" },

                // --- Groups ---
                { m_Settings.GetOptionGroupLocaleID(Setting.MoneyViewGroup), "Visualizzatore info" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Money), "Denaro" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Notifications), "Notifiche" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Milestone), "Traguardo" },
                { m_Settings.GetOptionGroupLocaleID(Setting.SaveConversion), "Conversione salvataggio" },
                { m_Settings.GetOptionGroupLocaleID(Setting.HotkeyActions), "Tasti rapidi" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutInfo), "" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutLinks), "" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutDiagnostics), "DIAGNOSTICA" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutUsage), "USO" },

                // --- Money View ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyView)), "Mostra dettagli al passaggio del mouse" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyView)), "Mostra valori numerici di tendenza accanto alle frecce vanilla di denaro e popolazione nella barra inferiore.\nÈ una visualizzazione leggera al passaggio del mouse sulla barra, <solo visualizzazione>;\nnon modifica denaro o popolazione della città." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyViewMode)), "Frequenza Money View" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyViewMode)), "Scegli se il testo di tendenza nella barra inferiore mostra valori orari o mensili per denaro e popolazione.\nMensile usa entrate di bilancio meno spese per il denaro, e una proiezione di 24 ore per la popolazione." },
                { m_Settings.GetOptionLocaleID("MoneyViewModeHourly"), "Orario (/h)" },
                { m_Settings.GetOptionLocaleID("MoneyViewModeMonthly"), "Mensile (/mo)" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyTooltipMode)), "Stile tooltip denaro" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyTooltipMode)), "Scegli quanti dettagli appaiono nel tooltip del denaro al passaggio del mouse.\nCompatto = predefinito alla prima installazione.\n<Mini> mostra solo 2 valori netti per /mo e /h.\n<Compatto> abbrevia i valori grandi (15.21M invece di 15,212,318).\n<Dati completi> mostra valori lunghi e campi Totale." },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeMini"), "Mini" },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeCompact"), "Compatto" },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeFullData"), "Dati completi" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyTooltipFontScale)), "Dimensione font denaro" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyTooltipFontScale)), "Regola la <dimensione del font> dei numeri nel tooltip Money View.\nPredefinito del gioco = 100%\n<Predefinito mod = 120%>\nPassa il mouse su Denaro in basso nello schermo.\nRichiesto da giocatori che fanno fatica a leggere i tooltip più piccoli del gioco." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.PopulationTooltipFontScale)), "Dimensione font popolazione" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.PopulationTooltipFontScale)), "Regola la <dimensione del font> dei numeri nel tooltip della popolazione.\nPredefinito del gioco = 100%\n<Predefinito mod = 120%>\nPassa il mouse su Popolazione in basso nello schermo." },

                // --- Money helpers ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ManualMoneyAmount)), "Importo tasto rapido denaro" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ManualMoneyAmount)), "Usa questo importo con i tasti rapidi Aggiungi denaro e Sottrai denaro.\n<Predefinito mod = 40,000>\nNon fa nulla se non usi il tasto rapido per aggiungere/sottrarre denaro (nella città).\nPer il denaro automatico, abilita l’opzione Aggiungi denaro automaticamente." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AddMoneyKeyboardBinding)), "Aggiungi denaro" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AddMoneyKeyboardBinding)), "Tasto rapido per <Aggiungi denaro> dentro la città." },
                { m_Settings.GetBindingKeyLocaleID(Setting.AddMoneyAction), "Aggiungi denaro" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.SubtractMoneyKeyboardBinding)), "Sottrai denaro" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.SubtractMoneyKeyboardBinding)), "Tasto rapido per <Sottrai denaro> dentro la città." },
                { m_Settings.GetBindingKeyLocaleID(Setting.SubtractMoneyAction), "Sottrai denaro" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoney)), "Aggiungi denaro automaticamente" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoney)), "Quando abilitato [ ✓ ], City Watchdog controlla il saldo della città mentre una città è caricata.\n- Se il saldo è <sotto la soglia>, \n  aggiunge l’importo automatico selezionato.\n- Si consiglia di usare il denaro manuale con il tasto rapido (<[> o <]>) quando serve invece di questa opzione automatica, ma è disponibile se la vuoi usare." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoneyThreshold)), "Soglia denaro automatico" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoneyThreshold)), "Se Aggiungi denaro automaticamente è abilitato e il saldo della città scende sotto questo valore,\nagginge l’importo automatico selezionato." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoneyAmount)), "Importo denaro automatico" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoneyAmount)), "Importo aggiunto ogni volta che Aggiungi denaro automaticamente si attiva.\nScegli un valore abbastanza alto da riportare la città sopra la soglia in sicurezza." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.InitialMoney)), "Denaro iniziale" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.InitialMoney)), "Imposta il saldo iniziale per una nuova città con <denaro limitato> o per la prima città caricata,\npoi torna al predefinito del gioco dopo l’applicazione.\nÈ disattivato se una città è già caricata.\nImposta prima di avviare/caricare una città → si applica una volta → poi usa <Importo tasto rapido denaro> o <Aggiungi denaro automaticamente>." },
                { m_Settings.GetOptionLocaleID("GameDefault"), "Predefinito del gioco" },

                // --- Notifications ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleNotificationsKeyboardBinding)), "Attiva/disattiva icone notifica" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleNotificationsKeyboardBinding)), "<Tasto rapido> per la stessa azione del pulsante icona <[TOGGLE ALL]> nel pannello di gioco.\nMostra o nasconde subito tutte le icone di notifica della città elencate." },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleNotificationsAction), "Mostra/Nascondi subito tutte le icone di notifica" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleNotificationPanelKeyboardBinding)), "Apri/Chiudi pannello notifiche" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleNotificationPanelKeyboardBinding)), "<Tasto rapido> per aprire o chiudere il\n<pannello notifiche> nella città.\nFunziona come cliccare l’icona in alto a sinistra per aprire il pannello completo." },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleNotificationPanelAction), "Apri/Chiudi pannello notifiche" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleRoadNamesKeyboardBinding)), "Nascondi/mostra nomi delle strade" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleRoadNamesKeyboardBinding)), "<Tasto rapido> per nascondere o mostrare subito le etichette vanilla dei nomi delle strade in città.\nEquivale a fare clic sull’icona Nome strada nella barra del pannello City Watchdog." },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleRoadNamesAction), "Nascondi/mostra nomi delle strade" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.DisableAllTooltips)), "Disabilita tutti i tooltip al passaggio del mouse" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.DisableAllTooltips)), "Disattiva i tooltip al passaggio del mouse del gioco — sia quelli che seguono il cursore su edifici/cittadini/strumenti sia i piccoli popup sui pulsanti dell’interfaccia del gioco (nomi della barra superiore, pulsanti vanilla, ecc.).\n<I popup denaro/popolazione di City Watchdog restano attivi>; sono controllati dall’opzione Money View sopra.\nEquivale a cliccare l’icona [i] nel pannello City Watchdog dentro la città." },

                // --- Milestone selector ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.CustomMilestone)), "Selettore traguardo" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.CustomMilestone)), "Abilita prima di caricare o iniziare una città per sbloccare il traguardo scelto subito dopo il caricamento della città.\nNon può essere attivato mentre una città è caricata, ma può essere disattivato se è rimasto attivo per errore.\nCity Watchdog non può annullare modifiche ai traguardi già salvate in una città; usa un salvataggio precedente se necessario." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MilestoneLevel)), "Traguardo" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MilestoneLevel)), "Scegli il livello di traguardo da sbloccare al prossimo caricamento della città.\nÈ modificabile solo fuori da una città caricata, e solo dopo che [Selettore traguardo] è abilitato [ ✓ ]." },

                // --- Save conversion ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ConfirmUnlimitedMoneySaveConversion)), "Convertitore denaro illimitato" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ConfirmUnlimitedMoneySaveConversion)), "<Fai prima un backup della città>.\nConverte una città iniziata con Denaro illimitato in una città normale con sfide economiche regolari.\nAbilitandolo si sblocca il pulsante <[Converti salvataggio Denaro illimitato]> quando la città caricata è di tipo <Denaro illimitato>.\nCity Watchdog non può annullare questa conversione.\nSe hai città normali, non preoccuparti; non serve." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)), "Converti città con Denaro illimitato in normale" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)), "Per città iniziate con <Denaro illimitato>.\nMentre quella città è caricata, converte il salvataggio a normale budget con denaro limitato così la città ha di nuovo sfide economiche regolari.\nIl pulsante è <disabilitato/grigio> a meno che la città caricata sia di tipo <Denaro illimitato>\ne <Convertitore denaro illimitato> sia ON [ ✓ ].\nFai un salvataggio di backup e usa a tuo rischio; City Watchdog non può annullare questa conversione." },
                { m_Settings.GetOptionWarningLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)), "Convertire questa città da Denaro illimitato a normale denaro limitato?\nSalva PRIMA un backup; City Watchdog non può annullarlo.\nSei sicuro?" },

                // --- About tab ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.NameText)), "Nome mod" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.NameText)), "Nome visualizzato di questa mod." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.VersionText)), "Versione" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.VersionText)), "Versione attuale della mod." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.OpenParadox)), "Paradox Mods" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.OpenParadox)), "Apre la pagina Paradox Mods dell’autore." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.WriteNotificationAuditLog)), "Report debug nel log" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.WriteNotificationAuditLog)), "<Non necessario per il gioco normale.>\nPer tester e controlli dopo patch del gioco: scrive un report <Logs/CityWatchdog.log>\nche confronta i prefab di notifica del gioco in tempo reale con le icone di notifica attualmente controllate da Watchdog." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.OpenLog)), "Apri log" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.OpenLog)), "Apre </Logs/CityWatchdog.log> se esiste.\nSe il file di log manca, apre invece la cartella Logs/." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ShowUsage)), "Mostra istruzioni" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ShowUsage)), "Mostra o nasconde le istruzioni d’uso qui sotto." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.UsageText)), "<Pannello notifiche>\n1. Fai clic sul pulsante City Watchdog (in alto a sinistra), oppure premi Shift+N, per aprire il pannello.\n2. Ordina ASC/DESC.\n3. Toggle All per un rapido Tutto Off/On, oppure espandi una sezione per cambiare icone specifiche.\n4. Mostra o nasconde solo le icone; non risolve il problema della città.\n\n<Aiuti denaro>\n1. Aggiungi o sottrai denaro: usa il <Importo tasto rapido denaro> predefinito [ o ].\n2. Aggiungi denaro automaticamente controlla il budget mentre una città è caricata e aggiunge denaro quando è sotto la soglia.\n3. Money View aggiunge valori numerici alla barra denaro e popolazione e tooltip al passaggio del mouse.\n4. Converti salvataggio Denaro illimitato è solo per città iniziate con Denaro illimitato ed è <irreversibile>.\n\n<Traguardo personalizzato>\nImposta Denaro iniziale e seleziona i traguardi dal menu Opzioni prima di caricare o avviare una città." },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.UsageText)), "" },
            };

            return entries;
        }

        public void Unload()
        {
        }
    }
}
