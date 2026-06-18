// <copyright file="LocaleFR.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi, MIT License.
// See LICENSE file in the project root for full license info.
// </copyright>
//
// File: src/Localization/LocaleFR.cs
// Purpose: French (fr-FR) strings for City Watchdog Options UI (settings menu).

namespace CityWatchdog
{
    using System.Collections.Generic; // Dictionary and KeyValuePair
    using Colossal;                   // IDictionarySource

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
                { m_Settings.GetOptionTabLocaleID(Setting.Hotkeys), "Raccourcis" },
                { m_Settings.GetOptionTabLocaleID(Setting.About), "À propos" },
                { m_Settings.GetOptionTabLocaleID(Setting.Debug), "Débogage" },

                // --- Groups ---
                { m_Settings.GetOptionGroupLocaleID(Setting.MoneyViewGroup), "Visionneuse d’infos" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Money), "Argent" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Notifications), "Notifications" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Milestone), "Jalon" },
                { m_Settings.GetOptionGroupLocaleID(Setting.SaveConversion), "Conversion de sauvegarde" },
                { m_Settings.GetOptionGroupLocaleID(Setting.HotkeyActions), "Raccourcis" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutInfo), "" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutLinks), "" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutDiagnostics), "DIAGNOSTICS" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutUsage), "UTILISATION" },

                // --- Money View ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyView)), "Afficher les détails au survol" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyView)), "Affiche des valeurs numériques de tendance à côté des flèches vanilla d’argent et de population dans la barre du bas.\nC’est un affichage léger au survol de la barre d’outils, <affichage seulement> ;\nil ne change ni l’argent ni la population de la ville." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyViewMode)), "Fréquence de la vue argent" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyViewMode)), "Choisissez si le texte de tendance de la barre du bas affiche des valeurs horaires ou mensuelles pour l’argent et la population.\nLe mensuel utilise les revenus du budget moins les dépenses pour l’argent, et une projection sur 24 heures pour la population." },
                { m_Settings.GetOptionLocaleID("MoneyViewModeHourly"), "Horaire (/h)" },
                { m_Settings.GetOptionLocaleID("MoneyViewModeMonthly"), "Mensuel (/mo)" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyTooltipMode)), "Style de l’info-bulle argent" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyTooltipMode)), "Choisissez le niveau de détail affiché dans l’info-bulle d’argent au survol.\nCompact = valeur par défaut à la première installation.\n<Mini> affiche seulement 2 valeurs nettes pour /mo et /h.\n<Compact> raccourcit les grandes valeurs (15.21M au lieu de 15,212,318).\n<Données complètes> affiche les valeurs longues et les champs Total." },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeMini"), "Mini" },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeCompact"), "Compact" },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeFullData"), "Données complètes" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyTooltipFontScale)), "Taille de police de l’argent" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyTooltipFontScale)), "Ajuste la <taille de police> des nombres de l’info-bulle Money View.\nValeur du jeu = 100%\n<Valeur du mod = 120%>\nSurvolez l’argent en bas de l’écran.\nDemandé par des joueurs qui ont du mal à lire les petites info-bulles du jeu." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.PopulationTooltipFontScale)), "Taille de police de la population" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.PopulationTooltipFontScale)), "Ajuste la <taille de police> des nombres de l’info-bulle de population.\nValeur du jeu = 100%\n<Valeur du mod = 120%>\nSurvolez la population en bas de l’écran." },

                // --- Money helpers ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ManualMoneyAmount)), "Montant du raccourci argent" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ManualMoneyAmount)), "Utilisez ce montant avec les raccourcis Ajouter de l’argent et Retirer de l’argent.\n<Valeur du mod = 40 000>\nCela ne fait rien sauf si vous utilisez le raccourci pour ajouter/retirer de l’argent (dans la ville).\nPour l’argent automatique, activez l’option Ajout d’argent automatique." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AddMoneyKeyboardBinding)), "Ajouter de l’argent" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AddMoneyKeyboardBinding)), "Raccourci pour <Ajouter de l’argent> dans la ville." },
                { m_Settings.GetBindingKeyLocaleID(Setting.AddMoneyAction), "Ajouter de l’argent" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.SubtractMoneyKeyboardBinding)), "Retirer de l’argent" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.SubtractMoneyKeyboardBinding)), "Raccourci pour <Retirer de l’argent> dans la ville." },
                { m_Settings.GetBindingKeyLocaleID(Setting.SubtractMoneyAction), "Retirer de l’argent" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoney)), "Ajout d’argent automatique" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoney)), "Quand activé [ ✓ ], City Watchdog vérifie le solde de la ville pendant qu’une ville est chargée.\n- Si le solde est <sous le seuil>, \n  il ajoute le montant automatique choisi.\n- Il est recommandé d’utiliser l’argent manuel avec le raccourci (<[> ou <]>) au besoin plutôt que cette option automatique, mais elle est disponible si vous la voulez." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoneyThreshold)), "Seuil d’argent automatique" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoneyThreshold)), "Si l’ajout d’argent automatique est activé et que le solde de la ville tombe sous cette valeur,\najoute le montant automatique choisi." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoneyAmount)), "Montant d’argent automatique" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoneyAmount)), "Montant ajouté chaque fois que l’ajout d’argent automatique se déclenche.\nChoisissez une valeur assez élevée pour remettre la ville au-dessus du seuil en toute sécurité." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.InitialMoney)), "Argent initial" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.InitialMoney)), "Définit le solde de départ pour une nouvelle ville à <argent limité> ou pour la première ville chargée,\npuis revient à la valeur par défaut du jeu après application.\nCette option est grisée si une ville est déjà chargée.\nRéglez avant de démarrer/charger une ville → s’applique une fois → puis utilisez <Montant du raccourci argent> ou <Ajout d’argent automatique> ensuite." },
                { m_Settings.GetOptionLocaleID("GameDefault"), "Par défaut du jeu" },

                // --- Notifications ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleNotificationsKeyboardBinding)), "Basculer les icônes de notification" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleNotificationsKeyboardBinding)), "<Raccourci> pour la même action que le bouton <[TOGGLE ALL]> du panneau en jeu.\nAffiche ou masque instantanément toutes les icônes de notification de la ville listées." },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleNotificationsAction), "Afficher/masquer instantanément toutes les icônes de notification" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleNotificationPanelKeyboardBinding)), "Ouvrir/fermer le panneau des notifications" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleNotificationPanelKeyboardBinding)), "<Raccourci> pour ouvrir ou fermer le\n<panneau des notifications> dans la ville.\nFonctionne comme un clic sur l’icône en haut à gauche pour ouvrir le panneau complet." },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleNotificationPanelAction), "Ouvrir/fermer le panneau des notifications" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleRoadNamesKeyboardBinding)), "Masquer/afficher les noms de routes" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleRoadNamesKeyboardBinding)), "<Raccourci> pour masquer ou afficher instantanément les étiquettes vanilla des noms de routes dans la ville.\nIdentique au clic sur l’icône Nom de route dans la barre du panneau City Watchdog." },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleRoadNamesAction), "Masquer/afficher les noms de routes" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.DisableAllTooltips)), "Désactiver toutes les info-bulles au survol" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.DisableAllTooltips)), "Désactive les info-bulles de survol du jeu — celles qui suivent le curseur sur les bâtiments/citoyens/outils et les petites fenêtres sur les boutons de l’interface du jeu (noms de la barre supérieure, boutons vanilla, etc.).\n<Les popups argent/population de City Watchdog restent activés> ; ils sont contrôlés par l’option Money View ci-dessus.\nIdentique au clic sur l’icône [i] dans le panneau City Watchdog en ville." },

                // --- Milestone selector ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.CustomMilestone)), "Sélecteur de jalon" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.CustomMilestone)), "Activez avant de charger ou de démarrer une ville pour débloquer le jalon choisi immédiatement après le chargement.\nCette option ne peut pas être activée pendant qu’une ville est chargée, mais elle peut être désactivée si elle a été laissée activée par erreur.\nCity Watchdog ne peut pas annuler les changements de jalon déjà sauvegardés dans une ville ; utilisez une sauvegarde plus ancienne si nécessaire." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MilestoneLevel)), "Jalon" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MilestoneLevel)), "Choisissez le niveau de jalon à débloquer au prochain chargement de ville.\nRéglable seulement en dehors d’une ville chargée, et seulement après activation de [Sélecteur de jalon] [ ✓ ]." },

                // --- Save conversion ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ConfirmUnlimitedMoneySaveConversion)), "Convertisseur d’argent illimité" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ConfirmUnlimitedMoneySaveConversion)), "<Faites d’abord une sauvegarde de la ville>.\nConvertit une ville commencée en Argent illimité en ville normale avec des défis d’argent réguliers.\nL’activation déverrouille le bouton <[Convertir la sauvegarde Argent illimité]> quand la ville chargée est de type <Argent illimité>.\nCity Watchdog ne peut pas annuler cette conversion.\nSi vous avez des villes normales, ne vous inquiétez pas ; ce n’est pas nécessaire." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)), "Convertir une ville Argent illimité en ville normale" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)), "Pour les villes commencées avec <Argent illimité>.\nPendant que cette ville est chargée, cela convertit la sauvegarde en budget normal à argent limité afin que la ville ait de nouveau des défis d’argent réguliers.\nLe bouton est <désactivé/grisé> sauf si la ville chargée est de type <Argent illimité>\net si <Convertisseur d’argent illimité> est ON [ ✓ ].\nFaites une sauvegarde et utilisez à vos risques ; City Watchdog ne peut pas annuler cette conversion." },
                { m_Settings.GetOptionWarningLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)), "Convertir cette ville d’Argent illimité vers de l’argent limité normal ?\nSauvegardez d’abord une copie ; City Watchdog ne peut pas annuler cela.\nConfirmer ?" },

                // --- About tab ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.NameText)), "Nom du mod" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.NameText)), "Nom affiché de ce mod." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.VersionText)), "Version" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.VersionText)), "Version actuelle du mod." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.OpenParadox)), "Paradox Mods" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.OpenParadox)), "Ouvre la page Paradox Mods de l’auteur." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.WriteNotificationAuditLog)), "Rapport de débogage vers le journal" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.WriteNotificationAuditLog)), "<Pas nécessaire pour le jeu normal.>\nPour les testeurs et les vérifications après patch du jeu : écrit un rapport <Logs/CityWatchdog.log>\ncomparant les prefabs de notification du jeu en direct avec les icônes de notification actuellement contrôlées par Watchdog." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.OpenLog)), "Ouvrir le journal" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.OpenLog)), "Ouvre </Logs/CityWatchdog.log> s’il existe.\nSi le fichier journal est absent, ouvre le dossier Logs/ à la place." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ShowUsage)), "Afficher les instructions" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ShowUsage)), "Affiche ou masque les instructions d’utilisation ci-dessous." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.UsageText)), "<Panneau des notifications>\n1. Cliquez sur le bouton City Watchdog (en haut à gauche), ou appuyez sur Shift+N, pour ouvrir le panneau.\n2. Triez ASC/DESC.\n3. Toggle All pour tout activer/désactiver rapidement, ou développez une section pour modifier des icônes précises.\n4. Affiche ou masque seulement les icônes ; ne corrige pas le problème de la ville.\n\n<Aides d’argent>\n1. Ajouter ou retirer de l’argent : utilisez le <Montant du raccourci argent> par défaut [ ou ].\n2. L’ajout automatique d’argent surveille le budget pendant qu’une ville est chargée et ajoute de l’argent si le solde est sous le seuil.\n3. Money View ajoute des valeurs numériques à la barre argent/population et aux info-bulles au survol.\n4. Convertir une sauvegarde Argent illimité est seulement pour les villes commencées avec Argent illimité et est <irréversible>.\n\n<Jalon personnalisé>\nRéglez l’argent initial et choisissez les jalons dans le menu Options avant de charger ou de démarrer une ville." },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.UsageText)), "" },
            };

            return entries;
        }

        public void Unload()
        {
        }
    }
}
