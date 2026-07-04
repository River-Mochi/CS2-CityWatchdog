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
                { m_Settings.GetOptionTabLocaleID(Setting.MiniHudTab), "Mini-HUD" },
                { m_Settings.GetOptionTabLocaleID(Setting.MoneyTab), "Denaro-Traguardi" },
                { m_Settings.GetOptionTabLocaleID(Setting.About), "Info" },

                // --- Groups, ordered by Options menu location ---
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutUsage), "USO" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Notifications), "Notifiche" },
                { m_Settings.GetOptionGroupLocaleID(Setting.MoneyViewGroup), "Info in città" },
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
                    "<Comandi visivi>\n" +
                    "1. Pulsante [i]: mostra/nasconde TUTTI i tooltip del gioco.\n" +
                    "2. Nomi strade: mostra/nasconde i nomi. Scorciatoia: \\.\n" +
                    "3. Nomi distretti: mostra/nasconde i nomi senza cambiare i confini.\n" +
                    "4. Frecce stradali: forza le frecce a senso unico (nasconde anche i nomi strade).\n" +
                    "5. Icona CWD: mostra/nasconde i tooltip del pannello City Watchdog.\n\n" +
                    "<Avvisi>\n" +
                    "1. Clicca City Watchdog in alto a sinistra o premi Shift+N.\n" +
                    "2. Pulsante ordine: crescente/decrescente.\n" +
                    "3. Toggle All accende/spegne tutto, oppure apri una sezione per scegliere.\n" +
                    "4. Nasconde solo le icone; non risolve il problema della città.\n\n" +
                    "<Aiuti denaro>\n" +
                    "1. Aggiungi o sottrai denaro: usa i tasti [ e ].\n" +
                    "2. Il denaro automatico aggiunge fondi sotto il limite scelto.\n" +
                    "3. Converti Denaro Illimitato vale solo per quelle città ed è <irreversibile>.\n\n" +
                    "<Tooltip menu in basso>\n" +
                    "Money View aggiunge trend denaro/popolazione e dettagli al passaggio del mouse.\n\n" +
                    "<Traguardo personalizzato>\n" +
                    "Imposta denaro iniziale e traguardo prima di caricare o iniziare una città."
                },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.UsageText)), "" },

                // --------------------------------------------------------------------
                // Actions tab - Notifications
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleNotificationsKeyboardBinding)), "Attiva/disattiva icone avviso" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleNotificationsKeyboardBinding)),
                    "<Scorciatoia> per la stessa azione del pulsante <[TOGGLE ALL]> in gioco.\n" +
                    "Mostra o nasconde subito tutte le icone elencate." },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleNotificationsAction), "Mostra/nasconde subito tutte le icone avviso" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleNotificationPanelKeyboardBinding)), "Apri/chiudi pannello avvisi" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleNotificationPanelKeyboardBinding)),
                    "<Scorciatoia> per aprire o chiudere il\n" +
                    "<pannello avvisi> in città.\n" +
                    "Come cliccare l’icona in alto a sinistra."
                },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleNotificationPanelAction), "Apri/chiudi pannello avvisi" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.PanelButtonsOnlyStart)), "Avvio solo pulsanti" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.PanelButtonsOnlyStart)),
                    "Se attivo [ ✓ ], City Watchdog parte nella vista piccola solo pulsanti.\n" +
                    "Usa la freccia del titolo o il contatore righe per aprire il pannello completo." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleRoadNamesKeyboardBinding)), "Nascondi/mostra nomi strade" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleRoadNamesKeyboardBinding)),
                    "<Scorciatoia> per mostrare/nascondere i nomi strade vanilla.\n" +
                    "Come l’icona Nomi strade nel pannello City Watchdog." },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleRoadNamesAction), "Nascondi/mostra nomi strade" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleAllTooltipsKeyboardBinding)), "Disattiva tutti i tooltip al passaggio" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleAllTooltipsKeyboardBinding)),
                    "<Scorciatoia> per mostrare/nascondere TUTTI i tooltip del gioco.\n" +
                    "<I popup denaro/popolazione di City Watchdog restano attivi>; sono controllati da Money View.\n" +
                    "Come cliccare l’icona [i] nel pannello." },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleAllTooltipsAction), "Mostra/nascondi tooltip del gioco" },

                // --------------------------------------------------------------------
                // Actions tab - In-City Info Viewer
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyView)), "Mostra tooltip denaro + popolazione" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyView)),
                    "<Consigliato>\n" +
                    "Menu in basso: mostra trend sulle frecce denaro e popolazione.\n" +
                    "Funzione leggera al passaggio del mouse <solo visuale>;\n" +
                    "Riduce il bisogno di aprire il pannello info del gioco."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyViewMode)), "Frequenza Money View" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyViewMode)),
                    "Scegli trend orari o mensili nel menu in basso.\n" +
                    "Mensile usa entrate meno uscite e proiezione popolazione 24 ore." },
                { m_Settings.GetOptionLocaleID("MoneyViewModeHourly"), "Orario (/h)" },
                { m_Settings.GetOptionLocaleID("MoneyViewModeMonthly"), "Mensile (/mo)" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyTooltipMode)), "Stile tooltip denaro" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyTooltipMode)),
                    "Scegli quanti dettagli mostra il tooltip denaro.\n" +
                    "Compatto = predefinito al primo avvio.\n" +
                    "<Mini> mostra solo 2 valori netti /mo e /h.\n" +
                    "<Compatto> abbrevia i numeri grandi (15.21M invece di 15,212,318).\n" +
                    "<Dati completi> mostra valori lunghi e totali." },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeMini"), "Mini" },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeCompact"), "Compatto" },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeFullData"), "Dati completi" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyTooltipFontScale)), "Dimensione testo denaro" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyTooltipFontScale)),
                    "Regola la <dimensione testo> dei numeri Money View.\n" +
                    "Predefinito gioco = 100%\n" +
                    "<Predefinito mod = 120%>\n" +
                    "Passa il mouse su Denaro in basso.\n" +
                    "Per chi fatica a leggere tooltip piccoli."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.PopulationTooltipFontScale)), "Dimensione testo popolazione" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.PopulationTooltipFontScale)),
                    "Regola la <dimensione testo> dei numeri popolazione.\n" +
                    "Predefinito gioco = 100%\n" +
                    "<Predefinito mod = 120%>\n" +
                    "Passa il mouse su Popolazione in basso."
                },

                // --------------------------------------------------------------------
                // Mini-HUD tab - Mini HUD Notifications
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudEnabled)), "Mini HUD" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudEnabled)),
                    "Mostra un piccolo HUD con i conteggi importanti.\n" +
                    "Usalo come barra rapida senza aprire il pannello completo.\n" +
                    "Clic su un’icona salta a un problema corrispondente.\n" +
                    "Riclicca per scorrere altri punti e tornare al primo."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ApplyMiniHudRecommendedPreset)), "Set iniziale consigliato" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ApplyMiniHudRecommendedPreset)),
                    "Applica una configurazione Mini HUD consigliata:\n" +
                    "Preferiti, 5 icone, orizzontale, alto centro, 100%, pannello scuro.\n" +
                    "Gli avvisi a zero restano visibili.\n" +
                    "Aggiungi/rimuovi preferiti **Stella blu** nel pannello esteso.\n" +
                    "I preferiti **Stella blu** iniziali sono inclusi in **[Consigliato]**."
                  },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudMode)), "Modalità Mini HUD" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudMode)),
                    "Scegli quali righe usa il Mini HUD.\n" +
                    "**Avvisi attivi** mostra i conteggi più alti.\n" +
                    "**Preferiti** include le righe con **Stella blu**.\n" +
                    "Puoi scegliere quanti preferiti vuoi,\n" +
                    "ma il Mini HUD mostra solo i primi 5 o 10 conteggi di quella lista." },
                { m_Settings.GetOptionLocaleID("MiniHudModeTopActive"), "Avvisi attivi" },
                { m_Settings.GetOptionLocaleID("MiniHudModeFavorites"), "Preferiti" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudItemCount)), "Numero icone Mini HUD" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudItemCount)),
                    "Scegli quante icone può mostrare il Mini HUD." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudScale)), "Dimensione Mini HUD" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudScale)),
                    "Scala icone e numeri del Mini HUD.\n" +
                    "90% = compatto. 100% = base. Fino a 130% per vedere meglio." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudOrientation)), "Orientamento Mini HUD" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudOrientation)),
                    "Scegli riga o colonna." },
                { m_Settings.GetOptionLocaleID("MiniHudOrientationHorizontal"), "Orizzontale" },
                { m_Settings.GetOptionLocaleID("MiniHudOrientationVertical"), "Verticale" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudPlacement)), "Posizione Mini HUD" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudPlacement)),
                    "Scegli dove appare il Mini HUD.\n" +
                    "Trascinabile permette di spostarlo nell’interfaccia." },
                { m_Settings.GetOptionLocaleID("MiniHudPlacementTopCenter"), "Alto centro" },
                { m_Settings.GetOptionLocaleID("MiniHudPlacementTopRight"), "Alto destra" },
                { m_Settings.GetOptionLocaleID("MiniHudPlacementDraggable"), "Trascinabile" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudPanelStyle)), "Stile Mini HUD" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudPanelStyle)),
                    "Scegli lo sfondo del Mini HUD.\n" +
                    "Vetro va da chiaro a bianco velato; non diventa più scuro.\n" +
                    "Usa pannello scuro per un HUD vanilla più scuro." },
                { m_Settings.GetOptionLocaleID("MiniHudPanelStyleDark"), "Pannello scuro" },
                { m_Settings.GetOptionLocaleID("MiniHudPanelStyleGlass"), "Pannello vetro" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudPanelOpacity)), "Opacità Mini HUD" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudPanelOpacity)),
                    "Regola la trasparenza dello sfondo.\n" +
                    "Più basso = più trasparente. Più alto = più solido.\n" +
                    "Vetro diventa più bianco; scuro più solido/scuro." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudHideZero)), "Nascondi avvisi a zero" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudHideZero)),
                    "Se attivo [ ✓ ], nasconde righe con conteggio 0." },

                // --------------------------------------------------------------------
                // Money-Milestones tab - New City Start Settings
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.InitialMoney)), "Denaro iniziale" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.InitialMoney)),
                    "Imposta il saldo iniziale per una nuova città con <denaro limitato>,\n" +
                    "poi torna al valore predefinito del gioco.\n" +
                    "Disattivato se una città è già caricata.\n" +
                    "Impostalo prima di caricare/iniziare. Poi usa <Importo hotkey denaro> o <Denaro automatico>." },
                { m_Settings.GetOptionLocaleID("GameDefault"), "Predefinito gioco" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.CustomMilestone)), "Selettore traguardo" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.CustomMilestone)),
                    "Attiva <prima di caricare o iniziare> per sbloccare un traguardo al caricamento.\n" +
                    "- Non si può attivare a città caricata, ma si può spegnere.\n" +
                    "- Se hai dimenticato, riavvia il gioco e scegli prima di entrare in città.\n" +
                    "- Il mod non annulla traguardi già salvati; usa un salvataggio precedente."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MilestoneLevel)), "Traguardo" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MilestoneLevel)),
                    "Scegli il traguardo da sbloccare al prossimo caricamento.\n" +
                    "Regolabile <solo fuori da una città caricata> e con [Selettore traguardo] attivo [ ✓ ].\n" +
                    "Se la città è già a quel livello o oltre, non succede nulla.\n" +
                    "Cambia solo se il traguardo scelto è più alto."
                },

                // --------------------------------------------------------------------
                // Money-Milestones tab - Money
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ManualMoneyAmount)), "Importo hotkey denaro" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ManualMoneyAmount)),
                    "Usa questo importo con Aggiungi e Sottrai denaro.\n" +
                    "<Predefinito mod = 40.000>\n" +
                    "Non fa nulla senza usare l’hotkey in città.\n" +
                    "Per automatizzare, attiva Denaro automatico."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AddMoneyKeyboardBinding)), "Aggiungi denaro" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AddMoneyKeyboardBinding)),
                    "Hotkey per <Aggiungi denaro> in città." },
                { m_Settings.GetBindingKeyLocaleID(Setting.AddMoneyAction), "Aggiungi denaro" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.SubtractMoneyKeyboardBinding)), "Sottrai denaro" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.SubtractMoneyKeyboardBinding)),
                    "Hotkey per <Sottrai denaro> in città." },
                { m_Settings.GetBindingKeyLocaleID(Setting.SubtractMoneyAction), "Sottrai denaro" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoney)), "Denaro automatico" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoney)),
                    "Se attivo [ ✓ ], City Watchdog controlla il saldo della città.\n" +
                    "- Se il saldo è <sotto la soglia>, \n" +
                    "  aggiunge l’importo scelto.\n" +
                    "- Meglio usare il denaro manuale con hotkey (<[> o <]>) quando serve" +
                    "  invece dell’automatico, ma l’opzione c’è."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoneyThreshold)), "Soglia denaro automatico" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoneyThreshold)),
                    "Se attivo e il saldo scende sotto questo valore,\n" +
                    "aggiunge l’importo scelto." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoneyAmount)), "Importo automatico" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoneyAmount)),
                    "Importo aggiunto a ogni attivazione automatica.\n" +
                    "Scegli abbastanza per superare la soglia." },

                // --------------------------------------------------------------------
                // Money-Milestones tab - Save Conversion
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ConfirmUnlimitedMoneySaveConversion)), "Convertitore denaro illimitato" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ConfirmUnlimitedMoneySaveConversion)),
                    "<Fai PRIMA un backup>.\n" +
                    "Converte una città nata con Denaro illimitato in città normale.\n" +
                    "Sblocca il pulsante <[Converti salvataggio Denaro illimitato]> se la città caricata è di tipo <Denaro illimitato>.\n" +
                    "City Watchdog non può annullare questa conversione.\n" +
                    "Se le città sono normali, non serve." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)), "Converti città Denaro illimitato in normale" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)),
                    "Per città iniziate con <Denaro illimitato>.\n" +
                    "Con la città caricata, converte il salvataggio a budget normale.\n" +
                    "Pulsante <disattivato/grigio> salvo se la città è <Denaro illimitato>\n" +
                    "e <Convertitore denaro illimitato> è ATTIVO [ ✓ ].\n" +
                    "Fai un backup e usa a tuo rischio; City Watchdog non può annullare." },

                { m_Settings.GetOptionWarningLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)),
                    "Convertire questa città da Denaro illimitato a denaro limitato normale?\n" +
                    "Salva un backup PRIMA; City Watchdog non può annullare.\n" +
                    "Sei sicuro?" },

                // --------------------------------------------------------------------
                // About tab
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.NameText)), "Nome mod" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.NameText)), "Nome visualizzato del mod." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.VersionText)), "Versione" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.VersionText)), "Versione attuale del mod." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.OpenParadox)), "Paradox Mods" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.OpenParadox)), "Apre la pagina Paradox Mods dell’autore." },

                // --------------------------------------------------------------------
                // About tab - Diagnostics
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.WriteNotificationAuditLog)), "Rapporto debug nel log" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.WriteNotificationAuditLog)),
                    "<Non serve per giocare normalmente.>\n" +
                    "Per test e patch del gioco: scrive un rapporto in <Logs/CityWatchdog.log>\n" +
                    "confrontando le notifiche live con le icone controllate da Watchdog." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.OpenLog)), "Apri log" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.OpenLog)),
                    "Apre </Logs/CityWatchdog.log> se esiste.\n" +
                    "Se manca, apre la cartella Logs/." },
            };

            return entries;
        }

        public void Unload()
        {
        }
    }
}
