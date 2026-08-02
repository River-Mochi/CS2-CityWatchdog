// <copyright file="InterfaceScaleControlSystem.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the MIT License. You may not use this file except in compliance with this License.
// See LICENSE file in the project root for full license information.
// This notice and the MIT License notice must be kept with
// all copies or substantial portions of this code.
// ================= </copyright> ======================

// File: Systems/InterfaceScaleControlSystem.cs
// Purpose: Title-bar button that toggles the vanilla "Interface Scaling (dev)" flag without the
//          --developerMode launch flag. That single flag alone makes the whole game + mod UI bigger.
//
// Mechanism: GameManager.instance.settings.userInterface is the vanilla InterfaceSettings. Its
// interfaceScaling bool is a PUBLIC property; the [SettingsUIDeveloper] attribute only HIDES it from
// the Options menu unless dev mode is on — it does not stop code from setting it. Assigning it +
// ApplyAndSave() takes effect with or without dev mode. We deliberately do NOT touch textScale or
// toolbarScale: those are normal (non-dev) sliders players already have. No Harmony, no reflection.
//
// Sync is EVENT-driven via InterfaceSettings.onSettingsApplied (fires only when a setting changes),
// so there is no per-frame polling and no FPS cost between changes.

namespace CityWatchdog.Systems
{
    using CS2Shared.RiverMochi;
    using Game.SceneFlow;
    using Game.Settings;
    using System;

    public partial class InterfaceScaleControlSystem : UISystemBaseExtension
    {
        private BoolBinding interfaceScaleEnabledBinding = null!;
        private InterfaceSettings? subscribedUi;

        protected override void OnCreate()
        {
            base.OnCreate();

            interfaceScaleEnabledBinding = AddBoolBindingAndTriggerBinding(
                "InterfaceScaleEnabled",
                GetUI()?.interfaceScaling ?? false,
                OnToggleInterfaceScale);
        }

        protected override void OnUpdate()
        {
            // One-time hookup: the settings object may not exist yet at OnCreate. Once it does, sync the
            // initial state and subscribe to the settings-applied event. After that this early-returns
            // for free every tick — no per-frame reads.
            if (subscribedUi != null)
            {
                return;
            }

            InterfaceSettings? ui = GetUI();
            if (ui == null)
            {
                return;
            }

            interfaceScaleEnabledBinding.Update(ui.interfaceScaling);
            ui.onSettingsApplied += OnVanillaSettingsApplied;
            subscribedUi = ui;
        }

        private static InterfaceSettings? GetUI() => GameManager.instance?.settings?.userInterface;

        // Fires when any interface setting is applied — e.g. the player flips the dev-mode checkbox, or
        // our own toggle calls ApplyAndSave. Keeps the panel button in sync. Event-driven: costs nothing
        // between changes.
        private void OnVanillaSettingsApplied(Setting _)
        {
            InterfaceSettings? ui = GetUI();
            if (ui != null && interfaceScaleEnabledBinding.Value != ui.interfaceScaling)
            {
                interfaceScaleEnabledBinding.Update(ui.interfaceScaling);
            }
        }

        private void OnToggleInterfaceScale(bool enable)
        {
            InterfaceSettings? ui = GetUI();
            if (ui == null)
            {
                return;
            }

            // Toggle ONLY the dev interface-scaling flag; that alone resizes the whole UI.
            ui.interfaceScaling = enable;

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

            // Setting the value alone only re-scales the UI the next time the Cohtml view re-lays-out
            // (which is why it "waited" for the Options menu to open). Force that re-layout now by
            // resizing the view to its current size, so the scale applies immediately in the city.
            ForceUiRelayout();

            interfaceScaleEnabledBinding.Update(ui.interfaceScaling);
        }

        private static void ForceUiRelayout()
        {
            try
            {
                var view = GameManager.instance?.userInterface?.view;
                if (view != null)
                {
                    view.Resize(view.width, view.height);
                }
            }
            catch (Exception ex)
            {
                LogUtils.WarnOnce(
                    "interface-scale-relayout",
                    () => $"Failed to force UI relayout: {ex.GetType().Name}: {ex.Message}",
                    ex);
            }
        }

        protected override void OnDestroy()
        {
            if (subscribedUi != null)
            {
                subscribedUi.onSettingsApplied -= OnVanillaSettingsApplied;
                subscribedUi = null;
            }

            base.OnDestroy();
        }
    }
}
