// <copyright file="WaterPipeNotificationIcon.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi.
// Licensed under the MIT License. See LICENSE file in the project root for full license information.
// </copyright>

// File: src/Data/WaterPipeNotificationIcon.cs
// Purpose: Defines water and sewage notification icon identifiers used by City Watchdog.

namespace CityWatchdog.Data
{
    public enum WaterPipeNotificationIcon
    {
        WaterNotification,
        DirtyWaterNotification,
        SewageNotification,
        WaterPipeNotConnectedNotification,
        SewagePipeNotConnectedNotification,
        NotEnoughWaterCapacityNotification,
        NotEnoughSewageCapacityNotification,
        NotEnoughGroundwaterNotification,
        NotEnoughSurfaceWaterNotification,
        DirtyWaterPumpNotification,
    }
}
