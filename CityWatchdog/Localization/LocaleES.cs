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

    public sealed class LocaleES : IDictionarySource
    {
        private readonly CwdSettings m_Settings;

        public LocaleES(CwdSettings setting)
        {
            m_Settings = setting;
        }

        public IEnumerable<KeyValuePair<string, string>> ReadEntries(
            IList<IDictionaryEntryError> errors,
            Dictionary<string, int> indexCounts)
        {
            string title = Mod.ModName + " (Vigilante urbano)";

            Dictionary<string, string> entries = new()
            {
                // --- Mod title ---
                { m_Settings.GetSettingsLocaleID(), title },

                // --- Tabs ---
                { m_Settings.GetOptionTabLocaleID(CwdSettings.kActions), "Acciones" },
                { m_Settings.GetOptionTabLocaleID(CwdSettings.kMiniHudTab), "Mini-HUD" },
                { m_Settings.GetOptionTabLocaleID(CwdSettings.kMoneyTab), "Nueva ciudad" },
                { m_Settings.GetOptionTabLocaleID(CwdSettings.kAbout), "Acerca de" },

                // --- Groups, ordered by Options menu location ---
                { m_Settings.GetOptionGroupLocaleID(CwdSettings.kAboutUsage), "USO" },
                { m_Settings.GetOptionGroupLocaleID(CwdSettings.kNotifications), "Notificaciones" },
                { m_Settings.GetOptionGroupLocaleID(CwdSettings.kMoneyViewGroup), "Info en ciudad" },
                { m_Settings.GetOptionGroupLocaleID(CwdSettings.kMiniHudGroup), "Avisos Mini HUD" },
                { m_Settings.GetOptionGroupLocaleID(CwdSettings.kMilestone), "AJUSTES DE CIUDAD NUEVA" },
                { m_Settings.GetOptionGroupLocaleID(CwdSettings.kMoney), "Dinero" },
                { m_Settings.GetOptionGroupLocaleID(CwdSettings.kSaveConversion), "Convertir guardado ilimitado" },
                { m_Settings.GetOptionGroupLocaleID(CwdSettings.kAboutInfo), "" },
                { m_Settings.GetOptionGroupLocaleID(CwdSettings.kAboutLinks), "" },
                { m_Settings.GetOptionGroupLocaleID(CwdSettings.kAboutDiagnostics), "DIAGNÓSTICO" },

                // --------------------------------------------------------------------
                // Actions tab - Usage
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.ShowUsage)), "Mostrar instrucciones" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.ShowUsage)), "Muestra u oculta las instrucciones de abajo." },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.UsageText)),
                    "A. Usa el icono de la pata arriba a la izquierda, o Shift+N, para abrir el panel.\n" +
                    "<Botones de vista>\n" +
                    "1. Icono del título: muestra/oculta las ayudas emergentes de City Watchdog.\n" +
                    "\n" +
                    "2. Botón **[i]**: oculta/muestra <TODAS> las ayudas emergentes del juego: edificios, ciudadanos, herramientas y barra inferior.\n" +
                    "3. Botón carretera: oculta/muestra nombres de calles. Atajo: \\.\n" +
                    "4. Botón distrito: oculta/muestra nombres de distritos.\n" +
                    "5. Botón flechas: activa/desactiva las flechas de sentido único (también oculta nombres de calles).\n" +
                    "\n" +
                    "<Alertas>\n" +
                    "1. Ordenar cambia A→Z, Z→A y lista solo activa.\n" +
                    "2. <[0/62]> = iconos ACTIVOS/total. Clic: expandir/contraer todas las filas.\n" +
                    "3a. [Mostrar iconos] apaga/enciende al instante todos los iconos de alertas de problemas.\n" +
                    "3b. Preajustes [1 | 2]: clic para cargar; mantén 1 segundo para guardar las casillas actuales.\n" +
                    "3c. Ocultar un icono no arregla el problema de la ciudad.\n" +
                    "\n" +
                    "<Ayudas>\n" +
                    "1. Añadir / restar dinero: usa las teclas <[ o ]> para <Cantidad del atajo de dinero>.\n" +
                    "2. Dinero automático añade dinero si la ciudad baja del límite elegido.\n" +
                    "3. Convertir guardado con Dinero ilimitado es solo para esas ciudades y es <irreversible>.\n" +
                    "\n" +
                    "<Ayudas del menú inferior>\n" +
                    "Vista de dinero añade detalles como tendencias al pasar el cursor sobre dinero o población.\n" +
                    "\n" +
                    "<Hito personalizado>\n" +
                    "Nueva ciudad fija el dinero inicial o los hitos antes de cargar o iniciar una ciudad."
                },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.UsageText)), "" },

                // --------------------------------------------------------------------
                // Actions tab - Notifications
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.ToggleNotificationsKeyboardBinding)), "Alternar iconos de alerta" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.ToggleNotificationsKeyboardBinding)),
                    "<Atajo> para la misma acción que el botón <[MOSTRAR ICONOS]> del juego.\n" +
                    "Muestra u oculta al instante todos los iconos de alertas de problemas."
                },
                { m_Settings.GetBindingKeyLocaleID(CwdSettings.ToggleNotificationsAction), "Mostrar/ocultar al instante los iconos de problemas" },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.ToggleNotificationPanelKeyboardBinding)), "Abrir/cerrar panel de alertas" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.ToggleNotificationPanelKeyboardBinding)),
                    "<Atajo> para abrir o cerrar el\n" +
                    "<panel de alertas> en la ciudad.\n" +
                    "Igual que pulsar el icono superior izquierdo."
                },
                { m_Settings.GetBindingKeyLocaleID(CwdSettings.ToggleNotificationPanelAction), "Abrir/cerrar panel de alertas" },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.PanelButtonsOnlyStart)), "Iniciar solo botones" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.PanelButtonsOnlyStart)),
                    "Si está activo [ ✓ ], City Watchdog abre primero la vista pequeña solo con botones.\n" +
                    "Usa la flecha del título o el contador para abrir el panel completo."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.ToggleRoadNamesKeyboardBinding)), "Ocultar/mostrar nombres de calles" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.ToggleRoadNamesKeyboardBinding)),
                    "<Atajo> para ocultar/mostrar nombres de calles del juego base.\n" +
                    "Igual que el icono de calles en City Watchdog."
                },
                { m_Settings.GetBindingKeyLocaleID(CwdSettings.ToggleRoadNamesAction), "Ocultar/mostrar nombres de calles" },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.ToggleAllTooltipsKeyboardBinding)), "Desactivar todas las ayudas emergentes" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.ToggleAllTooltipsKeyboardBinding)),
                    "<Atajo> para ocultar/mostrar TODAS las ayudas emergentes del juego: edificios, ciudadanos, herramientas e iconos inferiores.\n" +
                    "<Las ventanas de dinero/población de City Watchdog siguen activas>; las controla Vista de dinero.\n" +
                    "Igual que el icono [i] del panel City Watchdog."
                },
                { m_Settings.GetBindingKeyLocaleID(CwdSettings.ToggleAllTooltipsAction), "Ocultar/mostrar ayudas emergentes del juego" },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.InterfaceScaling)), "Interfaz del juego más grande" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.InterfaceScaling)),
                    "Al activarlo [ ✓ ], <toda la interfaz del juego> se hace más grande — paneles del juego y de mods.\n" +
                    "Usa la opción del juego <Escala de interfaz> sin necesitar el parámetro <--developerMode>.\n" +
                    "Esta casilla [x] está sincronizada con el botón de escala de la barra de título de City Watchdog.\n" +
                    "Solo para el texto: Opciones > Interfaz > <Escala de texto>.\n" +
                    "Sigue activo hasta que lo desactives, aunque quites City Watchdog.\n" +
                    "- Desactívalo antes de desinstalar para volver al tamaño normal.\n" +
                    "- O inicia una vez con <--developerMode> y desactiva Opciones > Interfaz > Escala de interfaz (dev)."
                },


                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.MainPanelOpacity)), "Opacidad del panel principal" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.MainPanelOpacity)),
                    "Ajusta la transparencia del fondo del panel principal de notificaciones.\n" +
                    "Los valores bajos son más transparentes. Los valores altos son más oscuros y sólidos."
                },

                // --------------------------------------------------------------------
                // Actions tab - In-City Info Viewer
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.MoneyView)), "Tendencias de dinero + población" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.MoneyView)),
                    "<Recomendado>\n" +
                    "Menú inferior: muestra tendencias en las flechas de <dinero y población>.\n" +
                    "Función ligera al pasar el cursor <solo visual>;\n" +
                    "ahorra tiempo y puede rendir mejor que abrir el panel de información del juego."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.MoneyViewMode)), "Frecuencia de Vista de dinero" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.MoneyViewMode)),
                    "Elige valores por hora o por mes en la barra inferior.\n" +
                    "Mensual usa ingresos menos gastos y una proyección de población de 24 h."
                },
                { m_Settings.GetOptionLocaleID("MoneyViewModeHourly"), "Por hora (/h)" },
                { m_Settings.GetOptionLocaleID("MoneyViewModeMonthly"), "Mensual (/mo)" },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.MoneyTooltipMode)), "Estilo de ayuda de dinero" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.MoneyTooltipMode)),
                    "Elige cuánto detalle muestra la ayuda de dinero.\n" +
                    "Compacto = predeterminado al instalar.\n" +
                    "<Mini> muestra solo 2 valores netos para /mo y /h.\n" +
                    "<Compacto> acorta números grandes (15.21M en vez de 15,212,318).\n" +
                    "<Datos completos> muestra valores largos y totales."
                },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeMini"), "Mini" },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeCompact"), "Compacto" },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeFullData"), "Datos completos" },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.MoneyTooltipFontScale)), "Tamaño de fuente de dinero" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.MoneyTooltipFontScale)),
                    "Ajusta el <tamaño de fuente> de los números de Vista de dinero.\n" +
                    "Predeterminado del juego = 100%\n" +
                    "<Predeterminado del mod = 120%>\n" +
                    "Pasa el cursor sobre Dinero abajo.\n" +
                    "Para jugadores que ven pequeñas las ayudas emergentes."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.PopulationTooltipFontScale)), "Tamaño de fuente de población" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.PopulationTooltipFontScale)),
                    "Ajusta el <tamaño de fuente> de los números de población.\n" +
                    "Predeterminado del juego = 100%\n" +
                    "<Predeterminado del mod = 120%>\n" +
                    "Pasa el cursor sobre Población abajo."
                },

                // --------------------------------------------------------------------
                // Mini-HUD tab - Mini HUD Notifications
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.MiniHudEnabled)), "Mini HUD" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.MiniHudEnabled)),
                    "Muestra un HUD pequeño con los contadores de alerta importantes.\n" +
                    "Úsalo como barra rápida sin abrir el panel completo.\n" +
                    "Clic en un icono salta a un problema.\n" +
                    "Más clics rotan por coincidencias y vuelven al primero."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.ApplyMiniHudRecommendedPreset)), "Clic: inicio rápido" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.ApplyMiniHudRecommendedPreset)),
                    "Aplica un <inicio rápido> para el Mini HUD:\n" +
                    "Incluye una **selección inicial de estrellas azules**.\n" +
                    "En modo Favoritos, Mini HUD muestra los 5 o 10 conteos actuales más altos de tu lista de **estrellas azules**.\n" +
                    "Añade/quita **estrellas azules** en el panel City Watchdog.\n" +
                    "Configura: Favoritos, 5 iconos, horizontal, arrastrable, 100 %, panel oscuro y oculta conteos 0.\n" +
                    "Ejecuta Inicio rápido otra vez cuando quieras restablecer estos ajustes."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.MiniHudMode)), "Modo mini panel" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.MiniHudMode)),
                    "Elige qué filas de alerta usa el mini panel.\n" +
                    "**Más activas** muestra los contadores actuales más altos.\n" +
                    "**Favoritos** usa las filas con **estrella azul** en el panel principal City Watchdog.\n" +
                    "Puedes elegir tantos favoritos como quieras,\n" +
                    "pero el mini panel solo muestra los 5 o 10 conteos más altos de esa lista de **estrellas azules**."
                },
                { m_Settings.GetOptionLocaleID("MiniHudModeTopActive"), "Alertas más activas" },
                { m_Settings.GetOptionLocaleID("MiniHudModeFavorites"), "Favoritos" },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.MiniHudItemCount)), "Cantidad de iconos" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.MiniHudItemCount)), "Elige cuántos iconos puede mostrar el Mini HUD." },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.MiniHudScale)), "Tamaño de icono" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.MiniHudScale)),
                    "Escala iconos y números del Mini HUD.\n" +
                    "90% = compacto. 100% = normal. Hasta 130% para ver mejor."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.MiniHudOrientation)), "Orientación" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.MiniHudOrientation)), "Elige fila o columna." },
                { m_Settings.GetOptionLocaleID("MiniHudOrientationHorizontal"), "Horizontal" },
                { m_Settings.GetOptionLocaleID("MiniHudOrientationVertical"), "Vertical" },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.MiniHudPlacement)), "Posición del HUD" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.MiniHudPlacement)),
                    "Elige dónde aparece el Mini HUD.\n" +
                    "Arrastrable permite moverlo en la interfaz de la ciudad."
                },
                { m_Settings.GetOptionLocaleID("MiniHudPlacementTopCenter"), "Arriba centro" },
                { m_Settings.GetOptionLocaleID("MiniHudPlacementTopRight"), "Arriba derecha" },
                { m_Settings.GetOptionLocaleID("MiniHudPlacementDraggable"), "Arrastrable" },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.MiniHudPanelStyle)), "Estilo oscuro o cristal" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.MiniHudPanelStyle)),
                    "Elige el fondo del Mini HUD.\n" +
                    "Cristal va de claro a blanco nublado; no se oscurece.\n" +
                    "Usa Oscuro para un HUD más oscuro estilo juego."
                },
                { m_Settings.GetOptionLocaleID("MiniHudPanelStyleDark"), "Panel oscuro" },
                { m_Settings.GetOptionLocaleID("MiniHudPanelStyleGlass"), "Panel cristal" },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.MiniHudPanelOpacity)), "Opacidad del fondo" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.MiniHudPanelOpacity)),
                    "Ajusta la transparencia del fondo del Mini HUD.\n" +
                    "Menor = más transparente. Mayor = más sólido.\n" +
                    "Cristal se vuelve más blanco. Oscuro más sólido/oscuro."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.MiniHudHideZero)), "Ocultar alertas 0" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.MiniHudHideZero)), "Si está activo [ ✓ ], Mini HUD oculta filas con contador 0." },

                // --------------------------------------------------------------------
                // City Start tab - New City Start Settings
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.InitialMoney)), "Dinero inicial" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.InitialMoney)),
                    "Define el saldo de la próxima ciudad con <dinero limitado> que cargues — nueva o existente.\n" +
                    "Después de aplicarse una vez, vuelve al valor predeterminado del juego.\n" +
                    "Se desactiva cuando ya hay una ciudad cargada.\n" +
                    "Configúralo antes de cargar o iniciar la ciudad. Después usa <Cantidad del atajo de dinero> si hace falta."
                },

                { m_Settings.GetOptionLocaleID("GameDefault"), "Valor del juego" },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.CustomMilestone)), "Selector de hito" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.CustomMilestone)),
                    "Actívalo <antes de cargar o iniciar> para desbloquear un hito al cargar.\n" +
                    "- No puede activarse con ciudad cargada, pero sí apagarse.\n" +
                    "- Si lo olvidaste, reinicia el juego y elige antes de entrar.\n" +
                    "- El mod no deshace hitos ya guardados; usa un guardado anterior."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.MilestoneLevel)), "Hito" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.MilestoneLevel)),
                    "Elige el hito para la próxima carga.\n" +
                    "Solo ajustable <fuera de una ciudad cargada> y con [Selector de hito] activo [ ✓ ].\n" +
                    "Si la ciudad ya está en ese hito o más, no pasa nada.\n" +
                    "Solo cambia si el hito elegido es mayor."
                },

                // --------------------------------------------------------------------
                // City Start tab - Money
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.ManualMoneyAmount)), "Cantidad del atajo de dinero" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.ManualMoneyAmount)),
                    "Usa esta cantidad con los atajos Añadir y Restar dinero.\n" +
                    "<Predeterminado del mod = 40,000>\n" +
                    "No hace nada sin usar el atajo en la ciudad.\n" +
                    "Para automatizar, activa Dinero automático."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.AddMoneyKeyboardBinding)), "Añadir dinero" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.AddMoneyKeyboardBinding)), "Atajo para <Añadir dinero> en la ciudad." },
                { m_Settings.GetBindingKeyLocaleID(CwdSettings.AddMoneyAction), "Añadir dinero" },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.SubtractMoneyKeyboardBinding)), "Restar dinero" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.SubtractMoneyKeyboardBinding)), "Atajo para <Restar dinero> en la ciudad." },
                { m_Settings.GetBindingKeyLocaleID(CwdSettings.SubtractMoneyAction), "Restar dinero" },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.AutomaticAddMoney)), "Dinero automático" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.AutomaticAddMoney)),
                    "Si está activo [ ✓ ], City Watchdog revisa el saldo de la ciudad.\n" +
                    "- Si el saldo está <bajo el límite>, añade lo necesario para alcanzar ese límite.\n" +
                    "- Siempre añade como mínimo la Cantidad de dinero automática elegida.\n" +
                    "- Para usos ocasionales se recomiendan los atajos manuales (<[> o <]>)."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.AutomaticAddMoneyThreshold)), "Límite de dinero automático" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.AutomaticAddMoneyThreshold)),
                    "Si Dinero automático está activo y el saldo cae por debajo de este valor,\n" +
                    "se añade dinero hasta alcanzar al menos este límite."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.AutomaticAddMoneyAmount)), "Cantidad automática" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.AutomaticAddMoneyAmount)),
                    "Cantidad mínima añadida cada vez que se activa Dinero automático.\n" +
                    "Si hace falta más para alcanzar el límite, City Watchdog añade la cantidad mayor."
                },

                // --------------------------------------------------------------------
                // City Start tab - Save Conversion
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.ConfirmUnlimitedMoneySaveConversion)), "Conversor de dinero ilimitado" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.ConfirmUnlimitedMoneySaveConversion)),
                    "<Haz copia de seguridad PRIMERO>.\n" +
                    "Convierte una ciudad iniciada con Dinero ilimitado en una ciudad normal.\n" +
                    "Al activarlo desbloquea <[Convertir guardado con Dinero ilimitado]> si la ciudad cargada es de <Dinero ilimitado>.\n" +
                    "City Watchdog no puede deshacerlo.\n" +
                    "Si tus ciudades son normales, no lo necesitas."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.ConvertUnlimitedMoneySave)), "Convertir ciudad con Dinero ilimitado a normal" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.ConvertUnlimitedMoneySave)),
                    "Para ciudades iniciadas con <Dinero ilimitado>.\n" +
                    "Con la ciudad cargada, convierte el guardado a presupuesto normal limitado.\n" +
                    "El botón está <desactivado/gris> salvo que la ciudad sea de <Dinero ilimitado>\n" +
                    "y <Conversor de dinero ilimitado> esté ACTIVADO [ ✓ ].\n" +
                    "Haz una copia y úsalo bajo tu responsabilidad; City Watchdog no deshace esto."
                },

                { m_Settings.GetOptionWarningLocaleID(nameof(CwdSettings.ConvertUnlimitedMoneySave)),
                    "¿Convertir esta ciudad de Dinero ilimitado a dinero limitado normal?\n" +
                    "Guarda una copia PRIMERO; City Watchdog no puede deshacerlo.\n" +
                    "¿Seguro?"
                },

                // --------------------------------------------------------------------
                // About tab
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.NameText)), "Nombre del mod" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.NameText)), "Nombre visible de este mod." },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.VersionText)), "Versión" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.VersionText)), "Versión actual del mod." },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.OpenParadox)), "Paradox Mods" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.OpenParadox)), "Abre la página Paradox Mods del autor." },

                // --------------------------------------------------------------------
                // About tab - Diagnostics
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.WriteNotificationAuditLog)), "Informe de depuración" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.WriteNotificationAuditLog)),
                    "<No hace falta para jugar normalmente.>\n" +
                    "Para probadores y revisiones tras actualizaciones del juego: escribe un informe en <Logs/CityWatchdog.log>\n" +
                    "que compara las alertas del juego con los iconos controlados por Watchdog."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.OpenLog)), "Abrir registro" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.OpenLog)),
                    "Abre </Logs/CityWatchdog.log> si existe.\n" +
                    "Si falta, abre la carpeta Logs/."
                },
            };

            return entries;
        }

        public void Unload()
        {
        }
    }
}
