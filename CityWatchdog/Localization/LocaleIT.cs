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
            string title = Mod.ModName + " (Sentinella urbana)";

            Dictionary<string, string> entries = new Dictionary<string, string>
            {
                { m_Settings.GetSettingsLocaleID(), title },
                { m_Settings.GetOptionTabLocaleID(Setting.Actions), "Azioni" },
                { m_Settings.GetOptionTabLocaleID(Setting.MiniHudTab), "Mini-HUD" },
                { m_Settings.GetOptionTabLocaleID(Setting.MoneyTab), "Soldi-Traguardi" },
                { m_Settings.GetOptionTabLocaleID(Setting.About), "Info" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutUsage), "USO" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Notifications), "Notifiche" },
                { m_Settings.GetOptionGroupLocaleID(Setting.MoneyViewGroup), "Info in città" },
                { m_Settings.GetOptionGroupLocaleID(Setting.MiniHudGroup), "Avvisi Mini HUD" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Milestone), "IMPOSTAZIONI NUOVA CITTÀ" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Money), "Soldi" },
                { m_Settings.GetOptionGroupLocaleID(Setting.SaveConversion), "Converti salvataggio illimitato" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutInfo), "" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutLinks), "" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutDiagnostics), "DIAGNOSTICA" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ShowUsage)), "Mostra istruzioni" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ShowUsage)), "Mostra o nasconde le istruzioni qui sotto." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.UsageText)),
                    "A. Usa l’icona zampa in alto a sinistra, o Shift+N, per aprire il pannello.\n" +
                    "<Pulsanti vista>\n" +
                    "1. Icona titolo: mostra/nasconde i tooltip di City Watchdog.\n" +
                    "\n" +
                    "2. Pulsante **[i]**: nasconde/mostra <TUTTI> i tooltip del gioco: edifici, cittadini, strumenti, barra in basso.\n" +
                    "3. Pulsante strade: nasconde/mostra nomi strade. Scorciatoia: \\.\n" +
                    "4. Pulsante distretti: nasconde/mostra nomi distretti.\n" +
                    "5. Pulsante frecce: forza frecce senso unico on/off (nasconde anche i nomi strade).\n" +
                    "\n" +
                    "<Avvisi>\n" +
                    "1. Ordine: A→Z, Z→A, solo attivi.\n" +
                    "2. <[0/63]> = icone ON/totale. Clic: espandi/comprimi tutte le righe.\n" +
                    "3a. [Attiva tutto] spegne/accende subito tutte le icone avviso.\n" +
                    "3b. Nasconde solo le icone; non risolve il problema della città.\n" +
                    "\n" +
                    "<Aiuti soldi>\n" +
                    "1. Aggiungi / sottrai soldi: usa i tasti <[ o ]> per <Importo scorciatoia soldi>.\n" +
                    "2. Soldi automatici aggiunge soldi se la città scende sotto il limite scelto.\n" +
                    "3. Converti salvataggio Soldi illimitati vale solo per quelle città ed è <irreversibile>.\n" +
                    "\n" +
                    "<Tooltip menu basso>\n" +
                    "Vista soldi aggiunge dettagli come trend al passaggio su soldi o popolazione.\n" +
                    "\n" +
                    "<Traguardo personalizzato>\n" +
                    "Soldi-Traguardi > IMPOSTAZIONI NUOVA CITTÀ imposta soldi iniziali o traguardi prima di caricare/iniziare." },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.UsageText)), "" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleNotificationsKeyboardBinding)), "Attiva/disattiva icone avviso" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleNotificationsKeyboardBinding)),
                    "<Scorciatoia> uguale al pulsante <[Attiva tutto]> in gioco.\n" +
                    "Mostra o nasconde subito tutte le icone avviso elencate." },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleNotificationsAction), "Mostra/nascondi tutte le icone avviso" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleNotificationPanelKeyboardBinding)), "Apri/chiudi pannello avvisi" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleNotificationPanelKeyboardBinding)),
                    "<Scorciatoia> per aprire o chiudere il\n" +
                    "<pannello avvisi> in città.\n" +
                    "Come cliccare l’icona in alto a sinistra." },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleNotificationPanelAction), "Apri/chiudi pannello avvisi" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.PanelButtonsOnlyStart)), "Avvio solo pulsanti" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.PanelButtonsOnlyStart)),
                    "Se attivo [ ✓ ], City Watchdog apre prima la vista piccola solo pulsanti.\n" +
                    "Usa la freccia titolo o il contatore righe per aprire il pannello completo." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleRoadNamesKeyboardBinding)), "Nascondi/mostra nomi strade" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleRoadNamesKeyboardBinding)),
                    "<Scorciatoia> per nascondere/mostrare i nomi strade del gioco base.\n" +
                    "Come l’icona nomi strade nel pannello City Watchdog." },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleRoadNamesAction), "Nascondi/mostra nomi strade" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleAllTooltipsKeyboardBinding)), "Disattiva tutti i tooltip" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleAllTooltipsKeyboardBinding)),
                    "<Scorciatoia> per nascondere/mostrare TUTTI i tooltip del gioco: edifici, cittadini, strumenti e icone in basso.\n" +
                    "<I popup soldi/popolazione di City Watchdog restano attivi>; li controlla Vista soldi.\n" +
                    "Come l’icona [i] nel pannello City Watchdog." },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleAllTooltipsAction), "Nascondi/mostra tooltip del gioco" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyView)), "Trend soldi + popolazione" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyView)),
                    "<Consigliato>\n" +
                    "Menu in basso: mostra trend sulle frecce <soldi e popolazione>.\n" +
                    "Funzione leggera al passaggio <solo visuale>;\n" +
                    "fa risparmiare tempo e può rendere meglio del pannello info del gioco." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyViewMode)), "Frequenza Vista soldi" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyViewMode)),
                    "Scegli valori orari o mensili nella barra in basso.\n" +
                    "Mensile usa entrate meno spese e proiezione popolazione 24 h." },
                { m_Settings.GetOptionLocaleID("MoneyViewModeHourly"), "Orario (/h)" },
                { m_Settings.GetOptionLocaleID("MoneyViewModeMonthly"), "Mensile (/mo)" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyTooltipMode)), "Stile tooltip soldi" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyTooltipMode)),
                    "Scegli quanti dettagli mostra il tooltip soldi.\n" +
                    "Compatto = predefinito alla prima installazione.\n" +
                    "<Mini> mostra solo 2 valori netti per /mo e /h.\n" +
                    "<Compatto> accorcia numeri grandi (15.21M invece di 15,212,318).\n" +
                    "<Dati completi> mostra valori lunghi e totali." },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeMini"), "Mini" },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeCompact"), "Compatto" },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeFullData"), "Dati completi" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyTooltipFontScale)), "Dimensione testo soldi" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyTooltipFontScale)),
                    "Regola la <dimensione testo> dei numeri Vista soldi.\n" +
                    "Default gioco = 100%\n" +
                    "<Default mod = 120%>\n" +
                    "Passa su Soldi in basso.\n" +
                    "Per chi fatica a leggere tooltip piccoli." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.PopulationTooltipFontScale)), "Dimensione testo popolazione" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.PopulationTooltipFontScale)),
                    "Regola la <dimensione testo> dei numeri popolazione.\n" +
                    "Default gioco = 100%\n" +
                    "<Default mod = 120%>\n" +
                    "Passa su Popolazione in basso." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudEnabled)), "Mini HUD" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudEnabled)),
                    "Mostra un piccolo HUD con i contatori avviso più importanti.\n" +
                    "Usalo come barra rapida senza aprire il pannello completo.\n" +
                    "Clic su un’icona salta a un problema corrispondente.\n" +
                    "Altri clic scorrono i risultati e tornano al primo." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ApplyMiniHudRecommendedPreset)), "Clic: avvio rapido" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ApplyMiniHudRecommendedPreset)),
                    "Applica un <avvio rapido> per Mini HUD:\n" +
                    "Include un **set iniziale di preferiti Blue Star**.\n" +
                    "Aggiungi/rimuovi preferiti **Blue Star** nel pannello Watchdog aperto.\n" +
                    "Preferiti, 5 icone, verticale, trascinabile, dimensione 100%, pannello scuro.\n" +
                    "Gli avvisi con 0 sono nascosti.\n"
                  },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudMode)), "Modalità Mini HUD" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudMode)),
                    "Scegli quali righe usa il Mini HUD.\n" +
                    "**Top attivi** mostra i conteggi attuali più alti.\n" +
                    "**Preferiti** usa le righe con **Blue Star** nel pannello principale City Watchdog.\n" +
                    "Puoi scegliere tutti i preferiti che vuoi,\n" +
                    "ma Mini HUD mostra solo top 5 o top 10 da quella lista **Blue Star**."
                  },
                { m_Settings.GetOptionLocaleID("MiniHudModeTopActive"), "Top avvisi attivi" },
                { m_Settings.GetOptionLocaleID("MiniHudModeFavorites"), "Preferiti" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudItemCount)), "Numero icone" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudItemCount)), "Scegli quante icone può mostrare il Mini HUD." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudScale)), "Dimensione icone" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudScale)),
                    "Scala icone e numeri del Mini HUD.\n" +
                    "90% = compatto. 100% = default. Fino a 130% per vedere meglio." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudOrientation)), "Orientamento" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudOrientation)), "Scegli riga o colonna." },
                { m_Settings.GetOptionLocaleID("MiniHudOrientationHorizontal"), "Orizzontale" },
                { m_Settings.GetOptionLocaleID("MiniHudOrientationVertical"), "Verticale" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudPlacement)), "Posizione HUD" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudPlacement)),
                    "Scegli dove appare il Mini HUD.\n" +
                    "Trascinabile permette di spostarlo nell’interfaccia città." },
                { m_Settings.GetOptionLocaleID("MiniHudPlacementTopCenter"), "Alto centro" },
                { m_Settings.GetOptionLocaleID("MiniHudPlacementTopRight"), "Alto destra" },
                { m_Settings.GetOptionLocaleID("MiniHudPlacementDraggable"), "Trascinabile" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudPanelStyle)), "Stile scuro o vetro" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudPanelStyle)),
                    "Scegli lo sfondo del Mini HUD.\n" +
                    "Vetro va da chiaro a bianco velato; non diventa scuro.\n" +
                    "Usa Scuro per un HUD più scuro stile gioco." },
                { m_Settings.GetOptionLocaleID("MiniHudPanelStyleDark"), "Pannello scuro" },
                { m_Settings.GetOptionLocaleID("MiniHudPanelStyleGlass"), "Pannello vetro" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudPanelOpacity)), "Opacità sfondo" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudPanelOpacity)),
                    "Regola la trasparenza dello sfondo Mini HUD.\n" +
                    "Basso = più trasparente. Alto = più solido.\n" +
                    "Vetro diventa più bianco. Scuro più solido/scuro." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudHideZero)), "Nascondi avvisi a 0" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudHideZero)), "Se attivo [ ✓ ], Mini HUD nasconde righe con contatore 0." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.InitialMoney)), "Soldi iniziali" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.InitialMoney)),
                    "Imposta il saldo iniziale per una nuova città con <soldi limitati> o la prima città caricata,\n" +
                    "poi torna al default del gioco.\n" +
                    "Disattivato se una città è già caricata.\n" +
                    "Imposta prima di caricare/iniziare. Poi usa <Importo scorciatoia soldi> o <Soldi automatici>." },
                { m_Settings.GetOptionLocaleID("GameDefault"), "Default gioco" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.CustomMilestone)), "Selettore traguardo" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.CustomMilestone)),
                    "Attiva <prima di caricare o iniziare> per sbloccare un traguardo al caricamento.\n" +
                    "- Non può essere acceso con città caricata, ma può essere spento.\n" +
                    "- Se dimenticato, riavvia il gioco e scegli prima di entrare.\n" +
                    "- Il mod non annulla traguardi già salvati; usa un salvataggio precedente." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MilestoneLevel)), "Traguardo" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MilestoneLevel)),
                    "Scegli il traguardo per il prossimo caricamento.\n" +
                    "Regolabile <solo fuori da una città caricata> e con [Selettore traguardo] attivo [ ✓ ].\n" +
                    "Se la città è già a quel traguardo o oltre, non succede nulla.\n" +
                    "Cambia solo se il traguardo scelto è più alto." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ManualMoneyAmount)), "Importo scorciatoia soldi" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ManualMoneyAmount)),
                    "Usa questo importo con le scorciatoie Aggiungi e Sottrai soldi.\n" +
                    "<Default mod = 40.000>\n" +
                    "Non fa nulla senza usare la scorciatoia in città.\n" +
                    "Per automatizzare, attiva Soldi automatici." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AddMoneyKeyboardBinding)), "Aggiungi soldi" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AddMoneyKeyboardBinding)), "Scorciatoia per <Aggiungi soldi> in città." },
                { m_Settings.GetBindingKeyLocaleID(Setting.AddMoneyAction), "Aggiungi soldi" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.SubtractMoneyKeyboardBinding)), "Sottrai soldi" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.SubtractMoneyKeyboardBinding)), "Scorciatoia per <Sottrai soldi> in città." },
                { m_Settings.GetBindingKeyLocaleID(Setting.SubtractMoneyAction), "Sottrai soldi" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoney)), "Soldi automatici" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoney)),
                    "Se attivo [ ✓ ], City Watchdog controlla il saldo città.\n" +
                    "- Se il saldo è <sotto la soglia>,\n" +
                    "  aggiunge l’importo scelto.\n" +
                    "- Meglio usare soldi manuali con hotkey (<[> o <]>) quando serve\n" +
                    "  invece dell’automatico; l’opzione c’è comunque." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoneyThreshold)), "Soglia soldi automatici" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoneyThreshold)),
                    "Se attivo e il saldo scende sotto questo valore,\n" +
                    "aggiunge l’importo scelto." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoneyAmount)), "Importo automatico" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoneyAmount)),
                    "Importo aggiunto a ogni attivazione automatica.\n" +
                    "Scegli abbastanza per superare la soglia." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ConfirmUnlimitedMoneySaveConversion)), "Convertitore soldi illimitati" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ConfirmUnlimitedMoneySaveConversion)),
                    "<Fai PRIMA un backup della città>.\n" +
                    "Converte una città avviata con Soldi illimitati in città normale.\n" +
                    "Attivandolo sblocchi <[Converti salvataggio Soldi illimitati]> se la città caricata è <Soldi illimitati>.\n" +
                    "City Watchdog non può annullare la conversione.\n" +
                    "Se hai città normali, non serve." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)), "Converti città Soldi illimitati in normale" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)),
                    "Per città iniziate con <Soldi illimitati>.\n" +
                    "Con la città caricata, converte il salvataggio a budget normale limitato.\n" +
                    "Il pulsante è <disabilitato/grigio> salvo se la città è <Soldi illimitati>\n" +
                    "e <Convertitore soldi illimitati> è ON [ ✓ ].\n" +
                    "Fai un backup; a tuo rischio. City Watchdog non annulla." },
                { m_Settings.GetOptionWarningLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)),
                    "Convertire questa città da Soldi illimitati a soldi limitati normali?\n" +
                    "Salva PRIMA un backup; City Watchdog non può annullare.\n" +
                    "Sei sicuro?" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.NameText)), "Nome mod" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.NameText)), "Nome visualizzato del mod." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.VersionText)), "Versione" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.VersionText)), "Versione attuale del mod." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.OpenParadox)), "Paradox Mods" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.OpenParadox)), "Apre la pagina Paradox Mods dell’autore." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.WriteNotificationAuditLog)), "Report debug nel log" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.WriteNotificationAuditLog)),
                    "<Non serve per giocare normalmente.>\n" +
                    "Per test e patch: scrive un report in <Logs/CityWatchdog.log>\n" +
                    "confrontando avvisi live del gioco e icone gestite da Watchdog." },
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
