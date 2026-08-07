// <copyright file="DayNightR2RenderCapture.Debug.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the MIT License. You may not use this file except in compliance with this License.
// See LICENSE file in the project root for full license information.
// This notice and the MIT License notice must be kept with
// all copies or substantial portions of this code.
// ================= </copyright> ======================

// File: Systems/Controls/DayNightR2RenderCapture.Debug.cs
// Purpose: R2 Debug diagnostic. Captures the E2A Day -> Night frames
// before and after HDRP post-processing for direct comparison with R1.

#if DEBUG

namespace CityWatchdog.Systems
{
    using System;
    using System.IO;
    using System.Threading.Tasks;

    using CS2Shared.RiverMochi;

    using UnityEngine;
    using UnityEngine.Experimental.Rendering;
    using UnityEngine.Rendering;
    using UnityEngine.Rendering.HighDefinition;

    internal enum DayNightR2CaptureStage
    {
        BeforePostProcess = 0,
        AfterPostProcess = 1,
    }

    internal sealed class DayNightR2CapturePass : CustomPass
    {
        private readonly DayNightR2CaptureStage m_Stage;

        internal DayNightR2CapturePass(
            DayNightR2CaptureStage stage)
        {
            m_Stage = stage;
        }

        protected override void Execute(
            CustomPassContext ctx)
        {
            DayNightR2RenderCapture.TryCapture(
                m_Stage,
                ctx);
        }
    }

    internal static class DayNightR2RenderCapture
    {
        // Six rendered frames match R1 so E2A and E2B can be compared directly.
        private const int kCaptureFrameCount = 6;

        // Small diagnostic copies keep disk/readback cost low and do not resize the game camera.
        private const int kCaptureWidth = 480;
        private const float kVolumePriority = 5000f;

        private static readonly bool[] s_BeforeScheduled =
            new bool[kCaptureFrameCount];

        private static readonly bool[] s_AfterScheduled =
            new bool[kCaptureFrameCount];

        private static CustomPassVolume? s_BeforeVolume;
        private static CustomPassVolume? s_AfterVolume;

        private static RenderTexture? s_BeforeTarget;
        private static RenderTexture? s_AfterTarget;

        private static RTHandle? s_BeforeTargetHandle;
        private static RTHandle? s_AfterTargetHandle;

        private static Camera? s_TargetCamera;

        private static bool s_Active;
        private static int s_Token;
        private static int s_FirstUnityFrame = -1;
        private static string? s_RunFolder;

        internal static void Initialize()
        {
            EnsureVolumes();
        }

        internal static void Begin(
            int token)
        {
            EnsureVolumes();

            Camera? camera = Camera.main;
            if (camera == null ||
                s_BeforeVolume == null ||
                s_AfterVolume == null)
            {
                LogUtils.WarnOnce(
                    "day-night-r2-camera-missing",
                    () =>
                        "R2 render capture could not start because the main game camera or HDRP capture volumes were unavailable.");
                return;
            }

            s_TargetCamera = camera;
            s_BeforeVolume.targetCamera = camera;
            s_AfterVolume.targetCamera = camera;

            Array.Clear(
                s_BeforeScheduled,
                0,
                s_BeforeScheduled.Length);

            Array.Clear(
                s_AfterScheduled,
                0,
                s_AfterScheduled.Length);

            s_Token = token;
            s_FirstUnityFrame = -1;
            s_Active = true;

            string rootFolder =
                Path.Combine(
                    Application.persistentDataPath,
                    "ModsData",
                    Mod.ModId,
                    "R2");

            string runName =
                $"{DateTime.Now:yyyyMMdd_HHmmss_fff}_token{token:D3}";

            s_RunFolder =
                Path.Combine(
                    rootFolder,
                    runName);

            Directory.CreateDirectory(
                s_RunFolder);

            WriteRunInfo(
                s_RunFolder,
                token);

            LogUtils.Info(
                $"[CWD-DN-R2] begin token={token} frames={kCaptureFrameCount} width={kCaptureWidth} folder={s_RunFolder}");
        }

        internal static void Shutdown()
        {
            s_Active = false;
            s_FirstUnityFrame = -1;
            s_RunFolder = null;
            s_TargetCamera = null;

            ReleaseTarget(
                ref s_BeforeTarget,
                ref s_BeforeTargetHandle);

            ReleaseTarget(
                ref s_AfterTarget,
                ref s_AfterTargetHandle);

            DestroyVolume(
                ref s_BeforeVolume);

            DestroyVolume(
                ref s_AfterVolume);
        }

        internal static void TryCapture(
            DayNightR2CaptureStage stage,
            CustomPassContext ctx)
        {
            if (!s_Active ||
                s_RunFolder == null)
            {
                return;
            }

            Camera? camera =
                ctx.hdCamera?.camera;

            if (camera == null ||
                camera.cameraType != CameraType.Game ||
                s_TargetCamera == null ||
                camera != s_TargetCamera)
            {
                return;
            }

            int unityFrame =
                Time.frameCount;

            if (s_FirstUnityFrame < 0)
            {
                s_FirstUnityFrame =
                    unityFrame;
            }

            int captureIndex =
                unityFrame -
                s_FirstUnityFrame;

            if (captureIndex < 0)
            {
                return;
            }

            if (captureIndex >=
                kCaptureFrameCount)
            {
                s_Active = false;
                return;
            }

            bool[] scheduled =
                stage == DayNightR2CaptureStage.BeforePostProcess
                    ? s_BeforeScheduled
                    : s_AfterScheduled;

            if (scheduled[captureIndex])
            {
                return;
            }

            RTHandle? source =
                ctx.cameraColorBuffer;

            if (source == null ||
                source.rt == null)
            {
                return;
            }

            if (!EnsureCaptureTarget(
                    stage,
                    camera,
                    out RenderTexture? target,
                    out RTHandle? targetHandle) ||
                target == null ||
                targetHandle == null)
            {
                return;
            }

            scheduled[captureIndex] = true;

            HDUtils.BlitCameraTexture(
                ctx.cmd,
                source,
                targetHandle);

            string stageName =
                stage == DayNightR2CaptureStage.BeforePostProcess
                    ? "before"
                    : "after";

            string fileName =
                $"f{captureIndex:D2}_uf{unityFrame}_{stageName}_{target.width}x{target.height}_rgba16f.raw";

            string filePath =
                Path.Combine(
                    s_RunFolder,
                    fileName);

            int width =
                target.width;

            int height =
                target.height;

            GraphicsFormat sourceFormat =
                source.rt.graphicsFormat;

            int token = s_Token;

            ctx.cmd.RequestAsyncReadback(
                target,
                request =>
                {
                    if (request.hasError)
                    {
                        LogUtils.WarnOnce(
                            $"day-night-r2-readback-{token}-{captureIndex}-{stageName}",
                            () =>
                                $"R1 GPU readback failed for token={token} frame={captureIndex} stage={stageName}.");
                        return;
                    }

                    var nativeData =
                        request.GetData<byte>();

                    byte[] bytes =
                        new byte[nativeData.Length];

                    nativeData.CopyTo(
                        bytes);

                    // Disk I/O is background-only so it does not disturb the captured frames.
                    _ = Task.Run(
                        () =>
                        {
                            try
                            {
                                File.WriteAllBytes(
                                    filePath,
                                    bytes);
                            }
                            catch (Exception ex)
                            {
                                string errorPath =
                                    filePath +
                                    ".error.txt";

                                try
                                {
                                    File.WriteAllText(
                                        errorPath,
                                        $"{ex.GetType().Name}: {ex.Message}");
                                }
                                catch
                                {
                                    // R1 is diagnostic-only. Avoid throwing from a background task.
                                }
                            }
                        });
                });

            LogUtils.Info(
                $"[CWD-DN-R2] queued token={token} index={captureIndex} unityFrame={unityFrame} stage={stageName} size={width}x{height} sourceFormat={sourceFormat} file={fileName}");

            if (captureIndex ==
                    kCaptureFrameCount - 1 &&
                s_BeforeScheduled[captureIndex] &&
                s_AfterScheduled[captureIndex])
            {
                s_Active = false;

                LogUtils.Info(
                    $"[CWD-DN-R2] capture queued token={token} frames={kCaptureFrameCount} folder={s_RunFolder}");
            }
        }

        private static void EnsureVolumes()
        {
            Camera? camera =
                Camera.main;

            if (s_BeforeVolume == null)
            {
                s_BeforeVolume =
                    CreateVolume(
                        "CWD-R2-BeforePostProcess",
                        CustomPassInjectionPoint.BeforePostProcess,
                        DayNightR2CaptureStage.BeforePostProcess,
                        camera);
            }
            else if (camera != null)
            {
                s_BeforeVolume.targetCamera =
                    camera;
            }

            if (s_AfterVolume == null)
            {
                s_AfterVolume =
                    CreateVolume(
                        "CWD-R2-AfterPostProcess",
                        CustomPassInjectionPoint.AfterPostProcess,
                        DayNightR2CaptureStage.AfterPostProcess,
                        camera);
            }
            else if (camera != null)
            {
                s_AfterVolume.targetCamera =
                    camera;
            }
        }

        private static CustomPassVolume CreateVolume(
            string name,
            CustomPassInjectionPoint injectionPoint,
            DayNightR2CaptureStage stage,
            Camera? targetCamera)
        {
            GameObject gameObject =
                new(name);

            gameObject.hideFlags =
                HideFlags.HideAndDontSave;

            CustomPassVolume volume =
                gameObject.AddComponent<CustomPassVolume>();

            volume.isGlobal = true;
            volume.priority =
                kVolumePriority;
            volume.injectionPoint =
                injectionPoint;

            if (targetCamera != null)
            {
                volume.targetCamera =
                    targetCamera;
            }

            volume.customPasses.Add(
                new DayNightR2CapturePass(
                    stage));

            return volume;
        }

        private static bool EnsureCaptureTarget(
            DayNightR2CaptureStage stage,
            Camera camera,
            out RenderTexture? target,
            out RTHandle? targetHandle)
        {
            int cameraWidth =
                Math.Max(
                    1,
                    camera.pixelWidth);

            int cameraHeight =
                Math.Max(
                    1,
                    camera.pixelHeight);

            int width =
                Math.Min(
                    kCaptureWidth,
                    cameraWidth);

            int height =
                Math.Max(
                    1,
                    Mathf.RoundToInt(
                        width *
                        ((float)cameraHeight /
                         cameraWidth)));

            if (stage ==
                DayNightR2CaptureStage.BeforePostProcess)
            {
                EnsureTarget(
                    "CWD-R2-BeforeTarget",
                    width,
                    height,
                    ref s_BeforeTarget,
                    ref s_BeforeTargetHandle);

                target =
                    s_BeforeTarget;

                targetHandle =
                    s_BeforeTargetHandle;
            }
            else
            {
                EnsureTarget(
                    "CWD-R2-AfterTarget",
                    width,
                    height,
                    ref s_AfterTarget,
                    ref s_AfterTargetHandle);

                target =
                    s_AfterTarget;

                targetHandle =
                    s_AfterTargetHandle;
            }

            return
                target != null &&
                targetHandle != null;
        }

        private static void EnsureTarget(
            string name,
            int width,
            int height,
            ref RenderTexture? target,
            ref RTHandle? targetHandle)
        {
            if (target != null &&
                targetHandle != null &&
                target.width == width &&
                target.height == height)
            {
                return;
            }

            ReleaseTarget(
                ref target,
                ref targetHandle);

            target =
                new RenderTexture(
                    width,
                    height,
                    0,
                    GraphicsFormat.R16G16B16A16_SFloat)
                {
                    name = name,
                    filterMode = FilterMode.Bilinear,
                    wrapMode = TextureWrapMode.Clamp,
                    hideFlags = HideFlags.HideAndDontSave,
                };

            target.Create();

            targetHandle =
                RTHandles.Alloc(
                    target);
        }

        private static void ReleaseTarget(
            ref RenderTexture? target,
            ref RTHandle? targetHandle)
        {
            if (targetHandle != null)
            {
                targetHandle.Release();
                targetHandle = null;
            }

            if (target != null)
            {
                target.Release();
                UnityEngine.Object.Destroy(
                    target);
                target = null;
            }
        }

        private static void DestroyVolume(
            ref CustomPassVolume? volume)
        {
            if (volume == null)
            {
                return;
            }

            GameObject gameObject =
                volume.gameObject;

            volume = null;

            if (gameObject != null)
            {
                UnityEngine.Object.Destroy(
                    gameObject);
            }
        }

        private static void WriteRunInfo(
            string folder,
            int token)
        {
            string info =
                "City Watchdog R2 HDR buffer diagnostic\n" +
                $"Token: {token}\n" +
                $"Frames: {kCaptureFrameCount}\n" +
                $"Target width: {kCaptureWidth}\n" +
                "Capture A: HDRP CustomPassInjectionPoint.BeforePostProcess\n" +
                "Capture B: HDRP CustomPassInjectionPoint.AfterPostProcess\n" +
                "Pixel format: little-endian R16G16B16A16_SFloat (RGBA half-float)\n" +
                "File names include capture index, Unity frame, stage, and dimensions.\n" +
                "The game camera, targetTexture, dynamic resolution, and RTHandle reference size are NOT changed.\n";

            File.WriteAllText(
                Path.Combine(
                    folder,
                    "R2-info.txt"),
                info);
        }
    }
}

#endif
