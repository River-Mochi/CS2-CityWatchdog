// <copyright file="AlertIconSystem.Counts.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the MIT License. You may not use this file except in compliance with this License.
// See LICENSE file in the project root for full license information.
// This notice and the MIT License notice must be kept with
// all copies or substantial portions of this code.
// ================= </copyright> ======================

// File: src/Systems/AlertIconSystem.Counts.cs
// Purpose: Counts active vanilla notification icon entities for the expanded CWD rows.

namespace CityWatchdog.Systems
{
    using System.Collections.Generic;
    using CS2Shared.RiverMochi;
    using Game.Economy;
    using Game.Prefabs;
    using Unity.Collections;
    using Unity.Entities;

    public partial class AlertIconSystem
    {
        public const int NotificationCountLength = 62;

        public int[] GetNotificationCounts()
        {
            BuildActiveIconCounts();

            int[] counts = new int[NotificationCountLength];
            int index = 0;

            if (electricityParameterQuery.TryGetSingleton(out ElectricityParameterData electricity))
            {
                counts[index++] = Count(electricity.m_ElectricityNotificationPrefab);
                counts[index++] = Count(electricity.m_BottleneckNotificationPrefab);
                counts[index++] = Count(electricity.m_BuildingBottleneckNotificationPrefab);
                counts[index++] = Count(electricity.m_NotEnoughProductionNotificationPrefab);
                counts[index++] = Count(electricity.m_TransformerNotificationPrefab);
                counts[index++] = Count(electricity.m_NotEnoughConnectedNotificationPrefab);
                counts[index++] = Count(electricity.m_BatteryEmptyNotificationPrefab);
                counts[index++] = Count(electricity.m_LowVoltageNotConnectedPrefab);
                counts[index++] = Count(electricity.m_HighVoltageNotConnectedPrefab);
            }
            else
            {
                index += 9;
            }

            if (waterPipeParameterQuery.TryGetSingleton(out WaterPipeParameterData water))
            {
                counts[index++] = Count(water.m_WaterNotification);
                counts[index++] = Count(water.m_DirtyWaterNotification);
                counts[index++] = Count(water.m_SewageNotification);
                counts[index++] = Count(water.m_WaterPipeNotConnectedNotification);
                counts[index++] = Count(water.m_SewagePipeNotConnectedNotification);
                counts[index++] = Count(water.m_NotEnoughWaterCapacityNotification);
                counts[index++] = Count(water.m_NotEnoughSewageCapacityNotification);
                counts[index++] = Count(water.m_NotEnoughGroundwaterNotification);
                counts[index++] = Count(water.m_NotEnoughSurfaceWaterNotification);
                counts[index++] = Count(water.m_DirtyWaterPumpNotification);
            }
            else
            {
                index += 10;
            }

            if (buildingConfigurationDataQuery.TryGetSingleton(out BuildingConfigurationData building))
            {
                counts[index++] = Count(building.m_AbandonedCollapsedNotification);
                counts[index++] = Count(building.m_AbandonedNotification);
                counts[index++] = Count(building.m_CondemnedNotification);
                counts[index++] = Count(building.m_TurnedOffNotification);
                counts[index++] = Count(building.m_HighRentNotification);
            }
            else
            {
                index += 5;
            }

            if (trafficConfigurationDataQuery.TryGetSingleton(out TrafficConfigurationData traffic))
            {
                counts[index++] = Count(traffic.m_BottleneckNotification);
                counts[index++] = Count(traffic.m_DeadEndNotification);
                counts[index++] = Count(traffic.m_RoadConnectionNotification);
                counts[index++] = Count(traffic.m_TrackConnectionNotification);
                counts[index++] = Count(traffic.m_CarConnectionNotification);
                counts[index++] = Count(traffic.m_ShipConnectionNotification);
                counts[index++] = Count(traffic.m_TrainConnectionNotification);
                counts[index++] = Count(traffic.m_PedestrianConnectionNotification);
                counts[index++] = Count(traffic.m_BicycleConnectionNotification);
            }
            else
            {
                index += 9;
            }

            if (companyNotificationParameterQuery.TryGetSingleton(out CompanyNotificationParameterData company))
            {
                counts[index++] = Count(company.m_NoInputsNotificationPrefab);
                counts[index++] = Count(company.m_NoCustomersNotificationPrefab);
            }
            else
            {
                index += 2;
            }

            if (workProviderNotificationParameterQuery.TryGetSingleton(out WorkProviderParameterData workProvider))
            {
                counts[index++] = Count(workProvider.m_UneducatedNotificationPrefab);
                counts[index++] = Count(workProvider.m_EducatedNotificationPrefab);
            }
            else
            {
                index += 2;
            }

            if (disasterNotificationParameterQuery.TryGetSingleton(out DisasterConfigurationData disaster))
            {
                counts[index++] = Count(disaster.m_WeatherDamageNotificationPrefab);
                counts[index++] = Count(disaster.m_WeatherDestroyedNotificationPrefab);
                counts[index++] = Count(disaster.m_WaterDamageNotificationPrefab);
                counts[index++] = Count(disaster.m_WaterDestroyedNotificationPrefab);
                counts[index++] = Count(disaster.m_DestroyedNotificationPrefab);
            }
            else
            {
                index += 5;
            }

            if (fireNotificationParameterQuery.TryGetSingleton(out FireConfigurationData fire))
            {
                counts[index++] = Count(fire.m_FireNotificationPrefab);
                counts[index++] = Count(fire.m_BurnedDownNotificationPrefab);
            }
            else
            {
                index += 2;
            }

            if (garbageNotificationParameterQuery.TryGetSingleton(out GarbageParameterData garbage))
            {
                counts[index++] = Count(garbage.m_GarbageNotificationPrefab);
                counts[index++] = Count(garbage.m_FacilityFullNotificationPrefab);
            }
            else
            {
                index += 2;
            }

            if (healthcareNotificationParameterQuery.TryGetSingleton(out HealthcareParameterData healthcare))
            {
                counts[index++] = Count(healthcare.m_AmbulanceNotificationPrefab);
                counts[index++] = Count(healthcare.m_HearseNotificationPrefab);
                counts[index++] = Count(healthcare.m_FacilityFullNotificationPrefab);
            }
            else
            {
                index += 3;
            }

            if (policeNotificationParameterQuery.TryGetSingleton(out PoliceConfigurationData police))
            {
                counts[index++] = Count(police.m_TrafficAccidentNotificationPrefab);
                counts[index++] = Count(police.m_CrimeSceneNotificationPrefab);
            }
            else
            {
                index += 2;
            }

            if (pollutionNotificationParameterQuery.TryGetSingleton(out PollutionParameterData pollution))
            {
                counts[index++] = Count(pollution.m_AirPollutionNotification);
                counts[index++] = Count(pollution.m_NoisePollutionNotification);
                counts[index++] = Count(pollution.m_GroundPollutionNotification);
            }
            else
            {
                index += 3;
            }

            CountResourceConsumerNotifications(out int lowSuppliesCount, out int noFuelCount);
            counts[index++] = lowSuppliesCount;
            counts[index++] = noFuelCount;

            CountResourceConnectionNotifications(
                out int oilPipeCount,
                out int fishingPierCount,
                out int otherConnectionCount);
            counts[index++] = oilPipeCount;
            counts[index++] = fishingPierCount;
            counts[index++] = otherConnectionCount;

            if (routeNotificationParameterQuery.TryGetSingleton(out RouteConfigurationData route))
            {
                counts[index++] = Count(route.m_PathfindNotification);
                counts[index++] = Count(route.m_GateBypassNotification);
            }
            else
            {
                index += 2;
            }

            if (transportLineNotificationParameterQuery.TryGetSingleton(out TransportLineData transport))
            {
                counts[index++] = Count(transport.m_VehicleNotification);
            }
            else
            {
                index++;
            }

#if DEBUG
            if (index != NotificationCountLength)
            {
                LogUtils.Debug(() => $"Notification count mapping length mismatch: expected={NotificationCountLength}, actual={index}.");
            }
#endif

            return counts;
        }

        private void BuildActiveIconCounts()
        {
            EntityDictionary.Clear();

            ComponentTypeHandle<PrefabRef> prefabRefTypeHandle = GetComponentTypeHandle<PrefabRef>(true);
            using NativeArray<ArchetypeChunk> chunks = iconQuery.ToArchetypeChunkArray(Allocator.TempJob);

            for (int i = 0; i < chunks.Length; i++)
            {
                NativeArray<PrefabRef> prefabRefs = chunks[i].GetNativeArray(ref prefabRefTypeHandle);
                for (int j = 0; j < prefabRefs.Length; j++)
                {
                    Entity prefab = prefabRefs[j].m_Prefab;
                    EntityDictionary.TryGetValue(prefab, out int count);
                    EntityDictionary[prefab] = count + 1;
                }
            }
        }

        private int Count(Entity prefab)
        {
            return prefab != Entity.Null && EntityDictionary.TryGetValue(prefab, out int count)
                ? count
                : 0;
        }

        private void CountResourceConsumerNotifications(
            out int lowSuppliesCount,
            out int noFuelCount)
        {
            lowSuppliesCount = 0;
            noFuelCount = 0;
            HashSet<Entity> seen = new();
            using NativeArray<ResourceConsumerData> consumers =
                resourceConsumerNotificationParameterQuery.ToComponentDataArray<ResourceConsumerData>(Allocator.Temp);

            for (int i = 0; i < consumers.Length; i++)
            {
                Entity prefab = consumers[i].m_NoResourceNotificationPrefab;
                if (!seen.Add(prefab))
                {
                    continue;
                }

                if (IsLowSuppliesNotificationPrefab(prefab))
                {
                    lowSuppliesCount += Count(prefab);
                }

                if (IsNoFuelNotificationPrefab(prefab))
                {
                    noFuelCount += Count(prefab);
                }
            }
        }

        private void CountResourceConnectionNotifications(
            out int oilPipeCount,
            out int fishingPierCount,
            out int otherConnectionCount)
        {
            oilPipeCount = 0;
            fishingPierCount = 0;
            otherConnectionCount = 0;
            HashSet<Entity> seen = new();
            using NativeArray<ResourceConnectionData> connections =
                resourceConnectionNotificationParameterQuery.ToComponentDataArray<ResourceConnectionData>(Allocator.Temp);

            for (int i = 0; i < connections.Length; i++)
            {
                ResourceConnectionData connection = connections[i];
                Entity prefab = connection.m_ConnectionWarningNotification;
                if (!seen.Add(prefab))
                {
                    continue;
                }

                bool isOilPipe = IsOilPipeNotConnectedNotification(connection);
                bool isFishingPier = IsFishingPierNotConnectedNotification(connection);
                if (isOilPipe)
                {
                    oilPipeCount += Count(prefab);
                }

                if (isFishingPier)
                {
                    fishingPierCount += Count(prefab);
                }

                if (!isOilPipe && !isFishingPier)
                {
                    otherConnectionCount += Count(prefab);
                }
            }
        }
    }
}
