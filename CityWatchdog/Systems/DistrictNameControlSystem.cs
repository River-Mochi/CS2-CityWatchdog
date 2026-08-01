// <copyright file="DistrictNameControlSystem.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the MIT License. You may not use this file except in compliance with this License.
// See LICENSE file in the project root for full license information.
// This notice and the MIT License notice must be kept with
// all copies or substantial portions of this code.
// ================= </copyright> ======================

// File: Systems/DistrictNameControlSystem.cs
// Purpose: Hides vanilla district-name labels.

namespace CityWatchdog.Systems
{
    using System;
    using System.Reflection;
    using CS2Shared.RiverMochi;
    using Game.Areas;
    using Game.Rendering;

    public partial class DistrictNameControlSystem : UISystemBaseExtension
    {
        private AreaBufferSystem? cachedAreaBufferSystem;
        private FieldInfo? hasNameMeshField;
        private object? districtAreaTypeData;
        private bool reflectionReady;
        private bool reflectionFailed;
        private BoolBinding hideDistrictNamesBinding = null!;
        private bool currentlyHiding;

        protected override void OnCreate()
        {
            base.OnCreate();

            currentlyHiding = CwdSettings.Instance?.HideDistrictNames ?? false;
            hideDistrictNamesBinding = AddBoolBindingAndTriggerBinding(
                nameof(CwdSettings.HideDistrictNames),
                currentlyHiding,
                OnHideDistrictNamesToggle);
        }

        // Restore vanilla's ready flag on unload so disabling CWD cannot leave names hidden.
        protected override void OnDestroy()
        {
            if (currentlyHiding)
            {
                SetHasNameMesh(true);
            }

            base.OnDestroy();
        }

        public void SyncFromSettings()
        {
            bool value = CwdSettings.Instance?.HideDistrictNames ?? false;
            if (hideDistrictNamesBinding.Value != value)
            {
                hideDistrictNamesBinding.Update(value);
            }

            ApplySetting(value);
        }

        protected override void OnUpdate()
        {
            if (!reflectionReady && !reflectionFailed)
            {
                InitializeReflection();
            }

            bool settingValue = CwdSettings.Instance?.HideDistrictNames ?? false;
            if (settingValue != currentlyHiding)
            {
                if (hideDistrictNamesBinding.Value != settingValue)
                {
                    hideDistrictNamesBinding.Update(settingValue);
                }

                ApplySetting(settingValue);
            }

            if (currentlyHiding && reflectionReady)
            {
                SuppressDistrictNameMesh();
            }
        }

        private void OnHideDistrictNamesToggle(bool value)
        {
            hideDistrictNamesBinding.Update(value);

            CwdSettings? setting = CwdSettings.Instance;
            if (setting != null)
            {
                setting.HideDistrictNames = value;
                TryPersist(setting);
            }

            ApplySetting(value);
        }

        private void ApplySetting(bool hide)
        {
            currentlyHiding = hide;
            if (!currentlyHiding)
            {
                SetHasNameMesh(true);
            }
        }

        private void SuppressDistrictNameMesh()
        {
            try
            {
                // AreaBufferSystem prepared this mesh earlier in the frame. Read first, then
                // clear only District ready flag so vanilla skips the label draw.
                cachedAreaBufferSystem?.GetNameMesh(AreaType.District, out _, out _);
                SetHasNameMesh(false);
            }
            catch (Exception ex)
            {
                LogUtils.WarnOnce(
                    "district-name-render-filter",
                    () => $"District-name rendering filter failed: {ex.GetType().Name}: {ex.Message}",
                    ex);
            }
        }

        // GetNameMesh is public, but the per-area ready flag is not. Reflection is limited
        // to this one flag so boundaries and other area labels remain untouched.
        private void InitializeReflection()
        {
            try
            {
                cachedAreaBufferSystem = World.GetExistingSystemManaged<AreaBufferSystem>();
                // Rendering system may not exist yet during startup, so retry next update.
                if (cachedAreaBufferSystem == null)
                {
                    return;
                }

                Type bufferType = typeof(AreaBufferSystem);
                Type? areaTypeDataType = bufferType.GetNestedType("AreaTypeData", BindingFlags.NonPublic);
                if (areaTypeDataType == null)
                {
                    LogUtils.WarnOnce(
                        "district-name-reflect",
                        () => "Cannot find AreaBufferSystem.AreaTypeData; district-name toggle disabled.");
                    reflectionFailed = true;
                    return;
                }

                FieldInfo? arrayField = bufferType.GetField(
                    "m_AreaTypeData",
                    BindingFlags.Instance | BindingFlags.NonPublic);
                hasNameMeshField = areaTypeDataType.GetField(
                    "m_HasNameMesh",
                    BindingFlags.Instance | BindingFlags.Public);

                if (arrayField == null ||
                    hasNameMeshField == null ||
                    hasNameMeshField.FieldType != typeof(bool))
                {
                    LogUtils.WarnOnce(
                        "district-name-reflect",
                        () => "District-name toggle disabled because CS2 area rendering internals changed.");
                    reflectionFailed = true;
                    return;
                }

                Array? array = arrayField.GetValue(cachedAreaBufferSystem) as Array;
                int districtIndex = (int)AreaType.District;
                if (array == null || districtIndex < 0 || districtIndex >= array.Length)
                {
                    LogUtils.WarnOnce(
                        "district-name-reflect",
                        () => "m_AreaTypeData does not contain a District entry; district-name toggle disabled.");
                    reflectionFailed = true;
                    return;
                }

                districtAreaTypeData = array.GetValue(districtIndex);
                if (districtAreaTypeData == null)
                {
                    LogUtils.WarnOnce(
                        "district-name-reflect",
                        () => "The District AreaTypeData entry is null; district-name toggle disabled.");
                    reflectionFailed = true;
                    return;
                }

                reflectionReady = true;
#if DEBUG
                LogUtils.Debug(() => $"District reflection OK: AreaTypeData found, District index={districtIndex}, m_HasNameMesh bool field found.");
#endif
            }
            catch (Exception ex)
            {
                LogUtils.WarnOnce(
                    "district-name-init",
                    () => $"District-name reflection initialization failed: {ex.GetType().Name}: {ex.Message}",
                    ex);
                reflectionFailed = true;
            }
        }

        private void SetHasNameMesh(bool value)
        {
            if (districtAreaTypeData == null || hasNameMeshField == null)
            {
                return;
            }

            try
            {
                hasNameMeshField.SetValue(districtAreaTypeData, value);
            }
            catch (Exception ex)
            {
                LogUtils.WarnOnce(
                    "district-name-set-mesh",
                    () => $"Setting district m_HasNameMesh failed: {ex.GetType().Name}: {ex.Message}",
                    ex);
            }
        }

        private static void TryPersist(CwdSettings setting)
        {
            try
            {
                setting.ApplyAndSave();
            }
            catch (Exception ex)
            {
                LogUtils.WarnOnce(
                    "district-name-save",
                    () => $"Failed to persist HideDistrictNames: {ex.GetType().Name}: {ex.Message}",
                    ex);
            }
        }
    }
}
