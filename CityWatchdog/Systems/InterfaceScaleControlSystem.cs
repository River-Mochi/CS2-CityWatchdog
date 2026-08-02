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
// ApplyAndSave() persists it with or without dev mode. We deliberately do NOT touch textScale or
// toolbarScale: those are normal (non-dev) sliders players already have. No Harmony.
//
// Applying it LIVE needs one extra step. The UI reads the scale from the vanilla
// "options.interfaceScaling" binding, which OptionsUISystem registers via AddUpdateBinding — and
// UISystemBase only pushes update bindings from OnUpdate, which OptionsUISystem early-returns from
// unless the Options screen is open. So changing the setting in-city did nothing visible until the
// player opened Options. We therefore reach that one binding (reflection over UISystemBase's private
// m_UpdateBindings list, resolved once and cached) and call Update() on it so the scale applies
// instantly. If that lookup ever fails we log once and fall back to the old behavior (applies when
// Options is opened) — the toggle still works, it just isn't instant.
//
// Sync is EVENT-driven via InterfaceSettings.onSettingsApplied (fires only when a setting changes),
// so there is no per-frame polling and no FPS cost between changes.

namespace CityWatchdog.Systems
{
    using Colossal.UI.Binding;
    using CS2Shared.RiverMochi;
    using Game.SceneFlow;
    using Game.Settings;
    using Game.UI;
    using Game.UI.Menu;
    using System;
    using System.Collections.Generic;
    using System.Reflection;

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

            // Setting the value is not enough on its own: the UI reads the scale from the vanilla
            // "options.interfaceScaling" binding, and that binding only pushes to the UI when
            // OptionsUISystem updates — which it refuses to do unless the Options screen is open
            // (OptionsUISystem.OnUpdate early-returns otherwise). That is exactly why the resize only
            // appeared after opening Options. Push that one binding ourselves so it applies instantly.
            PushVanillaInterfaceScalingBinding();

            interfaceScaleEnabledBinding.Update(ui.interfaceScaling);
        }

        // Cached lookup of OptionsUISystem's private update-binding list entry for
        // "options.interfaceScaling". Resolved once, then reused. Instance (not static) fields so a
        // world reload rebuilds the system and re-resolves rather than holding a stale binding.
        private IUpdateBinding? cachedScalingBinding;
        private bool scalingBindingLookupFailed;

        private void PushVanillaInterfaceScalingBinding()
        {
            try
            {
                IUpdateBinding? binding = ResolveScalingBinding();

                // Update() re-reads the getter and pushes to the UI when the value changed.
                binding?.Update();
            }
            catch (Exception ex)
            {
                LogUtils.WarnOnce(
                    "interface-scale-binding-push",
                    () => $"Failed to push interfaceScaling binding: {ex.GetType().Name}: {ex.Message}",
                    ex);
            }
        }

        private IUpdateBinding? ResolveScalingBinding()
        {
            if (cachedScalingBinding != null || scalingBindingLookupFailed)
            {
                return cachedScalingBinding;
            }

            OptionsUISystem? options = World.GetExistingSystemManaged<OptionsUISystem>();
            if (options == null)
            {
                return null;
            }

            // m_UpdateBindings is declared on UISystemBase (private), holding every binding the system
            // registered with AddUpdateBinding.
            FieldInfo? field = typeof(UISystemBase).GetField(
                "m_UpdateBindings",
                BindingFlags.Instance | BindingFlags.NonPublic);

            if (field?.GetValue(options) is not IEnumerable<IUpdateBinding> bindings)
            {
                scalingBindingLookupFailed = true;
                LogUtils.WarnOnce(
                    "interface-scale-binding-missing",
                    () => "Could not read OptionsUISystem update bindings; UI scale will only apply when the Options menu is opened.");
                return null;
            }

            foreach (IUpdateBinding candidate in bindings)
            {
                if (candidate is BindingBase namedBinding &&
                    namedBinding.path == "options.interfaceScaling")
                {
                    cachedScalingBinding = candidate;
                    return cachedScalingBinding;
                }
            }

            scalingBindingLookupFailed = true;
            LogUtils.WarnOnce(
                "interface-scale-binding-notfound",
                () => "options.interfaceScaling binding not found; UI scale will only apply when the Options menu is opened.");
            return null;
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
