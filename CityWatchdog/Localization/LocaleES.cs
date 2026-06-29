// <copyright file="LocaleES.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the MIT License. You may not use this file except in compliance with this License.
// See LICENSE file in the project root for full license information.
// This notice and the MIT License notice must be kept with
// all copies or substantial portions of this code.
// ================= </copyright> ======================

// File: src/Localization/LocaleES.cs
// Purpose: Spanish (es-ES) for City Watchdog Options UI menu.

namespace CityWatchdog
{
    using System.Collections.Generic; // Dictionary and KeyValuePair
    using Colossal;                   // IDictionarySource
    using Game.UI.Editor;

    public sealed class LocaleES : IDictionarySource
    {
        private readonly Setting m_Settings;

        public LocaleES(Setting setting)
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
                { m_Settings.GetOptionTabLocaleID(Setting.Actions), "Acciones" },
                { m_Settings.GetOptionTabLocaleID(Setting.MiniHudTab), "Mini-HUD" },
                { m_Settings.GetOptionTabLocaleID(Setting.MoneyTab), "Dinero e hitos" },
                { m_Settings.GetOptionTabLocaleID(Setting.About), "Acerca de" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutUsage), "USO" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Notifications), "Notificaciones" },
                { m_Settings.GetOptionGroupLocaleID(Setting.MoneyViewGroup), "Visor de información en la ciudad" },
                { m_Settings.GetOptionGroupLocaleID(Setting.MiniHudGroup), "Notificaciones Mini HUD" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Milestone), "AJUSTES DE INICIO DE NUEVA CIUDAD" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Money), "Dinero" },
                { m_Settings.GetOptionGroupLocaleID(Setting.SaveConversion), "Convertir guardado ilimitado" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutInfo), "" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutLinks), "" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutDiagnostics), "DIAGNÓSTICO" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ShowUsage)), "Mostrar instrucciones" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ShowUsage)), "Mostrar u ocultar the usage instructions below." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.UsageText)), "<Controles de visualización>\n1. Botón [i]: oculta/muestra TODOS los tooltips del juego.\n2. Botón Nombre de carretera: oculta/muestra nombres de carreteras. Atajo: \\.\n3. Botón Nombre de distrito: oculta/muestra nombres sin cambiar límites.\n4. Botón Flecha de carretera: fuerza flechas de sentido único y también oculta nombres de carretera.\n5. Icono de título CWD: muestra/oculta tooltips del panel.\n\n<Alertas>\n1. Pulsa City Watchdog arriba a la izquierda, o Shift+N.\n2. El botón de orden cambia ascendente/descendente.\n3. Toggle All apaga/enciende todo rápido, o expande una sección para iconos concretos.\n4. Solo oculta iconos; no arregla el problema de la ciudad.\n\n<Ayudas de dinero>\n1. Añadir o restar dinero: usa [ y ].\n2. El dinero automático se añade cuando la ciudad baja del límite.\n3. Convertir un guardado con dinero ilimitado es irreversible.\n\n<Tooltips del menú inferior>\nMoney View añade tendencias de dinero/población y detalles al pasar el ratón.\n\n<Hito personalizado>\nConfigura dinero inicial e hitos antes de cargar o iniciar una ciudad." },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.UsageText)), "" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleNotificationsKeyboardBinding)), "Mostrar/ocultar iconos de notificación" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleNotificationsKeyboardBinding)), "<Atajo> for the same action as the in-game <[TOGGLE ALL]> icon button.\nIt shows or hides all listed city notification icons instantly." },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleNotificationsAction), "Mostrar/Ocultar todos los iconos de notificación" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleNotificationPanelKeyboardBinding)), "Abrir/cerrar panel de notificaciones" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleNotificationPanelKeyboardBinding)), "<Atajo> for opening or closing the\n<panel de notificaciones> en la ciudad.\nWorks the same as clicking Top Left icon to open the full panel." },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleNotificationPanelAction), "Abrir/Cerrar panel de notificaciones" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.PanelButtonsOnlyStart)), "Iniciar solo con botones" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.PanelButtonsOnlyStart)), "Cuando está activado [ ✓ ], opening City Watchdog from the top-left button starts in the smaller buttons-only view.\nUse the title-bar arrow or the row-count button to expand the full panel." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleRoadNamesKeyboardBinding)), "Ocultar/mostrar nombres de carreteras" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleRoadNamesKeyboardBinding)), "<Atajo> to instantly hide or show the vanilla road name labels en la ciudad.\nSame as clicking the Road-Name icon in the City Watchdog panel toolbar." },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleRoadNamesAction), "Ocultar/mostrar nombres de carreteras" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleAllTooltipsKeyboardBinding)), "Desactivar todos los tooltips al pasar el ratón" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleAllTooltipsKeyboardBinding)), "<Atajo> to instantly hide or show ALL game hover tooltips — buildings, cims, tools, and bottom menu icons.\n<City Watchdog's own money/population popups stay on>; those are controlled by the Dinero View option above.\nSame as clicking the [i] icon on the City Watchdog panel inside the city." },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleAllTooltipsAction), "Ocultar/mostrar todos los tooltips del juego" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyView)), "Mostrar tooltips de dinero + población" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyView)), "<Recommend Enable>\nBottom game menu: Shows trend values with the game's bottom toolbar <money and population arrows>.\nThis is a lightweight hover over toolbar feature <display only>;\nSaves time and possible better performance than opening game's Info view panel." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyViewMode)), "Frecuencia de Money View" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyViewMode)), "Elige whether the bottom-toolbar trend text shows hourly or monthly values for money and population.\nMonthly uses budget income minus expenses for money, and a 24-hour projection for population." },
                { m_Settings.GetOptionLocaleID("MoneyViewModeHourly"), "Por hora (/h)" },
                { m_Settings.GetOptionLocaleID("MoneyViewModeMonthly"), "Mensual (/mo)" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyTooltipMode)), "Estilo del tooltip de dinero" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyTooltipMode)), "Elige how much detail appears in the money hover tooltip.\nCompacto = default on first install.\n<Mini> shows only 2 Net values for /mo and /h.\n<Compacto> shortens large values (15.21M instead of 15,212,318).\n<Datos completos> shows long values and Total fields." },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeMini"), "Mini" },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeCompact"), "Compacto" },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeFullData"), "Datos completos" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyTooltipFontScale)), "Tamaño de fuente del dinero" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyTooltipFontScale)), "Adjusts <font size> of Dinero View tooltip numbers.\nPredeterminado del juego = 100%\n<Predeterminado del mod = 120%>\nHover over Dinero at bottom of the screen.\nRequested by players who have hard time seeing smaller tooltips in the game." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.PopulationTooltipFontScale)), "Tamaño de fuente de población" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.PopulationTooltipFontScale)), "Adjusts <font size> of population tooltip numbers.\nPredeterminado del juego = 100%\n<Predeterminado del mod = 120%>\nHover over Population at bottom of the screen." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudEnabled)), "Mini HUD" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudEnabled)), "Muestra un HUD pequeño en la ciudad with the most important notification counts.\nUse it as a quick alert strip without opening the full City Watchdog panel.\nClicking an icon jumps to one matching problem spot.\nKeep clicking the same icon to rotate through matching spots, then back to the first one." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ApplyMiniHudRecommendedPreset)), "Preset recomendado" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ApplyMiniHudRecommendedPreset)), "Applies a recommended Mini HUD setup:\nFavoritos, 5 icons, vertical, draggable, hide zero alerts, glass style off.\nArrastrable vertical preset starts near the top-right side.\nStarter Blue-Star Favoritos: Not enough electricity, Electricity bottleneck, Battery depleted, Electric cable not connected, Power line not connected, Not enough water, Backed up sewer, Water pipe not connected, Sewer pipe not connected, Abandoned, High rent, Traffic jam, Road required, No pedestrian access, Lack of Labor, Water damage, On fire, Burned down, Garbage piling up, Traffic accident, Crime scene, Pathfinding failed, No vehicles.\nChange Estrella azuls anytime in the City Watchdog city panel." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudMode)), "Modo Mini HUD" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudMode)), "Elige which notification rows the Mini HUD uses.\n**Top active** alerts shows the highest current counts.\n**Favoritos** includes all rows marked with **Estrella azul** in the main City Watchdog panel.\nYou can pick as many favorites as you want,\nbut Mini HUD still shows only the top 5 or top 10 current counts from that **favorites blue-star** list." },
                { m_Settings.GetOptionLocaleID("MiniHudModeTopActive"), "Alertas más activas" },
                { m_Settings.GetOptionLocaleID("MiniHudModeFavorites"), "Favoritos" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudItemCount)), "Cantidad de iconos Mini HUD" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudItemCount)), "Elige how many notification icons the Mini HUD can show at once." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudOrientation)), "Orientación Mini HUD" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudOrientation)), "Elige whether Mini HUD icons are arranged in a row or a column." },
                { m_Settings.GetOptionLocaleID("MiniHudOrientationHorizontal"), "Horizontal" },
                { m_Settings.GetOptionLocaleID("MiniHudOrientationVertical"), "Vertical" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudPlacement)), "Ubicación Mini HUD" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudPlacement)), "Elige where the Mini HUD appears.\nArrastrable lets you move it en la ciudad UI." },
                { m_Settings.GetOptionLocaleID("MiniHudPlacementTopCenter"), "Arriba al centro" },
                { m_Settings.GetOptionLocaleID("MiniHudPlacementTopRight"), "Arriba a la derecha" },
                { m_Settings.GetOptionLocaleID("MiniHudPlacementDraggable"), "Arrastrable" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudHideZero)), "Ocultar alertas con cero" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudHideZero)), "Cuando está activado [ ✓ ], the Mini HUD hides notification rows with a count of 0." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudGlassStyle)), "Estilo cristal" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudGlassStyle)), "Adds a soft glass-style background behind the Mini HUD for readability." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.InitialMoney)), "Dinero inicial" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.InitialMoney)), "Sets the starting balance for a new <limited money> city or the first loaded city,\nthen resets to Predeterminado del juego after it applies.\nThis is grayed out if a city is already loaded.\nSet this before starting/loading a city. It applies once, then use <Cantidad del atajo de dinero> or <Añadir dinero automáticamente> afterward." },
                { m_Settings.GetOptionLocaleID("GameDefault"), "Predeterminado del juego" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.CustomMilestone)), "Selector de hitos" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.CustomMilestone)), "Enable <before loading or starting a city> to unlock a chosen milestone immediately after the city loads.\n- Cannot be turned ON after a city is loaded, but it can be turned OFF if it was left enabled by mistake.\n- If you forgot and loaded a city, just restart the game, and pick milestone before entering a city.\n- Mod no puede deshacer milestone changes already saved into a city; use an earlier save if needed." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MilestoneLevel)), "Hito" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MilestoneLevel)), "Pick a milestone level to unlock on the next city load.\nThis is <only adjustable outside a loaded city>, and only after [Selector de hitos] is enabled [ ✓ ].\nIf the city is already at or past the milestone selected, then nothing will happen.\nA change only happens if the milestone selected here is higher than what the city has." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ManualMoneyAmount)), "Cantidad del atajo de dinero" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ManualMoneyAmount)), "Use this amount with the Añadir dinero and Restar dinero hotkeys.\n<Predeterminado del mod = 40,000>\nThis does nothing unless you use the hotkey to add/subtract money (en la ciudad).\nFor automated money, enable the Añadir dinero automáticamente option." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AddMoneyKeyboardBinding)), "Añadir dinero" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AddMoneyKeyboardBinding)), "Atajo to <Añadir dinero> inside the city." },
                { m_Settings.GetBindingKeyLocaleID(Setting.AddMoneyAction), "Añadir dinero" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.SubtractMoneyKeyboardBinding)), "Restar dinero" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.SubtractMoneyKeyboardBinding)), "Atajo to <Restar dinero> inside the city." },
                { m_Settings.GetBindingKeyLocaleID(Setting.SubtractMoneyAction), "Restar dinero" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoney)), "Añadir dinero automáticamente" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoney)), "Cuando está activado [ ✓ ], City Watchdog checks the city balance while a city is loaded.\n- If the balance is <below the threshold>, \n  it adds the selected automatic amount.\n- Recommend to use Manual money with hotkey (<[> or <]>) as needed  instead of this automated option, but this is here if you want it." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoneyThreshold)), "Umbral de dinero automático" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoneyThreshold)), "If Añadir dinero automáticamente is enabled and the city balance falls below this value,\nAdd the selected automatic amount." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoneyAmount)), "Cantidad automática" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoneyAmount)), "Amount added each time Añadir dinero automáticamente triggers.\nElige a value high enough to bring the city safely above the threshold." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ConfirmUnlimitedMoneySaveConversion)), "Conversor de dinero ilimitado" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ConfirmUnlimitedMoneySaveConversion)), "<Haz primero una copia de seguridad>.\nConverts a city that started as Dinero ilimitado to a normal city with regular money challenges.\nEnabling this unlocks the <[Convert Dinero ilimitado Save]> button when the loaded city is <Dinero ilimitado> type.\nCity Watchdog no puede deshacer this conversion.\nIf you have normal cities, do not worry about this; it is not needed." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)), "Convertir ciudad con dinero ilimitado a normal" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)), "For cities started with <Dinero ilimitado>.\nWhile that city is loaded, this converts the save to normal limited-money budgeting so the city has regular money challenges again.\nButton is <disabled/greyed-out> unless the loaded city is an <Dinero ilimitado> type\nand <Conversor de dinero ilimitado> is ON [ ✓ ].\nMake a backup save, and use at your own risk; City Watchdog no puede deshacer this conversion." },
                { m_Settings.GetOptionWarningLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)), "Convert this city from Dinero ilimitado to normal limited money?\nSave a backup FIRST; City Watchdog no puede deshacer this.\nAre you sure?" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.NameText)), "Nombre del mod" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.NameText)), "Display name of this mod." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.VersionText)), "Versión" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.VersionText)), "Current mod version." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.OpenParadox)), "Paradox Mods" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.OpenParadox)), "Abrir the author's Paradox Mods page." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.WriteNotificationAuditLog)), "Informe de depuración al registro" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.WriteNotificationAuditLog)), "<Not needed for normal gameplay.>\nFor testers and post game-patch checks: writes a <Logs/CityWatchdog.log> report\ncomparing live game notification prefabs with the notification icons Watchdog currently controls." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.OpenLog)), "Abrir registro" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.OpenLog)), "Abrirs </Logs/CityWatchdog.log> if it exists.\nIf the log file is missing, opens the Logs/ folder instead." },
            };

            return entries;
        }

        public void Unload()
        {
        }
    }
}
