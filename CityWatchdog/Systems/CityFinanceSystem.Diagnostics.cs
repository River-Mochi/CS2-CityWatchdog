// <copyright file="CityFinanceSystem.Diagnostics.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi, MIT License.
// See LICENSE file in the project root for full license info.
// This copyright notice and the MIT License notice must be kept
// with all copies or substantial portions of this code.
// ================= </copyright> ======================

// File: src/Systems/CityFinanceSystem.Diagnostics.cs
// Purpose: Keeps optional City Watchdog money/city debug dumps separate from money actions.

namespace CityWatchdog.Systems
{
    using System.Text;

    public partial class CityFinanceSystem
    {
        public void ExportCurrentCityConfigurationInformation()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("---Current City Configuration Information---");
            stringBuilder.AppendLine($"{nameof(cityConfigurationSystem.cityName)}: {cityConfigurationSystem.cityName}");
            stringBuilder.AppendLine($"{nameof(cityConfigurationSystem.overrideCityName)}: {cityConfigurationSystem.overrideCityName}");
            stringBuilder.AppendLine($"{nameof(cityConfigurationSystem.leftHandTraffic)}: {cityConfigurationSystem.leftHandTraffic}");
            stringBuilder.AppendLine($"{nameof(cityConfigurationSystem.overrideLeftHandTraffic)}: {cityConfigurationSystem.overrideLeftHandTraffic}");
            stringBuilder.AppendLine($"{nameof(cityConfigurationSystem.naturalDisasters)}: {cityConfigurationSystem.naturalDisasters}");
            stringBuilder.AppendLine($"{nameof(cityConfigurationSystem.overrideNaturalDisasters)}: {cityConfigurationSystem.overrideNaturalDisasters}");
            stringBuilder.AppendLine($"{nameof(cityConfigurationSystem.unlockAll)}: {cityConfigurationSystem.unlockAll}");
            stringBuilder.AppendLine($"{nameof(cityConfigurationSystem.overrideUnlockAll)}: {cityConfigurationSystem.overrideUnlockAll}");
            stringBuilder.AppendLine($"{nameof(cityConfigurationSystem.unlimitedMoney)}: {cityConfigurationSystem.unlimitedMoney}");
            stringBuilder.AppendLine($"{nameof(cityConfigurationSystem.overrideUnlimitedMoney)}: {cityConfigurationSystem.overrideUnlimitedMoney}");
            stringBuilder.AppendLine($"{nameof(cityConfigurationSystem.unlockMapTiles)}: {cityConfigurationSystem.unlockMapTiles}");
            stringBuilder.AppendLine($"{nameof(cityConfigurationSystem.overrideUnlockMapTiles)}: {cityConfigurationSystem.overrideUnlockMapTiles}");
            stringBuilder.AppendLine($"{nameof(cityConfigurationSystem.overrideLoadedOptions)}: {cityConfigurationSystem.overrideLoadedOptions}");
            stringBuilder.AppendLine(string.Join(", ", cityConfigurationSystem.usedMods));
            stringBuilder.AppendLine("---End Current City Configuration Information---");

            CityWatchdog.Mod.DebugLog(() => stringBuilder.ToString());
        }
    }
}
