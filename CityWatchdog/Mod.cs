// <copyright file="Mod.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the MIT License. You may not use this file except in compliance with this License.
// See LICENSE file in the project root for full license information.
// This notice and the MIT License notice must be kept with
// all copies or substantial portions of this code.
// ================= </copyright> ======================

// File: src/Mod.cs
// Purpose: Mod entrypoint; registers settings, localization, systems, keybindings, and the dedicated mod log.

namespace CityWatchdog
{
    using CityWatchdog.Systems;
    using CS2Shared.RiverMochi;
    using Colossal;
    using Colossal.IO.AssetDatabase;
    using Colossal.Json;
    using Colossal.Localization;
    using Colossal.Logging;
    using Colossal.PSI.Environment;
    using Game;
    using Game.Input;
    using Game.Modding;
    using Game.SceneFlow;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Reflection;

    public sealed class Mod : IMod
    {
        public const string ModName = "City Watchdog";
        public const string ModId = "CityWatchdog";
        public const string ModTag = "[CWD]";

        public static readonly string ModVersion =
            Assembly.GetExecutingAssembly().GetName().Version?.ToString(3) ?? "0.5.0";

        public static readonly ILog s_Log =
            LogManager.GetLogger(ModId).SetShowsErrorsInUI(false);

        internal static Setting? Settings { get; private set; }

        private static bool s_BannerLogged;

        [System.Diagnostics.Conditional("DEBUG")]
        internal static void DebugLog(string message)
        {
            LogUtils.Info(() => message);
        }

        [System.Diagnostics.Conditional("DEBUG")]
        internal static void DebugLog(Func<string> messageFactory)
        {
            LogUtils.Info(messageFactory);
        }

        public void OnLoad(UpdateSystem updateSystem)
        {
            LogUtils.Configure(ModId, s_Log);
            ShellOpen.Configure(s_Log, ModId, ModTag);
            LogStartupBanner();

            if (GameManager.instance == null)
            {
                LogUtils.Warn(() => "GameManager.instance is null; City Watchdog cannot initialize.");
                return;
            }

            Setting setting = new Setting(this);
            Settings = Setting.Instance = setting;

            // Options UI strings — one IDictionarySource per language (typed Locale*.cs classes).
            AddLocaleSource("en-US", new LocaleEN(setting));
            AddLocaleSource("fr-FR", new LocaleFR(setting));
            AddLocaleSource("es-ES", new LocaleES(setting));
            AddLocaleSource("de-DE", new LocaleDE(setting));
            AddLocaleSource("it-IT", new LocaleIT(setting));
            AddLocaleSource("ja-JP", new LocaleJA(setting));
            AddLocaleSource("ko-KR", new LocaleKO(setting));
            AddLocaleSource("pl-PL", new LocalePL(setting));
            AddLocaleSource("pt-BR", new LocalePT_BR(setting));
            AddLocaleSource("zh-HANS", new LocaleZH_HANS(setting));
            AddLocaleSource("zh-HANT", new LocaleZH_HANT(setting));
            AddLocaleSource("th-TH", new LocaleTH(setting));       // Thai
            AddLocaleSource("vi-VN", new LocaleVI(setting));       // Vietnamese
            AddLocaleSource("tr-TR", new LocaleTR(setting));       // Turkish
            AddLocaleSource("pt-PT", new LocalePT_PT(setting));    // European Portuguese

            // In-city UI strings — loaded from lang/<locale>.json at the deployed mod folder.
            // Uses CO APIs: Colossal.Json.JSON.Load for parsing, Colossal.Localization.MemorySource
            // for the IDictionarySource. Each entry is registered under "CityWatchdog.UI.<Key>"
            // so React-side translate() picks it up for the active game language.
            LoadInCityUITranslations();

            try
            {
                AssetDatabase.global.LoadSettings(ModId, setting, new Setting(this));
            }
            catch (Exception ex)
            {
                LogUtils.Error(() => $"Settings load failed: {ex.GetType().Name}: {ex.Message}", ex);
            }

            try
            {
                setting.RegisterInOptionsUI();
            }
            catch (Exception ex)
            {
                LogUtils.Error(() => $"Options UI registration failed: {ex.GetType().Name}: {ex.Message}", ex);
            }

            try
            {
                setting.RegisterKeyBindings();
                EnableKeybinds(setting);
            }
            catch (Exception ex)
            {
                LogUtils.Error(() => $"Keybinding registration failed: {ex.GetType().Name}: {ex.Message}", ex);
            }

            try
            {
                ScheduleSystems(updateSystem);
            }
            catch (Exception ex)
            {
                LogUtils.Error(() => $"System scheduling failed: {ex.GetType().Name}: {ex.Message}", ex);
            }
        }

        public void OnDispose()
        {
            DebugLog(() => "Mod Dispose");

            Setting? setting = Settings;
            if (setting != null)
            {
                try
                {
                    setting.UnregisterInOptionsUI();
                }
                catch (Exception ex)
                {
                    LogUtils.Warn(() => $"UnregisterInOptionsUI failed: {ex.GetType().Name}: {ex.Message}", ex);
                }
            }

            Settings = null;
        }

        private static void ScheduleSystems(UpdateSystem updateSystem)
        {
            updateSystem.UpdateAt<CityFinanceSystem>(SystemUpdatePhase.ModificationEnd);
            updateSystem.UpdateAt<MilestoneSystem>(SystemUpdatePhase.ModificationEnd);
            updateSystem.UpdateAt<CityWatchdogUISystem>(SystemUpdatePhase.UIUpdate);
            updateSystem.UpdateAt<TooltipControlSystem>(SystemUpdatePhase.UIUpdate);
            updateSystem.UpdateAt<RoadNameControlSystem>(SystemUpdatePhase.UIUpdate);
            updateSystem.UpdateAt<RoadArrowControlSystem>(SystemUpdatePhase.UIUpdate);
            updateSystem.UpdateAt<AlertIconSystem>(SystemUpdatePhase.ModificationEnd);
        }


        private static void EnableKeybinds(Setting setting)
        {
            EnableAction(setting, Setting.AddMoneyAction);
            EnableAction(setting, Setting.SubtractMoneyAction);
            EnableAction(setting, Setting.ToggleNotificationsAction);
            EnableAction(setting, Setting.ToggleNotificationPanelAction);
            EnableAction(setting, Setting.ToggleRoadNamesAction);
            EnableAction(setting, Setting.ToggleAllTooltipsAction);
        }


        private static void EnableAction(Setting setting, string actionName)
        {
            try
            {
                ProxyAction action = setting.GetAction(actionName);
                if (action != null)
                {
                    action.shouldBeEnabled = true;
                }
            }
            catch (Exception ex)
            {
                LogUtils.Warn(() => $"Could not enable action '{actionName}': {ex.GetType().Name}: {ex.Message}", ex);
            }
        }

        private static void LogStartupBanner()
        {
            if (s_BannerLogged)
            {
                return;
            }

            s_BannerLogged = true;
            LogUtils.Info(() => $"{ModName} v{ModVersion} {ModTag} loaded");
        }

        // Scans the deployed lang/ folder for *.json files and registers every one as a
        // Colossal.Localization.MemorySource with the game's LocalizationManager. Each JSON
        // key gets the "CityWatchdog.UI." prefix so React-side translate("CityWatchdog.UI.Foo")
        // resolves through the active game locale. Uses CO APIs throughout per the API priority
        // rule: Colossal.Json.JSON.Load to parse, MemorySource for the IDictionarySource.
        //
        // Locale discovery is filesystem-based (scan *.json) rather than a hardcoded list, so
        // adding a new lang file to the source tree just works — no Mod.cs edit required.
        //
        // DELIBERATELY does NOT filter by localizationManager.GetSupportedLocales(). We support
        // unofficial locales (vi-VN, tr-TR, th-TH, pt-PT, ...) for players who use a third-party
        // locale-adder mod (I18N Everywhere, etc.) to put those languages in the game's dropdown.
        // When that mod adds e.g. vi-VN as active, the game finds our pre-registered MemorySource
        // and translates correctly. Without the locale-adder the extra sources sit unused —
        // harmless. Do NOT "helpfully" add a GetSupportedLocales filter; that would silently
        // break Vietnamese / Thai / Turkish / European-Portuguese players.
        private void LoadInCityUITranslations()
        {
            string langFolderPath = ResolveLangFolderPath();
            if (string.IsNullOrEmpty(langFolderPath))
            {
                LogUtils.Warn(() => "LoadInCityUITranslations: lang folder path empty; in-city UI will use English static fallback.");
                return;
            }

            bool langFolderExists;
            try
            {
                langFolderExists = Directory.Exists(langFolderPath);
            }
            catch (Exception ex)
            {
                LogUtils.Warn(() => $"LoadInCityUITranslations: Directory.Exists threw for '{langFolderPath}': {ex.GetType().Name}: {ex.Message}", ex);
                return;
            }

            if (!langFolderExists)
            {
                LogUtils.Warn(() => $"LoadInCityUITranslations: lang folder missing at '{langFolderPath}'.");
                return;
            }

            LocalizationManager? localizationManager = GameManager.instance?.localizationManager;
            if (localizationManager == null)
            {
                LogUtils.Warn(() => "LoadInCityUITranslations: no LocalizationManager available.");
                return;
            }

            string[] jsonFiles;
            try
            {
                jsonFiles = Directory.GetFiles(langFolderPath, "*.json");
            }
            catch (Exception ex)
            {
                LogUtils.Warn(() => $"LoadInCityUITranslations: Directory.GetFiles threw for '{langFolderPath}': {ex.GetType().Name}: {ex.Message}", ex);
                return;
            }

            int registered = 0;
            foreach (string jsonPath in jsonFiles)
            {
                string localeID = Path.GetFileNameWithoutExtension(jsonPath);
                try
                {
                    string raw = File.ReadAllText(jsonPath);
                    Variant variant = JSON.Load(raw);
                    Dictionary<string, string> translations = variant.Make<Dictionary<string, string>>();
                    if (translations == null || translations.Count == 0)
                    {
                        LogUtils.Warn(() => $"LoadInCityUITranslations: empty translations in '{jsonPath}'.");
                        continue;
                    }

                    Dictionary<string, string> prefixed = new Dictionary<string, string>(translations.Count);
                    foreach (KeyValuePair<string, string> entry in translations)
                    {
                        prefixed[$"CityWatchdog.UI.{entry.Key}"] = entry.Value;
                    }

                    localizationManager.AddSource(localeID, new MemorySource(prefixed));
                    registered++;
                }
                catch (Exception ex)
                {
                    LogUtils.Warn(() => $"LoadInCityUITranslations: failed loading '{jsonPath}': {ex.GetType().Name}: {ex.Message}", ex);
                }
            }

            LogUtils.Info(() => $"LoadInCityUITranslations: registered {registered}/{jsonFiles.Length} locale sources from '{langFolderPath}'.");
        }

        // Resolves the absolute path to the deployed <ModInstallDir>/lang/ folder.
        // Uses Colossal.PSI.Environment.EnvPath.kUserDataPath — the CO/CS2 API the game itself
        // uses (see Game.Debug, Game.Modding.Toolchain decompiled). This is the canonical
        // CS2-modding way to reach the user data root; csproj's <Content Include="lang\**">
        // deploys our JSONs under <kUserDataPath>\Mods\<ModId>\lang\.
        //
        // Never throws — returns empty string if anything fails. LoadInCityUITranslations handles
        // an empty path by skipping JSON load and letting the static en-US fallback in
        // localization.ts cover the player's UI.
        //
        // IMPORTANT: do NOT use Assembly.Location here. CS2 mod assemblies return a path that
        // crashes Path.GetDirectoryName with "Invalid path", which aborted OnLoad in v1.0.2.
        private string ResolveLangFolderPath()
        {
            try
            {
                string dataRoot = EnvPath.kUserDataPath;
                if (string.IsNullOrEmpty(dataRoot))
                {
                    return string.Empty;
                }
                return Path.Combine(dataRoot, "Mods", ModId, "lang");
            }
            catch (Exception ex)
            {
                LogUtils.Warn(() => $"ResolveLangFolderPath: path build failed: {ex.GetType().Name}: {ex.Message}", ex);
                return string.Empty;
            }
        }

        private static bool AddLocaleSource(string localeId, IDictionarySource source)
        {
            if (string.IsNullOrEmpty(localeId))
            {
                return false;
            }

            LocalizationManager? localizationManager = GameManager.instance?.localizationManager;
            if (localizationManager == null)
            {
                LogUtils.Warn(() => $"AddLocaleSource: No LocalizationManager; cannot add source for '{localeId}'.");
                return false;
            }

            try
            {
                localizationManager.AddSource(localeId, source);
                return true;
            }
            catch (Exception ex)
            {
                LogUtils.Warn(() => $"AddLocaleSource: AddSource for '{localeId}' failed: {ex.GetType().Name}: {ex.Message}", ex);
                return false;
            }
        }
    }
}
