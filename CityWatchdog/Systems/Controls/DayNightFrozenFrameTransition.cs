// <copyright file="DayNightFrozenFrameTransition.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the MIT License. You may not use this file except in compliance with this License.
// See LICENSE file in the project root for full license information.
// This notice and the MIT License notice must be kept with
// all copies or substantial portions of this code.
// ================= </copyright> ======================

// File: Systems/Controls/DayNightFrozenFrameTransition.cs
// Purpose: P1.1 test. Hold the last clean Day camera result at endCameraRendering.

namespace CityWatchdog.Systems
{
    using CS2Shared.RiverMochi;

    using UnityEngine;
    using UnityEngine.Rendering;

    internal static class DayNightFrozenFrameTransition
    {
        // First prove the clean Day frame can cover the unstable Night frames.
        // If this works, the next test can replace the hard release with a crossfade.
        private const double kHoldSeconds = 0.30d;

        private static RenderTexture? s_FrozenDay;
        private static Camera? s_TargetCamera;

        private static bool s_Initialized;

        private static bool s_CaptureRequested;
        private static bool s_CaptureReady;
        private static int s_CaptureToken;

        private static bool s_HoldActive;
        private static int s_HoldToken;
        private static double s_HoldStarted;
        private static double s_HoldUntil;
        private static int s_OverlayFrames;
        private static bool s_LoggedFirstOverlay;

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

            s_HoldActive = false;
            s_HoldToken = 0;
            s_HoldStarted = 0d;
            s_HoldUntil = 0d;
            s_OverlayFrames = 0;
            s_LoggedFirstOverlay = false;

#if DEBUG
            LogUtils.Info(
                $"[CWD-DN-P1.1] Day capture requested token={token}");
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
            s_HoldUntil =
                s_HoldStarted +
                kHoldSeconds;
            s_HoldActive = true;
            s_OverlayFrames = 0;
            s_LoggedFirstOverlay = false;

#if DEBUG
            LogUtils.Info(
                $"[CWD-DN-P1.1] hold begin token={token} seconds={kHoldSeconds:F3}");
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
            s_HoldActive = false;
            s_TargetCamera = null;

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
                    // P1 wrote inside HDRP, but later rendering still changed the displayed frame.
                    // P1.1 copies the finished main-camera target instead.
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
                    $"[CWD-DN-P1.1] Day captured token={s_CaptureToken} unityFrame={Time.frameCount} size={s_FrozenDay.width}x{s_FrozenDay.height}");
#endif

                return;
            }

            double now =
                Time.unscaledTimeAsDouble;

            if (now >= s_HoldUntil)
            {
                int token =
                    s_HoldToken;

                double elapsed =
                    now -
                    s_HoldStarted;

                int overlayFrames =
                    s_OverlayFrames;

                s_HoldActive = false;
                s_HoldToken = 0;
                s_CaptureReady = false;

#if DEBUG
                LogUtils.Info(
                    $"[CWD-DN-P1.1] hold end token={token} elapsed={elapsed:F3}s overlayFrames={overlayFrames}");
#endif

                return;
            }

            if (s_FrozenDay == null)
            {
                return;
            }

            CommandBuffer holdCommandBuffer =
                CommandBufferPool.Get(
                    "CWD DayNight show frozen Day");

            try
            {
                // This callback is after HDRP finishes this camera.
                holdCommandBuffer.Blit(
                    new RenderTargetIdentifier(
                        s_FrozenDay),
                    BuiltinRenderTextureType.CameraTarget);

                context.ExecuteCommandBuffer(
                    holdCommandBuffer);
            }
            finally
            {
                CommandBufferPool.Release(
                    holdCommandBuffer);
            }

            s_OverlayFrames++;

#if DEBUG
            if (!s_LoggedFirstOverlay)
            {
                s_LoggedFirstOverlay = true;

                LogUtils.Info(
                    $"[CWD-DN-P1.1] first final-camera overlay token={s_HoldToken} unityFrame={Time.frameCount}");
            }
#endif
        }

        private static void EnsureFrozenTarget(
            Camera camera)
        {
            int width =
                System.Math.Max(
                    1,
                    camera.pixelWidth);

            int height =
                System.Math.Max(
                    1,
                    camera.pixelHeight);

            if (s_FrozenDay != null &&
                s_FrozenDay.width == width &&
                s_FrozenDay.height == height)
            {
                return;
            }

            ReleaseFrozenTarget();

            // Store the finished camera image rather than the HDR scene-radiance buffer.
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

