// <copyright file="RoadNameControlSystem.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the MIT License; you may not use this file except in compliance with this License.
// See LICENSE file in the project root for full license information.
// This notice and the MIT License notice must be kept with
// all copies or substantial portions of this code.
// ================= </copyright> ======================

// File: src/Systems/RoadNameControlSystem.cs
// Purpose: Toggle for vanilla aggregate road-name labels.
//
// Mechanism: unsubscribe AggregateRenderSystem.Render from RenderPipelineManager.beginContextRendering
// whenever we want road names to NOT render, and let it stay subscribed when we want names or arrows
// to render. Done via Delegate.CreateDelegate against the private Render method — no Harmony, no IL
// patching.
//
// Why this and not the localization-dictionary overwrite approach we tried first:
//   - AggregateMeshSystem bakes each road label's TEXT INTO A GPU TEXTURE the first time the label
//     is created. The localization lookup runs only during that bake. Once a texture exists,
//     blanking the dictionary entry has zero visible effect on the already-rendered label.
//   - Existing labels would stay visible until something forced a rebake (a tool click, a hover,
//     a road edit, a locale reload). Restoring originals on toggle-off had the inverse problem.
//   - RoadNameRemover gets away with the localization-blank trick because Harmony patches catch
//     TryGetValue inside every bake. Without Harmony we can't ride that pulse, so we operate at
//     the only layer we can reach: the render pipeline subscription itself.
//
// Coordination with RoadArrowControlSystem:
//   The vanilla Render method draws arrows OR names mutually exclusively. When the active tool's
//   requireNetArrows is true (either because the player has a road/upgrade/bulldoze tool active,
//   or because RoadArrowControlSystem flipped DefaultToolSystem.requireNetArrows on), Render
//   returns before the names loop. So in those states we MUST keep Render subscribed (otherwise
//   we'd kill the arrows), and the names stay hidden as a free side-effect of the vanilla
//   mutually-exclusive logic.
//
//   Final decision: unsubscribe only when HideRoadNames is on AND neither the arrows-force toggle
//   nor a net tool is asking for arrows. In every other state, vanilla handles the right thing.

namespace CityWatchdog.Systems
{
    using CS2Shared.RiverMochi;
    using Game;
    using Game.Input;
    using Game.Rendering;
    using Game.Tools;
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using UnityEngine;
    using UnityEngine.Rendering;

    public partial class RoadNameControlSystem : UISystemBaseExtension
    {
        private const string AggregateRenderMethodName = "Render";

        private BoolBinding hideRoadNamesBinding = null!;
        private AggregateRenderSystem? cachedAggregateRenderSystem;
        private ToolSystem? cachedToolSystem;
        private Action<ScriptableRenderContext, List<Camera>>? cachedRenderDelegate;
        private bool currentlyUnsubscribed;
        private ProxyAction? toggleAction;

        protected override void OnCreate()
        {
            base.OnCreate();

            bool initial = Setting.Instance?.HideRoadNames ?? false;
            hideRoadNamesBinding = AddBoolBindingAndTriggerBinding(
                nameof(Setting.HideRoadNames),
                initial,
                OnHideRoadNamesToggle);

            toggleAction = EnableHotkey(Setting.ToggleRoadNamesAction);
        }

        protected override void OnDestroy()
        {
            // Restore vanilla rendering on mod unload so the game is clean.
            if (currentlyUnsubscribed && cachedRenderDelegate != null)
            {
                try
                {
                    RenderPipelineManager.beginContextRendering += cachedRenderDelegate;
                }
                catch (Exception ex)
                {
                    LogUtils.WarnOnce(
                        "road-name-restore",
                        () => $"Failed to re-subscribe AggregateRenderSystem.Render on destroy: {ex.GetType().Name}: {ex.Message}",
                        ex);
                }
                currentlyUnsubscribed = false;
            }
            base.OnDestroy();
        }

        public void SyncFromSettings()
        {
            bool value = Setting.Instance?.HideRoadNames ?? false;
            if (hideRoadNamesBinding.Value != value)
            {
                hideRoadNamesBinding.Update(value);
            }
            ApplyToGame();
        }

        protected override void OnUpdate()
        {
            if (toggleAction == null)
            {
                toggleAction = EnableHotkey(Setting.ToggleRoadNamesAction);
            }

            if (toggleAction?.WasReleasedThisFrame() == true)
            {
                bool current = Setting.Instance?.HideRoadNames ?? false;
                OnHideRoadNamesToggle(!current);
            }

            // Re-evaluate every frame because two of the inputs (tool active, arrows-force setting)
            // can change without us being notified. The subscribe/unsubscribe writes themselves are
            // idempotent — they only run on transition.
            ApplyToGame();
        }

        private void OnHideRoadNamesToggle(bool value)
        {
            hideRoadNamesBinding.Update(value);

            Setting? setting = Setting.Instance;
            if (setting != null)
            {
                setting.HideRoadNames = value;
                TryPersist(setting);
            }

            ApplyToGame();
        }

        private void ApplyToGame()
        {
            if (cachedAggregateRenderSystem == null)
            {
                cachedAggregateRenderSystem = World.GetExistingSystemManaged<AggregateRenderSystem>();
                if (cachedAggregateRenderSystem == null)
                {
                    return;
                }
            }

            if (cachedRenderDelegate == null)
            {
                cachedRenderDelegate = BuildRenderDelegate(cachedAggregateRenderSystem);
                if (cachedRenderDelegate == null)
                {
                    LogUtils.WarnOnce(
                        "road-name-render-delegate",
                        () => "Could not bind a delegate to AggregateRenderSystem.Render; road-name toggle disabled.");
                    return;
                }
            }

            Setting? setting = Setting.Instance;
            bool hideRequested = setting?.HideRoadNames ?? false;
            bool arrowsForced = setting?.ShowRoadArrows ?? false;
            bool toolWantsArrows = NetToolWantsArrows();

            // Only suppress vanilla Render when the user wants names hidden AND nothing else needs
            // the arrows path. When arrows are forced or a net tool is active, vanilla naturally
            // skips the names loop, so we let it run — that gives us arrows + no names for free.
            bool shouldBeUnsubscribed = hideRequested && !arrowsForced && !toolWantsArrows;

            if (shouldBeUnsubscribed && !currentlyUnsubscribed)
            {
                RenderPipelineManager.beginContextRendering -= cachedRenderDelegate;
                currentlyUnsubscribed = true;
            }
            else if (!shouldBeUnsubscribed && currentlyUnsubscribed)
            {
                RenderPipelineManager.beginContextRendering += cachedRenderDelegate;
                currentlyUnsubscribed = false;
            }
        }

        private bool NetToolWantsArrows()
        {
            if (cachedToolSystem == null)
            {
                cachedToolSystem = World.GetExistingSystemManaged<ToolSystem>();
                if (cachedToolSystem == null)
                {
                    return false;
                }
            }
            return cachedToolSystem.activeTool != null && cachedToolSystem.activeTool.requireNetArrows;
        }

        private static Action<ScriptableRenderContext, List<Camera>>? BuildRenderDelegate(AggregateRenderSystem system)
        {
            MethodInfo? method = typeof(AggregateRenderSystem).GetMethod(
                AggregateRenderMethodName,
                BindingFlags.Instance | BindingFlags.NonPublic);

            if (method == null)
            {
                return null;
            }

            try
            {
                return (Action<ScriptableRenderContext, List<Camera>>)Delegate.CreateDelegate(
                    typeof(Action<ScriptableRenderContext, List<Camera>>),
                    system,
                    method);
            }
            catch (Exception ex)
            {
                LogUtils.WarnOnce(
                    "road-name-delegate-create",
                    () => $"Delegate.CreateDelegate failed for AggregateRenderSystem.Render: {ex.GetType().Name}: {ex.Message}",
                    ex);
                return null;
            }
        }

        private ProxyAction? EnableHotkey(string actionName)
        {
            try
            {
                ProxyAction? action = Setting.Instance?.GetAction(actionName);
                if (action != null)
                {
                    action.shouldBeEnabled = true;
                }
                return action;
            }
            catch (Exception ex)
            {
                LogUtils.WarnOnce(
                    "road-name-hotkey-" + actionName,
                    () => $"Keybinding '{actionName}' unavailable: {ex.GetType().Name}: {ex.Message}",
                    ex);
                return null;
            }
        }

        private static void TryPersist(Setting setting)
        {
            try
            {
                setting.ApplyAndSave();
            }
            catch (Exception ex)
            {
                LogUtils.WarnOnce(
                    "road-name-save",
                    () => $"Failed to persist HideRoadNames: {ex.GetType().Name}: {ex.Message}",
                    ex);
            }
        }
    }
}
