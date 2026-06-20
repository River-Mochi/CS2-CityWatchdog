// <copyright file="InCityLocalization.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the MIT License. You may not use this file except in compliance with this License.
// See LICENSE file in the project root for full license info.
// ================= </copyright> ======================

// File: src/Localization/InCityLocalization.cs
// Purpose: Loads embedded in-city UI JSON translations into the game's LocalizationManager.
//
// Why embedded: the JSON bytes ride inside CityWatchdog.dll, so the loader does not need to
// resolve any filesystem path. Works identically for local-dev installs at
// <EnvPath.kUserDataPath>/Mods/CityWatchdog/ and PDX-subscribed installs at
// <EnvPath.kCacheDataPath>/Mods/pdx_mods/<asset_id>_<version>/. Eliminates the install-path
// failure modes that plagued v1.0.2 (Assembly.Location crash, hardcoded user-data path that
// silently missed subscribers).
//
// Source pattern: RoadRailSpeeds InCityLocalization.cs by River-Mochi (which itself adapted
// Algernon's LineTool embedded-CSV approach to JSON). See CS2ModdingTips/CS2-InCity-Localization-Pattern.md
// for the canonical River-Mochi mod localization recipe.
//
// DELIBERATELY does NOT filter by localizationManager.GetSupportedLocales(). The user supports
// unofficial locales (vi-VN, tr-TR, th-TH, pt-PT) for players using third-party locale-adder
// mods (I18N Everywhere, the Thai locale mod, the Turkish-style EXE patcher). Filtering would
// silently break those players. Register every embedded JSON; unused ones cost nothing.

namespace CityWatchdog
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using Colossal.Json;
    using Colossal.Localization;
    using Colossal.Logging;
    using Game.SceneFlow;

    internal static class InCityLocalization
    {
        private const string LangMarker = ".lang.";
        private const string JsonSuffix = ".json";

        // Reads embedded lang/*.json resources baked into this assembly and registers each as a
        // MemorySource on the game's LocalizationManager. Each JSON key is prefixed with
        // "<modId>.UI." to match the React-side translate() lookup pattern.
        public static void LoadEmbeddedJsonTranslations(string modId, string modTag, ILog log)
        {
            LocalizationManager? localizationManager = GameManager.instance?.localizationManager;
            if (localizationManager == null)
            {
                log.Warn($"{modTag} InCityLocalization: no LocalizationManager available.");
                return;
            }

            Assembly assembly = Assembly.GetExecutingAssembly();
            string[] resourceNames = assembly.GetManifestResourceNames()
                .Where(IsLangJsonResource)
                .OrderBy(static resourceName => resourceName, StringComparer.Ordinal)
                .ToArray();

            if (resourceNames.Length == 0)
            {
                log.Warn($"{modTag} InCityLocalization: no embedded lang/*.json resources found in '{assembly.GetName().Name}'.");
                return;
            }

            int registered = 0;
            foreach (string resourceName in resourceNames)
            {
                string localeId = GetLocaleId(resourceName);
                if (string.IsNullOrWhiteSpace(localeId))
                {
                    log.Warn($"{modTag} InCityLocalization: could not extract locale id from '{resourceName}'.");
                    continue;
                }

                try
                {
                    Dictionary<string, string> translations = ReadJsonResource(assembly, resourceName);
                    if (translations.Count == 0)
                    {
                        log.Warn($"{modTag} InCityLocalization: empty translations in '{resourceName}'.");
                        continue;
                    }

                    Dictionary<string, string> prefixed = new Dictionary<string, string>(translations.Count);
                    foreach (KeyValuePair<string, string> entry in translations)
                    {
                        if (!string.IsNullOrEmpty(entry.Value))
                        {
                            prefixed[$"{modId}.UI.{entry.Key}"] = entry.Value;
                        }
                    }

                    localizationManager.AddSource(localeId, new MemorySource(prefixed));
                    registered++;
                }
                catch (Exception ex)
                {
                    log.Warn($"{modTag} InCityLocalization: failed loading '{resourceName}': {ex.GetType().Name}: {ex.Message}");
                }
            }

            log.Info($"{modTag} InCityLocalization: registered {registered}/{resourceNames.Length} embedded locale sources.");
        }

        private static bool IsLangJsonResource(string resourceName)
        {
            return resourceName.IndexOf(LangMarker, StringComparison.Ordinal) >= 0
                && resourceName.EndsWith(JsonSuffix, StringComparison.OrdinalIgnoreCase);
        }

        // Resource names look like "CityWatchdog.lang.fr-FR.json" — pull out the "fr-FR" piece.
        private static string GetLocaleId(string resourceName)
        {
            int markerIndex = resourceName.LastIndexOf(LangMarker, StringComparison.Ordinal);
            if (markerIndex < 0 || !resourceName.EndsWith(JsonSuffix, StringComparison.OrdinalIgnoreCase))
            {
                return string.Empty;
            }

            int startIndex = markerIndex + LangMarker.Length;
            int length = resourceName.Length - startIndex - JsonSuffix.Length;
            return length <= 0 ? string.Empty : resourceName.Substring(startIndex, length);
        }

        private static Dictionary<string, string> ReadJsonResource(Assembly assembly, string resourceName)
        {
            using Stream? stream = assembly.GetManifestResourceStream(resourceName);
            if (stream == null)
            {
                return new Dictionary<string, string>();
            }

            using StreamReader reader = new StreamReader(stream);
            string raw = reader.ReadToEnd();
            Variant variant = JSON.Load(raw);
            return variant.Make<Dictionary<string, string>>() ?? new Dictionary<string, string>();
        }
    }
}
