// <copyright file="DayNightExposureBridge.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the MIT License. You may not use this file except in compliance with this License.
// See LICENSE file in the project root for full license information.
// This notice and the MIT License notice must be kept with
// all copies or substantial portions of this code.
// ================= </copyright> ======================

// File: Systems/DayNightExposureBridge.cs
// Purpose: Preserve HDRP exposure across an instant Day -> Night lighting jump.

namespace CityWatchdog.Systems
{
    using System;
    using System.Reflection;
    using Game.Rendering;
    using Unity.Collections;
    using UnityEngine;
    using UnityEngine.Rendering;
    using UnityEngine.Rendering.HighDefinition;

    internal sealed class DayNightExposureBridge : IDisposable
    {
        private const int kVolumePriority = 6000;
        private const string kVolumeName = "CityWatchdogDayNightExposureBridge";
        private const string kExposureTexturesFieldName = "m_ExposureTextures";
        private const string kCurrentTextureFieldName = "current";
        private const string kPreviousTextureFieldName = "previous";
        private const float kMinimumExposureMultiplier = 0.000001f;
        private const float kMaximumAbsoluteExposureEv = 64f;

        // HDRP exposes HDCamera, but its two 1x1 exposure-history RTHandles are internal.
        private static readonly FieldInfo? s_ExposureTexturesField =
            typeof(HDCamera).GetField(
                kExposureTexturesFieldName,
                BindingFlags.Instance | BindingFlags.NonPublic);

        private static readonly FieldInfo? s_CurrentTextureField =
            s_ExposureTexturesField?.FieldType.GetField(
                kCurrentTextureFieldName,
                BindingFlags.Instance |
                BindingFlags.Public |
                BindingFlags.NonPublic);

        private static readonly FieldInfo? s_PreviousTextureField =
            s_ExposureTexturesField?.FieldType.GetField(
                kPreviousTextureFieldName,
                BindingFlags.Instance |
                BindingFlags.Public |
                BindingFlags.NonPublic);

        private Volume? m_Volume;
        private Exposure? m_Exposure;
        private bool m_Disposed;

        public bool RequestCurrentExposure(
            Camera camera,
            Action<bool, float> completed)
        {
            if (m_Disposed ||
                camera == null ||
                completed == null)
            {
                return false;
            }

            try
            {
                HDCamera hdCamera = HDCamera.GetOrCreate(camera);
                RenderTexture? exposureTexture = GetExposureTexture(hdCamera);
                if (exposureTexture == null || !exposureTexture.IsCreated())
                {
                    return false;
                }

                AsyncGPUReadback.Request(
                    exposureTexture,
                    0,
                    request => CompleteExposureReadback(request, completed));

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool BeginFixed(float exposureEv)
        {
            if (!IsFinite(exposureEv) ||
                Mathf.Abs(exposureEv) > kMaximumAbsoluteExposureEv ||
                !EnsureVolume())
            {
                return false;
            }

            Exposure exposure = m_Exposure!;
            Volume volume = m_Volume!;

            ClearOverrides(exposure);

            // True fixed exposure is ExposureMode.Fixed + fixedExposure.
            // AdaptationMode.Fixed alone means immediate automatic adaptation in HDRP.
            exposure.mode.Override(ExposureMode.Fixed);
            exposure.fixedExposure.Override(exposureEv);

            // The captured multiplier already contains the effective compensation.
            exposure.compensation.Override(0f);

            volume.weight = 1f;
            return true;
        }

        public bool BeginProgressiveRelease(
            float speedDarkToLight,
            float speedLightToDark)
        {
            if (!EnsureVolume())
            {
                return false;
            }

            Exposure exposure = m_Exposure!;
            Volume volume = m_Volume!;

            ClearOverrides(exposure);

            // The game's lower-priority volume supplies its normal automatic mode and
            // current Day/Night EV limits. CWD overrides only the short adaptation behavior.
            exposure.adaptationMode.Override(AdaptationMode.Progressive);
            exposure.adaptationSpeedDarkToLight.Override(
                Mathf.Max(0.001f, speedDarkToLight));
            exposure.adaptationSpeedLightToDark.Override(
                Mathf.Max(0.001f, speedLightToDark));

            volume.weight = 1f;
            return true;
        }

        public void EndOverride()
        {
            if (m_Volume != null)
            {
                m_Volume.weight = 0f;
            }

            if (m_Exposure != null)
            {
                ClearOverrides(m_Exposure);
            }
        }

        public void Dispose()
        {
            if (m_Disposed)
            {
                return;
            }

            m_Disposed = true;
            EndOverride();

            if (m_Volume != null)
            {
                VolumeHelper.DestroyVolume(m_Volume);
            }

            m_Volume = null;
            m_Exposure = null;
            GC.SuppressFinalize(this);
        }

        private static RenderTexture? GetExposureTexture(HDCamera hdCamera)
        {
            FieldInfo? texturesField = s_ExposureTexturesField;
            if (texturesField == null)
            {
                return null;
            }

            object? textures = texturesField.GetValue(hdCamera);
            if (textures == null)
            {
                return null;
            }

            RTHandle? current =
                s_CurrentTextureField?.GetValue(textures) as RTHandle;
            if (current?.rt != null && current.rt.IsCreated())
            {
                return current.rt;
            }

            RTHandle? previous =
                s_PreviousTextureField?.GetValue(textures) as RTHandle;
            return previous?.rt;
        }

        private void CompleteExposureReadback(
            AsyncGPUReadbackRequest request,
            Action<bool, float> completed)
        {
            if (m_Disposed)
            {
                return;
            }

            try
            {
                if (request.hasError)
                {
                    completed(false, 0f);
                    return;
                }

                NativeArray<float> data = request.GetData<float>();
                if (data.Length < 1)
                {
                    completed(false, 0f);
                    return;
                }

                float exposureMultiplier = data[0];
                if (!IsFinite(exposureMultiplier) ||
                    exposureMultiplier <= kMinimumExposureMultiplier)
                {
                    completed(false, 0f);
                    return;
                }

                float exposureEv =
                    ColorUtils.ConvertExposureToEV100(exposureMultiplier);

                bool valid =
                    IsFinite(exposureEv) &&
                    Mathf.Abs(exposureEv) <= kMaximumAbsoluteExposureEv;

                completed(valid, valid ? exposureEv : 0f);
            }
            catch
            {
                completed(false, 0f);
            }
        }

        private bool EnsureVolume()
        {
            if (m_Disposed)
            {
                return false;
            }

            if (m_Volume != null && m_Exposure != null)
            {
                return true;
            }

            Volume? createdVolume = null;

            try
            {
                createdVolume =
                    VolumeHelper.CreateVolume(kVolumeName, kVolumePriority);
                createdVolume.isGlobal = true;
                createdVolume.weight = 0f;

                VolumeProfile profile = createdVolume.sharedProfile;
                if (!profile.TryGet(out Exposure exposure))
                {
                    exposure = profile.Add<Exposure>();
                }

                ClearOverrides(exposure);

                m_Volume = createdVolume;
                m_Exposure = exposure;
                return true;
            }
            catch
            {
                if (createdVolume != null)
                {
                    VolumeHelper.DestroyVolume(createdVolume);
                }

                m_Volume = null;
                m_Exposure = null;
                return false;
            }
        }

        private static void ClearOverrides(Exposure exposure)
        {
            exposure.mode.overrideState = false;
            exposure.fixedExposure.overrideState = false;
            exposure.compensation.overrideState = false;
            exposure.adaptationMode.overrideState = false;
            exposure.adaptationSpeedDarkToLight.overrideState = false;
            exposure.adaptationSpeedLightToDark.overrideState = false;
        }

        private static bool IsFinite(float value)
        {
            return !float.IsNaN(value) &&
                !float.IsInfinity(value);
        }
    }
}
