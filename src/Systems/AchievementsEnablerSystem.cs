// File: src/Systems/AchievementsEnablerSystem.cs
// Purpose: Keeps achievements enabled after game load and exposes achievement actions.

namespace CityWatchdog.Systems
{
    using Colossal.PSI.Common;
    using Colossal.Serialization.Entities;
    using Game;

    public partial class AchievementsControllerSystem : GameSystemBaseExtension
    {
        private const int AssertFrames = 1800;
        private int framesLeft;
        private bool achievementFixerDetectedLogged;

        protected override void OnCreate()
        {
            base.OnCreate();
            framesLeft = 0;
            achievementFixerDetectedLogged = false;
            Enabled = false;
        }

        protected override void OnGamePreload(Purpose purpose, GameMode mode)
        {
            base.OnGamePreload(purpose, mode);
            PlatformManager? platformManager = PlatformManager.instance;
            CityWatchdog.Mod.DebugLog(() =>
                $"AchievementsControllerSystem OnGamePreload, game mode: {mode}, game/mod achievements status: {platformManager?.achievementsEnabled.ToString() ?? "(no platform manager)"} {Setting.Instance.AchievementsEnabled}, Achievement Fixer enabled: {ModTools.IsAchievementFixerEnabled()}");
        }

        protected override void OnGameLoadingComplete(Purpose purpose, GameMode mode)
        {
            base.OnGameLoadingComplete(purpose, mode);

            if (mode != GameMode.Game || !ShouldRunCityWatchdogAchievements())
            {
                Enabled = false;
                return;
            }

            framesLeft = AssertFrames;
            Enabled = true;
            ForceEnableIfNeeded("OnGameLoadingComplete");
            CityWatchdog.Mod.ReapplyAchievementBannerForActiveLocale();
        }

        protected override void OnUpdate()
        {
            if (!ShouldRunCityWatchdogAchievements())
            {
                Enabled = false;
                return;
            }

            if (framesLeft <= 0)
            {
                CityWatchdog.Mod.ReapplyAchievementBannerForActiveLocaleFinal();
                Enabled = false;
                return;
            }

            ForceEnableIfNeeded("OnUpdate");
            framesLeft--;
        }

        public void SetAchievements(bool enabled)
        {
            if (ModTools.IsAchievementFixerEnabled())
            {
                LogAchievementFixerDetectedOnce();
                Enabled = false;
                return;
            }

            PlatformManager? platformManager = PlatformManager.instance;
            if (platformManager == null)
            {
                LogUtils.Warn(() => "SetAchievements skipped: PlatformManager.instance is null.");
                return;
            }

            if (platformManager.achievementsEnabled != enabled)
            {
                platformManager.achievementsEnabled = enabled;
                CityWatchdog.Mod.DebugLog(() => $"Set achievements: {enabled}");
            }

            if (enabled && InGame)
            {
                framesLeft = AssertFrames;
                Enabled = true;
                CityWatchdog.Mod.ReapplyAchievementBannerForActiveLocale();
            }
            else if (!enabled)
            {
                Enabled = false;
            }
        }

        private bool ShouldRunCityWatchdogAchievements()
        {
            if (!Setting.Instance.AchievementsEnabled)
            {
                return false;
            }

            if (!ModTools.IsAchievementFixerEnabled())
            {
                return true;
            }

            LogAchievementFixerDetectedOnce();
            return false;
        }

        private void LogAchievementFixerDetectedOnce()
        {
            if (achievementFixerDetectedLogged)
            {
                return;
            }

            achievementFixerDetectedLogged = true;
            LogUtils.Info(() => "Achievement Fixer is enabled; City Watchdog achievement support is disabled for this session to avoid duplicate achievement handling.");
        }

        private static bool ForceEnableIfNeeded(string source)
        {
            PlatformManager? platformManager = PlatformManager.instance;
            if (platformManager == null)
            {
                return false;
            }

            if (platformManager.achievementsEnabled)
            {
                return false;
            }

            CityWatchdog.Mod.DebugLog(() => $"{source}: detected achievementsEnabled == false; forcing true.");
            platformManager.achievementsEnabled = true;
            return true;
        }
    }
}
