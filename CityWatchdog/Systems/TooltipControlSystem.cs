// <copyright file="TooltipControlSystem.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the MIT License. You may not use this file except in compliance with this License.
// See LICENSE file in the project root for full license information.
// This notice and the MIT License notice must be kept with
// all copies or substantial portions of this code.
// ================= </copyright> ======================

// File: Systems/TooltipControlSystem.cs
// Purpose: Controls vanilla and CWD tooltip visibility, including the tooltip hotkey.

namespace CityWatchdog.Systems
{
    using System;
    using CS2Shared.RiverMochi;
    using Game.Input;
    using Game.UI.Tooltip;

    public partial class TooltipControlSystem : UISystemBaseExtension
    {
        // Binding identifier strings. Kept as constants — React side reads bindings by name,
        // so renaming or removing the underlying C# property must NOT cascade into the JS bundle.
        private const string DisableAllTooltipsBindingName = "DisableAllTooltips";

        private BoolBinding disableAllTooltipsBinding = null!;
        private BoolBinding disableCwdTooltipsBinding = null!;
        private TooltipUISystem? cachedTooltipUISystem;
        private ProxyAction? toggleAllTooltipsAction;

        protected override void OnCreate()
        {
            base.OnCreate();

            // Both tooltip toggles are in-session only: they start OFF (tooltips shown) every game
            // launch, so new mod tooltips are always visible first; the player must re-toggle to hide.
            disableAllTooltipsBinding = AddBoolBindingAndTriggerBinding(
                DisableAllTooltipsBindingName,
                false,
                OnDisableAllTooltipsToggle);

            disableCwdTooltipsBinding = AddBoolBindingAndTriggerBinding(
                nameof(CwdSettings.DisableCwdTooltips),
                false,
                OnDisableCwdTooltipsToggle);

            toggleAllTooltipsAction = EnableHotkey(CwdSettings.ToggleAllTooltipsAction);
        }

        protected override void OnUpdate()
        {
            if (toggleAllTooltipsAction == null)
            {
                toggleAllTooltipsAction = EnableHotkey(CwdSettings.ToggleAllTooltipsAction);
            }

            if (toggleAllTooltipsAction?.WasReleasedThisFrame() == true)
            {
                OnDisableAllTooltipsToggle(!disableAllTooltipsBinding.Value);
            }

            // Cheap idempotent re-apply: the vanilla TooltipUISystem is only created
            // in Game/Editor mode, so we cannot grab it during main menu. Keep the
            // game's hideTooltips field aligned with our binding once it appears.
            if (cachedTooltipUISystem == null)
            {
                cachedTooltipUISystem = World.GetExistingSystemManaged<TooltipUISystem>();
                if (cachedTooltipUISystem == null)
                {
                    return;
                }
            }

            bool desired = disableAllTooltipsBinding.Value;
            if (cachedTooltipUISystem.hideTooltips != desired)
            {
                cachedTooltipUISystem.hideTooltips = desired;
            }
        }

        private void OnDisableAllTooltipsToggle(bool value)
        {
            disableAllTooltipsBinding.Update(value);
            ApplyToGame(value);
        }

        private void OnDisableCwdTooltipsToggle(bool value)
        {
            // In-session only: update the binding but do not persist, so tooltips return next launch.
            disableCwdTooltipsBinding.Update(value);
        }

        private void ApplyToGame(bool value)
        {
            if (cachedTooltipUISystem == null)
            {
                cachedTooltipUISystem = World.GetExistingSystemManaged<TooltipUISystem>();
            }

            if (cachedTooltipUISystem != null)
            {
                // hideTooltips has a public setter, so no har. patching needed.
                cachedTooltipUISystem.hideTooltips = value;
            }
        }

        private static ProxyAction? EnableHotkey(string actionName)
        {
            try
            {
                ProxyAction? action = CwdSettings.Instance?.GetAction(actionName);
                if (action != null)
                {
                    action.shouldBeEnabled = true;
                }
                return action;
            }
            catch (Exception ex)
            {
                LogUtils.WarnOnce(
                    "tooltip-hotkey-" + actionName,
                    () => $"Keybinding '{actionName}' unavailable: {ex.GetType().Name}: {ex.Message}",
                    ex);
                return null;
            }
        }
    }
}
