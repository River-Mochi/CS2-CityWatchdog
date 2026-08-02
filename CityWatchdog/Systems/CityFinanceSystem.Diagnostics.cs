// <copyright file="CityFinanceSystem.Diagnostics.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the MIT License. You may not use this file except in compliance with this License.
// See LICENSE file in the project root for full license information.
// This notice and the MIT License notice must be kept with
// all copies or substantial portions of this code.
// ================= </copyright> ======================

// File: Systems/CityFinanceSystem.Diagnostics.cs
// Purpose: Keeps optional City Watchdog money/city debug dumps separate from money actions.

namespace CityWatchdog.Systems
{
    using System.Text;

    public partial class CityFinanceSystem
    {
        public void ExportCurrentCityConfigurationInformation()
        {
            StringBuilder stringBuilder = new();
            stringBuilder.AppendLine("---Current City Configuration Information---");
            stringBuilder.AppendLine($"{nameof(m_CityConfigurationSystem.cityName)}: {m_CityConfigurationSystem.cityName}");
            stringBuilder.AppendLine($"{nameof(m_CityConfigurationSystem.overrideCityName)}: {m_CityConfigurationSystem.overrideCityName}");
            stringBuilder.AppendLine($"{nameof(m_CityConfigurationSystem.leftHandTraffic)}: {m_CityConfigurationSystem.leftHandTraffic}");
            stringBuilder.AppendLine($"{nameof(m_CityConfigurationSystem.overrideLeftHandTraffic)}: {m_CityConfigurationSystem.overrideLeftHandTraffic}");
            stringBuilder.AppendLine($"{nameof(m_CityConfigurationSystem.naturalDisasters)}: {m_CityConfigurationSystem.naturalDisasters}");
            stringBuilder.AppendLine($"{nameof(m_CityConfigurationSystem.overrideNaturalDisasters)}: {m_CityConfigurationSystem.overrideNaturalDisasters}");
            stringBuilder.AppendLine($"{nameof(m_CityConfigurationSystem.unlockAll)}: {m_CityConfigurationSystem.unlockAll}");
            stringBuilder.AppendLine($"{nameof(m_CityConfigurationSystem.overrideUnlockAll)}: {m_CityConfigurationSystem.overrideUnlockAll}");
            stringBuilder.AppendLine($"{nameof(m_CityConfigurationSystem.unlimitedMoney)}: {m_CityConfigurationSystem.unlimitedMoney}");
            stringBuilder.AppendLine($"{nameof(m_CityConfigurationSystem.overrideUnlimitedMoney)}: {m_CityConfigurationSystem.overrideUnlimitedMoney}");
            stringBuilder.AppendLine($"{nameof(m_CityConfigurationSystem.unlockMapTiles)}: {m_CityConfigurationSystem.unlockMapTiles}");
            stringBuilder.AppendLine($"{nameof(m_CityConfigurationSystem.overrideUnlockMapTiles)}: {m_CityConfigurationSystem.overrideUnlockMapTiles}");
            stringBuilder.AppendLine($"{nameof(m_CityConfigurationSystem.overrideLoadedOptions)}: {m_CityConfigurationSystem.overrideLoadedOptions}");
            stringBuilder.AppendLine(string.Join(", ", m_CityConfigurationSystem.usedMods));
            stringBuilder.AppendLine("---End Current City Configuration Information---");

        }
    }
}
