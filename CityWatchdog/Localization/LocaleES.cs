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
                { m_Settings.GetOptionTabLocaleID(Setting.MiniHudTab), "Mini-HUD" },
                { m_Settings.GetOptionTabLocaleID(Setting.MoneyTab), "Dinero-Hitos" },
                { m_Settings.GetOptionTabLocaleID(Setting.About), "Acerca de" },

                // --- Groups, ordered by Options menu location ---
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutUsage), "USO" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Notifications), "Notificaciones" },
                { m_Settings.GetOptionGroupLocaleID(Setting.MoneyViewGroup), "Visor de info en ciudad" },
                { m_Settings.GetOptionGroupLocaleID(Setting.MiniHudGroup), "Notificaciones Mini HUD" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Milestone), "AJUSTES DE NUEVA CIUDAD" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Money), "Dinero" },
                { m_Settings.GetOptionGroupLocaleID(Setting.SaveConversion), "Convertir guardado ilimitado" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutInfo), "" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutLinks), "" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutDiagnostics), "DIAGNÓSTICO" },

                // --------------------------------------------------------------------
                // Actions tab - Usage
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ShowUsage)), "Mostrar instrucciones" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ShowUsage)), "Muestra u oculta las instrucciones de uso." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.UsageText)),
                    "<Controles de pantalla>\n" +
                    "1. Botón [i]: muestra/oculta TODOS los tooltips del juego.\n" +
                    "2. Botón Nombres de calles: muestra/oculta nombres. Atajo: \\.\n" +
                    "3. Botón Distritos: muestra/oculta nombres sin cambiar límites.\n" +
                    "4. Botón Flechas: fuerza flechas de sentido único (también oculta nombres).\n" +
                    "5. Icono CWD: muestra/oculta tooltips del panel City Watchdog.\n\n" +
                    "<Alertas>\n" +
                    "1. Pulsa City Watchdog arriba a la izquierda, o Shift+N, para abrir el panel.\n" +
                    "2. Botón de orden: ascendente/descendente.\n" +
                    "3. Toggle All activa/desactiva todo, o abre una sección para elegir.\n" +
                    "4. Solo oculta iconos; no arregla el problema de la ciudad.\n\n" +
                    "<Ayuda de dinero>\n" +
                    "1. Añadir o restar dinero: usa las teclas [ y ].\n" +
                    "2. Dinero automático añade dinero bajo el límite elegido.\n" +
                    "3. Convertir guardado con dinero ilimitado es solo para esas ciudades y es <irreversible>.\n\n" +
                    "<Tooltips del menú inferior>\n" +
                    "Money View añade tendencias de dinero/población y detalles al pasar el ratón.\n\n" +
                    "<Hito personalizado>\n" +
                    "Configura dinero inicial e hitos antes de cargar o crear una ciudad."
                },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.UsageText)), "" },

                // --------------------------------------------------------------------
                // Actions tab - Notifications
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleNotificationsKeyboardBinding)), "Alternar iconos de alerta" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleNotificationsKeyboardBinding)),
                    "<Atajo> para la misma acción que el botón <[TOGGLE ALL]> del juego.\n" +
                    "Muestra u oculta al instante todos los iconos listados." },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleNotificationsAction), "Mostrar/ocultar todos los iconos de alerta" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleNotificationPanelKeyboardBinding)), "Abrir/cerrar panel de alertas" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleNotificationPanelKeyboardBinding)),
                    "<Atajo> para abrir o cerrar el\n" +
                    "<panel de alertas> en la ciudad.\n" +
                    "Igual que pulsar el icono superior izquierdo."
                },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleNotificationPanelAction), "Abrir/cerrar panel de alertas" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.PanelButtonsOnlyStart)), "Inicio solo con botones" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.PanelButtonsOnlyStart)),
                    "Si está activado [ ✓ ], City Watchdog se abre en vista pequeña de solo botones.\n" +
                    "Usa la flecha del título o el botón contador para abrir el panel completo." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleRoadNamesKeyboardBinding)), "Ocultar/mostrar nombres de calles" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleRoadNamesKeyboardBinding)),
                    "<Atajo> para ocultar/mostrar nombres de calles vanilla.\n" +
                    "Igual que el icono de nombres de calle en City Watchdog." },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleRoadNamesAction), "Ocultar/mostrar nombres de calles" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleAllTooltipsKeyboardBinding)), "Desactivar todos los tooltips al pasar el ratón" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleAllTooltipsKeyboardBinding)),
                    "<Atajo> para ocultar/mostrar TODOS los tooltips del juego.\n" +
                    "<Los popups de dinero/población de City Watchdog siguen activos>; se controlan con Money View.\n" +
                    "Igual que pulsar el icono [i] dentro del panel." },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleAllTooltipsAction), "Ocultar/mostrar tooltips del juego" },

                // --------------------------------------------------------------------
                // Actions tab - In-City Info Viewer
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyView)), "Mostrar tooltips de dinero + población" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyView)),
                    "<Recomendado>\n" +
                    "Menú inferior: muestra tendencias en las flechas de dinero y población.\n" +
                    "Función ligera al pasar el ratón <solo visual>;\n" +
                    "Ahorra abrir el panel de info del juego."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyViewMode)), "Frecuencia de Money View" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyViewMode)),
                    "Elige si las tendencias del menú inferior son por hora o por mes.\n" +
                    "Mensual usa ingresos menos gastos y proyección de población de 24 h." },
                { m_Settings.GetOptionLocaleID("MoneyViewModeHourly"), "Por hora (/h)" },
                { m_Settings.GetOptionLocaleID("MoneyViewModeMonthly"), "Mensual (/mes)" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyTooltipMode)), "Estilo tooltip de dinero" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyTooltipMode)),
                    "Elige cuánto detalle muestra el tooltip de dinero.\n" +
                    "Compacto = valor inicial.\n" +
                    "<Mini> muestra solo 2 valores netos /mes y /h.\n" +
                    "<Compacto> acorta números grandes (15.21M en vez de 15,212,318).\n" +
                    "<Datos completos> muestra valores largos y totales." },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeMini"), "Mini" },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeCompact"), "Compacto" },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeFullData"), "Datos completos" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyTooltipFontScale)), "Tamaño fuente dinero" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyTooltipFontScale)),
                    "Ajusta el <tamaño de fuente> de los números de Money View.\n" +
                    "Valor del juego = 100%\n" +
                    "<Valor del mod = 120%>\n" +
                    "Pasa el ratón sobre Dinero abajo.\n" +
                    "Para jugadores que ven pequeños los tooltips."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.PopulationTooltipFontScale)), "Tamaño fuente población" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.PopulationTooltipFontScale)),
                    "Ajusta el <tamaño> de los números de población.\n" +
                    "Valor del juego = 100%\n" +
                    "<Valor del mod = 120%>\n" +
                    "Pasa el ratón sobre Población abajo."
                },

                // --------------------------------------------------------------------
                // Mini-HUD tab - Mini HUD Notifications
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudEnabled)), "Mini HUD" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudEnabled)),
                    "Muestra un HUD pequeño con los conteos importantes.\n" +
                    "Úsalo como tira rápida sin abrir el panel completo.\n" +
                    "Pulsar un icono salta a un problema correspondiente.\n" +
                    "Vuelve a pulsar para rotar por otros puntos y volver al primero."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ApplyMiniHudRecommendedPreset)), "Ajuste recomendado" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ApplyMiniHudRecommendedPreset)),
                    "Aplica una configuración recomendada del Mini HUD:\n" +
                    "Favoritos, 5 iconos, horizontal, centro superior, 100%, panel oscuro.\n" +
                    "Las alertas con cero siguen visibles.\n" +
                    "Añade/quita favoritos **Estrella azul** en el panel completo.\n" +
                    "Los favoritos iniciales **Estrella azul** vienen con **[Recomendado]**."
                  },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudMode)), "Modo Mini HUD" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudMode)),
                    "Elige qué filas usa el Mini HUD.\n" +
                    "**Alertas activas** muestra los conteos más altos.\n" +
                    "**Favoritos** incluye filas con **Estrella azul**.\n" +
                    "Puedes elegir tantos favoritos como quieras,\n" +
                    "pero Mini HUD muestra solo los 5 o 10 conteos más altos de esa lista." },
                { m_Settings.GetOptionLocaleID("MiniHudModeTopActive"), "Alertas activas" },
                { m_Settings.GetOptionLocaleID("MiniHudModeFavorites"), "Favoritos" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudItemCount)), "Cantidad de iconos Mini HUD" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudItemCount)),
                    "Elige cuántos iconos puede mostrar el Mini HUD." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudScale)), "Tamaño Mini HUD" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudScale)),
                    "Escala iconos y números del Mini HUD.\n" +
                    "90% = compacto. 100% = normal. Hasta 130% para ver mejor." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudOrientation)), "Orientación Mini HUD" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudOrientation)),
                    "Elige fila o columna." },
                { m_Settings.GetOptionLocaleID("MiniHudOrientationHorizontal"), "Horizontal" },
                { m_Settings.GetOptionLocaleID("MiniHudOrientationVertical"), "Vertical" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudPlacement)), "Posición Mini HUD" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudPlacement)),
                    "Elige dónde aparece el Mini HUD.\n" +
                    "Arrastrable permite moverlo en la interfaz." },
                { m_Settings.GetOptionLocaleID("MiniHudPlacementTopCenter"), "Centro superior" },
                { m_Settings.GetOptionLocaleID("MiniHudPlacementTopRight"), "Arriba derecha" },
                { m_Settings.GetOptionLocaleID("MiniHudPlacementDraggable"), "Arrastrable" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudPanelStyle)), "Estilo Mini HUD" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudPanelStyle)),
                    "Elige el fondo del Mini HUD.\n" +
                    "Cristal va de claro a blanco nublado; no se oscurece.\n" +
                    "Usa panel oscuro para un HUD estilo vanilla más oscuro." },
                { m_Settings.GetOptionLocaleID("MiniHudPanelStyleDark"), "Panel oscuro" },
                { m_Settings.GetOptionLocaleID("MiniHudPanelStyleGlass"), "Panel cristal" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudPanelOpacity)), "Opacidad Mini HUD" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudPanelOpacity)),
                    "Ajusta la transparencia del fondo.\n" +
                    "Más bajo = más transparente. Más alto = más sólido.\n" +
                    "Cristal se vuelve más blanco; oscuro se vuelve más sólido." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudHideZero)), "Ocultar alertas en cero" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudHideZero)),
                    "Si está activado [ ✓ ], oculta filas con conteo 0." },

                // --------------------------------------------------------------------
                // Money-Milestones tab - New City Start Settings
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.InitialMoney)), "Dinero inicial" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.InitialMoney)),
                    "Define el saldo inicial para una nueva ciudad con <dinero limitado>,\n" +
                    "y luego vuelve al valor del juego.\n" +
                    "Se desactiva si ya hay una ciudad cargada.\n" +
                    "Configúralo antes de cargar/crear ciudad. Luego usa <Monto de atajo de dinero> o <Dinero automático>." },
                { m_Settings.GetOptionLocaleID("GameDefault"), "Valor del juego" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.CustomMilestone)), "Selector de hito" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.CustomMilestone)),
                    "Activa <antes de cargar o crear> para desbloquear un hito al cargar.\n" +
                    "- No se puede activar con una ciudad cargada, pero sí apagar si quedó activo.\n" +
                    "- Si olvidaste hacerlo, reinicia el juego y elige antes de entrar.\n" +
                    "- El mod no puede deshacer hitos ya guardados; usa una partida anterior."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MilestoneLevel)), "Hito" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MilestoneLevel)),
                    "Elige el hito a desbloquear en la próxima carga.\n" +
                    "Solo se ajusta <fuera de una ciudad cargada> y con [Selector de hito] activo [ ✓ ].\n" +
                    "Si la ciudad ya está en ese hito o más, no pasa nada.\n" +
                    "Solo cambia si el hito elegido es más alto."
                },

                // --------------------------------------------------------------------
                // Money-Milestones tab - Money
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ManualMoneyAmount)), "Monto de atajo de dinero" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ManualMoneyAmount)),
                    "Usa este monto con los atajos Añadir y Restar dinero.\n" +
                    "<Valor del mod = 40,000>\n" +
                    "No hace nada salvo que uses el atajo en la ciudad.\n" +
                    "Para automático, activa Dinero automático."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AddMoneyKeyboardBinding)), "Añadir dinero" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AddMoneyKeyboardBinding)),
                    "Atajo para <Añadir dinero> en la ciudad." },
                { m_Settings.GetBindingKeyLocaleID(Setting.AddMoneyAction), "Añadir dinero" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.SubtractMoneyKeyboardBinding)), "Restar dinero" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.SubtractMoneyKeyboardBinding)),
                    "Atajo para <Restar dinero> en la ciudad." },
                { m_Settings.GetBindingKeyLocaleID(Setting.SubtractMoneyAction), "Restar dinero" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoney)), "Dinero automático" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoney)),
                    "Si está activado [ ✓ ], City Watchdog revisa el saldo de la ciudad.\n" +
                    "- Si el saldo está <bajo el umbral>, \n" +
                    "  añade el monto elegido.\n" +
                    "- Se recomienda usar dinero manual con atajo (<[> o <]>) cuando haga falta" +
                    "  en vez de automatizarlo, pero la opción existe."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoneyThreshold)), "Umbral de dinero automático" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoneyThreshold)),
                    "Si está activo y el saldo cae bajo este valor,\n" +
                    "añade el monto elegido." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoneyAmount)), "Monto automático" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoneyAmount)),
                    "Monto añadido cada vez que se activa.\n" +
                    "Elige suficiente para quedar sobre el umbral." },

                // --------------------------------------------------------------------
                // Money-Milestones tab - Save Conversion
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ConfirmUnlimitedMoneySaveConversion)), "Convertidor de dinero ilimitado" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ConfirmUnlimitedMoneySaveConversion)),
                    "<Haz una copia ANTES>.\n" +
                    "Convierte una ciudad creada con Dinero ilimitado a ciudad normal.\n" +
                    "Activa el botón <[Convertir guardado de Dinero ilimitado]> si la ciudad cargada es de tipo <Dinero ilimitado>.\n" +
                    "City Watchdog no puede deshacer esta conversión.\n" +
                    "Si tus ciudades son normales, no necesitas esto." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)), "Convertir ciudad con Dinero ilimitado a normal" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)),
                    "Para ciudades creadas con <Dinero ilimitado>.\n" +
                    "Con esa ciudad cargada, convierte el guardado a presupuesto normal.\n" +
                    "El botón está <desactivado/gris> salvo que la ciudad sea <Dinero ilimitado>\n" +
                    "y <Convertidor de dinero ilimitado> esté activo [ ✓ ].\n" +
                    "Haz copia y úsalo bajo tu riesgo; City Watchdog no puede deshacerlo." },

                { m_Settings.GetOptionWarningLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)),
                    "¿Convertir esta ciudad de Dinero ilimitado a dinero limitado normal?\n" +
                    "Guarda una copia ANTES; City Watchdog no puede deshacerlo.\n" +
                    "¿Seguro?" },

                // --------------------------------------------------------------------
                // About tab
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.NameText)), "Nombre del mod" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.NameText)), "Nombre mostrado del mod." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.VersionText)), "Versión" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.VersionText)), "Versión actual del mod." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.OpenParadox)), "Paradox Mods" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.OpenParadox)), "Abre la página Paradox Mods del autor." },

                // --------------------------------------------------------------------
                // About tab - Diagnostics
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.WriteNotificationAuditLog)), "Reporte debug al log" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.WriteNotificationAuditLog)),
                    "<No necesario para jugar normal.>\n" +
                    "Para pruebas y parches: escribe un reporte en <Logs/CityWatchdog.log>\n" +
                    "comparando prefabs de notificación del juego con los iconos que controla Watchdog." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.OpenLog)), "Abrir log" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.OpenLog)),
                    "Abre </Logs/CityWatchdog.log> si existe.\n" +
                    "Si no existe, abre la carpeta Logs/." },
            };

            return entries;
        }

        public void Unload()
        {
        }
    }
}
