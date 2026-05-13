// File: DebugConsole/Localization/LocalizationUtils.cs
// Purpose: Loads debug-console localization source data from the output folder.

namespace DebugConsole.Localization
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text.Json;

    internal static class LocalizationUtils
    {
        public static Dictionary<string, string>? DeserializeLocalization()
        {
            string path = Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                "Localization",
                "EN.json");

            if (!File.Exists(path))
            {
                return null;
            }

            return JsonSerializer.Deserialize<Dictionary<string, string>>(File.ReadAllText(path));
        }
    }
}
