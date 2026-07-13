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
                { m_Settings.GetOptionGroupLocaleID(Setting.MoneyViewGroup), "Visor de info en ciudad" },
                { m_Settings.GetOptionGroupLocaleID(Setting.MiniHudGroup), "Notificaciones del Mini HUD" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Milestone), "AJUSTES DE CIUDAD NUEVA" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Money), "Dinero" },
                { m_Settings.GetOptionGroupLocaleID(Setting.SaveConversion), "Convertir guardado ilimitado" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutInfo), "" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutLinks), "" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutDiagnostics), "DIAGNÓSTICO" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ShowUsage)), "Mostrar instrucciones" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ShowUsage)), "Muestra u oculta las instrucciones de abajo." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.UsageText)), "<Controles de vista>\n" +
                    "1. Botón [i]: oculta/muestra TODOS los tooltips del juego: edificios, cims, herramientas e iconos del menú inferior.\n" +
                    "2. Botón de nombres de calles: oculta/muestra nombres. Atajo: \\.\n" +
                    "3. Botón de distritos: oculta/muestra nombres sin cambiar límites.\n" +
                    "4. Botón de flechas: fuerza flechas de sentido único activadas/desactivadas (también oculta nombres de calles).\n" +
                    "5. Icono CWD de la barra de título: muestra/oculta tooltips del panel de City Watchdog.\n" +
                    "\n" +
                    "<Alertas de notificación>\n" +
                    "1. Pulsa el botón de City Watchdog (arriba izquierda), o Shift+N, para abrir el panel.\n" +
                    "2. Botón de orden: ascendente/descendente.\n" +
                    "3. Alternar todo para apagar/encender rápido, o abre una sección para cambiar iconos concretos.\n" +
                    "4. Solo muestra u oculta iconos; no arregla el problema de la ciudad.\n" +
                    "\n" +
                    "<Ayudas de dinero>\n" +
                    "1. Añadir o restar dinero: usa el <Importe del atajo de dinero>, teclas por defecto [ y ].\n" +
                    "2. Dinero automático añade dinero cuando la ciudad baja del límite que fijes.\n" +
                    "3. Convertir guardado con dinero ilimitado solo sirve para ciudades iniciadas con dinero ilimitado y es <irreversible>.\n" +
                    "\n" +
                    "<Tooltips del menú inferior>\n" +
                    "El visor de dinero añade tendencias de dinero y población a la barra inferior y más detalles al pasar el ratón.\n" +
                    "\n" +
                    "<Hito personalizado>\n" +
                    "Define dinero inicial y elige hitos en Dinero-Hitos > AJUSTES DE CIUDAD NUEVA antes de cargar o iniciar una ciudad." },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.UsageText)), "" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleNotificationsKeyboardBinding)), "Alternar iconos de notificación" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleNotificationsKeyboardBinding)), "<Atajo> para la misma acción que el botón <[Alternar todo]> del juego.\n" +
                    "Muestra u oculta al instante todos los iconos de notificación listados." },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleNotificationsAction), "Mostrar/ocultar al instante todos los iconos" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleNotificationPanelKeyboardBinding)), "Abrir/cerrar panel de notificaciones" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleNotificationPanelKeyboardBinding)), "<Atajo> para abrir o cerrar el\n" +
                    "<panel de notificaciones> en la ciudad.\n" +
                    "Funciona igual que pulsar el icono de arriba izquierda." },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleNotificationPanelAction), "Abrir/cerrar panel de notificaciones" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.PanelButtonsOnlyStart)), "Iniciar panel solo con botones" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.PanelButtonsOnlyStart)), "Si está activo [ ✓ ], City Watchdog se abre desde el botón superior izquierdo en vista pequeña solo con botones.\n" +
                    "Usa la flecha de la barra de título o el botón contador para abrir el panel completo." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleRoadNamesKeyboardBinding)), "Ocultar/mostrar nombres de calles" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleRoadNamesKeyboardBinding)), "<Atajo> para ocultar o mostrar al instante los nombres de calles del juego base.\n" +
                    "Igual que el icono de nombres de calles en City Watchdog." },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleRoadNamesAction), "Ocultar/mostrar nombres de calles" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleAllTooltipsKeyboardBinding)), "Desactivar todos los tooltips del ratón" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleAllTooltipsKeyboardBinding)), "<Atajo> para ocultar o mostrar al instante TODOS los tooltips del juego: edificios, cims, herramientas e iconos del menú inferior.\n" +
                    "<Los popups propios de dinero/población de City Watchdog siguen activos>; se controlan con la opción Visor de dinero.\n" +
                    "Igual que pulsar el icono [i] dentro del panel." },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleAllTooltipsAction), "Ocultar/mostrar todos los tooltips del juego" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyView)), "Mostrar tooltips de dinero + población" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyView)), "<Recomendado>\n" +
                    "Menú inferior: muestra tendencias junto a las <flechas de dinero y población> de la barra.\n" +
                    "Es una función ligera al pasar el ratón, <solo visual>;\n" +
                    "ahorra tiempo y puede rendir mejor que abrir el panel de información del juego." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyViewMode)), "Frecuencia del visor de dinero" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyViewMode)), "Elige si el texto de tendencia inferior usa valores por hora o por mes para dinero y población.\n" +
                    "Mensual usa ingresos menos gastos del presupuesto y una proyección de población de 24 h." },
                { m_Settings.GetOptionLocaleID("MoneyViewModeHourly"), "Por hora (/h)" },
                { m_Settings.GetOptionLocaleID("MoneyViewModeMonthly"), "Mensual (/mes)" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyTooltipMode)), "Estilo del tooltip de dinero" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyTooltipMode)), "Elige cuánto detalle aparece en el tooltip de dinero.\n" +
                    "Compacto = predeterminado en primera instalación.\n" +
                    "<Mini> solo muestra 2 valores netos para /mes y /h.\n" +
                    "<Compacto> acorta valores grandes (15.21M en vez de 15,212,318).\n" +
                    "<Datos completos> muestra valores largos y totales." },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeMini"), "Mini" },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeCompact"), "Compacto" },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeFullData"), "Datos completos" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyTooltipFontScale)), "Tamaño de fuente de dinero" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyTooltipFontScale)), "Ajusta el <tamaño de fuente> de los números del tooltip de dinero.\n" +
                    "Predeterminado del juego = 100%\n" +
                    "<Predeterminado del mod = 120%>\n" +
                    "Pasa el ratón sobre Dinero abajo.\n" +
                    "Pedido por jugadores a quienes les cuesta leer tooltips pequeños." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.PopulationTooltipFontScale)), "Tamaño de fuente de población" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.PopulationTooltipFontScale)), "Ajusta el <tamaño de fuente> de los números del tooltip de población.\n" +
                    "Predeterminado del juego = 100%\n" +
                    "<Predeterminado del mod = 120%>\n" +
                    "Pasa el ratón sobre Población abajo." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudEnabled)), "Mini HUD" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudEnabled)), "Muestra un HUD pequeño con los contadores de notificación más importantes.\n" +
                    "Úsalo como banda rápida de alertas sin abrir todo el panel de City Watchdog.\n" +
                    "Al pulsar un icono salta a un problema coincidente.\n" +
                    "Pulsa el mismo icono para rotar entre puntos y volver al primero." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ApplyMiniHudRecommendedPreset)), "Inicio rápido recomendado" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ApplyMiniHudRecommendedPreset)), "Aplica una configuración recomendada del Mini HUD:\n" +
                    "Favoritos, 5 iconos, horizontal, arriba centro, 100% de tamaño, panel oscuro.\n" +
                    "Las alertas con cero siguen visibles.\n" +
                    "Añade/quita favoritos de **Estrella azul** en el panel expandido cuando quieras.\n" +
                    "El set inicial de favoritos con **Estrella azul** viene con **[Recomendado]**." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudMode)), "Modo Mini HUD" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudMode)), "Elige qué filas de notificación usa el Mini HUD.\n" +
                    "**Activas principales** muestra los conteos actuales más altos.\n" +
                    "**Favoritos** incluye todas las filas con **Estrella azul** en el panel principal.\n" +
                    "Puedes elegir tantos favoritos como quieras,\n" +
                    "pero el Mini HUD solo muestra los 5 o 10 conteos actuales más altos de esa lista de **favoritos estrella azul**." },
                { m_Settings.GetOptionLocaleID("MiniHudModeTopActive"), "Alertas activas principales" },
                { m_Settings.GetOptionLocaleID("MiniHudModeFavorites"), "Favoritos" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudItemCount)), "Cantidad de iconos" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudItemCount)), "Elige cuántos iconos de notificación puede mostrar el Mini HUD a la vez." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudScale)), "Tamaño de iconos" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudScale)), "Escala iconos y números del Mini HUD.\n" +
                    "90% = compacto. 100% = predeterminado. Sube hasta 130% para ver mejor." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudOrientation)), "Orientación" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudOrientation)), "Elige si los iconos del Mini HUD van en fila o columna." },
                { m_Settings.GetOptionLocaleID("MiniHudOrientationHorizontal"), "Horizontal" },
                { m_Settings.GetOptionLocaleID("MiniHudOrientationVertical"), "Vertical" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudPlacement)), "Posición del HUD" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudPlacement)), "Elige dónde aparece el Mini HUD.\n" +
                    "Arrastrable te permite moverlo en la interfaz de ciudad." },
                { m_Settings.GetOptionLocaleID("MiniHudPlacementTopCenter"), "Arriba centro" },
                { m_Settings.GetOptionLocaleID("MiniHudPlacementTopRight"), "Arriba derecha" },
                { m_Settings.GetOptionLocaleID("MiniHudPlacementDraggable"), "Arrastrable" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudPanelStyle)), "Estilo oscuro o cristal" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudPanelStyle)), "Elige el fondo del Mini HUD.\n" +
                    "El panel de cristal va de claro a blanco nublado; no se oscurece.\n" +
                    "Usa panel oscuro para un HUD estilo juego más oscuro." },
                { m_Settings.GetOptionLocaleID("MiniHudPanelStyleDark"), "Panel oscuro" },
                { m_Settings.GetOptionLocaleID("MiniHudPanelStyleGlass"), "Panel cristal" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudPanelOpacity)), "Opacidad del fondo" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudPanelOpacity)), "Ajusta la transparencia del fondo del Mini HUD.\n" +
                    "Menor = más transparente. Mayor = más sólido.\n" +
                    "Cristal se vuelve más blanco/nublado. Oscuro se vuelve más sólido/oscuro." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudHideZero)), "Ocultar alertas cero" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudHideZero)), "Si está activo [ ✓ ], el Mini HUD oculta filas de notificación con conteo 0." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.InitialMoney)), "Dinero inicial" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.InitialMoney)), "Define el saldo inicial de una ciudad nueva con <dinero limitado> o la primera ciudad cargada,\n" +
                    "y luego vuelve a Predeterminado del juego tras aplicarse.\n" +
                    "Aparece en gris si ya hay una ciudad cargada.\n" +
                    "Defínelo antes de iniciar/cargar una ciudad. Se aplica una vez; luego usa <Importe del atajo de dinero> o <Dinero automático>." },
                { m_Settings.GetOptionLocaleID("GameDefault"), "Predeterminado del juego" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.CustomMilestone)), "Selector de hito" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.CustomMilestone)), "Activa <antes de cargar o iniciar una ciudad> para desbloquear el hito elegido al cargar.\n" +
                    "- No puede activarse tras cargar una ciudad, pero puede desactivarse si quedó activo por error.\n" +
                    "- Si lo olvidaste y cargaste una ciudad, reinicia el juego y elige el hito antes de entrar.\n" +
                    "- El mod no puede deshacer cambios de hitos ya guardados; usa un guardado anterior si hace falta." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MilestoneLevel)), "Hito" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MilestoneLevel)), "Elige un nivel de hito para desbloquear en la próxima carga de ciudad.\n" +
                    "Solo se ajusta <fuera de una ciudad cargada> y después de activar [Selector de hito] [ ✓ ].\n" +
                    "Si la ciudad ya está en ese hito o más allá, no pasará nada.\n" +
                    "Solo cambia si el hito elegido es mayor." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ManualMoneyAmount)), "Importe del atajo de dinero" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ManualMoneyAmount)), "Usa este importe con los atajos de Añadir dinero y Restar dinero.\n" +
                    "<Predeterminado del mod = 40,000>\n" +
                    "No hace nada salvo que uses el atajo en la ciudad.\n" +
                    "Para dinero automatizado, activa Dinero automático." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AddMoneyKeyboardBinding)), "Añadir dinero" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AddMoneyKeyboardBinding)), "Atajo para <Añadir dinero> dentro de la ciudad." },
                { m_Settings.GetBindingKeyLocaleID(Setting.AddMoneyAction), "Añadir dinero" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.SubtractMoneyKeyboardBinding)), "Restar dinero" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.SubtractMoneyKeyboardBinding)), "Atajo para <Restar dinero> dentro de la ciudad." },
                { m_Settings.GetBindingKeyLocaleID(Setting.SubtractMoneyAction), "Restar dinero" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoney)), "Dinero automático" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoney)), "Si está activo [ ✓ ], City Watchdog revisa el saldo mientras una ciudad está cargada.\n" +
                    "- Si el saldo está <por debajo del umbral>,\n" +
                    "  añade el importe automático elegido.\n" +
                    "- Se recomienda usar dinero manual con atajo (<[> o <]>) cuando haga falta\n" +
                    "  en vez de esta opción automática, pero está disponible si la quieres." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoneyThreshold)), "Umbral de dinero automático" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoneyThreshold)), "Si Dinero automático está activo y el saldo cae por debajo de este valor,\n" +
                    "se añade el importe automático elegido." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoneyAmount)), "Importe automático" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoneyAmount)), "Importe añadido cada vez que se activa Dinero automático.\n" +
                    "Elige un valor suficiente para subir con seguridad por encima del umbral." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ConfirmUnlimitedMoneySaveConversion)), "Conversor de dinero ilimitado" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ConfirmUnlimitedMoneySaveConversion)), "<Haz primero una copia de seguridad de la ciudad>.\n" +
                    "Convierte una ciudad iniciada con Dinero ilimitado en una ciudad normal con desafíos de dinero.\n" +
                    "Al activarlo desbloquea el botón <[Convertir guardado de dinero ilimitado]> cuando la ciudad cargada es de tipo <Dinero ilimitado>.\n" +
                    "City Watchdog no puede deshacer esta conversión.\n" +
                    "Si tus ciudades son normales, no te preocupes: no lo necesitas." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)), "Convertir ciudad de dinero ilimitado a normal" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)), "Para ciudades iniciadas con <Dinero ilimitado>.\n" +
                    "Mientras esa ciudad está cargada, convierte el guardado a presupuesto normal con dinero limitado.\n" +
                    "El botón está <desactivado/en gris> salvo que la ciudad cargada sea de tipo <Dinero ilimitado>\n" +
                    "y <Conversor de dinero ilimitado> esté ACTIVADO [ ✓ ].\n" +
                    "Haz una copia y úsalo bajo tu responsabilidad; City Watchdog no puede deshacerlo." },
                { m_Settings.GetOptionWarningLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)), "¿Convertir esta ciudad de Dinero ilimitado a dinero limitado normal?\n" +
                    "Guarda una copia PRIMERO; City Watchdog no puede deshacerlo.\n" +
                    "¿Seguro?" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.NameText)), "Nombre del mod" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.NameText)), "Nombre visible de este mod." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.VersionText)), "Versión" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.VersionText)), "Versión actual del mod." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.OpenParadox)), "Paradox Mods" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.OpenParadox)), "Abre la página de Paradox Mods del autor." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.WriteNotificationAuditLog)), "Informe debug al registro" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.WriteNotificationAuditLog)), "<No hace falta para jugar normal.>\n" +
                    "Para testers y revisiones tras parches: escribe un informe en <Logs/CityWatchdog.log>\n" +
                    "comparando las notificaciones reales del juego con los iconos que controla Watchdog." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.OpenLog)), "Abrir registro" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.OpenLog)), "Abre </Logs/CityWatchdog.log> si existe.\n" +
                    "Si falta el archivo, abre la carpeta Logs/." },
            };

            return entries;
        }

        public void Unload()
        {
        }
    }
}
