// <copyright file="DayNightFrozenFrameTransition.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the MIT License. You may not use this file except in compliance with this License.
// See LICENSE file in the project root for full license information.
// This notice and the MIT License notice must be kept with
// all copies or substantial portions of this code.
// ================= </copyright> ======================

// File: Systems/Controls/DayNightFrozenFrameTransition.cs
// Purpose: P1 test. Hold the last clean Day camera frame while Night settles.

namespace CityWatchdog.Systems
{
    using System;

    using CS2Shared.RiverMochi;

    using UnityEngine;
    using UnityEngine.Experimental.Rendering;
    using UnityEngine.Rendering;
    using UnityEngine.Rendering.HighDefinition;

    internal sealed class DayNightFrozenFramePass : CustomPass
    {
        protected override void Execute(
            CustomPassContext ctx)
        {
            DayNightFrozenFrameTransition.Execute(
                ctx);
        }
    }

    internal static class DayNightFrozenFrameTransition
    {
        // P1 only: first prove that hiding the unstable frames removes the visible artifacts.
        // If this works, the next test can replace the hard release with a short crossfade.
        private const double kHoldSeconds = 0.30d;

        // CustomPassVolume executes higher priorities first. A very low priority keeps
        // this copy late among other passes at the same AfterPostProcess injection point.
        private const float kVolumePriority = -10000f;

        private static CustomPassVolume? s_Volume;

        private static RenderTexture? s_FrozenDay;
        private static RTHandle? s_FrozenDayHandle;
        private static GraphicsFormat s_FrozenFormat = GraphicsFormat.None;

        private static Camera? s_TargetCamera;

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
            EnsureVolume();
        }

        internal static void RequestDayCapture(
            int token)
        {
            EnsureVolume();

            Camera? camera =
                Camera.main;

            if (camera == null ||
                s_Volume == null)
            {
                LogUtils.WarnOnce(
                    "day-night-frozen-frame-camera-missing",
                    () =>
                        "Day/Night frozen-frame capture could not start because the main game camera was unavailable.");
                return;
            }

            s_TargetCamera = camera;
            s_Volume.targetCamera = camera;

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
                $"[CWD-DN-P1] Day capture requested token={token}");
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
                s_FrozenDayHandle == null)
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
                $"[CWD-DN-P1] hold begin token={token} seconds={kHoldSeconds:F3}");
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
            s_CaptureRequested = false;
            s_CaptureReady = false;
            s_HoldActive = false;
            s_TargetCamera = null;

            ReleaseFrozenTarget();
            DestroyVolume();
        }

        internal static void Execute(
            CustomPassContext ctx)
        {
            // Idle cost is just this branch when no transition is active.
            if (!s_CaptureRequested &&
                !s_HoldActive)
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

            RTHandle? cameraColor =
                ctx.cameraColorBuffer;

            if (cameraColor == null ||
                cameraColor.rt == null)
            {
                return;
            }

            if (s_CaptureRequested)
            {
                GraphicsFormat format =
                    cameraColor.rt.graphicsFormat;

                EnsureFrozenTarget(
                    camera,
                    format);

                if (s_FrozenDayHandle == null)
                {
                    return;
                }

                // Capture the final clean Day world frame on the GPU.
                HDUtils.BlitCameraTexture(
                    ctx.cmd,
                    cameraColor,
                    s_FrozenDayHandle);

                s_CaptureRequested = false;
                s_CaptureReady = true;

#if DEBUG
                LogUtils.Info(
                    $"[CWD-DN-P1] Day captured token={s_CaptureToken} unityFrame={Time.frameCount} size={s_FrozenDay?.width}x{s_FrozenDay?.height} format={format}");
#endif

                // This is still the normal Day frame. Do not overlay it onto itself.
                return;
            }

            if (!s_HoldActive ||
                s_FrozenDayHandle == null)
            {
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
                    $"[CWD-DN-P1] hold end token={token} elapsed={elapsed:F3}s overlayFrames={overlayFrames}");
#endif

                // Let this frame show the now-settled live Night scene.
                return;
            }

            // Replace only the 3D camera result; later UI rendering can remain live.
            HDUtils.BlitCameraTexture(
                ctx.cmd,
                s_FrozenDayHandle,
                cameraColor);

            s_OverlayFrames++;

#if DEBUG
            if (!s_LoggedFirstOverlay)
            {
                s_LoggedFirstOverlay = true;

                LogUtils.Info(
                    $"[CWD-DN-P1] first frozen overlay token={s_HoldToken} unityFrame={Time.frameCount}");
            }
#endif
        }

        private static void EnsureVolume()
        {
            if (s_Volume != null)
            {
                return;
            }

            GameObject gameObject =
                new("CWD-DayNight-FrozenFrame");

            gameObject.hideFlags =
                HideFlags.HideAndDontSave;

            CustomPassVolume volume =
                gameObject.AddComponent<CustomPassVolume>();

            volume.isGlobal = true;
            volume.priority =
                kVolumePriority;
            volume.injectionPoint =
                CustomPassInjectionPoint.AfterPostProcess;

            Camera? camera =
                Camera.main;

            if (camera != null)
            {
                volume.targetCamera =
                    camera;
            }

            volume.customPasses.Add(
                new DayNightFrozenFramePass());

            s_Volume = volume;
        }

        private static void EnsureFrozenTarget(
            Camera camera,
            GraphicsFormat format)
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
                s_FrozenDayHandle != null &&
                s_FrozenDay.width == width &&
                s_FrozenDay.height == height &&
                s_FrozenFormat == format)
            {
                return;
            }

            ReleaseFrozenTarget();

            // Match the camera buffer format so the held frame stays as close as possible
            // to the actual clean Day camera result.
            s_FrozenDay =
                new RenderTexture(
                    width,
                    height,
                    0,
                    format)
                {
                    name = "CWD-DayNight-FrozenDay",
                    filterMode = FilterMode.Bilinear,
                    wrapMode = TextureWrapMode.Clamp,
                    hideFlags = HideFlags.HideAndDontSave,
                };

            s_FrozenDay.Create();

            s_FrozenDayHandle =
                RTHandles.Alloc(
                    s_FrozenDay);

            s_FrozenFormat =
                format;
        }

        private static void ReleaseFrozenTarget()
        {
            if (s_FrozenDayHandle != null)
            {
                s_FrozenDayHandle.Release();
                s_FrozenDayHandle = null;
            }

            if (s_FrozenDay != null)
            {
                s_FrozenDay.Release();

                UnityEngine.Object.Destroy(
                    s_FrozenDay);

                s_FrozenDay = null;
            }

            s_FrozenFormat =
                GraphicsFormat.None;
        }

        private static void DestroyVolume()
        {
            if (s_Volume == null)
            {
                return;
            }

            GameObject gameObject =
                s_Volume.gameObject;

            s_Volume = null;

            if (gameObject != null)
            {
                UnityEngine.Object.Destroy(
                    gameObject);
            }
        }
    }
}
