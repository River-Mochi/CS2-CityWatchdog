// <copyright file="LocaleIT.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the MIT License. You may not use this file except in compliance with this License.
// See LICENSE file in the project root for full license information.
// This notice and the MIT License notice must be kept with
// all copies or substantial portions of this code.
// ================= </copyright> ======================

// File: src/Localization/LocaleIT.cs
// Purpose: Italian (it-IT) for City Watchdog Options UI menu.

namespace CityWatchdog
{
    using System.Collections.Generic; // Dictionary and KeyValuePair
    using Colossal;                   // IDictionarySource
    using Game.UI.Editor;

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
            string title = Mod.ModName + " (Guardiano)";

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
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyView)),
                    "Mostra valori numerici di tendenza accanto alle frecce vanilla di denaro e popolazione nella barra in basso.\n" +
                    "È una visualizzazione leggera al passaggio del mouse sulla barra, <solo display>;\n" +
                    "non modifica denaro o popolazione della città."
                },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyViewMode)), "Frequenza Money View" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyViewMode)),
                    "Scegli se il testo di tendenza nella barra in basso mostra valori orari o mensili per denaro e popolazione.\n" +
                    "Mensile usa entrate di bilancio meno spese per il denaro, e una proiezione di 24 ore per la popolazione."
                },
                { m_Settings.GetOptionLocaleID("MoneyViewModeHourly"), "Orario (/h)" },
                { m_Settings.GetOptionLocaleID("MoneyViewModeMonthly"), "Mensile (/mo)" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyTooltipMode)), "Stile tooltip denaro" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyTooltipMode)),
                    "Scegli quanti dettagli appaiono nel tooltip del denaro al passaggio del mouse.\n" +
                    "Compatto = predefinito alla prima installazione.\n" +
                    "<Mini> mostra solo 2 valori netti per /mo e /h.\n" +
                    "<Compatto> accorcia i valori grandi (15.21M invece di 15,212,318).\n" +
                    "<Dati completi> mostra valori lunghi e campi Totale."
                },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeMini"), "Mini" },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeCompact"), "Compatto" },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeFullData"), "Dati completi" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyTooltipFontScale)), "Dimensione testo denaro" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyTooltipFontScale)),
                    "Regola la <dimensione testo> dei numeri nel tooltip Money View.\n" +
                    "Predefinito del gioco = 100%\n" +
                    "<Predefinito mod = 120%>\n" +
                    "Passa il mouse su Denaro in basso nello schermo.\n" +
                    "Richiesto da giocatori che fanno fatica a leggere i tooltip piccoli del gioco."
                },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.PopulationTooltipFontScale)), "Dimensione testo popolazione" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.PopulationTooltipFontScale)),
                    "Regola la <dimensione testo> dei numeri nel tooltip popolazione.\n" +
                    "Predefinito del gioco = 100%\n" +
                    "<Predefinito mod = 120%>\n" +
                    "Passa il mouse su Popolazione in basso nello schermo."
                },

                // --- Money helpers ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ManualMoneyAmount)), "Importo tasto rapido denaro" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ManualMoneyAmount)),
                    "Usa questo importo con i tasti rapidi Aggiungi denaro e Sottrai denaro.\n" +
                    "<Predefinito mod = 40,000>\n" +
                    "Non fa nulla se non usi il tasto rapido per aggiungere/sottrarre denaro nella città.\n" +
                    "Per denaro automatico, abilita l'opzione Aggiungi denaro automaticamente."
                },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AddMoneyKeyboardBinding)), "Aggiungi denaro" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AddMoneyKeyboardBinding)), "Tasto rapido per <Aggiungi denaro> dentro la città." },
                { m_Settings.GetBindingKeyLocaleID(Setting.AddMoneyAction), "Aggiungi denaro" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.SubtractMoneyKeyboardBinding)), "Sottrai denaro" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.SubtractMoneyKeyboardBinding)), "Tasto rapido per <Sottrai denaro> dentro la città." },
                { m_Settings.GetBindingKeyLocaleID(Setting.SubtractMoneyAction), "Sottrai denaro" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoney)), "Aggiungi denaro automaticamente" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoney)),
                    "Quando è abilitato [ ✓ ], City Watchdog controlla il saldo della città mentre una città è caricata.\n" +
                    "- Se il saldo è <sotto la soglia>, \n" +
                    "  aggiunge l'importo automatico selezionato.\n" +
                    "- È consigliato usare il denaro manuale con il tasto rapido (<[> o <]>) quando serve" +
                    "  invece di questa opzione automatica, ma è qui se la vuoi."
                },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoneyThreshold)), "Soglia denaro automatico" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoneyThreshold)),
                    "Se Aggiungi denaro automaticamente è abilitato e il saldo della città scende sotto questo valore,\n" +
                    "aggiunge l'importo automatico selezionato."
                },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoneyAmount)), "Importo denaro automatico" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoneyAmount)),
                    "Importo aggiunto ogni volta che Aggiungi denaro automaticamente si attiva.\n" +
                    "Scegli un valore abbastanza alto da riportare la città sopra la soglia in sicurezza."
                },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.InitialMoney)), "Denaro iniziale" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.InitialMoney)),
                    "Imposta il saldo iniziale per una nuova città con <denaro limitato> o per la prima città caricata,\n" +
                    "poi torna a Predefinito del gioco dopo l'applicazione.\n" +
                    "È disattivato se una città è già caricata.\n" +
                    "Imposta prima di avviare/caricare una città → si applica una volta → poi usa <Importo tasto rapido denaro> o <Aggiungi denaro automaticamente>."
                },
                { m_Settings.GetOptionLocaleID("GameDefault"), "Predefinito del gioco" },

                // --- Notifications ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleNotificationsKeyboardBinding)), "Mostra/Nascondi icone notifica" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleNotificationsKeyboardBinding)),
                    "<Tasto rapido> per la stessa azione del pulsante icona <[TOGGLE ALL]> nel pannello di gioco.\n" +
                    "Mostra o nasconde subito tutte le icone di notifica della città elencate."
                },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleNotificationsAction), "Mostra/Nascondi subito tutte le icone di notifica" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleNotificationPanelKeyboardBinding)), "Apri/Chiudi pannello notifiche" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleNotificationPanelKeyboardBinding)),
                    "<Tasto rapido> per aprire o chiudere il\n" +
                    "<pannello notifiche> nella città.\n" +
                    "Funziona come cliccare l'icona in alto a sinistra per aprire il pannello completo."
                },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleNotificationPanelAction), "Apri/Chiudi pannello notifiche" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleRoadNamesKeyboardBinding)), "Nascondi/Mostra nomi strade" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleRoadNamesKeyboardBinding)),
                    "<Tasto rapido> per nascondere o mostrare subito le etichette vanilla dei nomi delle strade nella città.\n" +
                    "È uguale a cliccare l'icona Nome strada nella barra del pannello City Watchdog."
                },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleRoadNamesAction), "Nascondi/Mostra nomi strade" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleAllTooltipsKeyboardBinding)), "Disattiva tutti i tooltip al passaggio del mouse" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleAllTooltipsKeyboardBinding)),
                    "<Hotkey> per nascondere o mostrare immediatamente TUTTI i tooltip del gioco — edifici, cims, strumenti e icone del menu inferiore.\n" +
                    "<I popup propri di denaro/popolazione di City Watchdog restano attivi>; sono controllati dall'opzione Money View sopra.\n" +
                    "Stesso effetto del clic sull'icona [i] del pannello City Watchdog in città." },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleAllTooltipsAction), "Nascondi/Mostra tutti i tooltip del gioco" },

                // --- Milestone selector ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.CustomMilestone)), "Selettore traguardo" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.CustomMilestone)),
                    "Abilita prima di caricare o iniziare una città per sbloccare il traguardo scelto subito dopo il caricamento.\n" +
                    "Non può essere attivato mentre una città è caricata, ma può essere disattivato se è rimasto attivo per errore.\n" +
                    "Se l'hai dimenticato e hai già caricato una città, riavvia il gioco e scegli il milestone prima di entrare in una città.\n" +
                    "City Watchdog non può annullare modifiche ai traguardi già salvate in una città; usa un salvataggio precedente se necessario."
                },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MilestoneLevel)), "Traguardo" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MilestoneLevel)),
                    "Scegli il livello di traguardo da sbloccare al prossimo caricamento della città.\n" +
                    "È modificabile solo fuori da una città caricata, e solo dopo aver abilitato [Selettore traguardo] [ ✓ ]."
                },

                // --- Save conversion ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ConfirmUnlimitedMoneySaveConversion)), "Convertitore denaro illimitato" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ConfirmUnlimitedMoneySaveConversion)),
                    "<Fai PRIMA un backup della città>.\n" +
                    "Converte una città iniziata con Denaro illimitato in una città normale con le sfide economiche regolari.\n" +
                    "Abilitare questa opzione sblocca il pulsante <[Converti salvataggio Denaro illimitato]> quando la città caricata è di tipo <Denaro illimitato>.\n" +
                    "City Watchdog non può annullare questa conversione.\n" +
                    "Se hai città normali, non preoccuparti; non serve."
                },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)), "Converti città con Denaro illimitato in normale" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)),
                    "Per città iniziate con <Denaro illimitato>.\n" +
                    "Mentre quella città è caricata, converte il salvataggio a normale budget con denaro limitato, così la città avrà di nuovo le normali sfide economiche.\n" +
                    "Il pulsante è <disabilitato/grigio> a meno che la città caricata sia di tipo <Denaro illimitato>\n" +
                    "e <Convertitore denaro illimitato> sia ON [ ✓ ].\n" +
                    "Fai un salvataggio di backup e usa a tuo rischio; City Watchdog non può annullare questa conversione."
                },
                { m_Settings.GetOptionWarningLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)),
                    "Convertire questa città da Denaro illimitato a normale denaro limitato?\n" +
                    "Salva PRIMA un backup; City Watchdog non può annullare questa operazione.\n" +
                    "Confermi?"
                },

                // --- About tab ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.NameText)), "Nome mod" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.NameText)), "Nome visualizzato di questa mod." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.VersionText)), "Versione" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.VersionText)), "Versione attuale della mod." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.OpenParadox)), "Paradox Mods" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.OpenParadox)), "Apre la pagina Paradox Mods dell'autore." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.WriteNotificationAuditLog)), "Report debug nel log" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.WriteNotificationAuditLog)),
                    "<Non serve per giocare normalmente.>\n" +
                    "Per tester e controlli dopo patch del gioco: scrive un report <Logs/CityWatchdog.log>\n" +
                    "confrontando i prefab di notifica del gioco con le icone di notifica che Watchdog controlla ora."
                },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.OpenLog)), "Apri log" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.OpenLog)),
                    "Apre </Logs/CityWatchdog.log> se esiste.\n" +
                    "Se il file log manca, apre invece la cartella Logs/."
                },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ShowUsage)), "Mostra istruzioni" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ShowUsage)), "Mostra o nasconde le istruzioni qui sotto." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.UsageText)),
                    "<Interruttori visuali>\n" +
                    "1. Pulsante [i]: nasconde/mostra TUTTI i tooltip del gioco al passaggio del mouse (edifici, cims, strumenti, icone del menu inferiore).\n" +
                    "2. Pulsante Nome strada: nasconde/mostra le etichette dei nomi strade. Tasto rapido: \\.\n" +
                    "3. Pulsante Frecce stradali: forza ON/OFF le frecce delle strade a senso unico (nasconde anche i nomi strade).\n" +
                    "4. Icona nella barra titolo CWD: mostra/nasconde i tooltip del pannello City Watchdog.\n" +
                    "\n" +
                    "<Avvisi di notifica>\n" +
                    "1. Clicca il pulsante City Watchdog (in alto a sinistra), o premi Shift+N, per aprire il pannello.\n" +
                    "2. Pulsante Ordina per crescente/decrescente.\n" +
                    "3. Toggle All per tutto Off/On rapidamente, oppure espandi una sezione per cambiare icone specifiche.\n" +
                    "4. Mostra o nasconde solo icone; non risolve il problema della città.\n" +
                    "\n" +
                    "<Aiuti denaro>\n" +
                    "1. Aggiungi o sottrai denaro: usa i tasti predefiniti [ e ] di <Importo tasto rapido denaro>.\n" +
                    "2. Aggiungi denaro automaticamente aggiunge denaro quando una città scende sotto il limite impostato.\n" +
                    "3. Converti salvataggio Denaro illimitato è solo per città iniziate con Denaro illimitato ed è <irreversibile>.\n" +
                    "\n" +
                    "<Tooltip menu inferiore>\n" +
                    "Money View aggiunge valori di tendenza alla barra denaro e popolazione e dettagli extra al passaggio del mouse.\n" +
                    "\n" +
                    "<Traguardo personalizzato>\n" +
                    "Imposta Denaro iniziale e seleziona i Traguardi dal menu Opzioni prima di caricare o iniziare una città."
                },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.UsageText)), "" },
            };

            return entries;
        }

        public void Unload()
        {
        }
    }
}
