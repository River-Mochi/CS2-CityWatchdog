// <copyright file="DistrictNameControlSystem.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the MIT License. You may not use this file except in compliance with this License.
// See LICENSE file in the project root for full license information.
// This notice and the MIT License notice must be kept with
// all copies or substantial portions of this code.
// ================= </copyright> ======================

// File: src/Systems/DistrictNameControlSystem.cs
// Purpose: Toggle for vanilla district-name labels while preserving district overlays.
//
// AreaRenderSystem draws more than names, so its render callback cannot simply be removed.
// Instead, a pre-render callback consumes the pending district name mesh and clears the
// district AreaTypeData.m_HasNameMesh flag before vanilla AreaRenderSystem.Render runs.

namespace CityWatchdog.Systems
{
    using CS2Shared.RiverMochi;
    using Game;
    using Game.Areas;
    using Game.Rendering;
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using UnityEngine;
    using UnityEngine.Rendering;

    public partial class DistrictNameControlSystem : UISystemBaseExtension
    {
        private AreaBufferSystem? cachedAreaBufferSystem;
        private FieldInfo? hasNameMeshField;
        private object? districtAreaTypeData;
        private bool reflectionReady;
        private bool reflectionFailed;
        private Action<ScriptableRenderContext, List<Camera>>? vanillaRenderDelegate;
        private Action<ScriptableRenderContext, List<Camera>>? preFilterDelegate;
        private BoolBinding hideDistrictNamesBinding = null!;
        private bool currentlyHiding;

        protected override void OnCreate()
        {
            base.OnCreate();

            currentlyHiding = Setting.Instance?.HideDistrictNames ?? false;
            hideDistrictNamesBinding = AddBoolBindingAndTriggerBinding(
                nameof(Setting.HideDistrictNames),
                currentlyHiding,
                OnHideDistrictNamesToggle);
        }

        protected override void OnDestroy()
        {
            if (preFilterDelegate != null)
            {
                try
                {
                    RenderPipelineManager.beginContextRendering -= preFilterDelegate;
                }
                catch (Exception ex)
                {
                    LogUtils.WarnOnce(
                        "district-name-destroy-unsub",
                        () => $"Failed to unsubscribe district-name pre-filter on destroy: {ex.GetType().Name}: {ex.Message}",
                        ex);
                }
            }

            if (currentlyHiding)
            {
                SetHasNameMesh(true);
            }

            base.OnDestroy();
        }

        public void SyncFromSettings()
        {
            bool value = Setting.Instance?.HideDistrictNames ?? false;
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

            bool settingValue = Setting.Instance?.HideDistrictNames ?? false;
            if (settingValue != currentlyHiding)
            {
                if (hideDistrictNamesBinding.Value != settingValue)
                {
                    hideDistrictNamesBinding.Update(settingValue);
                }

                ApplySetting(settingValue);
            }
        }

        private void OnHideDistrictNamesToggle(bool value)
        {
            hideDistrictNamesBinding.Update(value);

            Setting? setting = Setting.Instance;
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

        private void PreRenderFilter(ScriptableRenderContext context, List<Camera> cameras)
        {
            if (!currentlyHiding || !reflectionReady)
            {
                return;
            }

            try
            {
                cachedAreaBufferSystem?.GetNameMesh(AreaType.District, out _, out _);
                SetHasNameMesh(false);
            }
            catch (Exception ex)
            {
                LogUtils.WarnOnce(
                    "district-name-prerender",
                    () => $"District-name pre-render filter failed: {ex.GetType().Name}: {ex.Message}",
                    ex);
            }
        }

        private void InitializeReflection()
        {
            try
            {
                cachedAreaBufferSystem = World.GetExistingSystemManaged<AreaBufferSystem>();
                AreaRenderSystem? areaRenderSystem = World.GetExistingSystemManaged<AreaRenderSystem>();

                if (cachedAreaBufferSystem == null || areaRenderSystem == null)
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

                if (arrayField == null || hasNameMeshField == null)
                {
                    LogUtils.WarnOnce(
                        "district-name-reflect",
                        () => "Cannot find m_AreaTypeData or m_HasNameMesh; district-name toggle disabled.");
                    reflectionFailed = true;
                    return;
                }

                Array? array = arrayField.GetValue(cachedAreaBufferSystem) as Array;
                if (array == null || array.Length < 2)
                {
                    LogUtils.WarnOnce(
                        "district-name-reflect",
                        () => "m_AreaTypeData array is null or too short; district-name toggle disabled.");
                    reflectionFailed = true;
                    return;
                }

                districtAreaTypeData = array.GetValue(1);
                if (districtAreaTypeData == null)
                {
                    LogUtils.WarnOnce(
                        "district-name-reflect",
                        () => "m_AreaTypeData[1] (District) is null; district-name toggle disabled.");
                    reflectionFailed = true;
                    return;
                }

                vanillaRenderDelegate = BuildRenderDelegate(areaRenderSystem);
                if (vanillaRenderDelegate == null)
                {
                    LogUtils.WarnOnce(
                        "district-name-reflect",
                        () => "Could not bind AreaRenderSystem.Render delegate; district-name toggle disabled.");
                    reflectionFailed = true;
                    return;
                }

                preFilterDelegate = PreRenderFilter;
                RenderPipelineManager.beginContextRendering -= vanillaRenderDelegate;
                RenderPipelineManager.beginContextRendering += preFilterDelegate;
                RenderPipelineManager.beginContextRendering += vanillaRenderDelegate;
                reflectionReady = true;
                LogUtils.Info(() => "District-name control initialized.");
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

        private static Action<ScriptableRenderContext, List<Camera>>? BuildRenderDelegate(AreaRenderSystem system)
        {
            MethodInfo? method = typeof(AreaRenderSystem).GetMethod(
                "Render",
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
                    "district-name-delegate-create",
                    () => $"Delegate.CreateDelegate failed for AreaRenderSystem.Render: {ex.GetType().Name}: {ex.Message}",
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
                    "district-name-save",
                    () => $"Failed to persist HideDistrictNames: {ex.GetType().Name}: {ex.Message}",
                    ex);
            }
        }
    }
}
