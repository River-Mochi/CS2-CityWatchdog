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

    public sealed class LocaleIT : IDictionarySource
    {
        private readonly CwdSettings m_Settings;

        public LocaleIT(CwdSettings setting)
        {
            m_Settings = setting;
        }

        public IEnumerable<KeyValuePair<string, string>> ReadEntries(
            IList<IDictionaryEntryError> errors,
            Dictionary<string, int> indexCounts)
        {
            string title = Mod.ModName + " (Sentinella urbana)";

            Dictionary<string, string> entries = new()
            {
                // --- Mod title ---
                { m_Settings.GetSettingsLocaleID(), title },

                // --- Tabs ---
                { m_Settings.GetOptionTabLocaleID(CwdSettings.kActions), "Azioni" },
                { m_Settings.GetOptionTabLocaleID(CwdSettings.kMiniHudTab), "Mini-HUD" },
                { m_Settings.GetOptionTabLocaleID(CwdSettings.kMoneyTab), "Nuova città" },
                { m_Settings.GetOptionTabLocaleID(CwdSettings.kAbout), "Info" },

                // --- Groups, ordered by Options menu location ---
                { m_Settings.GetOptionGroupLocaleID(CwdSettings.kAboutUsage), "USO" },
                { m_Settings.GetOptionGroupLocaleID(CwdSettings.kNotifications), "Notifiche" },
                { m_Settings.GetOptionGroupLocaleID(CwdSettings.kMoneyViewGroup), "Info in città" },
                { m_Settings.GetOptionGroupLocaleID(CwdSettings.kMiniHudGroup), "Avvisi Mini HUD" },
                { m_Settings.GetOptionGroupLocaleID(CwdSettings.kMilestone), "IMPOSTAZIONI NUOVA CITTÀ" },
                { m_Settings.GetOptionGroupLocaleID(CwdSettings.kMoney), "Soldi" },
                { m_Settings.GetOptionGroupLocaleID(CwdSettings.kSaveConversion), "Converti salvataggio illimitato" },
                { m_Settings.GetOptionGroupLocaleID(CwdSettings.kAboutInfo), "" },
                { m_Settings.GetOptionGroupLocaleID(CwdSettings.kAboutLinks), "" },
                { m_Settings.GetOptionGroupLocaleID(CwdSettings.kAboutDiagnostics), "DIAGNOSTICA" },

                // --------------------------------------------------------------------
                // Actions tab - Usage
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.ShowUsage)), "Mostra istruzioni" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.ShowUsage)), "Mostra o nasconde le istruzioni qui sotto." },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.UsageText)),
                    "A. Usa l’icona zampa in alto a sinistra, o Shift+N, per aprire il pannello.\n" +
                    "<Pulsanti vista>\n" +
                    "1. Icona titolo: mostra/nasconde i suggerimenti di City Watchdog.\n" +
                    "\n" +
                    "2. Pulsante **[i]**: nasconde/mostra <TUTTI> i suggerimenti del gioco: edifici, cittadini, strumenti e barra in basso.\n" +
                    "3. Pulsante strade: nasconde/mostra nomi strade. Scorciatoia: \\.\n" +
                    "4. Pulsante distretti: nasconde/mostra nomi distretti.\n" +
                    "5. Pulsante frecce: attiva/disattiva le frecce a senso unico (nasconde anche i nomi strade).\n" +
                    "\n" +
                    "<Avvisi>\n" +
                    "1. Ordine: A→Z, Z→A, solo attivi.\n" +
                    "2. <[0/62]> = icone ATTIVE/totale. Clic: espandi/comprimi tutte le righe.\n" +
                    "3a. [Mostra icone] spegne/accende subito tutte le icone degli avvisi di problema.\n" +
                    "3b. Preimpostazioni [1 | 2]: clic per caricare; tieni premuto 1 secondo per salvare le caselle attuali.\n" +
                    "3c. Nascondere un’icona non risolve il problema della città.\n" +
                    "\n" +
                    "<Aiuti>\n" +
                    "1. Aggiungi / sottrai soldi: usa i tasti <[ o ]> per <Importo scorciatoia soldi>.\n" +
                    "2. Soldi automatici aggiunge soldi se la città scende sotto il limite scelto.\n" +
                    "3. Converti salvataggio Soldi illimitati vale solo per quelle città ed è <irreversibile>.\n" +
                    "\n" +
                    "<Suggerimenti menu basso>\n" +
                    "Vista soldi aggiunge dettagli come le tendenze al passaggio su soldi o popolazione.\n" +
                    "\n" +
                    "<Traguardo personalizzato>\n" +
                    "Nuova città imposta soldi iniziali o traguardi prima di caricare o iniziare una città."
                },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.UsageText)), "" },

                // --------------------------------------------------------------------
                // Actions tab - Notifications
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.ToggleNotificationsKeyboardBinding)), "Attiva/disattiva icone avviso" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.ToggleNotificationsKeyboardBinding)),
                    "<Scorciatoia> uguale al pulsante <[MOSTRA ICONE]> in gioco.\n" +
                    "Mostra o nasconde subito tutte le icone degli avvisi di problema."
                },
                { m_Settings.GetBindingKeyLocaleID(CwdSettings.ToggleNotificationsAction), "Mostra/nascondi subito le icone dei problemi" },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.ToggleNotificationPanelKeyboardBinding)), "Apri/chiudi pannello avvisi" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.ToggleNotificationPanelKeyboardBinding)),
                    "<Scorciatoia> per aprire o chiudere il\n" +
                    "<pannello avvisi> in città.\n" +
                    "Come cliccare l’icona in alto a sinistra."
                },
                { m_Settings.GetBindingKeyLocaleID(CwdSettings.ToggleNotificationPanelAction), "Apri/chiudi pannello avvisi" },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.PanelButtonsOnlyStart)), "Avvio solo pulsanti" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.PanelButtonsOnlyStart)),
                    "Se attivo [ ✓ ], City Watchdog apre prima la vista piccola solo pulsanti.\n" +
                    "Usa la freccia titolo o il contatore righe per aprire il pannello completo."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.ToggleRoadNamesKeyboardBinding)), "Nascondi/mostra nomi strade" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.ToggleRoadNamesKeyboardBinding)),
                    "<Scorciatoia> per nascondere/mostrare i nomi strade del gioco base.\n" +
                    "Come l’icona nomi strade nel pannello City Watchdog."
                },
                { m_Settings.GetBindingKeyLocaleID(CwdSettings.ToggleRoadNamesAction), "Nascondi/mostra nomi strade" },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.ToggleAllTooltipsKeyboardBinding)), "Disattiva tutti i suggerimenti" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.ToggleAllTooltipsKeyboardBinding)),
                    "<Scorciatoia> per nascondere/mostrare TUTTI i suggerimenti del gioco: edifici, cittadini, strumenti e icone in basso.\n" +
                    "<Le finestre soldi/popolazione di City Watchdog restano attive>; le controlla Vista soldi.\n" +
                    "Come l’icona [i] nel pannello City Watchdog."
                },
                { m_Settings.GetBindingKeyLocaleID(CwdSettings.ToggleAllTooltipsAction), "Nascondi/mostra suggerimenti del gioco" },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.InterfaceScaling)), "Interfaccia di gioco più grande" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.InterfaceScaling)),
                    "Se attivo [ ✓ ], <tutta l’interfaccia del gioco> viene ingrandita — pannelli del gioco e delle mod.\n" +
                    "Usa l’opzione del gioco <Scala interfaccia> senza il parametro <--developerMode>.\n" +
                    "Questa casella [x] è sincronizzata con il pulsante di scala nella barra del titolo di City Watchdog.\n" +
                    "Solo per il testo: Opzioni > Interfaccia > <Scala testo>.\n" +
                    "Resta attivo finché non lo disattivi, anche se rimuovi City Watchdog.\n" +
                    "- Disattivalo prima di disinstallare per tornare alla dimensione normale.\n" +
                    "- Oppure avvia una volta con <--developerMode> e disattiva Opzioni > Interfaccia > Scala interfaccia (dev)."
                },


                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.MainPanelOpacity)), "Opacità pannello principale" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.MainPanelOpacity)),
                    "Regola la trasparenza dello sfondo del pannello principale delle notifiche.\n" +
                    "Valori bassi: più trasparente. Valori alti: più scuro e opaco."
                },

                // --------------------------------------------------------------------
                // Actions tab - In-City Info Viewer
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.MoneyView)), "Tendenze soldi + popolazione" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.MoneyView)),
                    "<Consigliato>\n" +
                    "Menu in basso: mostra le tendenze sulle frecce <soldi e popolazione>.\n" +
                    "Funzione leggera al passaggio <solo visuale>;\n" +
                    "fa risparmiare tempo e può rendere meglio del pannello informazioni del gioco."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.MoneyViewMode)), "Frequenza Vista soldi" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.MoneyViewMode)),
                    "Scegli valori orari o mensili nella barra in basso.\n" +
                    "Mensile usa entrate meno spese e una proiezione popolazione di 24 h."
                },
                { m_Settings.GetOptionLocaleID("MoneyViewModeHourly"), "Orario (/h)" },
                { m_Settings.GetOptionLocaleID("MoneyViewModeMonthly"), "Mensile (/mo)" },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.MoneyTooltipMode)), "Stile suggerimento soldi" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.MoneyTooltipMode)),
                    "Scegli quanti dettagli mostra il suggerimento soldi.\n" +
                    "Compatto = predefinito alla prima installazione.\n" +
                    "<Mini> mostra solo 2 valori netti per /mo e /h.\n" +
                    "<Compatto> accorcia numeri grandi (15.21M invece di 15,212,318).\n" +
                    "<Dati completi> mostra valori lunghi e totali."
                },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeMini"), "Mini" },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeCompact"), "Compatto" },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeFullData"), "Dati completi" },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.MoneyTooltipFontScale)), "Dimensione testo soldi" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.MoneyTooltipFontScale)),
                    "Regola la <dimensione testo> dei numeri Vista soldi.\n" +
                    "Predefinito gioco = 100%\n" +
                    "<Predefinito mod = 120%>\n" +
                    "Passa su Soldi in basso.\n" +
                    "Per chi fatica a leggere suggerimenti piccoli."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.PopulationTooltipFontScale)), "Dimensione testo popolazione" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.PopulationTooltipFontScale)),
                    "Regola la <dimensione testo> dei numeri popolazione.\n" +
                    "Predefinito gioco = 100%\n" +
                    "<Predefinito mod = 120%>\n" +
                    "Passa su Popolazione in basso."
                },

                // --------------------------------------------------------------------
                // Mini-HUD tab - Mini HUD Notifications
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.MiniHudEnabled)), "Mini HUD" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.MiniHudEnabled)),
                    "Mostra un piccolo HUD con i contatori avviso più importanti.\n" +
                    "Usalo come barra rapida senza aprire il pannello completo.\n" +
                    "Clic su un’icona salta a un problema corrispondente.\n" +
                    "Altri clic scorrono i risultati e tornano al primo."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.ApplyMiniHudRecommendedPreset)), "Clic: avvio rapido" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.ApplyMiniHudRecommendedPreset)),
                    "Applica un <avvio rapido> al Mini HUD:\n" +
                    "Include una **selezione iniziale di stelle blu**.\n" +
                    "In modalità Preferiti, Mini HUD mostra i 5 o 10 conteggi attuali più alti della tua lista di **stelle blu**.\n" +
                    "Aggiungi/rimuovi le **stelle blu** nel pannello City Watchdog.\n" +
                    "Imposta: Preferiti, 5 icone, orizzontale, trascinabile, 100 %, pannello scuro e nasconde i conteggi 0.\n" +
                    "Esegui di nuovo Avvio rapido in qualsiasi momento per ripristinare queste impostazioni."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.MiniHudMode)), "Modalità mini pannello" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.MiniHudMode)),
                    "Scegli quali righe di avviso usa il mini pannello.\n" +
                    "**Più attivi** mostra i conteggi attuali più alti.\n" +
                    "**Preferiti** usa le righe con **stella blu** nel pannello principale City Watchdog.\n" +
                    "Puoi scegliere tutti i preferiti che vuoi,\n" +
                    "ma il mini pannello mostra solo i 5 o 10 conteggi più alti di quella lista di **stelle blu**."
                },
                { m_Settings.GetOptionLocaleID("MiniHudModeTopActive"), "Avvisi più attivi" },
                { m_Settings.GetOptionLocaleID("MiniHudModeFavorites"), "Preferiti" },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.MiniHudItemCount)), "Numero icone" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.MiniHudItemCount)), "Scegli quante icone può mostrare il Mini HUD." },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.MiniHudScale)), "Dimensione icone" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.MiniHudScale)),
                    "Scala icone e numeri del Mini HUD.\n" +
                    "90% = compatto. 100% = predefinito. Fino a 130% per vedere meglio."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.MiniHudOrientation)), "Orientamento" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.MiniHudOrientation)), "Scegli riga o colonna." },
                { m_Settings.GetOptionLocaleID("MiniHudOrientationHorizontal"), "Orizzontale" },
                { m_Settings.GetOptionLocaleID("MiniHudOrientationVertical"), "Verticale" },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.MiniHudPlacement)), "Posizione HUD" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.MiniHudPlacement)),
                    "Scegli dove appare il Mini HUD.\n" +
                    "Trascinabile permette di spostarlo nell’interfaccia città."
                },
                { m_Settings.GetOptionLocaleID("MiniHudPlacementTopCenter"), "Alto centro" },
                { m_Settings.GetOptionLocaleID("MiniHudPlacementTopRight"), "Alto destra" },
                { m_Settings.GetOptionLocaleID("MiniHudPlacementDraggable"), "Trascinabile" },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.MiniHudPanelStyle)), "Stile scuro o vetro" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.MiniHudPanelStyle)),
                    "Scegli lo sfondo del Mini HUD.\n" +
                    "Vetro va da chiaro a bianco velato; non diventa scuro.\n" +
                    "Usa Scuro per un HUD più scuro stile gioco."
                },
                { m_Settings.GetOptionLocaleID("MiniHudPanelStyleDark"), "Pannello scuro" },
                { m_Settings.GetOptionLocaleID("MiniHudPanelStyleGlass"), "Pannello vetro" },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.MiniHudPanelOpacity)), "Opacità sfondo" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.MiniHudPanelOpacity)),
                    "Regola la trasparenza dello sfondo Mini HUD.\n" +
                    "Basso = più trasparente. Alto = più solido.\n" +
                    "Vetro diventa più bianco. Scuro più solido/scuro."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.MiniHudHideZero)), "Nascondi avvisi a 0" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.MiniHudHideZero)), "Se attivo [ ✓ ], Mini HUD nasconde righe con contatore 0." },

                // --------------------------------------------------------------------
                // City Start tab - New City Start Settings
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.InitialMoney)), "Soldi iniziali" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.InitialMoney)),
                    "Imposta il saldo della prossima città con <soldi limitati> che carichi — nuova o esistente.\n" +
                    "Dopo una sola applicazione, torna al valore predefinito del gioco.\n" +
                    "È disattivato quando una città è già caricata.\n" +
                    "Impostalo prima di caricare o iniziare la città. Poi usa <Importo scorciatoia soldi> se serve."
                },

                { m_Settings.GetOptionLocaleID("GameDefault"), "Predefinito gioco" },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.CustomMilestone)), "Selettore traguardo" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.CustomMilestone)),
                    "Attiva <prima di caricare o iniziare> per sbloccare un traguardo al caricamento.\n" +
                    "- Non può essere acceso con città caricata, ma può essere spento.\n" +
                    "- Se dimenticato, riavvia il gioco e scegli prima di entrare.\n" +
                    "- Il mod non annulla traguardi già salvati; usa un salvataggio precedente."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.MilestoneLevel)), "Traguardo" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.MilestoneLevel)),
                    "Scegli il traguardo per il prossimo caricamento.\n" +
                    "Regolabile <solo fuori da una città caricata> e con [Selettore traguardo] attivo [ ✓ ].\n" +
                    "Se la città è già a quel traguardo o oltre, non succede nulla.\n" +
                    "Cambia solo se il traguardo scelto è più alto."
                },

                // --------------------------------------------------------------------
                // City Start tab - Money
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.ManualMoneyAmount)), "Importo scorciatoia soldi" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.ManualMoneyAmount)),
                    "Usa questo importo con le scorciatoie Aggiungi e Sottrai soldi.\n" +
                    "<Predefinito mod = 40.000>\n" +
                    "Non fa nulla senza usare la scorciatoia in città.\n" +
                    "Per automatizzare, attiva Soldi automatici."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.AddMoneyKeyboardBinding)), "Aggiungi soldi" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.AddMoneyKeyboardBinding)), "Scorciatoia per <Aggiungi soldi> in città." },
                { m_Settings.GetBindingKeyLocaleID(CwdSettings.AddMoneyAction), "Aggiungi soldi" },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.SubtractMoneyKeyboardBinding)), "Sottrai soldi" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.SubtractMoneyKeyboardBinding)), "Scorciatoia per <Sottrai soldi> in città." },
                { m_Settings.GetBindingKeyLocaleID(CwdSettings.SubtractMoneyAction), "Sottrai soldi" },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.AutomaticAddMoney)), "Soldi automatici" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.AutomaticAddMoney)),
                    "Se attivo [ ✓ ], City Watchdog controlla il saldo della città.\n" +
                    "- Se il saldo è <sotto la soglia>, aggiunge quanto basta per raggiungerla.\n" +
                    "- Aggiunge sempre almeno l’Importo soldi automatici scelto.\n" +
                    "- Per necessità occasionali sono consigliate le scorciatoie manuali (<[> o <]>)."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.AutomaticAddMoneyThreshold)), "Soglia soldi automatici" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.AutomaticAddMoneyThreshold)),
                    "Se Soldi automatici è attivo e il saldo scende sotto questo valore,\n" +
                    "vengono aggiunti soldi fino a raggiungere almeno questa soglia."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.AutomaticAddMoneyAmount)), "Importo automatico" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.AutomaticAddMoneyAmount)),
                    "Importo minimo aggiunto a ogni attivazione di Soldi automatici.\n" +
                    "Se serve di più per raggiungere la soglia, City Watchdog aggiunge l’importo maggiore."
                },

                // --------------------------------------------------------------------
                // City Start tab - Save Conversion
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.ConfirmUnlimitedMoneySaveConversion)), "Convertitore soldi illimitati" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.ConfirmUnlimitedMoneySaveConversion)),
                    "<Fai PRIMA una copia di sicurezza della città>.\n" +
                    "Converte una città avviata con Soldi illimitati in città normale.\n" +
                    "Attivandolo sblocchi <[Converti salvataggio Soldi illimitati]> se la città caricata è <Soldi illimitati>.\n" +
                    "City Watchdog non può annullare la conversione.\n" +
                    "Se hai città normali, non serve."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.ConvertUnlimitedMoneySave)), "Converti città Soldi illimitati in normale" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.ConvertUnlimitedMoneySave)),
                    "Per città iniziate con <Soldi illimitati>.\n" +
                    "Con la città caricata, converte il salvataggio a budget normale limitato.\n" +
                    "Il pulsante è <disabilitato/grigio> salvo se la città è <Soldi illimitati>\n" +
                    "e <Convertitore soldi illimitati> è ATTIVO [ ✓ ].\n" +
                    "Fai una copia di sicurezza; usalo a tuo rischio. City Watchdog non annulla."
                },

                { m_Settings.GetOptionWarningLocaleID(nameof(CwdSettings.ConvertUnlimitedMoneySave)),
                    "Convertire questa città da Soldi illimitati a soldi limitati normali?\n" +
                    "Salva PRIMA una copia di sicurezza; City Watchdog non può annullare.\n" +
                    "Sei sicuro?"
                },

                // --------------------------------------------------------------------
                // About tab
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.NameText)), "Nome mod" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.NameText)), "Nome visualizzato del mod." },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.VersionText)), "Versione" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.VersionText)), "Versione attuale del mod." },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.OpenParadox)), "Paradox Mods" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.OpenParadox)), "Apre la pagina Paradox Mods dell’autore." },

                // --------------------------------------------------------------------
                // About tab - Diagnostics
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.WriteNotificationAuditLog)), "Rapporto diagnostico" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.WriteNotificationAuditLog)),
                    "<Non serve per giocare normalmente.>\n" +
                    "Per i test e dopo gli aggiornamenti del gioco: scrive un rapporto in <Logs/CityWatchdog.log>\n" +
                    "confrontando gli avvisi attuali del gioco con le icone gestite da Watchdog."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.OpenLog)), "Apri registro" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.OpenLog)),
                    "Apre </Logs/CityWatchdog.log> se esiste.\n" +
                    "Se manca, apre la cartella Logs/."
                },
            };

            return entries;
        }

        public void Unload()
        {
        }
    }
}
