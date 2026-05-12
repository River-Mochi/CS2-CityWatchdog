// File: src/Mod.cs
// Purpose: Registers City Watchdog settings and gameplay/UI systems with the CS2 mod lifecycle.

namespace CityWatchdog
{
    using CityWatchdog.Settings;
    using CityWatchdog.Systems;
    using Colossal.Logging;
    using CS2Shared.Common;
    using CS2Shared.Tools;
    using Game;
    using Game.Modding;
    using System;
    using System.Reflection;

    public sealed class Mod : ModBase, IMod
    {
        // ---- Metadata ----
        public const string ModName = "City Watchdog";
        public const string ModId = "CityWatchdog";
        public const string ModTag = "[CW]";

        // Main mod logger. Writes to Logs/CityWatchdog.log
        public static readonly ILog s_Log = LogManager.GetLogger(ModId);

        // Assembly version source of truth for logs.
        // Controlled by <Version> in CityWatchdog.csproj.
        public static readonly string ModVersion =
            Assembly.GetExecutingAssembly().GetName().Version?.ToString(3) ?? "0.5.0";

#if DEBUG
        private const string BuildTag = "[DEBUG]";
#else
        private const string BuildTag = "[RELEASE]";
#endif

        private static bool s_BannerLogged;

        public override bool BetaVersion => true;

        public override DateTime VersionDate => new DateTime(2026, 5, 12);

        static Mod()
        {
#if DEBUG
            // Dev builds: surface errors in UI.
            s_Log.SetShowsErrorsInUI(true);
#else
            // Release builds: keep UI popups quiet.
            s_Log.SetShowsErrorsInUI(false);
#endif
        }

        // DEBUG-only info log helper.
        // Keeps release logs free of routine chatter.
        internal static void DebugLog(string message)
        {
#if DEBUG
            s_Log.Info(message);
#else
            _ = message;
#endif
        }

        protected override void CreateSetting()
        {
            Setting setting = new Setting(this);
            Setting = Settings.Setting.Instance = setting;
            LoadSetting(new Setting(this));
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
            s_Log.Info($"{ModName} {ModTag} v{ModVersion} loaded {BuildTag}");
        }
    }
}
