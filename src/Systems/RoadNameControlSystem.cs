// File: src/Systems/RoadNameControlSystem.cs
// Purpose: Toggle for vanilla aggregate road-name labels.
//
// Approach: blank the road-name STRINGS in the active LocalizationDictionary so the vanilla
// label meshes render but display nothing. No Harmony, no reflection, no GPU-pipeline games.
//
// Inspired by — not copied from — CS2-RoadNameRemover's idea of intercepting name lookups.
// That mod uses HarmonyLib to patch LocalizationDictionary.TryGetValue. We do not. Instead
// we use the public Colossal.Localization API:
//
//   * LocalizationManager.activeDictionary               (public getter)
//   * LocalizationDictionary.entryIDs                    (public IEnumerable)
//   * LocalizationDictionary.Add(key, value)             (public — overwrites existing)
//   * LocalizationManager.onActiveDictionaryChanged      (public event)
//
// Why this is better than (a) Harmony-patching TryGetValue, (b) unsubscribing the render
// callback, or (c) flipping RenderingSystem.hideOverlay:
//   - No code patching → no conflicts with other Harmony mods.
//   - Tool direction arrows are completely untouched (the rendering pipeline runs as
//     normal — only the displayed text changes).
//   - Locale switches are handled transparently via onActiveDictionaryChanged.
//   - The vanilla render system never knows anything changed.
//
// Categories blanked: STREET, HIGHWAY, ALLEY, BRIDGE (the four road-network types).
// District names are intentionally left alone — those are city geography, not road names.

namespace CityWatchdog.Systems
{
    using Colossal.Localization;
    using CS2Shared.RiverMochi;
    using Game;
    using Game.Input;
    using Game.SceneFlow;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public partial class RoadNameControlSystem : UISystemBaseExtension
    {
        // The vanilla label mesh renders the localized string for each road segment. Replacing
        // those strings with whitespace produces a label that takes layout space but draws no
        // visible glyphs. 10 spaces is enough for the typical font run.
        private const string BlankValue = "          ";

        // Keys with these prefixes are road-network names that the AggregateRenderSystem labels.
        // Discovered via the indexed-locale-IDs naming scheme used by Game.Assets.
        private static readonly string[] RoadNamePrefixes =
        {
            "Assets.STREET_NAME:",
            "Assets.HIGHWAY_NAME:",
            "Assets.ALLEY_NAME:",
            "Assets.BRIDGE_NAME:",
        };

        private BoolBinding hideRoadNamesBinding = null!;
        private ProxyAction? toggleAction;

        // Original strings keyed by entry ID, captured the first time we blank a key. Used to
        // restore the dictionary when the user toggles names back on (and on mod unload).
        private readonly Dictionary<string, string> savedOriginals = new Dictionary<string, string>(StringComparer.Ordinal);

        private LocalizationManager? cachedLocalizationManager;
        private bool dictionaryChangedHooked;
        private bool currentlyBlanked;

        protected override void OnCreate()
        {
            base.OnCreate();

            bool initial = Setting.Instance?.HideRoadNames ?? false;
            hideRoadNamesBinding = AddBoolBindingAndTriggerBinding(
                nameof(Setting.HideRoadNames),
                initial,
                OnHideRoadNamesToggle);

            toggleAction = EnableHotkey(Setting.ToggleRoadNamesAction);
            HookDictionaryChanged();
        }

        protected override void OnDestroy()
        {
            UnhookDictionaryChanged();

            // Leave the game in a clean state on mod unload: restore originals if we'd blanked.
            if (currentlyBlanked)
            {
                RestoreOriginals();
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
            ApplyToGame(value);
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

            // Lazy hookup: if the LocalizationManager wasn't ready at OnCreate, try again.
            if (!dictionaryChangedHooked)
            {
                HookDictionaryChanged();
            }

            // Self-heal on first appearance: when in-game starts and the dictionary becomes
            // available, apply the user's saved preference.
            if (Setting.Instance?.HideRoadNames == true && !currentlyBlanked)
            {
                ApplyBlanks();
            }
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

            ApplyToGame(value);
        }

        private void ApplyToGame(bool hide)
        {
            if (hide && !currentlyBlanked)
            {
                ApplyBlanks();
            }
            else if (!hide && currentlyBlanked)
            {
                RestoreOriginals();
            }
        }

        private void ApplyBlanks()
        {
            LocalizationDictionary? dict = GetActiveDictionary();
            if (dict == null)
            {
                return;
            }

            // entryIDs is a live enumerable backed by the underlying Dictionary's Keys. We
            // snapshot before mutating to avoid InvalidOperationException during iteration.
            string[] roadNameKeys = dict.entryIDs.Where(IsRoadNameKey).ToArray();

            foreach (string key in roadNameKeys)
            {
                if (!savedOriginals.ContainsKey(key) && dict.TryGetValue(key, out string original))
                {
                    savedOriginals[key] = original;
                }
                dict.Add(key, BlankValue);
            }

            currentlyBlanked = true;
        }

        private void RestoreOriginals()
        {
            LocalizationDictionary? dict = GetActiveDictionary();
            if (dict == null)
            {
                currentlyBlanked = false;
                savedOriginals.Clear();
                return;
            }

            foreach (KeyValuePair<string, string> entry in savedOriginals)
            {
                dict.Add(entry.Key, entry.Value);
            }
            savedOriginals.Clear();
            currentlyBlanked = false;
        }

        private LocalizationDictionary? GetActiveDictionary()
        {
            cachedLocalizationManager ??= GameManager.instance?.localizationManager;
            return cachedLocalizationManager?.activeDictionary;
        }

        private void HookDictionaryChanged()
        {
            if (dictionaryChangedHooked)
            {
                return;
            }
            cachedLocalizationManager ??= GameManager.instance?.localizationManager;
            if (cachedLocalizationManager == null)
            {
                return;
            }

            cachedLocalizationManager.onActiveDictionaryChanged += OnActiveDictionaryChanged;
            dictionaryChangedHooked = true;
        }

        private void UnhookDictionaryChanged()
        {
            if (!dictionaryChangedHooked || cachedLocalizationManager == null)
            {
                return;
            }
            try
            {
                cachedLocalizationManager.onActiveDictionaryChanged -= OnActiveDictionaryChanged;
            }
            catch (Exception ex)
            {
                LogUtils.WarnOnce(
                    "road-name-unhook",
                    () => $"Failed to detach onActiveDictionaryChanged: {ex.GetType().Name}: {ex.Message}",
                    ex);
            }
            dictionaryChangedHooked = false;
        }

        private void OnActiveDictionaryChanged()
        {
            // Locale switch or full reload — our saved originals were for the previous dict.
            // Discard them and re-blank against the new dictionary if the user is in hide mode.
            savedOriginals.Clear();
            currentlyBlanked = false;
            if (Setting.Instance?.HideRoadNames == true)
            {
                ApplyBlanks();
            }
        }

        private static bool IsRoadNameKey(string entryId)
        {
            if (string.IsNullOrEmpty(entryId))
            {
                return false;
            }
            for (int i = 0; i < RoadNamePrefixes.Length; i++)
            {
                if (entryId.StartsWith(RoadNamePrefixes[i], StringComparison.Ordinal))
                {
                    return true;
                }
            }
            return false;
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
