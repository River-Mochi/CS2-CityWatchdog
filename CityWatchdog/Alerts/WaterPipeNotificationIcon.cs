// <copyright file="WaterPipeNotificationIcon.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the MIT License; you may not use this file except in compliance with this License.
// See LICENSE file in the project root for full license information.
// This notice and the MIT License notice must be kept with
// all copies or substantial portions of this code.
// ================= </copyright> ======================

// File: Alerts/WaterPipeNotificationIcon.cs
// Purpose: Defines water and sewage notification icon identifiers used by City Watchdog.

namespace CityWatchdog.Alerts
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
