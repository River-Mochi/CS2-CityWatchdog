// <copyright file="LocaleES.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi, MIT License.
// See LICENSE file in the project root for full license info.
// </copyright>
//
// File: src/Localization/LocaleES.cs
// Purpose: Spanish (es-ES) strings for City Watchdog Options UI (settings menu).

namespace CityWatchdog
{
    using System.Collections.Generic; // Dictionary and KeyValuePair
    using Colossal;                   // IDictionarySource

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
                { m_Settings.GetOptionTabLocaleID(Setting.Hotkeys), "Atajos" },
                { m_Settings.GetOptionTabLocaleID(Setting.About), "Acerca de" },
                { m_Settings.GetOptionTabLocaleID(Setting.Debug), "Depuración" },

                // --- Groups ---
                { m_Settings.GetOptionGroupLocaleID(Setting.MoneyViewGroup), "Visor de información" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Money), "Dinero" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Notifications), "Notificaciones" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Milestone), "Hito" },
                { m_Settings.GetOptionGroupLocaleID(Setting.SaveConversion), "Conversión de guardado" },
                { m_Settings.GetOptionGroupLocaleID(Setting.HotkeyActions), "Atajos" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutInfo), "" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutLinks), "" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutDiagnostics), "DIAGNÓSTICO" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutUsage), "USO" },

                // --- Money View ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyView)), "Mostrar detalles al pasar el cursor" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyView)), "Muestra valores numéricos de tendencia junto a las flechas vanilla de dinero y población de la barra inferior.\nEs una visualización ligera al pasar el cursor por la barra, <solo visual>;\nno cambia el dinero ni la población de la ciudad." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyViewMode)), "Frecuencia de Money View" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyViewMode)), "Elige si el texto de tendencia de la barra inferior muestra valores por hora o mensuales para dinero y población.\nMensual usa ingresos del presupuesto menos gastos para dinero, y una proyección de 24 horas para población." },
                { m_Settings.GetOptionLocaleID("MoneyViewModeHourly"), "Por hora (/h)" },
                { m_Settings.GetOptionLocaleID("MoneyViewModeMonthly"), "Mensual (/mo)" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyTooltipMode)), "Estilo del tooltip de dinero" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyTooltipMode)), "Elige cuántos detalles aparecen en el tooltip de dinero al pasar el cursor.\nCompacto = predeterminado en la primera instalación.\n<Mini> muestra solo 2 valores netos para /mo y /h.\n<Compacto> acorta valores grandes (15.21M en vez de 15,212,318).\n<Datos completos> muestra valores largos y campos Total." },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeMini"), "Mini" },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeCompact"), "Compacto" },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeFullData"), "Datos completos" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyTooltipFontScale)), "Tamaño de fuente de dinero" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyTooltipFontScale)), "Ajusta el <tamaño de fuente> de los números del tooltip de Money View.\nPredeterminado del juego = 100%\n<Predeterminado del mod = 120%>\nPasa el cursor sobre Dinero en la parte inferior de la pantalla.\nPedido por jugadores a quienes les cuesta ver tooltips pequeños del juego." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.PopulationTooltipFontScale)), "Tamaño de fuente de población" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.PopulationTooltipFontScale)), "Ajusta el <tamaño de fuente> de los números del tooltip de población.\nPredeterminado del juego = 100%\n<Predeterminado del mod = 120%>\nPasa el cursor sobre Población en la parte inferior de la pantalla." },

                // --- Money helpers ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ManualMoneyAmount)), "Importe del atajo de dinero" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ManualMoneyAmount)), "Usa este importe con los atajos Añadir dinero y Restar dinero.\n<Predeterminado del mod = 40,000>\nEsto no hace nada salvo que uses el atajo para añadir/restar dinero (en la ciudad).\nPara dinero automático, activa la opción Añadir dinero automático." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AddMoneyKeyboardBinding)), "Añadir dinero" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AddMoneyKeyboardBinding)), "Atajo para <Añadir dinero> dentro de la ciudad." },
                { m_Settings.GetBindingKeyLocaleID(Setting.AddMoneyAction), "Añadir dinero" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.SubtractMoneyKeyboardBinding)), "Restar dinero" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.SubtractMoneyKeyboardBinding)), "Atajo para <Restar dinero> dentro de la ciudad." },
                { m_Settings.GetBindingKeyLocaleID(Setting.SubtractMoneyAction), "Restar dinero" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoney)), "Añadir dinero automático" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoney)), "Cuando está activado [ ✓ ], City Watchdog revisa el saldo de la ciudad mientras hay una ciudad cargada.\n- Si el saldo está <por debajo del umbral>, \n  añade el importe automático seleccionado.\n- Se recomienda usar dinero manual con el atajo (<[> o <]>) cuando haga falta en vez de esta opción automática, pero está aquí si la quieres." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoneyThreshold)), "Umbral de dinero automático" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoneyThreshold)), "Si Añadir dinero automático está activado y el saldo de la ciudad cae por debajo de este valor,\nañade el importe automático seleccionado." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoneyAmount)), "Importe de dinero automático" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoneyAmount)), "Importe añadido cada vez que se activa Añadir dinero automático.\nElige un valor suficientemente alto para dejar la ciudad con seguridad por encima del umbral." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.InitialMoney)), "Dinero inicial" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.InitialMoney)), "Establece el saldo inicial para una nueva ciudad con <dinero limitado> o la primera ciudad cargada,\ny luego vuelve a Predeterminado del juego después de aplicarse.\nSe muestra en gris si ya hay una ciudad cargada.\nConfigúralo antes de iniciar/cargar una ciudad → se aplica una vez → después usa <Importe del atajo de dinero> o <Añadir dinero automático>." },
                { m_Settings.GetOptionLocaleID("GameDefault"), "Predeterminado del juego" },

                // --- Notifications ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleNotificationsKeyboardBinding)), "Alternar iconos de notificación" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleNotificationsKeyboardBinding)), "<Atajo> para la misma acción que el botón de icono <[TOGGLE ALL]> del panel del juego.\nMuestra u oculta al instante todos los iconos de notificación de ciudad listados." },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleNotificationsAction), "Mostrar/ocultar instantáneamente todos los iconos de notificación" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleNotificationPanelKeyboardBinding)), "Abrir/cerrar panel de notificaciones" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleNotificationPanelKeyboardBinding)), "<Atajo> para abrir o cerrar el\n<panel de notificaciones> en la ciudad.\nFunciona igual que hacer clic en el icono superior izquierdo para abrir el panel completo." },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleNotificationPanelAction), "Abrir/cerrar panel de notificaciones" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleRoadNamesKeyboardBinding)), "Ocultar/mostrar nombres de carreteras" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleRoadNamesKeyboardBinding)), "<Atajo> para ocultar o mostrar al instante las etiquetas vanilla de nombres de carretera en la ciudad.\nIgual que hacer clic en el icono de nombre de carretera en la barra del panel City Watchdog." },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleRoadNamesAction), "Ocultar/mostrar nombres de carreteras" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.DisableAllTooltips)), "Desactivar todos los tooltips al pasar el cursor" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.DisableAllTooltips)), "Desactiva los tooltips del juego al pasar el cursor: tanto los que siguen el cursor sobre edificios/ciudadanos/herramientas como las pequeñas ventanas en botones de la UI del juego (nombres de la barra superior, botones vanilla, etc.).\n<Los popups propios de dinero/población de City Watchdog siguen activos>; se controlan con la opción Money View anterior.\nIgual que hacer clic en el icono [i] del panel City Watchdog dentro de la ciudad." },

                // --- Milestone selector ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.CustomMilestone)), "Selector de hitos" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.CustomMilestone)), "Actívalo antes de cargar o iniciar una ciudad para desbloquear el hito elegido inmediatamente después de que cargue la ciudad.\nNo puede activarse mientras hay una ciudad cargada, pero puede desactivarse si quedó activado por error.\nCity Watchdog no puede deshacer cambios de hitos ya guardados en una ciudad; usa un guardado anterior si hace falta." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MilestoneLevel)), "Hito" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MilestoneLevel)), "Elige el nivel de hito que se desbloqueará al cargar la próxima ciudad.\nSolo se puede ajustar fuera de una ciudad cargada, y solo después de activar [Selector de hitos] [ ✓ ]." },

                // --- Save conversion ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ConfirmUnlimitedMoneySaveConversion)), "Conversor de dinero ilimitado" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ConfirmUnlimitedMoneySaveConversion)), "<Haz primero una copia de seguridad de la ciudad>.\nConvierte una ciudad iniciada con Dinero ilimitado en una ciudad normal con desafíos de dinero normales.\nActivarlo desbloquea el botón <[Convertir guardado de Dinero ilimitado]> cuando la ciudad cargada es de tipo <Dinero ilimitado>.\nCity Watchdog no puede deshacer esta conversión.\nSi tienes ciudades normales, no te preocupes; no hace falta." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)), "Convertir ciudad de Dinero ilimitado a normal" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)), "Para ciudades iniciadas con <Dinero ilimitado>.\nMientras esa ciudad está cargada, convierte el guardado a presupuesto normal de dinero limitado para que la ciudad vuelva a tener desafíos de dinero normales.\nEl botón está <desactivado/en gris> salvo que la ciudad cargada sea de tipo <Dinero ilimitado>\ny <Conversor de dinero ilimitado> esté ON [ ✓ ].\nHaz una copia de seguridad y úsalo bajo tu responsabilidad; City Watchdog no puede deshacer esta conversión." },
                { m_Settings.GetOptionWarningLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)), "¿Convertir esta ciudad de Dinero ilimitado a dinero limitado normal?\nGuarda una copia de seguridad PRIMERO; City Watchdog no puede deshacer esto.\n¿Seguro?" },

                // --- About tab ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.NameText)), "Nombre del mod" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.NameText)), "Nombre visible de este mod." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.VersionText)), "Versión" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.VersionText)), "Versión actual del mod." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.OpenParadox)), "Paradox Mods" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.OpenParadox)), "Abre la página del autor en Paradox Mods." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.WriteNotificationAuditLog)), "Informe de depuración al registro" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.WriteNotificationAuditLog)), "<No es necesario para jugar normalmente.>\nPara testers y revisiones después de parches del juego: escribe un informe <Logs/CityWatchdog.log>\ncomparando los prefabs de notificación del juego en vivo con los iconos de notificación que Watchdog controla actualmente." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.OpenLog)), "Abrir registro" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.OpenLog)), "Abre </Logs/CityWatchdog.log> si existe.\nSi falta el archivo de registro, abre la carpeta Logs/ en su lugar." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ShowUsage)), "Mostrar instrucciones" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ShowUsage)), "Muestra u oculta las instrucciones de uso de abajo." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.UsageText)), "<Panel de notificaciones>\n1. Haz clic en el botón City Watchdog (arriba a la izquierda), o pulsa Shift+N, para abrir el panel.\n2. Ordena ASC/DESC.\n3. Usa Toggle All para activar/desactivar todo rápidamente, o expande una sección para cambiar iconos concretos.\n4. Solo muestra u oculta iconos; no soluciona el problema de la ciudad.\n\n<Ayudas de dinero>\n1. Añadir o restar dinero: usa el <Importe del atajo de dinero> predeterminado [ o ].\n2. Añadir dinero automático vigila el presupuesto mientras hay una ciudad cargada y añade dinero cuando está por debajo del umbral.\n3. Money View añade valores numéricos a la barra de dinero y población y tooltips al pasar el cursor.\n4. Convertir guardado de Dinero ilimitado es solo para ciudades iniciadas con Dinero ilimitado y es <irreversible>.\n\n<Hito personalizado>\nConfigura Dinero inicial y selecciona Hitos en el menú Opciones antes de cargar o iniciar una ciudad." },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.UsageText)), "" },
            };

            return entries;
        }

        public void Unload()
        {
        }
    }
}
