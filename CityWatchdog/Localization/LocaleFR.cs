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
                { m_Settings.GetOptionTabLocaleID(Setting.Actions), "Actions"},
                { m_Settings.GetOptionTabLocaleID(Setting.MoneyTab), "Argent"},
                { m_Settings.GetOptionTabLocaleID(Setting.Hotkeys), "Raccourcis"},
                { m_Settings.GetOptionTabLocaleID(Setting.About), "À propos"},
                { m_Settings.GetOptionTabLocaleID(Setting.Debug), "Debug"},

                // --- Groups, ordered by Options menu location ---
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutUsage), "UTILISATION"},
                { m_Settings.GetOptionGroupLocaleID(Setting.Notifications), "Notifications"},
                { m_Settings.GetOptionGroupLocaleID(Setting.Milestone), "PARAMÈTRES DE DÉPART D’UNE NOUVELLE VILLE"},
                { m_Settings.GetOptionGroupLocaleID(Setting.MoneyViewGroup), "Infos en ville"},
                { m_Settings.GetOptionGroupLocaleID(Setting.Money), "Argent"},
                { m_Settings.GetOptionGroupLocaleID(Setting.SaveConversion), "Conversion de sauvegarde"},
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutInfo), ""},
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutLinks), ""},
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutDiagnostics), "DIAGNOSTIC"},
                { m_Settings.GetOptionGroupLocaleID(Setting.HotkeyActions), "Raccourcis"},

                // --------------------------------------------------------------------
                // Actions tab - Usage
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ShowUsage)), "Afficher les instructions"},
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ShowUsage)), "Affiche ou masque les instructions ci-dessous."},

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.UsageText)),
                    "<Options d’affichage>\n" +
                    "1. Bouton [i] : masquer/afficher TOUS les infobulles du jeu — bâtiments, citoyens, outils et icônes du menu du bas.\n" +
                    "2. Bouton Noms de routes : masquer/afficher les noms de routes. Raccourci : \\.\n" +
                    "3. Bouton Flèches de route : forcer l’affichage des flèches de sens unique (masque aussi les noms de routes).\n" +
                    "4. Icône CWD dans la barre de titre : afficher/masquer les infobulles du panneau City Watchdog.\n" +
                    "\n" +
                    "<Alertes de notification>\n" +
                    "1. Cliquez sur le bouton City Watchdog en haut à gauche, ou appuyez sur Shift+N, pour ouvrir le panneau.\n" +
                    "2. Le bouton de tri change l’ordre croissant/décroissant.\n" +
                    "3. Toggle All active/désactive rapidement tout, ou ouvrez une section pour régler chaque icône.\n" +
                    "4. Cela masque seulement les icônes; cela ne corrige pas le problème de la ville.\n" +
                    "\n" +
                    "<Aides d’argent>\n" +
                    "1. Ajouter ou retirer de l’argent : utilisez les raccourcis par défaut [ et ].\n" +
                    "2. L’ajout automatique ajoute de l’argent quand la ville passe sous la limite choisie.\n" +
                    "3. La conversion d’une sauvegarde Argent illimité est réservée aux villes créées avec Argent illimité et n’est <pas réversible>.\n" +
                    "\n" +
                    "<Infobulles du menu du bas>\n" +
                    "Money View ajoute des tendances à l’argent et à la population, avec plus de détails au survol.\n" +
                    "\n" +
                    "<Milestone personnalisé>\n" +
                    "Réglez l’argent initial et choisissez le milestone dans PARAMÈTRES DE DÉPART D’UNE NOUVELLE VILLE avant de charger ou créer une ville."},
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.UsageText)), ""},

                // --------------------------------------------------------------------
                // Actions tab - Notifications
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleNotificationsKeyboardBinding)), "Afficher/masquer les icônes de notification"},
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleNotificationsKeyboardBinding)),
                    "<Raccourci> pour la même action que le bouton <[TOGGLE ALL]> en ville.\n" +
                    "Affiche ou masque instantanément toutes les icônes de notification listées."},
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleNotificationsAction), "Afficher/Masquer instantanément toutes les icônes de notification"},

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleNotificationPanelKeyboardBinding)), "Ouvrir/fermer le panneau de notifications"},
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleNotificationPanelKeyboardBinding)),
                    "<Raccourci> pour ouvrir ou fermer le\n" +
                    "<panneau de notifications> en ville.\n" +
                    "Même effet que le bouton en haut à gauche."},
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleNotificationPanelAction), "Ouvrir/Fermer le panneau de notifications"},

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleRoadNamesKeyboardBinding)), "Masquer/Afficher les noms de routes"},
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleRoadNamesKeyboardBinding)),
                    "<Raccourci> pour masquer ou afficher instantanément les noms de routes du jeu.\n" +
                    "Même effet que l’icône Nom de route dans la barre d’outils City Watchdog."},
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleRoadNamesAction), "Masquer/Afficher les noms de routes"},

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleAllTooltipsKeyboardBinding)), "Désactiver toutes les infobulles au survol"},
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleAllTooltipsKeyboardBinding)),
                    "<Raccourci> pour masquer ou afficher TOUTES les infobulles du jeu — bâtiments, citoyens, outils et icônes du menu du bas.\n" +
                    "<Les fenêtres argent/population de City Watchdog restent actives>; elles sont contrôlées par Money View.\n" +
                    "Même effet que l’icône [i] du panneau City Watchdog."},
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleAllTooltipsAction), "Masquer/Afficher toutes les infobulles du jeu"},

                // --------------------------------------------------------------------
                // Actions tab - New City Start Settings
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.InitialMoney)), "Argent initial"},
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.InitialMoney)),
                    "Définit l’argent de départ pour une nouvelle ville avec <argent limité>, ou la première ville chargée,\n" +
                    "puis revient à Game Default après application.\n" +
                    "Grisé si une ville est déjà chargée.\n" +
                    "À régler avant de créer/charger une ville. Après application, utilisez <Montant raccourci argent> ou <Ajout automatique d’argent>."},
                { m_Settings.GetOptionLocaleID("GameDefault"), "Valeur du jeu"},

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.CustomMilestone)), "Sélecteur de milestone"},
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.CustomMilestone)),
                    "Activez <avant de charger ou créer une ville> pour débloquer immédiatement le milestone choisi après chargement.\n" +
                    "Impossible à activer quand une ville est déjà chargée, mais vous pouvez le désactiver s’il est resté actif par erreur.\n" +
                    "Si vous avez oublié, redémarrez le jeu et choisissez le milestone avant d’entrer en ville.\n" +
                    "City Watchdog ne peut pas annuler les milestones déjà sauvegardés dans une ville; utilisez une sauvegarde plus ancienne si besoin."},

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MilestoneLevel)), "Milestone"},
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MilestoneLevel)),
                    "Choisissez le milestone à débloquer au prochain chargement de ville.\n" +
                    "Réglable seulement hors ville chargée, et seulement après activation de [Sélecteur de milestone] [ ✓ ]."},

                // --------------------------------------------------------------------
                // Money tab - In City Info Viewer
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyView)), "Afficher les ToolTips argent + population"},
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyView)),
                    "<Activation recommandée>\n" +
                    "Menu du bas : affiche les tendances avec les flèches d’argent et de population du jeu.\n" +
                    "Fonction légère de survol de la barre d’outils <affichage seulement>;\n" +
                    "gagne du temps et peut être plus performant que d’ouvrir le panneau Info du jeu."},

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyViewMode)), "Fréquence Money View"},
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyViewMode)),
                    "Choisissez si le texte de tendance affiche les valeurs horaires ou mensuelles pour l’argent et la population.\n" +
                    "Mensuel utilise revenus moins dépenses du budget pour l’argent, et une projection sur 24 h pour la population."},
                { m_Settings.GetOptionLocaleID("MoneyViewModeHourly"), "Horaire (/h)"},
                { m_Settings.GetOptionLocaleID("MoneyViewModeMonthly"), "Mensuel (/mo)"},

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyTooltipMode)), "Style d’infobulle d’argent"},
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyTooltipMode)),
                    "Choisissez le niveau de détail dans l’infobulle d’argent.\n" +
                    "Compact = valeur par défaut à la première installation.\n" +
                    "<Mini> affiche seulement 2 valeurs Net pour /mo et /h.\n" +
                    "<Compact> raccourcit les grands nombres (15.21M au lieu de 15,212,318).\n" +
                    "<Full data> affiche les valeurs longues et les champs Total."},
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeMini"), "Mini"},
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeCompact"), "Compact"},
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeFullData"), "Données complètes"},

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyTooltipFontScale)), "Taille police argent"},
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyTooltipFontScale)),
                    "Ajuste la <taille de police> des nombres dans l’infobulle Money View.\n" +
                    "Jeu par défaut = 100%\n" +
                    "<Mod par défaut = 120%>\n" +
                    "Survolez Argent en bas de l’écran.\n" +
                    "Demandé par des joueurs qui ont du mal à lire les petites infobulles."},

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.PopulationTooltipFontScale)), "Taille police population"},
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.PopulationTooltipFontScale)),
                    "Ajuste la <taille de police> des nombres de population.\n" +
                    "Jeu par défaut = 100%\n" +
                    "<Mod par défaut = 120%>\n" +
                    "Survolez Population en bas de l’écran."},

                // --------------------------------------------------------------------
                // Money tab - Money
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ManualMoneyAmount)), "Montant du raccourci argent"},
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ManualMoneyAmount)),
                    "Utilisez ce montant avec les raccourcis Ajouter et Retirer de l’argent.\n" +
                    "<Mod par défaut = 40,000>\n" +
                    "Ne fait rien sans utiliser le raccourci en ville.\n" +
                    "Pour l’argent automatique, activez Ajout automatique d’argent."},

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AddMoneyKeyboardBinding)), "Ajouter de l’argent"},
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AddMoneyKeyboardBinding)),
                    "Raccourci pour <Ajouter de l’argent> en ville."},
                { m_Settings.GetBindingKeyLocaleID(Setting.AddMoneyAction), "Ajouter de l’argent"},

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.SubtractMoneyKeyboardBinding)), "Retirer de l’argent"},
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.SubtractMoneyKeyboardBinding)),
                    "Raccourci pour <Retirer de l’argent> en ville."},
                { m_Settings.GetBindingKeyLocaleID(Setting.SubtractMoneyAction), "Retirer de l’argent"},

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoney)), "Ajout automatique d’argent"},
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoney)),
                    "Quand activé [ ✓ ], City Watchdog vérifie le solde pendant qu’une ville est chargée.\n" +
                    "- Si le solde est <sous le seuil>,\n" +
                    "  il ajoute le montant automatique choisi.\n" +
                    "- Il est recommandé d’utiliser l’argent manuel avec les raccourcis (<[> ou <]>) au besoin, mais cette option est disponible."},

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoneyThreshold)), "Seuil d’argent automatique"},
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoneyThreshold)),
                    "Si l’ajout automatique est activé et que le solde passe sous cette valeur,\n" +
                    "ajoute le montant automatique choisi."},

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoneyAmount)), "Montant automatique"},
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoneyAmount)),
                    "Montant ajouté à chaque déclenchement automatique.\n" +
                    "Choisissez une valeur assez élevée pour repasser au-dessus du seuil."},

                // --------------------------------------------------------------------
                // Money tab - Save Conversion
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ConfirmUnlimitedMoneySaveConversion)), "Convertisseur Argent illimité"},
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ConfirmUnlimitedMoneySaveConversion)),
                    "<Faites d’abord une sauvegarde de la ville>.\n" +
                    "Convertit une ville créée avec Argent illimité en ville normale avec budget régulier.\n" +
                    "Activer ceci débloque le bouton <[Convertir la sauvegarde Argent illimité]> quand la ville chargée est de type <Argent illimité>.\n" +
                    "City Watchdog ne peut pas annuler cette conversion.\n" +
                    "Si vos villes sont normales, ignorez cette option."},

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)), "Convertir la ville Argent illimité en normale"},
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)),
                    "Pour les villes commencées avec <Argent illimité>.\n" +
                    "Pendant que cette ville est chargée, convertit la sauvegarde en budget limité normal.\n" +
                    "Le bouton est <désactivé/grisé> sauf si la ville chargée est de type <Argent illimité>\n" +
                    "et que <Convertisseur Argent illimité> est ON [ ✓ ].\n" +
                    "Faites une sauvegarde et utilisez à vos risques; City Watchdog ne peut pas annuler cette conversion."},

                { m_Settings.GetOptionWarningLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)),
                    "Convertir cette ville d’Argent illimité vers argent limité normal ?\n" +
                    "Sauvegardez D’ABORD; City Watchdog ne peut pas annuler cela.\n" +
                    "Êtes-vous sûr ?"},

                // --------------------------------------------------------------------
                // About tab
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.NameText)), "Nom du mod"},
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.NameText)), "Nom affiché de ce mod."},

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.VersionText)), "Version"},
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.VersionText)), "Version actuelle du mod."},

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.OpenParadox)), "Paradox Mods"},
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.OpenParadox)), "Ouvre la page Paradox Mods de l’auteur."},

                // --------------------------------------------------------------------
                // Debug tab - Diagnostics
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.WriteNotificationAuditLog)), "Rapport debug dans le log"},
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.WriteNotificationAuditLog)),
                    "<Inutile pour le jeu normal.>\n" +
                    "Pour testeurs et vérifications après patch : écrit un rapport <Logs/CityWatchdog.log>\n" +
                    "comparant les prefabs de notification du jeu avec les icônes contrôlées par Watchdog."},

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.OpenLog)), "Ouvrir le log"},
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.OpenLog)),
                    "Ouvre </Logs/CityWatchdog.log> s’il existe.\n" +
                    "Si le fichier manque, ouvre le dossier Logs/ à la place."},
            };

            return entries;
        }

        public void Unload()
        {
        }
    }
}
