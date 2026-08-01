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

    public sealed class LocaleFR : IDictionarySource
    {
        private readonly CwdSettings m_Settings;

        public LocaleFR(CwdSettings setting)
        {
            m_Settings = setting;
        }

        public IEnumerable<KeyValuePair<string, string>> ReadEntries(
            IList<IDictionaryEntryError> errors,
            Dictionary<string, int> indexCounts)
        {
            string title = Mod.ModName + " (Vigie urbaine)";

            Dictionary<string, string> entries = new()
            {
                { m_Settings.GetSettingsLocaleID(), title },
                { m_Settings.GetOptionTabLocaleID(CwdSettings.Actions), "Actions" },
                { m_Settings.GetOptionTabLocaleID(CwdSettings.MiniHudTab), "Mini-HUD" },
                { m_Settings.GetOptionTabLocaleID(CwdSettings.MoneyTab), "Départ ville" },
                { m_Settings.GetOptionTabLocaleID(CwdSettings.About), "À propos" },
                { m_Settings.GetOptionGroupLocaleID(CwdSettings.AboutUsage), "UTILISATION" },
                { m_Settings.GetOptionGroupLocaleID(CwdSettings.Notifications), "Notifications" },
                { m_Settings.GetOptionGroupLocaleID(CwdSettings.MoneyViewGroup), "Infos en jeu" },
                { m_Settings.GetOptionGroupLocaleID(CwdSettings.MiniHudGroup), "Alertes Mini HUD" },
                { m_Settings.GetOptionGroupLocaleID(CwdSettings.Milestone), "DÉPART NOUVELLE VILLE" },
                { m_Settings.GetOptionGroupLocaleID(CwdSettings.Money), "Argent" },
                { m_Settings.GetOptionGroupLocaleID(CwdSettings.SaveConversion), "Convertir sauvegarde illimitée" },
                { m_Settings.GetOptionGroupLocaleID(CwdSettings.AboutInfo), "" },
                { m_Settings.GetOptionGroupLocaleID(CwdSettings.AboutLinks), "" },
                { m_Settings.GetOptionGroupLocaleID(CwdSettings.AboutDiagnostics), "DIAGNOSTIC" },
                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.ShowUsage)), "Afficher les instructions" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.ShowUsage)), "Affiche ou masque les instructions ci-dessous." },
                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.UsageText)),
                    "A. Clique l’icône patte en haut à gauche, ou Shift+N, pour ouvrir le panneau.\n" +
                    "<Boutons d’affichage>\n" +
                    "1. Icône de titre : affiche/masque les infobulles City Watchdog.\n" +
                    "\n" +
                    "2. Bouton **[i]** : masque/affiche <TOUTES> les infobulles du jeu : bâtiments, citoyens, outils, barre basse.\n" +
                    "3. Bouton routes : masque/affiche les noms de rues. Raccourci : \\.\n" +
                    "4. Bouton districts : masque/affiche les noms de districts.\n" +
                    "5. Bouton flèches : active/désactive les flèches à sens unique (masque aussi les noms de rues).\n" +
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
                    "Départ ville > DÉPART NOUVELLE VILLE règle l’argent initial ou les jalons avant de charger/démarrer." },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.UsageText)), "" },
                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.ToggleNotificationsKeyboardBinding)), "Basculer les icônes d’alerte" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.ToggleNotificationsKeyboardBinding)),
                    "<Raccourci> pour la même action que le bouton <[Tout basculer]> en jeu.\n" +
                    "Affiche ou masque tout de suite toutes les icônes d’alerte listées." },
                { m_Settings.GetBindingKeyLocaleID(CwdSettings.ToggleNotificationsAction), "Afficher/masquer toutes les icônes d’alerte" },
                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.ToggleNotificationPanelKeyboardBinding)), "Ouvrir/fermer le panneau d’alertes" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.ToggleNotificationPanelKeyboardBinding)),
                    "<Raccourci> pour ouvrir ou fermer le\n" +
                    "<panneau d’alertes> en jeu.\n" +
                    "Comme cliquer l’icône en haut à gauche." },
                { m_Settings.GetBindingKeyLocaleID(CwdSettings.ToggleNotificationPanelAction), "Ouvrir/fermer le panneau d’alertes" },
                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.PanelButtonsOnlyStart)), "Démarrage boutons seuls" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.PanelButtonsOnlyStart)),
                    "Si activé [ ✓ ], City Watchdog s’ouvre d’abord en petite vue boutons seuls.\n" +
                    "Utilise la flèche du titre ou le compteur pour ouvrir le panneau complet." },
                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.ToggleRoadNamesKeyboardBinding)), "Masquer/afficher noms de rues" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.ToggleRoadNamesKeyboardBinding)),
                    "<Raccourci> pour masquer/afficher les noms de rues du jeu de base.\n" +
                    "Comme l’icône Noms de rues dans City Watchdog." },
                { m_Settings.GetBindingKeyLocaleID(CwdSettings.ToggleRoadNamesAction), "Masquer/afficher noms de rues" },
                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.ToggleAllTooltipsKeyboardBinding)), "Désactiver toutes les infobulles" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.ToggleAllTooltipsKeyboardBinding)),
                    "<Raccourci> pour masquer/afficher TOUTES les infobulles du jeu : bâtiments, citoyens, outils et icônes du bas.\n" +
                    "<Les fenêtres argent/population de City Watchdog restent actives> ; elles dépendent de Vue argent.\n" +
                    "Comme l’icône [i] du panneau City Watchdog." },
                { m_Settings.GetBindingKeyLocaleID(CwdSettings.ToggleAllTooltipsAction), "Masquer/afficher les infobulles du jeu" },
                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.MainPanelOpacity)), "Opacité du panneau principal" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.MainPanelOpacity)),
                    "Règle la transparence de l’arrière-plan du panneau principal des notifications.\n" +
                    "Les valeurs basses sont plus transparentes. Les valeurs hautes sont plus sombres et opaques." },
                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.MoneyView)), "Tendances argent + population" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.MoneyView)),
                    "<Recommandé>\n" +
                    "Menu du bas : affiche les tendances sur les flèches <argent et population>.\n" +
                    "Fonction légère au survol <affichage seul> ;\n" +
                    "gagne du temps et peut mieux marcher que le panneau d’infos du jeu." },
                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.MoneyViewMode)), "Fréquence Vue argent" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.MoneyViewMode)),
                    "Choisis les valeurs horaires ou mensuelles dans la barre du bas.\n" +
                    "Mensuel utilise revenus moins dépenses et une projection population 24 h." },
                { m_Settings.GetOptionLocaleID("MoneyViewModeHourly"), "Horaire (/h)" },
                { m_Settings.GetOptionLocaleID("MoneyViewModeMonthly"), "Mensuel (/mo)" },
                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.MoneyTooltipMode)), "Style infobulle argent" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.MoneyTooltipMode)),
                    "Choisis le niveau de détail de l’infobulle argent.\n" +
                    "Compact = défaut à la première installation.\n" +
                    "<Mini> montre seulement 2 valeurs nettes pour /mo et /h.\n" +
                    "<Compact> raccourcit les grands nombres (15.21M au lieu de 15,212,318).\n" +
                    "<Données complètes> montre valeurs longues et totaux." },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeMini"), "Mini" },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeCompact"), "Compact" },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeFullData"), "Données complètes" },
                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.MoneyTooltipFontScale)), "Taille police argent" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.MoneyTooltipFontScale)),
                    "Ajuste la <taille de police> des nombres de Vue argent.\n" +
                    "Défaut du jeu = 100%\n" +
                    "<Défaut du mod = 120%>\n" +
                    "Survole Argent en bas de l’écran.\n" +
                    "Pour les joueurs qui lisent mal les petites infobulles." },
                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.PopulationTooltipFontScale)), "Taille police population" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.PopulationTooltipFontScale)),
                    "Ajuste la <taille de police> des nombres de population.\n" +
                    "Défaut du jeu = 100%\n" +
                    "<Défaut du mod = 120%>\n" +
                    "Survole Population en bas de l’écran." },
                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.MiniHudEnabled)), "Mini HUD" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.MiniHudEnabled)),
                    "Affiche un petit HUD avec les compteurs d’alerte importants.\n" +
                    "Sert de bandeau rapide sans ouvrir tout le panneau.\n" +
                    "Cliquer une icône saute vers un problème correspondant.\n" +
                    "Recliquer fait tourner les résultats puis revient au premier." },
                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.ApplyMiniHudRecommendedPreset)), "Clic : démarrage rapide" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.ApplyMiniHudRecommendedPreset)),
                    "Applique un <démarrage rapide> pour le mini-affichage :\n" +
                    "Inclut une **sélection initiale d’étoiles bleues**.\n" +
                    "Une alerte avec **étoile bleue** peut apparaître dans le mini-affichage si elle fait partie des 5 ou 10 compteurs les plus élevés.\n" +
                    "Ajoute/retire des **étoiles bleues** dans le panneau Watchdog ouvert.\n" +
                    "Le préréglage comprend : Favoris, 5 icônes, vertical, déplaçable, taille 100 %, panneau sombre et icônes à 0 masquées."
                  },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.MiniHudMode)), "Mode mini-affichage" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.MiniHudMode)),
                    "Choisis les lignes d’alerte utilisées par le mini-affichage.\n" +
                    "**Alertes dominantes** montre les compteurs actuels les plus élevés.\n" +
                    "**Favoris** utilise les lignes avec **étoile bleue** dans le panneau principal City Watchdog.\n" +
                    "Tu peux choisir autant de favoris que tu veux,\n" +
                    "mais le mini-affichage montre seulement les 5 ou 10 compteurs les plus élevés de cette liste d’**étoiles bleues**."
                  },

                { m_Settings.GetOptionLocaleID("MiniHudModeTopActive"), "Alertes dominantes" },
                { m_Settings.GetOptionLocaleID("MiniHudModeFavorites"), "Favoris" },
                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.MiniHudItemCount)), "Nombre d’icônes" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.MiniHudItemCount)), "Choisis combien d’icônes le Mini HUD peut afficher." },
                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.MiniHudScale)), "Taille des icônes" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.MiniHudScale)),
                    "Redimensionne les icônes et nombres du Mini HUD.\n" +
                    "90 % = compact. 100 % = défaut. Jusqu’à 130 % pour mieux voir." },
                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.MiniHudOrientation)), "Orientation" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.MiniHudOrientation)), "Choisis ligne ou colonne." },
                { m_Settings.GetOptionLocaleID("MiniHudOrientationHorizontal"), "Horizontal" },
                { m_Settings.GetOptionLocaleID("MiniHudOrientationVertical"), "Vertical" },
                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.MiniHudPlacement)), "Position du HUD" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.MiniHudPlacement)),
                    "Choisis où apparaît le Mini HUD.\n" +
                    "Déplaçable permet de le bouger dans l’interface de ville." },
                { m_Settings.GetOptionLocaleID("MiniHudPlacementTopCenter"), "Haut centre" },
                { m_Settings.GetOptionLocaleID("MiniHudPlacementTopRight"), "Haut droit" },
                { m_Settings.GetOptionLocaleID("MiniHudPlacementDraggable"), "Déplaçable" },
                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.MiniHudPanelStyle)), "Style sombre ou verre" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.MiniHudPanelStyle)),
                    "Choisis le fond du Mini HUD.\n" +
                    "Verre va de clair à blanc voilé ; il ne devient pas plus sombre.\n" +
                    "Utilise Sombre pour un HUD plus foncé façon jeu." },
                { m_Settings.GetOptionLocaleID("MiniHudPanelStyleDark"), "Panneau sombre" },
                { m_Settings.GetOptionLocaleID("MiniHudPanelStyleGlass"), "Panneau verre" },
                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.MiniHudPanelOpacity)), "Opacité du fond" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.MiniHudPanelOpacity)),
                    "Ajuste la transparence du fond Mini HUD.\n" +
                    "Plus bas = plus transparent. Plus haut = plus opaque.\n" +
                    "Verre devient plus blanc. Sombre devient plus dense/foncé." },
                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.MiniHudHideZero)), "Masquer alertes à 0" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.MiniHudHideZero)), "Si activé [ ✓ ], Mini HUD masque les lignes avec un compteur à 0." },
                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.InitialMoney)), "Argent initial" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.InitialMoney)),
                    "Définit le solde de départ pour une nouvelle ville à <argent limité> ou la première ville chargée,\n" +
                    "puis revient au défaut du jeu.\n" +
                    "Grisé si une ville est déjà chargée.\n" +
                    "À régler avant de charger/démarrer. Ensuite utilise <Montant raccourci argent> ou <Argent auto>." },
                { m_Settings.GetOptionLocaleID("GameDefault"), "Défaut du jeu" },
                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.CustomMilestone)), "Sélecteur de jalon" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.CustomMilestone)),
                    "Active <avant de charger ou démarrer> pour débloquer un jalon au chargement.\n" +
                    "- Impossible d’activer dans une ville déjà chargée, mais possible de le désactiver.\n" +
                    "- Oublié ? Redémarre le jeu et choisis avant de charger ta ville.\n" +
                    "- Le mod n’annule pas les jalons déjà sauvegardés ; utilise une sauvegarde antérieure." },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.MilestoneLevel)), "Jalon" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.MilestoneLevel)),
                    "Choisis le jalon à débloquer au prochain chargement.\n" +
                    "Réglable <seulement hors ville chargée> et avec [Sélecteur de jalon] activé [ ✓ ].\n" +
                    "Si la ville est déjà à ce jalon ou plus, rien ne se passe.\n" +
                    "Changement seulement si le jalon choisi est plus haut." },
                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.ManualMoneyAmount)), "Montant raccourci argent" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.ManualMoneyAmount)),
                    "Utilise ce montant avec les raccourcis Ajouter et Retirer argent.\n" +
                    "<Défaut du mod = 40 000>\n" +
                    "Ne fait rien sans utiliser le raccourci en jeu.\n" +
                    "Pour automatiser, active Argent auto." },
                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.AddMoneyKeyboardBinding)), "Ajouter argent" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.AddMoneyKeyboardBinding)), "Raccourci pour <Ajouter argent> en jeu." },
                { m_Settings.GetBindingKeyLocaleID(CwdSettings.AddMoneyAction), "Ajouter argent" },
                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.SubtractMoneyKeyboardBinding)), "Retirer argent" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.SubtractMoneyKeyboardBinding)), "Raccourci pour <Retirer argent> en jeu." },
                { m_Settings.GetBindingKeyLocaleID(CwdSettings.SubtractMoneyAction), "Retirer argent" },
                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.AutomaticAddMoney)), "Argent auto" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.AutomaticAddMoney)),
                    "Si activé [ ✓ ], City Watchdog vérifie le solde de la ville.\n" +
                    "- Si le solde est <sous le seuil>,\n" +
                    "  il ajoute le montant choisi.\n" +
                    "- Mieux vaut utiliser l’argent manuel avec raccourci (<[> ou <]>) au besoin\n" +
                    "  plutôt que l’automatique ; option disponible quand même." },
                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.AutomaticAddMoneyThreshold)), "Seuil argent auto" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.AutomaticAddMoneyThreshold)),
                    "Si actif et si le solde tombe sous cette valeur,\n" +
                    "ajoute le montant choisi." },
                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.AutomaticAddMoneyAmount)), "Montant auto" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.AutomaticAddMoneyAmount)),
                    "Montant ajouté à chaque déclenchement auto.\n" +
                    "Choisis assez pour repasser au-dessus du seuil." },
                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.ConfirmUnlimitedMoneySaveConversion)), "Convertisseur argent illimité" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.ConfirmUnlimitedMoneySaveConversion)),
                    "<Fais d’abord une sauvegarde>.\n" +
                    "Convertit une ville créée avec Argent illimité en ville normale avec un budget limité.\n" +
                    "Active le bouton <[Convertir sauvegarde Argent illimité]> si la ville chargée est de type <Argent illimité>.\n" +
                    "City Watchdog ne peut pas annuler cette conversion.\n" +
                    "Si tes villes sont normales, ignore ceci." },
                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.ConvertUnlimitedMoneySave)), "Convertir ville Argent illimité en normale" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.ConvertUnlimitedMoneySave)),
                    "Pour les villes lancées avec <Argent illimité>.\n" +
                    "Avec cette ville chargée, convertit la sauvegarde en budget normal limité.\n" +
                    "Le bouton est <désactivé/grisé> sauf si la ville est de type <Argent illimité>\n" +
                    "et si <Convertisseur argent illimité> est ACTIVÉ [ ✓ ].\n" +
                    "Fais une sauvegarde ; utilise cette fonction à tes risques. City Watchdog ne peut pas annuler." },
                { m_Settings.GetOptionWarningLocaleID(nameof(CwdSettings.ConvertUnlimitedMoneySave)),
                    "Convertir cette ville d’Argent illimité en argent limité normal ?\n" +
                    "Sauvegarde d’abord ; City Watchdog ne peut pas annuler.\n" +
                    "Confirmer ?" },
                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.NameText)), "Nom du mod" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.NameText)), "Nom affiché de ce mod." },
                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.VersionText)), "Version" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.VersionText)), "Version actuelle du mod." },
                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.OpenParadox)), "Paradox Mods" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.OpenParadox)), "Ouvre la page Paradox Mods de l’auteur." },
                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.WriteNotificationAuditLog)), "Rapport de débogage" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.WriteNotificationAuditLog)),
                    "<Pas nécessaire en jeu normal.>\n" +
                    "Pour les tests et après les mises à jour du jeu : écrit un rapport dans <Logs/CityWatchdog.log>\n" +
                    "comparant les alertes du jeu aux icônes contrôlées par Watchdog." },
                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.OpenLog)), "Ouvrir le journal" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.OpenLog)),
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
