// File: src/Systems/MoneyControllerSystem.cs
// Purpose: Handles City Watchdog money actions, initial money, and automatic money support.

namespace CityWatchdog.Systems
{
    using Colossal.Serialization.Entities;
    using Game;
    using Game.City;
    using Game.Input;
    using Game.SceneFlow;
    using Game.Simulation;
    using System;
    using System.Reflection;
    using System.Text;
    using Unity.Entities;

    public partial class MoneyControllerSystem : GameSystemBaseExtension
    {
        private const int AutomaticMoneyCheckIntervalUpdates = 128;

        private CitySystem citySystem = null!;
        private CityConfigurationSystem cityConfigurationSystem = null!;
        private ProxyAction? addMoneyAction;
        private ProxyAction? subtractMoneyAction;
        private int automaticMoneyCheckCooldown;

        public enum ModifyMoneyType
        {
            AutoAdd,
            ManualAdd,
            AutoSubtract,
            ManualSubtract,
            None
        }

        public void ExportCurrentCityConfigurationInformation()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("---Current City Configuration Information---");
            stringBuilder.AppendLine($"{nameof(cityConfigurationSystem.cityName)}: {cityConfigurationSystem.cityName}");
            stringBuilder.AppendLine($"{nameof(cityConfigurationSystem.overrideCityName)}: {cityConfigurationSystem.overrideCityName}");
            stringBuilder.AppendLine($"{nameof(cityConfigurationSystem.leftHandTraffic)}: {cityConfigurationSystem.leftHandTraffic}");
            stringBuilder.AppendLine($"{nameof(cityConfigurationSystem.overrideLeftHandTraffic)}: {cityConfigurationSystem.overrideLeftHandTraffic}");
            stringBuilder.AppendLine($"{nameof(cityConfigurationSystem.naturalDisasters)}: {cityConfigurationSystem.naturalDisasters}");
            stringBuilder.AppendLine($"{nameof(cityConfigurationSystem.overrideNaturalDisasters)}: {cityConfigurationSystem.overrideNaturalDisasters}");
            stringBuilder.AppendLine($"{nameof(cityConfigurationSystem.unlockAll)}: {cityConfigurationSystem.unlockAll}");
            stringBuilder.AppendLine($"{nameof(cityConfigurationSystem.overrideUnlockAll)}: {cityConfigurationSystem.overrideUnlockAll}");
            stringBuilder.AppendLine($"{nameof(cityConfigurationSystem.unlimitedMoney)}: {cityConfigurationSystem.unlimitedMoney}");
            stringBuilder.AppendLine($"{nameof(cityConfigurationSystem.overrideUnlimitedMoney)}: {cityConfigurationSystem.overrideUnlimitedMoney}");
            stringBuilder.AppendLine($"{nameof(cityConfigurationSystem.unlockMapTiles)}: {cityConfigurationSystem.unlockMapTiles}");
            stringBuilder.AppendLine($"{nameof(cityConfigurationSystem.overrideUnlockMapTiles)}: {cityConfigurationSystem.overrideUnlockMapTiles}");
            stringBuilder.AppendLine($"{nameof(cityConfigurationSystem.overrideLoadedOptions)}: {cityConfigurationSystem.overrideLoadedOptions}");
            stringBuilder.AppendLine(string.Join(", ", cityConfigurationSystem.usedMods));
            stringBuilder.AppendLine("---End Current City Configuration Information---");

            CityWatchdog.Mod.DebugLog(() => stringBuilder.ToString());
        }

        public void SetUnlimitedMoneyToLimitedMoney()
        {
            if (!CanConvertUnlimitedMoneySave())
            {
                return;
            }

            PlayerMoney beforeMoney = EntityManager.GetComponentData<PlayerMoney>(citySystem.City);
            LogUtils.Info(() => $"Starting set unlimited money to limited money, PlayerMoney.m_Unlimited: {beforeMoney.m_Unlimited}, PlayerMoney.money: {beforeMoney.money}, CityConfigurationSystem.unlimitedMoney: {cityConfigurationSystem.unlimitedMoney}, CityConfigurationSystem.overrideUnlimitedMoney: {cityConfigurationSystem.overrideUnlimitedMoney}");

            cityConfigurationSystem.unlimitedMoney = false;
            cityConfigurationSystem.overrideUnlimitedMoney = false;

            PlayerMoney playerMoney = EntityManager.GetComponentData<PlayerMoney>(citySystem.City);
            playerMoney.m_Unlimited = false;
            EntityManager.SetComponentData(citySystem.City, playerMoney);

            FieldInfo? loadedUnlimitedMoneyField = typeof(CityConfigurationSystem).GetField("m_LoadedUnlimitedMoney", BindingFlags.NonPublic | BindingFlags.Instance);
            if (loadedUnlimitedMoneyField == null)
            {
                CityWatchdog.Mod.DebugLog(() => "m_LoadedUnlimitedMoney is null");
            }
            else
            {
                loadedUnlimitedMoneyField.SetValue(cityConfigurationSystem, false);
            }

            LogUtils.Info(() => $"Set unlimited money to limited money completed, PlayerMoney.m_Unlimited: {playerMoney.m_Unlimited}, PlayerMoney.money: {playerMoney.money}, CityConfigurationSystem.unlimitedMoney: {cityConfigurationSystem.unlimitedMoney}, CityConfigurationSystem.overrideUnlimitedMoney: {cityConfigurationSystem.overrideUnlimitedMoney}");
        }

        public bool CanConvertUnlimitedMoneySave()
        {
            if (GameManager.instance == null ||
                GameManager.instance.gameMode != GameMode.Game ||
                citySystem == null ||
                cityConfigurationSystem == null)
            {
                return false;
            }

            Entity city = citySystem.City;
            if (city == Entity.Null ||
                !EntityManager.Exists(city) ||
                !EntityManager.HasComponent<PlayerMoney>(city))
            {
                return false;
            }

            PlayerMoney playerMoney = EntityManager.GetComponentData<PlayerMoney>(city);
            return playerMoney.m_Unlimited ||
                   cityConfigurationSystem.unlimitedMoney ||
                   cityConfigurationSystem.overrideUnlimitedMoney;
        }

        public void OnSubtractMoney()
        {
            ModifyMoney(ModifyMoneyType.ManualSubtract, Setting.Instance.ManualMoneyAmount);
        }

        public void OnAddMoney()
        {
            ModifyMoney(ModifyMoneyType.ManualAdd, Setting.Instance.ManualMoneyAmount);
        }

        protected override void OnCreate()
        {
            base.OnCreate();

            citySystem = World.GetOrCreateSystemManaged<CitySystem>();
            cityConfigurationSystem = World.GetOrCreateSystemManaged<CityConfigurationSystem>();
            automaticMoneyCheckCooldown = 0;

            addMoneyAction = TryGetAction(Setting.AddMoneyAction);
            if (addMoneyAction != null)
            {
                addMoneyAction.shouldBeEnabled = true;
            }

            subtractMoneyAction = TryGetAction(Setting.SubtractMoneyAction);
            if (subtractMoneyAction != null)
            {
                subtractMoneyAction.shouldBeEnabled = true;
            }
        }

        protected override void OnGameLoaded(Context serializationContext)
        {
            base.OnGameLoaded(serializationContext);

            automaticMoneyCheckCooldown = 0;

            if ((serializationContext.purpose == Purpose.NewGame || serializationContext.purpose == Purpose.LoadGame) &&
                Setting.Instance.InitialMoney != 0)
            {
                PlayerMoney playerMoney = EntityManager.GetComponentData<PlayerMoney>(citySystem.City);
                if (!playerMoney.m_Unlimited)
                {
                    int rawMoney = playerMoney.money;
                    CityWatchdog.Mod.DebugLog(() => $"Setting initial money, default money: {rawMoney}");

                    ModifyMoney(ModifyMoneyType.AutoSubtract, rawMoney);
                    ModifyMoney(ModifyMoneyType.AutoAdd, Setting.Instance.InitialMoney);
                    Setting.Instance.ResetInitialMoney();

                    PlayerMoney updatedMoney = EntityManager.GetComponentData<PlayerMoney>(citySystem.City);
                    CityWatchdog.Mod.DebugLog(() => $"Set initial money completed, money: {updatedMoney.money}");
                }
            }
        }

        protected override void OnUpdate()
        {
            if (!InGame)
            {
                automaticMoneyCheckCooldown = 0;
                return;
            }

            UpdateAutomaticAddMoney();

            if (addMoneyAction != null && addMoneyAction.WasPerformedThisFrame())
            {
                OnAddMoney();
            }

            if (subtractMoneyAction != null && subtractMoneyAction.WasPerformedThisFrame())
            {
                OnSubtractMoney();
            }
        }

        private void UpdateAutomaticAddMoney()
        {
            if (!Setting.Instance.AutomaticAddMoney)
            {
                automaticMoneyCheckCooldown = 0;
                return;
            }

            if (automaticMoneyCheckCooldown > 0)
            {
                automaticMoneyCheckCooldown--;
                return;
            }

            automaticMoneyCheckCooldown = AutomaticMoneyCheckIntervalUpdates;
            TryAutomaticAddMoney();
        }

        private void TryAutomaticAddMoney()
        {
            Entity city = citySystem.City;
            if (city == Entity.Null ||
                !EntityManager.Exists(city) ||
                !EntityManager.HasComponent<PlayerMoney>(city))
            {
                return;
            }

            PlayerMoney playerMoney = EntityManager.GetComponentData<PlayerMoney>(city);
            if (playerMoney.m_Unlimited)
            {
                return;
            }

            int threshold = Setting.Instance.AutomaticAddMoneyThreshold;
            if (playerMoney.money >= threshold)
            {
                return;
            }

            int amount = GetAutomaticAddMoneyAmount(
                playerMoney.money,
                threshold,
                Setting.Instance.AutomaticAddMoneyAmount);

            if (amount <= 0)
            {
                return;
            }

            CityWatchdog.Mod.DebugLog(() => $"AutoAdd money: balance {playerMoney.money:N0} below threshold {threshold:N0}; adding {amount:N0}.");
            ModifyMoney(ModifyMoneyType.AutoAdd, amount);
        }

        private static int GetAutomaticAddMoneyAmount(int currentMoney, int threshold, int selectedAmount)
        {
            long deficit = (long)threshold - currentMoney;
            long requestedAmount = Math.Max(0, selectedAmount);
            long amount = Math.Max(deficit, requestedAmount);

            if (amount <= 0)
            {
                return 0;
            }

            if (amount > int.MaxValue)
            {
                return int.MaxValue;
            }

            return (int)amount;
        }

        private ProxyAction? TryGetAction(string actionName)
        {
            try
            {
                return Setting.Instance.GetAction(actionName);
            }
            catch (System.Exception ex)
            {
                LogUtils.WarnOnce(
                    "missing-keybind-" + actionName,
                    () => $"Keybinding action '{actionName}' is unavailable: {ex.GetType().Name}: {ex.Message}",
                    ex);
                return null;
            }
        }

        private void ModifyMoney(ModifyMoneyType modifyMoneyType, int money)
        {
            if (GameManager.instance.gameMode != GameMode.Game ||
                citySystem == null ||
                modifyMoneyType == ModifyMoneyType.None)
            {
                return;
            }

            PlayerMoney playerMoney = EntityManager.GetComponentData<PlayerMoney>(citySystem.City);
            if (modifyMoneyType == ModifyMoneyType.AutoAdd || modifyMoneyType == ModifyMoneyType.ManualAdd)
            {
                playerMoney.Add(money);
            }
            else if (modifyMoneyType == ModifyMoneyType.AutoSubtract || modifyMoneyType == ModifyMoneyType.ManualSubtract)
            {
                playerMoney.Subtract(money);
            }

            CityWatchdog.Mod.DebugLog(() => $"{modifyMoneyType} money {money} to {playerMoney.money} ");
            EntityManager.SetComponentData(citySystem.City, playerMoney);
        }
    }
}
