# File: src/Scripts/fix_ui_and_notification_nullability.py
# Purpose: Adds C# 9-safe null-forgiving initializers to CS2 system fields initialized during OnCreate.

from __future__ import annotations

from pathlib import Path


REPLACEMENTS_BY_FILE = {
    "src/Systems/CityWatchdogUISystem.cs": {
        "private NotificationControllerSystem notificationControllerSystem;":
            "private NotificationControllerSystem notificationControllerSystem = null!;",
        "private BoolBinding panelVisibleBinding;":
            "private BoolBinding panelVisibleBinding = null!;",
        "private BoolBinding electricityElectricityNotificationBinding;":
            "private BoolBinding electricityElectricityNotificationBinding = null!;",
        "private BoolBinding electricityBottleneckNotificationBinding;":
            "private BoolBinding electricityBottleneckNotificationBinding = null!;",
        "private BoolBinding electricityBuildingBottleneckNotificationBinding;":
            "private BoolBinding electricityBuildingBottleneckNotificationBinding = null!;",
        "private BoolBinding electricityNotEnoughProductionNotificationBinding;":
            "private BoolBinding electricityNotEnoughProductionNotificationBinding = null!;",
        "private BoolBinding electricityTransformerNotificationBinding;":
            "private BoolBinding electricityTransformerNotificationBinding = null!;",
        "private BoolBinding electricityNotEnoughConnectedNotificationBinding;":
            "private BoolBinding electricityNotEnoughConnectedNotificationBinding = null!;",
        "private BoolBinding electricityBatteryEmptyNotificationBinding;":
            "private BoolBinding electricityBatteryEmptyNotificationBinding = null!;",
        "private BoolBinding electricityLowVoltageNotConnectedBinding;":
            "private BoolBinding electricityLowVoltageNotConnectedBinding = null!;",
        "private BoolBinding electricityHighVoltageNotConnectedBinding;":
            "private BoolBinding electricityHighVoltageNotConnectedBinding = null!;",
        "private BoolBinding waterPipeWaterNotificationBinding;":
            "private BoolBinding waterPipeWaterNotificationBinding = null!;",
        "private BoolBinding waterPipeDirtyWaterNotificationBinding;":
            "private BoolBinding waterPipeDirtyWaterNotificationBinding = null!;",
        "private BoolBinding waterPipeSewageNotificationBinding;":
            "private BoolBinding waterPipeSewageNotificationBinding = null!;",
        "private BoolBinding waterPipeWaterPipeNotConnectedNotificationBinding;":
            "private BoolBinding waterPipeWaterPipeNotConnectedNotificationBinding = null!;",
        "private BoolBinding waterPipeSewagePipeNotConnectedNotificationBinding;":
            "private BoolBinding waterPipeSewagePipeNotConnectedNotificationBinding = null!;",
        "private BoolBinding waterPipeNotEnoughWaterCapacityNotificationBinding;":
            "private BoolBinding waterPipeNotEnoughWaterCapacityNotificationBinding = null!;",
        "private BoolBinding waterPipeNotEnoughSewageCapacityNotificationBinding;":
            "private BoolBinding waterPipeNotEnoughSewageCapacityNotificationBinding = null!;",
        "private BoolBinding waterPipeNotEnoughGroundwaterNotificationBinding;":
            "private BoolBinding waterPipeNotEnoughGroundwaterNotificationBinding = null!;",
        "private BoolBinding waterPipeNotEnoughSurfaceWaterNotificationBinding;":
            "private BoolBinding waterPipeNotEnoughSurfaceWaterNotificationBinding = null!;",
        "private BoolBinding waterPipeDirtyWaterPumpNotificationBinding;":
            "private BoolBinding waterPipeDirtyWaterPumpNotificationBinding = null!;",
        "private BoolBinding buildingAbandonedCollapsedNotificationBinding;":
            "private BoolBinding buildingAbandonedCollapsedNotificationBinding = null!;",
        "private BoolBinding buildingAbandonedNotificationBinding;":
            "private BoolBinding buildingAbandonedNotificationBinding = null!;",
        "private BoolBinding buildingCondemnedNotificationBinding;":
            "private BoolBinding buildingCondemnedNotificationBinding = null!;",
        "private BoolBinding buildingTurnedOffNotificationBinding;":
            "private BoolBinding buildingTurnedOffNotificationBinding = null!;",
        "private BoolBinding buildingHighRentNotificationBinding;":
            "private BoolBinding buildingHighRentNotificationBinding = null!;",
        "private BoolBinding trafficBottleneckNotificationBinding;":
            "private BoolBinding trafficBottleneckNotificationBinding = null!;",
        "private BoolBinding trafficDeadEndNotificationBinding;":
            "private BoolBinding trafficDeadEndNotificationBinding = null!;",
        "private BoolBinding trafficRoadConnectionNotificationBinding;":
            "private BoolBinding trafficRoadConnectionNotificationBinding = null!;",
        "private BoolBinding trafficTrackConnectionNotificationBinding;":
            "private BoolBinding trafficTrackConnectionNotificationBinding = null!;",
        "private BoolBinding trafficCarConnectionNotificationBinding;":
            "private BoolBinding trafficCarConnectionNotificationBinding = null!;",
        "private BoolBinding trafficShipConnectionNotificationBinding;":
            "private BoolBinding trafficShipConnectionNotificationBinding = null!;",
        "private BoolBinding trafficTrainConnectionNotificationBinding;":
            "private BoolBinding trafficTrainConnectionNotificationBinding = null!;",
        "private BoolBinding trafficPedestrianConnectionNotificationBinding;":
            "private BoolBinding trafficPedestrianConnectionNotificationBinding = null!;",
        "private BoolBinding companyNoInputsNotificationBinding;":
            "private BoolBinding companyNoInputsNotificationBinding = null!;",
        "private BoolBinding companyNoCustomersNotificationBinding;":
            "private BoolBinding companyNoCustomersNotificationBinding = null!;",
        "private BoolBinding workProviderUneducatedNotificationBinding;":
            "private BoolBinding workProviderUneducatedNotificationBinding = null!;",
        "private BoolBinding workProviderEducatedNotificationBinding;":
            "private BoolBinding workProviderEducatedNotificationBinding = null!;",
        "private BoolBinding disasterWeatherDamageNotificationBinding;":
            "private BoolBinding disasterWeatherDamageNotificationBinding = null!;",
        "private BoolBinding disasterWeatherDestroyedNotificationBinding;":
            "private BoolBinding disasterWeatherDestroyedNotificationBinding = null!;",
        "private BoolBinding disasterWaterDamageNotificationBinding;":
            "private BoolBinding disasterWaterDamageNotificationBinding = null!;",
        "private BoolBinding disasterWaterDestroyedNotificationBinding;":
            "private BoolBinding disasterWaterDestroyedNotificationBinding = null!;",
        "private BoolBinding disasterDestroyedNotificationBinding;":
            "private BoolBinding disasterDestroyedNotificationBinding = null!;",
        "private BoolBinding fireFireNotificationBinding;":
            "private BoolBinding fireFireNotificationBinding = null!;",
        "private BoolBinding fireBurnedDownNotificationBinding;":
            "private BoolBinding fireBurnedDownNotificationBinding = null!;",
        "private BoolBinding garbageGarbageNotificationBinding;":
            "private BoolBinding garbageGarbageNotificationBinding = null!;",
        "private BoolBinding garbageFacilityFullNotificationBinding;":
            "private BoolBinding garbageFacilityFullNotificationBinding = null!;",
        "private BoolBinding healthcareAmbulanceNotificationBinding;":
            "private BoolBinding healthcareAmbulanceNotificationBinding = null!;",
        "private BoolBinding healthcareHearseNotificationBinding;":
            "private BoolBinding healthcareHearseNotificationBinding = null!;",
        "private BoolBinding healthcareFacilityFullNotificationBinding;":
            "private BoolBinding healthcareFacilityFullNotificationBinding = null!;",
        "private BoolBinding policeTrafficAccidentNotificationBinding;":
            "private BoolBinding policeTrafficAccidentNotificationBinding = null!;",
        "private BoolBinding policeCrimeSceneNotificationBinding;":
            "private BoolBinding policeCrimeSceneNotificationBinding = null!;",
        "private BoolBinding pollutionAirPollutionNotificationBinding;":
            "private BoolBinding pollutionAirPollutionNotificationBinding = null!;",
        "private BoolBinding pollutionNoisePollutionNotificationBinding;":
            "private BoolBinding pollutionNoisePollutionNotificationBinding = null!;",
        "private BoolBinding pollutionGroundPollutionNotificationBinding;":
            "private BoolBinding pollutionGroundPollutionNotificationBinding = null!;",
        "private BoolBinding resourceConsumerNoResourceNotificationBinding;":
            "private BoolBinding resourceConsumerNoResourceNotificationBinding = null!;",
        "private BoolBinding routePathfindNotificationBinding;":
            "private BoolBinding routePathfindNotificationBinding = null!;",
        "private BoolBinding transportLineVehicleNotificationBinding;":
            "private BoolBinding transportLineVehicleNotificationBinding = null!;",
    },
    "src/Systems/NotificationControllerSystem.cs": {
        "private StringBuilder logBuilder;":
            "private StringBuilder logBuilder = null!;",
        "private PrefabSystem prefabSystem;":
            "private PrefabSystem prefabSystem = null!;",
    },
}


def find_repo_root() -> Path:
    cwd = Path.cwd().resolve()

    if (cwd / "src" / "Systems").is_dir():
        return cwd

    if cwd.name.lower() == "src" and (cwd / "Systems").is_dir():
        return cwd.parent

    raise RuntimeError("Run from the CityWatchdog repo root or from the src folder.")


def patch_file(repo: Path, relative_path: str, replacements: dict[str, str]) -> bool:
    path = repo / relative_path
    if not path.is_file():
        raise FileNotFoundError(relative_path)

    original = path.read_text(encoding="utf-8-sig")
    text = original

    for old, new in replacements.items():
        text = text.replace(old, new)

    if text == original:
        print(f"NO CHANGE: {relative_path}")
        return False

    backup = path.with_name(path.name + ".phase10-nullability.bak")
    if not backup.exists():
        backup.write_text(original, encoding="utf-8", newline="\r\n")

    path.write_text(text, encoding="utf-8", newline="\r\n")
    print(f"UPDATED: {relative_path}")
    print(f"Backup: {backup.relative_to(repo).as_posix()}")
    return True


def main() -> int:
    repo = find_repo_root()
    changed = False

    for relative_path, replacements in REPLACEMENTS_BY_FILE.items():
        changed = patch_file(repo, relative_path, replacements) or changed

    if not changed:
        print("No files changed.")
    else:
        print("Done.")
    return 0


if __name__ == "__main__":
    raise SystemExit(main())
