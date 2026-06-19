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
            string title = Mod.ModName + " (Gardien)";

            Dictionary<string, string> entries = new Dictionary<string, string>
            {
                // --- Mod title ---
                { m_Settings.GetSettingsLocaleID(), title },

                // --- Tabs ---
                { m_Settings.GetOptionTabLocaleID(Setting.Actions), "Actions" },
                { m_Settings.GetOptionTabLocaleID(Setting.Hotkeys), "Raccourcis" },
                { m_Settings.GetOptionTabLocaleID(Setting.About), "À propos" },
                { m_Settings.GetOptionTabLocaleID(Setting.Debug), "Debug" },

                // --- Groups ---
                { m_Settings.GetOptionGroupLocaleID(Setting.MoneyViewGroup), "Visionneuse d'infos" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Money), "Argent" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Notifications), "Notifications" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Milestone), "Palier" },
                { m_Settings.GetOptionGroupLocaleID(Setting.SaveConversion), "Conversion de sauvegarde" },
                { m_Settings.GetOptionGroupLocaleID(Setting.HotkeyActions), "Raccourcis" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutInfo), "" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutLinks), "" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutDiagnostics), "DIAGNOSTIC" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutUsage), "UTILISATION" },

                // --- Money View ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyView)), "Afficher les détails au survol" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyView)),
                    "Affiche les tendances chiffrées à côté des flèches vanilla d'argent et de population dans la barre du bas.\n" +
                    "C'est un petit affichage au survol de la barre d'outils, <affichage seulement>;\n" +
                    "cela ne change ni l'argent ni la population de la ville."
                },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyViewMode)), "Fréquence Money View" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyViewMode)),
                    "Choisissez si le texte de tendance de la barre du bas affiche les valeurs horaires ou mensuelles pour l'argent et la population.\n" +
                    "Mensuel utilise les revenus du budget moins les dépenses pour l'argent, et une projection sur 24 heures pour la population."
                },
                { m_Settings.GetOptionLocaleID("MoneyViewModeHourly"), "Horaire (/h)" },
                { m_Settings.GetOptionLocaleID("MoneyViewModeMonthly"), "Mensuel (/mo)" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyTooltipMode)), "Style de l'infobulle d'argent" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyTooltipMode)),
                    "Choisissez le niveau de détail dans l'infobulle d'argent au survol.\n" +
                    "Compact = valeur par défaut à la première installation.\n" +
                    "<Mini> affiche seulement 2 valeurs nettes pour /mo et /h.\n" +
                    "<Compact> raccourcit les grands nombres (15.21M au lieu de 15,212,318).\n" +
                    "<Données complètes> affiche les valeurs longues et les champs Total."
                },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeMini"), "Mini" },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeCompact"), "Compact" },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeFullData"), "Données complètes" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyTooltipFontScale)), "Taille de police de l'argent" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyTooltipFontScale)),
                    "Ajuste la <taille de police> des nombres dans l'infobulle Money View.\n" +
                    "Valeur du jeu = 100%\n" +
                    "<Valeur du mod = 120%>\n" +
                    "Survolez l'argent en bas de l'écran.\n" +
                    "Demandé par des joueurs qui ont du mal à lire les petites infobulles du jeu."
                },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.PopulationTooltipFontScale)), "Taille de police de la population" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.PopulationTooltipFontScale)),
                    "Ajuste la <taille de police> des nombres dans l'infobulle de population.\n" +
                    "Valeur du jeu = 100%\n" +
                    "<Valeur du mod = 120%>\n" +
                    "Survolez Population en bas de l'écran."
                },

                // --- Money helpers ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ManualMoneyAmount)), "Montant du raccourci d'argent" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ManualMoneyAmount)),
                    "Utilisez ce montant avec les raccourcis Ajouter de l'argent et Retirer de l'argent.\n" +
                    "<Valeur du mod = 40,000>\n" +
                    "Cela ne fait rien sauf si vous utilisez le raccourci pour ajouter/retirer de l'argent dans la ville.\n" +
                    "Pour l'argent automatique, activez l'option Ajout automatique d'argent."
                },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AddMoneyKeyboardBinding)), "Ajouter de l'argent" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AddMoneyKeyboardBinding)), "Raccourci pour <Ajouter de l'argent> dans la ville." },
                { m_Settings.GetBindingKeyLocaleID(Setting.AddMoneyAction), "Ajouter de l'argent" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.SubtractMoneyKeyboardBinding)), "Retirer de l'argent" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.SubtractMoneyKeyboardBinding)), "Raccourci pour <Retirer de l'argent> dans la ville." },
                { m_Settings.GetBindingKeyLocaleID(Setting.SubtractMoneyAction), "Retirer de l'argent" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoney)), "Ajout automatique d'argent" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoney)),
                    "Quand l'option est activée [ ✓ ], City Watchdog vérifie le solde de la ville pendant qu'une ville est chargée.\n" +
                    "- Si le solde est <sous le seuil>, \n" +
                    "  il ajoute le montant automatique choisi.\n" +
                    "- Il est recommandé d'utiliser plutôt l'argent manuel avec le raccourci (<[> ou <]>) au besoin\n" +
                    "  au lieu de cette option automatique, mais elle est là si vous la voulez."
                },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoneyThreshold)), "Seuil d'argent automatique" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoneyThreshold)),
                    "Si l'ajout automatique d'argent est activé et que le solde de la ville passe sous cette valeur,\n" +
                    "le montant automatique choisi est ajouté."
                },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoneyAmount)), "Montant d'argent automatique" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoneyAmount)),
                    "Montant ajouté chaque fois que l'ajout automatique d'argent se déclenche.\n" +
                    "Choisissez une valeur assez haute pour ramener la ville au-dessus du seuil en sécurité."
                },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.InitialMoney)), "Argent initial" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.InitialMoney)),
                    "Définit le solde de départ pour une nouvelle ville avec <argent limité> ou la première ville chargée,\n" +
                    "puis revient à la valeur du jeu après application.\n" +
                    "Cette option est grisée si une ville est déjà chargée.\n" +
                    "À régler avant de démarrer/charger une ville → s'applique une fois → puis utilisez <Montant du raccourci d'argent> ou <Ajout automatique d'argent>."
                },
                { m_Settings.GetOptionLocaleID("GameDefault"), "Valeur du jeu" },

                // --- Notifications ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleNotificationsKeyboardBinding)), "Afficher/Masquer les icônes de notification" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleNotificationsKeyboardBinding)),
                    "<Raccourci> pour la même action que le bouton <[TOGGLE ALL]> dans le panneau du jeu.\n" +
                    "Affiche ou masque instantanément toutes les icônes de notification listées de la ville."
                },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleNotificationsAction), "Afficher/Masquer instantanément toutes les icônes de notification" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleNotificationPanelKeyboardBinding)), "Ouvrir/Fermer le panneau de notifications" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleNotificationPanelKeyboardBinding)),
                    "<Raccourci> pour ouvrir ou fermer le\n" +
                    "<panneau de notifications> dans la ville.\n" +
                    "Fonctionne comme un clic sur l'icône en haut à gauche pour ouvrir le panneau complet."
                },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleNotificationPanelAction), "Ouvrir/Fermer le panneau de notifications" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleRoadNamesKeyboardBinding)), "Masquer/Afficher les noms de routes" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleRoadNamesKeyboardBinding)),
                    "<Raccourci> pour masquer ou afficher instantanément les étiquettes vanilla des noms de routes dans la ville.\n" +
                    "Même effet qu'un clic sur l'icône Nom de route dans la barre du panneau City Watchdog."
                },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleRoadNamesAction), "Masquer/Afficher les noms de routes" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.DisableAllTooltips)), "Désactiver toutes les infobulles au survol" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.DisableAllTooltips)),
                    "Désactive les infobulles du jeu au survol — celles qui suivent le curseur sur les bâtiments/citoyens/outils\n" +
                    " et les petits popups sur les boutons de l'interface du jeu (noms de la barre du haut, boutons vanilla, etc.).\n" +
                    "<Les popups argent/population propres à City Watchdog restent actifs>; ils sont contrôlés par l'option Money View ci-dessus.\n" +
                    "Même effet qu'un clic sur l'icône [i] du panneau City Watchdog dans la ville."
                },

                // --- Milestone selector ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.CustomMilestone)), "Sélecteur de palier" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.CustomMilestone)),
                    "Activez avant de charger ou de démarrer une ville pour débloquer le palier choisi juste après le chargement.\n" +
                    "Impossible de l'activer pendant qu'une ville est chargée, mais vous pouvez le désactiver s'il est resté activé par erreur.\n" +
                    "City Watchdog ne peut pas annuler les changements de palier déjà enregistrés dans une ville; utilisez une sauvegarde plus ancienne si besoin."
                },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MilestoneLevel)), "Palier" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MilestoneLevel)),
                    "Choisissez le niveau de palier à débloquer au prochain chargement de la ville.\n" +
                    "Réglable seulement hors d'une ville chargée, et seulement après activation de [Sélecteur de palier] [ ✓ ]."
                },

                // --- Save conversion ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ConfirmUnlimitedMoneySaveConversion)), "Convertisseur d'argent illimité" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ConfirmUnlimitedMoneySaveConversion)),
                    "<Faites d'ABORD une sauvegarde de la ville>.\n" +
                    "Convertit une ville commencée avec Argent illimité en ville normale avec les défis d'argent classiques.\n" +
                    "Activer ceci déverrouille le bouton <[Convertir la sauvegarde Argent illimité]> quand la ville chargée est de type <Argent illimité>.\n" +
                    "City Watchdog ne peut pas annuler cette conversion.\n" +
                    "Si vous avez des villes normales, pas d'inquiétude; ce n'est pas nécessaire."
                },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)), "Convertir la ville Argent illimité en normale" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)),
                    "Pour les villes commencées avec <Argent illimité>.\n" +
                    "Pendant que cette ville est chargée, convertit la sauvegarde en budget normal avec argent limité afin de retrouver les défis d'argent classiques.\n" +
                    "Le bouton est <désactivé/grisé> sauf si la ville chargée est de type <Argent illimité>\n" +
                    "et si <Convertisseur d'argent illimité> est activé [ ✓ ].\n" +
                    "Faites une sauvegarde et utilisez à vos risques; City Watchdog ne peut pas annuler cette conversion."
                },
                { m_Settings.GetOptionWarningLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)),
                    "Convertir cette ville d'Argent illimité en argent limité normal ?\n" +
                    "Sauvegardez d'ABORD; City Watchdog ne peut pas annuler cela.\n" +
                    "Êtes-vous sûr ?"
                },

                // --- About tab ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.NameText)), "Nom du mod" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.NameText)), "Nom affiché de ce mod." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.VersionText)), "Version" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.VersionText)), "Version actuelle du mod." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.OpenParadox)), "Paradox Mods" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.OpenParadox)), "Ouvre la page Paradox Mods de l'auteur." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.WriteNotificationAuditLog)), "Rapport debug dans le log" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.WriteNotificationAuditLog)),
                    "<Pas nécessaire pour jouer normalement.>\n" +
                    "Pour les testeurs et les vérifications après patch du jeu : écrit un rapport <Logs/CityWatchdog.log>\n" +
                    "comparant les prefabs de notification du jeu avec les icônes de notification actuellement contrôlées par Watchdog."
                },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.OpenLog)), "Ouvrir le log" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.OpenLog)),
                    "Ouvre </Logs/CityWatchdog.log> s'il existe.\n" +
                    "Si le fichier log est absent, ouvre le dossier Logs/ à la place."
                },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ShowUsage)), "Afficher les instructions" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ShowUsage)), "Affiche ou masque les instructions ci-dessous." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.UsageText)),
                    "<Options d'affichage>\n" +
                    "1. Bouton [i] : masquer/afficher TOUTES les infobulles du jeu (bâtiments, cims, outils, icônes du menu inférieur).\n" +
                    "2. Bouton Nom de route : masquer/afficher les noms de routes. Raccourci : \\.\n" +
                    "3. Bouton Flèches routières : forcer les flèches de routes à sens unique ON/OFF (masque aussi les noms de routes).\n" +
                    "4. Icône de barre de titre CWD : afficher/masquer les infobulles du panneau City Watchdog.\n" +
                    "\n" +
                    "<Alertes de notification>\n" +
                    "1. Cliquez sur le bouton City Watchdog (en haut à gauche), ou appuyez sur Shift+N, pour ouvrir le panneau.\n" +
                    "2. Bouton de tri croissant/décroissant.\n" +
                    "3. Toggle All pour tout activer/désactiver vite, ou ouvrez une section pour changer des icônes précises.\n" +
                    "4. Affiche ou masque seulement les icônes; ne corrige pas le problème de ville.\n" +
                    "\n" +
                    "<Aides d'argent>\n" +
                    "1. Ajouter ou retirer de l'argent : utilisez les touches par défaut [ et ] de <Montant du raccourci d'argent>.\n" +
                    "2. L'ajout automatique d'argent ajoute de l'argent quand une ville passe sous la limite définie.\n" +
                    "3. Convertir la sauvegarde Argent illimité concerne seulement les villes commencées avec Argent illimité et est <irréversible>.\n" +
                    "\n" +
                    "<Infobulles du menu du bas>\n" +
                    "Money View ajoute des tendances à la barre d'argent et de population, ainsi que des détails au survol.\n" +
                    "\n" +
                    "<Palier personnalisé>\n" +
                    "Définissez l'argent initial et sélectionnez les paliers dans les Options avant de charger ou de démarrer une ville."
                },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.UsageText)), "" },
            };

            return entries;
        }

        public void Unload()
        {
        }
    }
}
