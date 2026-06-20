// <copyright file="UIStringsJsonSource.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the MIT License. You may not use this file except in compliance with this License.
// See LICENSE file in the project root for full license information.
// This notice and the MIT License notice must be kept with
// all copies or substantial portions of this code.
// ================= </copyright> ======================

// File: src/Localization/UIStringsJsonSource.cs
// Purpose: Loads in-city UI translations from lang/<locale>.json and registers them with the
//   game's LocalizationManager under "CityWatchdog.UI.<Key>" so React-side translate() resolves
//   to the active game language. Single source of truth lives in lang/<locale>.json; the
//   translation tool keeps every language file aligned with en-US.json.

namespace CityWatchdog.Localization
{
    using Colossal;
    using CS2Shared.RiverMochi;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    using System.Text.RegularExpressions;

    public sealed class UIStringsJsonSource : IDictionarySource
    {
        private const string KeyPrefix = "CityWatchdog.UI";

        // Matches "<key>": "<value>" pairs in a flat JSON object. Both groups handle escaped
        // characters (\n, \", \\, etc.) without prematurely terminating on the inner quote.
        private static readonly Regex PairPattern = new Regex(
            "\"((?:[^\"\\\\]|\\\\.)*)\"\\s*:\\s*\"((?:[^\"\\\\]|\\\\.)*)\"",
            RegexOptions.Compiled);

        private readonly Dictionary<string, string> entries;

        public UIStringsJsonSource(string localeCode)
        {
            entries = new Dictionary<string, string>();
            string jsonPath = ResolveJsonPath(localeCode);

            if (string.IsNullOrEmpty(jsonPath) || !File.Exists(jsonPath))
            {
                LogUtils.Warn(() => $"UIStringsJsonSource: missing lang file for '{localeCode}' at '{jsonPath}'. UI text will fall back to en-US.");
                return;
            }

            try
            {
                string json = File.ReadAllText(jsonPath);
                foreach (Match match in PairPattern.Matches(json))
                {
                    string key = Unescape(match.Groups[1].Value);
                    string value = Unescape(match.Groups[2].Value);
                    entries[$"{KeyPrefix}.{key}"] = value;
                }
            }
            catch (Exception ex)
            {
                LogUtils.Warn(() => $"UIStringsJsonSource: parse failed for '{localeCode}': {ex.GetType().Name}: {ex.Message}", ex);
            }
        }

        public IEnumerable<KeyValuePair<string, string>> ReadEntries(
            IList<IDictionaryEntryError> errors,
            Dictionary<string, int> indexCounts)
        {
            return entries;
        }

        public void Unload()
        {
        }

        private static string ResolveJsonPath(string localeCode)
        {
            string assemblyDir = Path.GetDirectoryName(typeof(UIStringsJsonSource).Assembly.Location) ?? string.Empty;
            return Path.Combine(assemblyDir, "lang", $"{localeCode}.json");
        }

        // Character-by-character unescape so we never misfire on escaped backslashes.
        private static string Unescape(string s)
        {
            StringBuilder result = new StringBuilder(s.Length);
            for (int i = 0; i < s.Length; i++)
            {
                char c = s[i];
                if (c == '\\' && i + 1 < s.Length)
                {
                    char next = s[i + 1];
                    switch (next)
                    {
                        case 'n': result.Append('\n'); i++; break;
                        case 'r': result.Append('\r'); i++; break;
                        case 't': result.Append('\t'); i++; break;
                        case '"': result.Append('"'); i++; break;
                        case '/': result.Append('/'); i++; break;
                        case '\\': result.Append('\\'); i++; break;
                        default: result.Append(c); break;
                    }
                }
                else
                {
                    result.Append(c);
                }
            }
            return result.ToString();
        }
    }
}
