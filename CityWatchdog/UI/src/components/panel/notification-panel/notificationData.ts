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

    // Stable index into the C# count array (AlertIconSystem.Counts.cs) / favorites / jump-to-alert.
    // Explicit and independent of this item's position in `sections` so a row can be moved to a
    // different display section (e.g. "Other") without ever touching the C# side or renumbering.
    readonly countIndex: number;

    // Marks a row as an opt-in, positive-status extra (e.g. Leveling Building) rather than a
    // "problem" alert. Affects it everywhere the panel distinguishes problems from extras:
    // Toggle All / the N hotkey leave its real setting untouched, its tone/count are excluded from
    // the Toggle All summary (so that can still reach a clean "all on"), and it never appears in
    // the Active-first triage list (there's nothing to "fix" about it, so it doesn't belong there).
    readonly optional?: boolean;
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
            { icon: icon("NotEnoughElectricity"), localeId: "ElectricityElectricityNotification", countIndex: 0, binding: ElectricityElectricityNotificationBinding$, onToggle: OnElectricityElectricityNotificationBindingToggle },
            { icon: icon("ElectricityBottleneck"), localeId: "ElectricityBottleneckNotification", countIndex: 1, binding: ElectricityBottleneckNotificationBinding$, onToggle: OnElectricityBottleneckNotificationBindingToggle },
            { icon: icon("BadServiceElectricity"), localeId: "ElectricityBuildingBottleneckNotification", countIndex: 2, binding: ElectricityBuildingBottleneckNotificationBinding$, onToggle: OnElectricityBuildingBottleneckNotificationBindingToggle },
            { icon: icon("LowProductionElectricity"), localeId: "ElectricityNotEnoughProductionNotification", countIndex: 3, binding: ElectricityNotEnoughProductionNotificationBinding$, onToggle: OnElectricityNotEnoughProductionNotificationBindingToggle },
            { icon: icon("OutOfCapacityElectricity"), localeId: "ElectricityTransformerNotification", countIndex: 4, binding: ElectricityTransformerNotificationBinding$, onToggle: OnElectricityTransformerNotificationBindingToggle },
            { icon: icon("NotEnoughOutputLinesConnected"), localeId: "ElectricityNotEnoughConnectedNotification", countIndex: 5, binding: ElectricityNotEnoughConnectedNotificationBinding$, onToggle: OnElectricityNotEnoughConnectedNotificationBindingToggle },
            { icon: icon("BatteryEmpty"), localeId: "ElectricityBatteryEmptyNotification", countIndex: 6, binding: ElectricityBatteryEmptyNotificationBinding$, onToggle: OnElectricityBatteryEmptyNotificationBindingToggle },
            { icon: icon("PowerlineDisconnectedLow"), localeId: "ElectricityLowVoltageNotConnected", countIndex: 7, binding: ElectricityLowVoltageNotConnectedBinding$, onToggle: OnElectricityLowVoltageNotConnectedBindingToggle },
            { icon: icon("PowerlineDisconnected"), localeId: "ElectricityHighVoltageNotConnected", countIndex: 8, binding: ElectricityHighVoltageNotConnectedBinding$, onToggle: OnElectricityHighVoltageNotConnectedBindingToggle },
        ],
    },
    {
        localeId: "WaterPipe",
        items: [
            { icon: icon("NoRunningWater"), localeId: "WaterPipeWaterNotification", countIndex: 9, binding: WaterPipeWaterNotificationBinding$, onToggle: OnWaterPipeWaterNotificationBindingToggle },
            { icon: icon("ContaminatedWater"), localeId: "WaterPipeDirtyWaterNotification", countIndex: 10, binding: WaterPipeDirtyWaterNotificationBinding$, onToggle: OnWaterPipeDirtyWaterNotificationBindingToggle },
            { icon: icon("Sewage"), localeId: "WaterPipeSewageNotification", countIndex: 11, binding: WaterPipeSewageNotificationBinding$, onToggle: OnWaterPipeSewageNotificationBindingToggle },
            { icon: icon("WaterPipeDisconnected"), localeId: "WaterPipeWaterPipeNotConnectedNotification", countIndex: 12, binding: WaterPipeWaterPipeNotConnectedNotificationBinding$, onToggle: OnWaterPipeWaterPipeNotConnectedNotificationBindingToggle },
            { icon: icon("SewagePipeDisconnected"), localeId: "WaterPipeSewagePipeNotConnectedNotification", countIndex: 13, binding: WaterPipeSewagePipeNotConnectedNotificationBinding$, onToggle: OnWaterPipeSewagePipeNotConnectedNotificationBindingToggle },
            { icon: icon("WaterFacilityOverload"), localeId: "WaterPipeNotEnoughWaterCapacityNotification", countIndex: 14, binding: WaterPipeNotEnoughWaterCapacityNotificationBinding$, onToggle: OnWaterPipeNotEnoughWaterCapacityNotificationBindingToggle },
            { icon: icon("SewageFacilityOverload"), localeId: "WaterPipeNotEnoughSewageCapacityNotification", countIndex: 15, binding: WaterPipeNotEnoughSewageCapacityNotificationBinding$, onToggle: OnWaterPipeNotEnoughSewageCapacityNotificationBindingToggle },
            { icon: icon("GroundwaterLevelLow"), localeId: "WaterPipeNotEnoughGroundwaterNotification", countIndex: 16, binding: WaterPipeNotEnoughGroundwaterNotificationBinding$, onToggle: OnWaterPipeNotEnoughGroundwaterNotificationBindingToggle },
            { icon: icon("SurfaceWaterLevelLow"), localeId: "WaterPipeNotEnoughSurfaceWaterNotification", countIndex: 17, binding: WaterPipeNotEnoughSurfaceWaterNotificationBinding$, onToggle: OnWaterPipeNotEnoughSurfaceWaterNotificationBindingToggle },
            { icon: icon("DirtyWaterPump"), localeId: "WaterPipeDirtyWaterPumpNotification", countIndex: 18, binding: WaterPipeDirtyWaterPumpNotificationBinding$, onToggle: OnWaterPipeDirtyWaterPumpNotificationBindingToggle },
        ],
    },
    {
        localeId: "Building",
        items: [
            { icon: icon("BuildingCollapsed"), localeId: "BuildingAbandonedCollapsedNotification", countIndex: 19, binding: BuildingAbandonedCollapsedNotificationBinding$, onToggle: OnBuildingAbandonedCollapsedNotificationBindingToggle },
            { icon: icon("BuildingAbandoned"), localeId: "BuildingAbandonedNotification", countIndex: 20, binding: BuildingAbandonedNotificationBinding$, onToggle: OnBuildingAbandonedNotificationBindingToggle },
            { icon: icon("BuildingCondemned"), localeId: "BuildingCondemnedNotification", countIndex: 21, binding: BuildingCondemnedNotificationBinding$, onToggle: OnBuildingCondemnedNotificationBindingToggle },
            { icon: icon("TurnedOff"), localeId: "BuildingTurnedOffNotification", countIndex: 22, binding: BuildingTurnedOffNotificationBinding$, onToggle: OnBuildingTurnedOffNotificationBindingToggle },
            { icon: icon("RentTooHigh"), localeId: "BuildingHighRentNotification", countIndex: 23, binding: BuildingHighRentNotificationBinding$, onToggle: OnBuildingHighRentNotificationBindingToggle },
        ],
    },
    {
        localeId: "Traffic",
        items: [
            { icon: icon("TrafficBottleneck"), localeId: "TrafficBottleneckNotification", countIndex: 25, binding: TrafficBottleneckNotificationBinding$, onToggle: OnTrafficBottleneckNotificationBindingToggle },
            { icon: icon("DeadEnd"), localeId: "TrafficDeadEndNotification", countIndex: 26, binding: TrafficDeadEndNotificationBinding$, onToggle: OnTrafficDeadEndNotificationBindingToggle },
            { icon: icon("RoadNotConnected"), localeId: "TrafficRoadConnectionNotification", countIndex: 27, binding: TrafficRoadConnectionNotificationBinding$, onToggle: OnTrafficRoadConnectionNotificationBindingToggle },
            { icon: icon("TrackNotConnected"), localeId: "TrafficTrackConnectionNotification", countIndex: 28, binding: TrafficTrackConnectionNotificationBinding$, onToggle: OnTrafficTrackConnectionNotificationBindingToggle },
            { icon: icon("NoCarAccess"), localeId: "TrafficCarConnectionNotification", countIndex: 29, binding: TrafficCarConnectionNotificationBinding$, onToggle: OnTrafficCarConnectionNotificationBindingToggle },
            { icon: icon("NoBoatAccess"), localeId: "TrafficShipConnectionNotification", countIndex: 30, binding: TrafficShipConnectionNotificationBinding$, onToggle: OnTrafficShipConnectionNotificationBindingToggle },
            { icon: icon("NoTrainAccess"), localeId: "TrafficTrainConnectionNotification", countIndex: 31, binding: TrafficTrainConnectionNotificationBinding$, onToggle: OnTrafficTrainConnectionNotificationBindingToggle },
            { icon: icon("NoPedestrianAccess"), localeId: "TrafficPedestrianConnectionNotification", countIndex: 32, binding: TrafficPedestrianConnectionNotificationBinding$, onToggle: OnTrafficPedestrianConnectionNotificationBindingToggle },
            { icon: icon("NoBikeAccess"), localeId: "TrafficBicycleConnectionNotification", countIndex: 33, binding: TrafficBicycleConnectionNotificationBinding$, onToggle: OnTrafficBicycleConnectionNotificationBindingToggle },
        ],
    },
    {
        localeId: "Company",
        items: [
            { icon: icon("NoInputs"), localeId: "CompanyNoInputsNotification", gameTitleKey: "Notifications.TITLE[No Inputs]", countIndex: 34, binding: CompanyNoInputsNotificationBinding$, onToggle: OnCompanyNoInputsNotificationBindingToggle },
            { icon: icon("NoCustomers"), localeId: "CompanyNoCustomersNotification", countIndex: 35, binding: CompanyNoCustomersNotificationBinding$, onToggle: OnCompanyNoCustomersNotificationBindingToggle },
        ],
    },
    {
        localeId: "WorkProvider",
        items: [
            { icon: icon("NoWorkers"), localeId: "WorkProviderUneducatedNotification", countIndex: 36, binding: WorkProviderUneducatedNotificationBinding$, onToggle: OnWorkProviderUneducatedNotificationBindingToggle },
            { icon: icon("NoEducatedWorkers"), localeId: "WorkProviderEducatedNotification", countIndex: 37, binding: WorkProviderEducatedNotificationBinding$, onToggle: OnWorkProviderEducatedNotificationBindingToggle },
        ],
    },
    {
        localeId: "Disaster",
        items: [
            { icon: icon("WeatherDamage"), localeId: "DisasterWeatherDamageNotification", countIndex: 38, binding: DisasterWeatherDamageNotificationBinding$, onToggle: OnDisasterWeatherDamageNotificationBindingToggle },
            { icon: icon("WeatherDestroyed"), localeId: "DisasterWeatherDestroyedNotification", countIndex: 39, binding: DisasterWeatherDestroyedNotificationBinding$, onToggle: OnDisasterWeatherDestroyedNotificationBindingToggle },
            { icon: icon("WaterDamage"), localeId: "DisasterWaterDamageNotification", countIndex: 40, binding: DisasterWaterDamageNotificationBinding$, onToggle: OnDisasterWaterDamageNotificationBindingToggle },
            { icon: icon("WaterDestroyed"), localeId: "DisasterWaterDestroyedNotification", countIndex: 41, binding: DisasterWaterDestroyedNotificationBinding$, onToggle: OnDisasterWaterDestroyedNotificationBindingToggle },
            { icon: icon("Destroyed"), localeId: "DisasterDestroyedNotification", countIndex: 42, binding: DisasterDestroyedNotificationBinding$, onToggle: OnDisasterDestroyedNotificationBindingToggle },
        ],
    },
    {
        localeId: "Fire",
        items: [
            { icon: icon("BuildingOnFire"), localeId: "FireFireNotification", countIndex: 43, binding: FireFireNotificationBinding$, onToggle: OnFireFireNotificationBindingToggle },
            { icon: icon("BurnedDown"), localeId: "FireBurnedDownNotification", countIndex: 44, binding: FireBurnedDownNotificationBinding$, onToggle: OnFireBurnedDownNotificationBindingToggle },
        ],
    },
    {
        localeId: "Garbage",
        items: [
            { icon: icon("TooMuchGarbage"), localeId: "GarbageGarbageNotification", countIndex: 45, binding: GarbageGarbageNotificationBinding$, onToggle: OnGarbageGarbageNotificationBindingToggle },
            { icon: icon("FacilityFull"), localeId: "GarbageFacilityFullNotification", miniHudIdentity: facilityFullMiniHudIdentity, countIndex: 46, binding: GarbageFacilityFullNotificationBinding$, onToggle: OnGarbageFacilityFullNotificationBindingToggle },
        ],
    },
    {
        localeId: "Healthcare",
        items: [
            { icon: icon("MedicalEmergency"), localeId: "HealthcareAmbulanceNotification", countIndex: 47, binding: HealthcareAmbulanceNotificationBinding$, onToggle: OnHealthcareAmbulanceNotificationBindingToggle },
            { icon: icon("HearseServiceNeeded"), localeId: "HealthcareHearseNotification", countIndex: 48, binding: HealthcareHearseNotificationBinding$, onToggle: OnHealthcareHearseNotificationBindingToggle },
            { icon: icon("FacilityFull"), localeId: "HealthcareFacilityFullNotification", miniHudIdentity: facilityFullMiniHudIdentity, countIndex: 49, binding: HealthcareFacilityFullNotificationBinding$, onToggle: OnHealthcareFacilityFullNotificationBindingToggle },
        ],
    },
    {
        localeId: "Police",
        items: [
            { icon: icon("TrafficAccident"), localeId: "PoliceTrafficAccidentNotification", countIndex: 50, binding: PoliceTrafficAccidentNotificationBinding$, onToggle: OnPoliceTrafficAccidentNotificationBindingToggle },
            { icon: icon("CrimeScene"), localeId: "PoliceCrimeSceneNotification", countIndex: 51, binding: PoliceCrimeSceneNotificationBinding$, onToggle: OnPoliceCrimeSceneNotificationBindingToggle },
        ],
    },
    {
        localeId: "Pollution",
        items: [
            { icon: icon("AirPollution"), localeId: "PollutionAirPollutionNotification", countIndex: 52, binding: PollutionAirPollutionNotificationBinding$, onToggle: OnPollutionAirPollutionNotificationBindingToggle },
            { icon: icon("NoisePollution"), localeId: "PollutionNoisePollutionNotification", countIndex: 53, binding: PollutionNoisePollutionNotificationBinding$, onToggle: OnPollutionNoisePollutionNotificationBindingToggle },
            { icon: icon("PollutedSoil"), localeId: "PollutionGroundPollutionNotification", countIndex: 54, binding: PollutionGroundPollutionNotificationBinding$, onToggle: OnPollutionGroundPollutionNotificationBindingToggle },
        ],
    },
    {
        localeId: "ResourceConsumer",
        items: [
            { icon: icon("NotEnoughIndustrialGoods"), localeId: "ResourceConsumerNoResourceNotification", countIndex: 55, binding: ResourceConsumerNoResourceNotificationBinding$, onToggle: OnResourceConsumerNoResourceNotificationBindingToggle },
            { icon: icon("NoFuel"), localeId: "ResourceConsumerNoFuelNotification", countIndex: 56, binding: ResourceConsumerNoFuelNotificationBinding$, onToggle: OnResourceConsumerNoFuelNotificationBindingToggle },
        ],
    },
    {
        localeId: "ResourceConnection",
        items: [
            { icon: icon("OilPipeNotConnected"), localeId: "ResourceConnectionOilPipeNotConnectedNotification", countIndex: 57, binding: ResourceConnectionOilPipeNotConnectedNotificationBinding$, onToggle: OnResourceConnectionOilPipeNotConnectedNotificationBindingToggle },
            { icon: icon("FishingPierNotConnected"), localeId: "ResourceConnectionFishingPierNotConnectedNotification", countIndex: 58, binding: ResourceConnectionFishingPierNotConnectedNotificationBinding$, onToggle: OnResourceConnectionFishingPierNotConnectedNotificationBindingToggle },
            { icon: icon("OilPipeNotConnected"), localeId: "ResourceConnectionWarningNotification", countIndex: 59, binding: ResourceConnectionWarningNotificationBinding$, onToggle: OnResourceConnectionWarningNotificationBindingToggle },
        ],
    },
    {
        localeId: "Route",
        items: [
            { icon: icon("PathfindFailed"), localeId: "RoutePathfindNotification", countIndex: 60, binding: RoutePathfindNotificationBinding$, onToggle: OnRoutePathfindNotificationBindingToggle },
            { icon: icon("NoPortAccess"), localeId: "RouteGateBypassNotification", countIndex: 61, binding: RouteGateBypassNotificationBinding$, onToggle: OnRouteGateBypassNotificationBindingToggle },
        ],
    },
    {
        localeId: "TransportLine",
        items: [
            { icon: icon("NoVehicles"), localeId: "TransportLineVehicleNotification", countIndex: 62, binding: TransportLineVehicleNotificationBinding$, onToggle: OnTransportLineVehicleNotificationBindingToggle },
        ],
    },
    // Appended LAST (not inserted alphabetically) so every existing section keeps its bit position in
    // PanelCollapsedSectionsMask — inserting this earlier in the array would shift every later
    // section's saved collapse-state bit and silently scramble players' existing settings.
    {
        localeId: "Other",
        items: [
            { icon: icon("LevelingBuilding"), localeId: "BuildingLevelingNotification", countIndex: 24, binding: BuildingLevelingNotificationBinding$, onToggle: OnBuildingLevelingNotificationBindingToggle, optional: true },
        ],
    },
];

export const allItems = sections.flatMap((section) => section.items);
export const allIconSources = Array.from(new Set(allItems.map((item) => item.icon)));
export const notificationCountIndexes = new Map(
    allItems.map((item) => [item.localeId, item.countIndex]),
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

// Persisted expand/collapse: one bit per section by its index in `sections` (bit set = collapsed).
// 0 = all expanded. Section order must stay stable for saved masks to keep their meaning.
export const expandedSectionsFromMask = (mask: number): Record<string, boolean> => {
    const result: Record<string, boolean> = {};
    sections.forEach((section, index) => {
        result[section.localeId] = ((mask >> index) & 1) === 0;
    });
    return result;
};

export const collapsedSectionsMask = (expanded: Record<string, boolean>): number => {
    let mask = 0;
    sections.forEach((section, index) => {
        if (expanded[section.localeId] === false) {
            mask |= 1 << index;
        }
    });
    return mask;
};
