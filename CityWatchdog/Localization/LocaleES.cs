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
                { m_Settings.GetOptionTabLocaleID(Setting.MoneyTab), "Dinero-Hitos" },
                { m_Settings.GetOptionTabLocaleID(Setting.About), "Acerca de" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutUsage), "USO" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Notifications), "Notificaciones" },
                { m_Settings.GetOptionGroupLocaleID(Setting.MoneyViewGroup), "Info en ciudad" },
                { m_Settings.GetOptionGroupLocaleID(Setting.MiniHudGroup), "Avisos Mini HUD" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Milestone), "AJUSTES DE CIUDAD NUEVA" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Money), "Dinero" },
                { m_Settings.GetOptionGroupLocaleID(Setting.SaveConversion), "Convertir guardado ilimitado" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutInfo), "" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutLinks), "" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutDiagnostics), "DIAGNÓSTICO" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ShowUsage)), "Mostrar instrucciones" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ShowUsage)), "Muestra u oculta las instrucciones de abajo." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.UsageText)),
                    "A. Usa el icono de la pata arriba a la izquierda, o Shift+N, para abrir el panel.\n" +
                    "<Botones de vista>\n" +
                    "1. Icono del título: muestra/oculta tooltips de City Watchdog.\n" +
                    "\n" +
                    "2. Botón **[i]**: oculta/muestra <TODOS> los tooltips del juego: edificios, ciudadanos, herramientas, barra inferior.\n" +
                    "3. Botón carretera: oculta/muestra nombres de calles. Atajo: \\.\n" +
                    "4. Botón distrito: oculta/muestra nombres de distritos.\n" +
                    "5. Botón flechas: fuerza flechas de sentido único on/off (también oculta nombres de calles).\n" +
                    "\n" +
                    "<Alertas>\n" +
                    "1. Ordenar cambia A→Z, Z→A, lista solo activa.\n" +
                    "2. <[0/63]> = iconos ON/total. Clic: expandir/contraer todas las filas.\n" +
                    "3a. [Alternar todo] apaga/enciende todos los iconos de alerta.\n" +
                    "3b. Solo oculta iconos; no arregla el problema de la ciudad.\n" +
                    "\n" +
                    "<Ayuda de dinero>\n" +
                    "1. Añadir / restar dinero: usa las teclas <[ o ]> para <Cantidad del atajo de dinero>.\n" +
                    "2. Dinero automático añade dinero si la ciudad baja del límite elegido.\n" +
                    "3. Convertir guardado con Dinero ilimitado es solo para esas ciudades y es <irreversible>.\n" +
                    "\n" +
                    "<Tooltips del menú inferior>\n" +
                    "Vista de dinero añade detalles como tendencias al pasar el mouse sobre dinero o población.\n" +
                    "\n" +
                    "<Hito personalizado>\n" +
                    "Dinero-Hitos > AJUSTES DE CIUDAD NUEVA fija dinero inicial o hitos antes de cargar/iniciar una ciudad." },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.UsageText)), "" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleNotificationsKeyboardBinding)), "Alternar iconos de alerta" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleNotificationsKeyboardBinding)),
                    "<Atajo> para la misma acción que <[Alternar todo]> en el juego.\n" +
                    "Muestra u oculta al instante todos los iconos de alerta listados." },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleNotificationsAction), "Mostrar/ocultar todos los iconos de alerta" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleNotificationPanelKeyboardBinding)), "Abrir/cerrar panel de alertas" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleNotificationPanelKeyboardBinding)),
                    "<Atajo> para abrir o cerrar el\n" +
                    "<panel de alertas> en la ciudad.\n" +
                    "Igual que pulsar el icono superior izquierdo." },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleNotificationPanelAction), "Abrir/cerrar panel de alertas" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.PanelButtonsOnlyStart)), "Iniciar solo botones" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.PanelButtonsOnlyStart)),
                    "Si está activo [ ✓ ], City Watchdog abre primero la vista pequeña solo con botones.\n" +
                    "Usa la flecha del título o el contador para abrir el panel completo." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleRoadNamesKeyboardBinding)), "Ocultar/mostrar nombres de calles" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleRoadNamesKeyboardBinding)),
                    "<Atajo> para ocultar/mostrar nombres de calles del juego base.\n" +
                    "Igual que el icono de calles en City Watchdog." },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleRoadNamesAction), "Ocultar/mostrar nombres de calles" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleAllTooltipsKeyboardBinding)), "Desactivar todos los tooltips" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleAllTooltipsKeyboardBinding)),
                    "<Atajo> para ocultar/mostrar TODOS los tooltips del juego: edificios, ciudadanos, herramientas e iconos inferiores.\n" +
                    "<Los popups de dinero/población de City Watchdog siguen activos>; los controla Vista de dinero.\n" +
                    "Igual que el icono [i] del panel City Watchdog." },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleAllTooltipsAction), "Ocultar/mostrar tooltips del juego" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyView)), "Tendencias de dinero + población" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyView)),
                    "<Recomendado>\n" +
                    "Menú inferior: muestra tendencias en las flechas de <dinero y población>.\n" +
                    "Función ligera al pasar el mouse <solo visual>;\n" +
                    "ahorra tiempo y puede rendir mejor que abrir el panel de info del juego." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyViewMode)), "Frecuencia de Vista de dinero" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyViewMode)),
                    "Elige valores por hora o por mes en la barra inferior.\n" +
                    "Mensual usa ingresos menos gastos y proyección de población de 24 h." },
                { m_Settings.GetOptionLocaleID("MoneyViewModeHourly"), "Por hora (/h)" },
                { m_Settings.GetOptionLocaleID("MoneyViewModeMonthly"), "Mensual (/mo)" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyTooltipMode)), "Estilo del tooltip de dinero" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyTooltipMode)),
                    "Elige cuánto detalle muestra el tooltip de dinero.\n" +
                    "Compacto = predeterminado al instalar.\n" +
                    "<Mini> muestra solo 2 valores netos para /mo y /h.\n" +
                    "<Compacto> acorta números grandes (15.21M en vez de 15,212,318).\n" +
                    "<Datos completos> muestra valores largos y totales." },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeMini"), "Mini" },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeCompact"), "Compacto" },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeFullData"), "Datos completos" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyTooltipFontScale)), "Tamaño de fuente de dinero" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyTooltipFontScale)),
                    "Ajusta el <tamaño de fuente> de los números de Vista de dinero.\n" +
                    "Predeterminado del juego = 100%\n" +
                    "<Predeterminado del mod = 120%>\n" +
                    "Pasa el mouse sobre Dinero abajo.\n" +
                    "Para jugadores que ven pequeños los tooltips." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.PopulationTooltipFontScale)), "Tamaño de fuente de población" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.PopulationTooltipFontScale)),
                    "Ajusta el <tamaño de fuente> de los números de población.\n" +
                    "Predeterminado del juego = 100%\n" +
                    "<Predeterminado del mod = 120%>\n" +
                    "Pasa el mouse sobre Población abajo." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudEnabled)), "Mini HUD" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudEnabled)),
                    "Muestra un HUD pequeño con los contadores de alerta importantes.\n" +
                    "Úsalo como barra rápida sin abrir el panel completo.\n" +
                    "Clic en un icono salta a un problema.\n" +
                    "Más clics rotan por coincidencias y vuelven al primero." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ApplyMiniHudRecommendedPreset)), "Clic: inicio rápido" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ApplyMiniHudRecommendedPreset)),
                    "Aplica un <inicio rápido> para Mini HUD:\n" +
                    "Favoritos, 5 iconos, vertical, arrastrable, tamaño 100%, panel oscuro.\n" +
                    "Las alertas con 0 se ocultan.\n" +
                    "Incluye un **grupo inicial de favoritos con estrella azul**.\n" +
                    "Añade/quita favoritos de **estrella azul** en el panel Watchdog expandido." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudMode)), "Modo Mini HUD" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudMode)),
                    "Elige qué filas usa el Mini HUD.\n" +
                    "**Top activas** muestra los contadores actuales más altos.\n" +
                    "**Favoritos** usa filas con **estrella azul** en el panel principal.\n" +
                    "Puedes elegir tantos favoritos como quieras,\n" +
                    "pero Mini HUD solo muestra el top 5 o top 10." },
                { m_Settings.GetOptionLocaleID("MiniHudModeTopActive"), "Top alertas activas" },
                { m_Settings.GetOptionLocaleID("MiniHudModeFavorites"), "Favoritos" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudItemCount)), "Cantidad de iconos" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudItemCount)), "Elige cuántos iconos puede mostrar el Mini HUD." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudScale)), "Tamaño de icono" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudScale)),
                    "Escala iconos y números del Mini HUD.\n" +
                    "90% = compacto. 100% = normal. Hasta 130% para ver mejor." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudOrientation)), "Orientación" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudOrientation)), "Elige fila o columna." },
                { m_Settings.GetOptionLocaleID("MiniHudOrientationHorizontal"), "Horizontal" },
                { m_Settings.GetOptionLocaleID("MiniHudOrientationVertical"), "Vertical" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudPlacement)), "Posición del HUD" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudPlacement)),
                    "Elige dónde aparece el Mini HUD.\n" +
                    "Arrastrable permite moverlo en la interfaz de la ciudad." },
                { m_Settings.GetOptionLocaleID("MiniHudPlacementTopCenter"), "Arriba centro" },
                { m_Settings.GetOptionLocaleID("MiniHudPlacementTopRight"), "Arriba derecha" },
                { m_Settings.GetOptionLocaleID("MiniHudPlacementDraggable"), "Arrastrable" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudPanelStyle)), "Estilo oscuro o cristal" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudPanelStyle)),
                    "Elige el fondo del Mini HUD.\n" +
                    "Cristal va de claro a blanco nublado; no se oscurece.\n" +
                    "Usa Oscuro para un HUD más oscuro estilo juego." },
                { m_Settings.GetOptionLocaleID("MiniHudPanelStyleDark"), "Panel oscuro" },
                { m_Settings.GetOptionLocaleID("MiniHudPanelStyleGlass"), "Panel cristal" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudPanelOpacity)), "Opacidad del fondo" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudPanelOpacity)),
                    "Ajusta la transparencia del fondo del Mini HUD.\n" +
                    "Menor = más transparente. Mayor = más sólido.\n" +
                    "Cristal se vuelve más blanco. Oscuro más sólido/oscuro." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudHideZero)), "Ocultar alertas 0" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudHideZero)), "Si está activo [ ✓ ], Mini HUD oculta filas con contador 0." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.InitialMoney)), "Dinero inicial" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.InitialMoney)),
                    "Define el saldo inicial de una ciudad nueva con <dinero limitado> o la primera ciudad cargada,\n" +
                    "luego vuelve al valor del juego.\n" +
                    "Se desactiva si ya hay una ciudad cargada.\n" +
                    "Ponlo antes de cargar/iniciar. Luego usa <Cantidad del atajo de dinero> o <Dinero automático>." },
                { m_Settings.GetOptionLocaleID("GameDefault"), "Valor del juego" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.CustomMilestone)), "Selector de hito" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.CustomMilestone)),
                    "Actívalo <antes de cargar o iniciar> para desbloquear un hito al cargar.\n" +
                    "- No puede activarse con ciudad cargada, pero sí apagarse.\n" +
                    "- Si lo olvidaste, reinicia el juego y elige antes de entrar.\n" +
                    "- El mod no deshace hitos ya guardados; usa un guardado anterior." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MilestoneLevel)), "Hito" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MilestoneLevel)),
                    "Elige el hito para el próximo cargado.\n" +
                    "Solo ajustable <fuera de una ciudad cargada> y con [Selector de hito] activo [ ✓ ].\n" +
                    "Si la ciudad ya está en ese hito o más, no pasa nada.\n" +
                    "Solo cambia si el hito elegido es mayor." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ManualMoneyAmount)), "Cantidad del atajo de dinero" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ManualMoneyAmount)),
                    "Usa esta cantidad con los atajos Añadir y Restar dinero.\n" +
                    "<Predeterminado del mod = 40,000>\n" +
                    "No hace nada sin usar el atajo en la ciudad.\n" +
                    "Para automatizar, activa Dinero automático." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AddMoneyKeyboardBinding)), "Añadir dinero" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AddMoneyKeyboardBinding)), "Atajo para <Añadir dinero> en la ciudad." },
                { m_Settings.GetBindingKeyLocaleID(Setting.AddMoneyAction), "Añadir dinero" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.SubtractMoneyKeyboardBinding)), "Restar dinero" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.SubtractMoneyKeyboardBinding)), "Atajo para <Restar dinero> en la ciudad." },
                { m_Settings.GetBindingKeyLocaleID(Setting.SubtractMoneyAction), "Restar dinero" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoney)), "Dinero automático" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoney)),
                    "Si está activo [ ✓ ], City Watchdog revisa el saldo de la ciudad.\n" +
                    "- Si el saldo está <bajo el límite>,\n" +
                    "  añade la cantidad elegida.\n" +
                    "- Mejor usar dinero manual con atajo (<[> o <]>) cuando haga falta\n" +
                    "  en vez de automatizar; la opción está por si la quieres." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoneyThreshold)), "Límite de dinero automático" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoneyThreshold)),
                    "Si está activo y el saldo cae bajo este valor,\n" +
                    "añade la cantidad elegida." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoneyAmount)), "Cantidad automática" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoneyAmount)),
                    "Cantidad añadida cada vez que se activa.\n" +
                    "Elige suficiente para quedar sobre el límite." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ConfirmUnlimitedMoneySaveConversion)), "Conversor de dinero ilimitado" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ConfirmUnlimitedMoneySaveConversion)),
                    "<Haz copia de seguridad PRIMERO>.\n" +
                    "Convierte una ciudad iniciada con Dinero ilimitado en una ciudad normal.\n" +
                    "Al activarlo desbloquea <[Convertir guardado con Dinero ilimitado]> si la ciudad cargada es de <Dinero ilimitado>.\n" +
                    "City Watchdog no puede deshacerlo.\n" +
                    "Si tus ciudades son normales, no lo necesitas." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)), "Convertir ciudad con Dinero ilimitado a normal" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)),
                    "Para ciudades iniciadas con <Dinero ilimitado>.\n" +
                    "Con la ciudad cargada, convierte el guardado a presupuesto normal limitado.\n" +
                    "El botón está <desactivado/gris> salvo que la ciudad sea de <Dinero ilimitado>\n" +
                    "y <Conversor de dinero ilimitado> esté ON [ ✓ ].\n" +
                    "Haz copia y úsalo bajo tu riesgo; City Watchdog no deshace esto." },
                { m_Settings.GetOptionWarningLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)),
                    "¿Convertir esta ciudad de Dinero ilimitado a dinero limitado normal?\n" +
                    "Guarda copia PRIMERO; City Watchdog no puede deshacerlo.\n" +
                    "¿Seguro?" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.NameText)), "Nombre del mod" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.NameText)), "Nombre visible de este mod." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.VersionText)), "Versión" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.VersionText)), "Versión actual del mod." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.OpenParadox)), "Paradox Mods" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.OpenParadox)), "Abre la página Paradox Mods del autor." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.WriteNotificationAuditLog)), "Informe debug al log" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.WriteNotificationAuditLog)),
                    "<No hace falta para jugar normal.>\n" +
                    "Para testers y parches: escribe un informe en <Logs/CityWatchdog.log>\n" +
                    "comparando alertas del juego con los iconos que controla Watchdog." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.OpenLog)), "Abrir log" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.OpenLog)),
                    "Abre </Logs/CityWatchdog.log> si existe.\n" +
                    "Si falta, abre la carpeta Logs/." },
            };

            return entries;
        }

        public void Unload()
        {
        }
    }
}
