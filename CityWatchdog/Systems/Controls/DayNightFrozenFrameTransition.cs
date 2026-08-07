// <copyright file="DayNightFrozenFrameTransition.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the MIT License. You may not use this file except in compliance with this License.
// See LICENSE file in the project root for full license information.
// This notice and the MIT License notice must be kept with
// all copies or substantial portions of this code.
// ================= </copyright> ======================

// File: Systems/Controls/DayNightFrozenFrameTransition.cs
// Purpose: P1.3 test. Hold the last clean Day frame until Night exposure is safely recovering.

namespace CityWatchdog.Systems
{
    using System;
    using System.Reflection;

    using CS2Shared.RiverMochi;

    using UnityEngine;
    using UnityEngine.Rendering;
    using UnityEngine.Rendering.HighDefinition;

    internal static class DayNightFrozenFrameTransition
    {
        private const string kGpuExposureValueMethodName =
            "GpuExposureValue";

        // Keep the proven P1.2 minimum cover even on a very fast PC.
        private const double kMinimumHoldSeconds = 0.30d;

        // Render-count floor matters when a slow PC produces very few frames in 0.30 sec.
        private const int kMinimumOverlayFrames = 6;

        // Night limitMax is EV 6. A normal Night exposure multiplier should therefore
        // recover to roughly this range or brighter before we even consider releasing.
        private const float kMinimumNightExposure = 0.012f;

        // Require exposure to stop changing rapidly for several rendered samples.
        private const float kStableRelativeChange = 0.12f;
        private const int kStableSamplesRequired = 3;

        // Emergency guard only. It still requires a minimum number of rendered frames.
        private const double kEmergencyHoldSeconds = 5d;
        private const int kEmergencyMinimumOverlayFrames = 8;

        private static readonly MethodInfo? s_GpuExposureValueMethod =
            typeof(HDCamera).GetMethod(
                kGpuExposureValueMethodName,
                BindingFlags.Instance |
                BindingFlags.NonPublic |
                BindingFlags.Public);

        private static RenderTexture? s_FrozenDay;
        private static Camera? s_TargetCamera;

        private static bool s_Initialized;

        private static bool s_CaptureRequested;
        private static bool s_CaptureReady;
        private static int s_CaptureToken;

        private static bool s_HoldActive;
        private static int s_HoldToken;
        private static double s_HoldStarted;
        private static int s_OverlayFrames;
        private static bool s_LoggedFirstOverlay;

        private static bool s_HasLastGpuExposure;
        private static float s_LastGpuExposure;
        private static int s_StableSamples;
        private static bool s_LoggedExposureUnavailable;

        internal static void Initialize()
        {
            if (s_Initialized)
            {
                return;
            }

            RenderPipelineManager.endCameraRendering +=
                OnEndCameraRendering;

            s_Initialized = true;
        }

        internal static void RequestDayCapture(
            int token)
        {
            Initialize();

            Camera? camera =
                Camera.main;

            if (camera == null)
            {
                LogUtils.WarnOnce(
                    "day-night-frozen-frame-camera-missing",
                    () =>
                        "Day/Night frozen-frame capture could not start because the main game camera was unavailable.");
                return;
            }

            s_TargetCamera = camera;

            s_CaptureToken = token;
            s_CaptureRequested = true;
            s_CaptureReady = false;

            ResetHoldState();

#if DEBUG
            LogUtils.Info(
                $"[CWD-DN-P1.3] Day capture requested token={token}");
#endif
        }

        internal static bool IsDayCaptureReady(
            int token)
        {
            return
                s_CaptureReady &&
                s_CaptureToken == token;
        }

        internal static bool BeginHold(
            int token)
        {
            if (!IsDayCaptureReady(token) ||
                s_FrozenDay == null)
            {
                LogUtils.WarnOnce(
                    $"day-night-frozen-frame-not-ready-{token}",
                    () =>
                        $"Day/Night frozen Day frame was not ready for token={token}.");
                return false;
            }

            s_HoldToken = token;
            s_HoldStarted =
                Time.unscaledTimeAsDouble;
            s_HoldActive = true;
            s_OverlayFrames = 0;
            s_LoggedFirstOverlay = false;

            s_HasLastGpuExposure = false;
            s_LastGpuExposure = 0f;
            s_StableSamples = 0;

#if DEBUG
            LogUtils.Info(
                $"[CWD-DN-P1.3] hold begin token={token} minSeconds={kMinimumHoldSeconds:F3} minFrames={kMinimumOverlayFrames}");
#endif

            return true;
        }

        internal static void CancelPendingCapture(
            int token)
        {
            if (s_CaptureToken != token ||
                s_HoldActive)
            {
                return;
            }

            s_CaptureRequested = false;
            s_CaptureReady = false;
        }

        // A player may click Day/Default again while the hidden Night transition is
        // still settling. Stop replaying the old frame as soon as that new mode applies.
        internal static void CancelActiveHold()
        {
            if (!s_HoldActive)
            {
                return;
            }

#if DEBUG
            LogUtils.Info(
                $"[CWD-DN-P1.3] hold canceled token={s_HoldToken} overlayFrames={s_OverlayFrames}");
#endif

            ResetHoldState();
            s_CaptureReady = false;
        }

        internal static void Shutdown()
        {
            if (s_Initialized)
            {
                RenderPipelineManager.endCameraRendering -=
                    OnEndCameraRendering;

                s_Initialized = false;
            }

            s_CaptureRequested = false;
            s_CaptureReady = false;
            s_TargetCamera = null;

            ResetHoldState();
            ReleaseFrozenTarget();
        }

        private static void OnEndCameraRendering(
            ScriptableRenderContext context,
            Camera camera)
        {
            if ((!s_CaptureRequested &&
                 !s_HoldActive) ||
                s_TargetCamera == null ||
                camera != s_TargetCamera ||
                camera.cameraType != CameraType.Game)
            {
                return;
            }

            if (s_CaptureRequested)
            {
                CaptureCleanDayFrame(
                    context,
                    camera);
                return;
            }

            if (!s_HoldActive ||
                s_FrozenDay == null)
            {
                return;
            }

            double elapsed =
                Time.unscaledTimeAsDouble -
                s_HoldStarted;

            bool exposureAvailable =
                TryGetGpuExposure(
                    camera,
                    out float gpuExposure);

            float relativeChange =
                UpdateExposureStability(
                    exposureAvailable,
                    gpuExposure);

            bool minimumCoverComplete =
                elapsed >= kMinimumHoldSeconds &&
                s_OverlayFrames >= kMinimumOverlayFrames;

            bool safeExposureState =
                exposureAvailable &&
                gpuExposure >= kMinimumNightExposure &&
                s_StableSamples >= kStableSamplesRequired;

            if (minimumCoverComplete &&
                safeExposureState)
            {
                EndHold(
                    "safe",
                    elapsed,
                    gpuExposure,
                    relativeChange);
                return;
            }

            bool emergencyRelease =
                elapsed >= kEmergencyHoldSeconds &&
                s_OverlayFrames >= kEmergencyMinimumOverlayFrames;

            if (emergencyRelease)
            {
                EndHold(
                    "emergency",
                    elapsed,
                    gpuExposure,
                    relativeChange);
                return;
            }

#if DEBUG
            if (s_OverlayFrames == 6 ||
                s_OverlayFrames == 12 ||
                s_OverlayFrames == 18 ||
                s_OverlayFrames == 24)
            {
                LogUtils.Info(
                    $"[CWD-DN-P1.3] state token={s_HoldToken} elapsed={elapsed:F3}s frames={s_OverlayFrames} gpuExp={(exposureAvailable ? gpuExposure : -1f):G9} relDelta={relativeChange:F3} stable={s_StableSamples}/{kStableSamplesRequired}");
            }
#endif

            ReplayFrozenDay(
                context);

            s_OverlayFrames++;

#if DEBUG
            if (!s_LoggedFirstOverlay)
            {
                s_LoggedFirstOverlay = true;

                LogUtils.Info(
                    $"[CWD-DN-P1.3] first final-camera overlay token={s_HoldToken} unityFrame={Time.frameCount}");
            }
#endif
        }

        private static void CaptureCleanDayFrame(
            ScriptableRenderContext context,
            Camera camera)
        {
            EnsureFrozenTarget(
                camera);

            if (s_FrozenDay == null)
            {
                return;
            }

            CommandBuffer commandBuffer =
                CommandBufferPool.Get(
                    "CWD DayNight capture clean Day");

            try
            {
                commandBuffer.Blit(
                    BuiltinRenderTextureType.CameraTarget,
                    new RenderTargetIdentifier(
                        s_FrozenDay));

                context.ExecuteCommandBuffer(
                    commandBuffer);
            }
            finally
            {
                CommandBufferPool.Release(
                    commandBuffer);
            }

            s_CaptureRequested = false;
            s_CaptureReady = true;

#if DEBUG
            LogUtils.Info(
                $"[CWD-DN-P1.3] Day captured token={s_CaptureToken} unityFrame={Time.frameCount} size={s_FrozenDay.width}x{s_FrozenDay.height}");
#endif
        }

        private static void ReplayFrozenDay(
            ScriptableRenderContext context)
        {
            if (s_FrozenDay == null)
            {
                return;
            }

            CommandBuffer commandBuffer =
                CommandBufferPool.Get(
                    "CWD DayNight show frozen Day");

            try
            {
                // CameraTarget and our RenderTexture use opposite vertical orientation here.
                commandBuffer.Blit(
                    new RenderTargetIdentifier(
                        s_FrozenDay),
                    new RenderTargetIdentifier(
                        BuiltinRenderTextureType.CameraTarget),
                    new Vector2(
                        1f,
                        -1f),
                    new Vector2(
                        0f,
                        1f));

                context.ExecuteCommandBuffer(
                    commandBuffer);
            }
            finally
            {
                CommandBufferPool.Release(
                    commandBuffer);
            }
        }

        private static float UpdateExposureStability(
            bool exposureAvailable,
            float gpuExposure)
        {
            if (!exposureAvailable)
            {
                s_HasLastGpuExposure = false;
                s_StableSamples = 0;
                return float.PositiveInfinity;
            }

            if (!s_HasLastGpuExposure)
            {
                s_HasLastGpuExposure = true;
                s_LastGpuExposure = gpuExposure;
                s_StableSamples = 0;
                return float.PositiveInfinity;
            }

            float denominator =
                Mathf.Max(
                    Mathf.Max(
                        Mathf.Abs(gpuExposure),
                        Mathf.Abs(s_LastGpuExposure)),
                    kMinimumNightExposure);

            float relativeChange =
                Mathf.Abs(
                    gpuExposure -
                    s_LastGpuExposure) /
                denominator;

            if (gpuExposure >= kMinimumNightExposure &&
                relativeChange <= kStableRelativeChange)
            {
                s_StableSamples++;
            }
            else
            {
                s_StableSamples = 0;
            }

            s_LastGpuExposure = gpuExposure;

            return relativeChange;
        }

        private static bool TryGetGpuExposure(
            Camera camera,
            out float gpuExposure)
        {
            gpuExposure = 0f;

            MethodInfo? method =
                s_GpuExposureValueMethod;

            if (method == null)
            {
                LogExposureUnavailableOnce(
                    $"HDRP method '{kGpuExposureValueMethodName}' was not found.");
                return false;
            }

            try
            {
                HDCamera hdCamera =
                    HDCamera.GetOrCreate(
                        camera);

                object? value =
                    method.Invoke(
                        hdCamera,
                        null);

                if (value is not float exposure ||
                    exposure <= 0f ||
                    float.IsNaN(exposure) ||
                    float.IsInfinity(exposure))
                {
                    return false;
                }

                gpuExposure = exposure;
                return true;
            }
            catch (Exception ex)
            {
                LogExposureUnavailableOnce(
                    $"HDRP exposure state read failed: {ex.GetType().Name}: {ex.Message}");
                return false;
            }
        }

        private static void LogExposureUnavailableOnce(
            string message)
        {
            if (s_LoggedExposureUnavailable)
            {
                return;
            }

            s_LoggedExposureUnavailable = true;

            LogUtils.WarnOnce(
                "day-night-p13-gpu-exposure-unavailable",
                () =>
                    $"Day/Night adaptive hold cannot read current HDRP exposure. {message} " +
                    $"P1.3 will keep the frozen frame until its emergency guard.");
        }

        private static void EndHold(
            string reason,
            double elapsed,
            float gpuExposure,
            float relativeChange)
        {
            int token =
                s_HoldToken;

            int overlayFrames =
                s_OverlayFrames;

            int stableSamples =
                s_StableSamples;

            ResetHoldState();
            s_CaptureReady = false;

#if DEBUG
            LogUtils.Info(
                $"[CWD-DN-P1.3] hold end reason={reason} token={token} elapsed={elapsed:F3}s overlayFrames={overlayFrames} gpuExp={gpuExposure:G9} relDelta={relativeChange:F3} stable={stableSamples}/{kStableSamplesRequired}");
#endif
        }

        private static void ResetHoldState()
        {
            s_HoldActive = false;
            s_HoldToken = 0;
            s_HoldStarted = 0d;
            s_OverlayFrames = 0;
            s_LoggedFirstOverlay = false;

            s_HasLastGpuExposure = false;
            s_LastGpuExposure = 0f;
            s_StableSamples = 0;
        }

        private static void EnsureFrozenTarget(
            Camera camera)
        {
            int width =
                Math.Max(
                    1,
                    camera.pixelWidth);

            int height =
                Math.Max(
                    1,
                    camera.pixelHeight);

            if (s_FrozenDay != null &&
                s_FrozenDay.width == width &&
                s_FrozenDay.height == height)
            {
                return;
            }

            ReleaseFrozenTarget();

            s_FrozenDay =
                new RenderTexture(
                    width,
                    height,
                    0,
                    RenderTextureFormat.Default,
                    RenderTextureReadWrite.Default)
                {
                    name = "CWD-DayNight-FrozenDay-FinalCamera",
                    filterMode = FilterMode.Bilinear,
                    wrapMode = TextureWrapMode.Clamp,
                    hideFlags = HideFlags.HideAndDontSave,
                };

            s_FrozenDay.Create();
        }

        private static void ReleaseFrozenTarget()
        {
            if (s_FrozenDay == null)
            {
                return;
            }

            s_FrozenDay.Release();

            UnityEngine.Object.Destroy(
                s_FrozenDay);

            s_FrozenDay = null;
        }
    }
}
