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
            string title = Mod.ModName + " (Vigie urbaine)";

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
                { m_Settings.GetOptionGroupLocaleID(Setting.MiniHudGroup), "Alertes Mini HUD" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Milestone), "DÉPART NOUVELLE VILLE" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Money), "Argent" },
                { m_Settings.GetOptionGroupLocaleID(Setting.SaveConversion), "Convertir sauvegarde illimitée" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutInfo), "" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutLinks), "" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutDiagnostics), "DIAGNOSTIC" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ShowUsage)), "Afficher les instructions" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ShowUsage)), "Affiche ou masque les instructions ci-dessous." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.UsageText)),
                    "A. Clique l’icône patte en haut à gauche, ou Shift+N, pour ouvrir le panneau.\n" +
                    "<Boutons d’affichage>\n" +
                    "1. Icône de titre : affiche/masque les infobulles City Watchdog.\n" +
                    "\n" +
                    "2. Bouton **[i]** : masque/affiche <TOUTES> les infobulles du jeu : bâtiments, citoyens, outils, barre basse.\n" +
                    "3. Bouton routes : masque/affiche les noms de rues. Raccourci : \\.\n" +
                    "4. Bouton districts : masque/affiche les noms de districts.\n" +
                    "5. Bouton flèches : force les flèches sens unique on/off (masque aussi les noms de rues).\n" +
                    "\n" +
                    "<Alertes>\n" +
                    "1. Tri : A→Z, Z→A, liste active seule.\n" +
                    "2. <[0/62]> = icônes actives/total. Clique pour ouvrir/fermer toutes les lignes.\n" +
                    "3a. [Tout basculer] active/désactive tout de suite toutes les icônes d’alerte.\n" +
                    "3b. Masque seulement les icônes ; ne corrige pas le problème de ville.\n" +
                    "\n" +
                    "<Aide argent>\n" +
                    "1. Ajouter / retirer argent : touches par défaut <[ ou ]> pour <Montant raccourci argent>.\n" +
                    "2. Argent auto ajoute de l’argent si la ville passe sous ta limite.\n" +
                    "3. Convertir une sauvegarde Argent illimité vaut seulement pour ces villes et c’est <irréversible>.\n" +
                    "\n" +
                    "<Infobulles du menu bas>\n" +
                    "Vue argent ajoute des détails comme les tendances au survol de l’argent ou de la population.\n" +
                    "\n" +
                    "<Jalon personnalisé>\n" +
                    "Argent-Jalons > DÉPART NOUVELLE VILLE règle l’argent initial ou les jalons avant de charger/démarrer." },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.UsageText)), "" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleNotificationsKeyboardBinding)), "Basculer les icônes d’alerte" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleNotificationsKeyboardBinding)),
                    "<Raccourci> pour la même action que le bouton <[Tout basculer]> en jeu.\n" +
                    "Affiche ou masque tout de suite toutes les icônes d’alerte listées." },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleNotificationsAction), "Afficher/masquer toutes les icônes d’alerte" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleNotificationPanelKeyboardBinding)), "Ouvrir/fermer le panneau d’alertes" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleNotificationPanelKeyboardBinding)),
                    "<Raccourci> pour ouvrir ou fermer le\n" +
                    "<panneau d’alertes> en ville.\n" +
                    "Comme cliquer l’icône en haut à gauche." },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleNotificationPanelAction), "Ouvrir/fermer le panneau d’alertes" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.PanelButtonsOnlyStart)), "Démarrage boutons seuls" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.PanelButtonsOnlyStart)),
                    "Si activé [ ✓ ], City Watchdog s’ouvre d’abord en petite vue boutons seuls.\n" +
                    "Utilise la flèche du titre ou le compteur pour ouvrir le panneau complet." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleRoadNamesKeyboardBinding)), "Masquer/afficher noms de rues" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleRoadNamesKeyboardBinding)),
                    "<Raccourci> pour masquer/afficher les noms de rues du jeu de base.\n" +
                    "Comme l’icône Noms de rues dans City Watchdog." },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleRoadNamesAction), "Masquer/afficher noms de rues" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleAllTooltipsKeyboardBinding)), "Désactiver toutes les infobulles" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleAllTooltipsKeyboardBinding)),
                    "<Raccourci> pour masquer/afficher TOUTES les infobulles du jeu : bâtiments, citoyens, outils et icônes du bas.\n" +
                    "<Les popups argent/population de City Watchdog restent actifs> ; ils dépendent de Vue argent.\n" +
                    "Comme l’icône [i] du panneau City Watchdog." },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleAllTooltipsAction), "Masquer/afficher les infobulles du jeu" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyView)), "Tendances argent + population" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyView)),
                    "<Recommandé>\n" +
                    "Menu du bas : affiche les tendances sur les flèches <argent et population>.\n" +
                    "Fonction légère au survol <affichage seul> ;\n" +
                    "gagne du temps et peut mieux marcher que le panneau d’infos du jeu." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyViewMode)), "Fréquence Vue argent" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyViewMode)),
                    "Choisis les valeurs horaires ou mensuelles dans la barre du bas.\n" +
                    "Mensuel utilise revenus moins dépenses et une projection population 24 h." },
                { m_Settings.GetOptionLocaleID("MoneyViewModeHourly"), "Horaire (/h)" },
                { m_Settings.GetOptionLocaleID("MoneyViewModeMonthly"), "Mensuel (/mo)" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyTooltipMode)), "Style infobulle argent" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyTooltipMode)),
                    "Choisis le niveau de détail de l’infobulle argent.\n" +
                    "Compact = défaut à la première installation.\n" +
                    "<Mini> montre seulement 2 valeurs nettes pour /mo et /h.\n" +
                    "<Compact> raccourcit les grands nombres (15.21M au lieu de 15,212,318).\n" +
                    "<Données complètes> montre valeurs longues et totaux." },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeMini"), "Mini" },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeCompact"), "Compact" },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeFullData"), "Données complètes" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyTooltipFontScale)), "Taille police argent" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyTooltipFontScale)),
                    "Ajuste la <taille de police> des nombres de Vue argent.\n" +
                    "Défaut du jeu = 100%\n" +
                    "<Défaut du mod = 120%>\n" +
                    "Survole Argent en bas de l’écran.\n" +
                    "Pour les joueurs qui lisent mal les petites infobulles." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.PopulationTooltipFontScale)), "Taille police population" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.PopulationTooltipFontScale)),
                    "Ajuste la <taille de police> des nombres de population.\n" +
                    "Défaut du jeu = 100%\n" +
                    "<Défaut du mod = 120%>\n" +
                    "Survole Population en bas de l’écran." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudEnabled)), "Mini HUD" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudEnabled)),
                    "Affiche un petit HUD avec les compteurs d’alerte importants.\n" +
                    "Sert de bandeau rapide sans ouvrir tout le panneau.\n" +
                    "Cliquer une icône saute vers un problème correspondant.\n" +
                    "Recliquer fait tourner les résultats puis revient au premier." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ApplyMiniHudRecommendedPreset)), "Clic : démarrage rapide" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ApplyMiniHudRecommendedPreset)),
                    "Applique un <démarrage rapide> pour Mini HUD :\n" +
                    "Inclut un **lot de favoris Blue Star**.\n" +
                    "Ajoute/retire les favoris **Blue Star** dans le panneau Watchdog ouvert.\n" +
                    "Favoris, 5 icônes, vertical, déplaçable, taille 100 %, panneau sombre.\n" +
                    "Les alertes à 0 sont masquées.\n"
                  },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudMode)), "Mode Mini HUD" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudMode)),
                    "Choisis les lignes utilisées par le Mini HUD.\n" +
                    "**Top actives** montre les compteurs actuels les plus hauts.\n" +
                    "**Favoris** utilise les lignes avec **Blue Star** dans le panneau principal.\n" +
                    "Tu peux choisir autant de favoris que tu veux,\n" +
                    "mais Mini HUD montre seulement le top 5 ou top 10 de cette liste **Blue Star**."
                  },
                { m_Settings.GetOptionLocaleID("MiniHudModeTopActive"), "Top alertes actives" },
                { m_Settings.GetOptionLocaleID("MiniHudModeFavorites"), "Favoris" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudItemCount)), "Nombre d’icônes" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudItemCount)), "Choisis combien d’icônes le Mini HUD peut afficher." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudScale)), "Taille des icônes" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudScale)),
                    "Redimensionne les icônes et nombres du Mini HUD.\n" +
                    "90 % = compact. 100 % = défaut. Jusqu’à 130 % pour mieux voir." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudOrientation)), "Orientation" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudOrientation)), "Choisis ligne ou colonne." },
                { m_Settings.GetOptionLocaleID("MiniHudOrientationHorizontal"), "Horizontal" },
                { m_Settings.GetOptionLocaleID("MiniHudOrientationVertical"), "Vertical" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudPlacement)), "Position du HUD" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudPlacement)),
                    "Choisis où apparaît le Mini HUD.\n" +
                    "Déplaçable permet de le bouger dans l’interface de ville." },
                { m_Settings.GetOptionLocaleID("MiniHudPlacementTopCenter"), "Haut centre" },
                { m_Settings.GetOptionLocaleID("MiniHudPlacementTopRight"), "Haut droit" },
                { m_Settings.GetOptionLocaleID("MiniHudPlacementDraggable"), "Déplaçable" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudPanelStyle)), "Style sombre ou verre" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudPanelStyle)),
                    "Choisis le fond du Mini HUD.\n" +
                    "Verre va de clair à blanc voilé ; il ne devient pas plus sombre.\n" +
                    "Utilise Sombre pour un HUD plus foncé façon jeu." },
                { m_Settings.GetOptionLocaleID("MiniHudPanelStyleDark"), "Panneau sombre" },
                { m_Settings.GetOptionLocaleID("MiniHudPanelStyleGlass"), "Panneau verre" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudPanelOpacity)), "Opacité du fond" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudPanelOpacity)),
                    "Ajuste la transparence du fond Mini HUD.\n" +
                    "Plus bas = plus transparent. Plus haut = plus opaque.\n" +
                    "Verre devient plus blanc. Sombre devient plus dense/foncé." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudHideZero)), "Masquer alertes à 0" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudHideZero)), "Si activé [ ✓ ], Mini HUD masque les lignes avec un compteur à 0." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.InitialMoney)), "Argent initial" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.InitialMoney)),
                    "Définit le solde de départ pour une nouvelle ville à <argent limité> ou la première ville chargée,\n" +
                    "puis revient au défaut du jeu.\n" +
                    "Grisé si une ville est déjà chargée.\n" +
                    "À régler avant de charger/démarrer. Ensuite utilise <Montant raccourci argent> ou <Argent auto>." },
                { m_Settings.GetOptionLocaleID("GameDefault"), "Défaut du jeu" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.CustomMilestone)), "Sélecteur de jalon" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.CustomMilestone)),
                    "Active <avant de charger ou démarrer> pour débloquer un jalon au chargement.\n" +
                    "- Impossible d’activer en ville chargée, mais possible de désactiver.\n" +
                    "- Oublié ? Redémarre le jeu et choisis avant d’entrer en ville.\n" +
                    "- Le mod n’annule pas les jalons déjà sauvegardés ; utilise une ancienne save." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MilestoneLevel)), "Jalon" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MilestoneLevel)),
                    "Choisis le jalon à débloquer au prochain chargement.\n" +
                    "Réglable <seulement hors ville chargée> et avec [Sélecteur de jalon] activé [ ✓ ].\n" +
                    "Si la ville est déjà à ce jalon ou plus, rien ne se passe.\n" +
                    "Changement seulement si le jalon choisi est plus haut." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ManualMoneyAmount)), "Montant raccourci argent" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ManualMoneyAmount)),
                    "Utilise ce montant avec les raccourcis Ajouter et Retirer argent.\n" +
                    "<Défaut du mod = 40 000>\n" +
                    "Ne fait rien sans utiliser le raccourci en ville.\n" +
                    "Pour automatiser, active Argent auto." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AddMoneyKeyboardBinding)), "Ajouter argent" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AddMoneyKeyboardBinding)), "Raccourci pour <Ajouter argent> en ville." },
                { m_Settings.GetBindingKeyLocaleID(Setting.AddMoneyAction), "Ajouter argent" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.SubtractMoneyKeyboardBinding)), "Retirer argent" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.SubtractMoneyKeyboardBinding)), "Raccourci pour <Retirer argent> en ville." },
                { m_Settings.GetBindingKeyLocaleID(Setting.SubtractMoneyAction), "Retirer argent" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoney)), "Argent auto" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoney)),
                    "Si activé [ ✓ ], City Watchdog vérifie le solde de la ville.\n" +
                    "- Si le solde est <sous le seuil>,\n" +
                    "  il ajoute le montant choisi.\n" +
                    "- Mieux vaut utiliser l’argent manuel avec raccourci (<[> ou <]>) au besoin\n" +
                    "  plutôt que l’automatique ; option disponible quand même." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoneyThreshold)), "Seuil argent auto" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoneyThreshold)),
                    "Si actif et si le solde tombe sous cette valeur,\n" +
                    "ajoute le montant choisi." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoneyAmount)), "Montant auto" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoneyAmount)),
                    "Montant ajouté à chaque déclenchement auto.\n" +
                    "Choisis assez pour repasser au-dessus du seuil." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ConfirmUnlimitedMoneySaveConversion)), "Convertisseur argent illimité" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ConfirmUnlimitedMoneySaveConversion)),
                    "<Fais d’abord une sauvegarde>.\n" +
                    "Convertit une ville créée en Argent illimité en ville normale.\n" +
                    "Active le bouton <[Convertir sauvegarde Argent illimité]> si la ville chargée est de type <Argent illimité>.\n" +
                    "City Watchdog ne peut pas annuler ça.\n" +
                    "Si tes villes sont normales, ignore ceci." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)), "Convertir ville Argent illimité en normale" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)),
                    "Pour les villes lancées avec <Argent illimité>.\n" +
                    "Avec cette ville chargée, convertit la sauvegarde en budget normal limité.\n" +
                    "Le bouton est <désactivé/grisé> sauf si la ville est de type <Argent illimité>\n" +
                    "et si <Convertisseur argent illimité> est ON [ ✓ ].\n" +
                    "Fais une sauvegarde ; à tes risques. City Watchdog ne peut pas annuler." },
                { m_Settings.GetOptionWarningLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)),
                    "Convertir cette ville d’Argent illimité en argent limité normal ?\n" +
                    "Sauvegarde d’abord ; City Watchdog ne peut pas annuler.\n" +
                    "Confirmer ?" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.NameText)), "Nom du mod" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.NameText)), "Nom affiché de ce mod." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.VersionText)), "Version" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.VersionText)), "Version actuelle du mod." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.OpenParadox)), "Paradox Mods" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.OpenParadox)), "Ouvre la page Paradox Mods de l’auteur." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.WriteNotificationAuditLog)), "Rapport debug au log" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.WriteNotificationAuditLog)),
                    "<Pas nécessaire en jeu normal.>\n" +
                    "Pour tests et patchs : écrit un rapport dans <Logs/CityWatchdog.log>\n" +
                    "comparant les alertes du jeu aux icônes contrôlées par Watchdog." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.OpenLog)), "Ouvrir log" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.OpenLog)),
                    "Ouvre </Logs/CityWatchdog.log> s’il existe.\n" +
                    "Sinon ouvre le dossier Logs/." },
            };

            return entries;
        }

        public void Unload()
        {
        }
    }
}
