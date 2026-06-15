// File: src/Systems/TooltipControlSystem.cs
// Purpose: Global tooltip on/off toggle.
//   - Mirrors the persisted Setting.DisableAllTooltips into a UI binding.
//   - Drives vanilla Game.UI.Tooltip.TooltipUISystem.hideTooltips so the game's
//     world/mouse tooltip pipeline short-circuits when off.
//   - The DOM-level UI tooltips (balloon popups from cs2/ui Tooltip and vanilla
//     panels) are hidden on the UI side by a small CSS injector that subscribes
//     to the same binding. See src/UI/src/mods/Tooltip/tooltipBlocker.ts.
//   - No Harmony: hideTooltips is a public setter on the vanilla system, so we
//     just look it up and assign.

namespace CityWatchdog.Systems
{
    using CS2Shared.RiverMochi;
    using Game;
    using Game.UI.Tooltip;
    using System;

    public partial class TooltipControlSystem : UISystemBaseExtension
    {
        private BoolBinding disableAllTooltipsBinding = null!;
        private BoolBinding disableCwdTooltipsBinding = null!;
        private TooltipUISystem? cachedTooltipUISystem;

        protected override void OnCreate()
        {
            base.OnCreate();

            Setting? setting = Setting.Instance;
            bool initialAll = setting?.DisableAllTooltips ?? false;
            bool initialCwd = setting?.DisableCwdTooltips ?? false;

            disableAllTooltipsBinding = AddBoolBindingAndTriggerBinding(
                nameof(Setting.DisableAllTooltips),
                initialAll,
                OnDisableAllTooltipsToggle);

            disableCwdTooltipsBinding = AddBoolBindingAndTriggerBinding(
                nameof(Setting.DisableCwdTooltips),
                initialCwd,
                OnDisableCwdTooltipsToggle);
        }

        public void SyncFromSettings()
        {
            Setting? setting = Setting.Instance;
            bool allTooltips = setting?.DisableAllTooltips ?? false;
            bool cwdTooltips = setting?.DisableCwdTooltips ?? false;

            if (disableAllTooltipsBinding.Value != allTooltips)
            {
                disableAllTooltipsBinding.Update(allTooltips);
            }

            if (disableCwdTooltipsBinding.Value != cwdTooltips)
            {
                disableCwdTooltipsBinding.Update(cwdTooltips);
            }

            ApplyToGame(allTooltips);
        }

        protected override void OnUpdate()
        {
            // Cheap idempotent re-apply: the vanilla TooltipUISystem is only created
            // in Game/Editor mode, so we cannot grab it during main menu. Keep the
            // game's hideTooltips field aligned with our setting once it appears.
            if (cachedTooltipUISystem == null)
            {
                cachedTooltipUISystem = World.GetExistingSystemManaged<TooltipUISystem>();
                if (cachedTooltipUISystem == null)
                {
                    return;
                }
            }

            bool desired = Setting.Instance?.DisableAllTooltips ?? false;
            if (cachedTooltipUISystem.hideTooltips != desired)
            {
                cachedTooltipUISystem.hideTooltips = desired;
            }
        }

        private void OnDisableAllTooltipsToggle(bool value)
        {
            disableAllTooltipsBinding.Update(value);

            Setting? setting = Setting.Instance;
            if (setting != null)
            {
                setting.DisableAllTooltips = value;
                TryPersist(setting);
            }

            ApplyToGame(value);
        }

        private void OnDisableCwdTooltipsToggle(bool value)
        {
            disableCwdTooltipsBinding.Update(value);

            Setting? setting = Setting.Instance;
            if (setting != null)
            {
                setting.DisableCwdTooltips = value;
                TryPersist(setting);
            }
        }

        private void ApplyToGame(bool value)
        {
            if (cachedTooltipUISystem == null)
            {
                cachedTooltipUISystem = World.GetExistingSystemManaged<TooltipUISystem>();
            }

            if (cachedTooltipUISystem != null)
            {
                cachedTooltipUISystem.hideTooltips = value;
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
                    "tooltip-save",
                    () => $"Failed to persist DisableAllTooltips: {ex.GetType().Name}: {ex.Message}",
                    ex);
            }
        }
    }
}
