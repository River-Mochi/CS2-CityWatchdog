// <copyright file="MilestoneDisplay.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the MIT License. You may not use this file except in compliance with this License.
// See LICENSE file in the project root for full license information.
// This notice and the MIT License notice must be kept with
// all copies or substantial portions of this code.
// ================= </copyright> ======================

// Purpose: Resolves game-localized milestone names for the City Watchdog milestone dropdown.

namespace CityWatchdog
{
    using System.Text;
    using Colossal.Localization;
    using Game.SceneFlow;

    internal static class MilestoneDisplay
    {
        public static string Get(int zeroBasedIndex, string fallbackInternalName)
        {
            int gameMilestoneNumber = zeroBasedIndex + 1;

            LocalizationManager? localizationManager = GameManager.instance?.localizationManager;
            LocalizationDictionary? dictionary = localizationManager?.activeDictionary;

            if (dictionary != null)
            {
                string? localized =
                    TryGet(dictionary, $"Progression.MILESTONE_NAME:{gameMilestoneNumber}") ??
                    TryGet(dictionary, $"PROGRESSION.MILESTONE_NAME:{gameMilestoneNumber}");

                if (localized is string text && !string.IsNullOrWhiteSpace(text))
                {
                    return text;
                }
            }

            return ToFriendlyFallback(fallbackInternalName, gameMilestoneNumber);
        }

        private static string? TryGet(LocalizationDictionary dictionary, string key)
        {
            if (dictionary.TryGetValue(key, out string value) &&
                !string.IsNullOrWhiteSpace(value) &&
                !value.Contains("MILESTONE_NAME"))
            {
                return value;
            }

            return null;
        }

        private static string ToFriendlyFallback(string fallbackInternalName, int gameMilestoneNumber)
        {
            if (string.IsNullOrWhiteSpace(fallbackInternalName))
            {
                return $"Milestone {gameMilestoneNumber}";
            }

            StringBuilder builder = new StringBuilder();

            for (int i = 0; i < fallbackInternalName.Length; i++)
            {
                char current = fallbackInternalName[i];

                if (i > 0 &&
                    char.IsUpper(current) &&
                    !char.IsWhiteSpace(fallbackInternalName[i - 1]))
                {
                    builder.Append(' ');
                }

                builder.Append(current);
            }

            return builder.ToString();
        }
    }
}
