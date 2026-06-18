// <copyright file="ElectricityNotificationIcon.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi.
// Licensed under the MIT License. See LICENSE file in the project root for full license information.
// </copyright>

// File: src/Data/ElectricityNotificationIcon.cs
// Purpose: Defines electricity notification icon identifiers used by City Watchdog.

namespace CityWatchdog.Data
{
    public enum ElectricityNotificationIcon
    {
        ElectricityNotification,
        BottleneckNotification,
        BuildingBottleneckNotification,
        NotEnoughProductionNotification,
        TransformerNotification,
        NotEnoughConnectedNotification,
        BatteryEmptyNotification,
        LowVoltageNotConnected,
        HighVoltageNotConnected,
    }
}
