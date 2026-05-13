// File: src/Mod.cs
// Purpose: Registers City Watchdog settings, systems, localization placeholders, and the dedicated mod log.

namespace CityWatchdog
{
    using CityWatchdog.Settings;
    using CityWatchdog.Systems;
    using Colossal;
    using Colossal.IO.AssetDatabase;
    using Colossal.Localization;
    using Colossal.Logging;
    using CS2Shared.Common;
    using CS2Shared.Tools;
    using Game;
    using Game.Modding;
    using Game.SceneFlow;
    using System;
    using System.Reflection;

    public sealed class Mod : ModBase, IMod
    {
        public const string ModName = "City Watchdog";
        public const string ModId = "CityWatchdog";
        public const string ModTag = "[CWD]";

        public static readonly string ModVersion =
            Assembly.GetExecutingAssembly().GetName().Version?.ToString(3) ?? "0.5.0";

        public static readonly ILog s_Log =
            LogManager.GetLogger(ModId).SetShowsErrorsInUI(false);

        private static bool s_BannerLogged;

        public override bool BetaVersion => true;

        public override DateTime VersionDate => new DateTime(2026, 5, 12);

        internal static void DebugLog(string message)
        {
#if DEBUG
            LogUtils.Info(s_Log, () => message);
#else
            _ = message;
#endif
        }

        protected override void CreateSetting()
        {
            Setting setting = new Setting(this);
            Setting = Settings.Setting.Instance = setting;

            // Register languages here when locale files are added.
            // AddLocaleSource("en-US", new LocaleEN(setting));
            // AddLocaleSource("fr-FR", new LocaleFR(setting));
            // AddLocaleSource("es-ES", new LocaleES(setting));
            // AddLocaleSource("de-DE", new LocaleDE(setting));
            // AddLocaleSource("it-IT", new LocaleIT(setting));
            // AddLocaleSource("ja-JP", new LocaleJA(setting));
            // AddLocaleSource("ko-KR", new LocaleKO(setting));
            // AddLocaleSource("pl-PL", new LocalePL(setting));
            // AddLocaleSource("pt-BR", new LocalePT_BR(setting));
            // AddLocaleSource("zh-HANS", new LocaleZH_CN(setting));    // Simplified Chinese
            // AddLocaleSource("zh-HANT", new LocaleZH_HANT(setting));  // Traditional Chinese

            // CS2 persists ModSetting values in ModsSettings/CityWatchdog/CityWatchdog.coc.
            AssetDatabase.global.LoadSettings(ModId, setting, new Setting(this));
        }

        protected override void CreateSystem(UpdateSystem updateSystem)
        {
            base.CreateSystem(updateSystem);

            LogStartupBanner();

            if (!ModTools.IsModInclusive("AchievementEnabler"))
            {
                updateSystem.UpdateAfter<AchievementsControllerSystem>(SystemUpdatePhase.Deserialize);
            }

            updateSystem.UpdateAt<MoneyControllerSystem>(SystemUpdatePhase.ModificationEnd);
            updateSystem.UpdateAt<UnlockMilestonesSystem>(SystemUpdatePhase.ModificationEnd);
            updateSystem.UpdateAt<CityWatchdogUISystem>(SystemUpdatePhase.UIUpdate);
            updateSystem.UpdateAt<NotificationControllerSystem>(SystemUpdatePhase.ModificationEnd);
        }

        private static void LogStartupBanner()
        {
            if (s_BannerLogged)
            {
                return;
            }

            s_BannerLogged = true;
            LogUtils.Info(s_Log, () => $"{ModName} v{ModVersion} {ModTag} loaded");
        }

        private static void AddLocaleSource(string localeId, IDictionarySource source)
        {
            if (string.IsNullOrEmpty(localeId))
            {
                return;
            }

            LocalizationManager? localizationManager = GameManager.instance.localizationManager;
            if (localizationManager == null)
            {
                LogUtils.Warn(s_Log, () => $"AddLocaleSource: No LocalizationManager; cannot add source for '{localeId}'.");
                return;
            }

            try
            {
                localizationManager.AddSource(localeId, source);
            }
            catch (Exception ex)
            {
                LogUtils.Warn(s_Log, () => $"AddLocaleSource: AddSource for '{localeId}' failed: {ex.GetType().Name}: {ex.Message}", ex);
            }
        }
    }
}
