// <copyright file="InterfaceScaleControlSystem.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the MIT License. You may not use this file except in compliance with this License.
// See LICENSE file in the project root for full license information.
// This notice and the MIT License notice must be kept with
// all copies or substantial portions of this code.
// ================= </copyright> ======================

// File: Systems/InterfaceScaleControlSystem.cs
// Purpose: Panel button + Options slider that drive the vanilla (developer-gated) UI scaling without
//          requiring the --developerMode launch flag.
//
// Mechanism: GameManager.instance.settings.userInterface is the vanilla InterfaceSettings. Its
// interfaceScaling (bool) and textScale (float) are PUBLIC properties; the [SettingsUIDeveloper]
// attribute on interfaceScaling only HIDES it from the Options menu when dev mode is off — it does
// not stop code from setting it. The render pipeline (DebugCustomPass) applies scaling based on the
// interfaceScaling bool, so assigning it + ApplyAndSave() takes effect with or without dev mode.
// No Harmony, no reflection. (Same settings object TimeWeatherAnarchy reads for time/temperature.)

namespace CityWatchdog.Systems
{
    using CS2Shared.RiverMochi;
    using Game.SceneFlow;
    using Game.Settings;
    using System;

    public partial class InterfaceScaleControlSystem : UISystemBaseExtension
    {
        private const int kScaleMin = 100;
        private const int kScaleMax = 150;

        private BoolBinding interfaceScaleEnabledBinding = null!;

        protected override void OnCreate()
        {
            base.OnCreate();

            bool current = GetUI()?.interfaceScaling ?? false;
            interfaceScaleEnabledBinding = AddBoolBindingAndTriggerBinding(
                "InterfaceScaleEnabled",
                current,
                OnToggleInterfaceScale);
        }

        protected override void OnUpdate()
        {
            // Keep the panel button in sync if the player flips vanilla's own "Interface Scaling (dev)"
            // checkbox (only visible with dev mode). Reading one bool per UI tick is trivial.
            InterfaceSettings? ui = GetUI();
            if (ui != null && interfaceScaleEnabledBinding.Value != ui.interfaceScaling)
            {
                interfaceScaleEnabledBinding.Update(ui.interfaceScaling);
            }
        }

        private static InterfaceSettings? GetUI() => GameManager.instance?.settings?.userInterface;

        private void OnToggleInterfaceScale(bool enable)
        {
            InterfaceSettings? ui = GetUI();
            if (ui == null)
            {
                return;
            }

            ui.interfaceScaling = enable;

            // Only push our text-scale level when turning scaling ON. Turning it off restores the
            // unscaled UI but leaves the saved textScale value untouched.
            if (enable)
            {
                ui.textScale = Clamp(CwdSettings.Instance.InterfaceScaleLevel) / 100f;
            }

            Apply(ui);
            interfaceScaleEnabledBinding.Update(ui.interfaceScaling);
        }

        // Called from the CWD Options slider. Only re-applies while scaling is already enabled, so
        // dragging the slider with scaling off never forces the whole game UI to resize.
        public void ApplyLevelIfEnabled(int level)
        {
            InterfaceSettings? ui = GetUI();
            if (ui == null || !ui.interfaceScaling)
            {
                return;
            }

            ui.textScale = Clamp(level) / 100f;
            Apply(ui);
        }

        private static int Clamp(int value) => Math.Max(kScaleMin, Math.Min(kScaleMax, value));

        private static void Apply(InterfaceSettings ui)
        {
            try
            {
                ui.ApplyAndSave();
            }
            catch (Exception ex)
            {
                LogUtils.WarnOnce(
                    "interface-scale-apply",
                    () => $"Failed to apply interface scaling: {ex.GetType().Name}: {ex.Message}",
                    ex);
            }
        }
    }
}
