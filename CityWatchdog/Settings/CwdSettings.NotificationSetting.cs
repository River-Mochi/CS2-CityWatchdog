// <copyright file="CwdSettings.NotificationSetting.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the MIT License. You may not use this file except in compliance with this License.
// See LICENSE file in the project root for full license information.
// This notice and the MIT License notice must be kept with
// all copies or substantial portions of this code.
// ================= </copyright> ======================

// File: src/Settings/CwdSettings.NotificationSetting.cs
// Purpose: Contains City Watchdog settings and Options UI logic.

namespace CityWatchdog
{
    public partial class CwdSettings {
        public NotificationSetting Notification { get; set; } = new NotificationSetting();

        public class NotificationSetting {
            public bool ElectricityElectricityNotification { get; set; }
            public bool ElectricityBottleneckNotification { get; set; }
            public bool ElectricityBuildingBottleneckNotification { get; set; }
            public bool ElectricityNotEnoughProductionNotification { get; set; }
            public bool ElectricityTransformerNotification { get; set; }
            public bool ElectricityNotEnoughConnectedNotification { get; set; }
            public bool ElectricityBatteryEmptyNotification { get; set; }
            public bool ElectricityLowVoltageNotConnected { get; set; }
            public bool ElectricityHighVoltageNotConnected { get; set; }


            public bool WaterPipeWaterNotification { get; set; }
            public bool WaterPipeDirtyWaterNotification { get; set; }
            public bool WaterPipeSewageNotification { get; set; }
            public bool WaterPipeWaterPipeNotConnectedNotification { get; set; }
            public bool WaterPipeSewagePipeNotConnectedNotification { get; set; }
            public bool WaterPipeNotEnoughWaterCapacityNotification { get; set; }
            public bool WaterPipeNotEnoughSewageCapacityNotification { get; set; }
            public bool WaterPipeNotEnoughGroundwaterNotification { get; set; }
            public bool WaterPipeNotEnoughSurfaceWaterNotification { get; set; }
            public bool WaterPipeDirtyWaterPumpNotification { get; set; }

            public bool BuildingAbandonedCollapsedNotification { get; set; }
            public bool BuildingAbandonedNotification { get; set; }
            public bool BuildingCondemnedNotification { get; set; }
            public bool BuildingTurnedOffNotification { get; set; }
            public bool BuildingHighRentNotification { get; set; }
            public bool BuildingLevelingNotification { get; set; }

            public bool TrafficBottleneckNotification { get; set; }
            public bool TrafficDeadEndNotification { get; set; }
            public bool TrafficRoadConnectionNotification { get; set; }
            public bool TrafficTrackConnectionNotification { get; set; }
            public bool TrafficCarConnectionNotification { get; set; }
            public bool TrafficShipConnectionNotification { get; set; }
            public bool TrafficTrainConnectionNotification { get; set; }
            public bool TrafficPedestrianConnectionNotification { get; set; }
            public bool TrafficBicycleConnectionNotification { get; set; }
        
            public bool CompanyNoInputsNotification { get; set; }
            public bool CompanyNoCustomersNotification { get; set; }

            public bool WorkProviderUneducatedNotification { get; set; }
            public bool WorkProviderEducatedNotification { get; set; }

            public bool DisasterWeatherDamageNotification { get; set; }
            public bool DisasterWeatherDestroyedNotification { get; set; }
            public bool DisasterWaterDamageNotification { get; set; }
            public bool DisasterWaterDestroyedNotification { get; set; }
            public bool DisasterDestroyedNotification { get; set; }

            public bool FireFireNotification { get; set; }
            public bool FireBurnedDownNotification { get; set; }

            public bool GarbageGarbageNotification { get; set; }
            public bool GarbageFacilityFullNotification { get; set; }

            public bool HealthcareAmbulanceNotification { get; set; }
            public bool HealthcareHearseNotification { get; set; }
            public bool HealthcareFacilityFullNotification { get; set; }

            public bool PoliceTrafficAccidentNotification { get; set; }
            public bool PoliceCrimeSceneNotification { get; set; }

            public bool PollutionAirPollutionNotification { get; set; }
            public bool PollutionNoisePollutionNotification { get; set; }
            public bool PollutionGroundPollutionNotification { get; set; }

            public bool ResourceConsumerNoResourceNotification { get; set; }
            public bool ResourceConsumerNoFuelNotification { get; set; }

            public bool ResourceConnectionWarningNotification { get; set; }
            public bool ResourceConnectionOilPipeNotConnectedNotification { get; set; }
            public bool ResourceConnectionFishingPierNotConnectedNotification { get; set; }

            public bool RoutePathfindNotification { get; set; }
            public bool RouteGateBypassNotification { get; set; }

            public bool TransportLineVehicleNotification { get; set; }

            // Copies every notification flag from another snapshot. Used by the in-city preset slots
            // (save = copy live -> preset; load = copy preset -> live). Unlike SHOW ICONS, a preset
            // captures the player's EXACT layout, so BuildingLevelingNotification (the optional row)
            // IS included here. Keep this list complete whenever notifications are added.
            public void CopyFrom(NotificationSetting other) {
                ElectricityElectricityNotification = other.ElectricityElectricityNotification;
                ElectricityBottleneckNotification = other.ElectricityBottleneckNotification;
                ElectricityBuildingBottleneckNotification = other.ElectricityBuildingBottleneckNotification;
                ElectricityNotEnoughProductionNotification = other.ElectricityNotEnoughProductionNotification;
                ElectricityTransformerNotification = other.ElectricityTransformerNotification;
                ElectricityNotEnoughConnectedNotification = other.ElectricityNotEnoughConnectedNotification;
                ElectricityBatteryEmptyNotification = other.ElectricityBatteryEmptyNotification;
                ElectricityLowVoltageNotConnected = other.ElectricityLowVoltageNotConnected;
                ElectricityHighVoltageNotConnected = other.ElectricityHighVoltageNotConnected;

                WaterPipeWaterNotification = other.WaterPipeWaterNotification;
                WaterPipeDirtyWaterNotification = other.WaterPipeDirtyWaterNotification;
                WaterPipeSewageNotification = other.WaterPipeSewageNotification;
                WaterPipeWaterPipeNotConnectedNotification = other.WaterPipeWaterPipeNotConnectedNotification;
                WaterPipeSewagePipeNotConnectedNotification = other.WaterPipeSewagePipeNotConnectedNotification;
                WaterPipeNotEnoughWaterCapacityNotification = other.WaterPipeNotEnoughWaterCapacityNotification;
                WaterPipeNotEnoughSewageCapacityNotification = other.WaterPipeNotEnoughSewageCapacityNotification;
                WaterPipeNotEnoughGroundwaterNotification = other.WaterPipeNotEnoughGroundwaterNotification;
                WaterPipeNotEnoughSurfaceWaterNotification = other.WaterPipeNotEnoughSurfaceWaterNotification;
                WaterPipeDirtyWaterPumpNotification = other.WaterPipeDirtyWaterPumpNotification;

                BuildingAbandonedCollapsedNotification = other.BuildingAbandonedCollapsedNotification;
                BuildingAbandonedNotification = other.BuildingAbandonedNotification;
                BuildingCondemnedNotification = other.BuildingCondemnedNotification;
                BuildingTurnedOffNotification = other.BuildingTurnedOffNotification;
                BuildingHighRentNotification = other.BuildingHighRentNotification;
                BuildingLevelingNotification = other.BuildingLevelingNotification;

                TrafficBottleneckNotification = other.TrafficBottleneckNotification;
                TrafficDeadEndNotification = other.TrafficDeadEndNotification;
                TrafficRoadConnectionNotification = other.TrafficRoadConnectionNotification;
                TrafficTrackConnectionNotification = other.TrafficTrackConnectionNotification;
                TrafficCarConnectionNotification = other.TrafficCarConnectionNotification;
                TrafficShipConnectionNotification = other.TrafficShipConnectionNotification;
                TrafficTrainConnectionNotification = other.TrafficTrainConnectionNotification;
                TrafficPedestrianConnectionNotification = other.TrafficPedestrianConnectionNotification;
                TrafficBicycleConnectionNotification = other.TrafficBicycleConnectionNotification;

                CompanyNoInputsNotification = other.CompanyNoInputsNotification;
                CompanyNoCustomersNotification = other.CompanyNoCustomersNotification;

                WorkProviderUneducatedNotification = other.WorkProviderUneducatedNotification;
                WorkProviderEducatedNotification = other.WorkProviderEducatedNotification;

                DisasterWeatherDamageNotification = other.DisasterWeatherDamageNotification;
                DisasterWeatherDestroyedNotification = other.DisasterWeatherDestroyedNotification;
                DisasterWaterDamageNotification = other.DisasterWaterDamageNotification;
                DisasterWaterDestroyedNotification = other.DisasterWaterDestroyedNotification;
                DisasterDestroyedNotification = other.DisasterDestroyedNotification;

                FireFireNotification = other.FireFireNotification;
                FireBurnedDownNotification = other.FireBurnedDownNotification;

                GarbageGarbageNotification = other.GarbageGarbageNotification;
                GarbageFacilityFullNotification = other.GarbageFacilityFullNotification;

                HealthcareAmbulanceNotification = other.HealthcareAmbulanceNotification;
                HealthcareHearseNotification = other.HealthcareHearseNotification;
                HealthcareFacilityFullNotification = other.HealthcareFacilityFullNotification;

                PoliceTrafficAccidentNotification = other.PoliceTrafficAccidentNotification;
                PoliceCrimeSceneNotification = other.PoliceCrimeSceneNotification;

                PollutionAirPollutionNotification = other.PollutionAirPollutionNotification;
                PollutionNoisePollutionNotification = other.PollutionNoisePollutionNotification;
                PollutionGroundPollutionNotification = other.PollutionGroundPollutionNotification;

                ResourceConsumerNoResourceNotification = other.ResourceConsumerNoResourceNotification;
                ResourceConsumerNoFuelNotification = other.ResourceConsumerNoFuelNotification;
                ResourceConnectionWarningNotification = other.ResourceConnectionWarningNotification;
                ResourceConnectionOilPipeNotConnectedNotification = other.ResourceConnectionOilPipeNotConnectedNotification;
                ResourceConnectionFishingPierNotConnectedNotification = other.ResourceConnectionFishingPierNotConnectedNotification;

                RoutePathfindNotification = other.RoutePathfindNotification;
                RouteGateBypassNotification = other.RouteGateBypassNotification;

                TransportLineVehicleNotification = other.TransportLineVehicleNotification;
            }

            public void SetDefaults() {
                ElectricityElectricityNotification = true;
                ElectricityBottleneckNotification = true;
                ElectricityBuildingBottleneckNotification = true;
                ElectricityNotEnoughProductionNotification = true;
                ElectricityTransformerNotification = true;
                ElectricityNotEnoughConnectedNotification = true;
                ElectricityBatteryEmptyNotification = true;
                ElectricityLowVoltageNotConnected = true;
                ElectricityHighVoltageNotConnected = true;

                WaterPipeWaterNotification = true;
                WaterPipeDirtyWaterNotification = true;
                WaterPipeSewageNotification = true;
                WaterPipeWaterPipeNotConnectedNotification = true;
                WaterPipeSewagePipeNotConnectedNotification = true;
                WaterPipeNotEnoughWaterCapacityNotification = true;
                WaterPipeNotEnoughSewageCapacityNotification = true;
                WaterPipeNotEnoughGroundwaterNotification = true;
                WaterPipeNotEnoughSurfaceWaterNotification = true;
                WaterPipeDirtyWaterPumpNotification = true;

                BuildingAbandonedCollapsedNotification = true;
                BuildingAbandonedNotification = true;
                BuildingCondemnedNotification = true;
                BuildingTurnedOffNotification = true;
                BuildingHighRentNotification = true;
                BuildingLevelingNotification = false;   // OFF by default to match vanilla (hidden unless opted in).

                TrafficBottleneckNotification = true;
                TrafficDeadEndNotification = true;
                TrafficRoadConnectionNotification = true;
                TrafficTrackConnectionNotification = true;
                TrafficCarConnectionNotification = true;
                TrafficShipConnectionNotification = true;
                TrafficTrainConnectionNotification = true;
                TrafficPedestrianConnectionNotification = true;
                TrafficBicycleConnectionNotification = true;
            
                CompanyNoInputsNotification = true;
                CompanyNoCustomersNotification = true;

                WorkProviderUneducatedNotification = true;
                WorkProviderEducatedNotification = true;

                DisasterWeatherDamageNotification = true;
                DisasterWeatherDestroyedNotification = true;
                DisasterWaterDamageNotification = true;
                DisasterWaterDestroyedNotification = true;
                DisasterDestroyedNotification = true;

                FireFireNotification = true;
                FireBurnedDownNotification = true;

                GarbageGarbageNotification = true;
                GarbageFacilityFullNotification = true;

                HealthcareAmbulanceNotification = true;
                HealthcareHearseNotification = true;
                HealthcareFacilityFullNotification = true;

                PoliceTrafficAccidentNotification = true;
                PoliceCrimeSceneNotification = true;

                PollutionAirPollutionNotification = true;
                PollutionNoisePollutionNotification = true;
                PollutionGroundPollutionNotification = true;

                ResourceConsumerNoResourceNotification = true;
                ResourceConsumerNoFuelNotification = true;
                ResourceConnectionWarningNotification = true;
                ResourceConnectionOilPipeNotConnectedNotification = true;
                ResourceConnectionFishingPierNotConnectedNotification = true;

                RoutePathfindNotification = true;
                RouteGateBypassNotification = true;

                TransportLineVehicleNotification = true;
            }
        }
    }

}
