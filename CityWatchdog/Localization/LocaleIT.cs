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
                { m_Settings.GetSettingsLocaleID(), title },
                { m_Settings.GetOptionTabLocaleID(Setting.Actions), "Azioni" },
                { m_Settings.GetOptionTabLocaleID(Setting.MiniHudTab), "Mini-HUD" },
                { m_Settings.GetOptionTabLocaleID(Setting.MoneyTab), "Denaro-Traguardi" },
                { m_Settings.GetOptionTabLocaleID(Setting.About), "Info" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutUsage), "USO" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Notifications), "Notifiche" },
                { m_Settings.GetOptionGroupLocaleID(Setting.MoneyViewGroup), "Info in città" },
                { m_Settings.GetOptionGroupLocaleID(Setting.MiniHudGroup), "Notifiche Mini HUD" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Milestone), "AVVIO NUOVA CITTÀ" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Money), "Denaro" },
                { m_Settings.GetOptionGroupLocaleID(Setting.SaveConversion), "Converti salvataggio illimitato" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutInfo), "" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutLinks), "" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutDiagnostics), "DIAGNOSTICA" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ShowUsage)), "Mostra istruzioni" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ShowUsage)), "Mostra o nasconde le istruzioni qui sotto." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.UsageText)), "<Comandi visuali>\n" +
                    "1. Pulsante [i]: nasconde/mostra TUTTI i suggerimenti del gioco: edifici, cittadini, strumenti, icone del menu in basso.\n" +
                    "2. Pulsante nomi strade: nasconde/mostra i nomi. Tasto: \\.\n" +
                    "3. Pulsante nomi distretti: nasconde/mostra i nomi senza cambiare i confini.\n" +
                    "4. Pulsante frecce strada: forza on/off le frecce senso unico (nasconde anche i nomi strade).\n" +
                    "5. Icona CWD nella barra titolo: mostra/nasconde i suggerimenti del pannello City Watchdog.\n" +
                    "\n" +
                    "<Avvisi>\n" +
                    "1. Clicca il pulsante City Watchdog in alto a sinistra, o premi Shift+N, per aprire il pannello.\n" +
                    "2. Pulsante ordine: crescente/decrescente.\n" +
                    "3. Alterna tutto per spegnere/accendere rapidamente, o apri una sezione per scegliere.\n" +
                    "4. Mostra o nasconde solo icone; non risolve il problema della città.\n" +
                    "\n" +
                    "<Aiuti denaro>\n" +
                    "1. Aggiungi o sottrai denaro: usa <Importo tasto denaro>, tasti predefiniti [ e ].\n" +
                    "2. Denaro automatico aggiunge fondi quando la città scende sotto il limite scelto.\n" +
                    "3. Converti salvataggio Denaro illimitato vale solo per città avviate così ed è <irreversibile>.\n" +
                    "\n" +
                    "<Suggerimenti menu basso>\n" +
                    "La vista denaro aggiunge tendenze denaro/popolazione e dettagli al passaggio del mouse.\n" +
                    "\n" +
                    "<Traguardo personalizzato>\n" +
                    "Imposta denaro iniziale e traguardo in Denaro-Traguardi > AVVIO NUOVA CITTÀ prima di caricare o iniziare una città." },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.UsageText)), "" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleNotificationsKeyboardBinding)), "Alterna icone avviso" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleNotificationsKeyboardBinding)), "<Tasto> per la stessa azione del pulsante <[Alterna tutto]> in gioco.\n" +
                    "Mostra o nasconde subito tutte le icone di avviso elencate." },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleNotificationsAction), "Mostra/nascondi tutte le icone avviso" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleNotificationPanelKeyboardBinding)), "Apri/chiudi pannello avvisi" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleNotificationPanelKeyboardBinding)), "<Tasto> per aprire o chiudere il\n" +
                    "<pannello avvisi> in città.\n" +
                    "Funziona come cliccare l'icona in alto a sinistra." },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleNotificationPanelAction), "Apri/chiudi pannello avvisi" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.PanelButtonsOnlyStart)), "Avvio pannello solo pulsanti" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.PanelButtonsOnlyStart)), "Se attivo [ ✓ ], City Watchdog si apre dal pulsante in alto a sinistra nella piccola vista solo pulsanti.\n" +
                    "Usa la freccia titolo o il pulsante conteggio per aprire il pannello completo." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleRoadNamesKeyboardBinding)), "Nascondi/mostra nomi strade" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleRoadNamesKeyboardBinding)), "<Tasto> per nascondere o mostrare subito i nomi strade del gioco base.\n" +
                    "Come l'icona nomi strade nella barra di City Watchdog." },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleRoadNamesAction), "Nascondi/mostra nomi strade" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleAllTooltipsKeyboardBinding)), "Disattiva tutti i suggerimenti mouse" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleAllTooltipsKeyboardBinding)), "<Tasto> per nascondere o mostrare subito TUTTI i suggerimenti del gioco — edifici, cittadini, strumenti e icone del menu in basso.\n" +
                    "<I popup denaro/popolazione di City Watchdog restano attivi>; sono controllati dalla Vista denaro.\n" +
                    "Come l'icona [i] nel pannello City Watchdog." },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleAllTooltipsAction), "Nascondi/mostra tutti i suggerimenti del gioco" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyView)), "Mostra suggerimenti denaro + popolazione" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyView)), "<Consigliato>\n" +
                    "Menu in basso: mostra i trend con le <frecce denaro e popolazione> della barra.\n" +
                    "Funzione leggera al passaggio del mouse <solo visuale>;\n" +
                    "risparmia tempo e può essere più leggera del pannello Info del gioco." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyViewMode)), "Frequenza vista denaro" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyViewMode)), "Scegli se il testo trend in basso mostra valori orari o mensili per denaro e popolazione.\n" +
                    "Mensile usa entrate meno spese del budget e una proiezione popolazione di 24 ore." },
                { m_Settings.GetOptionLocaleID("MoneyViewModeHourly"), "Orario (/h)" },
                { m_Settings.GetOptionLocaleID("MoneyViewModeMonthly"), "Mensile (/mese)" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyTooltipMode)), "Stile suggerimento denaro" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyTooltipMode)), "Scegli quanti dettagli mostra il suggerimento denaro.\n" +
                    "Compatto = predefinito alla prima installazione.\n" +
                    "<Mini> mostra solo 2 valori netti per /mese e /h.\n" +
                    "<Compatto> accorcia valori grandi (15.21M invece di 15,212,318).\n" +
                    "<Dati completi> mostra valori lunghi e totali." },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeMini"), "Mini" },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeCompact"), "Compatto" },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeFullData"), "Dati completi" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyTooltipFontScale)), "Dimensione font denaro" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyTooltipFontScale)), "Regola la <dimensione del font> dei numeri nel suggerimento denaro.\n" +
                    "Predefinito gioco = 100%\n" +
                    "<Predefinito mod = 120%>\n" +
                    "Passa il mouse su Denaro in basso.\n" +
                    "Per chi fatica a leggere suggerimenti piccoli." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.PopulationTooltipFontScale)), "Dimensione font popolazione" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.PopulationTooltipFontScale)), "Regola la <dimensione del font> dei numeri popolazione.\n" +
                    "Predefinito gioco = 100%\n" +
                    "<Predefinito mod = 120%>\n" +
                    "Passa il mouse su Popolazione in basso." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudEnabled)), "Mini HUD" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudEnabled)), "Mostra un piccolo HUD città con i conteggi avviso più importanti.\n" +
                    "Usalo come barra rapida senza aprire tutto il pannello City Watchdog.\n" +
                    "Clic su un'icona salta a un problema corrispondente.\n" +
                    "Clic ripetuti ruotano tra i punti e tornano al primo." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ApplyMiniHudRecommendedPreset)), "Imposta avvio rapido" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ApplyMiniHudRecommendedPreset)), "Applica una configurazione Mini HUD consigliata:\n" +
                    "Preferiti, 5 icone, orizzontale, alto centro, 100%, pannello scuro.\n" +
                    "Gli avvisi a zero restano visibili.\n" +
                    "Aggiungi/rimuovi preferiti **Stella blu** quando vuoi nel pannello Watchdog espanso.\n" +
                    "Il set iniziale di preferiti **Stella blu** è incluso con **[Consigliato]**." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudMode)), "Modalità Mini HUD" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudMode)), "Scegli quali righe avviso usa il Mini HUD.\n" +
                    "**Attivi principali** mostra i conteggi attuali più alti.\n" +
                    "**Preferiti** include le righe segnate con **Stella blu** nel pannello principale.\n" +
                    "Puoi scegliere quanti preferiti vuoi,\n" +
                    "ma il Mini HUD mostra solo i 5 o 10 conteggi più alti della lista **preferiti stella blu**." },
                { m_Settings.GetOptionLocaleID("MiniHudModeTopActive"), "Avvisi attivi principali" },
                { m_Settings.GetOptionLocaleID("MiniHudModeFavorites"), "Preferiti" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudItemCount)), "Numero icone" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudItemCount)), "Scegli quante icone avviso può mostrare il Mini HUD alla volta." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudScale)), "Dimensione icone" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudScale)), "Scala icone e numeri del Mini HUD.\n" +
                    "90% = compatto. 100% = standard. Fino a 130% per vedere meglio." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudOrientation)), "Orientamento" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudOrientation)), "Scegli se le icone del Mini HUD sono in riga o colonna." },
                { m_Settings.GetOptionLocaleID("MiniHudOrientationHorizontal"), "Orizzontale" },
                { m_Settings.GetOptionLocaleID("MiniHudOrientationVertical"), "Verticale" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudPlacement)), "Posizione HUD" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudPlacement)), "Scegli dove appare il Mini HUD.\n" +
                    "Trascinabile permette di spostarlo nell'interfaccia città." },
                { m_Settings.GetOptionLocaleID("MiniHudPlacementTopCenter"), "Alto centro" },
                { m_Settings.GetOptionLocaleID("MiniHudPlacementTopRight"), "Alto destra" },
                { m_Settings.GetOptionLocaleID("MiniHudPlacementDraggable"), "Trascinabile" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudPanelStyle)), "Stile scuro o vetro" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudPanelStyle)), "Scegli lo sfondo del Mini HUD.\n" +
                    "Il pannello vetro va da chiaro a bianco nuvoloso; non diventa più scuro.\n" +
                    "Usa pannello scuro per uno HUD più scuro in stile gioco." },
                { m_Settings.GetOptionLocaleID("MiniHudPanelStyleDark"), "Pannello scuro" },
                { m_Settings.GetOptionLocaleID("MiniHudPanelStyleGlass"), "Pannello vetro" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudPanelOpacity)), "Opacità sfondo" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudPanelOpacity)), "Regola la trasparenza dello sfondo Mini HUD.\n" +
                    "Più basso = più trasparente. Più alto = più solido.\n" +
                    "Vetro diventa più bianco/nuvoloso. Scuro diventa più solido/scuro." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudHideZero)), "Nascondi avvisi zero" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudHideZero)), "Se attivo [ ✓ ], il Mini HUD nasconde le righe con conteggio 0." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.InitialMoney)), "Denaro iniziale" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.InitialMoney)), "Imposta il saldo iniziale per una nuova città con <denaro limitato> o la prima città caricata,\n" +
                    "poi torna al predefinito del gioco dopo l'applicazione.\n" +
                    "È grigio se una città è già caricata.\n" +
                    "Imposta prima di avviare/caricare. Si applica una volta, poi usa <Importo tasto denaro> o <Denaro automatico>." },
                { m_Settings.GetOptionLocaleID("GameDefault"), "Predefinito gioco" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.CustomMilestone)), "Selettore traguardo" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.CustomMilestone)), "Attiva <prima di caricare o iniziare una città> per sbloccare il traguardo scelto subito dopo il caricamento.\n" +
                    "- Non può essere attivato dopo il caricamento, ma può essere disattivato se lasciato acceso per errore.\n" +
                    "- Se hai dimenticato e caricato una città, riavvia il gioco e scegli il traguardo prima di entrare.\n" +
                    "- Il mod non può annullare traguardi già salvati; usa un salvataggio precedente se serve." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MilestoneLevel)), "Traguardo" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MilestoneLevel)), "Scegli un livello traguardo da sbloccare al prossimo caricamento città.\n" +
                    "Regolabile <solo fuori da una città caricata> e solo dopo aver attivato [Selettore traguardo] [ ✓ ].\n" +
                    "Se la città è già a quel livello o oltre, non succede nulla.\n" +
                    "Cambia solo se il traguardo scelto è più alto." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ManualMoneyAmount)), "Importo tasto denaro" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ManualMoneyAmount)), "Usa questo importo con i tasti Aggiungi denaro e Sottrai denaro.\n" +
                    "<Predefinito mod = 40.000>\n" +
                    "Non fa nulla se non usi il tasto in città.\n" +
                    "Per automazione, attiva Denaro automatico." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AddMoneyKeyboardBinding)), "Aggiungi denaro" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AddMoneyKeyboardBinding)), "Tasto per <Aggiungi denaro> in città." },
                { m_Settings.GetBindingKeyLocaleID(Setting.AddMoneyAction), "Aggiungi denaro" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.SubtractMoneyKeyboardBinding)), "Sottrai denaro" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.SubtractMoneyKeyboardBinding)), "Tasto per <Sottrai denaro> in città." },
                { m_Settings.GetBindingKeyLocaleID(Setting.SubtractMoneyAction), "Sottrai denaro" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoney)), "Denaro automatico" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoney)), "Se attivo [ ✓ ], City Watchdog controlla il saldo mentre una città è caricata.\n" +
                    "- Se il saldo è <sotto la soglia>,\n" +
                    "  aggiunge l'importo automatico scelto.\n" +
                    "- Meglio usare denaro manuale con tasto (<[> o <]>) quando serve\n" +
                    "  invece dell'automazione, ma l'opzione è disponibile." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoneyThreshold)), "Soglia denaro automatico" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoneyThreshold)), "Se Denaro automatico è attivo e il saldo città scende sotto questo valore,\n" +
                    "viene aggiunto l'importo scelto." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoneyAmount)), "Importo automatico" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoneyAmount)), "Importo aggiunto a ogni attivazione automatica.\n" +
                    "Scegli un valore sufficiente a superare la soglia." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ConfirmUnlimitedMoneySaveConversion)), "Convertitore denaro illimitato" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ConfirmUnlimitedMoneySaveConversion)), "<Fai PRIMA un backup della città>.\n" +
                    "Converte una città avviata con Denaro illimitato in una città normale con sfide di denaro.\n" +
                    "Attivandolo sblocca il pulsante <[Converti salvataggio denaro illimitato]> quando la città caricata è di tipo <Denaro illimitato>.\n" +
                    "City Watchdog non può annullare la conversione.\n" +
                    "Per città normali non serve." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)), "Converti città denaro illimitato in normale" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)), "Per città avviate con <Denaro illimitato>.\n" +
                    "Mentre quella città è caricata, converte il salvataggio al normale budget con denaro limitato.\n" +
                    "Il pulsante è <disattivato/grigio> salvo se la città caricata è di tipo <Denaro illimitato>\n" +
                    "e <Convertitore denaro illimitato> è ON [ ✓ ].\n" +
                    "Fai un backup e usa a tuo rischio; City Watchdog non può annullare." },
                { m_Settings.GetOptionWarningLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)), "Convertire questa città da Denaro illimitato a denaro limitato normale?\n" +
                    "Salva PRIMA un backup; City Watchdog non può annullare.\n" +
                    "Sei sicuro?" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.NameText)), "Nome mod" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.NameText)), "Nome visualizzato di questo mod." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.VersionText)), "Versione" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.VersionText)), "Versione attuale del mod." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.OpenParadox)), "Paradox Mods" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.OpenParadox)), "Apre la pagina Paradox Mods dell'autore." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.WriteNotificationAuditLog)), "Report debug nel log" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.WriteNotificationAuditLog)), "<Non serve per giocare normalmente.>\n" +
                    "Per tester e controlli dopo patch: scrive un report in <Logs/CityWatchdog.log>\n" +
                    "confrontando le notifiche reali del gioco con le icone controllate da Watchdog." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.OpenLog)), "Apri log" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.OpenLog)), "Apre </Logs/CityWatchdog.log> se esiste.\n" +
                    "Se manca il file, apre invece la cartella Logs/." },
            };

            return entries;
        }

        public void Unload()
        {
        }
    }
}
