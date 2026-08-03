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
        private const string kDisableAllTooltipsBindingName = "DisableAllTooltips";

        private BoolBinding m_DisableAllTooltipsBinding = null!;
        private BoolBinding m_DisableCwdTooltipsBinding = null!;
        private TooltipUISystem? m_CachedTooltipUISystem;
        private ProxyAction? m_ToggleAllTooltipsAction;

        protected override void OnCreate()
        {
            base.OnCreate();

            // Both tooltip toggles are in-session only: they start OFF (tooltips shown) every game
            // launch, so new mod tooltips are always visible first; the player must re-toggle to hide.
            m_DisableAllTooltipsBinding = AddBoolBindingAndTriggerBinding(
                kDisableAllTooltipsBindingName,
                false,
                OnDisableAllTooltipsToggle);

            m_DisableCwdTooltipsBinding = AddBoolBindingAndTriggerBinding(
                nameof(CwdSettings.DisableCwdTooltips),
                false,
                OnDisableCwdTooltipsToggle);

            m_ToggleAllTooltipsAction = EnableHotkey(CwdSettings.ToggleAllTooltipsAction);
        }

        protected override void OnUpdate()
        {
            m_ToggleAllTooltipsAction ??= EnableHotkey(CwdSettings.ToggleAllTooltipsAction);

            if (m_ToggleAllTooltipsAction?.WasReleasedThisFrame() == true)
            {
                OnDisableAllTooltipsToggle(!m_DisableAllTooltipsBinding.Value);
            }

            // Cheap idempotent re-apply: the vanilla TooltipUISystem is only created
            // in Game/Editor mode, so we cannot grab it during main menu. Keep the
            // game's hideTooltips field aligned with our binding once it appears.
            if (m_CachedTooltipUISystem == null)
            {
                m_CachedTooltipUISystem = World.GetExistingSystemManaged<TooltipUISystem>();
                if (m_CachedTooltipUISystem == null)
                {
                    return;
                }
            }

            bool desired = m_DisableAllTooltipsBinding.Value;
            if (m_CachedTooltipUISystem.hideTooltips != desired)
            {
                m_CachedTooltipUISystem.hideTooltips = desired;
            }
        }

        private void OnDisableAllTooltipsToggle(bool value)
        {
            m_DisableAllTooltipsBinding.Update(value);
            ApplyToGame(value);
        }

        private void OnDisableCwdTooltipsToggle(bool value)
        {
            // In-session only: update the binding but do not persist, so tooltips return next launch.
            m_DisableCwdTooltipsBinding.Update(value);
        }

        private void ApplyToGame(bool value)
        {
            m_CachedTooltipUISystem ??= World.GetExistingSystemManaged<TooltipUISystem>();

            if (m_CachedTooltipUISystem != null)
            {
                // hideTooltips has a public setter, so no har. patching needed.
                m_CachedTooltipUISystem.hideTooltips = value;
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
