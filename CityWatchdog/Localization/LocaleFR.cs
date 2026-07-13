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
                { m_Settings.GetOptionTabLocaleID(Setting.MoneyTab), "Argent-Jalons" },
                { m_Settings.GetOptionTabLocaleID(Setting.About), "À propos" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutUsage), "UTILISATION" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Notifications), "Notifications" },
                { m_Settings.GetOptionGroupLocaleID(Setting.MoneyViewGroup), "Infos en ville" },
                { m_Settings.GetOptionGroupLocaleID(Setting.MiniHudGroup), "Notifications du Mini HUD" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Milestone), "DÉMARRAGE NOUVELLE VILLE" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Money), "Argent" },
                { m_Settings.GetOptionGroupLocaleID(Setting.SaveConversion), "Convertir sauvegarde illimitée" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutInfo), "" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutLinks), "" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutDiagnostics), "DIAGNOSTIC" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ShowUsage)), "Afficher les instructions" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ShowUsage)), "Affiche ou masque les instructions ci-dessous." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.UsageText)), "<Affichage>\n" +
                    "1. Bouton [i] : masquer/afficher TOUTES les infobulles du jeu — bâtiments, cims, outils, icônes du menu du bas.\n" +
                    "2. Bouton noms de routes : masquer/afficher les noms. Raccourci : \\.\n" +
                    "3. Bouton districts : masquer/afficher les noms sans changer les limites.\n" +
                    "4. Bouton flèches : forcer les flèches de sens unique on/off (masque aussi les noms de routes).\n" +
                    "5. Icône CWD de la barre de titre : afficher/masquer les infobulles du panneau City Watchdog.\n" +
                    "\n" +
                    "<Alertes>\n" +
                    "1. Clique sur le bouton City Watchdog en haut à gauche, ou appuie sur Shift+N, pour ouvrir le panneau.\n" +
                    "2. Bouton de tri : ordre croissant/décroissant.\n" +
                    "3. Tout basculer pour tout couper/réactiver vite, ou ouvrir une section pour choisir.\n" +
                    "4. Affiche ou masque seulement les icônes ; ne corrige pas le problème de la ville.\n" +
                    "\n" +
                    "<Aides argent>\n" +
                    "1. Ajouter ou retirer de l'argent : utilise <Montant du raccourci argent>, touches par défaut [ et ].\n" +
                    "2. L'ajout automatique ajoute de l'argent quand la ville passe sous la limite choisie.\n" +
                    "3. Convertir une sauvegarde Argent illimité ne sert que pour ces villes et reste <irréversible>.\n" +
                    "\n" +
                    "<Infobulles du menu du bas>\n" +
                    "La vue argent ajoute des tendances argent/population et plus de détails au survol.\n" +
                    "\n" +
                    "<Jalon personnalisé>\n" +
                    "Définis l'argent initial et le jalon dans Argent-Jalons > DÉMARRAGE NOUVELLE VILLE avant de charger ou créer une ville." },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.UsageText)), "" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleNotificationsKeyboardBinding)), "Basculer les icônes d'alerte" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleNotificationsKeyboardBinding)), "<Raccourci> pour la même action que le bouton <[Tout basculer]> en jeu.\n" +
                    "Affiche ou masque instantanément toutes les icônes d'alerte listées." },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleNotificationsAction), "Afficher/masquer toutes les icônes d'alerte" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleNotificationPanelKeyboardBinding)), "Ouvrir/fermer le panneau d'alertes" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleNotificationPanelKeyboardBinding)), "<Raccourci> pour ouvrir ou fermer le\n" +
                    "<panneau d'alertes> en ville.\n" +
                    "Fonctionne comme un clic sur l'icône en haut à gauche." },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleNotificationPanelAction), "Ouvrir/fermer le panneau d'alertes" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.PanelButtonsOnlyStart)), "Démarrer en mode boutons" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.PanelButtonsOnlyStart)), "Si activé [ ✓ ], City Watchdog s'ouvre depuis le bouton en haut à gauche dans la petite vue boutons.\n" +
                    "Utilise la flèche de titre ou le bouton compteur pour ouvrir le panneau complet." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleRoadNamesKeyboardBinding)), "Masquer/afficher noms de routes" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleRoadNamesKeyboardBinding)), "<Raccourci> pour masquer ou afficher instantanément les noms de routes du jeu de base.\n" +
                    "Comme l'icône Noms de routes dans City Watchdog." },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleRoadNamesAction), "Masquer/afficher noms de routes" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleAllTooltipsKeyboardBinding)), "Désactiver toutes les infobulles" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleAllTooltipsKeyboardBinding)), "<Raccourci> pour masquer ou afficher instantanément TOUTES les infobulles du jeu — bâtiments, cims, outils et icônes du menu du bas.\n" +
                    "<Les popups argent/population de City Watchdog restent actifs> ; ils sont contrôlés par la vue argent.\n" +
                    "Comme l'icône [i] du panneau City Watchdog." },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleAllTooltipsAction), "Masquer/afficher toutes les infobulles du jeu" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyView)), "Afficher infobulles argent + population" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyView)), "<Activation recommandée>\n" +
                    "Menu du bas : affiche les tendances avec les <flèches argent et population> de la barre.\n" +
                    "Fonction légère au survol, <affichage seulement> ;\n" +
                    "gagne du temps et peut être plus fluide que le panneau Infos du jeu." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyViewMode)), "Fréquence de la vue argent" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyViewMode)), "Choisis si le texte de tendance du bas affiche des valeurs horaires ou mensuelles pour l'argent et la population.\n" +
                    "Mensuel utilise revenus moins dépenses du budget et une projection de population sur 24 h." },
                { m_Settings.GetOptionLocaleID("MoneyViewModeHourly"), "Horaire (/h)" },
                { m_Settings.GetOptionLocaleID("MoneyViewModeMonthly"), "Mensuel (/mo)" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyTooltipMode)), "Style infobulle argent" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyTooltipMode)), "Choisis le niveau de détail de l'infobulle argent.\n" +
                    "Compact = défaut à la première installation.\n" +
                    "<Mini> affiche seulement 2 valeurs nettes pour /mo et /h.\n" +
                    "<Compact> raccourcit les grands nombres (15.21M au lieu de 15,212,318).\n" +
                    "<Données complètes> affiche les valeurs longues et les totaux." },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeMini"), "Mini" },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeCompact"), "Compact" },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeFullData"), "Données complètes" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyTooltipFontScale)), "Taille police argent" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyTooltipFontScale)), "Ajuste la <taille de police> des chiffres de l'infobulle argent.\n" +
                    "Défaut du jeu = 100%\n" +
                    "<Défaut du mod = 120%>\n" +
                    "Survole l'argent en bas de l'écran.\n" +
                    "Demandé par les joueurs qui lisent mal les petites infobulles." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.PopulationTooltipFontScale)), "Taille police population" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.PopulationTooltipFontScale)), "Ajuste la <taille de police> des chiffres de population.\n" +
                    "Défaut du jeu = 100%\n" +
                    "<Défaut du mod = 120%>\n" +
                    "Survole la population en bas de l'écran." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudEnabled)), "Mini HUD" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudEnabled)), "Affiche un petit HUD avec les compteurs d'alertes importants.\n" +
                    "Sert de bande d'alerte rapide sans ouvrir tout le panneau City Watchdog.\n" +
                    "Cliquer une icône saute vers un problème correspondant.\n" +
                    "Cliquer à nouveau fait tourner les emplacements puis revient au premier." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ApplyMiniHudRecommendedPreset)), "Réglage rapide recommandé" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ApplyMiniHudRecommendedPreset)), "Applique un réglage recommandé du Mini HUD :\n" +
                    "Favoris, 5 icônes, horizontal, haut centre, taille 100%, panneau sombre.\n" +
                    "Les alertes à zéro restent visibles.\n" +
                    "Ajoute/retire des favoris **Étoile bleue** quand tu veux dans le panneau Watchdog ouvert.\n" +
                    "Les favoris de départ **Étoile bleue** sont inclus avec **[Recommandé]**." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudMode)), "Mode Mini HUD" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudMode)), "Choisis les lignes d'alerte utilisées par le Mini HUD.\n" +
                    "**Alertes principales** affiche les compteurs actuels les plus hauts.\n" +
                    "**Favoris** inclut toutes les lignes marquées **Étoile bleue** dans le panneau principal.\n" +
                    "Tu peux choisir autant de favoris que tu veux,\n" +
                    "mais le Mini HUD n'affiche que les 5 ou 10 plus grands compteurs de cette liste **favoris étoile bleue**." },
                { m_Settings.GetOptionLocaleID("MiniHudModeTopActive"), "Alertes principales" },
                { m_Settings.GetOptionLocaleID("MiniHudModeFavorites"), "Favoris" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudItemCount)), "Nombre d'icônes" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudItemCount)), "Choisis combien d'icônes d'alerte le Mini HUD peut afficher à la fois." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudScale)), "Taille des icônes" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudScale)), "Ajuste la taille des icônes et chiffres du Mini HUD.\n" +
                    "90% = compact. 100% = défaut. Jusqu'à 130% pour mieux voir." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudOrientation)), "Orientation" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudOrientation)), "Choisis si les icônes du Mini HUD sont en ligne ou en colonne." },
                { m_Settings.GetOptionLocaleID("MiniHudOrientationHorizontal"), "Horizontal" },
                { m_Settings.GetOptionLocaleID("MiniHudOrientationVertical"), "Vertical" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudPlacement)), "Position du HUD" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudPlacement)), "Choisis où apparaît le Mini HUD.\n" +
                    "Déplaçable permet de le bouger dans l'interface de la ville." },
                { m_Settings.GetOptionLocaleID("MiniHudPlacementTopCenter"), "Haut centre" },
                { m_Settings.GetOptionLocaleID("MiniHudPlacementTopRight"), "Haut droite" },
                { m_Settings.GetOptionLocaleID("MiniHudPlacementDraggable"), "Déplaçable" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudPanelStyle)), "Style sombre ou verre" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudPanelStyle)), "Choisis le fond du Mini HUD.\n" +
                    "Le panneau verre va de clair à blanc nuageux ; il ne devient pas plus sombre.\n" +
                    "Utilise le panneau sombre pour un HUD plus foncé, style jeu." },
                { m_Settings.GetOptionLocaleID("MiniHudPanelStyleDark"), "Panneau sombre" },
                { m_Settings.GetOptionLocaleID("MiniHudPanelStyleGlass"), "Panneau verre" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudPanelOpacity)), "Opacité du fond" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudPanelOpacity)), "Ajuste la transparence du fond du Mini HUD.\n" +
                    "Plus bas = plus transparent. Plus haut = plus opaque.\n" +
                    "Verre devient plus blanc/nuageux. Sombre devient plus opaque/foncé." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudHideZero)), "Masquer alertes à zéro" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudHideZero)), "Si activé [ ✓ ], le Mini HUD masque les lignes d'alerte avec un compteur à 0." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.InitialMoney)), "Argent initial" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.InitialMoney)), "Définit le solde de départ d'une nouvelle ville en <argent limité> ou de la première ville chargée,\n" +
                    "puis revient au défaut du jeu après application.\n" +
                    "Grisé si une ville est déjà chargée.\n" +
                    "À régler avant de démarrer/charger une ville. S'applique une fois, puis utilise <Montant du raccourci argent> ou <Ajout automatique>." },
                { m_Settings.GetOptionLocaleID("GameDefault"), "Défaut du jeu" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.CustomMilestone)), "Sélecteur de jalon" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.CustomMilestone)), "Active <avant de charger ou démarrer une ville> pour débloquer le jalon choisi juste après le chargement.\n" +
                    "- Ne peut pas être activé après chargement, mais peut être désactivé s'il est resté actif par erreur.\n" +
                    "- Si tu as oublié et chargé une ville, redémarre le jeu et choisis le jalon avant d'entrer en ville.\n" +
                    "- Le mod ne peut pas annuler les changements de jalons déjà sauvegardés ; utilise une sauvegarde plus ancienne si besoin." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MilestoneLevel)), "Jalon" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MilestoneLevel)), "Choisis le jalon à débloquer au prochain chargement de ville.\n" +
                    "Réglable <seulement hors ville chargée>, et seulement si [Sélecteur de jalon] est activé [ ✓ ].\n" +
                    "Si la ville est déjà à ce jalon ou plus loin, rien ne se passe.\n" +
                    "Le changement n'arrive que si le jalon choisi est plus élevé." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ManualMoneyAmount)), "Montant du raccourci argent" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ManualMoneyAmount)), "Utilise ce montant avec les raccourcis Ajouter argent et Retirer argent.\n" +
                    "<Défaut du mod = 40 000>\n" +
                    "Ne fait rien sans utiliser le raccourci en ville.\n" +
                    "Pour l'automatisation, active Ajout automatique d'argent." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AddMoneyKeyboardBinding)), "Ajouter argent" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AddMoneyKeyboardBinding)), "Raccourci pour <Ajouter argent> en ville." },
                { m_Settings.GetBindingKeyLocaleID(Setting.AddMoneyAction), "Ajouter argent" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.SubtractMoneyKeyboardBinding)), "Retirer argent" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.SubtractMoneyKeyboardBinding)), "Raccourci pour <Retirer argent> en ville." },
                { m_Settings.GetBindingKeyLocaleID(Setting.SubtractMoneyAction), "Retirer argent" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoney)), "Ajout automatique d'argent" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoney)), "Si activé [ ✓ ], City Watchdog vérifie le solde de la ville pendant qu'elle est chargée.\n" +
                    "- Si le solde est <sous le seuil>,\n" +
                    "  il ajoute le montant automatique choisi.\n" +
                    "- Mieux vaut utiliser l'argent manuel avec raccourci (<[> ou <]>) au besoin\n" +
                    "  plutôt que cette option automatique, mais elle est là si tu la veux." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoneyThreshold)), "Seuil d'argent automatique" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoneyThreshold)), "Si l'ajout automatique est actif et que le solde passe sous cette valeur,\n" +
                    "le montant automatique choisi est ajouté." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoneyAmount)), "Montant automatique" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoneyAmount)), "Montant ajouté à chaque déclenchement automatique.\n" +
                    "Choisis une valeur suffisante pour repasser au-dessus du seuil." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ConfirmUnlimitedMoneySaveConversion)), "Convertisseur Argent illimité" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ConfirmUnlimitedMoneySaveConversion)), "<Fais d'abord une sauvegarde de la ville>.\n" +
                    "Convertit une ville commencée en Argent illimité en ville normale avec défis d'argent.\n" +
                    "Active le bouton <[Convertir sauvegarde Argent illimité]> quand la ville chargée est de type <Argent illimité>.\n" +
                    "City Watchdog ne peut pas annuler cette conversion.\n" +
                    "Pour les villes normales, pas besoin de cette option." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)), "Convertir ville Argent illimité en normale" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)), "Pour les villes commencées avec <Argent illimité>.\n" +
                    "Quand cette ville est chargée, convertit la sauvegarde en budget normal avec argent limité.\n" +
                    "Le bouton est <désactivé/grisé> sauf si la ville chargée est de type <Argent illimité>\n" +
                    "et si <Convertisseur Argent illimité> est ACTIVÉ [ ✓ ].\n" +
                    "Fais une sauvegarde et utilise à tes risques ; City Watchdog ne peut pas annuler." },
                { m_Settings.GetOptionWarningLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)), "Convertir cette ville d'Argent illimité vers argent limité normal ?\n" +
                    "Sauvegarde d'abord ; City Watchdog ne peut pas annuler.\n" +
                    "Confirmer ?" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.NameText)), "Nom du mod" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.NameText)), "Nom affiché de ce mod." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.VersionText)), "Version" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.VersionText)), "Version actuelle du mod." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.OpenParadox)), "Paradox Mods" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.OpenParadox)), "Ouvre la page Paradox Mods de l'auteur." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.WriteNotificationAuditLog)), "Rapport debug dans le log" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.WriteNotificationAuditLog)), "<Inutile pour jouer normalement.>\n" +
                    "Pour testeurs et vérifications après patch : écrit un rapport dans <Logs/CityWatchdog.log>\n" +
                    "comparant les notifications réelles du jeu aux icônes contrôlées par Watchdog." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.OpenLog)), "Ouvrir le log" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.OpenLog)), "Ouvre </Logs/CityWatchdog.log> s'il existe.\n" +
                    "Si le fichier manque, ouvre le dossier Logs/." },
            };

            return entries;
        }

        public void Unload()
        {
        }
    }
}
