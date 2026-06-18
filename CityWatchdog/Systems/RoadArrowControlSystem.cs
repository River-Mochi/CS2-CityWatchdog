// <copyright file="RoadArrowControlSystem.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi, MIT License.
// See LICENSE file in the project root for full license info.
// </copyright>

// File: src/Systems/RoadArrowControlSystem.cs
// Purpose: Toggle to show 1-way road direction arrows even when no road tool is active.
//
// Approach: tell the vanilla DefaultToolSystem that it "wants" net arrows. When the player
// has no specific tool selected, the active tool IS the default tool, and the vanilla
// AggregateRenderSystem.Render method does:
//
//     if (m_ToolSystem.activeTool != null && m_ToolSystem.activeTool.requireNetArrows) {
//         // draws arrows
//     }
//
// So setting requireNetArrows = true on the default tool makes the vanilla code render
// arrows the whole time the user is browsing. The moment the user grabs a real tool the
// vanilla check looks at that tool's own flag, so we don't interfere with tool behavior.
//
// `requireNetArrows` is a public property on ToolBaseSystem but its setter is internal,
// so we go through reflection. No Harmony, no IL patching, no custom render path of our own.
//
// Inspired by — but not copied from — an unpublished community mod that shipped only a DLL.
// Our identifier names, file layout, persistence wiring, and lifecycle differ. Defaults
// in OnDestroy restore the original flag so the game is left clean on mod unload.

namespace CityWatchdog.Systems
{
    using CS2Shared.RiverMochi;
    using Game;
    using Game.Input;
    using Game.Tools;
    using System;
    using System.Reflection;

    public partial class RoadArrowControlSystem : UISystemBaseExtension
    {
        private const string ArrowsPropertyName = "requireNetArrows";

        private BoolBinding showRoadArrowsBinding = null!;
        private DefaultToolSystem? vanillaDefaultTool;
        private PropertyInfo? arrowsRequiredProperty;

        // When we set the flag to true we save the previous value (vanilla default is false).
        // Used to put the flag back where we found it on toggle-off and on system destroy.
        private bool originalFlagCaptured;
        private bool originalFlagValue;
        private bool arrowsCurrentlyForced;

        protected override void OnCreate()
        {
            base.OnCreate();

            bool initial = Setting.Instance?.ShowRoadArrows ?? false;
            showRoadArrowsBinding = AddBoolBindingAndTriggerBinding(
                nameof(Setting.ShowRoadArrows),
                initial,
                OnShowRoadArrowsToggle);
        }

        protected override void OnDestroy()
        {
            // Restore vanilla default-tool flag on mod unload so the game is clean.
            if (arrowsCurrentlyForced)
            {
                WriteArrowsFlag(originalFlagCaptured ? originalFlagValue : false);
                arrowsCurrentlyForced = false;
            }
            base.OnDestroy();
        }

        public void SyncFromSettings()
        {
            bool value = Setting.Instance?.ShowRoadArrows ?? false;
            if (showRoadArrowsBinding.Value != value)
            {
                showRoadArrowsBinding.Update(value);
            }
            ApplyToGame(value);
        }

        protected override void OnUpdate()
        {
            // Reapply each tick so any code path that resets DefaultToolSystem.requireNetArrows
            // gets corrected. The write itself is idempotent — only fires when the value differs.
            ApplyToGame(Setting.Instance?.ShowRoadArrows ?? false);
        }

        private void OnShowRoadArrowsToggle(bool value)
        {
            showRoadArrowsBinding.Update(value);

            Setting? setting = Setting.Instance;
            if (setting != null)
            {
                setting.ShowRoadArrows = value;
                TryPersist(setting);
            }

            ApplyToGame(value);
        }

        private void ApplyToGame(bool show)
        {
            if (show && !arrowsCurrentlyForced)
            {
                CaptureOriginalFlag();
                if (WriteArrowsFlag(true))
                {
                    arrowsCurrentlyForced = true;
                }
            }
            else if (!show && arrowsCurrentlyForced)
            {
                WriteArrowsFlag(originalFlagCaptured ? originalFlagValue : false);
                arrowsCurrentlyForced = false;
            }
        }

        private void CaptureOriginalFlag()
        {
            if (originalFlagCaptured)
            {
                return;
            }
            if (!ResolveReflectionTargets())
            {
                return;
            }

            try
            {
                originalFlagValue = (bool)(arrowsRequiredProperty!.GetValue(vanillaDefaultTool) ?? false);
                originalFlagCaptured = true;
            }
            catch (Exception ex)
            {
                LogUtils.WarnOnce(
                    "road-arrow-read",
                    () => $"Failed to read DefaultToolSystem.{ArrowsPropertyName}: {ex.GetType().Name}: {ex.Message}",
                    ex);
            }
        }

        private bool WriteArrowsFlag(bool target)
        {
            if (!ResolveReflectionTargets())
            {
                return false;
            }

            try
            {
                arrowsRequiredProperty!.SetValue(vanillaDefaultTool, target);
                return true;
            }
            catch (Exception ex)
            {
                LogUtils.WarnOnce(
                    "road-arrow-write",
                    () => $"Failed to write DefaultToolSystem.{ArrowsPropertyName}={target}: {ex.GetType().Name}: {ex.Message}",
                    ex);
                return false;
            }
        }

        private bool ResolveReflectionTargets()
        {
            if (vanillaDefaultTool == null)
            {
                vanillaDefaultTool = World.GetExistingSystemManaged<DefaultToolSystem>();
                if (vanillaDefaultTool == null)
                {
                    return false;
                }
            }

            if (arrowsRequiredProperty == null)
            {
                arrowsRequiredProperty = typeof(ToolBaseSystem).GetProperty(
                    ArrowsPropertyName,
                    BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

                if (arrowsRequiredProperty == null || !arrowsRequiredProperty.CanWrite)
                {
                    LogUtils.WarnOnce(
                        "road-arrow-prop",
                        () => $"ToolBaseSystem.{ArrowsPropertyName} not found or not writable; show-road-arrows toggle disabled.");
                    return false;
                }
            }

            return true;
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
                    "road-arrow-save",
                    () => $"Failed to persist ShowRoadArrows: {ex.GetType().Name}: {ex.Message}",
                    ex);
            }
        }
    }
}
