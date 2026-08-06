// <copyright file="DayNightControlSystem.Debug.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the MIT License. You may not use this file except in compliance with this License.
// See LICENSE file in the project root for full license information.
// This notice and the MIT License notice must be kept with
// all copies or substantial portions of this code.
// ================= </copyright> ======================

// File: Systems/Dev/DayNightControlSystem.Debug.cs
// Purpose: Passively records HDRP exposure history around Day/Night switches.

namespace CityWatchdog.Systems
{
#if DEBUG
    using System;
    using System.Globalization;
    using System.Reflection;

    using CS2Shared.RiverMochi;

    using Unity.Collections;
    using UnityEngine;
    using UnityEngine.Rendering;
    using UnityEngine.Rendering.HighDefinition;

    public partial class DayNightControlSystem
    {
        private static readonly int[] s_DebugFrameOffsets =
        {
            0,
            1,
            2,
            3,
            4,
            5,
            6,
            8,
            12,
            18,
            30,
        };

        private static readonly FieldInfo?
            s_ExposureTexturesField =
                typeof(HDCamera).GetField(
                    "m_ExposureTextures",
                    BindingFlags.Instance |
                    BindingFlags.NonPublic);

        private static readonly FieldInfo?
            s_ExposureCurrentField =
                s_ExposureTexturesField?
                    .FieldType.GetField(
                        "current",
                        BindingFlags.Instance |
                        BindingFlags.Public |
                        BindingFlags.NonPublic);

        private static readonly FieldInfo?
            s_ExposurePreviousField =
                s_ExposureTexturesField?
                    .FieldType.GetField(
                        "previous",
                        BindingFlags.Instance |
                        BindingFlags.Public |
                        BindingFlags.NonPublic);

        private static readonly FieldInfo?
            s_DidResetHistoryField =
                typeof(HDCamera).GetField(
                    "didResetPostProcessingHistoryInLastFrame",
                    BindingFlags.Instance |
                    BindingFlags.NonPublic);

        private static readonly FieldInfo?
            s_GpuExposureValueField =
                typeof(HDCamera).GetField(
                    "m_GpuExposureValue",
                    BindingFlags.Instance |
                    BindingFlags.NonPublic);

        private static readonly FieldInfo?
            s_GpuDeExposureValueField =
                typeof(HDCamera).GetField(
                    "m_GpuDeExposureValue",
                    BindingFlags.Instance |
                    BindingFlags.NonPublic);

        private int m_DebugSequence;
        private int m_DebugStartFrame;
        private int m_DebugNextOffsetIndex;
        private bool m_DebugActive;

        partial void BeginExposureDebug(
            int previousMode,
            int targetMode,
            float beforeHour,
            bool resetHistory)
        {
            m_DebugSequence++;
            m_DebugStartFrame = UnityEngine.Time.frameCount;
            m_DebugNextOffsetIndex = 0;
            m_DebugActive = true;

            LogUtils.Info(
                string.Format(
                    CultureInfo.InvariantCulture,
                    "[CWD-DN-DEBUG] BEGIN seq={0} frame={1} from={2} to={3} hour={4:F3} option={5} plannedReset={6}",
                    m_DebugSequence,
                    m_DebugStartFrame,
                    ModeName(previousMode),
                    ModeName(targetMode),
                    beforeHour,
                    ShouldUseSmootherSwitch() ? "ON" : "OFF",
                    resetHistory));

            RequestExposureDebugSample(
                m_DebugSequence,
                "before",
                -1);
        }

        partial void AdvanceExposureDebug()
        {
            if (!m_DebugActive)
            {
                return;
            }

            int relativeFrame =
                UnityEngine.Time.frameCount -
                m_DebugStartFrame;

            while (m_DebugNextOffsetIndex <
                    s_DebugFrameOffsets.Length &&
                relativeFrame >=
                    s_DebugFrameOffsets[m_DebugNextOffsetIndex])
            {
                int offset =
                    s_DebugFrameOffsets[m_DebugNextOffsetIndex];

                RequestExposureDebugSample(
                    m_DebugSequence,
                    "after",
                    offset);

                m_DebugNextOffsetIndex++;
            }

            if (m_DebugNextOffsetIndex >=
                s_DebugFrameOffsets.Length)
            {
                LogUtils.Info(
                    $"[CWD-DN-DEBUG] END seq={m_DebugSequence} frame={UnityEngine.Time.frameCount}");

                m_DebugActive = false;
            }
        }

        partial void StopExposureDebug()
        {
            m_DebugActive = false;
            m_DebugNextOffsetIndex = 0;
        }

        private void RequestExposureDebugSample(
            int sequence,
            string stage,
            int relativeFrame)
        {
            Camera? camera = GetActiveCamera();
            if (camera == null)
            {
                LogUtils.Info(
                    $"[CWD-DN-DEBUG] seq={sequence} stage={stage} rel={relativeFrame} camera=missing");
                return;
            }

            HDCamera hdCamera;
            try
            {
                hdCamera = HDCamera.GetOrCreate(camera);
            }
            catch (Exception ex)
            {
                LogUtils.Info(
                    $"[CWD-DN-DEBUG] seq={sequence} stage={stage} rel={relativeFrame} HDCamera={ex.GetType().Name}");
                return;
            }

            LogExposureDebugMeta(
                sequence,
                stage,
                relativeFrame,
                hdCamera);

            object? exposureTextures =
                s_ExposureTexturesField?.GetValue(hdCamera);

            if (exposureTextures == null)
            {
                LogUtils.Info(
                    $"[CWD-DN-DEBUG] seq={sequence} stage={stage} rel={relativeFrame} textures=missing");
                return;
            }

            RTHandle? current =
                s_ExposureCurrentField?
                    .GetValue(exposureTextures)
                    as RTHandle;

            RTHandle? previous =
                s_ExposurePreviousField?
                    .GetValue(exposureTextures)
                    as RTHandle;

            RequestExposureTextureRead(
                sequence,
                stage,
                relativeFrame,
                "current",
                current);

            RequestExposureTextureRead(
                sequence,
                stage,
                relativeFrame,
                "previous",
                previous);
        }

        private void LogExposureDebugMeta(
            int sequence,
            string stage,
            int relativeFrame,
            HDCamera hdCamera)
        {
            Exposure? exposure =
                hdCamera.volumeStack?
                    .GetComponent<Exposure>();

            bool resetRequested =
                ReadBool(
                    s_ResetPostProcessingHistoryField,
                    hdCamera);

            bool resetLastFrame =
                ReadBool(
                    s_DidResetHistoryField,
                    hdCamera);

            float gpuExposure =
                ReadFloat(
                    s_GpuExposureValueField,
                    hdCamera);

            float gpuDeExposure =
                ReadFloat(
                    s_GpuDeExposureValueField,
                    hdCamera);

            float hour =
                NormalizeHour(m_PlanetarySystem?.time ?? 0f);

            string exposureText =
                exposure == null
                    ? "Exposure=missing"
                    : string.Format(
                        CultureInfo.InvariantCulture,
                        "mode={0} adapt={1} comp={2:F3} fixedEV={3:F3} minEV={4:F3} maxEV={5:F3} LtoD={6:F3} DtoL={7:F3}",
                        exposure.mode.value,
                        exposure.adaptationMode.value,
                        exposure.compensation.value,
                        exposure.fixedExposure.value,
                        exposure.limitMin.value,
                        exposure.limitMax.value,
                        exposure.adaptationSpeedLightToDark.value,
                        exposure.adaptationSpeedDarkToLight.value);

            LogUtils.Info(
                string.Format(
                    CultureInfo.InvariantCulture,
                    "[CWD-DN-DEBUG] seq={0} stage={1} rel={2} frame={3} hour={4:F3} mode={5} override={6} resetNow={7} resetLast={8} gpuExp={9:G9} gpuDeExp={10:G9} {11}",
                    sequence,
                    stage,
                    relativeFrame,
                    UnityEngine.Time.frameCount,
                    hour,
                    ModeName(m_DayNightModeBinding.value),
                    m_PlanetarySystem?.overrideTime ?? false,
                    resetRequested,
                    resetLastFrame,
                    gpuExposure,
                    gpuDeExposure,
                    exposureText));
        }

        private static void RequestExposureTextureRead(
            int sequence,
            string stage,
            int relativeFrame,
            string textureName,
            RTHandle? handle)
        {
            RenderTexture? texture = handle?.rt;
            if (texture == null || !texture.IsCreated())
            {
                LogUtils.Info(
                    $"[CWD-DN-DEBUG] seq={sequence} stage={stage} rel={relativeFrame} tex={textureName} unavailable");
                return;
            }

            try
            {
                AsyncGPUReadback.Request(
                    texture,
                    0,
                    request =>
                        CompleteExposureTextureRead(
                            sequence,
                            stage,
                            relativeFrame,
                            textureName,
                            request));
            }
            catch (Exception ex)
            {
                LogUtils.Info(
                    $"[CWD-DN-DEBUG] seq={sequence} stage={stage} rel={relativeFrame} tex={textureName} request={ex.GetType().Name}");
            }
        }

        private static void CompleteExposureTextureRead(
            int sequence,
            string stage,
            int relativeFrame,
            string textureName,
            AsyncGPUReadbackRequest request)
        {
            if (request.hasError)
            {
                LogUtils.Info(
                    $"[CWD-DN-DEBUG] seq={sequence} stage={stage} rel={relativeFrame} tex={textureName} readback=error");
                return;
            }

            try
            {
                NativeArray<float> data =
                    request.GetData<float>();

                if (data.Length < 1)
                {
                    LogUtils.Info(
                        $"[CWD-DN-DEBUG] seq={sequence} stage={stage} rel={relativeFrame} tex={textureName} values=empty");
                    return;
                }

                float multiplier = data[0];
                string ev =
                    data.Length >= 2
                        ? data[1].ToString(
                            "G9",
                            CultureInfo.InvariantCulture)
                        : "missing";

                LogUtils.Info(
                    string.Format(
                        CultureInfo.InvariantCulture,
                        "[CWD-DN-DEBUG] seq={0} stage={1} rel={2} tex={3} multiplier={4:G9} ev={5}",
                        sequence,
                        stage,
                        relativeFrame,
                        textureName,
                        multiplier,
                        ev));
            }
            catch (Exception ex)
            {
                LogUtils.Info(
                    $"[CWD-DN-DEBUG] seq={sequence} stage={stage} rel={relativeFrame} tex={textureName} parse={ex.GetType().Name}");
            }
        }

        private static bool ReadBool(
            FieldInfo? field,
            object target)
        {
            return
                field?.GetValue(target)
                    is bool value &&
                value;
        }

        private static float ReadFloat(
            FieldInfo? field,
            object target)
        {
            return
                field?.GetValue(target)
                    is float value
                        ? value
                        : float.NaN;
        }
    }
#endif
}
