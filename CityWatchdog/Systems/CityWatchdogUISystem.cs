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
        // Counting alerts scans every icon. Sim-frame throttles for steady updates
        // ForceUpdate refreshes on city first load.
        private const int kPanelCountUpdateInterval = 256;
        private const int kMiniHudCountUpdateInterval = 256;

        private readonly int[] lastNotificationCounts = new int[AlertIconSystem.NotificationCountLength];
        private bool hasLastNotificationCounts;

        private AlertIconSystem alertIconSystem = null!;
        private ProxyAction? toggleNotificationsAction;
        private ProxyAction? toggleNotificationPanelAction;
        private BoolBinding panelVisibleBinding = null!;
        private UIUpdateState notificationCountUpdateState = null!;
        private UIUpdateState miniHudCountUpdateState = null!;
        private ValueBinding<int[]> notificationCountsBinding = null!;
        private ValueBinding<int[]> miniHudFavoritesBinding = null!;
        private ValueBinding<bool> miniHudEnabledBinding = null!;
        private ValueBinding<int> miniHudModeBinding = null!;
        private ValueBinding<int> miniHudItemCountBinding = null!;
        private ValueBinding<int> miniHudScaleBinding = null!;
        private ValueBinding<int> miniHudOrientationBinding = null!;
        private ValueBinding<int> miniHudPlacementBinding = null!;
        private ValueBinding<bool> miniHudHideZeroBinding = null!;
        private ValueBinding<int> miniHudPanelStyleBinding = null!;
        private ValueBinding<int> miniHudPanelOpacityBinding = null!;
        private ValueBinding<int> miniHudHorizontalPositionXBinding = null!;
        private ValueBinding<int> miniHudHorizontalPositionYBinding = null!;
        private ValueBinding<int> miniHudVerticalPositionXBinding = null!;
        private ValueBinding<int> miniHudVerticalPositionYBinding = null!;
        private ValueBinding<int> panelPositionXBinding = null!;
        private ValueBinding<int> panelPositionYBinding = null!;
        private ValueBinding<int> panelCollapsedSectionsMaskBinding = null!;
        private ValueBinding<int> panelSortModeBinding = null!;
        private ValueBinding<bool> panelButtonsOnlyStartBinding = null!;
        private ValueBinding<int> mainPanelOpacityBinding = null!;
        private ValueBinding<bool> preset1SavedBinding = null!;
        private ValueBinding<bool> preset2SavedBinding = null!;
        private ValueBinding<int> activePresetBinding = null!;
        private ValueBinding<bool>? moneyViewBinding;
        private ValueBinding<int>? moneyViewModeBinding;
        private ValueBinding<int>? moneyTooltipModeBinding;
        private ValueBinding<int>? moneyTooltipFontScaleBinding;
        private ValueBinding<int>? populationTooltipFontScaleBinding;

        private BoolBinding electricityElectricityNotificationBinding = null!;
        private BoolBinding electricityBottleneckNotificationBinding = null!;
        private BoolBinding electricityBuildingBottleneckNotificationBinding = null!;
        private BoolBinding electricityNotEnoughProductionNotificationBinding = null!;
        private BoolBinding electricityTransformerNotificationBinding = null!;
        private BoolBinding electricityNotEnoughConnectedNotificationBinding = null!;
        private BoolBinding electricityBatteryEmptyNotificationBinding = null!;
        private BoolBinding electricityLowVoltageNotConnectedBinding = null!;
        private BoolBinding electricityHighVoltageNotConnectedBinding = null!;

        private BoolBinding waterPipeWaterNotificationBinding = null!;
        private BoolBinding waterPipeDirtyWaterNotificationBinding = null!;
        private BoolBinding waterPipeSewageNotificationBinding = null!;
        private BoolBinding waterPipeWaterPipeNotConnectedNotificationBinding = null!;
        private BoolBinding waterPipeSewagePipeNotConnectedNotificationBinding = null!;
        private BoolBinding waterPipeNotEnoughWaterCapacityNotificationBinding = null!;
        private BoolBinding waterPipeNotEnoughSewageCapacityNotificationBinding = null!;
        private BoolBinding waterPipeNotEnoughGroundwaterNotificationBinding = null!;
        private BoolBinding waterPipeNotEnoughSurfaceWaterNotificationBinding = null!;
        private BoolBinding waterPipeDirtyWaterPumpNotificationBinding = null!;

        private BoolBinding buildingAbandonedCollapsedNotificationBinding = null!;
        private BoolBinding buildingAbandonedNotificationBinding = null!;
        private BoolBinding buildingCondemnedNotificationBinding = null!;
        private BoolBinding buildingTurnedOffNotificationBinding = null!;
        private BoolBinding buildingHighRentNotificationBinding = null!;
        private BoolBinding buildingLevelingNotificationBinding = null!;

        private BoolBinding trafficBottleneckNotificationBinding = null!;
        private BoolBinding trafficDeadEndNotificationBinding = null!;
        private BoolBinding trafficRoadConnectionNotificationBinding = null!;
        private BoolBinding trafficTrackConnectionNotificationBinding = null!;
        private BoolBinding trafficCarConnectionNotificationBinding = null!;
        private BoolBinding trafficShipConnectionNotificationBinding = null!;
        private BoolBinding trafficTrainConnectionNotificationBinding = null!;
        private BoolBinding trafficPedestrianConnectionNotificationBinding = null!;
        private BoolBinding trafficBicycleConnectionNotificationBinding = null!;

        private BoolBinding companyNoInputsNotificationBinding = null!;
        private BoolBinding companyNoCustomersNotificationBinding = null!;

        private BoolBinding workProviderUneducatedNotificationBinding = null!;
        private BoolBinding workProviderEducatedNotificationBinding = null!;

        private BoolBinding disasterWeatherDamageNotificationBinding = null!;
        private BoolBinding disasterWeatherDestroyedNotificationBinding = null!;
        private BoolBinding disasterWaterDamageNotificationBinding = null!;
        private BoolBinding disasterWaterDestroyedNotificationBinding = null!;
        private BoolBinding disasterDestroyedNotificationBinding = null!;

        private BoolBinding fireFireNotificationBinding = null!;
        private BoolBinding fireBurnedDownNotificationBinding = null!;

        private BoolBinding garbageGarbageNotificationBinding = null!;
        private BoolBinding garbageFacilityFullNotificationBinding = null!;

        private BoolBinding healthcareAmbulanceNotificationBinding = null!;
        private BoolBinding healthcareHearseNotificationBinding = null!;
        private BoolBinding healthcareFacilityFullNotificationBinding = null!;

        private BoolBinding policeTrafficAccidentNotificationBinding = null!;
        private BoolBinding policeCrimeSceneNotificationBinding = null!;

        private BoolBinding pollutionAirPollutionNotificationBinding = null!;
        private BoolBinding pollutionNoisePollutionNotificationBinding = null!;
        private BoolBinding pollutionGroundPollutionNotificationBinding = null!;

        private BoolBinding resourceConsumerNoResourceNotificationBinding = null!;
        private BoolBinding resourceConsumerNoFuelNotificationBinding = null!;
        private BoolBinding resourceConnectionWarningNotificationBinding = null!;
        private BoolBinding resourceConnectionOilPipeNotConnectedNotificationBinding = null!;
        private BoolBinding resourceConnectionFishingPierNotConnectedNotificationBinding = null!;

        private BoolBinding routePathfindNotificationBinding = null!;
        private BoolBinding routeGateBypassNotificationBinding = null!;

        private BoolBinding transportLineVehicleNotificationBinding = null!;

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

            panelVisibleBinding.Update(false);

            // The mini HUD stays open across loads, so force a rescan instead of letting it sit on the old
            // city's totals until the next tick. Clearing hasLastNotificationCounts stops the diff in
            // OnUpdate from suppressing the push when the two cities' arrays happen to match.
            hasLastNotificationCounts = false;
            notificationCountUpdateState.ForceUpdate();
            miniHudCountUpdateState.ForceUpdate();
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

            alertIconSystem = World.GetOrCreateSystemManaged<AlertIconSystem>();
            InitializeKeybindActions();
            notificationCountUpdateState = UIUpdateState.Create(World, kPanelCountUpdateInterval);
            miniHudCountUpdateState = UIUpdateState.Create(World, kMiniHudCountUpdateInterval);

            panelVisibleBinding = AddBoolBindingAndTriggerBinding("ControlPanelEnabled", false, OnControlPanelBindingToggle);
            AddBoolTriggerBinding("ToggleAllNotifications", ApplyAllNotificationToggles);
            notificationCountsBinding = new ValueBinding<int[]>(
                ModId,
                "NotificationCounts",
                new int[AlertIconSystem.NotificationCountLength],
                new ArrayWriter<int>());
            AddBinding(notificationCountsBinding);
            miniHudFavoritesBinding = new ValueBinding<int[]>(
                ModId,
                "MiniHudFavorites",
                GetMiniHudFavoriteIndexes(),
                new ArrayWriter<int>());
            AddBinding(miniHudFavoritesBinding);
            AddTriggerBinding<int>("ToggleMiniHudFavorite", ToggleMiniHudFavorite);
            AddTriggerBinding<int>("MiniHudNotificationClicked", JumpToMiniHudNotification);
            AddTriggerBinding<string>("MiniHudPositionChanged", SaveMiniHudPosition);
            AddTriggerBinding<string>("PanelPositionChanged", SavePanelPosition);
            AddTriggerBinding<int>("PanelCollapsedSectionsChanged", SavePanelCollapsedSections);
            AddTriggerBinding<int>("PanelSortModeChanged", SavePanelSortMode);
            miniHudEnabledBinding = AddValueBinding(nameof(CwdSettings.MiniHudEnabled), CwdSettings.Instance.MiniHudEnabled);
            miniHudModeBinding = AddValueBinding(nameof(CwdSettings.MiniHudMode), CwdSettings.Instance.MiniHudMode);
            miniHudItemCountBinding = AddValueBinding(nameof(CwdSettings.MiniHudItemCount), CwdSettings.Instance.MiniHudItemCount);
            miniHudScaleBinding = AddValueBinding(nameof(CwdSettings.MiniHudScale), CwdSettings.Instance.MiniHudScale);
            miniHudOrientationBinding = AddValueBinding(nameof(CwdSettings.MiniHudOrientation), CwdSettings.Instance.MiniHudOrientation);
            miniHudPlacementBinding = AddValueBinding(nameof(CwdSettings.MiniHudPlacement), CwdSettings.Instance.MiniHudPlacement);
            miniHudHideZeroBinding = AddValueBinding(nameof(CwdSettings.MiniHudHideZero), CwdSettings.Instance.MiniHudHideZero);
            miniHudPanelStyleBinding = AddValueBinding(nameof(CwdSettings.MiniHudPanelStyle), CwdSettings.Instance.MiniHudPanelStyle);
            miniHudPanelOpacityBinding = AddValueBinding(nameof(CwdSettings.MiniHudPanelOpacity), CwdSettings.Instance.MiniHudPanelOpacity);
            miniHudHorizontalPositionXBinding = AddValueBinding(nameof(CwdSettings.MiniHudHorizontalPositionX), CwdSettings.Instance.MiniHudHorizontalPositionX);
            miniHudHorizontalPositionYBinding = AddValueBinding(nameof(CwdSettings.MiniHudHorizontalPositionY), CwdSettings.Instance.MiniHudHorizontalPositionY);
            miniHudVerticalPositionXBinding = AddValueBinding(nameof(CwdSettings.MiniHudVerticalPositionX), CwdSettings.Instance.MiniHudVerticalPositionX);
            miniHudVerticalPositionYBinding = AddValueBinding(nameof(CwdSettings.MiniHudVerticalPositionY), CwdSettings.Instance.MiniHudVerticalPositionY);
            panelPositionXBinding = AddValueBinding(nameof(CwdSettings.PanelPositionX), CwdSettings.Instance.PanelPositionX);
            panelPositionYBinding = AddValueBinding(nameof(CwdSettings.PanelPositionY), CwdSettings.Instance.PanelPositionY);
            panelCollapsedSectionsMaskBinding = AddValueBinding(nameof(CwdSettings.PanelCollapsedSectionsMask), CwdSettings.Instance.PanelCollapsedSectionsMask);
            panelSortModeBinding = AddValueBinding(nameof(CwdSettings.PanelSortMode), CwdSettings.Instance.PanelSortMode);
            panelButtonsOnlyStartBinding = AddValueBinding(nameof(CwdSettings.PanelButtonsOnlyStart), CwdSettings.Instance.PanelButtonsOnlyStart);
            mainPanelOpacityBinding = AddValueBinding(nameof(CwdSettings.MainPanelOpacity), CwdSettings.Instance.MainPanelOpacity);
            preset1SavedBinding = AddValueBinding(nameof(CwdSettings.Preset1Saved), CwdSettings.Instance.Preset1Saved);
            preset2SavedBinding = AddValueBinding(nameof(CwdSettings.Preset2Saved), CwdSettings.Instance.Preset2Saved);
            activePresetBinding = AddValueBinding(nameof(CwdSettings.ActivePreset), CwdSettings.Instance.ActivePreset);
            AddTriggerBinding<int>("SavePreset", SavePreset);
            AddTriggerBinding<int>("LoadPreset", LoadPreset);
            moneyViewBinding = AddValueBinding(nameof(CwdSettings.MoneyView), CwdSettings.Instance.MoneyView);
            moneyViewModeBinding = AddValueBinding(nameof(CwdSettings.MoneyViewMode), CwdSettings.Instance.MoneyViewMode);
            moneyTooltipModeBinding = AddValueBinding(nameof(CwdSettings.MoneyTooltipMode), CwdSettings.Instance.MoneyTooltipMode);
            moneyTooltipFontScaleBinding = AddValueBinding(nameof(CwdSettings.MoneyTooltipFontScale), CwdSettings.Instance.MoneyTooltipFontScale);
            populationTooltipFontScaleBinding = AddValueBinding(nameof(CwdSettings.PopulationTooltipFontScale), CwdSettings.Instance.PopulationTooltipFontScale);

            electricityElectricityNotificationBinding = AddBoolBindingAndTriggerBinding(nameof(CwdSettings.Instance.Notification.ElectricityElectricityNotification), CwdSettings.Instance.Notification.ElectricityElectricityNotification, OnElectricityElectricityNotificationToggle);
            electricityBottleneckNotificationBinding = AddBoolBindingAndTriggerBinding(nameof(CwdSettings.Instance.Notification.ElectricityBottleneckNotification), CwdSettings.Instance.Notification.ElectricityBottleneckNotification, OnElectricityBottleneckNotificationToggle);
            electricityBuildingBottleneckNotificationBinding = AddBoolBindingAndTriggerBinding(nameof(CwdSettings.Instance.Notification.ElectricityBuildingBottleneckNotification), CwdSettings.Instance.Notification.ElectricityBuildingBottleneckNotification, OnElectricityBuildingBottleneckNotificationToggle);
            electricityNotEnoughProductionNotificationBinding = AddBoolBindingAndTriggerBinding(nameof(CwdSettings.Instance.Notification.ElectricityNotEnoughProductionNotification), CwdSettings.Instance.Notification.ElectricityNotEnoughProductionNotification, OnElectricityNotEnoughProductionNotificationToggle);
            electricityTransformerNotificationBinding = AddBoolBindingAndTriggerBinding(nameof(CwdSettings.Instance.Notification.ElectricityTransformerNotification), CwdSettings.Instance.Notification.ElectricityTransformerNotification, OnElectricityTransformerNotificationToggle);
            electricityNotEnoughConnectedNotificationBinding = AddBoolBindingAndTriggerBinding(nameof(CwdSettings.Instance.Notification.ElectricityNotEnoughConnectedNotification), CwdSettings.Instance.Notification.ElectricityNotEnoughConnectedNotification, OnElectricityNotEnoughConnectedNotificationToggle);
            electricityBatteryEmptyNotificationBinding = AddBoolBindingAndTriggerBinding(nameof(CwdSettings.Instance.Notification.ElectricityBatteryEmptyNotification), CwdSettings.Instance.Notification.ElectricityBatteryEmptyNotification, OnElectricityBatteryEmptyNotificationToggle);
            electricityLowVoltageNotConnectedBinding = AddBoolBindingAndTriggerBinding(nameof(CwdSettings.Instance.Notification.ElectricityLowVoltageNotConnected), CwdSettings.Instance.Notification.ElectricityLowVoltageNotConnected, OnElectricityLowVoltageNotConnectedToggle);
            electricityHighVoltageNotConnectedBinding = AddBoolBindingAndTriggerBinding(nameof(CwdSettings.Instance.Notification.ElectricityHighVoltageNotConnected), CwdSettings.Instance.Notification.ElectricityHighVoltageNotConnected, OnElectricityHighVoltageNotConnectedToggle);

            waterPipeWaterNotificationBinding = AddBoolBindingAndTriggerBinding(nameof(CwdSettings.Instance.Notification.WaterPipeWaterNotification), CwdSettings.Instance.Notification.WaterPipeWaterNotification, OnWaterPipeWaterNotificationToggle);
            waterPipeDirtyWaterNotificationBinding = AddBoolBindingAndTriggerBinding(nameof(CwdSettings.Instance.Notification.WaterPipeDirtyWaterNotification), CwdSettings.Instance.Notification.WaterPipeDirtyWaterNotification, OnWaterPipeDirtyWaterNotificationToggle);
            waterPipeSewageNotificationBinding = AddBoolBindingAndTriggerBinding(nameof(CwdSettings.Instance.Notification.WaterPipeSewageNotification), CwdSettings.Instance.Notification.WaterPipeSewageNotification, OnWaterPipeSewageNotificationToggle);
            waterPipeWaterPipeNotConnectedNotificationBinding = AddBoolBindingAndTriggerBinding(nameof(CwdSettings.Instance.Notification.WaterPipeWaterPipeNotConnectedNotification), CwdSettings.Instance.Notification.WaterPipeWaterPipeNotConnectedNotification, OnWaterPipeWaterPipeNotConnectedNotificationToggle);
            waterPipeSewagePipeNotConnectedNotificationBinding = AddBoolBindingAndTriggerBinding(nameof(CwdSettings.Instance.Notification.WaterPipeSewagePipeNotConnectedNotification), CwdSettings.Instance.Notification.WaterPipeSewagePipeNotConnectedNotification, OnWaterPipeSewagePipeNotConnectedNotificationToggle);
            waterPipeNotEnoughWaterCapacityNotificationBinding = AddBoolBindingAndTriggerBinding(nameof(CwdSettings.Instance.Notification.WaterPipeNotEnoughWaterCapacityNotification), CwdSettings.Instance.Notification.WaterPipeNotEnoughWaterCapacityNotification, OnWaterPipeNotEnoughWaterCapacityNotificationToggle);
            waterPipeNotEnoughSewageCapacityNotificationBinding = AddBoolBindingAndTriggerBinding(nameof(CwdSettings.Instance.Notification.WaterPipeNotEnoughSewageCapacityNotification), CwdSettings.Instance.Notification.WaterPipeNotEnoughSewageCapacityNotification, OnWaterPipeNotEnoughSewageCapacityNotificationToggle);
            waterPipeNotEnoughGroundwaterNotificationBinding = AddBoolBindingAndTriggerBinding(nameof(CwdSettings.Instance.Notification.WaterPipeNotEnoughGroundwaterNotification), CwdSettings.Instance.Notification.WaterPipeNotEnoughGroundwaterNotification, OnWaterPipeNotEnoughGroundwaterNotificationToggle);
            waterPipeNotEnoughSurfaceWaterNotificationBinding = AddBoolBindingAndTriggerBinding(nameof(CwdSettings.Instance.Notification.WaterPipeNotEnoughSurfaceWaterNotification), CwdSettings.Instance.Notification.WaterPipeNotEnoughSurfaceWaterNotification, OnWaterPipeNotEnoughSurfaceWaterNotificationToggle);
            waterPipeDirtyWaterPumpNotificationBinding = AddBoolBindingAndTriggerBinding(nameof(CwdSettings.Instance.Notification.WaterPipeDirtyWaterPumpNotification), CwdSettings.Instance.Notification.WaterPipeDirtyWaterPumpNotification, OnWaterPipeDirtyWaterPumpNotificationToggle);

            buildingAbandonedCollapsedNotificationBinding = AddBoolBindingAndTriggerBinding(nameof(CwdSettings.Instance.Notification.BuildingAbandonedCollapsedNotification), CwdSettings.Instance.Notification.BuildingAbandonedCollapsedNotification, OnBuildingAbandonedCollapsedNotificationToggle);
            buildingAbandonedNotificationBinding = AddBoolBindingAndTriggerBinding(nameof(CwdSettings.Instance.Notification.BuildingAbandonedNotification), CwdSettings.Instance.Notification.BuildingAbandonedNotification, OnBuildingAbandonedNotificationToggle);
            buildingCondemnedNotificationBinding = AddBoolBindingAndTriggerBinding(nameof(CwdSettings.Instance.Notification.BuildingCondemnedNotification), CwdSettings.Instance.Notification.BuildingCondemnedNotification, OnBuildingCondemnedNotificationToggle);
            buildingTurnedOffNotificationBinding = AddBoolBindingAndTriggerBinding(nameof(CwdSettings.Instance.Notification.BuildingTurnedOffNotification), CwdSettings.Instance.Notification.BuildingTurnedOffNotification, OnBuildingTurnedOffNotificationToggle);
            buildingHighRentNotificationBinding = AddBoolBindingAndTriggerBinding(nameof(CwdSettings.Instance.Notification.BuildingHighRentNotification), CwdSettings.Instance.Notification.BuildingHighRentNotification, OnBuildingHighRentNotificationToggle);
            buildingLevelingNotificationBinding = AddBoolBindingAndTriggerBinding(nameof(CwdSettings.Instance.Notification.BuildingLevelingNotification), CwdSettings.Instance.Notification.BuildingLevelingNotification, OnBuildingLevelingNotificationToggle);

            trafficBottleneckNotificationBinding = AddBoolBindingAndTriggerBinding(nameof(CwdSettings.Instance.Notification.TrafficBottleneckNotification), CwdSettings.Instance.Notification.TrafficBottleneckNotification, OnTrafficBottleneckNotificationToggle);
            trafficDeadEndNotificationBinding = AddBoolBindingAndTriggerBinding(nameof(CwdSettings.Instance.Notification.TrafficDeadEndNotification), CwdSettings.Instance.Notification.TrafficDeadEndNotification, OnTrafficDeadEndNotificationToggle);
            trafficRoadConnectionNotificationBinding = AddBoolBindingAndTriggerBinding(nameof(CwdSettings.Instance.Notification.TrafficRoadConnectionNotification), CwdSettings.Instance.Notification.TrafficRoadConnectionNotification, OnTrafficRoadConnectionNotificationToggle);
            trafficTrackConnectionNotificationBinding = AddBoolBindingAndTriggerBinding(nameof(CwdSettings.Instance.Notification.TrafficTrackConnectionNotification), CwdSettings.Instance.Notification.TrafficTrackConnectionNotification, OnTrafficTrackConnectionNotificationToggle);
            trafficCarConnectionNotificationBinding = AddBoolBindingAndTriggerBinding(nameof(CwdSettings.Instance.Notification.TrafficCarConnectionNotification), CwdSettings.Instance.Notification.TrafficCarConnectionNotification, OnTrafficCarConnectionNotificationToggle);
            trafficShipConnectionNotificationBinding = AddBoolBindingAndTriggerBinding(nameof(CwdSettings.Instance.Notification.TrafficShipConnectionNotification), CwdSettings.Instance.Notification.TrafficShipConnectionNotification, OnTrafficShipConnectionNotificationToggle);
            trafficTrainConnectionNotificationBinding = AddBoolBindingAndTriggerBinding(nameof(CwdSettings.Instance.Notification.TrafficTrainConnectionNotification), CwdSettings.Instance.Notification.TrafficTrainConnectionNotification, OnTrafficTrainConnectionNotificationToggle);
            trafficPedestrianConnectionNotificationBinding = AddBoolBindingAndTriggerBinding(nameof(CwdSettings.Instance.Notification.TrafficPedestrianConnectionNotification), CwdSettings.Instance.Notification.TrafficPedestrianConnectionNotification, OnTrafficPedestrianConnectionNotificationToggle);
            trafficBicycleConnectionNotificationBinding = AddBoolBindingAndTriggerBinding(nameof(CwdSettings.Instance.Notification.TrafficBicycleConnectionNotification), CwdSettings.Instance.Notification.TrafficBicycleConnectionNotification, OnTrafficBicycleConnectionNotificationToggle);

            companyNoInputsNotificationBinding = AddBoolBindingAndTriggerBinding(nameof(CwdSettings.Instance.Notification.CompanyNoInputsNotification), CwdSettings.Instance.Notification.CompanyNoInputsNotification, OnCompanyNoInputsNotificationToggle);
            companyNoCustomersNotificationBinding = AddBoolBindingAndTriggerBinding(nameof(CwdSettings.Instance.Notification.CompanyNoCustomersNotification), CwdSettings.Instance.Notification.CompanyNoCustomersNotification, OnCompanyNoCustomersNotificationToggle);

            workProviderUneducatedNotificationBinding = AddBoolBindingAndTriggerBinding(nameof(CwdSettings.Instance.Notification.WorkProviderUneducatedNotification), CwdSettings.Instance.Notification.WorkProviderUneducatedNotification, OnWorkProviderUneducatedNotificationToggle);
            workProviderEducatedNotificationBinding = AddBoolBindingAndTriggerBinding(nameof(CwdSettings.Instance.Notification.WorkProviderEducatedNotification), CwdSettings.Instance.Notification.WorkProviderEducatedNotification, OnWorkProviderEducatedNotificationToggle);

            disasterWeatherDamageNotificationBinding = AddBoolBindingAndTriggerBinding(nameof(CwdSettings.Instance.Notification.DisasterWeatherDamageNotification), CwdSettings.Instance.Notification.DisasterWeatherDamageNotification, OnDisasterWeatherDamageNotificationToggle);
            disasterWeatherDestroyedNotificationBinding = AddBoolBindingAndTriggerBinding(nameof(CwdSettings.Instance.Notification.DisasterWeatherDestroyedNotification), CwdSettings.Instance.Notification.DisasterWeatherDestroyedNotification, OnDisasterWeatherDestroyedNotificationToggle);
            disasterWaterDamageNotificationBinding = AddBoolBindingAndTriggerBinding(nameof(CwdSettings.Instance.Notification.DisasterWaterDamageNotification), CwdSettings.Instance.Notification.DisasterWaterDamageNotification, OnDisasterWaterDamageNotificationToggle);
            disasterWaterDestroyedNotificationBinding = AddBoolBindingAndTriggerBinding(nameof(CwdSettings.Instance.Notification.DisasterWaterDestroyedNotification), CwdSettings.Instance.Notification.DisasterWaterDestroyedNotification, OnDisasterWaterDestroyedNotificationToggle);
            disasterDestroyedNotificationBinding = AddBoolBindingAndTriggerBinding(nameof(CwdSettings.Instance.Notification.DisasterDestroyedNotification), CwdSettings.Instance.Notification.DisasterDestroyedNotification, OnDisasterDestroyedNotificationToggle);

            fireFireNotificationBinding = AddBoolBindingAndTriggerBinding(nameof(CwdSettings.Instance.Notification.FireFireNotification), CwdSettings.Instance.Notification.FireFireNotification, OnFireFireNotificationToggle);
            fireBurnedDownNotificationBinding = AddBoolBindingAndTriggerBinding(nameof(CwdSettings.Instance.Notification.FireBurnedDownNotification), CwdSettings.Instance.Notification.FireBurnedDownNotification, OnFireBurnedDownNotificationToggle);

            garbageGarbageNotificationBinding = AddBoolBindingAndTriggerBinding(nameof(CwdSettings.Instance.Notification.GarbageGarbageNotification), CwdSettings.Instance.Notification.GarbageGarbageNotification, OnGarbageGarbageNotificationToggle);
            garbageFacilityFullNotificationBinding = AddBoolBindingAndTriggerBinding(nameof(CwdSettings.Instance.Notification.GarbageFacilityFullNotification), CwdSettings.Instance.Notification.GarbageFacilityFullNotification, OnGarbageFacilityFullNotificationToggle);

            healthcareAmbulanceNotificationBinding = AddBoolBindingAndTriggerBinding(nameof(CwdSettings.Instance.Notification.HealthcareAmbulanceNotification), CwdSettings.Instance.Notification.HealthcareAmbulanceNotification, OnHealthcareAmbulanceNotificationToggle);
            healthcareHearseNotificationBinding = AddBoolBindingAndTriggerBinding(nameof(CwdSettings.Instance.Notification.HealthcareHearseNotification), CwdSettings.Instance.Notification.HealthcareHearseNotification, OnHealthcareHearseNotificationToggle);
            healthcareFacilityFullNotificationBinding = AddBoolBindingAndTriggerBinding(nameof(CwdSettings.Instance.Notification.HealthcareFacilityFullNotification), CwdSettings.Instance.Notification.HealthcareFacilityFullNotification, OnHealthcareFacilityFullNotificationToggle);

            policeTrafficAccidentNotificationBinding = AddBoolBindingAndTriggerBinding(nameof(CwdSettings.Instance.Notification.PoliceTrafficAccidentNotification), CwdSettings.Instance.Notification.PoliceTrafficAccidentNotification, OnPoliceTrafficAccidentNotificationToggle);
            policeCrimeSceneNotificationBinding = AddBoolBindingAndTriggerBinding(nameof(CwdSettings.Instance.Notification.PoliceCrimeSceneNotification), CwdSettings.Instance.Notification.PoliceCrimeSceneNotification, OnPoliceCrimeSceneNotificationToggle);

            pollutionAirPollutionNotificationBinding = AddBoolBindingAndTriggerBinding(nameof(CwdSettings.Instance.Notification.PollutionAirPollutionNotification), CwdSettings.Instance.Notification.PollutionAirPollutionNotification, OnPollutionAirPollutionNotificationToggle);
            pollutionNoisePollutionNotificationBinding = AddBoolBindingAndTriggerBinding(nameof(CwdSettings.Instance.Notification.PollutionNoisePollutionNotification), CwdSettings.Instance.Notification.PollutionNoisePollutionNotification, OnPollutionNoisePollutionNotificationToggle);
            pollutionGroundPollutionNotificationBinding = AddBoolBindingAndTriggerBinding(nameof(CwdSettings.Instance.Notification.PollutionGroundPollutionNotification), CwdSettings.Instance.Notification.PollutionGroundPollutionNotification, OnPollutionGroundPollutionNotificationToggle);

            resourceConsumerNoResourceNotificationBinding = AddBoolBindingAndTriggerBinding(nameof(CwdSettings.Instance.Notification.ResourceConsumerNoResourceNotification), CwdSettings.Instance.Notification.ResourceConsumerNoResourceNotification, OnResourceConsumerNoResourceNotificationToggle);
            resourceConsumerNoFuelNotificationBinding = AddBoolBindingAndTriggerBinding(nameof(CwdSettings.Instance.Notification.ResourceConsumerNoFuelNotification), CwdSettings.Instance.Notification.ResourceConsumerNoFuelNotification, OnResourceConsumerNoFuelNotificationToggle);
            resourceConnectionWarningNotificationBinding = AddBoolBindingAndTriggerBinding(nameof(CwdSettings.Instance.Notification.ResourceConnectionWarningNotification), CwdSettings.Instance.Notification.ResourceConnectionWarningNotification, OnResourceConnectionWarningNotificationToggle);
            resourceConnectionOilPipeNotConnectedNotificationBinding = AddBoolBindingAndTriggerBinding(nameof(CwdSettings.Instance.Notification.ResourceConnectionOilPipeNotConnectedNotification), CwdSettings.Instance.Notification.ResourceConnectionOilPipeNotConnectedNotification, OnResourceConnectionOilPipeNotConnectedNotificationToggle);
            resourceConnectionFishingPierNotConnectedNotificationBinding = AddBoolBindingAndTriggerBinding(nameof(CwdSettings.Instance.Notification.ResourceConnectionFishingPierNotConnectedNotification), CwdSettings.Instance.Notification.ResourceConnectionFishingPierNotConnectedNotification, OnResourceConnectionFishingPierNotConnectedNotificationToggle);

            routePathfindNotificationBinding = AddBoolBindingAndTriggerBinding(nameof(CwdSettings.Instance.Notification.RoutePathfindNotification), CwdSettings.Instance.Notification.RoutePathfindNotification, OnRoutePathfindNotificationToggle);
            routeGateBypassNotificationBinding = AddBoolBindingAndTriggerBinding(nameof(CwdSettings.Instance.Notification.RouteGateBypassNotification), CwdSettings.Instance.Notification.RouteGateBypassNotification, OnRouteGateBypassNotificationToggle);

            transportLineVehicleNotificationBinding = AddBoolBindingAndTriggerBinding(nameof(CwdSettings.Instance.Notification.TransportLineVehicleNotification), CwdSettings.Instance.Notification.TransportLineVehicleNotification, OnTransportLineVehicleNotificationToggle);
        }



        #region OnElectricityNotificationToggle
        private void OnElectricityElectricityNotificationToggle(bool value) {
            electricityElectricityNotificationBinding.Update(value);
            CwdSettings.Instance.Notification.ElectricityElectricityNotification = value;
            alertIconSystem.EnableElectricityNotification(ElectricityNotificationIcon.ElectricityNotification, value, true);
        }
        private void OnElectricityBottleneckNotificationToggle(bool value) {
            electricityBottleneckNotificationBinding.Update(value);
            CwdSettings.Instance.Notification.ElectricityBottleneckNotification = value;
            alertIconSystem.EnableElectricityNotification(ElectricityNotificationIcon.BottleneckNotification, value, true);
        }
        private void OnElectricityBuildingBottleneckNotificationToggle(bool value) {
            electricityBuildingBottleneckNotificationBinding.Update(value);
            CwdSettings.Instance.Notification.ElectricityBuildingBottleneckNotification = value;
            alertIconSystem.EnableElectricityNotification(ElectricityNotificationIcon.BuildingBottleneckNotification, value, true);
        }
        private void OnElectricityNotEnoughProductionNotificationToggle(bool value) {
            electricityNotEnoughProductionNotificationBinding.Update(value);
            CwdSettings.Instance.Notification.ElectricityNotEnoughProductionNotification = value;
            alertIconSystem.EnableElectricityNotification(ElectricityNotificationIcon.NotEnoughProductionNotification, value, true);
        }
        private void OnElectricityTransformerNotificationToggle(bool value) {
            electricityTransformerNotificationBinding.Update(value);
            CwdSettings.Instance.Notification.ElectricityTransformerNotification = value;
            alertIconSystem.EnableElectricityNotification(ElectricityNotificationIcon.TransformerNotification, value, true);
        }
        private void OnElectricityNotEnoughConnectedNotificationToggle(bool value) {
            electricityNotEnoughConnectedNotificationBinding.Update(value);
            CwdSettings.Instance.Notification.ElectricityNotEnoughConnectedNotification = value;
            alertIconSystem.EnableElectricityNotification(ElectricityNotificationIcon.NotEnoughConnectedNotification, value, true);
        }
        private void OnElectricityBatteryEmptyNotificationToggle(bool value) {
            electricityBatteryEmptyNotificationBinding.Update(value);
            CwdSettings.Instance.Notification.ElectricityBatteryEmptyNotification = value;
            alertIconSystem.EnableElectricityNotification(ElectricityNotificationIcon.BatteryEmptyNotification, value, true);
        }
        private void OnElectricityLowVoltageNotConnectedToggle(bool value) {
            electricityLowVoltageNotConnectedBinding.Update(value);
            CwdSettings.Instance.Notification.ElectricityLowVoltageNotConnected = value;
            alertIconSystem.EnableElectricityNotification(ElectricityNotificationIcon.LowVoltageNotConnected, value, true);
        }
        private void OnElectricityHighVoltageNotConnectedToggle(bool value) {
            electricityHighVoltageNotConnectedBinding.Update(value);
            CwdSettings.Instance.Notification.ElectricityHighVoltageNotConnected = value;
            alertIconSystem.EnableElectricityNotification(ElectricityNotificationIcon.HighVoltageNotConnected, value, true);
        }

        #endregion

        #region OnWaterPipeNotificationToggle
        private void OnWaterPipeWaterNotificationToggle(bool value) {
            waterPipeWaterNotificationBinding.Update(value);
            CwdSettings.Instance.Notification.WaterPipeWaterNotification = value;
            alertIconSystem.EnableWaterPipeNotification(WaterPipeNotificationIcon.WaterNotification, value, true);
        }
        private void OnWaterPipeDirtyWaterNotificationToggle(bool value) {
            waterPipeDirtyWaterNotificationBinding.Update(value);
            CwdSettings.Instance.Notification.WaterPipeDirtyWaterNotification = value;
            alertIconSystem.EnableWaterPipeNotification(WaterPipeNotificationIcon.DirtyWaterNotification, value, true);
        }
        private void OnWaterPipeSewageNotificationToggle(bool value) {
            waterPipeSewageNotificationBinding.Update(value);
            CwdSettings.Instance.Notification.WaterPipeSewageNotification = value;
            alertIconSystem.EnableWaterPipeNotification(WaterPipeNotificationIcon.SewageNotification, value, true);
        }
        private void OnWaterPipeWaterPipeNotConnectedNotificationToggle(bool value) {
            waterPipeWaterPipeNotConnectedNotificationBinding.Update(value);
            CwdSettings.Instance.Notification.WaterPipeWaterPipeNotConnectedNotification = value;
            alertIconSystem.EnableWaterPipeNotification(WaterPipeNotificationIcon.WaterPipeNotConnectedNotification, value, true);
        }
        private void OnWaterPipeSewagePipeNotConnectedNotificationToggle(bool value) {
            waterPipeSewagePipeNotConnectedNotificationBinding.Update(value);
            CwdSettings.Instance.Notification.WaterPipeSewagePipeNotConnectedNotification = value;
            alertIconSystem.EnableWaterPipeNotification(WaterPipeNotificationIcon.SewagePipeNotConnectedNotification, value, true);
        }
        private void OnWaterPipeNotEnoughWaterCapacityNotificationToggle(bool value) {
            waterPipeNotEnoughWaterCapacityNotificationBinding.Update(value);
            CwdSettings.Instance.Notification.WaterPipeNotEnoughWaterCapacityNotification = value;
            alertIconSystem.EnableWaterPipeNotification(WaterPipeNotificationIcon.NotEnoughWaterCapacityNotification, value, true);
        }
        private void OnWaterPipeNotEnoughSewageCapacityNotificationToggle(bool value) {
            waterPipeNotEnoughSewageCapacityNotificationBinding.Update(value);
            CwdSettings.Instance.Notification.WaterPipeNotEnoughSewageCapacityNotification = value;
            alertIconSystem.EnableWaterPipeNotification(WaterPipeNotificationIcon.NotEnoughSewageCapacityNotification, value, true);
        }
        private void OnWaterPipeNotEnoughGroundwaterNotificationToggle(bool value) {
            waterPipeNotEnoughGroundwaterNotificationBinding.Update(value);
            CwdSettings.Instance.Notification.WaterPipeNotEnoughGroundwaterNotification = value;
            alertIconSystem.EnableWaterPipeNotification(WaterPipeNotificationIcon.NotEnoughGroundwaterNotification, value, true);
        }
        private void OnWaterPipeNotEnoughSurfaceWaterNotificationToggle(bool value) {
            waterPipeNotEnoughSurfaceWaterNotificationBinding.Update(value);
            CwdSettings.Instance.Notification.WaterPipeNotEnoughSurfaceWaterNotification = value;
            alertIconSystem.EnableWaterPipeNotification(WaterPipeNotificationIcon.NotEnoughSurfaceWaterNotification, value, true);
        }
        private void OnWaterPipeDirtyWaterPumpNotificationToggle(bool value) {
            waterPipeDirtyWaterPumpNotificationBinding.Update(value);
            CwdSettings.Instance.Notification.WaterPipeDirtyWaterPumpNotification = value;
            alertIconSystem.EnableWaterPipeNotification(WaterPipeNotificationIcon.DirtyWaterPumpNotification, value, true);
        }
        #endregion

        #region OnBuildingNotificationToggle
        private void OnBuildingAbandonedCollapsedNotificationToggle(bool value) {
            buildingAbandonedCollapsedNotificationBinding.Update(value);
            CwdSettings.Instance.Notification.BuildingAbandonedCollapsedNotification = value;
            alertIconSystem.EnableBuildingNotification(BuildingNotificationIcon.AbandonedCollapsedNotification, value, true);
        }
        private void OnBuildingAbandonedNotificationToggle(bool value) {
            buildingAbandonedNotificationBinding.Update(value);
            CwdSettings.Instance.Notification.BuildingAbandonedNotification = value;
            alertIconSystem.EnableBuildingNotification(BuildingNotificationIcon.AbandonedNotification, value, true);
        }
        private void OnBuildingCondemnedNotificationToggle(bool value) {
            buildingCondemnedNotificationBinding.Update(value);
            CwdSettings.Instance.Notification.BuildingCondemnedNotification = value;
            alertIconSystem.EnableBuildingNotification(BuildingNotificationIcon.CondemnedNotification, value, true);
        }
        private void OnBuildingTurnedOffNotificationToggle(bool value) {
            buildingTurnedOffNotificationBinding.Update(value);
            CwdSettings.Instance.Notification.BuildingTurnedOffNotification = value;
            alertIconSystem.EnableBuildingNotification(BuildingNotificationIcon.TurnedOffNotification, value, true);
        }
        private void OnBuildingHighRentNotificationToggle(bool value) {
            buildingHighRentNotificationBinding.Update(value);
            CwdSettings.Instance.Notification.BuildingHighRentNotification = value;
            alertIconSystem.EnableBuildingNotification(BuildingNotificationIcon.HighRentNotification, value, true);
        }
        private void OnBuildingLevelingNotificationToggle(bool value) {
            buildingLevelingNotificationBinding.Update(value);
            CwdSettings.Instance.Notification.BuildingLevelingNotification = value;
            alertIconSystem.EnableBuildingNotification(BuildingNotificationIcon.LevelingNotification, value, true);
        }
        #endregion

        #region OnTrafficNotificationToggle
        private void OnTrafficBottleneckNotificationToggle(bool value) {
            trafficBottleneckNotificationBinding.Update(value);
            CwdSettings.Instance.Notification.TrafficBottleneckNotification = value;
            alertIconSystem.EnableTrafficNotification(TrafficNotificationIcon.BottleneckNotification, value, true);
        }
        private void OnTrafficDeadEndNotificationToggle(bool value) {
            trafficDeadEndNotificationBinding.Update(value);
            CwdSettings.Instance.Notification.TrafficDeadEndNotification = value;
            alertIconSystem.EnableTrafficNotification(TrafficNotificationIcon.DeadEndNotification, value, true);
        }
        private void OnTrafficRoadConnectionNotificationToggle(bool value) {
            trafficRoadConnectionNotificationBinding.Update(value);
            CwdSettings.Instance.Notification.TrafficRoadConnectionNotification = value;
            alertIconSystem.EnableTrafficNotification(TrafficNotificationIcon.RoadConnectionNotification, value, true);
        }
        private void OnTrafficTrackConnectionNotificationToggle(bool value) {
            trafficTrackConnectionNotificationBinding.Update(value);
            CwdSettings.Instance.Notification.TrafficTrackConnectionNotification = value;
            alertIconSystem.EnableTrafficNotification(TrafficNotificationIcon.TrackConnectionNotification, value, true);
        }
        private void OnTrafficCarConnectionNotificationToggle(bool value) {
            trafficCarConnectionNotificationBinding.Update(value);
            CwdSettings.Instance.Notification.TrafficCarConnectionNotification = value;
            alertIconSystem.EnableTrafficNotification(TrafficNotificationIcon.CarConnectionNotification, value, true);
        }
        private void OnTrafficShipConnectionNotificationToggle(bool value) {
            trafficShipConnectionNotificationBinding.Update(value);
            CwdSettings.Instance.Notification.TrafficShipConnectionNotification = value;
            alertIconSystem.EnableTrafficNotification(TrafficNotificationIcon.ShipConnectionNotification, value, true);
        }
        private void OnTrafficTrainConnectionNotificationToggle(bool value) {
            trafficTrainConnectionNotificationBinding.Update(value);
            CwdSettings.Instance.Notification.TrafficTrainConnectionNotification = value;
            alertIconSystem.EnableTrafficNotification(TrafficNotificationIcon.TrainConnectionNotification, value, true);
        }
        private void OnTrafficPedestrianConnectionNotificationToggle(bool value) {
            trafficPedestrianConnectionNotificationBinding.Update(value);
            CwdSettings.Instance.Notification.TrafficPedestrianConnectionNotification = value;
            alertIconSystem.EnableTrafficNotification(TrafficNotificationIcon.PedestrianConnectionNotification, value, true);
        }
        private void OnTrafficBicycleConnectionNotificationToggle(bool value) {
            trafficBicycleConnectionNotificationBinding.Update(value);
            CwdSettings.Instance.Notification.TrafficBicycleConnectionNotification = value;
            alertIconSystem.EnableTrafficNotification(TrafficNotificationIcon.BicycleConnectionNotification, value, true);
        }
        #endregion

        #region OnCompanyNotificationToggle
        private void OnCompanyNoInputsNotificationToggle(bool value) {
            companyNoInputsNotificationBinding.Update(value);
            CwdSettings.Instance.Notification.CompanyNoInputsNotification = value;
            alertIconSystem.EnableCompanyNotification(CompanyNotificationIcon.NoInputsNotification, value, true);
        }
        private void OnCompanyNoCustomersNotificationToggle(bool value) {
            companyNoCustomersNotificationBinding.Update(value);
            CwdSettings.Instance.Notification.CompanyNoCustomersNotification = value;
            alertIconSystem.EnableCompanyNotification(CompanyNotificationIcon.NoCustomersNotification, value, true);
        }
        #endregion

        #region OnWorkProviderNotificationToggle
        private void OnWorkProviderUneducatedNotificationToggle(bool value) {
            workProviderUneducatedNotificationBinding.Update(value);
            CwdSettings.Instance.Notification.WorkProviderUneducatedNotification = value;
            alertIconSystem.EnableWorkProviderNotification(WorkProviderNotificationIcon.UneducatedNotification, value, true);
        }
        private void OnWorkProviderEducatedNotificationToggle(bool value) {
            workProviderEducatedNotificationBinding.Update(value);
            CwdSettings.Instance.Notification.WorkProviderEducatedNotification = value;
            alertIconSystem.EnableWorkProviderNotification(WorkProviderNotificationIcon.EducatedNotification, value, true);
        }
        #endregion

        #region OnDisasterNotificationToggle
        private void OnDisasterWeatherDamageNotificationToggle(bool value) {
            disasterWeatherDamageNotificationBinding.Update(value);
            CwdSettings.Instance.Notification.DisasterWeatherDamageNotification = value;
            alertIconSystem.EnableDisasterNotification(DisasterNotificationIcon.WeatherDamageNotification, value, true);
        }
        private void OnDisasterWeatherDestroyedNotificationToggle(bool value) {
            disasterWeatherDestroyedNotificationBinding.Update(value);
            CwdSettings.Instance.Notification.DisasterWeatherDestroyedNotification = value;
            alertIconSystem.EnableDisasterNotification(DisasterNotificationIcon.WeatherDestroyedNotification, value, true);
        }
        private void OnDisasterWaterDamageNotificationToggle(bool value) {
            disasterWaterDamageNotificationBinding.Update(value);
            CwdSettings.Instance.Notification.DisasterWaterDamageNotification = value;
            alertIconSystem.EnableDisasterNotification(DisasterNotificationIcon.WaterDamageNotification, value, true);
        }
        private void OnDisasterWaterDestroyedNotificationToggle(bool value) {
            disasterWaterDestroyedNotificationBinding.Update(value);
            CwdSettings.Instance.Notification.DisasterWaterDestroyedNotification = value;
            alertIconSystem.EnableDisasterNotification(DisasterNotificationIcon.WaterDestroyedNotification, value, true);
        }
        private void OnDisasterDestroyedNotificationToggle(bool value) {
            disasterDestroyedNotificationBinding.Update(value);
            CwdSettings.Instance.Notification.DisasterDestroyedNotification = value;
            alertIconSystem.EnableDisasterNotification(DisasterNotificationIcon.DestroyedNotification, value, true);
        }
        #endregion

        #region OnFireNotificationToggle
        private void OnFireFireNotificationToggle(bool value) {
            fireFireNotificationBinding.Update(value);
            CwdSettings.Instance.Notification.FireFireNotification = value;
            alertIconSystem.EnableFireNotification(FireNotificationIcon.FireNotification, value, true);
        }
        private void OnFireBurnedDownNotificationToggle(bool value) {
            fireBurnedDownNotificationBinding.Update(value);
            CwdSettings.Instance.Notification.FireBurnedDownNotification = value;
            alertIconSystem.EnableFireNotification(FireNotificationIcon.BurnedDownNotification, value, true);
        }
        #endregion

        #region OnGarbageNotificationToggle
        private void OnGarbageGarbageNotificationToggle(bool value) {
            garbageGarbageNotificationBinding.Update(value);
            CwdSettings.Instance.Notification.GarbageGarbageNotification = value;
            alertIconSystem.EnableGarbageNotification(GarbageNotificationIcon.GarbageNotification, value, true);
        }
        private void OnGarbageFacilityFullNotificationToggle(bool value) {
            garbageFacilityFullNotificationBinding.Update(value);
            CwdSettings.Instance.Notification.GarbageFacilityFullNotification = value;
            alertIconSystem.EnableGarbageNotification(GarbageNotificationIcon.FacilityFullNotification, value, true);
        }
        #endregion

        #region OnHealthcareNotificationToggle
        private void OnHealthcareAmbulanceNotificationToggle(bool value) {
            healthcareAmbulanceNotificationBinding.Update(value);
            CwdSettings.Instance.Notification.HealthcareAmbulanceNotification = value;
            alertIconSystem.EnableHealthcareNotification(HealthcareNotificationIcon.AmbulanceNotification, value, true);
        }
        private void OnHealthcareHearseNotificationToggle(bool value) {
            healthcareHearseNotificationBinding.Update(value);
            CwdSettings.Instance.Notification.HealthcareHearseNotification = value;
            alertIconSystem.EnableHealthcareNotification(HealthcareNotificationIcon.HearseNotification, value, true);
        }
        private void OnHealthcareFacilityFullNotificationToggle(bool value) {
            healthcareFacilityFullNotificationBinding.Update(value);
            CwdSettings.Instance.Notification.HealthcareFacilityFullNotification = value;
            alertIconSystem.EnableHealthcareNotification(HealthcareNotificationIcon.FacilityFullNotification, value, true);
        }
        #endregion

        #region OnPoliceNotificationToggle
        private void OnPoliceTrafficAccidentNotificationToggle(bool value) {
            policeTrafficAccidentNotificationBinding.Update(value);
            CwdSettings.Instance.Notification.PoliceTrafficAccidentNotification = value;
            alertIconSystem.EnablePoliceNotification(PoliceNotificationIcon.TrafficAccidentNotification, value, true);
        }
        private void OnPoliceCrimeSceneNotificationToggle(bool value) {
            policeCrimeSceneNotificationBinding.Update(value);
            CwdSettings.Instance.Notification.PoliceCrimeSceneNotification = value;
            alertIconSystem.EnablePoliceNotification(PoliceNotificationIcon.CrimeSceneNotification, value, true);
        }
        #endregion

        #region OnPollutionNotificationToggle
        private void OnPollutionAirPollutionNotificationToggle(bool value) {
            pollutionAirPollutionNotificationBinding.Update(value);
            CwdSettings.Instance.Notification.PollutionAirPollutionNotification = value;
            alertIconSystem.EnablePollutionNotification(PollutionNotificationIcon.AirPollutionNotification, value, true);
        }
        private void OnPollutionNoisePollutionNotificationToggle(bool value) {
            pollutionNoisePollutionNotificationBinding.Update(value);
            CwdSettings.Instance.Notification.PollutionNoisePollutionNotification = value;
            alertIconSystem.EnablePollutionNotification(PollutionNotificationIcon.NoisePollutionNotification, value, true);
        }
        private void OnPollutionGroundPollutionNotificationToggle(bool value) {
            pollutionGroundPollutionNotificationBinding.Update(value);
            CwdSettings.Instance.Notification.PollutionGroundPollutionNotification = value;
            alertIconSystem.EnablePollutionNotification(PollutionNotificationIcon.GroundPollutionNotification, value, true);
        }
        #endregion

        #region OnResourceConsumerNotificationToggle
        private void OnResourceConsumerNoResourceNotificationToggle(bool value) {
            resourceConsumerNoResourceNotificationBinding.Update(value);
            CwdSettings.Instance.Notification.ResourceConsumerNoResourceNotification = value;
            alertIconSystem.EnableResourceConsumerNotification(ResourceConsumerNotificationIcon.NoResourceNotification, value, true);
        }

        private void OnResourceConsumerNoFuelNotificationToggle(bool value) {
            resourceConsumerNoFuelNotificationBinding.Update(value);
            CwdSettings.Instance.Notification.ResourceConsumerNoFuelNotification = value;
            alertIconSystem.EnableResourceConsumerNotification(ResourceConsumerNotificationIcon.NoFuelNotification, value, true);
        }
        #endregion

        #region OnResourceConnectionNotificationToggle
        private void OnResourceConnectionWarningNotificationToggle(bool value) {
            resourceConnectionWarningNotificationBinding.Update(value);
            CwdSettings.Instance.Notification.ResourceConnectionWarningNotification = value;
            alertIconSystem.EnableResourceConnectionNotification(ResourceConnectionNotificationIcon.ConnectionWarningNotification, value, true);
        }

        private void OnResourceConnectionOilPipeNotConnectedNotificationToggle(bool value) {
            resourceConnectionOilPipeNotConnectedNotificationBinding.Update(value);
            CwdSettings.Instance.Notification.ResourceConnectionOilPipeNotConnectedNotification = value;
            alertIconSystem.EnableResourceConnectionNotification(ResourceConnectionNotificationIcon.OilPipeNotConnectedNotification, value, true);
        }

        private void OnResourceConnectionFishingPierNotConnectedNotificationToggle(bool value) {
            resourceConnectionFishingPierNotConnectedNotificationBinding.Update(value);
            CwdSettings.Instance.Notification.ResourceConnectionFishingPierNotConnectedNotification = value;
            alertIconSystem.EnableResourceConnectionNotification(ResourceConnectionNotificationIcon.FishingPierNotConnectedNotification, value, true);
        }
        #endregion

        #region OnRouteNotificationToggle
        private void OnRoutePathfindNotificationToggle(bool value) {
            routePathfindNotificationBinding.Update(value);
            CwdSettings.Instance.Notification.RoutePathfindNotification = value;
            alertIconSystem.EnableRouteNotification(RouteNotificationIcon.PathfindNotification, value, true);
        }

        private void OnRouteGateBypassNotificationToggle(bool value) {
            routeGateBypassNotificationBinding.Update(value);
            CwdSettings.Instance.Notification.RouteGateBypassNotification = value;
            alertIconSystem.EnableRouteNotification(RouteNotificationIcon.GateBypassNotification, value, true);
        }
        #endregion

        #region OnTransportLineNotificationToggle
        private void OnTransportLineVehicleNotificationToggle(bool value) {
            transportLineVehicleNotificationBinding.Update(value);
            CwdSettings.Instance.Notification.TransportLineVehicleNotification = value;
            alertIconSystem.EnableTransportLineNotification(TransportLineNotificationIcon.VehicleNotification, value, true);
        }
        #endregion

        protected override void OnUpdate()
        {
            RefreshKeybindActions();

            if (!IsInGame())
            {
                return;
            }

            if (toggleNotificationPanelAction?.WasReleasedThisFrame() == true)
            {
                ToggleControlPanelFromHotkey();
                return;
            }

            if (toggleNotificationsAction?.WasReleasedThisFrame() == true)
            {
                ToggleAllNotificationsFromHotkey();
            }

            bool shouldUpdateCounts =
                panelVisibleBinding.Value
                    ? notificationCountUpdateState.Advance()
                    : miniHudEnabledBinding.value && miniHudCountUpdateState.Advance();

            if (shouldUpdateCounts)
            {
                int[] nextCounts = alertIconSystem.GetNotificationCounts();

                if (!hasLastNotificationCounts || !AreSameNotificationCounts(lastNotificationCounts, nextCounts))
                {
                    Array.Copy(nextCounts, lastNotificationCounts, nextCounts.Length);
                    hasLastNotificationCounts = true;
                    notificationCountsBinding.Update(nextCounts);
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
            toggleNotificationsAction = EnableAction(CwdSettings.ToggleNotificationsAction);
            toggleNotificationPanelAction = EnableAction(CwdSettings.ToggleNotificationPanelAction);
        }

        private void RefreshKeybindActions()
        {
            if (toggleNotificationsAction == null)
            {
                toggleNotificationsAction = EnableAction(CwdSettings.ToggleNotificationsAction);
            }

            if (toggleNotificationPanelAction == null)
            {
                toggleNotificationPanelAction = EnableAction(CwdSettings.ToggleNotificationPanelAction);
            }
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
            alertIconSystem.SetAllNotifications(enabled);
            UpdateAllNotificationBindings(enabled);

            // Show/Hide Icons no longer matches either saved slot, so drop the "selected" ring.
            SetActivePreset(0);
        }

        private void UpdateAllNotificationBindings(bool enabled)
        {
            // Keep this list aligned with CwdSettings.NotificationSetting and the BoolBinding fields above.
            electricityElectricityNotificationBinding.Update(enabled);
            electricityBottleneckNotificationBinding.Update(enabled);
            electricityBuildingBottleneckNotificationBinding.Update(enabled);
            electricityNotEnoughProductionNotificationBinding.Update(enabled);
            electricityTransformerNotificationBinding.Update(enabled);
            electricityNotEnoughConnectedNotificationBinding.Update(enabled);
            electricityBatteryEmptyNotificationBinding.Update(enabled);
            electricityLowVoltageNotConnectedBinding.Update(enabled);
            electricityHighVoltageNotConnectedBinding.Update(enabled);

            waterPipeWaterNotificationBinding.Update(enabled);
            waterPipeDirtyWaterNotificationBinding.Update(enabled);
            waterPipeSewageNotificationBinding.Update(enabled);
            waterPipeWaterPipeNotConnectedNotificationBinding.Update(enabled);
            waterPipeSewagePipeNotConnectedNotificationBinding.Update(enabled);
            waterPipeNotEnoughWaterCapacityNotificationBinding.Update(enabled);
            waterPipeNotEnoughSewageCapacityNotificationBinding.Update(enabled);
            waterPipeNotEnoughGroundwaterNotificationBinding.Update(enabled);
            waterPipeNotEnoughSurfaceWaterNotificationBinding.Update(enabled);
            waterPipeDirtyWaterPumpNotificationBinding.Update(enabled);

            buildingAbandonedCollapsedNotificationBinding.Update(enabled);
            buildingAbandonedNotificationBinding.Update(enabled);
            buildingCondemnedNotificationBinding.Update(enabled);
            buildingTurnedOffNotificationBinding.Update(enabled);
            buildingHighRentNotificationBinding.Update(enabled);
            // Deliberately NOT updated here: Leveling is an optional/positive row that Toggle All
            // and the N hotkey leave alone (its real setting is never touched by SetAllNotificationSettings
            // either) — only its own manual checkbox should change it.

            trafficBottleneckNotificationBinding.Update(enabled);
            trafficDeadEndNotificationBinding.Update(enabled);
            trafficRoadConnectionNotificationBinding.Update(enabled);
            trafficTrackConnectionNotificationBinding.Update(enabled);
            trafficCarConnectionNotificationBinding.Update(enabled);
            trafficShipConnectionNotificationBinding.Update(enabled);
            trafficTrainConnectionNotificationBinding.Update(enabled);
            trafficPedestrianConnectionNotificationBinding.Update(enabled);
            trafficBicycleConnectionNotificationBinding.Update(enabled);

            companyNoInputsNotificationBinding.Update(enabled);
            companyNoCustomersNotificationBinding.Update(enabled);

            workProviderUneducatedNotificationBinding.Update(enabled);
            workProviderEducatedNotificationBinding.Update(enabled);

            disasterWeatherDamageNotificationBinding.Update(enabled);
            disasterWeatherDestroyedNotificationBinding.Update(enabled);
            disasterWaterDamageNotificationBinding.Update(enabled);
            disasterWaterDestroyedNotificationBinding.Update(enabled);
            disasterDestroyedNotificationBinding.Update(enabled);

            fireFireNotificationBinding.Update(enabled);
            fireBurnedDownNotificationBinding.Update(enabled);

            garbageGarbageNotificationBinding.Update(enabled);
            garbageFacilityFullNotificationBinding.Update(enabled);

            healthcareAmbulanceNotificationBinding.Update(enabled);
            healthcareHearseNotificationBinding.Update(enabled);
            healthcareFacilityFullNotificationBinding.Update(enabled);

            policeTrafficAccidentNotificationBinding.Update(enabled);
            policeCrimeSceneNotificationBinding.Update(enabled);

            pollutionAirPollutionNotificationBinding.Update(enabled);
            pollutionNoisePollutionNotificationBinding.Update(enabled);
            pollutionGroundPollutionNotificationBinding.Update(enabled);

            resourceConsumerNoResourceNotificationBinding.Update(enabled);
            resourceConsumerNoFuelNotificationBinding.Update(enabled);
            resourceConnectionWarningNotificationBinding.Update(enabled);
            resourceConnectionOilPipeNotConnectedNotificationBinding.Update(enabled);
            resourceConnectionFishingPierNotConnectedNotificationBinding.Update(enabled);
            routePathfindNotificationBinding.Update(enabled);
            routeGateBypassNotificationBinding.Update(enabled);
            transportLineVehicleNotificationBinding.Update(enabled);
        }

        // Save the current checkboxes into a preset slot ("hold" gesture on the panel's 1 | 2 button).
        private void SavePreset(int slot)
        {
            CwdSettings.NotificationSetting live = CwdSettings.Instance.Notification;

            if (slot == 1)
            {
                CwdSettings.Instance.Preset1.CopyFrom(live);
                CwdSettings.Instance.Preset1Saved = true;
                preset1SavedBinding.Update(true);
            }
            else if (slot == 2)
            {
                CwdSettings.Instance.Preset2.CopyFrom(live);
                CwdSettings.Instance.Preset2Saved = true;
                preset2SavedBinding.Update(true);
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
            alertIconSystem.ApplyNotificationSettings();
            PushNotificationBindingsFromSettings();
            SetActivePreset(slot);
            TrySavePresetSettings("preset-load");
        }

        private void SetActivePreset(int slot)
        {
            CwdSettings.Instance.ActivePreset = slot;
            activePresetBinding.Update(slot);
        }

        // Mirrors UpdateAllNotificationBindings but pushes each notification's OWN saved value (used
        // after a preset load, where slots differ per notification). Includes BuildingLeveling, which
        // the bulk Toggle All path deliberately skips.
        private void PushNotificationBindingsFromSettings()
        {
            CwdSettings.NotificationSetting n = CwdSettings.Instance.Notification;

            electricityElectricityNotificationBinding.Update(n.ElectricityElectricityNotification);
            electricityBottleneckNotificationBinding.Update(n.ElectricityBottleneckNotification);
            electricityBuildingBottleneckNotificationBinding.Update(n.ElectricityBuildingBottleneckNotification);
            electricityNotEnoughProductionNotificationBinding.Update(n.ElectricityNotEnoughProductionNotification);
            electricityTransformerNotificationBinding.Update(n.ElectricityTransformerNotification);
            electricityNotEnoughConnectedNotificationBinding.Update(n.ElectricityNotEnoughConnectedNotification);
            electricityBatteryEmptyNotificationBinding.Update(n.ElectricityBatteryEmptyNotification);
            electricityLowVoltageNotConnectedBinding.Update(n.ElectricityLowVoltageNotConnected);
            electricityHighVoltageNotConnectedBinding.Update(n.ElectricityHighVoltageNotConnected);

            waterPipeWaterNotificationBinding.Update(n.WaterPipeWaterNotification);
            waterPipeDirtyWaterNotificationBinding.Update(n.WaterPipeDirtyWaterNotification);
            waterPipeSewageNotificationBinding.Update(n.WaterPipeSewageNotification);
            waterPipeWaterPipeNotConnectedNotificationBinding.Update(n.WaterPipeWaterPipeNotConnectedNotification);
            waterPipeSewagePipeNotConnectedNotificationBinding.Update(n.WaterPipeSewagePipeNotConnectedNotification);
            waterPipeNotEnoughWaterCapacityNotificationBinding.Update(n.WaterPipeNotEnoughWaterCapacityNotification);
            waterPipeNotEnoughSewageCapacityNotificationBinding.Update(n.WaterPipeNotEnoughSewageCapacityNotification);
            waterPipeNotEnoughGroundwaterNotificationBinding.Update(n.WaterPipeNotEnoughGroundwaterNotification);
            waterPipeNotEnoughSurfaceWaterNotificationBinding.Update(n.WaterPipeNotEnoughSurfaceWaterNotification);
            waterPipeDirtyWaterPumpNotificationBinding.Update(n.WaterPipeDirtyWaterPumpNotification);

            buildingAbandonedCollapsedNotificationBinding.Update(n.BuildingAbandonedCollapsedNotification);
            buildingAbandonedNotificationBinding.Update(n.BuildingAbandonedNotification);
            buildingCondemnedNotificationBinding.Update(n.BuildingCondemnedNotification);
            buildingTurnedOffNotificationBinding.Update(n.BuildingTurnedOffNotification);
            buildingHighRentNotificationBinding.Update(n.BuildingHighRentNotification);
            buildingLevelingNotificationBinding.Update(n.BuildingLevelingNotification);

            trafficBottleneckNotificationBinding.Update(n.TrafficBottleneckNotification);
            trafficDeadEndNotificationBinding.Update(n.TrafficDeadEndNotification);
            trafficRoadConnectionNotificationBinding.Update(n.TrafficRoadConnectionNotification);
            trafficTrackConnectionNotificationBinding.Update(n.TrafficTrackConnectionNotification);
            trafficCarConnectionNotificationBinding.Update(n.TrafficCarConnectionNotification);
            trafficShipConnectionNotificationBinding.Update(n.TrafficShipConnectionNotification);
            trafficTrainConnectionNotificationBinding.Update(n.TrafficTrainConnectionNotification);
            trafficPedestrianConnectionNotificationBinding.Update(n.TrafficPedestrianConnectionNotification);
            trafficBicycleConnectionNotificationBinding.Update(n.TrafficBicycleConnectionNotification);

            companyNoInputsNotificationBinding.Update(n.CompanyNoInputsNotification);
            companyNoCustomersNotificationBinding.Update(n.CompanyNoCustomersNotification);

            workProviderUneducatedNotificationBinding.Update(n.WorkProviderUneducatedNotification);
            workProviderEducatedNotificationBinding.Update(n.WorkProviderEducatedNotification);

            disasterWeatherDamageNotificationBinding.Update(n.DisasterWeatherDamageNotification);
            disasterWeatherDestroyedNotificationBinding.Update(n.DisasterWeatherDestroyedNotification);
            disasterWaterDamageNotificationBinding.Update(n.DisasterWaterDamageNotification);
            disasterWaterDestroyedNotificationBinding.Update(n.DisasterWaterDestroyedNotification);
            disasterDestroyedNotificationBinding.Update(n.DisasterDestroyedNotification);

            fireFireNotificationBinding.Update(n.FireFireNotification);
            fireBurnedDownNotificationBinding.Update(n.FireBurnedDownNotification);

            garbageGarbageNotificationBinding.Update(n.GarbageGarbageNotification);
            garbageFacilityFullNotificationBinding.Update(n.GarbageFacilityFullNotification);

            healthcareAmbulanceNotificationBinding.Update(n.HealthcareAmbulanceNotification);
            healthcareHearseNotificationBinding.Update(n.HealthcareHearseNotification);
            healthcareFacilityFullNotificationBinding.Update(n.HealthcareFacilityFullNotification);

            policeTrafficAccidentNotificationBinding.Update(n.PoliceTrafficAccidentNotification);
            policeCrimeSceneNotificationBinding.Update(n.PoliceCrimeSceneNotification);

            pollutionAirPollutionNotificationBinding.Update(n.PollutionAirPollutionNotification);
            pollutionNoisePollutionNotificationBinding.Update(n.PollutionNoisePollutionNotification);
            pollutionGroundPollutionNotificationBinding.Update(n.PollutionGroundPollutionNotification);

            resourceConsumerNoResourceNotificationBinding.Update(n.ResourceConsumerNoResourceNotification);
            resourceConsumerNoFuelNotificationBinding.Update(n.ResourceConsumerNoFuelNotification);
            resourceConnectionWarningNotificationBinding.Update(n.ResourceConnectionWarningNotification);
            resourceConnectionOilPipeNotConnectedNotificationBinding.Update(n.ResourceConnectionOilPipeNotConnectedNotification);
            resourceConnectionFishingPierNotConnectedNotificationBinding.Update(n.ResourceConnectionFishingPierNotConnectedNotification);

            routePathfindNotificationBinding.Update(n.RoutePathfindNotification);
            routeGateBypassNotificationBinding.Update(n.RouteGateBypassNotification);

            transportLineVehicleNotificationBinding.Update(n.TransportLineVehicleNotification);
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

        private ProxyAction? EnableAction(string actionName)
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
            panelVisibleBinding.Update(value);
            if (value)
            {
                notificationCountUpdateState.ForceUpdate();
            }
        }

        private void ToggleControlPanelFromHotkey()
        {
            bool visible = !panelVisibleBinding.Value;
            panelVisibleBinding.Update(visible);
            if (visible)
            {
                notificationCountUpdateState.ForceUpdate();
            }
        }

        private void JumpToMiniHudNotification(int index)
        {
            if (!alertIconSystem.TryGetNextNotificationEntity(index, out Entity entity) ||
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

            miniHudFavoritesBinding.Update(GetMiniHudFavoriteIndexes());
        }

        private void SaveMiniHudPosition(string payload)
        {
            if (CwdSettings.Instance.MiniHudPlacement != CwdSettings.MiniHudPlacementDraggable ||
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

            x = Math.Clamp(x, -CwdSettings.MiniHudPositionLimit, CwdSettings.MiniHudPositionLimit);
            y = Math.Clamp(y, -CwdSettings.MiniHudPositionLimit, CwdSettings.MiniHudPositionLimit);

            if (orientation == CwdSettings.MiniHudOrientationHorizontal)
            {
                if (CwdSettings.Instance.MiniHudHorizontalPositionX == x &&
                    CwdSettings.Instance.MiniHudHorizontalPositionY == y)
                {
                    return;
                }

                CwdSettings.Instance.MiniHudHorizontalPositionX = x;
                CwdSettings.Instance.MiniHudHorizontalPositionY = y;
            }
            else if (orientation == CwdSettings.MiniHudOrientationVertical)
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

            x = Math.Clamp(x, -CwdSettings.PanelPositionLimit, CwdSettings.PanelPositionLimit);
            y = Math.Clamp(y, -CwdSettings.PanelPositionLimit, CwdSettings.PanelPositionLimit);

            if (CwdSettings.Instance.PanelPositionX == x && CwdSettings.Instance.PanelPositionY == y)
            {
                return;
            }

            CwdSettings.Instance.PanelPositionX = x;
            CwdSettings.Instance.PanelPositionY = y;
            panelPositionXBinding.Update(x);
            panelPositionYBinding.Update(y);

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
            panelCollapsedSectionsMaskBinding.Update(mask);

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
            panelSortModeBinding.Update(mode);

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

        public void UpdateMoneyViewBinding(bool value) => moneyViewBinding?.Update(value);

        public void UpdateMoneyViewModeBinding(int value) => moneyViewModeBinding?.Update(value);

        public void UpdateMoneyTooltipModeBinding(int value) => moneyTooltipModeBinding?.Update(value);

        public void UpdateMoneyTooltipFontScaleBinding(int value) => moneyTooltipFontScaleBinding?.Update(value);

        public void UpdatePopulationTooltipFontScaleBinding(int value) => populationTooltipFontScaleBinding?.Update(value);

        public void UpdateMiniHudEnabledBinding(bool value)
        {
            miniHudEnabledBinding?.Update(value);
            if (value)
            {
                miniHudCountUpdateState?.ForceUpdate();
            }
        }

        public void UpdateMiniHudModeBinding(int value) => miniHudModeBinding?.Update(value);

        public void UpdateMiniHudItemCountBinding(int value) => miniHudItemCountBinding?.Update(value);

        public void UpdateMiniHudScaleBinding(int value) => miniHudScaleBinding?.Update(value);

        public void UpdateMiniHudOrientationBinding(int value) => miniHudOrientationBinding?.Update(value);

        public void UpdateMiniHudPlacementBinding(int value) => miniHudPlacementBinding?.Update(value);

        public void UpdateMiniHudHideZeroBinding(bool value) => miniHudHideZeroBinding?.Update(value);

        public void UpdateMiniHudPanelStyleBinding(int value) => miniHudPanelStyleBinding?.Update(value);

        public void UpdateMiniHudPanelOpacityBinding(int value) => miniHudPanelOpacityBinding?.Update(value);

        public void UpdateMiniHudFavoritesBinding() => miniHudFavoritesBinding?.Update(GetMiniHudFavoriteIndexes());

        private void UpdateMiniHudPositionBinding(int x, int y, int orientation)
        {
            if (orientation == CwdSettings.MiniHudOrientationHorizontal)
            {
                miniHudHorizontalPositionXBinding?.Update(x);
                miniHudHorizontalPositionYBinding?.Update(y);
            }
            else if (orientation == CwdSettings.MiniHudOrientationVertical)
            {
                miniHudVerticalPositionXBinding?.Update(x);
                miniHudVerticalPositionYBinding?.Update(y);
            }
        }

        public void UpdateMiniHudPositionBindings()
        {
            miniHudHorizontalPositionXBinding?.Update(CwdSettings.Instance.MiniHudHorizontalPositionX);
            miniHudHorizontalPositionYBinding?.Update(CwdSettings.Instance.MiniHudHorizontalPositionY);
            miniHudVerticalPositionXBinding?.Update(CwdSettings.Instance.MiniHudVerticalPositionX);
            miniHudVerticalPositionYBinding?.Update(CwdSettings.Instance.MiniHudVerticalPositionY);
        }

        public void UpdatePanelButtonsOnlyStartBinding(bool value) => panelButtonsOnlyStartBinding?.Update(value);

        public void UpdateMainPanelOpacityBinding(int value) => mainPanelOpacityBinding?.Update(value);

    }

}
