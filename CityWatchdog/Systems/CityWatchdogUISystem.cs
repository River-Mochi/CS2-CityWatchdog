// <copyright file="CityWatchdogUISystem.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the MIT License. You may not use this file except in compliance with this License.
// See LICENSE file in the project root for full license information.
// This notice and the MIT License notice must be kept with
// all copies or substantial portions of this code.
// ================= </copyright> ======================

// File: Systems/CityWatchdogUISystem.cs
// Purpose: Keeps CWD settings, game systems, React panel, and mini HUD in sync.

namespace CityWatchdog.Systems
{
    using System;
    using CityWatchdog.Alerts;
    using Colossal.Serialization.Entities;
    using Colossal.UI.Binding;
    using CS2Shared.RiverMochi;
    using Game;
    using Game.Input;
    using Game.Rendering;
    using Game.SceneFlow;
    using Game.Tools;
    using Game.UI;
    using Unity.Entities;

    public partial class CityWatchdogUISystem : UISystemBaseExtension {
        // Only the open panel or mini HUD scans.
        // Opening the panel or loading a city refreshes right away.
        private const int kPanelCountUpdateInterval = 256;      // Lower = faster updates, more work.
        private const int kMiniHudCountUpdateInterval = 256;    // 256 is ~4 sec at normal speed.

        private readonly int[] m_LastNotificationCounts = new int[AlertIconSystem.NotificationCountLength];
        private bool m_HasLastNotificationCounts;

        private AlertIconSystem m_AlertIconSystem = null!;
        private ProxyAction? m_ToggleNotificationsAction;
        private ProxyAction? m_ToggleNotificationPanelAction;
        private BoolBinding m_PanelVisibleBinding = null!;
        private UIUpdateState m_NotificationCountUpdateState = null!;
        private UIUpdateState m_MiniHudCountUpdateState = null!;
        private ValueBinding<int[]> m_NotificationCountsBinding = null!;
        private ValueBinding<int[]> m_MiniHudFavoritesBinding = null!;
        private ValueBinding<bool> m_MiniHudEnabledBinding = null!;
        private ValueBinding<int> m_MiniHudModeBinding = null!;
        private ValueBinding<int> m_MiniHudItemCountBinding = null!;
        private ValueBinding<int> m_MiniHudScaleBinding = null!;
        private ValueBinding<int> m_MiniHudOrientationBinding = null!;
        private ValueBinding<int> m_MiniHudPlacementBinding = null!;
        private ValueBinding<bool> m_MiniHudHideZeroBinding = null!;
        private ValueBinding<int> m_MiniHudPanelStyleBinding = null!;
        private ValueBinding<int> m_MiniHudPanelOpacityBinding = null!;
        private ValueBinding<int> m_MiniHudHorizontalPositionXBinding = null!;
        private ValueBinding<int> m_MiniHudHorizontalPositionYBinding = null!;
        private ValueBinding<int> m_MiniHudVerticalPositionXBinding = null!;
        private ValueBinding<int> m_MiniHudVerticalPositionYBinding = null!;
        private ValueBinding<int> m_PanelPositionXBinding = null!;
        private ValueBinding<int> m_PanelPositionYBinding = null!;
        private ValueBinding<int> m_PanelCollapsedSectionsMaskBinding = null!;
        private ValueBinding<int> m_PanelSortModeBinding = null!;
        private ValueBinding<bool> m_PanelButtonsOnlyStartBinding = null!;
        private ValueBinding<int> m_MainPanelOpacityBinding = null!;
        private ValueBinding<bool> m_Preset1SavedBinding = null!;
        private ValueBinding<bool> m_Preset2SavedBinding = null!;
        private ValueBinding<int> m_ActivePresetBinding = null!;
        private ValueBinding<bool>? m_MoneyViewBinding;
        private ValueBinding<int>? m_MoneyViewModeBinding;
        private ValueBinding<int>? m_MoneyTooltipModeBinding;
        private ValueBinding<int>? m_MoneyTooltipFontScaleBinding;
        private ValueBinding<int>? m_PopulationTooltipFontScaleBinding;

        private BoolBinding m_ElectricElectricNotificationBinding = null!;
        private BoolBinding m_ElectricBottleneckNotificationBinding = null!;
        private BoolBinding m_ElectricBuildingBottleneckNotificationBinding = null!;
        private BoolBinding m_ElectricNotEnoughProductionNotificationBinding = null!;
        private BoolBinding m_ElectricTransformerNotificationBinding = null!;
        private BoolBinding m_ElectricNotEnoughConnectedNotificationBinding = null!;
        private BoolBinding m_ElectricBatteryEmptyNotificationBinding = null!;
        private BoolBinding m_ElectricLowVoltageNotConnectedBinding = null!;
        private BoolBinding m_ElectricHighVoltageNotConnectedBinding = null!;

        private BoolBinding m_WaterPipeWaterNotificationBinding = null!;
        private BoolBinding m_WaterPipeDirtyWaterNotificationBinding = null!;
        private BoolBinding m_WaterPipeSewageNotificationBinding = null!;
        private BoolBinding m_WaterPipeWaterPipeNotConnectedNotificationBinding = null!;
        private BoolBinding m_WaterPipeSewagePipeNotConnectedNotificationBinding = null!;
        private BoolBinding m_WaterPipeNotEnoughWaterCapacityNotificationBinding = null!;
        private BoolBinding m_WaterPipeNotEnoughSewageCapacityNotificationBinding = null!;
        private BoolBinding m_WaterPipeNotEnoughGroundwaterNotificationBinding = null!;
        private BoolBinding m_WaterPipeNotEnoughSurfaceWaterNotificationBinding = null!;
        private BoolBinding m_WaterPipeDirtyWaterPumpNotificationBinding = null!;

        private BoolBinding m_BuildingAbandonedCollapsedNotificationBinding = null!;
        private BoolBinding m_BuildingAbandonedNotificationBinding = null!;
        private BoolBinding m_BuildingCondemnedNotificationBinding = null!;
        private BoolBinding m_BuildingTurnedOffNotificationBinding = null!;
        private BoolBinding m_BuildingHighRentNotificationBinding = null!;
        private BoolBinding m_BuildingLevelingNotificationBinding = null!;

        private BoolBinding m_TrafficBottleneckNotificationBinding = null!;
        private BoolBinding m_TrafficDeadEndNotificationBinding = null!;
        private BoolBinding m_TrafficRoadConnectionNotificationBinding = null!;
        private BoolBinding m_TrafficTrackConnectionNotificationBinding = null!;
        private BoolBinding m_TrafficCarConnectionNotificationBinding = null!;
        private BoolBinding m_TrafficShipConnectionNotificationBinding = null!;
        private BoolBinding m_TrafficTrainConnectionNotificationBinding = null!;
        private BoolBinding m_TrafficPedestrianConnectionNotificationBinding = null!;
        private BoolBinding m_TrafficBicycleConnectionNotificationBinding = null!;

        private BoolBinding m_CompanyNoInputsNotificationBinding = null!;
        private BoolBinding m_CompanyNoCustomersNotificationBinding = null!;

        private BoolBinding m_WorkProviderUneducatedNotificationBinding = null!;
        private BoolBinding m_WorkProviderEducatedNotificationBinding = null!;

        private BoolBinding m_DisasterWeatherDamageNotificationBinding = null!;
        private BoolBinding m_DisasterWeatherDestroyedNotificationBinding = null!;
        private BoolBinding m_DisasterWaterDamageNotificationBinding = null!;
        private BoolBinding m_DisasterWaterDestroyedNotificationBinding = null!;
        private BoolBinding m_DisasterDestroyedNotificationBinding = null!;

        private BoolBinding m_FireFireNotificationBinding = null!;
        private BoolBinding m_FireBurnedDownNotificationBinding = null!;

        private BoolBinding m_GarbageGarbageNotificationBinding = null!;
        private BoolBinding m_GarbageFacilityFullNotificationBinding = null!;

        private BoolBinding m_HealthcareAmbulanceNotificationBinding = null!;
        private BoolBinding m_HealthcareHearseNotificationBinding = null!;
        private BoolBinding m_HealthcareFacilityFullNotificationBinding = null!;

        private BoolBinding m_PoliceTrafficAccidentNotificationBinding = null!;
        private BoolBinding m_PoliceCrimeSceneNotificationBinding = null!;

        private BoolBinding m_PollutionAirPollutionNotificationBinding = null!;
        private BoolBinding m_PollutionNoisePollutionNotificationBinding = null!;
        private BoolBinding m_PollutionGroundPollutionNotificationBinding = null!;

        private BoolBinding m_ResourceConsumerNoResourceNotificationBinding = null!;
        private BoolBinding m_ResourceConsumerNoFuelNotificationBinding = null!;
        private BoolBinding m_ResourceConnectionWarningNotificationBinding = null!;
        private BoolBinding m_ResourceConnectionOilPipeNotConnectedNotificationBinding = null!;
        private BoolBinding m_ResourceConnectionFishingPierNotConnectedNotificationBinding = null!;

        private BoolBinding m_RoutePathfindNotificationBinding = null!;
        private BoolBinding m_RouteGateBypassNotificationBinding = null!;

        private BoolBinding m_TransportLineVehicleNotificationBinding = null!;

        // Close the panel on every city load. The Active view is a deliberately frozen snapshot, so a
        // panel left open across a load keeps showing the PREVIOUS city's alert list — 8 disconnected oil
        // pipes that exist in the city you just left. Closing unmounts the React tree, which discards that
        // snapshot; the player reopens and gets this city's data. Players don't expect a mod panel to
        // survive a load anyway.
        protected override void OnGameLoadingComplete(Purpose purpose, GameMode mode)
        {
            base.OnGameLoadingComplete(purpose, mode);

            if (!IsRealGameLoad(purpose, mode))
            {
                return;
            }

            m_PanelVisibleBinding.Update(false);

            // The mini HUD stays open across loads, so force a rescan instead of letting it sit on the old
            // city's totals until the next tick. Clearing m_hasLastNotificationCounts stops the diff in
            // OnUpdate from suppressing the push when the two cities' arrays happen to match.
            m_HasLastNotificationCounts = false;
            m_NotificationCountUpdateState.ForceUpdate();
            m_MiniHudCountUpdateState.ForceUpdate();
        }

        // Ignore editor/main-menu transitions and save-outs; only a real city load should reset the panel.
        private static bool IsRealGameLoad(Purpose purpose, GameMode mode)
        {
            return mode == GameMode.Game &&
                (purpose == Purpose.NewGame || purpose == Purpose.LoadGame);
        }

        // Binding IDs are the C# <-> React contract. Field names can change, but these IDs
        // must stay aligned with UI.
        protected override void OnCreate() {
            base.OnCreate();

            m_AlertIconSystem = World.GetOrCreateSystemManaged<AlertIconSystem>();
            InitializeKeybindActions();
            m_NotificationCountUpdateState = UIUpdateState.Create(World, kPanelCountUpdateInterval);
            m_MiniHudCountUpdateState = UIUpdateState.Create(World, kMiniHudCountUpdateInterval);

            m_PanelVisibleBinding = AddBoolBindingAndTriggerBinding("ControlPanelEnabled", false, OnControlPanelBindingToggle);
            AddBoolTriggerBinding("ToggleAllNotifications", ApplyAllNotificationToggles);
            m_NotificationCountsBinding = new ValueBinding<int[]>(
                ModId,
                "NotificationCounts",
                new int[AlertIconSystem.NotificationCountLength],
                new ArrayWriter<int>());
            AddBinding(m_NotificationCountsBinding);
            m_MiniHudFavoritesBinding = new ValueBinding<int[]>(
                ModId,
                "MiniHudFavorites",
                GetMiniHudFavoriteIndexes(),
                new ArrayWriter<int>());
            AddBinding(m_MiniHudFavoritesBinding);
            AddTriggerBinding<int>("ToggleMiniHudFavorite", ToggleMiniHudFavorite);
            AddTriggerBinding<int>("MiniHudNotificationClicked", JumpToMiniHudNotification);
            AddTriggerBinding<string>("MiniHudPositionChanged", SaveMiniHudPosition);
            AddTriggerBinding<string>("PanelPositionChanged", SavePanelPosition);
            AddTriggerBinding<int>("PanelCollapsedSectionsChanged", SavePanelCollapsedSections);
            AddTriggerBinding<int>("PanelSortModeChanged", SavePanelSortMode);
            m_MiniHudEnabledBinding = AddValueBinding(nameof(CwdSettings.MiniHudEnabled), CwdSettings.Instance.MiniHudEnabled);
            m_MiniHudModeBinding = AddValueBinding(nameof(CwdSettings.MiniHudMode), CwdSettings.Instance.MiniHudMode);
            m_MiniHudItemCountBinding = AddValueBinding(nameof(CwdSettings.MiniHudItemCount), CwdSettings.Instance.MiniHudItemCount);
            m_MiniHudScaleBinding = AddValueBinding(nameof(CwdSettings.MiniHudScale), CwdSettings.Instance.MiniHudScale);
            m_MiniHudOrientationBinding = AddValueBinding(nameof(CwdSettings.MiniHudOrientation), CwdSettings.Instance.MiniHudOrientation);
            m_MiniHudPlacementBinding = AddValueBinding(nameof(CwdSettings.MiniHudPlacement), CwdSettings.Instance.MiniHudPlacement);
            m_MiniHudHideZeroBinding = AddValueBinding(nameof(CwdSettings.MiniHudHideZero), CwdSettings.Instance.MiniHudHideZero);
            m_MiniHudPanelStyleBinding = AddValueBinding(nameof(CwdSettings.MiniHudPanelStyle), CwdSettings.Instance.MiniHudPanelStyle);
            m_MiniHudPanelOpacityBinding = AddValueBinding(nameof(CwdSettings.MiniHudPanelOpacity), CwdSettings.Instance.MiniHudPanelOpacity);
            m_MiniHudHorizontalPositionXBinding = AddValueBinding(nameof(CwdSettings.MiniHudHorizontalPositionX), CwdSettings.Instance.MiniHudHorizontalPositionX);
            m_MiniHudHorizontalPositionYBinding = AddValueBinding(nameof(CwdSettings.MiniHudHorizontalPositionY), CwdSettings.Instance.MiniHudHorizontalPositionY);
            m_MiniHudVerticalPositionXBinding = AddValueBinding(nameof(CwdSettings.MiniHudVerticalPositionX), CwdSettings.Instance.MiniHudVerticalPositionX);
            m_MiniHudVerticalPositionYBinding = AddValueBinding(nameof(CwdSettings.MiniHudVerticalPositionY), CwdSettings.Instance.MiniHudVerticalPositionY);
            m_PanelPositionXBinding = AddValueBinding(nameof(CwdSettings.PanelPositionX), CwdSettings.Instance.PanelPositionX);
            m_PanelPositionYBinding = AddValueBinding(nameof(CwdSettings.PanelPositionY), CwdSettings.Instance.PanelPositionY);
            m_PanelCollapsedSectionsMaskBinding = AddValueBinding(nameof(CwdSettings.PanelCollapsedSectionsMask), CwdSettings.Instance.PanelCollapsedSectionsMask);
            m_PanelSortModeBinding = AddValueBinding(nameof(CwdSettings.PanelSortMode), CwdSettings.Instance.PanelSortMode);
            m_PanelButtonsOnlyStartBinding = AddValueBinding(nameof(CwdSettings.PanelButtonsOnlyStart), CwdSettings.Instance.PanelButtonsOnlyStart);
            m_MainPanelOpacityBinding = AddValueBinding(nameof(CwdSettings.MainPanelOpacity), CwdSettings.Instance.MainPanelOpacity);
            m_Preset1SavedBinding = AddValueBinding(nameof(CwdSettings.Preset1Saved), CwdSettings.Instance.Preset1Saved);
            m_Preset2SavedBinding = AddValueBinding(nameof(CwdSettings.Preset2Saved), CwdSettings.Instance.Preset2Saved);
            m_ActivePresetBinding = AddValueBinding(nameof(CwdSettings.ActivePreset), CwdSettings.Instance.ActivePreset);
            AddTriggerBinding<int>("SavePreset", SavePreset);
            AddTriggerBinding<int>("LoadPreset", LoadPreset);
            m_MoneyViewBinding = AddValueBinding(nameof(CwdSettings.MoneyView), CwdSettings.Instance.MoneyView);
            m_MoneyViewModeBinding = AddValueBinding(nameof(CwdSettings.MoneyViewMode), CwdSettings.Instance.MoneyViewMode);
            m_MoneyTooltipModeBinding = AddValueBinding(nameof(CwdSettings.MoneyTooltipMode), CwdSettings.Instance.MoneyTooltipMode);
            m_MoneyTooltipFontScaleBinding = AddValueBinding(nameof(CwdSettings.MoneyTooltipFontScale), CwdSettings.Instance.MoneyTooltipFontScale);
            m_PopulationTooltipFontScaleBinding = AddValueBinding(nameof(CwdSettings.PopulationTooltipFontScale), CwdSettings.Instance.PopulationTooltipFontScale);

            m_ElectricElectricNotificationBinding = AddBoolBindingAndTriggerBinding(nameof(CwdSettings.Instance.Notification.ElectricityElectricityNotification), CwdSettings.Instance.Notification.ElectricityElectricityNotification, OnElectricityElectricityNotificationToggle);
            m_ElectricBottleneckNotificationBinding = AddBoolBindingAndTriggerBinding(nameof(CwdSettings.Instance.Notification.ElectricityBottleneckNotification), CwdSettings.Instance.Notification.ElectricityBottleneckNotification, OnElectricityBottleneckNotificationToggle);
            m_ElectricBuildingBottleneckNotificationBinding = AddBoolBindingAndTriggerBinding(nameof(CwdSettings.Instance.Notification.ElectricityBuildingBottleneckNotification), CwdSettings.Instance.Notification.ElectricityBuildingBottleneckNotification, OnElectricityBuildingBottleneckNotificationToggle);
            m_ElectricNotEnoughProductionNotificationBinding = AddBoolBindingAndTriggerBinding(nameof(CwdSettings.Instance.Notification.ElectricityNotEnoughProductionNotification), CwdSettings.Instance.Notification.ElectricityNotEnoughProductionNotification, OnElectricityNotEnoughProductionNotificationToggle);
            m_ElectricTransformerNotificationBinding = AddBoolBindingAndTriggerBinding(nameof(CwdSettings.Instance.Notification.ElectricityTransformerNotification), CwdSettings.Instance.Notification.ElectricityTransformerNotification, OnElectricityTransformerNotificationToggle);
            m_ElectricNotEnoughConnectedNotificationBinding = AddBoolBindingAndTriggerBinding(nameof(CwdSettings.Instance.Notification.ElectricityNotEnoughConnectedNotification), CwdSettings.Instance.Notification.ElectricityNotEnoughConnectedNotification, OnElectricityNotEnoughConnectedNotificationToggle);
            m_ElectricBatteryEmptyNotificationBinding = AddBoolBindingAndTriggerBinding(nameof(CwdSettings.Instance.Notification.ElectricityBatteryEmptyNotification), CwdSettings.Instance.Notification.ElectricityBatteryEmptyNotification, OnElectricityBatteryEmptyNotificationToggle);
            m_ElectricLowVoltageNotConnectedBinding = AddBoolBindingAndTriggerBinding(nameof(CwdSettings.Instance.Notification.ElectricityLowVoltageNotConnected), CwdSettings.Instance.Notification.ElectricityLowVoltageNotConnected, OnElectricityLowVoltageNotConnectedToggle);
            m_ElectricHighVoltageNotConnectedBinding = AddBoolBindingAndTriggerBinding(nameof(CwdSettings.Instance.Notification.ElectricityHighVoltageNotConnected), CwdSettings.Instance.Notification.ElectricityHighVoltageNotConnected, OnElectricityHighVoltageNotConnectedToggle);

            m_WaterPipeWaterNotificationBinding = AddBoolBindingAndTriggerBinding(nameof(CwdSettings.Instance.Notification.WaterPipeWaterNotification), CwdSettings.Instance.Notification.WaterPipeWaterNotification, OnWaterPipeWaterNotificationToggle);
            m_WaterPipeDirtyWaterNotificationBinding = AddBoolBindingAndTriggerBinding(nameof(CwdSettings.Instance.Notification.WaterPipeDirtyWaterNotification), CwdSettings.Instance.Notification.WaterPipeDirtyWaterNotification, OnWaterPipeDirtyWaterNotificationToggle);
            m_WaterPipeSewageNotificationBinding = AddBoolBindingAndTriggerBinding(nameof(CwdSettings.Instance.Notification.WaterPipeSewageNotification), CwdSettings.Instance.Notification.WaterPipeSewageNotification, OnWaterPipeSewageNotificationToggle);
            m_WaterPipeWaterPipeNotConnectedNotificationBinding = AddBoolBindingAndTriggerBinding(nameof(CwdSettings.Instance.Notification.WaterPipeWaterPipeNotConnectedNotification), CwdSettings.Instance.Notification.WaterPipeWaterPipeNotConnectedNotification, OnWaterPipeWaterPipeNotConnectedNotificationToggle);
            m_WaterPipeSewagePipeNotConnectedNotificationBinding = AddBoolBindingAndTriggerBinding(nameof(CwdSettings.Instance.Notification.WaterPipeSewagePipeNotConnectedNotification), CwdSettings.Instance.Notification.WaterPipeSewagePipeNotConnectedNotification, OnWaterPipeSewagePipeNotConnectedNotificationToggle);
            m_WaterPipeNotEnoughWaterCapacityNotificationBinding = AddBoolBindingAndTriggerBinding(nameof(CwdSettings.Instance.Notification.WaterPipeNotEnoughWaterCapacityNotification), CwdSettings.Instance.Notification.WaterPipeNotEnoughWaterCapacityNotification, OnWaterPipeNotEnoughWaterCapacityNotificationToggle);
            m_WaterPipeNotEnoughSewageCapacityNotificationBinding = AddBoolBindingAndTriggerBinding(nameof(CwdSettings.Instance.Notification.WaterPipeNotEnoughSewageCapacityNotification), CwdSettings.Instance.Notification.WaterPipeNotEnoughSewageCapacityNotification, OnWaterPipeNotEnoughSewageCapacityNotificationToggle);
            m_WaterPipeNotEnoughGroundwaterNotificationBinding = AddBoolBindingAndTriggerBinding(nameof(CwdSettings.Instance.Notification.WaterPipeNotEnoughGroundwaterNotification), CwdSettings.Instance.Notification.WaterPipeNotEnoughGroundwaterNotification, OnWaterPipeNotEnoughGroundwaterNotificationToggle);
            m_WaterPipeNotEnoughSurfaceWaterNotificationBinding = AddBoolBindingAndTriggerBinding(nameof(CwdSettings.Instance.Notification.WaterPipeNotEnoughSurfaceWaterNotification), CwdSettings.Instance.Notification.WaterPipeNotEnoughSurfaceWaterNotification, OnWaterPipeNotEnoughSurfaceWaterNotificationToggle);
            m_WaterPipeDirtyWaterPumpNotificationBinding = AddBoolBindingAndTriggerBinding(nameof(CwdSettings.Instance.Notification.WaterPipeDirtyWaterPumpNotification), CwdSettings.Instance.Notification.WaterPipeDirtyWaterPumpNotification, OnWaterPipeDirtyWaterPumpNotificationToggle);

            m_BuildingAbandonedCollapsedNotificationBinding = AddBoolBindingAndTriggerBinding(nameof(CwdSettings.Instance.Notification.BuildingAbandonedCollapsedNotification), CwdSettings.Instance.Notification.BuildingAbandonedCollapsedNotification, OnBuildingAbandonedCollapsedNotificationToggle);
            m_BuildingAbandonedNotificationBinding = AddBoolBindingAndTriggerBinding(nameof(CwdSettings.Instance.Notification.BuildingAbandonedNotification), CwdSettings.Instance.Notification.BuildingAbandonedNotification, OnBuildingAbandonedNotificationToggle);
            m_BuildingCondemnedNotificationBinding = AddBoolBindingAndTriggerBinding(nameof(CwdSettings.Instance.Notification.BuildingCondemnedNotification), CwdSettings.Instance.Notification.BuildingCondemnedNotification, OnBuildingCondemnedNotificationToggle);
            m_BuildingTurnedOffNotificationBinding = AddBoolBindingAndTriggerBinding(nameof(CwdSettings.Instance.Notification.BuildingTurnedOffNotification), CwdSettings.Instance.Notification.BuildingTurnedOffNotification, OnBuildingTurnedOffNotificationToggle);
            m_BuildingHighRentNotificationBinding = AddBoolBindingAndTriggerBinding(nameof(CwdSettings.Instance.Notification.BuildingHighRentNotification), CwdSettings.Instance.Notification.BuildingHighRentNotification, OnBuildingHighRentNotificationToggle);
            m_BuildingLevelingNotificationBinding = AddBoolBindingAndTriggerBinding(nameof(CwdSettings.Instance.Notification.BuildingLevelingNotification), CwdSettings.Instance.Notification.BuildingLevelingNotification, OnBuildingLevelingNotificationToggle);

            m_TrafficBottleneckNotificationBinding = AddBoolBindingAndTriggerBinding(nameof(CwdSettings.Instance.Notification.TrafficBottleneckNotification), CwdSettings.Instance.Notification.TrafficBottleneckNotification, OnTrafficBottleneckNotificationToggle);
            m_TrafficDeadEndNotificationBinding = AddBoolBindingAndTriggerBinding(nameof(CwdSettings.Instance.Notification.TrafficDeadEndNotification), CwdSettings.Instance.Notification.TrafficDeadEndNotification, OnTrafficDeadEndNotificationToggle);
            m_TrafficRoadConnectionNotificationBinding = AddBoolBindingAndTriggerBinding(nameof(CwdSettings.Instance.Notification.TrafficRoadConnectionNotification), CwdSettings.Instance.Notification.TrafficRoadConnectionNotification, OnTrafficRoadConnectionNotificationToggle);
            m_TrafficTrackConnectionNotificationBinding = AddBoolBindingAndTriggerBinding(nameof(CwdSettings.Instance.Notification.TrafficTrackConnectionNotification), CwdSettings.Instance.Notification.TrafficTrackConnectionNotification, OnTrafficTrackConnectionNotificationToggle);
            m_TrafficCarConnectionNotificationBinding = AddBoolBindingAndTriggerBinding(nameof(CwdSettings.Instance.Notification.TrafficCarConnectionNotification), CwdSettings.Instance.Notification.TrafficCarConnectionNotification, OnTrafficCarConnectionNotificationToggle);
            m_TrafficShipConnectionNotificationBinding = AddBoolBindingAndTriggerBinding(nameof(CwdSettings.Instance.Notification.TrafficShipConnectionNotification), CwdSettings.Instance.Notification.TrafficShipConnectionNotification, OnTrafficShipConnectionNotificationToggle);
            m_TrafficTrainConnectionNotificationBinding = AddBoolBindingAndTriggerBinding(nameof(CwdSettings.Instance.Notification.TrafficTrainConnectionNotification), CwdSettings.Instance.Notification.TrafficTrainConnectionNotification, OnTrafficTrainConnectionNotificationToggle);
            m_TrafficPedestrianConnectionNotificationBinding = AddBoolBindingAndTriggerBinding(nameof(CwdSettings.Instance.Notification.TrafficPedestrianConnectionNotification), CwdSettings.Instance.Notification.TrafficPedestrianConnectionNotification, OnTrafficPedestrianConnectionNotificationToggle);
            m_TrafficBicycleConnectionNotificationBinding = AddBoolBindingAndTriggerBinding(nameof(CwdSettings.Instance.Notification.TrafficBicycleConnectionNotification), CwdSettings.Instance.Notification.TrafficBicycleConnectionNotification, OnTrafficBicycleConnectionNotificationToggle);

            m_CompanyNoInputsNotificationBinding = AddBoolBindingAndTriggerBinding(nameof(CwdSettings.Instance.Notification.CompanyNoInputsNotification), CwdSettings.Instance.Notification.CompanyNoInputsNotification, OnCompanyNoInputsNotificationToggle);
            m_CompanyNoCustomersNotificationBinding = AddBoolBindingAndTriggerBinding(nameof(CwdSettings.Instance.Notification.CompanyNoCustomersNotification), CwdSettings.Instance.Notification.CompanyNoCustomersNotification, OnCompanyNoCustomersNotificationToggle);

            m_WorkProviderUneducatedNotificationBinding = AddBoolBindingAndTriggerBinding(nameof(CwdSettings.Instance.Notification.WorkProviderUneducatedNotification), CwdSettings.Instance.Notification.WorkProviderUneducatedNotification, OnWorkProviderUneducatedNotificationToggle);
            m_WorkProviderEducatedNotificationBinding = AddBoolBindingAndTriggerBinding(nameof(CwdSettings.Instance.Notification.WorkProviderEducatedNotification), CwdSettings.Instance.Notification.WorkProviderEducatedNotification, OnWorkProviderEducatedNotificationToggle);

            m_DisasterWeatherDamageNotificationBinding = AddBoolBindingAndTriggerBinding(nameof(CwdSettings.Instance.Notification.DisasterWeatherDamageNotification), CwdSettings.Instance.Notification.DisasterWeatherDamageNotification, OnDisasterWeatherDamageNotificationToggle);
            m_DisasterWeatherDestroyedNotificationBinding = AddBoolBindingAndTriggerBinding(nameof(CwdSettings.Instance.Notification.DisasterWeatherDestroyedNotification), CwdSettings.Instance.Notification.DisasterWeatherDestroyedNotification, OnDisasterWeatherDestroyedNotificationToggle);
            m_DisasterWaterDamageNotificationBinding = AddBoolBindingAndTriggerBinding(nameof(CwdSettings.Instance.Notification.DisasterWaterDamageNotification), CwdSettings.Instance.Notification.DisasterWaterDamageNotification, OnDisasterWaterDamageNotificationToggle);
            m_DisasterWaterDestroyedNotificationBinding = AddBoolBindingAndTriggerBinding(nameof(CwdSettings.Instance.Notification.DisasterWaterDestroyedNotification), CwdSettings.Instance.Notification.DisasterWaterDestroyedNotification, OnDisasterWaterDestroyedNotificationToggle);
            m_DisasterDestroyedNotificationBinding = AddBoolBindingAndTriggerBinding(nameof(CwdSettings.Instance.Notification.DisasterDestroyedNotification), CwdSettings.Instance.Notification.DisasterDestroyedNotification, OnDisasterDestroyedNotificationToggle);

            m_FireFireNotificationBinding = AddBoolBindingAndTriggerBinding(nameof(CwdSettings.Instance.Notification.FireFireNotification), CwdSettings.Instance.Notification.FireFireNotification, OnFireFireNotificationToggle);
            m_FireBurnedDownNotificationBinding = AddBoolBindingAndTriggerBinding(nameof(CwdSettings.Instance.Notification.FireBurnedDownNotification), CwdSettings.Instance.Notification.FireBurnedDownNotification, OnFireBurnedDownNotificationToggle);

            m_GarbageGarbageNotificationBinding = AddBoolBindingAndTriggerBinding(nameof(CwdSettings.Instance.Notification.GarbageGarbageNotification), CwdSettings.Instance.Notification.GarbageGarbageNotification, OnGarbageGarbageNotificationToggle);
            m_GarbageFacilityFullNotificationBinding = AddBoolBindingAndTriggerBinding(nameof(CwdSettings.Instance.Notification.GarbageFacilityFullNotification), CwdSettings.Instance.Notification.GarbageFacilityFullNotification, OnGarbageFacilityFullNotificationToggle);

            m_HealthcareAmbulanceNotificationBinding = AddBoolBindingAndTriggerBinding(nameof(CwdSettings.Instance.Notification.HealthcareAmbulanceNotification), CwdSettings.Instance.Notification.HealthcareAmbulanceNotification, OnHealthcareAmbulanceNotificationToggle);
            m_HealthcareHearseNotificationBinding = AddBoolBindingAndTriggerBinding(nameof(CwdSettings.Instance.Notification.HealthcareHearseNotification), CwdSettings.Instance.Notification.HealthcareHearseNotification, OnHealthcareHearseNotificationToggle);
            m_HealthcareFacilityFullNotificationBinding = AddBoolBindingAndTriggerBinding(nameof(CwdSettings.Instance.Notification.HealthcareFacilityFullNotification), CwdSettings.Instance.Notification.HealthcareFacilityFullNotification, OnHealthcareFacilityFullNotificationToggle);

            m_PoliceTrafficAccidentNotificationBinding = AddBoolBindingAndTriggerBinding(nameof(CwdSettings.Instance.Notification.PoliceTrafficAccidentNotification), CwdSettings.Instance.Notification.PoliceTrafficAccidentNotification, OnPoliceTrafficAccidentNotificationToggle);
            m_PoliceCrimeSceneNotificationBinding = AddBoolBindingAndTriggerBinding(nameof(CwdSettings.Instance.Notification.PoliceCrimeSceneNotification), CwdSettings.Instance.Notification.PoliceCrimeSceneNotification, OnPoliceCrimeSceneNotificationToggle);

            m_PollutionAirPollutionNotificationBinding = AddBoolBindingAndTriggerBinding(nameof(CwdSettings.Instance.Notification.PollutionAirPollutionNotification), CwdSettings.Instance.Notification.PollutionAirPollutionNotification, OnPollutionAirPollutionNotificationToggle);
            m_PollutionNoisePollutionNotificationBinding = AddBoolBindingAndTriggerBinding(nameof(CwdSettings.Instance.Notification.PollutionNoisePollutionNotification), CwdSettings.Instance.Notification.PollutionNoisePollutionNotification, OnPollutionNoisePollutionNotificationToggle);
            m_PollutionGroundPollutionNotificationBinding = AddBoolBindingAndTriggerBinding(nameof(CwdSettings.Instance.Notification.PollutionGroundPollutionNotification), CwdSettings.Instance.Notification.PollutionGroundPollutionNotification, OnPollutionGroundPollutionNotificationToggle);

            m_ResourceConsumerNoResourceNotificationBinding = AddBoolBindingAndTriggerBinding(nameof(CwdSettings.Instance.Notification.ResourceConsumerNoResourceNotification), CwdSettings.Instance.Notification.ResourceConsumerNoResourceNotification, OnResourceConsumerNoResourceNotificationToggle);
            m_ResourceConsumerNoFuelNotificationBinding = AddBoolBindingAndTriggerBinding(nameof(CwdSettings.Instance.Notification.ResourceConsumerNoFuelNotification), CwdSettings.Instance.Notification.ResourceConsumerNoFuelNotification, OnResourceConsumerNoFuelNotificationToggle);
            m_ResourceConnectionWarningNotificationBinding = AddBoolBindingAndTriggerBinding(nameof(CwdSettings.Instance.Notification.ResourceConnectionWarningNotification), CwdSettings.Instance.Notification.ResourceConnectionWarningNotification, OnResourceConnectionWarningNotificationToggle);
            m_ResourceConnectionOilPipeNotConnectedNotificationBinding = AddBoolBindingAndTriggerBinding(nameof(CwdSettings.Instance.Notification.ResourceConnectionOilPipeNotConnectedNotification), CwdSettings.Instance.Notification.ResourceConnectionOilPipeNotConnectedNotification, OnResourceConnectionOilPipeNotConnectedNotificationToggle);
            m_ResourceConnectionFishingPierNotConnectedNotificationBinding = AddBoolBindingAndTriggerBinding(nameof(CwdSettings.Instance.Notification.ResourceConnectionFishingPierNotConnectedNotification), CwdSettings.Instance.Notification.ResourceConnectionFishingPierNotConnectedNotification, OnResourceConnectionFishingPierNotConnectedNotificationToggle);

            m_RoutePathfindNotificationBinding = AddBoolBindingAndTriggerBinding(nameof(CwdSettings.Instance.Notification.RoutePathfindNotification), CwdSettings.Instance.Notification.RoutePathfindNotification, OnRoutePathfindNotificationToggle);
            m_RouteGateBypassNotificationBinding = AddBoolBindingAndTriggerBinding(nameof(CwdSettings.Instance.Notification.RouteGateBypassNotification), CwdSettings.Instance.Notification.RouteGateBypassNotification, OnRouteGateBypassNotificationToggle);

            m_TransportLineVehicleNotificationBinding = AddBoolBindingAndTriggerBinding(nameof(CwdSettings.Instance.Notification.TransportLineVehicleNotification), CwdSettings.Instance.Notification.TransportLineVehicleNotification, OnTransportLineVehicleNotificationToggle);
        }



        #region OnElectricityNotificationToggle
        private void OnElectricityElectricityNotificationToggle(bool value) {
            m_ElectricElectricNotificationBinding.Update(value);
            CwdSettings.Instance.Notification.ElectricityElectricityNotification = value;
            m_AlertIconSystem.EnableElectricityNotification(ElectricityNotificationIcon.ElectricityNotification, value, true);
        }
        private void OnElectricityBottleneckNotificationToggle(bool value) {
            m_ElectricBottleneckNotificationBinding.Update(value);
            CwdSettings.Instance.Notification.ElectricityBottleneckNotification = value;
            m_AlertIconSystem.EnableElectricityNotification(ElectricityNotificationIcon.BottleneckNotification, value, true);
        }
        private void OnElectricityBuildingBottleneckNotificationToggle(bool value) {
            m_ElectricBuildingBottleneckNotificationBinding.Update(value);
            CwdSettings.Instance.Notification.ElectricityBuildingBottleneckNotification = value;
            m_AlertIconSystem.EnableElectricityNotification(ElectricityNotificationIcon.BuildingBottleneckNotification, value, true);
        }
        private void OnElectricityNotEnoughProductionNotificationToggle(bool value) {
            m_ElectricNotEnoughProductionNotificationBinding.Update(value);
            CwdSettings.Instance.Notification.ElectricityNotEnoughProductionNotification = value;
            m_AlertIconSystem.EnableElectricityNotification(ElectricityNotificationIcon.NotEnoughProductionNotification, value, true);
        }
        private void OnElectricityTransformerNotificationToggle(bool value) {
            m_ElectricTransformerNotificationBinding.Update(value);
            CwdSettings.Instance.Notification.ElectricityTransformerNotification = value;
            m_AlertIconSystem.EnableElectricityNotification(ElectricityNotificationIcon.TransformerNotification, value, true);
        }
        private void OnElectricityNotEnoughConnectedNotificationToggle(bool value) {
            m_ElectricNotEnoughConnectedNotificationBinding.Update(value);
            CwdSettings.Instance.Notification.ElectricityNotEnoughConnectedNotification = value;
            m_AlertIconSystem.EnableElectricityNotification(ElectricityNotificationIcon.NotEnoughConnectedNotification, value, true);
        }
        private void OnElectricityBatteryEmptyNotificationToggle(bool value) {
            m_ElectricBatteryEmptyNotificationBinding.Update(value);
            CwdSettings.Instance.Notification.ElectricityBatteryEmptyNotification = value;
            m_AlertIconSystem.EnableElectricityNotification(ElectricityNotificationIcon.BatteryEmptyNotification, value, true);
        }
        private void OnElectricityLowVoltageNotConnectedToggle(bool value) {
            m_ElectricLowVoltageNotConnectedBinding.Update(value);
            CwdSettings.Instance.Notification.ElectricityLowVoltageNotConnected = value;
            m_AlertIconSystem.EnableElectricityNotification(ElectricityNotificationIcon.LowVoltageNotConnected, value, true);
        }
        private void OnElectricityHighVoltageNotConnectedToggle(bool value) {
            m_ElectricHighVoltageNotConnectedBinding.Update(value);
            CwdSettings.Instance.Notification.ElectricityHighVoltageNotConnected = value;
            m_AlertIconSystem.EnableElectricityNotification(ElectricityNotificationIcon.HighVoltageNotConnected, value, true);
        }

        #endregion

        #region OnWaterPipeNotificationToggle
        private void OnWaterPipeWaterNotificationToggle(bool value) {
            m_WaterPipeWaterNotificationBinding.Update(value);
            CwdSettings.Instance.Notification.WaterPipeWaterNotification = value;
            m_AlertIconSystem.EnableWaterPipeNotification(WaterPipeNotificationIcon.WaterNotification, value, true);
        }
        private void OnWaterPipeDirtyWaterNotificationToggle(bool value) {
            m_WaterPipeDirtyWaterNotificationBinding.Update(value);
            CwdSettings.Instance.Notification.WaterPipeDirtyWaterNotification = value;
            m_AlertIconSystem.EnableWaterPipeNotification(WaterPipeNotificationIcon.DirtyWaterNotification, value, true);
        }
        private void OnWaterPipeSewageNotificationToggle(bool value) {
            m_WaterPipeSewageNotificationBinding.Update(value);
            CwdSettings.Instance.Notification.WaterPipeSewageNotification = value;
            m_AlertIconSystem.EnableWaterPipeNotification(WaterPipeNotificationIcon.SewageNotification, value, true);
        }
        private void OnWaterPipeWaterPipeNotConnectedNotificationToggle(bool value) {
            m_WaterPipeWaterPipeNotConnectedNotificationBinding.Update(value);
            CwdSettings.Instance.Notification.WaterPipeWaterPipeNotConnectedNotification = value;
            m_AlertIconSystem.EnableWaterPipeNotification(WaterPipeNotificationIcon.WaterPipeNotConnectedNotification, value, true);
        }
        private void OnWaterPipeSewagePipeNotConnectedNotificationToggle(bool value) {
            m_WaterPipeSewagePipeNotConnectedNotificationBinding.Update(value);
            CwdSettings.Instance.Notification.WaterPipeSewagePipeNotConnectedNotification = value;
            m_AlertIconSystem.EnableWaterPipeNotification(WaterPipeNotificationIcon.SewagePipeNotConnectedNotification, value, true);
        }
        private void OnWaterPipeNotEnoughWaterCapacityNotificationToggle(bool value) {
            m_WaterPipeNotEnoughWaterCapacityNotificationBinding.Update(value);
            CwdSettings.Instance.Notification.WaterPipeNotEnoughWaterCapacityNotification = value;
            m_AlertIconSystem.EnableWaterPipeNotification(WaterPipeNotificationIcon.NotEnoughWaterCapacityNotification, value, true);
        }
        private void OnWaterPipeNotEnoughSewageCapacityNotificationToggle(bool value) {
            m_WaterPipeNotEnoughSewageCapacityNotificationBinding.Update(value);
            CwdSettings.Instance.Notification.WaterPipeNotEnoughSewageCapacityNotification = value;
            m_AlertIconSystem.EnableWaterPipeNotification(WaterPipeNotificationIcon.NotEnoughSewageCapacityNotification, value, true);
        }
        private void OnWaterPipeNotEnoughGroundwaterNotificationToggle(bool value) {
            m_WaterPipeNotEnoughGroundwaterNotificationBinding.Update(value);
            CwdSettings.Instance.Notification.WaterPipeNotEnoughGroundwaterNotification = value;
            m_AlertIconSystem.EnableWaterPipeNotification(WaterPipeNotificationIcon.NotEnoughGroundwaterNotification, value, true);
        }
        private void OnWaterPipeNotEnoughSurfaceWaterNotificationToggle(bool value) {
            m_WaterPipeNotEnoughSurfaceWaterNotificationBinding.Update(value);
            CwdSettings.Instance.Notification.WaterPipeNotEnoughSurfaceWaterNotification = value;
            m_AlertIconSystem.EnableWaterPipeNotification(WaterPipeNotificationIcon.NotEnoughSurfaceWaterNotification, value, true);
        }
        private void OnWaterPipeDirtyWaterPumpNotificationToggle(bool value) {
            m_WaterPipeDirtyWaterPumpNotificationBinding.Update(value);
            CwdSettings.Instance.Notification.WaterPipeDirtyWaterPumpNotification = value;
            m_AlertIconSystem.EnableWaterPipeNotification(WaterPipeNotificationIcon.DirtyWaterPumpNotification, value, true);
        }
        #endregion

        #region OnBuildingNotificationToggle
        private void OnBuildingAbandonedCollapsedNotificationToggle(bool value) {
            m_BuildingAbandonedCollapsedNotificationBinding.Update(value);
            CwdSettings.Instance.Notification.BuildingAbandonedCollapsedNotification = value;
            m_AlertIconSystem.EnableBuildingNotification(BuildingNotificationIcon.AbandonedCollapsedNotification, value, true);
        }
        private void OnBuildingAbandonedNotificationToggle(bool value) {
            m_BuildingAbandonedNotificationBinding.Update(value);
            CwdSettings.Instance.Notification.BuildingAbandonedNotification = value;
            m_AlertIconSystem.EnableBuildingNotification(BuildingNotificationIcon.AbandonedNotification, value, true);
        }
        private void OnBuildingCondemnedNotificationToggle(bool value) {
            m_BuildingCondemnedNotificationBinding.Update(value);
            CwdSettings.Instance.Notification.BuildingCondemnedNotification = value;
            m_AlertIconSystem.EnableBuildingNotification(BuildingNotificationIcon.CondemnedNotification, value, true);
        }
        private void OnBuildingTurnedOffNotificationToggle(bool value) {
            m_BuildingTurnedOffNotificationBinding.Update(value);
            CwdSettings.Instance.Notification.BuildingTurnedOffNotification = value;
            m_AlertIconSystem.EnableBuildingNotification(BuildingNotificationIcon.TurnedOffNotification, value, true);
        }
        private void OnBuildingHighRentNotificationToggle(bool value) {
            m_BuildingHighRentNotificationBinding.Update(value);
            CwdSettings.Instance.Notification.BuildingHighRentNotification = value;
            m_AlertIconSystem.EnableBuildingNotification(BuildingNotificationIcon.HighRentNotification, value, true);
        }
        private void OnBuildingLevelingNotificationToggle(bool value) {
            m_BuildingLevelingNotificationBinding.Update(value);
            CwdSettings.Instance.Notification.BuildingLevelingNotification = value;
            m_AlertIconSystem.EnableBuildingNotification(BuildingNotificationIcon.LevelingNotification, value, true);
        }
        #endregion

        #region OnTrafficNotificationToggle
        private void OnTrafficBottleneckNotificationToggle(bool value) {
            m_TrafficBottleneckNotificationBinding.Update(value);
            CwdSettings.Instance.Notification.TrafficBottleneckNotification = value;
            m_AlertIconSystem.EnableTrafficNotification(TrafficNotificationIcon.BottleneckNotification, value, true);
        }
        private void OnTrafficDeadEndNotificationToggle(bool value) {
            m_TrafficDeadEndNotificationBinding.Update(value);
            CwdSettings.Instance.Notification.TrafficDeadEndNotification = value;
            m_AlertIconSystem.EnableTrafficNotification(TrafficNotificationIcon.DeadEndNotification, value, true);
        }
        private void OnTrafficRoadConnectionNotificationToggle(bool value) {
            m_TrafficRoadConnectionNotificationBinding.Update(value);
            CwdSettings.Instance.Notification.TrafficRoadConnectionNotification = value;
            m_AlertIconSystem.EnableTrafficNotification(TrafficNotificationIcon.RoadConnectionNotification, value, true);
        }
        private void OnTrafficTrackConnectionNotificationToggle(bool value) {
            m_TrafficTrackConnectionNotificationBinding.Update(value);
            CwdSettings.Instance.Notification.TrafficTrackConnectionNotification = value;
            m_AlertIconSystem.EnableTrafficNotification(TrafficNotificationIcon.TrackConnectionNotification, value, true);
        }
        private void OnTrafficCarConnectionNotificationToggle(bool value) {
            m_TrafficCarConnectionNotificationBinding.Update(value);
            CwdSettings.Instance.Notification.TrafficCarConnectionNotification = value;
            m_AlertIconSystem.EnableTrafficNotification(TrafficNotificationIcon.CarConnectionNotification, value, true);
        }
        private void OnTrafficShipConnectionNotificationToggle(bool value) {
            m_TrafficShipConnectionNotificationBinding.Update(value);
            CwdSettings.Instance.Notification.TrafficShipConnectionNotification = value;
            m_AlertIconSystem.EnableTrafficNotification(TrafficNotificationIcon.ShipConnectionNotification, value, true);
        }
        private void OnTrafficTrainConnectionNotificationToggle(bool value) {
            m_TrafficTrainConnectionNotificationBinding.Update(value);
            CwdSettings.Instance.Notification.TrafficTrainConnectionNotification = value;
            m_AlertIconSystem.EnableTrafficNotification(TrafficNotificationIcon.TrainConnectionNotification, value, true);
        }
        private void OnTrafficPedestrianConnectionNotificationToggle(bool value) {
            m_TrafficPedestrianConnectionNotificationBinding.Update(value);
            CwdSettings.Instance.Notification.TrafficPedestrianConnectionNotification = value;
            m_AlertIconSystem.EnableTrafficNotification(TrafficNotificationIcon.PedestrianConnectionNotification, value, true);
        }
        private void OnTrafficBicycleConnectionNotificationToggle(bool value) {
            m_TrafficBicycleConnectionNotificationBinding.Update(value);
            CwdSettings.Instance.Notification.TrafficBicycleConnectionNotification = value;
            m_AlertIconSystem.EnableTrafficNotification(TrafficNotificationIcon.BicycleConnectionNotification, value, true);
        }
        #endregion

        #region OnCompanyNotificationToggle
        private void OnCompanyNoInputsNotificationToggle(bool value) {
            m_CompanyNoInputsNotificationBinding.Update(value);
            CwdSettings.Instance.Notification.CompanyNoInputsNotification = value;
            m_AlertIconSystem.EnableCompanyNotification(CompanyNotificationIcon.NoInputsNotification, value, true);
        }
        private void OnCompanyNoCustomersNotificationToggle(bool value) {
            m_CompanyNoCustomersNotificationBinding.Update(value);
            CwdSettings.Instance.Notification.CompanyNoCustomersNotification = value;
            m_AlertIconSystem.EnableCompanyNotification(CompanyNotificationIcon.NoCustomersNotification, value, true);
        }
        #endregion

        #region OnWorkProviderNotificationToggle
        private void OnWorkProviderUneducatedNotificationToggle(bool value) {
            m_WorkProviderUneducatedNotificationBinding.Update(value);
            CwdSettings.Instance.Notification.WorkProviderUneducatedNotification = value;
            m_AlertIconSystem.EnableWorkProviderNotification(WorkProviderNotificationIcon.UneducatedNotification, value, true);
        }
        private void OnWorkProviderEducatedNotificationToggle(bool value) {
            m_WorkProviderEducatedNotificationBinding.Update(value);
            CwdSettings.Instance.Notification.WorkProviderEducatedNotification = value;
            m_AlertIconSystem.EnableWorkProviderNotification(WorkProviderNotificationIcon.EducatedNotification, value, true);
        }
        #endregion

        #region OnDisasterNotificationToggle
        private void OnDisasterWeatherDamageNotificationToggle(bool value) {
            m_DisasterWeatherDamageNotificationBinding.Update(value);
            CwdSettings.Instance.Notification.DisasterWeatherDamageNotification = value;
            m_AlertIconSystem.EnableDisasterNotification(DisasterNotificationIcon.WeatherDamageNotification, value, true);
        }
        private void OnDisasterWeatherDestroyedNotificationToggle(bool value) {
            m_DisasterWeatherDestroyedNotificationBinding.Update(value);
            CwdSettings.Instance.Notification.DisasterWeatherDestroyedNotification = value;
            m_AlertIconSystem.EnableDisasterNotification(DisasterNotificationIcon.WeatherDestroyedNotification, value, true);
        }
        private void OnDisasterWaterDamageNotificationToggle(bool value) {
            m_DisasterWaterDamageNotificationBinding.Update(value);
            CwdSettings.Instance.Notification.DisasterWaterDamageNotification = value;
            m_AlertIconSystem.EnableDisasterNotification(DisasterNotificationIcon.WaterDamageNotification, value, true);
        }
        private void OnDisasterWaterDestroyedNotificationToggle(bool value) {
            m_DisasterWaterDestroyedNotificationBinding.Update(value);
            CwdSettings.Instance.Notification.DisasterWaterDestroyedNotification = value;
            m_AlertIconSystem.EnableDisasterNotification(DisasterNotificationIcon.WaterDestroyedNotification, value, true);
        }
        private void OnDisasterDestroyedNotificationToggle(bool value) {
            m_DisasterDestroyedNotificationBinding.Update(value);
            CwdSettings.Instance.Notification.DisasterDestroyedNotification = value;
            m_AlertIconSystem.EnableDisasterNotification(DisasterNotificationIcon.DestroyedNotification, value, true);
        }
        #endregion

        #region OnFireNotificationToggle
        private void OnFireFireNotificationToggle(bool value) {
            m_FireFireNotificationBinding.Update(value);
            CwdSettings.Instance.Notification.FireFireNotification = value;
            m_AlertIconSystem.EnableFireNotification(FireNotificationIcon.FireNotification, value, true);
        }
        private void OnFireBurnedDownNotificationToggle(bool value) {
            m_FireBurnedDownNotificationBinding.Update(value);
            CwdSettings.Instance.Notification.FireBurnedDownNotification = value;
            m_AlertIconSystem.EnableFireNotification(FireNotificationIcon.BurnedDownNotification, value, true);
        }
        #endregion

        #region OnGarbageNotificationToggle
        private void OnGarbageGarbageNotificationToggle(bool value) {
            m_GarbageGarbageNotificationBinding.Update(value);
            CwdSettings.Instance.Notification.GarbageGarbageNotification = value;
            m_AlertIconSystem.EnableGarbageNotification(GarbageNotificationIcon.GarbageNotification, value, true);
        }
        private void OnGarbageFacilityFullNotificationToggle(bool value) {
            m_GarbageFacilityFullNotificationBinding.Update(value);
            CwdSettings.Instance.Notification.GarbageFacilityFullNotification = value;
            m_AlertIconSystem.EnableGarbageNotification(GarbageNotificationIcon.FacilityFullNotification, value, true);
        }
        #endregion

        #region OnHealthcareNotificationToggle
        private void OnHealthcareAmbulanceNotificationToggle(bool value) {
            m_HealthcareAmbulanceNotificationBinding.Update(value);
            CwdSettings.Instance.Notification.HealthcareAmbulanceNotification = value;
            m_AlertIconSystem.EnableHealthcareNotification(HealthcareNotificationIcon.AmbulanceNotification, value, true);
        }
        private void OnHealthcareHearseNotificationToggle(bool value) {
            m_HealthcareHearseNotificationBinding.Update(value);
            CwdSettings.Instance.Notification.HealthcareHearseNotification = value;
            m_AlertIconSystem.EnableHealthcareNotification(HealthcareNotificationIcon.HearseNotification, value, true);
        }
        private void OnHealthcareFacilityFullNotificationToggle(bool value) {
            m_HealthcareFacilityFullNotificationBinding.Update(value);
            CwdSettings.Instance.Notification.HealthcareFacilityFullNotification = value;
            m_AlertIconSystem.EnableHealthcareNotification(HealthcareNotificationIcon.FacilityFullNotification, value, true);
        }
        #endregion

        #region OnPoliceNotificationToggle
        private void OnPoliceTrafficAccidentNotificationToggle(bool value) {
            m_PoliceTrafficAccidentNotificationBinding.Update(value);
            CwdSettings.Instance.Notification.PoliceTrafficAccidentNotification = value;
            m_AlertIconSystem.EnablePoliceNotification(PoliceNotificationIcon.TrafficAccidentNotification, value, true);
        }
        private void OnPoliceCrimeSceneNotificationToggle(bool value) {
            m_PoliceCrimeSceneNotificationBinding.Update(value);
            CwdSettings.Instance.Notification.PoliceCrimeSceneNotification = value;
            m_AlertIconSystem.EnablePoliceNotification(PoliceNotificationIcon.CrimeSceneNotification, value, true);
        }
        #endregion

        #region OnPollutionNotificationToggle
        private void OnPollutionAirPollutionNotificationToggle(bool value) {
            m_PollutionAirPollutionNotificationBinding.Update(value);
            CwdSettings.Instance.Notification.PollutionAirPollutionNotification = value;
            m_AlertIconSystem.EnablePollutionNotification(PollutionNotificationIcon.AirPollutionNotification, value, true);
        }
        private void OnPollutionNoisePollutionNotificationToggle(bool value) {
            m_PollutionNoisePollutionNotificationBinding.Update(value);
            CwdSettings.Instance.Notification.PollutionNoisePollutionNotification = value;
            m_AlertIconSystem.EnablePollutionNotification(PollutionNotificationIcon.NoisePollutionNotification, value, true);
        }
        private void OnPollutionGroundPollutionNotificationToggle(bool value) {
            m_PollutionGroundPollutionNotificationBinding.Update(value);
            CwdSettings.Instance.Notification.PollutionGroundPollutionNotification = value;
            m_AlertIconSystem.EnablePollutionNotification(PollutionNotificationIcon.GroundPollutionNotification, value, true);
        }
        #endregion

        #region OnResourceConsumerNotificationToggle
        private void OnResourceConsumerNoResourceNotificationToggle(bool value) {
            m_ResourceConsumerNoResourceNotificationBinding.Update(value);
            CwdSettings.Instance.Notification.ResourceConsumerNoResourceNotification = value;
            m_AlertIconSystem.EnableResourceConsumerNotification(ResourceConsumerNotificationIcon.NoResourceNotification, value, true);
        }

        private void OnResourceConsumerNoFuelNotificationToggle(bool value) {
            m_ResourceConsumerNoFuelNotificationBinding.Update(value);
            CwdSettings.Instance.Notification.ResourceConsumerNoFuelNotification = value;
            m_AlertIconSystem.EnableResourceConsumerNotification(ResourceConsumerNotificationIcon.NoFuelNotification, value, true);
        }
        #endregion

        #region OnResourceConnectionNotificationToggle
        private void OnResourceConnectionWarningNotificationToggle(bool value) {
            m_ResourceConnectionWarningNotificationBinding.Update(value);
            CwdSettings.Instance.Notification.ResourceConnectionWarningNotification = value;
            m_AlertIconSystem.EnableResourceConnectionNotification(ResourceConnectionNotificationIcon.ConnectionWarningNotification, value, true);
        }

        private void OnResourceConnectionOilPipeNotConnectedNotificationToggle(bool value) {
            m_ResourceConnectionOilPipeNotConnectedNotificationBinding.Update(value);
            CwdSettings.Instance.Notification.ResourceConnectionOilPipeNotConnectedNotification = value;
            m_AlertIconSystem.EnableResourceConnectionNotification(ResourceConnectionNotificationIcon.OilPipeNotConnectedNotification, value, true);
        }

        private void OnResourceConnectionFishingPierNotConnectedNotificationToggle(bool value) {
            m_ResourceConnectionFishingPierNotConnectedNotificationBinding.Update(value);
            CwdSettings.Instance.Notification.ResourceConnectionFishingPierNotConnectedNotification = value;
            m_AlertIconSystem.EnableResourceConnectionNotification(ResourceConnectionNotificationIcon.FishingPierNotConnectedNotification, value, true);
        }
        #endregion

        #region OnRouteNotificationToggle
        private void OnRoutePathfindNotificationToggle(bool value) {
            m_RoutePathfindNotificationBinding.Update(value);
            CwdSettings.Instance.Notification.RoutePathfindNotification = value;
            m_AlertIconSystem.EnableRouteNotification(RouteNotificationIcon.PathfindNotification, value, true);
        }

        private void OnRouteGateBypassNotificationToggle(bool value) {
            m_RouteGateBypassNotificationBinding.Update(value);
            CwdSettings.Instance.Notification.RouteGateBypassNotification = value;
            m_AlertIconSystem.EnableRouteNotification(RouteNotificationIcon.GateBypassNotification, value, true);
        }
        #endregion

        #region OnTransportLineNotificationToggle
        private void OnTransportLineVehicleNotificationToggle(bool value) {
            m_TransportLineVehicleNotificationBinding.Update(value);
            CwdSettings.Instance.Notification.TransportLineVehicleNotification = value;
            m_AlertIconSystem.EnableTransportLineNotification(TransportLineNotificationIcon.VehicleNotification, value, true);
        }
        #endregion

        protected override void OnUpdate()
        {
            RefreshKeybindActions();

            if (!IsInGame())
            {
                return;
            }

            if (m_ToggleNotificationPanelAction?.WasReleasedThisFrame() == true)
            {
                ToggleControlPanelFromHotkey();
                return;
            }

            if (m_ToggleNotificationsAction?.WasReleasedThisFrame() == true)
            {
                ToggleAllNotificationsFromHotkey();
            }

            bool shouldUpdateCounts =
                m_PanelVisibleBinding.Value
                    ? m_NotificationCountUpdateState.Advance()
                    : m_MiniHudEnabledBinding.value && m_MiniHudCountUpdateState.Advance();

            if (shouldUpdateCounts)
            {
                int[] nextCounts = m_AlertIconSystem.GetNotificationCounts();

                if (!m_HasLastNotificationCounts || !AreSameNotificationCounts(m_LastNotificationCounts, nextCounts))
                {
                    Array.Copy(nextCounts, m_LastNotificationCounts, nextCounts.Length);
                    m_HasLastNotificationCounts = true;
                    m_NotificationCountsBinding.Update(nextCounts);
                }
            }
        }


        private static bool AreSameNotificationCounts(int[] previous, int[] next)
        {
            if (previous.Length != next.Length)
            {
                return false;
            }

            for (int i = 0; i < previous.Length; i++)
            {
                if (previous[i] != next[i])
                {
                    return false;
                }
            }

            return true;
        }

        private void InitializeKeybindActions()
        {
            m_ToggleNotificationsAction = EnableAction(CwdSettings.ToggleNotificationsAction);
            m_ToggleNotificationPanelAction = EnableAction(CwdSettings.ToggleNotificationPanelAction);
        }

        private void RefreshKeybindActions()
        {
            m_ToggleNotificationsAction ??= EnableAction(CwdSettings.ToggleNotificationsAction);

            m_ToggleNotificationPanelAction ??= EnableAction(CwdSettings.ToggleNotificationPanelAction);
        }

        private void ToggleAllNotificationsFromHotkey()
        {
            bool enabled = !AreAllNotificationSettingsEnabled();

            ApplyAllNotificationToggles(enabled);
        }

        private void ApplyAllNotificationToggles(bool enabled)
        {
            // Shared path for the hotkey and panel Toggle All button.
            // The controller applies icon state in bulk, then bindings update panel state.
            m_AlertIconSystem.SetAllNotifications(enabled);
            UpdateAllNotificationBindings(enabled);

            // Show/Hide Icons no longer matches either saved slot, so drop the "selected" ring.
            SetActivePreset(0);
        }

        private void UpdateAllNotificationBindings(bool enabled)
        {
            // Keep this list aligned with CwdSettings.NotificationSetting and the BoolBinding fields above.
            m_ElectricElectricNotificationBinding.Update(enabled);
            m_ElectricBottleneckNotificationBinding.Update(enabled);
            m_ElectricBuildingBottleneckNotificationBinding.Update(enabled);
            m_ElectricNotEnoughProductionNotificationBinding.Update(enabled);
            m_ElectricTransformerNotificationBinding.Update(enabled);
            m_ElectricNotEnoughConnectedNotificationBinding.Update(enabled);
            m_ElectricBatteryEmptyNotificationBinding.Update(enabled);
            m_ElectricLowVoltageNotConnectedBinding.Update(enabled);
            m_ElectricHighVoltageNotConnectedBinding.Update(enabled);

            m_WaterPipeWaterNotificationBinding.Update(enabled);
            m_WaterPipeDirtyWaterNotificationBinding.Update(enabled);
            m_WaterPipeSewageNotificationBinding.Update(enabled);
            m_WaterPipeWaterPipeNotConnectedNotificationBinding.Update(enabled);
            m_WaterPipeSewagePipeNotConnectedNotificationBinding.Update(enabled);
            m_WaterPipeNotEnoughWaterCapacityNotificationBinding.Update(enabled);
            m_WaterPipeNotEnoughSewageCapacityNotificationBinding.Update(enabled);
            m_WaterPipeNotEnoughGroundwaterNotificationBinding.Update(enabled);
            m_WaterPipeNotEnoughSurfaceWaterNotificationBinding.Update(enabled);
            m_WaterPipeDirtyWaterPumpNotificationBinding.Update(enabled);

            m_BuildingAbandonedCollapsedNotificationBinding.Update(enabled);
            m_BuildingAbandonedNotificationBinding.Update(enabled);
            m_BuildingCondemnedNotificationBinding.Update(enabled);
            m_BuildingTurnedOffNotificationBinding.Update(enabled);
            m_BuildingHighRentNotificationBinding.Update(enabled);
            // Deliberately NOT updated here: Leveling is an optional/positive row that Toggle All
            // and the N hotkey leave alone (its real setting is never touched by SetAllNotificationSettings
            // either) — only its own manual checkbox should change it.

            m_TrafficBottleneckNotificationBinding.Update(enabled);
            m_TrafficDeadEndNotificationBinding.Update(enabled);
            m_TrafficRoadConnectionNotificationBinding.Update(enabled);
            m_TrafficTrackConnectionNotificationBinding.Update(enabled);
            m_TrafficCarConnectionNotificationBinding.Update(enabled);
            m_TrafficShipConnectionNotificationBinding.Update(enabled);
            m_TrafficTrainConnectionNotificationBinding.Update(enabled);
            m_TrafficPedestrianConnectionNotificationBinding.Update(enabled);
            m_TrafficBicycleConnectionNotificationBinding.Update(enabled);

            m_CompanyNoInputsNotificationBinding.Update(enabled);
            m_CompanyNoCustomersNotificationBinding.Update(enabled);

            m_WorkProviderUneducatedNotificationBinding.Update(enabled);
            m_WorkProviderEducatedNotificationBinding.Update(enabled);

            m_DisasterWeatherDamageNotificationBinding.Update(enabled);
            m_DisasterWeatherDestroyedNotificationBinding.Update(enabled);
            m_DisasterWaterDamageNotificationBinding.Update(enabled);
            m_DisasterWaterDestroyedNotificationBinding.Update(enabled);
            m_DisasterDestroyedNotificationBinding.Update(enabled);

            m_FireFireNotificationBinding.Update(enabled);
            m_FireBurnedDownNotificationBinding.Update(enabled);

            m_GarbageGarbageNotificationBinding.Update(enabled);
            m_GarbageFacilityFullNotificationBinding.Update(enabled);

            m_HealthcareAmbulanceNotificationBinding.Update(enabled);
            m_HealthcareHearseNotificationBinding.Update(enabled);
            m_HealthcareFacilityFullNotificationBinding.Update(enabled);

            m_PoliceTrafficAccidentNotificationBinding.Update(enabled);
            m_PoliceCrimeSceneNotificationBinding.Update(enabled);

            m_PollutionAirPollutionNotificationBinding.Update(enabled);
            m_PollutionNoisePollutionNotificationBinding.Update(enabled);
            m_PollutionGroundPollutionNotificationBinding.Update(enabled);

            m_ResourceConsumerNoResourceNotificationBinding.Update(enabled);
            m_ResourceConsumerNoFuelNotificationBinding.Update(enabled);
            m_ResourceConnectionWarningNotificationBinding.Update(enabled);
            m_ResourceConnectionOilPipeNotConnectedNotificationBinding.Update(enabled);
            m_ResourceConnectionFishingPierNotConnectedNotificationBinding.Update(enabled);
            m_RoutePathfindNotificationBinding.Update(enabled);
            m_RouteGateBypassNotificationBinding.Update(enabled);
            m_TransportLineVehicleNotificationBinding.Update(enabled);
        }

        // Save the current checkboxes into a preset slot ("hold" gesture on the panel's 1 | 2 button).
        private void SavePreset(int slot)
        {
            CwdSettings.NotificationSetting live = CwdSettings.Instance.Notification;

            if (slot == 1)
            {
                CwdSettings.Instance.Preset1.CopyFrom(live);
                CwdSettings.Instance.Preset1Saved = true;
                m_Preset1SavedBinding.Update(true);
            }
            else if (slot == 2)
            {
                CwdSettings.Instance.Preset2.CopyFrom(live);
                CwdSettings.Instance.Preset2Saved = true;
                m_Preset2SavedBinding.Update(true);
            }
            else
            {
                return;
            }

            SetActivePreset(slot);
            TrySavePresetSettings("preset-save");
        }

        // Load a saved preset into the live checkboxes ("click" gesture on the panel's 1 | 2 button).
        // A never-saved slot is a no-op so a fresh install cannot blank the live set with an empty preset.
        private void LoadPreset(int slot)
        {
            CwdSettings.NotificationSetting source;

            if (slot == 1)
            {
                if (!CwdSettings.Instance.Preset1Saved)
                {
                    return;
                }
                source = CwdSettings.Instance.Preset1;
            }
            else if (slot == 2)
            {
                if (!CwdSettings.Instance.Preset2Saved)
                {
                    return;
                }
                source = CwdSettings.Instance.Preset2;
            }
            else
            {
                return;
            }

            // Copy snapshot -> live, apply to the map icons in one batched pass, then push every panel
            // checkbox binding so the rows reflect the loaded layout.
            CwdSettings.Instance.Notification.CopyFrom(source);
            m_AlertIconSystem.ApplyNotificationSettings();
            PushNotificationBindingsFromSettings();
            SetActivePreset(slot);
            TrySavePresetSettings("preset-load");
        }

        private void SetActivePreset(int slot)
        {
            CwdSettings.Instance.ActivePreset = slot;
            m_ActivePresetBinding.Update(slot);
        }

        // Mirrors UpdateAllNotificationBindings but pushes each notification's OWN saved value (used
        // after a preset load, where slots differ per notification). Includes BuildingLeveling, which
        // the bulk Toggle All path deliberately skips.
        private void PushNotificationBindingsFromSettings()
        {
            CwdSettings.NotificationSetting n = CwdSettings.Instance.Notification;

            m_ElectricElectricNotificationBinding.Update(n.ElectricityElectricityNotification);
            m_ElectricBottleneckNotificationBinding.Update(n.ElectricityBottleneckNotification);
            m_ElectricBuildingBottleneckNotificationBinding.Update(n.ElectricityBuildingBottleneckNotification);
            m_ElectricNotEnoughProductionNotificationBinding.Update(n.ElectricityNotEnoughProductionNotification);
            m_ElectricTransformerNotificationBinding.Update(n.ElectricityTransformerNotification);
            m_ElectricNotEnoughConnectedNotificationBinding.Update(n.ElectricityNotEnoughConnectedNotification);
            m_ElectricBatteryEmptyNotificationBinding.Update(n.ElectricityBatteryEmptyNotification);
            m_ElectricLowVoltageNotConnectedBinding.Update(n.ElectricityLowVoltageNotConnected);
            m_ElectricHighVoltageNotConnectedBinding.Update(n.ElectricityHighVoltageNotConnected);

            m_WaterPipeWaterNotificationBinding.Update(n.WaterPipeWaterNotification);
            m_WaterPipeDirtyWaterNotificationBinding.Update(n.WaterPipeDirtyWaterNotification);
            m_WaterPipeSewageNotificationBinding.Update(n.WaterPipeSewageNotification);
            m_WaterPipeWaterPipeNotConnectedNotificationBinding.Update(n.WaterPipeWaterPipeNotConnectedNotification);
            m_WaterPipeSewagePipeNotConnectedNotificationBinding.Update(n.WaterPipeSewagePipeNotConnectedNotification);
            m_WaterPipeNotEnoughWaterCapacityNotificationBinding.Update(n.WaterPipeNotEnoughWaterCapacityNotification);
            m_WaterPipeNotEnoughSewageCapacityNotificationBinding.Update(n.WaterPipeNotEnoughSewageCapacityNotification);
            m_WaterPipeNotEnoughGroundwaterNotificationBinding.Update(n.WaterPipeNotEnoughGroundwaterNotification);
            m_WaterPipeNotEnoughSurfaceWaterNotificationBinding.Update(n.WaterPipeNotEnoughSurfaceWaterNotification);
            m_WaterPipeDirtyWaterPumpNotificationBinding.Update(n.WaterPipeDirtyWaterPumpNotification);

            m_BuildingAbandonedCollapsedNotificationBinding.Update(n.BuildingAbandonedCollapsedNotification);
            m_BuildingAbandonedNotificationBinding.Update(n.BuildingAbandonedNotification);
            m_BuildingCondemnedNotificationBinding.Update(n.BuildingCondemnedNotification);
            m_BuildingTurnedOffNotificationBinding.Update(n.BuildingTurnedOffNotification);
            m_BuildingHighRentNotificationBinding.Update(n.BuildingHighRentNotification);
            m_BuildingLevelingNotificationBinding.Update(n.BuildingLevelingNotification);

            m_TrafficBottleneckNotificationBinding.Update(n.TrafficBottleneckNotification);
            m_TrafficDeadEndNotificationBinding.Update(n.TrafficDeadEndNotification);
            m_TrafficRoadConnectionNotificationBinding.Update(n.TrafficRoadConnectionNotification);
            m_TrafficTrackConnectionNotificationBinding.Update(n.TrafficTrackConnectionNotification);
            m_TrafficCarConnectionNotificationBinding.Update(n.TrafficCarConnectionNotification);
            m_TrafficShipConnectionNotificationBinding.Update(n.TrafficShipConnectionNotification);
            m_TrafficTrainConnectionNotificationBinding.Update(n.TrafficTrainConnectionNotification);
            m_TrafficPedestrianConnectionNotificationBinding.Update(n.TrafficPedestrianConnectionNotification);
            m_TrafficBicycleConnectionNotificationBinding.Update(n.TrafficBicycleConnectionNotification);

            m_CompanyNoInputsNotificationBinding.Update(n.CompanyNoInputsNotification);
            m_CompanyNoCustomersNotificationBinding.Update(n.CompanyNoCustomersNotification);

            m_WorkProviderUneducatedNotificationBinding.Update(n.WorkProviderUneducatedNotification);
            m_WorkProviderEducatedNotificationBinding.Update(n.WorkProviderEducatedNotification);

            m_DisasterWeatherDamageNotificationBinding.Update(n.DisasterWeatherDamageNotification);
            m_DisasterWeatherDestroyedNotificationBinding.Update(n.DisasterWeatherDestroyedNotification);
            m_DisasterWaterDamageNotificationBinding.Update(n.DisasterWaterDamageNotification);
            m_DisasterWaterDestroyedNotificationBinding.Update(n.DisasterWaterDestroyedNotification);
            m_DisasterDestroyedNotificationBinding.Update(n.DisasterDestroyedNotification);

            m_FireFireNotificationBinding.Update(n.FireFireNotification);
            m_FireBurnedDownNotificationBinding.Update(n.FireBurnedDownNotification);

            m_GarbageGarbageNotificationBinding.Update(n.GarbageGarbageNotification);
            m_GarbageFacilityFullNotificationBinding.Update(n.GarbageFacilityFullNotification);

            m_HealthcareAmbulanceNotificationBinding.Update(n.HealthcareAmbulanceNotification);
            m_HealthcareHearseNotificationBinding.Update(n.HealthcareHearseNotification);
            m_HealthcareFacilityFullNotificationBinding.Update(n.HealthcareFacilityFullNotification);

            m_PoliceTrafficAccidentNotificationBinding.Update(n.PoliceTrafficAccidentNotification);
            m_PoliceCrimeSceneNotificationBinding.Update(n.PoliceCrimeSceneNotification);

            m_PollutionAirPollutionNotificationBinding.Update(n.PollutionAirPollutionNotification);
            m_PollutionNoisePollutionNotificationBinding.Update(n.PollutionNoisePollutionNotification);
            m_PollutionGroundPollutionNotificationBinding.Update(n.PollutionGroundPollutionNotification);

            m_ResourceConsumerNoResourceNotificationBinding.Update(n.ResourceConsumerNoResourceNotification);
            m_ResourceConsumerNoFuelNotificationBinding.Update(n.ResourceConsumerNoFuelNotification);
            m_ResourceConnectionWarningNotificationBinding.Update(n.ResourceConnectionWarningNotification);
            m_ResourceConnectionOilPipeNotConnectedNotificationBinding.Update(n.ResourceConnectionOilPipeNotConnectedNotification);
            m_ResourceConnectionFishingPierNotConnectedNotificationBinding.Update(n.ResourceConnectionFishingPierNotConnectedNotification);

            m_RoutePathfindNotificationBinding.Update(n.RoutePathfindNotification);
            m_RouteGateBypassNotificationBinding.Update(n.RouteGateBypassNotification);

            m_TransportLineVehicleNotificationBinding.Update(n.TransportLineVehicleNotification);
        }

        private static void TrySavePresetSettings(string tag)
        {
            try
            {
                CwdSettings.Instance.ApplyAndSave();
            }
            catch (Exception ex)
            {
                LogUtils.WarnOnce(
                    tag,
                    () => $"Failed to persist notification preset: {ex.GetType().Name}: {ex.Message}",
                    ex);
            }
        }

        private static bool AreAllNotificationSettingsEnabled()
        {
            // Keep this list aligned with CwdSettings.NotificationSetting.
            CwdSettings.NotificationSetting notification = CwdSettings.Instance.Notification;

            return notification.ElectricityElectricityNotification &&
                   notification.ElectricityBottleneckNotification &&
                   notification.ElectricityBuildingBottleneckNotification &&
                   notification.ElectricityNotEnoughProductionNotification &&
                   notification.ElectricityTransformerNotification &&
                   notification.ElectricityNotEnoughConnectedNotification &&
                   notification.ElectricityBatteryEmptyNotification &&
                   notification.ElectricityLowVoltageNotConnected &&
                   notification.ElectricityHighVoltageNotConnected &&
                   notification.WaterPipeWaterNotification &&
                   notification.WaterPipeDirtyWaterNotification &&
                   notification.WaterPipeSewageNotification &&
                   notification.WaterPipeWaterPipeNotConnectedNotification &&
                   notification.WaterPipeSewagePipeNotConnectedNotification &&
                   notification.WaterPipeNotEnoughWaterCapacityNotification &&
                   notification.WaterPipeNotEnoughSewageCapacityNotification &&
                   notification.WaterPipeNotEnoughGroundwaterNotification &&
                   notification.WaterPipeNotEnoughSurfaceWaterNotification &&
                   notification.WaterPipeDirtyWaterPumpNotification &&
                   notification.BuildingAbandonedCollapsedNotification &&
                   notification.BuildingAbandonedNotification &&
                   notification.BuildingCondemnedNotification &&
                   notification.BuildingTurnedOffNotification &&
                   notification.BuildingHighRentNotification &&
                   notification.TrafficBottleneckNotification &&
                   notification.TrafficDeadEndNotification &&
                   notification.TrafficRoadConnectionNotification &&
                   notification.TrafficTrackConnectionNotification &&
                   notification.TrafficCarConnectionNotification &&
                   notification.TrafficShipConnectionNotification &&
                   notification.TrafficTrainConnectionNotification &&
                   notification.TrafficPedestrianConnectionNotification &&
                   notification.TrafficBicycleConnectionNotification &&
                   notification.CompanyNoInputsNotification &&
                   notification.CompanyNoCustomersNotification &&
                   notification.WorkProviderUneducatedNotification &&
                   notification.WorkProviderEducatedNotification &&
                   notification.DisasterWeatherDamageNotification &&
                   notification.DisasterWeatherDestroyedNotification &&
                   notification.DisasterWaterDamageNotification &&
                   notification.DisasterWaterDestroyedNotification &&
                   notification.DisasterDestroyedNotification &&
                   notification.FireFireNotification &&
                   notification.FireBurnedDownNotification &&
                   notification.GarbageGarbageNotification &&
                   notification.GarbageFacilityFullNotification &&
                   notification.HealthcareAmbulanceNotification &&
                   notification.HealthcareHearseNotification &&
                   notification.HealthcareFacilityFullNotification &&
                   notification.PoliceTrafficAccidentNotification &&
                   notification.PoliceCrimeSceneNotification &&
                   notification.PollutionAirPollutionNotification &&
                   notification.PollutionNoisePollutionNotification &&
                   notification.PollutionGroundPollutionNotification &&
                   notification.ResourceConsumerNoResourceNotification &&
                   notification.ResourceConsumerNoFuelNotification &&
                   notification.ResourceConnectionWarningNotification &&
                   notification.ResourceConnectionOilPipeNotConnectedNotification &&
                   notification.ResourceConnectionFishingPierNotConnectedNotification &&
                   notification.RoutePathfindNotification &&
                   notification.RouteGateBypassNotification &&
                   notification.TransportLineVehicleNotification;
        }

        private static bool IsInGame()
        {
            return GameManager.instance != null &&
                   GameManager.instance.gameMode == GameMode.Game;
        }

        private static ProxyAction? EnableAction(string actionName)
        {
            try
            {
                ProxyAction? action = CwdSettings.Instance.GetAction(actionName);
                if (action != null)
                {
                    action.shouldBeEnabled = true;
                }

                return action;
            }
            catch (Exception ex)
            {
                LogUtils.WarnOnce(
                    "missing-keybind-" + actionName,
                    () => $"Keybinding action '{actionName}' is unavailable: {ex.GetType().Name}: {ex.Message}",
                    ex);
                return null;
            }
        }

        private void OnControlPanelBindingToggle(bool value)
        {
            m_PanelVisibleBinding.Update(value);
            if (value)
            {
                m_NotificationCountUpdateState.ForceUpdate();
            }
        }

        private void ToggleControlPanelFromHotkey()
        {
            bool visible = !m_PanelVisibleBinding.Value;
            m_PanelVisibleBinding.Update(visible);
            if (visible)
            {
                m_NotificationCountUpdateState.ForceUpdate();
            }
        }

        private void JumpToMiniHudNotification(int index)
        {
            if (!m_AlertIconSystem.TryGetNextNotificationEntity(index, out Entity entity) ||
                !EntityManager.Exists(entity))
            {
                return;
            }

            ToolSystem toolSystem = World.GetOrCreateSystemManaged<ToolSystem>();
            CameraUpdateSystem cameraSystem = World.GetOrCreateSystemManaged<CameraUpdateSystem>();

            toolSystem.selected = entity;
            cameraSystem.orbitCameraController.followedEntity = entity;
            cameraSystem.orbitCameraController.TryMatchPosition(cameraSystem.activeCameraController);
            cameraSystem.activeCameraController = cameraSystem.orbitCameraController;
        }

        private void ToggleMiniHudFavorite(int index)
        {
            if (index < 0 || index >= AlertIconSystem.NotificationCountLength)
            {
                return;
            }

            if (index < 31)
            {
                CwdSettings.Instance.MiniHudFavoriteMaskLow ^= 1 << index;
            }
            else
            {
                CwdSettings.Instance.MiniHudFavoriteMaskHigh ^= 1 << (index - 31);
            }

            try
            {
                CwdSettings.Instance.ApplyAndSave();
            }
            catch (Exception ex)
            {
                LogUtils.WarnOnce(
                    "mini-hud-favorites-save",
                    () => $"Failed to save mini HUD favorites: {ex.GetType().Name}: {ex.Message}",
                    ex);
            }

            m_MiniHudFavoritesBinding.Update(GetMiniHudFavoriteIndexes());
        }

        private void SaveMiniHudPosition(string payload)
        {
            if (CwdSettings.Instance.MiniHudPlacement != CwdSettings.kMiniHudPlacementDraggable ||
                string.IsNullOrWhiteSpace(payload))
            {
                return;
            }

            string[] parts = payload.Split(',');
            if (parts.Length != 3 ||
                !int.TryParse(parts[0], out int orientation) ||
                !int.TryParse(parts[1], out int x) ||
                !int.TryParse(parts[2], out int y))
            {
                return;
            }

            if (orientation != CwdSettings.Instance.MiniHudOrientation)
            {
                return;
            }

            x = Math.Clamp(x, -CwdSettings.kMiniHudPositionLimit, CwdSettings.kMiniHudPositionLimit);
            y = Math.Clamp(y, -CwdSettings.kMiniHudPositionLimit, CwdSettings.kMiniHudPositionLimit);

            if (orientation == CwdSettings.kMiniHudOrientationHorizontal)
            {
                if (CwdSettings.Instance.MiniHudHorizontalPositionX == x &&
                    CwdSettings.Instance.MiniHudHorizontalPositionY == y)
                {
                    return;
                }

                CwdSettings.Instance.MiniHudHorizontalPositionX = x;
                CwdSettings.Instance.MiniHudHorizontalPositionY = y;
            }
            else if (orientation == CwdSettings.kMiniHudOrientationVertical)
            {
                if (CwdSettings.Instance.MiniHudVerticalPositionX == x &&
                    CwdSettings.Instance.MiniHudVerticalPositionY == y)
                {
                    return;
                }

                CwdSettings.Instance.MiniHudVerticalPositionX = x;
                CwdSettings.Instance.MiniHudVerticalPositionY = y;
            }
            else
            {
                return;
            }

            CwdSettings.Instance.MiniHudPositionX = x;
            CwdSettings.Instance.MiniHudPositionY = y;
            CwdSettings.Instance.MiniHudPositionOrientation = orientation;
            UpdateMiniHudPositionBinding(x, y, orientation);

            try
            {
                CwdSettings.Instance.ApplyAndSave();
            }
            catch (Exception ex)
            {
                LogUtils.WarnOnce(
                    "mini-hud-position-save",
                    () => $"Failed to save Mini HUD position: {ex.GetType().Name}: {ex.Message}",
                    ex);
            }
        }

        private void SavePanelPosition(string payload)
        {
            if (string.IsNullOrWhiteSpace(payload))
            {
                return;
            }

            string[] parts = payload.Split(',');
            if (parts.Length != 2 ||
                !int.TryParse(parts[0], out int x) ||
                !int.TryParse(parts[1], out int y))
            {
                return;
            }

            x = Math.Clamp(x, -CwdSettings.kPanelPositionLimit, CwdSettings.kPanelPositionLimit);
            y = Math.Clamp(y, -CwdSettings.kPanelPositionLimit, CwdSettings.kPanelPositionLimit);

            if (CwdSettings.Instance.PanelPositionX == x && CwdSettings.Instance.PanelPositionY == y)
            {
                return;
            }

            CwdSettings.Instance.PanelPositionX = x;
            CwdSettings.Instance.PanelPositionY = y;
            m_PanelPositionXBinding.Update(x);
            m_PanelPositionYBinding.Update(y);

            try
            {
                CwdSettings.Instance.ApplyAndSave();
            }
            catch (Exception ex)
            {
                LogUtils.WarnOnce(
                    "panel-position-save",
                    () => $"Failed to save panel position: {ex.GetType().Name}: {ex.Message}",
                    ex);
            }
        }

        private void SavePanelCollapsedSections(int mask)
        {
            if (CwdSettings.Instance.PanelCollapsedSectionsMask == mask)
            {
                return;
            }

            CwdSettings.Instance.PanelCollapsedSectionsMask = mask;
            m_PanelCollapsedSectionsMaskBinding.Update(mask);

            try
            {
                CwdSettings.Instance.ApplyAndSave();
            }
            catch (Exception ex)
            {
                LogUtils.WarnOnce(
                    "panel-collapsed-sections-save",
                    () => $"Failed to save panel collapsed sections: {ex.GetType().Name}: {ex.Message}",
                    ex);
            }
        }

        private void SavePanelSortMode(int mode)
        {
            if (mode < 0 || mode > 2 || CwdSettings.Instance.PanelSortMode == mode)
            {
                return;
            }

            CwdSettings.Instance.PanelSortMode = mode;
            m_PanelSortModeBinding.Update(mode);

            try
            {
                CwdSettings.Instance.ApplyAndSave();
            }
            catch (Exception ex)
            {
                LogUtils.WarnOnce(
                    "panel-sort-mode-save",
                    () => $"Failed to save panel sort mode: {ex.GetType().Name}: {ex.Message}",
                    ex);
            }
        }

        private static int[] GetMiniHudFavoriteIndexes()
        {
            System.Collections.Generic.List<int> favorites = new();
            for (int index = 0; index < AlertIconSystem.NotificationCountLength; index++)
            {
                int mask = index < 31
                    ? CwdSettings.Instance.MiniHudFavoriteMaskLow
                    : CwdSettings.Instance.MiniHudFavoriteMaskHigh;
                int bit = index < 31 ? index : index - 31;
                if ((mask & (1 << bit)) != 0)
                {
                    favorites.Add(index);
                }
            }

            return favorites.ToArray();
        }

        public void UpdateMoneyViewBinding(bool value) => m_MoneyViewBinding?.Update(value);

        public void UpdateMoneyViewModeBinding(int value) => m_MoneyViewModeBinding?.Update(value);

        public void UpdateMoneyTooltipModeBinding(int value) => m_MoneyTooltipModeBinding?.Update(value);

        public void UpdateMoneyTooltipFontScaleBinding(int value) => m_MoneyTooltipFontScaleBinding?.Update(value);

        public void UpdatePopulationTooltipFontScaleBinding(int value) => m_PopulationTooltipFontScaleBinding?.Update(value);

        public void UpdateMiniHudEnabledBinding(bool value)
        {
            m_MiniHudEnabledBinding?.Update(value);
            if (value)
            {
                m_MiniHudCountUpdateState?.ForceUpdate();
            }
        }

        public void UpdateMiniHudModeBinding(int value) => m_MiniHudModeBinding?.Update(value);

        public void UpdateMiniHudItemCountBinding(int value) => m_MiniHudItemCountBinding?.Update(value);

        public void UpdateMiniHudScaleBinding(int value) => m_MiniHudScaleBinding?.Update(value);

        public void UpdateMiniHudOrientationBinding(int value) => m_MiniHudOrientationBinding?.Update(value);

        public void UpdateMiniHudPlacementBinding(int value) => m_MiniHudPlacementBinding?.Update(value);

        public void UpdateMiniHudHideZeroBinding(bool value) => m_MiniHudHideZeroBinding?.Update(value);

        public void UpdateMiniHudPanelStyleBinding(int value) => m_MiniHudPanelStyleBinding?.Update(value);

        public void UpdateMiniHudPanelOpacityBinding(int value) => m_MiniHudPanelOpacityBinding?.Update(value);

        public void UpdateMiniHudFavoritesBinding() => m_MiniHudFavoritesBinding?.Update(GetMiniHudFavoriteIndexes());

        private void UpdateMiniHudPositionBinding(int x, int y, int orientation)
        {
            if (orientation == CwdSettings.kMiniHudOrientationHorizontal)
            {
                m_MiniHudHorizontalPositionXBinding?.Update(x);
                m_MiniHudHorizontalPositionYBinding?.Update(y);
            }
            else if (orientation == CwdSettings.kMiniHudOrientationVertical)
            {
                m_MiniHudVerticalPositionXBinding?.Update(x);
                m_MiniHudVerticalPositionYBinding?.Update(y);
            }
        }

        public void UpdateMiniHudPositionBindings()
        {
            m_MiniHudHorizontalPositionXBinding?.Update(CwdSettings.Instance.MiniHudHorizontalPositionX);
            m_MiniHudHorizontalPositionYBinding?.Update(CwdSettings.Instance.MiniHudHorizontalPositionY);
            m_MiniHudVerticalPositionXBinding?.Update(CwdSettings.Instance.MiniHudVerticalPositionX);
            m_MiniHudVerticalPositionYBinding?.Update(CwdSettings.Instance.MiniHudVerticalPositionY);
        }

        public void UpdatePanelButtonsOnlyStartBinding(bool value) => m_PanelButtonsOnlyStartBinding?.Update(value);

        public void UpdateMainPanelOpacityBinding(int value) => m_MainPanelOpacityBinding?.Update(value);

    }

}
