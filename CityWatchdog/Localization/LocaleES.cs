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
                // --- Mod title ---
                { m_Settings.GetSettingsLocaleID(), title },

                // --- Tabs ---
                { m_Settings.GetOptionTabLocaleID(Setting.Actions), "Acciones" },
                { m_Settings.GetOptionTabLocaleID(Setting.MoneyTab), "Dinero e hitos" },
                { m_Settings.GetOptionTabLocaleID(Setting.About), "Acerca de" },

                // --- Groups, ordered by Options menu location ---
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutUsage), "USO" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Notifications), "Notificaciones" },
                { m_Settings.GetOptionGroupLocaleID(Setting.MoneyViewGroup), "Visor de información en ciudad" },
                { m_Settings.GetOptionGroupLocaleID(Setting.MiniHudGroup), "Notificaciones Mini HUD" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Milestone), "AJUSTES DE INICIO DE NUEVA CIUDAD" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Money), "Dinero" },
                { m_Settings.GetOptionGroupLocaleID(Setting.SaveConversion), "Convertir guardado ilimitado" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutInfo), "" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutLinks), "" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutDiagnostics), "DIAGNÓSTICO" },

                // --------------------------------------------------------------------
                // Actions tab - Usage
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ShowUsage)), "Mostrar instrucciones" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ShowUsage)), "Muestra u oculta las instrucciones de abajo." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.UsageText)), "<Controles de pantalla>\n" +
                    "1. Botón [i]: ocultar/mostrar TODOS los tooltips del juego: edificios, cims, herramientas e iconos inferiores.\n" +
                    "2. Nombres de carreteras: ocultar/mostrar nombres de carreteras. Atajo: \\.\n" +
                    "3. Nombres de distrito: ocultar/mostrar nombres de distrito sin cambiar sus límites.\n" +
                    "4. Flechas de carretera: fuerza flechas de sentido único (también oculta nombres de carreteras).\n" +
                    "5. Icono de la barra CWD: muestra/oculta tooltips del panel City Watchdog.\n" +
                    "\n" +
                    "<Alertas de notificación>\n" +
                    "1. Pulsa el botón City Watchdog arriba a la izquierda, o Shift+N, para abrir el panel.\n" +
                    "2. Botón de orden ascendente/descendente.\n" +
                    "3. Toggle All activa/desactiva todo rápido, o abre una sección para cambiar iconos concretos.\n" +
                    "4. Solo oculta iconos; no arregla el problema de la ciudad.\n" +
                    "\n" +
                    "<Ayudas de dinero>\n" +
                    "1. Añadir o restar dinero: usa <Cantidad del atajo de dinero> con las teclas [ y ].\n" +
                    "2. El dinero automático añade dinero si la ciudad baja del límite elegido.\n" +
                    "3. Convertir guardados de Dinero ilimitado solo sirve para ciudades creadas con Dinero ilimitado y <no se puede deshacer>.\n" +
                    "\n" +
                    "<Tooltips del menú inferior>\n" +
                    "Money View añade tendencias a dinero y población en la barra y más detalles al pasar el ratón.\n" +
                    "\n" +
                    "<Hito personalizado>\n" +
                    "Configura Dinero inicial e hitos en Dinero e hitos > AJUSTES DE INICIO DE NUEVA CIUDAD antes de cargar o empezar una ciudad." },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.UsageText)), "" },

                // --------------------------------------------------------------------
                // Actions tab - Notifications
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleNotificationsKeyboardBinding)), "Mostrar/ocultar iconos de notificación" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleNotificationsKeyboardBinding)), "<Atajo> para la misma acción que el botón <[TOGGLE ALL]> del juego.\n" +
                    "Muestra u oculta al instante todos los iconos listados." },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleNotificationsAction), "Mostrar/Ocultar todos los iconos de notificación" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleNotificationPanelKeyboardBinding)), "Abrir/cerrar panel de notificaciones" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleNotificationPanelKeyboardBinding)), "<Atajo> para abrir o cerrar el\n" +
                    "<panel de notificaciones> en la ciudad.\n" +
                    "Funciona igual que el icono de arriba a la izquierda." },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleNotificationPanelAction), "Abrir/Cerrar panel de notificaciones" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleRoadNamesKeyboardBinding)), "Ocultar/mostrar nombres de carreteras" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleRoadNamesKeyboardBinding)), "<Atajo> para ocultar o mostrar al instante los nombres de carreteras del juego.\n" +
                    "Igual que el icono de nombres en la barra del panel City Watchdog." },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleRoadNamesAction), "Ocultar/Mostrar nombres de carreteras" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleAllTooltipsKeyboardBinding)), "Desactivar todos los tooltips al pasar el ratón" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleAllTooltipsKeyboardBinding)), "<Atajo> para ocultar o mostrar TODOS los tooltips del juego: edificios, ciudadanos, herramientas e iconos inferiores.\n" +
                    "<Los popups de dinero/población de City Watchdog siguen activos>; se controlan con Money View.\n" +
                    "Igual que el icono [i] del panel City Watchdog." },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleAllTooltipsAction), "Ocultar/Mostrar todos los tooltips del juego" },

                // --------------------------------------------------------------------
                // Actions tab - In-City Info Viewer
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyView)), "Mostrar ToolTips de dinero + población" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyView)), "<Recomendado>\n" +
                    "Menú inferior: muestra valores de tendencia junto a las flechas de dinero y población.\n" +
                    "Función ligera de hover <solo visual>;\n" +
                    "ahorra tiempo y puede rendir mejor que abrir el panel de información del juego." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyViewMode)), "Frecuencia de Money View" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyViewMode)), "Elige si las tendencias muestran valores por hora o por mes para dinero y población.\n" +
                    "Mensual usa ingresos menos gastos del presupuesto y una proyección de población de 24 horas." },
                { m_Settings.GetOptionLocaleID("MoneyViewModeHourly"), "Por hora (/h)" },
                { m_Settings.GetOptionLocaleID("MoneyViewModeMonthly"), "Mensual (/mo)" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyTooltipMode)), "Estilo del tooltip de dinero" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyTooltipMode)), "Elige cuánto detalle aparece en el tooltip de dinero.\n" +
                    "Compact = valor por defecto al instalar.\n" +
                    "<Mini> muestra solo 2 valores netos para /mo y /h.\n" +
                    "<Compact> acorta números grandes (15.21M en vez de 15,212,318).\n" +
                    "<Full data> muestra valores largos y totales." },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeMini"), "Mini" },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeCompact"), "Compacto" },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeFullData"), "Datos completos" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyTooltipFontScale)), "Tamaño de fuente de dinero" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyTooltipFontScale)), "Ajusta el <tamaño de fuente> de los números de Money View.\n" +
                    "Juego = 100%\n" +
                    "<Mod = 120%>\n" +
                    "Pasa el ratón sobre Dinero abajo.\n" +
                    "Pedido por jugadores que no ven bien tooltips pequeños." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.PopulationTooltipFontScale)), "Tamaño de fuente de población" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.PopulationTooltipFontScale)), "Ajusta el <tamaño de fuente> de los números de población.\n" +
                    "Juego = 100%\n" +
                    "<Mod = 120%>\n" +
                    "Pasa el ratón sobre Población abajo." },

                // --------------------------------------------------------------------
                // Actions tab - Mini HUD Notifications
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudEnabled)), "Notificaciones Mini HUD" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudEnabled)), "Muestra un pequeño HUD en la ciudad con los recuentos de notificación más importantes.\n" +
                    "Úsalo como una barra rápida de alertas sin abrir el panel completo de City Watchdog." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudMode)), "Modo Mini HUD" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudMode)), "Elige qué filas de notificación usa el Mini HUD.\n" +
                    "Alertas principales muestra los recuentos actuales más altos.\n" +
                    "Favoritos muestra solo las filas marcadas como favoritas en el panel City Watchdog." },
                { m_Settings.GetOptionLocaleID("MiniHudModeTopActive"), "Alertas principales" },
                { m_Settings.GetOptionLocaleID("MiniHudModeFavorites"), "Favoritos" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudItemCount)), "Número de iconos Mini HUD" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudItemCount)), "Elige cuántos iconos de notificación puede mostrar el Mini HUD a la vez." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudOrientation)), "Orientación Mini HUD" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudOrientation)), "Elige si los iconos del Mini HUD se colocan en fila o en columna." },
                { m_Settings.GetOptionLocaleID("MiniHudOrientationHorizontal"), "Horizontal" },
                { m_Settings.GetOptionLocaleID("MiniHudOrientationVertical"), "Vertical" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudPlacement)), "Ubicación Mini HUD" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudPlacement)), "Elige dónde aparece el Mini HUD.\n" +
                    "Draggable permite moverlo en la interfaz de la ciudad." },
                { m_Settings.GetOptionLocaleID("MiniHudPlacementTopCenter"), "Arriba centro" },
                { m_Settings.GetOptionLocaleID("MiniHudPlacementTopRight"), "Arriba derecha" },
                { m_Settings.GetOptionLocaleID("MiniHudPlacementDraggable"), "Arrastrable" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudHideZero)), "Ocultar alertas en cero" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudHideZero)), "Cuando está activado [ ✓ ], el Mini HUD oculta filas de notificación con recuento 0." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudGlassStyle)), "Estilo cristal" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudGlassStyle)), "Añade un fondo suave tipo cristal detrás del Mini HUD para mejorar la lectura." },

                // --------------------------------------------------------------------
                // Money-Milestones tab - New City Start Settings
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.InitialMoney)), "Dinero inicial" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.InitialMoney)), "Define el saldo inicial de una ciudad nueva con <dinero limitado>, o de la primera ciudad cargada,\n" +
                    "y luego vuelve a Game Default tras aplicarse.\n" +
                    "Se desactiva si ya hay una ciudad cargada.\n" +
                    "Configúralo antes de iniciar/cargar una ciudad. Después usa <Cantidad de atajo de dinero> o <Dinero automático>." },
                { m_Settings.GetOptionLocaleID("GameDefault"), "Valor del juego" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.CustomMilestone)), "Selector de milestone" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.CustomMilestone)), "Actívalo <antes de cargar o empezar una ciudad> para desbloquear el milestone elegido al cargar.\n" +
                    "No se puede activar con una ciudad cargada, pero sí desactivar si quedó activo por error.\n" +
                    "Si lo olvidaste, reinicia el juego y elige el milestone antes de entrar en una ciudad.\n" +
                    "City Watchdog no puede deshacer milestones ya guardados; usa una partida anterior si hace falta." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MilestoneLevel)), "Milestone" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MilestoneLevel)), "Elige el milestone que se desbloqueará al cargar la próxima ciudad.\n" +
                    "Solo se ajusta fuera de una ciudad cargada y tras activar [Selector de milestone] [ ✓ ]." },

                // --------------------------------------------------------------------
                // Money-Milestones tab - Money
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ManualMoneyAmount)), "Cantidad del atajo de dinero" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ManualMoneyAmount)), "Usa esta cantidad con los atajos Añadir dinero y Restar dinero.\n" +
                    "<Mod = 40,000>\n" +
                    "No hace nada salvo que uses el atajo dentro de la ciudad.\n" +
                    "Para dinero automático, activa Dinero automático." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AddMoneyKeyboardBinding)), "Añadir dinero" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AddMoneyKeyboardBinding)), "Atajo para <Añadir dinero> dentro de la ciudad." },
                { m_Settings.GetBindingKeyLocaleID(Setting.AddMoneyAction), "Añadir dinero" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.SubtractMoneyKeyboardBinding)), "Restar dinero" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.SubtractMoneyKeyboardBinding)), "Atajo para <Restar dinero> dentro de la ciudad." },
                { m_Settings.GetBindingKeyLocaleID(Setting.SubtractMoneyAction), "Restar dinero" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoney)), "Añadir dinero automáticamente" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoney)), "Cuando está activado [ ✓ ], City Watchdog revisa el saldo mientras hay una ciudad cargada.\n" +
                    "- Si el saldo está <por debajo del umbral>,\n" +
                    "  añade la cantidad automática elegida.\n" +
                    "- Se recomienda usar dinero manual con las teclas (<[> o <]>) cuando haga falta, pero esta opción está disponible." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoneyThreshold)), "Umbral de dinero automático" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoneyThreshold)), "Si el dinero automático está activado y el saldo baja de este valor,\n" +
                    "añade la cantidad automática elegida." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoneyAmount)), "Cantidad automática de dinero" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoneyAmount)), "Cantidad añadida cada vez que se activa el dinero automático.\n" +
                    "Elige un valor suficiente para quedar por encima del umbral." },

                // --------------------------------------------------------------------
                // Money-Milestones tab - Save Conversion
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ConfirmUnlimitedMoneySaveConversion)), "Convertidor de Dinero ilimitado" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ConfirmUnlimitedMoneySaveConversion)), "<Haz primero una copia de seguridad de la ciudad>.\n" +
                    "Convierte una ciudad iniciada con Dinero ilimitado a una ciudad normal con presupuesto regular.\n" +
                    "Activarlo desbloquea el botón <[Convertir partida de Dinero ilimitado]> si la ciudad cargada es de tipo <Dinero ilimitado>.\n" +
                    "City Watchdog no puede deshacer esta conversión.\n" +
                    "Si tus ciudades son normales, no necesitas esto." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)), "Convertir ciudad de Dinero ilimitado a normal" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)), "Para ciudades creadas con <Dinero ilimitado>.\n" +
                    "Con esa ciudad cargada, convierte la partida a presupuesto limitado normal.\n" +
                    "El botón está <desactivado/gris> salvo que la ciudad cargada sea de tipo <Dinero ilimitado>\n" +
                    "y <Convertidor de Dinero ilimitado> esté ON [ ✓ ].\n" +
                    "Haz copia de seguridad y úsalo bajo tu responsabilidad; City Watchdog no puede deshacerlo." },

                { m_Settings.GetOptionWarningLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)), "¿Convertir esta ciudad de Dinero ilimitado a dinero limitado normal?\n" +
                    "Haz una copia PRIMERO; City Watchdog no puede deshacerlo.\n" +
                    "¿Seguro?" },

                // --------------------------------------------------------------------
                // About tab
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.NameText)), "Nombre del mod" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.NameText)), "Nombre mostrado de este mod." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.VersionText)), "Versión" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.VersionText)), "Versión actual del mod." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.OpenParadox)), "Paradox Mods" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.OpenParadox)), "Abre la página de Paradox Mods del autor." },

                // --------------------------------------------------------------------
                // About tab - Diagnostics
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.WriteNotificationAuditLog)), "Informe debug al log" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.WriteNotificationAuditLog)), "<No es necesario para jugar normalmente.>\n" +
                    "Para pruebas y revisiones tras parches: escribe un informe en <Logs/CityWatchdog.log>\n" +
                    "comparando las notificaciones reales del juego con los iconos controlados por Watchdog." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.OpenLog)), "Abrir log" },
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
