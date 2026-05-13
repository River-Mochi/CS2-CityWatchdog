# File: src/Scripts/fix_remaining_log_calls.py
# Purpose: Replace remaining manual Logger.Info calls with LogUtils.Info wrappers.

from __future__ import annotations

from pathlib import Path


def find_repo_root() -> Path:
    cwd = Path.cwd().resolve()
    if cwd.name.lower() == "src":
        return cwd.parent

    if (cwd / "src").is_dir():
        return cwd

    raise RuntimeError("Run from the CityWatchdog repo root or from the src folder.")


def replace_exact(path: Path, replacements: dict[str, str]) -> bool:
    text = path.read_text(encoding="utf-8-sig")
    original = text

    for old, new in replacements.items():
        if old not in text:
            print(f"MISS: {path} did not contain expected text:")
            print(old)
            print()
            continue

        text = text.replace(old, new)

    if text != original:
        backup = path.with_name(path.name + ".remaining-logwrap.bak")
        if not backup.exists():
            backup.write_text(original, encoding="utf-8")

        path.write_text(text, encoding="utf-8")
        print(f"UPDATED: {path}")
        return True

    print(f"NO CHANGE: {path}")
    return False


def main() -> int:
    repo = find_repo_root()
    src = repo / "src"

    achievement_file = src / "Systems" / "AchievementsEnablerSystem.cs"
    money_file = src / "Systems" / "MoneyControllerSystem.cs"
    notification_file = src / "Systems" / "NotificationControllerSystem.cs"

    achievement_replacements = {
        'Logger.Info($"AchievementsControllerSystem OnGamePreload, game mode: {mode}, game/mod achievements status: {PlatformManager.instance.achievementsEnabled} {Setting.Instance.AchievementsEnabled} ");':
        'LogUtils.Info(Mod.s_Log, () => $"AchievementsControllerSystem OnGamePreload, game mode: {mode}, game/mod achievements status: {PlatformManager.instance.achievementsEnabled} {Setting.Instance.AchievementsEnabled} ");',

        'Logger.Info($"AchievementsControllerSystem OnGameLoaded, game/mod achievements status: {PlatformManager.instance.achievementsEnabled} {Setting.Instance.AchievementsEnabled} ");':
        'LogUtils.Info(Mod.s_Log, () => $"AchievementsControllerSystem OnGameLoaded, game/mod achievements status: {PlatformManager.instance.achievementsEnabled} {Setting.Instance.AchievementsEnabled} ");',
    }

    money_replacements = {
        'Logger.Info($"Starting set unlimited money to limited money to limited money, PlayerMoney.m_Unlimited: {EntityManager.GetComponentData<PlayerMoney>(citySystem.City).m_Unlimited}, PlayerMoney.money: {EntityManager.GetComponentData<PlayerMoney>(citySystem.City).money}, CityConfigurationSystem.unlimitedMoney: {cityConfigurationSystem.unlimitedMoney}, CityConfigurationSystem.overrideUnlimitedMoney: {cityConfigurationSystem.overrideUnlimitedMoney}");':
        'LogUtils.Info(Mod.s_Log, () => $"Starting set unlimited money to limited money to limited money, PlayerMoney.m_Unlimited: {EntityManager.GetComponentData<PlayerMoney>(citySystem.City).m_Unlimited}, PlayerMoney.money: {EntityManager.GetComponentData<PlayerMoney>(citySystem.City).money}, CityConfigurationSystem.unlimitedMoney: {cityConfigurationSystem.unlimitedMoney}, CityConfigurationSystem.overrideUnlimitedMoney: {cityConfigurationSystem.overrideUnlimitedMoney}");',

        'Logger.Info($"Set unlimited money to limited money to limited money completed, PlayerMoney.m_Unlimited: {componentData.m_Unlimited}, PlayerMoney.money: {componentData.money}, CityConfigurationSystem.unlimitedMoney: {cityConfigurationSystem.unlimitedMoney}, CityConfigurationSystem.overrideUnlimitedMoney: {cityConfigurationSystem.overrideUnlimitedMoney}");':
        'LogUtils.Info(Mod.s_Log, () => $"Set unlimited money to limited money to limited money completed, PlayerMoney.m_Unlimited: {componentData.m_Unlimited}, PlayerMoney.money: {componentData.money}, CityConfigurationSystem.unlimitedMoney: {cityConfigurationSystem.unlimitedMoney}, CityConfigurationSystem.overrideUnlimitedMoney: {cityConfigurationSystem.overrideUnlimitedMoney}");',

        'Logger.Info($"Setting initial money, default money: {raw}");':
        'LogUtils.Info(Mod.s_Log, () => $"Setting initial money, default money: {raw}");',

        'Logger.Info($"Set initial money completed, money: {componentData.money}");':
        'LogUtils.Info(Mod.s_Log, () => $"Set initial money completed, money: {componentData.money}");',

        'Logger.Info($"{componentData.money} < {Setting.Instance.AutomaticAddMoneyThreshold}, automatically add money");':
        'LogUtils.Info(Mod.s_Log, () => $"{componentData.money} < {Setting.Instance.AutomaticAddMoneyThreshold}, automatically add money");',
    }

    notification_replacements = {
        '}.ForEach(action => Logger.Info(action()));':
        '}.ForEach(action => LogUtils.Info(Mod.s_Log, action));',
    }

    changed = False
    changed |= replace_exact(achievement_file, achievement_replacements)
    changed |= replace_exact(money_file, money_replacements)
    changed |= replace_exact(notification_file, notification_replacements)

    print()
    if changed:
        print("Done. Build next:")
        print("  dotnet build src/CityWatchdog.csproj")
    else:
        print("No replacements were applied. Check whether the lines were already edited.")

    return 0


if __name__ == "__main__":
    raise SystemExit(main())
