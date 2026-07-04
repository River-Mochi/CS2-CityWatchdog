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
                // --- Mod title ---
                { m_Settings.GetSettingsLocaleID(), title },

                // --- Tabs ---
                { m_Settings.GetOptionTabLocaleID(Setting.Actions), "Actions" },
                { m_Settings.GetOptionTabLocaleID(Setting.MiniHudTab), "Mini-HUD" },
                { m_Settings.GetOptionTabLocaleID(Setting.MoneyTab), "Argent-Jalons" },
                { m_Settings.GetOptionTabLocaleID(Setting.About), "À propos" },

                // --- Groups, ordered by Options menu location ---
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutUsage), "UTILISATION" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Notifications), "Notifications" },
                { m_Settings.GetOptionGroupLocaleID(Setting.MoneyViewGroup), "Infos en ville" },
                { m_Settings.GetOptionGroupLocaleID(Setting.MiniHudGroup), "Notifications Mini HUD" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Milestone), "NOUVELLE VILLE" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Money), "Argent" },
                { m_Settings.GetOptionGroupLocaleID(Setting.SaveConversion), "Convertir sauvegarde illimitée" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutInfo), "" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutLinks), "" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutDiagnostics), "DIAGNOSTIC" },

                // --------------------------------------------------------------------
                // Actions tab - Usage
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ShowUsage)), "Afficher les instructions" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ShowUsage)), "Afficher ou masquer les instructions ci-dessous." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.UsageText)),
                    "<Affichage>\n" +
                    "1. Bouton [i] : masque/affiche TOUS les infobulles du jeu.\n" +
                    "2. Bouton Noms de routes : masque/affiche les noms. Raccourci : \\.\n" +
                    "3. Bouton Districts : masque/affiche les noms sans changer les limites.\n" +
                    "4. Bouton flèches : force les flèches de sens unique (masque aussi les noms de routes).\n" +
                    "5. Icône CWD : masque/affiche les infobulles du panneau City Watchdog.\n\n" +
                    "<Alertes>\n" +
                    "1. Clique sur City Watchdog (en haut à gauche) ou Shift+N pour ouvrir le panneau.\n" +
                    "2. Bouton de tri : ordre croissant/décroissant.\n" +
                    "3. Toggle All active/désactive vite tout, ou ouvre une section pour choisir.\n" +
                    "4. Masque seulement les icônes; ne corrige pas le problème de la ville.\n\n" +
                    "<Aide argent>\n" +
                    "1. Ajouter/retirer de l’argent : touches par défaut [ et ].\n" +
                    "2. L’ajout automatique ajoute de l’argent sous la limite choisie.\n" +
                    "3. Convertir une sauvegarde Argent illimité sert seulement aux villes Argent illimité et est <irréversible>.\n\n" +
                    "<Infobulles du menu bas>\n" +
                    "Money View ajoute les tendances argent/population et des détails au survol.\n\n" +
                    "<Jalon personnalisé>\n" +
                    "Régle l’argent initial et le jalon avant de charger ou créer une ville."
                },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.UsageText)), "" },

                // --------------------------------------------------------------------
                // Actions tab - Notifications
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleNotificationsKeyboardBinding)), "Basculer les icônes d’alerte" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleNotificationsKeyboardBinding)),
                    "<Raccourci> pour la même action que le bouton <[TOGGLE ALL]> en ville.\n" +
                    "Affiche ou masque instantanément toutes les icônes listées." },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleNotificationsAction), "Afficher/masquer toutes les icônes d’alerte" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleNotificationPanelKeyboardBinding)), "Ouvrir/fermer le panneau d’alertes" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleNotificationPanelKeyboardBinding)),
                    "<Raccourci> pour ouvrir ou fermer le\n" +
                    "<panneau d’alertes> en ville.\n" +
                    "Même action que le bouton en haut à gauche."
                },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleNotificationPanelAction), "Ouvrir/fermer le panneau d’alertes" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.PanelButtonsOnlyStart)), "Démarrage en mode boutons" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.PanelButtonsOnlyStart)),
                    "Si activé [ ✓ ], City Watchdog s’ouvre d’abord en petit mode boutons.\n" +
                    "Utilise la flèche de titre ou le bouton compteur pour ouvrir le panneau complet." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleRoadNamesKeyboardBinding)), "Masquer/afficher les noms de routes" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleRoadNamesKeyboardBinding)),
                    "<Raccourci> pour masquer/afficher les noms de routes vanilla.\n" +
                    "Même action que l’icône Nom de route dans City Watchdog." },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleRoadNamesAction), "Masquer/afficher les noms de routes" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleAllTooltipsKeyboardBinding)), "Désactiver tous les infobulles au survol" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleAllTooltipsKeyboardBinding)),
                    "<Raccourci> pour masquer/afficher TOUS les infobulles du jeu.\n" +
                    "<Les popups argent/population de City Watchdog restent actifs>; option Money View ci-dessus.\n" +
                    "Même action que l’icône [i] dans le panneau City Watchdog." },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleAllTooltipsAction), "Masquer/afficher tous les infobulles du jeu" },

                // --------------------------------------------------------------------
                // Actions tab - In-City Info Viewer
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyView)), "Afficher les infobulles argent + population" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyView)),
                    "<Recommandé>\n" +
                    "Menu du bas : ajoute les tendances aux flèches argent/population.\n" +
                    "Fonction légère au survol de la barre <affichage seulement>;\n" +
                    "Évite d’ouvrir souvent le panneau d’infos du jeu."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyViewMode)), "Fréquence Money View" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyViewMode)),
                    "Choisis si les tendances du menu bas sont horaires ou mensuelles.\n" +
                    "Mensuel = revenus moins dépenses, et projection population sur 24 h." },
                { m_Settings.GetOptionLocaleID("MoneyViewModeHourly"), "Horaire (/h)" },
                { m_Settings.GetOptionLocaleID("MoneyViewModeMonthly"), "Mensuel (/mo)" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyTooltipMode)), "Style infobulle argent" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyTooltipMode)),
                    "Choisis le niveau de détail de l’infobulle argent.\n" +
                    "Compact = défaut au premier lancement.\n" +
                    "<Mini> affiche seulement 2 valeurs Net /mo et /h.\n" +
                    "<Compact> raccourcit les grands nombres (15.21M au lieu de 15,212,318).\n" +
                    "<Données complètes> affiche les longues valeurs et les totaux." },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeMini"), "Mini" },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeCompact"), "Compact" },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeFullData"), "Données complètes" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyTooltipFontScale)), "Taille police argent" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyTooltipFontScale)),
                    "Ajuste la <taille> des nombres Money View.\n" +
                    "Défaut du jeu = 100%\n" +
                    "<Défaut mod = 120%>\n" +
                    "Survole l’argent en bas de l’écran.\n" +
                    "Demandé par les joueurs qui trouvent les infobulles trop petites."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.PopulationTooltipFontScale)), "Taille police population" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.PopulationTooltipFontScale)),
                    "Ajuste la <taille> des nombres de population.\n" +
                    "Défaut du jeu = 100%\n" +
                    "<Défaut mod = 120%>\n" +
                    "Survole la population en bas de l’écran."
                },

                // --------------------------------------------------------------------
                // Mini-HUD tab - Mini HUD Notifications
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudEnabled)), "Mini HUD" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudEnabled)),
                    "Affiche un petit HUD avec les alertes importantes.\n" +
                    "Sert de bandeau rapide sans ouvrir le panneau complet.\n" +
                    "Cliquer une icône saute vers un problème correspondant.\n" +
                    "Reclique pour passer aux autres emplacements, puis revenir au premier."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ApplyMiniHudRecommendedPreset)), "Preset recommandé" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ApplyMiniHudRecommendedPreset)),
                    "Applique un réglage Mini HUD recommandé :\n" +
                    "Favoris, 5 icônes, horizontal, haut centre, taille 100%, panneau sombre.\n" +
                    "Les alertes à zéro restent visibles.\n" +
                    "Ajoute/retire les favoris **Étoile bleue** dans le panneau complet.\n" +
                    "Les favoris de départ **Étoile bleue** sont inclus avec **[Recommandé]**."
                  },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudMode)), "Mode Mini HUD" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudMode)),
                    "Choisis les lignes utilisées par le Mini HUD.\n" +
                    "**Alertes actives** montre les plus grands compteurs.\n" +
                    "**Favoris** utilise les lignes marquées **Étoile bleue**.\n" +
                    "Tu peux choisir autant de favoris que tu veux,\n" +
                    "mais le Mini HUD affiche seulement les 5 ou 10 plus grands compteurs de cette liste." },
                { m_Settings.GetOptionLocaleID("MiniHudModeTopActive"), "Alertes actives" },
                { m_Settings.GetOptionLocaleID("MiniHudModeFavorites"), "Favoris" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudItemCount)), "Nombre d’icônes Mini HUD" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudItemCount)),
                    "Choisis combien d’icônes le Mini HUD peut afficher." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudScale)), "Taille Mini HUD" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudScale)),
                    "Ajuste la taille des icônes et nombres.\n" +
                    "90% = compact. 100% = défaut. Jusqu’à 130% pour mieux voir." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudOrientation)), "Orientation Mini HUD" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudOrientation)),
                    "Choisis une ligne ou une colonne." },
                { m_Settings.GetOptionLocaleID("MiniHudOrientationHorizontal"), "Horizontal" },
                { m_Settings.GetOptionLocaleID("MiniHudOrientationVertical"), "Vertical" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudPlacement)), "Position Mini HUD" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudPlacement)),
                    "Choisis où apparaît le Mini HUD.\n" +
                    "Déplaçable permet de le bouger dans l’UI." },
                { m_Settings.GetOptionLocaleID("MiniHudPlacementTopCenter"), "Haut centre" },
                { m_Settings.GetOptionLocaleID("MiniHudPlacementTopRight"), "Haut droite" },
                { m_Settings.GetOptionLocaleID("MiniHudPlacementDraggable"), "Déplaçable" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudPanelStyle)), "Style Mini HUD" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudPanelStyle)),
                    "Choisis le style du fond Mini HUD.\n" +
                    "Verre : clair vers blanc nuageux, sans devenir plus sombre.\n" +
                    "Utilise Sombre pour un HUD vanilla plus foncé." },
                { m_Settings.GetOptionLocaleID("MiniHudPanelStyleDark"), "Panneau sombre" },
                { m_Settings.GetOptionLocaleID("MiniHudPanelStyleGlass"), "Panneau verre" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudPanelOpacity)), "Opacité Mini HUD" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudPanelOpacity)),
                    "Ajuste la transparence du fond Mini HUD.\n" +
                    "Plus bas = plus transparent. Plus haut = plus opaque.\n" +
                    "Verre devient plus blanc/nuageux. Sombre devient plus foncé." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudHideZero)), "Masquer les alertes à zéro" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudHideZero)),
                    "Si activé [ ✓ ], le Mini HUD masque les lignes à 0." },

                // --------------------------------------------------------------------
                // Money-Milestones tab - New City Start Settings
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.InitialMoney)), "Argent initial" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.InitialMoney)),
                    "Définit l’argent de départ pour une nouvelle ville <argent limité>,\n" +
                    "puis revient au Défaut du jeu après application.\n" +
                    "Grisé si une ville est déjà chargée.\n" +
                    "À régler avant de lancer/charger une ville. Ensuite utilise <Montant raccourci argent> ou <Ajout automatique>." },
                { m_Settings.GetOptionLocaleID("GameDefault"), "Défaut du jeu" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.CustomMilestone)), "Sélecteur de jalon" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.CustomMilestone)),
                    "Active-le <avant de charger ou créer une ville> pour débloquer un jalon au chargement.\n" +
                    "- Ne peut pas être activé après chargement, mais peut être désactivé.\n" +
                    "- Si tu as oublié, redémarre le jeu puis choisis avant d’entrer en ville.\n" +
                    "- Le mod ne peut pas annuler un jalon déjà sauvegardé; utilise une ancienne sauvegarde."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MilestoneLevel)), "Jalon" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MilestoneLevel)),
                    "Choisis le jalon à débloquer au prochain chargement.\n" +
                    "Réglable <seulement hors ville chargée> et après activation du [Sélecteur de jalon] [ ✓ ].\n" +
                    "Si la ville est déjà à ce jalon ou plus loin, rien ne se passe.\n" +
                    "Le changement se fait seulement si le jalon choisi est plus élevé."
                },

                // --------------------------------------------------------------------
                // Money-Milestones tab - Money
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ManualMoneyAmount)), "Montant raccourci argent" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ManualMoneyAmount)),
                    "Montant utilisé avec les raccourcis Ajouter et Retirer argent.\n" +
                    "<Défaut mod = 40 000>\n" +
                    "Ne fait rien sans utiliser le raccourci en ville.\n" +
                    "Pour l’automatique, active Ajout automatique d’argent."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AddMoneyKeyboardBinding)), "Ajouter argent" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AddMoneyKeyboardBinding)),
                    "Raccourci pour <Ajouter argent> en ville." },
                { m_Settings.GetBindingKeyLocaleID(Setting.AddMoneyAction), "Ajouter argent" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.SubtractMoneyKeyboardBinding)), "Retirer argent" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.SubtractMoneyKeyboardBinding)),
                    "Raccourci pour <Retirer argent> en ville." },
                { m_Settings.GetBindingKeyLocaleID(Setting.SubtractMoneyAction), "Retirer argent" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoney)), "Ajout automatique d’argent" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoney)),
                    "Si activé [ ✓ ], City Watchdog vérifie le solde en ville.\n" +
                    "- Si le solde est <sous le seuil>, \n" +
                    "  il ajoute le montant choisi.\n" +
                    "- Mieux vaut utiliser les raccourcis manuels (<[> ou <]>) au besoin" +
                    "  plutôt que l’automatique, mais l’option existe."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoneyThreshold)), "Seuil d’argent automatique" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoneyThreshold)),
                    "Si l’ajout automatique est actif et le solde passe sous cette valeur,\n" +
                    "ajoute le montant choisi." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoneyAmount)), "Montant automatique" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoneyAmount)),
                    "Montant ajouté à chaque déclenchement automatique.\n" +
                    "Choisis assez pour repasser au-dessus du seuil." },

                // --------------------------------------------------------------------
                // Money-Milestones tab - Save Conversion
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ConfirmUnlimitedMoneySaveConversion)), "Convertisseur Argent illimité" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ConfirmUnlimitedMoneySaveConversion)),
                    "<Fais une sauvegarde AVANT>.\n" +
                    "Convertit une ville créée en Argent illimité vers une ville normale.\n" +
                    "Active le bouton <[Convertir sauvegarde Argent illimité]> si la ville chargée est de type <Argent illimité>.\n" +
                    "City Watchdog ne peut pas annuler cette conversion.\n" +
                    "Si tes villes sont normales, ignore cette option." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)), "Convertir une ville Argent illimité en normale" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)),
                    "Pour les villes créées avec <Argent illimité>.\n" +
                    "Pendant que la ville est chargée, convertit la sauvegarde vers un budget normal.\n" +
                    "Bouton <désactivé/grisé> sauf si la ville est de type <Argent illimité>\n" +
                    "et que <Convertisseur Argent illimité> est activé [ ✓ ].\n" +
                    "Fais une sauvegarde et utilise à tes risques; City Watchdog ne peut pas annuler." },

                { m_Settings.GetOptionWarningLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)),
                    "Convertir cette ville d’Argent illimité vers argent limité normal ?\n" +
                    "Sauvegarde d’abord; City Watchdog ne peut pas annuler.\n" +
                    "Confirmer ?" },

                // --------------------------------------------------------------------
                // About tab
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.NameText)), "Nom du mod" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.NameText)), "Nom affiché de ce mod." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.VersionText)), "Version" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.VersionText)), "Version actuelle du mod." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.OpenParadox)), "Paradox Mods" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.OpenParadox)), "Ouvre la page Paradox Mods de l’auteur." },

                // --------------------------------------------------------------------
                // About tab - Diagnostics
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.WriteNotificationAuditLog)), "Rapport debug dans le log" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.WriteNotificationAuditLog)),
                    "<Inutile en jeu normal.>\n" +
                    "Pour tests et patchs du jeu : écrit un rapport <Logs/CityWatchdog.log>\n" +
                    "comparant les notifications du jeu avec celles contrôlées par Watchdog." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.OpenLog)), "Ouvrir le log" },
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
