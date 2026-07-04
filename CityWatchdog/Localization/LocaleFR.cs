// <copyright file="LocaleFR.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the MIT License. You may not use this file except in compliance with this License.
// See LICENSE file in the project root for full license information.
// This notice and the MIT License notice must be kept with
// all copies or substantial portions of this code.
// ================= </copyright> ======================

// File: src/Localization/LocaleFR.cs
// Purpose: French (fr-FR) for City Watchdog Options UI menu.

namespace CityWatchdog
{
    using System.Collections.Generic; // Dictionary and KeyValuePair
    using Colossal;                   // IDictionarySource
    using Game.UI.Editor;

    public sealed class LocaleFR : IDictionarySource
    {
        private readonly Setting m_Settings;

        public LocaleFR(Setting setting)
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
                { m_Settings.GetOptionTabLocaleID(Setting.Actions), "Actions" },
                { m_Settings.GetOptionTabLocaleID(Setting.MiniHudTab), "Mini-HUD" },
                { m_Settings.GetOptionTabLocaleID(Setting.MoneyTab), "Argent et jalons" },
                { m_Settings.GetOptionTabLocaleID(Setting.About), "À propos" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutUsage), "UTILISATION" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Notifications), "Notifications" },
                { m_Settings.GetOptionGroupLocaleID(Setting.MoneyViewGroup), "Infos en ville" },
                { m_Settings.GetOptionGroupLocaleID(Setting.MiniHudGroup), "Notifications Mini HUD" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Milestone), "RÉGLAGES DE DÉPART DE NOUVELLE VILLE" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Money), "Argent" },
                { m_Settings.GetOptionGroupLocaleID(Setting.SaveConversion), "Convertir sauvegarde illimitée" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutInfo), "" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutLinks), "" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutDiagnostics), "DIAGNOSTICS" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ShowUsage)), "Afficher les instructions" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ShowUsage)), "Afficher ou masquer les instructions ci-dessous." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.UsageText)), "<Affichage>\n1. Bouton [i] : masque/affiche TOUS les tooltips du jeu.\n2. Bouton Noms de routes : masque/affiche les noms de routes. Raccourci : \\.\n3. Bouton Noms de districts : masque/affiche les noms sans changer les limites.\n4. Bouton Flèches de routes : force les flèches de sens unique et masque aussi les noms de routes.\n5. Icône de titre CWD : masque/affiche les tooltips du panneau.\n\n<Alertes>\n1. Cliquez sur le bouton City Watchdog en haut à gauche, ou appuyez sur Shift+N.\n2. Le bouton de tri change l’ordre croissant/décroissant.\n3. Toggle All coupe/réactive tout, ou ouvrez une section pour régler une icône précise.\n4. Le mod masque les icônes seulement; il ne corrige pas le problème de ville.\n\n<Aides argent>\n1. Ajouter ou retirer de l’argent : utilisez les touches [ et ].\n2. L’ajout automatique ajoute de l’argent sous la limite choisie.\n3. Convertir une sauvegarde Argent illimité est irréversible.\n\n<Tooltips du menu du bas>\nMoney View ajoute des tendances argent/population et des détails au survol.\n\n<Jalon personnalisé>\nRéglez Argent initial et les jalons avant de charger ou démarrer une ville." },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.UsageText)), "" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleNotificationsKeyboardBinding)), "Afficher/masquer les icônes de notification" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleNotificationsKeyboardBinding)), "<Raccourci> pour la même action que the en jeu <[TOGGLE ALL]> bouton icône.\nAffiche ou masque instantanément toutes les icônes de notification listées." },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleNotificationsAction), "Afficher/Masquer toutes les icônes de notification" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleNotificationPanelKeyboardBinding)), "Ouvrir/fermer le panneau de notifications" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleNotificationPanelKeyboardBinding)), "<Raccourci> for ouvrir ou fermer the\n<panneau de notifications> en ville.\nMême effet que cliquer sur l’icône en haut à gauche to open the panneau complet." },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleNotificationPanelAction), "Ouvrir/Fermer le panneau de notifications" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.PanelButtonsOnlyStart)), "Démarrage en mode boutons" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.PanelButtonsOnlyStart)), "Si activé [ ✓ ], opening City Watchdog from the bouton en haut à gauche starts in the smaller vue boutons seulement.\nUse the flèche de la barre de titre or the bouton du nombre de lignes to expand the panneau complet." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleRoadNamesKeyboardBinding)), "Masquer/Afficher les noms de routes" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleRoadNamesKeyboardBinding)), "<Raccourci> to instantly hide or show the noms de routes du jeu en ville.\nSame as clicking the icône Nom de route in the City Watchdog barre d’outils du panneau." },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleRoadNamesAction), "Masquer/Afficher les noms de routes" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleAllTooltipsKeyboardBinding)), "Désactiver toutes les infobulles au survol" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleAllTooltipsKeyboardBinding)), "<Raccourci> to instantly hide or show TOUTES les infobulles du jeu — bâtiments, citoyens, outils et icônes du menu inférieur.\n<City Watchdog's own fenêtres argent/population restent actives>; those are contrôlées par the l’option Argent View ci-dessus.\nSame as clicking the [i] icon on the City Watchdog panel inside the city." },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleAllTooltipsAction), "Masquer/Afficher toutes les infobulles du jeu" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyView)), "Afficher les ToolTips argent + population" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyView)), "<Activation recommandée>\nMenu inférieur du jeu: Shows valeurs de tendance with the game's bottom toolbar <argent et population arrows>.\nThis is a léger hover over toolbar feature <affichage seulement>;\nSaves time and possible better performance than opening game's Info view panel." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyViewMode)), "Fréquence Money View" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyViewMode)), "Choisir whether the bottom-toolbar trend text shows horaires ou mensuelles values for argent et population.\nMonthly uses budget income minus expenses for money, and a 24-hour projection for population." },
                { m_Settings.GetOptionLocaleID("MoneyViewModeHourly"), "Horaire (/h)" },
                { m_Settings.GetOptionLocaleID("MoneyViewModeMonthly"), "Mensuel (/mo)" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyTooltipMode)), "Style d’infobulle d’argent" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyTooltipMode)), "Choisir how much detail appears in the money hover tooltip.\nCompact = default on first install.\n<Mini> shows only 2 Net values for /mo and /h.\n<Compact> shortens large values (15.21M instead of 15,212,318).\n<Données complètes> shows long values and Total fields." },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeMini"), "Mini" },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeCompact"), "Compact" },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeFullData"), "Données complètes" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyTooltipFontScale)), "Taille police argent" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyTooltipFontScale)), "Adjusts <taille de police> of Argent View tooltip numbers.\nPar défaut du jeu = 100%\n<Par défaut du mod = 120%>\nSurvoler Argent at bottom of the screen.\nRequested by players who have hard time seeing smaller tooltips in the game." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.PopulationTooltipFontScale)), "Taille police population" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.PopulationTooltipFontScale)), "Adjusts <taille de police> of population tooltip numbers.\nPar défaut du jeu = 100%\n<Par défaut du mod = 120%>\nSurvoler Population at bottom of the screen." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudEnabled)), "Mini HUD" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudEnabled)), "Affiche un petit HUD en ville with the most compteurs de notification importants.\nUse it as a barre d’alerte rapide without opening the full City Watchdog panel.\nCliquer une icône va à one emplacement de problème correspondant.\nContinuer à cliquer the same icon to parcourir les emplacements correspondants, then back to the first one." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ApplyMiniHudRecommendedPreset)), "Préréglage conseillé" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ApplyMiniHudRecommendedPreset)), "Applies a recommended Mini HUD setup:\nFavorites, 5 icons, horizontal, top center, 100% size, dark panel.\nZero-count alerts stay visible.\nAdd/remove **Blue Star** favorites anytime in the expanded Watchdog panel.\nStarter set Blue-Star favorites are included with **[Recommended]**." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudMode)), "Mode Mini HUD" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudMode)), "Choisir quelles lignes de notification the Mini HUD uses.\n**Top active** alerts shows the plus grands compteurs actuels.\n**Favoris** includes all rows marquées avec **Étoile bleue** in the panneau principal City Watchdog.\nYou can pick as many favorites as you want,\nbut Mini HUD still shows only the top 5 or top 10 current counts from that **favorites blue-star** list." },
                { m_Settings.GetOptionLocaleID("MiniHudModeTopActive"), "Alertes les plus actives" },
                { m_Settings.GetOptionLocaleID("MiniHudModeFavorites"), "Favoris" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudItemCount)), "Nombre d’icônes Mini HUD" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudItemCount)), "Choisir how many notification icons the Mini HUD can show at once." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudScale)), "Mini HUD size" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudScale)), "Scale Mini HUD icons and numbers.\n90% = compact. 100% = default. Increase up to 130% for better visibility." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudOrientation)), "Orientation Mini HUD" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudOrientation)), "Choisir whether Mini HUD icons are arranged in a row or a column." },
                { m_Settings.GetOptionLocaleID("MiniHudOrientationHorizontal"), "Horizontal" },
                { m_Settings.GetOptionLocaleID("MiniHudOrientationVertical"), "Vertical" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudPlacement)), "Position Mini HUD" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudPlacement)), "Choisir where the Mini HUD appears.\nDéplaçable lets you move it en ville UI." },
                { m_Settings.GetOptionLocaleID("MiniHudPlacementTopCenter"), "En haut au centre" },
                { m_Settings.GetOptionLocaleID("MiniHudPlacementTopRight"), "En haut à droite" },
                { m_Settings.GetOptionLocaleID("MiniHudPlacementDraggable"), "Déplaçable" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudHideZero)), "Masquer les alertes à zéro" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudHideZero)), "Si activé [ ✓ ], the Mini HUD hides notification rows with a count of 0." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudGlassStyle)), "Style verre" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudGlassStyle)), "Adds a soft glass-style background behind the Mini HUD for readability." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.InitialMoney)), "Argent initial" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.InitialMoney)), "Sets the starting balance for a nouvelle <argent limité> city or the première ville chargée,\nthen revient à la valeur du jeu after it applies.\nThis is grisé if a ville déjà chargée.\nSet this avant de démarrer/charger a city. It applies once, then use <Montant du raccourci argent> or <Ajout automatique d’argent> afterward." },
                { m_Settings.GetOptionLocaleID("GameDefault"), "Valeur du jeu" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.CustomMilestone)), "Sélecteur de jalon" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.CustomMilestone)), "Activer <avant de charger ou démarrer une ville> to débloquer un jalon choisi juste après le chargement.\n- Ne peut pas être activé after a city is loaded, but it peut être désactivé if it was left enabled by mistake.\n- If you oublié and loaded a city, just redémarrer le jeu, and pick milestone before entering a city.\n- Mod ne peut pas annuler milestone changes already saved into a city; use an sauvegarde précédente if needed." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MilestoneLevel)), "Jalon" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MilestoneLevel)), "Choisir a milestone level to unlock on the prochain chargement de ville.\nThis is <only adjustable outside a loaded city>, and only after [Sélecteur de jalon] is enabled [ ✓ ].\nIf the city is already at or past the milestone selected, then nothing will happen.\nA change only happens if the milestone selected here is higher than what the city has." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ManualMoneyAmount)), "Montant du raccourci argent" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ManualMoneyAmount)), "Utilisez ce montant with the Ajouter de l’argent and Retirer de l’argent raccourcis.\n<Par défaut du mod = 40,000>\nThis ne fait rien sauf si you use the hotkey to add/subtract money (en ville).\nFor automated money, enable the Ajout automatique d’argent option." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AddMoneyKeyboardBinding)), "Ajouter de l’argent" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AddMoneyKeyboardBinding)), "Raccourci to <Ajouter de l’argent> inside the city." },
                { m_Settings.GetBindingKeyLocaleID(Setting.AddMoneyAction), "Ajouter de l’argent" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.SubtractMoneyKeyboardBinding)), "Retirer de l’argent" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.SubtractMoneyKeyboardBinding)), "Raccourci to <Retirer de l’argent> inside the city." },
                { m_Settings.GetBindingKeyLocaleID(Setting.SubtractMoneyAction), "Retirer de l’argent" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoney)), "Ajout automatique d’argent" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoney)), "Si activé [ ✓ ], City Watchdog checks the solde de la ville while a city is loaded.\n- If the balance is <sous le seuil>, \n  it ajoute le montant automatique choisi.\n- Recommend to use Manual money with hotkey (<[> or <]>) as needed  instead of this automated option, but this is here if you want it." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoneyThreshold)), "Seuil d’argent automatique" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoneyThreshold)), "If Ajout automatique d’argent is enabled and the solde de la ville falls below this value,\nAdd the selected automatic amount." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoneyAmount)), "Montant automatique" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoneyAmount)), "Amount added each time Ajout automatique d’argent triggers.\nChoisir a value high enough to bring the city safely above the threshold." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ConfirmUnlimitedMoneySaveConversion)), "Convertisseur Argent illimité" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ConfirmUnlimitedMoneySaveConversion)), "<Faites d’abord une sauvegarde de la ville>.\nConvertit une ville that started as Argent illimité to a ville normale with défis d’argent normaux.\nEnabling this unlocks the <[Convert Argent illimité Save]> button when the loaded city is <Argent illimité> type.\nCity Watchdog ne peut pas annuler cette conversion.\nIf you have normal cities, do not worry about this; it is not needed." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)), "Convertir la ville Argent illimité en ville normale" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)), "For cities started with <Argent illimité>.\nWhile that city is loaded, this converts the save to normal limited-money budgeting so the city has défis d’argent normaux again.\nButton is <disabled/greyed-out> unless the loaded city is an <Argent illimité> type\nand <Convertisseur Argent illimité> is ON [ ✓ ].\nMake a backup save, and use at your own risk; City Watchdog ne peut pas annuler cette conversion." },
                { m_Settings.GetOptionWarningLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)), "Convert this city from Argent illimité to normal argent limité?\nSave a backup FIRST; City Watchdog ne peut pas annuler this.\nAre you sure?" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.NameText)), "Nom du mod" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.NameText)), "Display name of this mod." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.VersionText)), "Version" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.VersionText)), "Current mod version." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.OpenParadox)), "Paradox Mods" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.OpenParadox)), "Open the author's Paradox Mods page." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.WriteNotificationAuditLog)), "Rapport debug vers le journal" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.WriteNotificationAuditLog)), "<Not needed for normal gameplay.>\nFor testers and post game-patch checks: écrit un <Logs/CityWatchdog.log> rapport\ncomparing live game notification prefabs with the notification icons Watchdog currently controls." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.OpenLog)), "Ouvrir le journal" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.OpenLog)), "Ouvre </Logs/CityWatchdog.log> s’il existe.\nSi le fichier log manque, ouvre le dossier Logs/ à la place." },
            };

            return entries;
        }

        public void Unload()
        {
        }
    }
}
