// <copyright file="CwdMilestoneSystem.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the MIT License. You may not use this file except in compliance with this License.
// See LICENSE file in the project root for full license information.
// This notice and the MIT License notice must be kept with
// all copies or substantial portions of this code.
// ================= </copyright> ======================

// File: Systems/City/CwdMilestoneSystem.cs
// Purpose: Applies the custom milestone setting to new or loaded cities.

namespace CityWatchdog.Systems
{
    using Colossal.Serialization.Entities;
    using CS2Shared.RiverMochi;
    using Game.City;
    using Game.Common;
    using Game.Prefabs;
    using Game.Simulation;
    using Unity.Collections;
    using Unity.Entities;
    using Unity.Mathematics;

    public partial class CwdMilestoneSystem : GameSystemBaseExtension
    {
        private EntityArchetype m_UnlockEventArchetype;
        private EntityQuery m_MilestoneLevelGroup;
        private EntityQuery m_MilestoneGroup;
        private CitySystem m_CitySystem = null!;

        protected override void OnCreate()
        {
            base.OnCreate();

            m_CitySystem =
                World.GetOrCreateSystemManaged<CitySystem>();

            // Use vanilla Unlock events so milestone rewards and side effects stay game-native.
            m_UnlockEventArchetype =
                EntityManager.CreateArchetype(
                    new ComponentType[]
                    {
                        ComponentType.ReadWrite<Event>(),
                        ComponentType.ReadWrite<Unlock>(),
                    });

            m_MilestoneLevelGroup =
                GetEntityQuery(
                    new ComponentType[]
                    {
                        ComponentType.ReadWrite<MilestoneLevel>(),
                    });

            m_MilestoneGroup =
                GetEntityQuery(
                    new ComponentType[]
                    {
                        ComponentType.ReadOnly<MilestoneData>(),
                    });

            RequireForUpdate(m_MilestoneLevelGroup);
            RequireForUpdate(m_MilestoneGroup);
        }

        protected override void OnGameLoaded(
            Context serializationContext)
        {
            base.OnGameLoaded(serializationContext);

            if (InGame)
            {
                ApplyConfiguredMilestone();
            }
        }

        private void ApplyConfiguredMilestone()
        {
            if (!CwdSettings.Instance.CustomMilestone)
            {
                return;
            }

            NativeArray<Entity> milestoneEntities =
                m_MilestoneGroup.ToEntityArray(
                    Allocator.TempJob);

            NativeArray<MilestoneData> milestoneData =
                m_MilestoneGroup.ToComponentDataArray<MilestoneData>(
                    Allocator.TempJob);

            try
            {
                MilestoneLevel milestoneLevel =
                    m_MilestoneLevelGroup
                        .GetSingleton<MilestoneLevel>();

                if (!TryGetTargetMilestone(
                        milestoneEntities,
                        milestoneLevel,
                        out int targetMilestone))
                {
                    return;
                }

                PlayerMoney playerMoney =
                    EntityManager.GetComponentData<PlayerMoney>(
                        m_CitySystem.City);

                Creditworthiness creditworthiness =
                    EntityManager.GetComponentData<Creditworthiness>(
                        m_CitySystem.City);

                DevTreePoints devTreePoints =
                    EntityManager.GetComponentData<DevTreePoints>(
                        m_CitySystem.City);

                XP xp =
                    EntityManager.GetComponentData<XP>(
                        m_CitySystem.City);

                // Apply every skipped milestone so jumping several levels keeps rewards consistent.
                for (int i = milestoneLevel.m_AchievedMilestone;
                     i < targetMilestone;
                     i++)
                {
                    QueueMilestoneUnlock(
                        milestoneEntities[i]);

                    milestoneLevel.m_AchievedMilestone =
                        math.max(
                            milestoneLevel.m_AchievedMilestone,
                            milestoneData[i].m_Index);

                    ApplyMilestoneRewards(
                        milestoneData[i],
                        ref playerMoney,
                        ref creditworthiness,
                        ref devTreePoints,
                        ref xp);
                }

                m_MilestoneLevelGroup.SetSingleton(
                    milestoneLevel);

                EntityManager.SetComponentData(
                    m_CitySystem.City,
                    playerMoney);

                EntityManager.SetComponentData(
                    m_CitySystem.City,
                    creditworthiness);

                EntityManager.SetComponentData(
                    m_CitySystem.City,
                    devTreePoints);

                EntityManager.SetComponentData(
                    m_CitySystem.City,
                    xp);

                LogUtils.Info(
                    () =>
                        $"Unlock level " +
                        $"{CwdSettings.Instance.MilestoneLevel + 1} " +
                        "Milestone");
            }
            finally
            {
                if (milestoneEntities.IsCreated)
                {
                    milestoneEntities.Dispose();
                }

                if (milestoneData.IsCreated)
                {
                    milestoneData.Dispose();
                }
            }
        }

        private static bool TryGetTargetMilestone(
            NativeArray<Entity> milestoneEntities,
            MilestoneLevel currentMilestone,
            out int targetMilestone)
        {
            targetMilestone =
                math.min(
                    CwdSettings.Instance.MilestoneLevel + 1,
                    milestoneEntities.Length);

            return
                currentMilestone.m_AchievedMilestone <
                targetMilestone;
        }

        private void QueueMilestoneUnlock(
            Entity milestoneEntity)
        {
            Entity entity =
                EntityManager.CreateEntity(
                    m_UnlockEventArchetype);

            EntityManager.SetComponentData(
                entity,
                new Unlock(milestoneEntity));
        }

        private static void ApplyMilestoneRewards(
            MilestoneData milestoneData,
            ref PlayerMoney playerMoney,
            ref Creditworthiness creditworthiness,
            ref DevTreePoints devTreePoints,
            ref XP xp)
        {
            playerMoney.Add(
                milestoneData.m_Reward);

            creditworthiness.m_Amount +=
                milestoneData.m_LoanLimit;

            devTreePoints.m_Points +=
                milestoneData.m_DevTreePoints;

            xp.m_XP =
                milestoneData.m_XpRequried;
        }
    }
}
