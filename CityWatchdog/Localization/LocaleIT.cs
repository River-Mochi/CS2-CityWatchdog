// <copyright file="LocaleIT.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the MIT License. You may not use this file except in compliance with this License.
// See LICENSE file in the project root for full license information.
// This notice and the MIT License notice must be kept with
// all copies or substantial portions of this code.
// ================= </copyright> ======================

// File: src/Localization/LocaleIT.cs
// Purpose: English (en-US) for City Watchdog Options UI menu.

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
                { m_Settings.GetOptionTabLocaleID(Setting.MoneyTab), "Denaro e traguardi" },
                { m_Settings.GetOptionTabLocaleID(Setting.About), "Informazioni" },

                // --- Groups, ordered by Options menu location ---
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutUsage), "USO" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Notifications), "Notifiche" },
                { m_Settings.GetOptionGroupLocaleID(Setting.MoneyViewGroup), "Visore info in città" },
                { m_Settings.GetOptionGroupLocaleID(Setting.MiniHudGroup), "Notifiche Mini HUD" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Milestone), "IMPOSTAZIONI NUOVA CITTÀ" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Money), "Denaro" },
                { m_Settings.GetOptionGroupLocaleID(Setting.SaveConversion), "Converti salvataggio illimitato" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutInfo), "" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutLinks), "" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutDiagnostics), "DIAGNOSTICA" },

                // --------------------------------------------------------------------
                // Actions tab - Usage
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ShowUsage)), "Mostra istruzioni" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ShowUsage)), "Mostra o nasconde le istruzioni qui sotto." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.UsageText)),
                    "<Interruttori visuali>\n" +
                    "1. Pulsante [i]: nasconde/mostra TUTTI i tooltip del gioco: edifici, cims, strumenti e icone del menu in basso.\n" +
                    "2. Nomi strade: nasconde/mostra i nomi delle strade. Tasto rapido: \\.\n" +
                    "3. Nomi distretti: nasconde/mostra i nomi dei distretti senza cambiare i confini.\n" +
                    "4. Frecce strade: forza le frecce delle strade a senso unico (nasconde anche i nomi strade).\n" +
                    "5. Icona barra titolo CWD: mostra/nasconde i tooltip del pannello City Watchdog.\n" +
                    "\n" +
                    "<Avvisi di notifica>\n" +
                    "1. Clicca il pulsante City Watchdog in alto a sinistra, o premi Shift+N, per aprire il pannello.\n" +
                    "2. Pulsante di ordinamento crescente/decrescente.\n" +
                    "3. Toggle All attiva/disattiva tutto rapidamente, oppure apri una sezione per cambiare icone specifiche.\n" +
                    "4. Mostra o nasconde solo le icone; non risolve il problema della città.\n" +
                    "\n" +
                    "<Aiuti denaro>\n" +
                    "1. Aggiungi o sottrai denaro: usa <Importo tasto rapido denaro> con i tasti [ e ].\n" +
                    "2. Il denaro automatico aggiunge denaro quando la città scende sotto il limite impostato.\n" +
                    "3. Converti salvataggio Denaro illimitato serve solo per città avviate con Denaro illimitato ed è <irreversibile>.\n" +
                    "\n" +
                    "<Tooltip del menu inferiore>\n" +
                    "Money View aggiunge valori di tendenza a denaro e popolazione nella barra e dettagli al passaggio del mouse.\n" +
                    "\n" +
                    "<Traguardo personalizzato>\n" +
                    "Imposta denaro iniziale e traguardi in Denaro e traguardi > IMPOSTAZIONI NUOVA CITTÀ prima di caricare o avviare una città."
                },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.UsageText)), "" },

                // --------------------------------------------------------------------
                // Actions tab - Notifications
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleNotificationsKeyboardBinding)), "Attiva/disattiva icone notifiche" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleNotificationsKeyboardBinding)),
                    "<Scorciatoia> per la stessa azione del pulsante <[TOGGLE ALL]> in gioco.\n" +
                    "Mostra o nasconde subito tutte le icone di notifica elencate." },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleNotificationsAction), "Mostra/Nascondi subito tutte le icone di notifica" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleNotificationPanelKeyboardBinding)), "Apri/chiudi pannello notifiche" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleNotificationPanelKeyboardBinding)),
                    "<Scorciatoia> per aprire o chiudere il\n" +
                    "<pannello notifiche> in città.\n" +
                    "Funziona come il pulsante in alto a sinistra."
                },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleNotificationPanelAction), "Apri/Chiudi pannello notifiche" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.PanelButtonsOnlyStart)), "Avvio solo pulsanti" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.PanelButtonsOnlyStart)),
                    "Se attivo [ ✓ ], City Watchdog dal pulsante in alto a sinistra parte nella vista piccola solo pulsanti.\n" +
                    "Usa la freccia nella barra del titolo o il pulsante delle righe per aprire il pannello completo." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleRoadNamesKeyboardBinding)), "Nascondi/mostra nomi strade" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleRoadNamesKeyboardBinding)),
                    "<Scorciatoia> per nascondere o mostrare subito i nomi strade vanilla.\n" +
                    "Come l’icona nomi strade nella barra del pannello City Watchdog." },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleRoadNamesAction), "Nascondi/Mostra nomi strade" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleAllTooltipsKeyboardBinding)), "Disattiva tutti i tooltip al passaggio del mouse" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleAllTooltipsKeyboardBinding)),
                    "<Scorciatoia> per nascondere o mostrare TUTTI i tooltip del gioco — edifici, cittadini, strumenti e icone del menu in basso.\n" +
                    "<I popup denaro/popolazione di City Watchdog restano attivi>; si controllano con Money View.\n" +
                    "Come l’icona [i] nel pannello City Watchdog." },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleAllTooltipsAction), "Nascondi/Mostra tutti i tooltip del gioco" },

                // --------------------------------------------------------------------
                // Actions tab - In-City Info Viewer
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyView)), "Mostra ToolTips denaro + popolazione" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyView)),
                    "<Consigliato>\n" +
                    "Menu in basso: mostra valori trend accanto alle frecce di denaro e popolazione.\n" +
                    "Funzione leggera al passaggio del mouse <solo display>;\n" +
                    "fa risparmiare tempo e può essere più leggera del pannello info del gioco."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyViewMode)), "Frequenza Money View" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyViewMode)),
                    "Scegli se i trend mostrano valori orari o mensili per denaro e popolazione.\n" +
                    "Mensile usa entrate meno spese del budget e una proiezione popolazione di 24 ore." },
                { m_Settings.GetOptionLocaleID("MoneyViewModeHourly"), "Orario (/h)" },
                { m_Settings.GetOptionLocaleID("MoneyViewModeMonthly"), "Mensile (/mo)" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyTooltipMode)), "Stile tooltip denaro" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyTooltipMode)),
                    "Scegli quanti dettagli mostra il tooltip denaro.\n" +
                    "Compact = predefinito alla prima installazione.\n" +
                    "<Mini> mostra solo 2 valori Net per /mo e /h.\n" +
                    "<Compact> accorcia i numeri grandi (15.21M invece di 15,212,318).\n" +
                    "<Full data> mostra valori lunghi e campi Totale." },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeMini"), "Mini" },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeCompact"), "Compatto" },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeFullData"), "Dati completi" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyTooltipFontScale)), "Dimensione font denaro" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyTooltipFontScale)),
                    "Regola la <dimensione del font> dei numeri Money View.\n" +
                    "Gioco = 100%\n" +
                    "<Mod = 120%>\n" +
                    "Passa il mouse su Denaro in basso.\n" +
                    "Richiesto da giocatori che leggono male i tooltip piccoli."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.PopulationTooltipFontScale)), "Dimensione font popolazione" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.PopulationTooltipFontScale)),
                    "Regola la <dimensione del font> dei numeri popolazione.\n" +
                    "Gioco = 100%\n" +
                    "<Mod = 120%>\n" +
                    "Passa il mouse su Popolazione in basso."
                },

                // --------------------------------------------------------------------
                // Actions tab - Mini HUD Notifications
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudEnabled)), "Notifiche Mini HUD" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudEnabled)),
                    "Mostra un piccolo HUD in città con i conteggi di notifica più importanti.\n" +
                    "Usalo come barra rapida di avvisi senza aprire il pannello completo City Watchdog." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ApplyMiniHudRecommendedPreset)), "Preset consigliato" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ApplyMiniHudRecommendedPreset)),
                    "Applica una configurazione consigliata del Mini HUD:\n" +
                    "avvisi più attivi, 5 icone, verticale, trascinabile, nasconde zeri e stile vetro.\n" +
                    "Il preset verticale trascinabile parte vicino all’alto a destra." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudMode)), "Modalità Mini HUD" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudMode)),
                    "Scegli quali righe di notifica usa il Mini HUD.\n" +
                    "Avvisi più attivi mostra i conteggi attuali più alti.\n" +
                    "Preferiti mostra solo le righe segnate come preferite nel pannello City Watchdog." },
                { m_Settings.GetOptionLocaleID("MiniHudModeTopActive"), "Avvisi più attivi" },
                { m_Settings.GetOptionLocaleID("MiniHudModeFavorites"), "Preferiti" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudItemCount)), "Numero icone Mini HUD" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudItemCount)),
                    "Scegli quante icone di notifica il Mini HUD può mostrare insieme." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudOrientation)), "Orientamento Mini HUD" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudOrientation)),
                    "Scegli se le icone del Mini HUD sono disposte in riga o in colonna." },
                { m_Settings.GetOptionLocaleID("MiniHudOrientationHorizontal"), "Orizzontale" },
                { m_Settings.GetOptionLocaleID("MiniHudOrientationVertical"), "Verticale" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudPlacement)), "Posizione Mini HUD" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudPlacement)),
                    "Scegli dove appare il Mini HUD.\n" +
                    "Trascinabile ti permette di spostarlo nell'interfaccia della città." },
                { m_Settings.GetOptionLocaleID("MiniHudPlacementTopCenter"), "Alto centro" },
                { m_Settings.GetOptionLocaleID("MiniHudPlacementTopRight"), "Alto destra" },
                { m_Settings.GetOptionLocaleID("MiniHudPlacementDraggable"), "Trascinabile" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudHideZero)), "Nascondi avvisi a zero" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudHideZero)),
                    "Quando attivo [ ✓ ], il Mini HUD nasconde le righe di notifica con conteggio 0." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudGlassStyle)), "Stile vetro" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudGlassStyle)),
                    "Aggiunge uno sfondo morbido tipo vetro dietro il Mini HUD per migliorare la leggibilità." },

                // --------------------------------------------------------------------
                // Money-Milestones tab - New City Start Settings
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.InitialMoney)), "Denaro iniziale" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.InitialMoney)),
                    "Imposta il saldo iniziale per una nuova città con <denaro limitato> o per la prima città caricata,\n" +
                    "poi torna a Game Default dopo l’applicazione.\n" +
                    "È disattivato se una città è già caricata.\n" +
                    "Impostalo prima di iniziare/caricare una città. Poi usa <Importo tasto denaro> o <Aggiunta denaro automatica>." },
                { m_Settings.GetOptionLocaleID("GameDefault"), "Predefinito gioco" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.CustomMilestone)), "Selettore milestone" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.CustomMilestone)),
                    "Attiva <prima di caricare o iniziare una città> per sbloccare subito il milestone scelto dopo il caricamento.\n" +
                    "Non può essere attivato con una città caricata, ma può essere disattivato se rimasto attivo per errore.\n" +
                    "Se lo hai dimenticato, riavvia il gioco e scegli il milestone prima di entrare in città.\n" +
                    "City Watchdog non può annullare milestone già salvati; usa un salvataggio precedente se serve." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MilestoneLevel)), "Milestone" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MilestoneLevel)),
                    "Scegli il milestone da sbloccare al prossimo caricamento della città.\n" +
                    "Regolabile solo fuori da una città caricata e solo dopo aver attivato [Selettore milestone] [ ✓ ]." },

                // --------------------------------------------------------------------
                // Money-Milestones tab - Money
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ManualMoneyAmount)), "Importo tasto denaro" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ManualMoneyAmount)),
                    "Usa questo importo con i tasti Aggiungi denaro e Sottrai denaro.\n" +
                    "<Mod = 40,000>\n" +
                    "Non fa nulla se non usi il tasto rapido in città.\n" +
                    "Per denaro automatico, abilita Aggiunta denaro automatica."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AddMoneyKeyboardBinding)), "Aggiungi denaro" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AddMoneyKeyboardBinding)),
                    "Tasto rapido per <Aggiungi denaro> in città." },
                { m_Settings.GetBindingKeyLocaleID(Setting.AddMoneyAction), "Aggiungi denaro" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.SubtractMoneyKeyboardBinding)), "Sottrai denaro" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.SubtractMoneyKeyboardBinding)),
                    "Tasto rapido per <Sottrai denaro> in città." },
                { m_Settings.GetBindingKeyLocaleID(Setting.SubtractMoneyAction), "Sottrai denaro" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoney)), "Aggiunta denaro automatica" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoney)),
                    "Quando attivo [ ✓ ], City Watchdog controlla il saldo mentre una città è caricata.\n" +
                    "- Se il saldo è <sotto la soglia>,\n" +
                    "  aggiunge l’importo automatico scelto.\n" +
                    "- Si consiglia il denaro manuale con i tasti (<[> o <]>) quando serve, ma questa opzione è disponibile."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoneyThreshold)), "Soglia denaro automatica" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoneyThreshold)),
                    "Se l’aggiunta automatica è attiva e il saldo scende sotto questo valore,\n" +
                    "agginge l’importo automatico scelto." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoneyAmount)), "Importo denaro automatico" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoneyAmount)),
                    "Importo aggiunto ogni volta che si attiva.\n" +
                    "Scegli un valore sufficiente a superare la soglia." },

                // --------------------------------------------------------------------
                // Money-Milestones tab - Save Conversion
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ConfirmUnlimitedMoneySaveConversion)), "Convertitore denaro illimitato" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ConfirmUnlimitedMoneySaveConversion)),
                    "<Fai prima un backup della città>.\n" +
                    "Converte una città iniziata con Denaro illimitato in una città normale con budget regolare.\n" +
                    "Abilitarlo sblocca il pulsante <[Converti salvataggio Denaro illimitato]> quando la città caricata è di tipo <Denaro illimitato>.\n" +
                    "City Watchdog non può annullare questa conversione.\n" +
                    "Per città normali non serve." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)), "Converti città Denaro illimitato a normale" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)),
                    "Per città avviate con <Denaro illimitato>.\n" +
                    "Mentre quella città è caricata, converte il salvataggio al budget normale limitato.\n" +
                    "Il pulsante è <disattivato/grigio> salvo che la città caricata sia di tipo <Denaro illimitato>\n" +
                    "e <Convertitore denaro illimitato> sia ON [ ✓ ].\n" +
                    "Fai un backup e usa a tuo rischio; City Watchdog non può annullarlo." },

                { m_Settings.GetOptionWarningLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)),
                    "Convertire questa città da Denaro illimitato a denaro limitato normale?\n" +
                    "Salva PRIMA un backup; City Watchdog non può annullarlo.\n" +
                    "Sei sicuro?" },

                // --------------------------------------------------------------------
                // About tab
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.NameText)), "Nome mod" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.NameText)), "Nome visualizzato di questa mod." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.VersionText)), "Versione" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.VersionText)), "Versione attuale della mod." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.OpenParadox)), "Paradox Mods" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.OpenParadox)), "Apre la pagina Paradox Mods dell’autore." },

                // --------------------------------------------------------------------
                // About tab - Diagnostics
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.WriteNotificationAuditLog)), "Report debug nel log" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.WriteNotificationAuditLog)),
                    "<Non necessario per il gioco normale.>\n" +
                    "Per tester e controlli dopo patch: scrive un report in <Logs/CityWatchdog.log>\n" +
                    "confrontando le notifiche live del gioco con le icone controllate da Watchdog." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.OpenLog)), "Apri log" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.OpenLog)),
                    "Apre </Logs/CityWatchdog.log> se esiste.\n" +
                    "Se manca il file, apre invece la cartella Logs/." },
            };

            return entries;
        }

        public void Unload()
        {
        }
    }
}
