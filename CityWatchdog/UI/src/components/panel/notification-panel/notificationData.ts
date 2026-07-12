// File: src/UI/src/components/panel/notification-panel/notificationData.ts
// Purpose: Notification panel section data, vanilla title keys, icons, and binding/toggle wiring.

import type { ValueBinding } from "cs2/api";
import {
    BuildingAbandonedCollapsedNotificationBinding$, BuildingAbandonedNotificationBinding$, BuildingCondemnedNotificationBinding$,
    BuildingHighRentNotificationBinding$,
    BuildingLevelingNotificationBinding$,
    BuildingTurnedOffNotificationBinding$,
    CompanyNoCustomersNotificationBinding$, CompanyNoInputsNotificationBinding$,
    DisasterDestroyedNotificationBinding$, DisasterWaterDamageNotificationBinding$, DisasterWaterDestroyedNotificationBinding$, DisasterWeatherDamageNotificationBinding$, DisasterWeatherDestroyedNotificationBinding$,
    ElectricityBatteryEmptyNotificationBinding$,
    ElectricityBottleneckNotificationBinding$, ElectricityBuildingBottleneckNotificationBinding$,
    ElectricityElectricityNotificationBinding$,
    ElectricityHighVoltageNotConnectedBinding$, ElectricityLowVoltageNotConnectedBinding$,
    ElectricityNotEnoughConnectedNotificationBinding$,
    ElectricityNotEnoughProductionNotificationBinding$, ElectricityTransformerNotificationBinding$,
    FireBurnedDownNotificationBinding$, FireFireNotificationBinding$,
    GarbageFacilityFullNotificationBinding$, GarbageGarbageNotificationBinding$,
    HealthcareAmbulanceNotificationBinding$, HealthcareFacilityFullNotificationBinding$, HealthcareHearseNotificationBinding$,
    OnBuildingAbandonedCollapsedNotificationBindingToggle, OnBuildingAbandonedNotificationBindingToggle, OnBuildingCondemnedNotificationBindingToggle,
    OnBuildingHighRentNotificationBindingToggle,
    OnBuildingLevelingNotificationBindingToggle,
    OnBuildingTurnedOffNotificationBindingToggle,
    OnCompanyNoCustomersNotificationBindingToggle, OnCompanyNoInputsNotificationBindingToggle,
    OnDisasterDestroyedNotificationBindingToggle, OnDisasterWaterDamageNotificationBindingToggle, OnDisasterWaterDestroyedNotificationBindingToggle, OnDisasterWeatherDamageNotificationBindingToggle, OnDisasterWeatherDestroyedNotificationBindingToggle,
    OnElectricityBatteryEmptyNotificationBindingToggle,
    OnElectricityBottleneckNotificationBindingToggle, OnElectricityBuildingBottleneckNotificationBindingToggle,
    OnElectricityElectricityNotificationBindingToggle,
    OnElectricityHighVoltageNotConnectedBindingToggle, OnElectricityLowVoltageNotConnectedBindingToggle,
    OnElectricityNotEnoughConnectedNotificationBindingToggle,
    OnElectricityNotEnoughProductionNotificationBindingToggle, OnElectricityTransformerNotificationBindingToggle,
    OnFireBurnedDownNotificationBindingToggle, OnFireFireNotificationBindingToggle,
    OnGarbageFacilityFullNotificationBindingToggle, OnGarbageGarbageNotificationBindingToggle,
    OnHealthcareAmbulanceNotificationBindingToggle, OnHealthcareFacilityFullNotificationBindingToggle, OnHealthcareHearseNotificationBindingToggle,
    OnPoliceCrimeSceneNotificationBindingToggle, OnPoliceTrafficAccidentNotificationBindingToggle,
    OnPollutionAirPollutionNotificationBindingToggle, OnPollutionGroundPollutionNotificationBindingToggle, OnPollutionNoisePollutionNotificationBindingToggle,
    OnResourceConsumerNoFuelNotificationBindingToggle,
    OnResourceConsumerNoResourceNotificationBindingToggle,
    OnResourceConnectionFishingPierNotConnectedNotificationBindingToggle,
    OnResourceConnectionOilPipeNotConnectedNotificationBindingToggle,
    OnRouteGateBypassNotificationBindingToggle,
    OnRoutePathfindNotificationBindingToggle,
    OnTrafficBottleneckNotificationBindingToggle,
    OnTrafficCarConnectionNotificationBindingToggle,
    OnTrafficBicycleConnectionNotificationBindingToggle,
    OnTrafficDeadEndNotificationBindingToggle,
    OnTrafficPedestrianConnectionNotificationBindingToggle,
    OnTrafficRoadConnectionNotificationBindingToggle,
    OnTrafficShipConnectionNotificationBindingToggle,
    OnTrafficTrackConnectionNotificationBindingToggle,
    OnTrafficTrainConnectionNotificationBindingToggle,
    OnResourceConnectionWarningNotificationBindingToggle,
    OnTransportLineVehicleNotificationBindingToggle,
    OnToggleAllNotifications,
    OnWaterPipeDirtyWaterNotificationBindingToggle,
    OnWaterPipeDirtyWaterPumpNotificationBindingToggle,
    OnWaterPipeNotEnoughGroundwaterNotificationBindingToggle,
    OnWaterPipeNotEnoughSewageCapacityNotificationBindingToggle,
    OnWaterPipeNotEnoughSurfaceWaterNotificationBindingToggle,
    OnWaterPipeNotEnoughWaterCapacityNotificationBindingToggle,
    OnWaterPipeSewageNotificationBindingToggle,
    OnWaterPipeSewagePipeNotConnectedNotificationBindingToggle,
    OnWaterPipeWaterNotificationBindingToggle,
    OnWaterPipeWaterPipeNotConnectedNotificationBindingToggle,
    PoliceCrimeSceneNotificationBinding$, PoliceTrafficAccidentNotificationBinding$,
    PollutionAirPollutionNotificationBinding$, PollutionGroundPollutionNotificationBinding$, PollutionNoisePollutionNotificationBinding$,
    ResourceConsumerNoFuelNotificationBinding$,
    ResourceConsumerNoResourceNotificationBinding$,
    ResourceConnectionFishingPierNotConnectedNotificationBinding$,
    ResourceConnectionOilPipeNotConnectedNotificationBinding$,
    ResourceConnectionWarningNotificationBinding$,
    RouteGateBypassNotificationBinding$,
    RoutePathfindNotificationBinding$,
    TrafficBicycleConnectionNotificationBinding$,
    TrafficBottleneckNotificationBinding$,
    TrafficCarConnectionNotificationBinding$,
    TrafficDeadEndNotificationBinding$,
    TrafficPedestrianConnectionNotificationBinding$,
    TrafficRoadConnectionNotificationBinding$,
    TrafficShipConnectionNotificationBinding$,
    TrafficTrackConnectionNotificationBinding$,
    TrafficTrainConnectionNotificationBinding$,
    TransportLineVehicleNotificationBinding$,
    WaterPipeDirtyWaterNotificationBinding$,
    WaterPipeDirtyWaterPumpNotificationBinding$,
    WaterPipeNotEnoughGroundwaterNotificationBinding$,
    WaterPipeNotEnoughSewageCapacityNotificationBinding$,
    WaterPipeNotEnoughSurfaceWaterNotificationBinding$,
    WaterPipeNotEnoughWaterCapacityNotificationBinding$,
    WaterPipeSewageNotificationBinding$,
    WaterPipeSewagePipeNotConnectedNotificationBinding$,
    WaterPipeWaterNotificationBinding$,
    WaterPipeWaterPipeNotConnectedNotificationBinding$,
    WorkProviderEducatedNotificationBinding$, WorkProviderUneducatedNotificationBinding$,
    OnWorkProviderEducatedNotificationBindingToggle, OnWorkProviderUneducatedNotificationBindingToggle,
} from "../../../bindings/bindings";

export type Localize = (localeId: string, fallback?: string, raw?: boolean) => string;

export interface NotificationItem {
    readonly localeId: string;

    // Built-in game localization key for the notification title.
    // If the game key is missing, CWD falls back to the CWD locale string.
    readonly gameTitleKey?: string;

    // Optional Mini HUD identity. Use this when two panel rows represent the same vanilla alert/icon/count.
    readonly miniHudIdentity?: string;

    readonly icon: string;
    readonly binding: ValueBinding<boolean>;
    readonly onToggle: (enabled: boolean) => void;
}

export interface NotificationSection {
    readonly localeId: string;
    readonly defaultExpanded?: boolean;
    readonly items: NotificationItem[];
}

const icon = (name: string) => `Media/Game/Notifications/${name}.svg`;
const facilityFullMiniHudIdentity = "FacilityFullNotification";

export const gameTitleKeys: Record<string, string> = {
    ElectricityElectricityNotification: "Notifications.TITLE[Electricity Notification]",
    ElectricityBottleneckNotification: "Notifications.TITLE[Electricity Bottleneck Notification]",
    ElectricityBuildingBottleneckNotification: "Notifications.TITLE[Electricity Building Bottleneck Notification]",
    ElectricityNotEnoughProductionNotification: "Notifications.TITLE[Electricity Not Enough Production Notification]",
    ElectricityTransformerNotification: "Notifications.TITLE[Electricity Transformer Out of Capacity]",
    ElectricityNotEnoughConnectedNotification: "Notifications.TITLE[Electricity Not Enough Connected Notification]",
    ElectricityBatteryEmptyNotification: "Notifications.TITLE[Battery Empty]",
    ElectricityLowVoltageNotConnected: "Notifications.TITLE[Powerline Not Connected - Low]",
    ElectricityHighVoltageNotConnected: "Notifications.TITLE[Powerline Not Connected]",

    WaterPipeWaterNotification: "Notifications.TITLE[Water Notification]",
    WaterPipeDirtyWaterNotification: "Notifications.TITLE[Dirty Water]",
    WaterPipeSewageNotification: "Notifications.TITLE[Sewage Notification]",
    WaterPipeWaterPipeNotConnectedNotification: "Notifications.TITLE[Pipeline Not Connected]",
    WaterPipeSewagePipeNotConnectedNotification: "Notifications.TITLE[Pipeline Not Connected - Sewage]",
    WaterPipeNotEnoughWaterCapacityNotification: "Notifications.TITLE[Water Not Enough Production Notification]",
    WaterPipeNotEnoughSewageCapacityNotification: "Notifications.TITLE[Sewage Not Enough Production Notification]",
    WaterPipeNotEnoughGroundwaterNotification: "Notifications.TITLE[Not Enough Groundwater Notification]",
    WaterPipeNotEnoughSurfaceWaterNotification: "Notifications.TITLE[Not Enough Surface Water Notification]",
    WaterPipeDirtyWaterPumpNotification: "Notifications.TITLE[Dirty Water Pump Notification]",

    BuildingAbandonedCollapsedNotification: "Notifications.TITLE[Abandoned Collapsed]",
    BuildingAbandonedNotification: "Notifications.TITLE[Abandoned]",
    BuildingCondemnedNotification: "Notifications.TITLE[Condemned]",
    BuildingTurnedOffNotification: "Notifications.TITLE[Turned Off]",
    BuildingHighRentNotification: "Notifications.TITLE[Rent Too High]",
    BuildingLevelingNotification: "Notifications.TITLE[Leveling Building]",

    TrafficBottleneckNotification: "Notifications.TITLE[Traffic Bottleneck Notification]",
    TrafficDeadEndNotification: "Notifications.TITLE[Dead End]",
    TrafficRoadConnectionNotification: "Notifications.TITLE[No Road Access]",
    TrafficTrackConnectionNotification: "Notifications.TITLE[Track Not Connected]",
    TrafficCarConnectionNotification: "Notifications.TITLE[No Car Access]",
    TrafficShipConnectionNotification: "Notifications.TITLE[No Watercraft Access]",
    TrafficTrainConnectionNotification: "Notifications.TITLE[No Train Access]",
    TrafficPedestrianConnectionNotification: "Notifications.TITLE[No Pedestrian Access]",
    TrafficBicycleConnectionNotification: "Notifications.TITLE[No Bicycle Access]",

    CompanyNoInputsNotification: "Notifications.TITLE[No Inputs]",
    CompanyNoCustomersNotification: "Notifications.TITLE[No Customers]",

    WorkProviderUneducatedNotification: "Notifications.TITLE[MissingUneducatedWorkers]",
    WorkProviderEducatedNotification: "Notifications.TITLE[MissingEducatedWorkers]",

    DisasterWeatherDamageNotification: "Notifications.TITLE[Weather Damage]",
    DisasterWeatherDestroyedNotification: "Notifications.TITLE[Weather Destroyed]",
    DisasterWaterDamageNotification: "Notifications.TITLE[Water Damage]",
    DisasterWaterDestroyedNotification: "Notifications.TITLE[Water Destroyed]",
    DisasterDestroyedNotification: "Notifications.TITLE[Destroyed]",

    FireFireNotification: "Notifications.TITLE[Fire Notification]",
    FireBurnedDownNotification: "Notifications.TITLE[Burned Down]",

    GarbageGarbageNotification: "Notifications.TITLE[Garbage Notification]",
    GarbageFacilityFullNotification: "Notifications.TITLE[Facility Full]",

    HealthcareAmbulanceNotification: "Notifications.TITLE[Ambulance Notification]",
    HealthcareHearseNotification: "Notifications.TITLE[Hearse Notification]",
    HealthcareFacilityFullNotification: "Notifications.TITLE[Facility Full]",

    PoliceTrafficAccidentNotification: "Notifications.TITLE[Traffic Accident]",
    PoliceCrimeSceneNotification: "Notifications.TITLE[Crime Scene]",

    PollutionAirPollutionNotification: "Notifications.TITLE[Air Pollution]",
    PollutionNoisePollutionNotification: "Notifications.TITLE[Noise Pollution]",
    PollutionGroundPollutionNotification: "Notifications.TITLE[Ground Pollution]",

    // Live medical/shelter resource prefabs use this key and display as "Low Supplies".
    ResourceConsumerNoResourceNotification: "Notifications.TITLE[No Hospital Supplies]",
    ResourceConsumerNoFuelNotification: "Notifications.TITLE[No Fuel Notification]",
    ResourceConnectionOilPipeNotConnectedNotification: "Notifications.TITLE[Oil Pipe Not Connected]",
    ResourceConnectionFishingPierNotConnectedNotification: "Notifications.TITLE[Fishing Pier Not Connected]",
    RoutePathfindNotification: "Notifications.TITLE[Pathfind Failed]",
    RouteGateBypassNotification: "Notifications.TITLE[Gate Bypass Exists]",
    TransportLineVehicleNotification: "Notifications.TITLE[No Vehicles]",
};

export const sections: NotificationSection[] = [
    {
        localeId: "Electricity",
        defaultExpanded: true,
        items: [
            { icon: icon("NotEnoughElectricity"), localeId: "ElectricityElectricityNotification", binding: ElectricityElectricityNotificationBinding$, onToggle: OnElectricityElectricityNotificationBindingToggle },
            { icon: icon("ElectricityBottleneck"), localeId: "ElectricityBottleneckNotification", binding: ElectricityBottleneckNotificationBinding$, onToggle: OnElectricityBottleneckNotificationBindingToggle },
            { icon: icon("BadServiceElectricity"), localeId: "ElectricityBuildingBottleneckNotification", binding: ElectricityBuildingBottleneckNotificationBinding$, onToggle: OnElectricityBuildingBottleneckNotificationBindingToggle },
            { icon: icon("LowProductionElectricity"), localeId: "ElectricityNotEnoughProductionNotification", binding: ElectricityNotEnoughProductionNotificationBinding$, onToggle: OnElectricityNotEnoughProductionNotificationBindingToggle },
            { icon: icon("OutOfCapacityElectricity"), localeId: "ElectricityTransformerNotification", binding: ElectricityTransformerNotificationBinding$, onToggle: OnElectricityTransformerNotificationBindingToggle },
            { icon: icon("NotEnoughOutputLinesConnected"), localeId: "ElectricityNotEnoughConnectedNotification", binding: ElectricityNotEnoughConnectedNotificationBinding$, onToggle: OnElectricityNotEnoughConnectedNotificationBindingToggle },
            { icon: icon("BatteryEmpty"), localeId: "ElectricityBatteryEmptyNotification", binding: ElectricityBatteryEmptyNotificationBinding$, onToggle: OnElectricityBatteryEmptyNotificationBindingToggle },
            { icon: icon("PowerlineDisconnectedLow"), localeId: "ElectricityLowVoltageNotConnected", binding: ElectricityLowVoltageNotConnectedBinding$, onToggle: OnElectricityLowVoltageNotConnectedBindingToggle },
            { icon: icon("PowerlineDisconnected"), localeId: "ElectricityHighVoltageNotConnected", binding: ElectricityHighVoltageNotConnectedBinding$, onToggle: OnElectricityHighVoltageNotConnectedBindingToggle },
        ],
    },
    {
        localeId: "WaterPipe",
        items: [
            { icon: icon("NoRunningWater"), localeId: "WaterPipeWaterNotification", binding: WaterPipeWaterNotificationBinding$, onToggle: OnWaterPipeWaterNotificationBindingToggle },
            { icon: icon("ContaminatedWater"), localeId: "WaterPipeDirtyWaterNotification", binding: WaterPipeDirtyWaterNotificationBinding$, onToggle: OnWaterPipeDirtyWaterNotificationBindingToggle },
            { icon: icon("Sewage"), localeId: "WaterPipeSewageNotification", binding: WaterPipeSewageNotificationBinding$, onToggle: OnWaterPipeSewageNotificationBindingToggle },
            { icon: icon("WaterPipeDisconnected"), localeId: "WaterPipeWaterPipeNotConnectedNotification", binding: WaterPipeWaterPipeNotConnectedNotificationBinding$, onToggle: OnWaterPipeWaterPipeNotConnectedNotificationBindingToggle },
            { icon: icon("SewagePipeDisconnected"), localeId: "WaterPipeSewagePipeNotConnectedNotification", binding: WaterPipeSewagePipeNotConnectedNotificationBinding$, onToggle: OnWaterPipeSewagePipeNotConnectedNotificationBindingToggle },
            { icon: icon("WaterFacilityOverload"), localeId: "WaterPipeNotEnoughWaterCapacityNotification", binding: WaterPipeNotEnoughWaterCapacityNotificationBinding$, onToggle: OnWaterPipeNotEnoughWaterCapacityNotificationBindingToggle },
            { icon: icon("SewageFacilityOverload"), localeId: "WaterPipeNotEnoughSewageCapacityNotification", binding: WaterPipeNotEnoughSewageCapacityNotificationBinding$, onToggle: OnWaterPipeNotEnoughSewageCapacityNotificationBindingToggle },
            { icon: icon("GroundwaterLevelLow"), localeId: "WaterPipeNotEnoughGroundwaterNotification", binding: WaterPipeNotEnoughGroundwaterNotificationBinding$, onToggle: OnWaterPipeNotEnoughGroundwaterNotificationBindingToggle },
            { icon: icon("SurfaceWaterLevelLow"), localeId: "WaterPipeNotEnoughSurfaceWaterNotification", binding: WaterPipeNotEnoughSurfaceWaterNotificationBinding$, onToggle: OnWaterPipeNotEnoughSurfaceWaterNotificationBindingToggle },
            { icon: icon("DirtyWaterPump"), localeId: "WaterPipeDirtyWaterPumpNotification", binding: WaterPipeDirtyWaterPumpNotificationBinding$, onToggle: OnWaterPipeDirtyWaterPumpNotificationBindingToggle },
        ],
    },
    {
        localeId: "Building",
        items: [
            { icon: icon("BuildingCollapsed"), localeId: "BuildingAbandonedCollapsedNotification", binding: BuildingAbandonedCollapsedNotificationBinding$, onToggle: OnBuildingAbandonedCollapsedNotificationBindingToggle },
            { icon: icon("BuildingAbandoned"), localeId: "BuildingAbandonedNotification", binding: BuildingAbandonedNotificationBinding$, onToggle: OnBuildingAbandonedNotificationBindingToggle },
            { icon: icon("BuildingCondemned"), localeId: "BuildingCondemnedNotification", binding: BuildingCondemnedNotificationBinding$, onToggle: OnBuildingCondemnedNotificationBindingToggle },
            { icon: icon("TurnedOff"), localeId: "BuildingTurnedOffNotification", binding: BuildingTurnedOffNotificationBinding$, onToggle: OnBuildingTurnedOffNotificationBindingToggle },
            { icon: icon("RentTooHigh"), localeId: "BuildingHighRentNotification", binding: BuildingHighRentNotificationBinding$, onToggle: OnBuildingHighRentNotificationBindingToggle },
            { icon: icon("LevelingBuilding"), localeId: "BuildingLevelingNotification", binding: BuildingLevelingNotificationBinding$, onToggle: OnBuildingLevelingNotificationBindingToggle },
        ],
    },
    {
        localeId: "Traffic",
        items: [
            { icon: icon("TrafficBottleneck"), localeId: "TrafficBottleneckNotification", binding: TrafficBottleneckNotificationBinding$, onToggle: OnTrafficBottleneckNotificationBindingToggle },
            { icon: icon("DeadEnd"), localeId: "TrafficDeadEndNotification", binding: TrafficDeadEndNotificationBinding$, onToggle: OnTrafficDeadEndNotificationBindingToggle },
            { icon: icon("RoadNotConnected"), localeId: "TrafficRoadConnectionNotification", binding: TrafficRoadConnectionNotificationBinding$, onToggle: OnTrafficRoadConnectionNotificationBindingToggle },
            { icon: icon("TrackNotConnected"), localeId: "TrafficTrackConnectionNotification", binding: TrafficTrackConnectionNotificationBinding$, onToggle: OnTrafficTrackConnectionNotificationBindingToggle },
            { icon: icon("NoCarAccess"), localeId: "TrafficCarConnectionNotification", binding: TrafficCarConnectionNotificationBinding$, onToggle: OnTrafficCarConnectionNotificationBindingToggle },
            { icon: icon("NoBoatAccess"), localeId: "TrafficShipConnectionNotification", binding: TrafficShipConnectionNotificationBinding$, onToggle: OnTrafficShipConnectionNotificationBindingToggle },
            { icon: icon("NoTrainAccess"), localeId: "TrafficTrainConnectionNotification", binding: TrafficTrainConnectionNotificationBinding$, onToggle: OnTrafficTrainConnectionNotificationBindingToggle },
            { icon: icon("NoPedestrianAccess"), localeId: "TrafficPedestrianConnectionNotification", binding: TrafficPedestrianConnectionNotificationBinding$, onToggle: OnTrafficPedestrianConnectionNotificationBindingToggle },
            { icon: icon("NoBikeAccess"), localeId: "TrafficBicycleConnectionNotification", binding: TrafficBicycleConnectionNotificationBinding$, onToggle: OnTrafficBicycleConnectionNotificationBindingToggle },
        ],
    },
    {
        localeId: "Company",
        items: [
            { icon: icon("NoInputs"), localeId: "CompanyNoInputsNotification", gameTitleKey: "Notifications.TITLE[No Inputs]", binding: CompanyNoInputsNotificationBinding$, onToggle: OnCompanyNoInputsNotificationBindingToggle },
            { icon: icon("NoCustomers"), localeId: "CompanyNoCustomersNotification", binding: CompanyNoCustomersNotificationBinding$, onToggle: OnCompanyNoCustomersNotificationBindingToggle },
        ],
    },
    {
        localeId: "WorkProvider",
        items: [
            { icon: icon("NoWorkers"), localeId: "WorkProviderUneducatedNotification", binding: WorkProviderUneducatedNotificationBinding$, onToggle: OnWorkProviderUneducatedNotificationBindingToggle },
            { icon: icon("NoEducatedWorkers"), localeId: "WorkProviderEducatedNotification", binding: WorkProviderEducatedNotificationBinding$, onToggle: OnWorkProviderEducatedNotificationBindingToggle },
        ],
    },
    {
        localeId: "Disaster",
        items: [
            { icon: icon("WeatherDamage"), localeId: "DisasterWeatherDamageNotification", binding: DisasterWeatherDamageNotificationBinding$, onToggle: OnDisasterWeatherDamageNotificationBindingToggle },
            { icon: icon("WeatherDestroyed"), localeId: "DisasterWeatherDestroyedNotification", binding: DisasterWeatherDestroyedNotificationBinding$, onToggle: OnDisasterWeatherDestroyedNotificationBindingToggle },
            { icon: icon("WaterDamage"), localeId: "DisasterWaterDamageNotification", binding: DisasterWaterDamageNotificationBinding$, onToggle: OnDisasterWaterDamageNotificationBindingToggle },
            { icon: icon("WaterDestroyed"), localeId: "DisasterWaterDestroyedNotification", binding: DisasterWaterDestroyedNotificationBinding$, onToggle: OnDisasterWaterDestroyedNotificationBindingToggle },
            { icon: icon("Destroyed"), localeId: "DisasterDestroyedNotification", binding: DisasterDestroyedNotificationBinding$, onToggle: OnDisasterDestroyedNotificationBindingToggle },
        ],
    },
    {
        localeId: "Fire",
        items: [
            { icon: icon("BuildingOnFire"), localeId: "FireFireNotification", binding: FireFireNotificationBinding$, onToggle: OnFireFireNotificationBindingToggle },
            { icon: icon("BurnedDown"), localeId: "FireBurnedDownNotification", binding: FireBurnedDownNotificationBinding$, onToggle: OnFireBurnedDownNotificationBindingToggle },
        ],
    },
    {
        localeId: "Garbage",
        items: [
            { icon: icon("TooMuchGarbage"), localeId: "GarbageGarbageNotification", binding: GarbageGarbageNotificationBinding$, onToggle: OnGarbageGarbageNotificationBindingToggle },
            { icon: icon("FacilityFull"), localeId: "GarbageFacilityFullNotification", miniHudIdentity: facilityFullMiniHudIdentity, binding: GarbageFacilityFullNotificationBinding$, onToggle: OnGarbageFacilityFullNotificationBindingToggle },
        ],
    },
    {
        localeId: "Healthcare",
        items: [
            { icon: icon("MedicalEmergency"), localeId: "HealthcareAmbulanceNotification", binding: HealthcareAmbulanceNotificationBinding$, onToggle: OnHealthcareAmbulanceNotificationBindingToggle },
            { icon: icon("HearseServiceNeeded"), localeId: "HealthcareHearseNotification", binding: HealthcareHearseNotificationBinding$, onToggle: OnHealthcareHearseNotificationBindingToggle },
            { icon: icon("FacilityFull"), localeId: "HealthcareFacilityFullNotification", miniHudIdentity: facilityFullMiniHudIdentity, binding: HealthcareFacilityFullNotificationBinding$, onToggle: OnHealthcareFacilityFullNotificationBindingToggle },
        ],
    },
    {
        localeId: "Police",
        items: [
            { icon: icon("TrafficAccident"), localeId: "PoliceTrafficAccidentNotification", binding: PoliceTrafficAccidentNotificationBinding$, onToggle: OnPoliceTrafficAccidentNotificationBindingToggle },
            { icon: icon("CrimeScene"), localeId: "PoliceCrimeSceneNotification", binding: PoliceCrimeSceneNotificationBinding$, onToggle: OnPoliceCrimeSceneNotificationBindingToggle },
        ],
    },
    {
        localeId: "Pollution",
        items: [
            { icon: icon("AirPollution"), localeId: "PollutionAirPollutionNotification", binding: PollutionAirPollutionNotificationBinding$, onToggle: OnPollutionAirPollutionNotificationBindingToggle },
            { icon: icon("NoisePollution"), localeId: "PollutionNoisePollutionNotification", binding: PollutionNoisePollutionNotificationBinding$, onToggle: OnPollutionNoisePollutionNotificationBindingToggle },
            { icon: icon("PollutedSoil"), localeId: "PollutionGroundPollutionNotification", binding: PollutionGroundPollutionNotificationBinding$, onToggle: OnPollutionGroundPollutionNotificationBindingToggle },
        ],
    },
    {
        localeId: "ResourceConsumer",
        items: [
            { icon: icon("NotEnoughIndustrialGoods"), localeId: "ResourceConsumerNoResourceNotification", binding: ResourceConsumerNoResourceNotificationBinding$, onToggle: OnResourceConsumerNoResourceNotificationBindingToggle },
            { icon: icon("NoFuel"), localeId: "ResourceConsumerNoFuelNotification", binding: ResourceConsumerNoFuelNotificationBinding$, onToggle: OnResourceConsumerNoFuelNotificationBindingToggle },
        ],
    },
    {
        localeId: "ResourceConnection",
        items: [
            { icon: icon("OilPipeNotConnected"), localeId: "ResourceConnectionOilPipeNotConnectedNotification", binding: ResourceConnectionOilPipeNotConnectedNotificationBinding$, onToggle: OnResourceConnectionOilPipeNotConnectedNotificationBindingToggle },
            { icon: icon("FishingPierNotConnected"), localeId: "ResourceConnectionFishingPierNotConnectedNotification", binding: ResourceConnectionFishingPierNotConnectedNotificationBinding$, onToggle: OnResourceConnectionFishingPierNotConnectedNotificationBindingToggle },
            { icon: icon("OilPipeNotConnected"), localeId: "ResourceConnectionWarningNotification", binding: ResourceConnectionWarningNotificationBinding$, onToggle: OnResourceConnectionWarningNotificationBindingToggle },
        ],
    },
    {
        localeId: "Route",
        items: [
            { icon: icon("PathfindFailed"), localeId: "RoutePathfindNotification", binding: RoutePathfindNotificationBinding$, onToggle: OnRoutePathfindNotificationBindingToggle },
            { icon: icon("NoPortAccess"), localeId: "RouteGateBypassNotification", binding: RouteGateBypassNotificationBinding$, onToggle: OnRouteGateBypassNotificationBindingToggle },
        ],
    },
    {
        localeId: "TransportLine",
        items: [
            { icon: icon("NoVehicles"), localeId: "TransportLineVehicleNotification", binding: TransportLineVehicleNotificationBinding$, onToggle: OnTransportLineVehicleNotificationBindingToggle },
        ],
    },
];

export const allItems = sections.flatMap((section) => section.items);
export const allIconSources = Array.from(new Set(allItems.map((item) => item.icon)));
export const notificationCountIndexes = new Map(
    allItems.map((item, index) => [item.localeId, index]),
);

export const setAllNotifications = (enabled: boolean) => {
    OnToggleAllNotifications(enabled);
};

export const createExpandedSections = (expanded: boolean | null = null) => {
    const result: Record<string, boolean> = {};

    sections.forEach((section) => {
        // Fresh UI sessions start all rows expanded.
        // In the same city/session, manual expand/collapse state is remembered by React state.
        result[section.localeId] = expanded ?? true;
    });

    return result;
};
