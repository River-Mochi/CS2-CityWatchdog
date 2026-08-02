// <copyright file="CityFinanceSystem.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the MIT License. You may not use this file except in compliance with this License.
// See LICENSE file in the project root for full license information.
// This notice and the MIT License notice must be kept with
// all copies or substantial portions of this code.
// ================= </copyright> ======================

// File: Systems/CityFinanceSystem.cs
// Purpose: Handles City Watchdog money actions, initial money, and automatic money support.

namespace CityWatchdog.Systems
{
    using System;
    using System.Reflection;
    using Colossal.Serialization.Entities;
    using CS2Shared.RiverMochi;
    using Game;
    using Game.City;
    using Game.Input;
    using Game.SceneFlow;
    using Game.Simulation;
    using Unity.Entities;

    public partial class CityFinanceSystem : GameSystemBaseExtension
    {
        // Counts this system's OnUpdate passes. Higher = automatic money checks less often.
        private const int AutomaticMoneyCheckIntervalUpdates = 128;
        // Hold-to-repeat delay for [ and ]. Higher = easier single-taps before repeat begins.
        private const int ManualMoneyRepeatInitialDelayUpdates = 20;
        // Hold-to-repeat speed for [ and ] after the delay. Lower = faster repeated money changes.
        private const int ManualMoneyRepeatIntervalUpdates = 9;

        private CitySystem m_CitySystem = null!;
        private CityConfigurationSystem m_CityConfigurationSystem = null!;
        private ProxyAction? m_AddMoneyAction;
        private ProxyAction? m_SubtractMoneyAction;
        private int m_AutomaticMoneyCheckCooldown;
        private int m_AddMoneyRepeatCooldown;
        private int m_SubtractMoneyRepeatCooldown;

        public enum FinanceActionKind
        {
            AutoAdd,
            ManualAdd,
            AutoSubtract,
            ManualSubtract,
            None
        }

        public void SetUnlimitedMoneyToLimitedMoney()
        {
            if (!CanConvertUnlimitedMoneySave() ||
                !TryGetPlayerMoney(out PlayerMoney beforeMoney))
            {
                return;
            }

            LogUtils.Info(() =>
                "Starting set unlimited money to limited money.\n" +
                $"PlayerMoney.m_Unlimited: {beforeMoney.m_Unlimited}\n" +
                $"PlayerMoney.money: {beforeMoney.money}\n" +
                $"CityConfigurationSystem.unlimitedMoney: {m_CityConfigurationSystem.unlimitedMoney}\n" +
                $"CityConfigurationSystem.overrideUnlimitedMoney: {m_CityConfigurationSystem.overrideUnlimitedMoney}");

            ApplyLimitedMoneyMode();
            ClearLoadedUnlimitedMoneyFlag();

            if (!TryGetPlayerMoney(out PlayerMoney afterMoney))
            {
                return;
            }

            LogUtils.Info(() =>
                "Set unlimited money to limited money completed.\n" +
                $"PlayerMoney.m_Unlimited: {afterMoney.m_Unlimited}\n" +
                $"PlayerMoney.money: {afterMoney.money}\n" +
                $"CityConfigurationSystem.unlimitedMoney: {m_CityConfigurationSystem.unlimitedMoney}\n" +
                $"CityConfigurationSystem.overrideUnlimitedMoney: {m_CityConfigurationSystem.overrideUnlimitedMoney}");
        }

        private void ApplyLimitedMoneyMode()
        {
            m_CityConfigurationSystem.unlimitedMoney = false;
            m_CityConfigurationSystem.overrideUnlimitedMoney = false;

            if (TryGetPlayerMoney(out PlayerMoney playerMoney))
            {
                playerMoney.m_Unlimited = false;
                EntityManager.SetComponentData(m_CitySystem.City, playerMoney);
            }
        }

        private void ClearLoadedUnlimitedMoneyFlag()
        {
            FieldInfo? loadedUnlimitedMoneyField = typeof(CityConfigurationSystem).GetField(
                "m_LoadedUnlimitedMoney",
                BindingFlags.NonPublic | BindingFlags.Instance);
            if (loadedUnlimitedMoneyField == null)
            {
                return;
            }

            loadedUnlimitedMoneyField.SetValue(m_CityConfigurationSystem, false);
        }

        public bool CanConvertUnlimitedMoneySave()
        {
            if (GameManager.instance == null ||
                GameManager.instance.gameMode != GameMode.Game ||
                m_CitySystem == null ||
                m_CityConfigurationSystem == null)
            {
                return false;
            }

            if (!TryGetPlayerMoney(out PlayerMoney playerMoney))
            {
                return false;
            }

            return playerMoney.m_Unlimited ||
                   m_CityConfigurationSystem.unlimitedMoney ||
                   m_CityConfigurationSystem.overrideUnlimitedMoney;
        }

        public void OnSubtractMoney()
        {
            ApplyMoneyChange(FinanceActionKind.ManualSubtract, CwdSettings.Instance.ManualMoneyAmount);
        }

        public void OnAddMoney()
        {
            ApplyMoneyChange(FinanceActionKind.ManualAdd, CwdSettings.Instance.ManualMoneyAmount);
        }

        protected override void OnCreate()
        {
            base.OnCreate();

            m_CitySystem = World.GetOrCreateSystemManaged<CitySystem>();
            m_CityConfigurationSystem = World.GetOrCreateSystemManaged<CityConfigurationSystem>();
            m_AutomaticMoneyCheckCooldown = 0;
            ResetManualMoneyRepeat();

            m_AddMoneyAction = TryGetAction(CwdSettings.AddMoneyAction);
            if (m_AddMoneyAction != null)
            {
                m_AddMoneyAction.shouldBeEnabled = true;
            }

            m_SubtractMoneyAction = TryGetAction(CwdSettings.SubtractMoneyAction);
            if (m_SubtractMoneyAction != null)
            {
                m_SubtractMoneyAction.shouldBeEnabled = true;
            }
        }

        protected override void OnGameLoaded(Context serializationContext)
        {
            base.OnGameLoaded(serializationContext);

            m_AutomaticMoneyCheckCooldown = 0;

            if ((serializationContext.purpose == Purpose.NewGame || serializationContext.purpose == Purpose.LoadGame) &&
                CwdSettings.Instance.InitialMoney != 0)
            {
                if (!TryGetPlayerMoney(out PlayerMoney playerMoney))
                {
                    return;
                }

                if (!playerMoney.m_Unlimited)
                {
                    ApplyMoneyChange(FinanceActionKind.AutoSubtract, playerMoney.money);
                    ApplyMoneyChange(FinanceActionKind.AutoAdd, CwdSettings.Instance.InitialMoney);
                    CwdSettings.Instance.ResetInitialMoney();
                }
            }
        }

        protected override void OnUpdate()
        {
            if (!InGame)
            {
                m_AutomaticMoneyCheckCooldown = 0;
                ResetManualMoneyRepeat();
                return;
            }

            UpdateAutomaticAddMoney();
            UpdateManualMoneyHotkeys();
        }

        private void UpdateManualMoneyHotkeys()
        {
            UpdateManualMoneyHotkey(m_AddMoneyAction, FinanceActionKind.ManualAdd, ref m_AddMoneyRepeatCooldown);
            UpdateManualMoneyHotkey(m_SubtractMoneyAction, FinanceActionKind.ManualSubtract, ref m_SubtractMoneyRepeatCooldown);
        }

        private void UpdateManualMoneyHotkey(ProxyAction? action, FinanceActionKind financeActionKind, ref int repeatCooldown)
        {
            if (action == null)
            {
                repeatCooldown = 0;
                return;
            }

            // First press always applies once; held keys repeat only after the delay above.
            if (action.WasPressedThisFrame())
            {
                ApplyMoneyChange(financeActionKind, CwdSettings.Instance.ManualMoneyAmount);
                repeatCooldown = ManualMoneyRepeatInitialDelayUpdates;
                return;
            }

            if (!action.IsPressed())
            {
                repeatCooldown = 0;
                return;
            }

            if (repeatCooldown > 0)
            {
                repeatCooldown--;
                return;
            }

            ApplyMoneyChange(financeActionKind, CwdSettings.Instance.ManualMoneyAmount);
            repeatCooldown = ManualMoneyRepeatIntervalUpdates;
        }

        private void ResetManualMoneyRepeat()
        {
            m_AddMoneyRepeatCooldown = 0;
            m_SubtractMoneyRepeatCooldown = 0;
        }

        private void UpdateAutomaticAddMoney()
        {
            if (!CwdSettings.Instance.AutomaticAddMoney)
            {
                m_AutomaticMoneyCheckCooldown = 0;
                return;
            }

            if (m_AutomaticMoneyCheckCooldown > 0)
            {
                m_AutomaticMoneyCheckCooldown--;
                return;
            }

            m_AutomaticMoneyCheckCooldown = AutomaticMoneyCheckIntervalUpdates;
            TryAutomaticAddMoney();
        }

        private void TryAutomaticAddMoney()
        {
            if (!TryGetPlayerMoney(out PlayerMoney playerMoney))
            {
                return;
            }

            if (playerMoney.m_Unlimited)
            {
                return;
            }

            int threshold = CwdSettings.Instance.AutomaticAddMoneyThreshold;
            if (playerMoney.money >= threshold)
            {
                return;
            }

            int amount = GetAutomaticAddMoneyAmount(
                playerMoney.money,
                threshold,
                CwdSettings.Instance.AutomaticAddMoneyAmount);

            if (amount <= 0)
            {
                return;
            }

            ApplyMoneyChange(FinanceActionKind.AutoAdd, amount);
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

        private static ProxyAction? TryGetAction(string actionName)
        {
            try
            {
                return CwdSettings.Instance.GetAction(actionName);
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

        private bool TryGetPlayerMoney(out PlayerMoney playerMoney)
        {
            playerMoney = default;

            if (m_CitySystem == null)
            {
                return false;
            }

            Entity city = m_CitySystem.City;
            if (city == Entity.Null ||
                !EntityManager.Exists(city) ||
                !EntityManager.HasComponent<PlayerMoney>(city))
            {
                return false;
            }

            playerMoney = EntityManager.GetComponentData<PlayerMoney>(city);
            return true;
        }

        private void ApplyMoneyChange(FinanceActionKind financeActionKind, int money)
        {
            if (GameManager.instance.gameMode != GameMode.Game ||
                financeActionKind == FinanceActionKind.None ||
                !TryGetPlayerMoney(out PlayerMoney playerMoney))
            {
                return;
            }

            if (financeActionKind == FinanceActionKind.AutoAdd || financeActionKind == FinanceActionKind.ManualAdd)
            {
                playerMoney.Add(money);
            }
            else if (financeActionKind == FinanceActionKind.AutoSubtract || financeActionKind == FinanceActionKind.ManualSubtract)
            {
                playerMoney.Subtract(money);
            }

            EntityManager.SetComponentData(m_CitySystem.City, playerMoney);
        }
    }
}
