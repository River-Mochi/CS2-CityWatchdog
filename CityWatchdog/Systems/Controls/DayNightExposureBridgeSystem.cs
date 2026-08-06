// <copyright file="DayNightExposureBridgeSystem.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the MIT License. You may not use this file except in compliance with this License.
// See LICENSE file in the project root for full license information.
// This notice and the MIT License notice must be kept with
// all copies or substantial portions of this code.
// ================= </copyright> ======================

// File: Systems/Controls/DayNightExposureBridgeSystem.cs
// Purpose: Tests a narrow automatic-exposure limit bridge after vanilla LightingSystem.

namespace CityWatchdog.Systems
{
    using System;
    using System.Globalization;
    using System.Reflection;

    using CS2Shared.RiverMochi;

    using Game.Rendering;

    using UnityEngine;
    using UnityEngine.Rendering;
    using UnityEngine.Rendering.HighDefinition;

    public partial class DayNightExposureBridgeSystem : GameSystemBaseExtension
    {
        private const string kLightingExposureFieldName = "m_Exposure";
        private const string kLightingProfileFieldName = "m_Profile";

        // One intermediate value for the usual 14 -> 6 change: 10, then vanilla 6.
        private const int kNightBridgeFrameCount = 2;
        private const int kNightRecoveryFrameCount = 4;
        private const float kLightToDarkSpeedMultiplier = 4f;
        private const float kExposureRangeDifference = 0.05f;

        private static readonly FieldInfo? s_LightingExposureField =
            typeof(LightingSystem).GetField(
                kLightingExposureFieldName,
                BindingFlags.Instance | BindingFlags.NonPublic);

        private static readonly FieldInfo? s_LightingProfileField =
            typeof(LightingSystem).GetField(
                kLightingProfileFieldName,
                BindingFlags.Instance | BindingFlags.NonPublic);

        private LightingSystem m_LightingSystem = null!;
        private DayNightControlSystem? m_ControlSystem;

        private bool m_NightBridgeActive;
        private int m_NightBridgeFrame;
        private float m_NightBridgeStartMax;

        private bool m_NightRecoveryActive;
        private int m_NightRecoveryFrame;
        private float m_OriginalLightToDarkSpeed;
        private float m_BoostedLightToDarkSpeed;

        private bool m_AutoCheckPending;
        private bool m_AutoBaselineValid;
        private float m_AutoBeforeMin;
        private float m_AutoBeforeMax;

        protected override void OnCreate()
        {
            base.OnCreate();

            m_LightingSystem =
                World.GetOrCreateSystemManaged<LightingSystem>();
        }

        protected override void OnUpdate()
        {
            ProcessAutoBrighteningCheck();
            ProcessNightBridge();
            ProcessNightRecovery();
        }

        internal void AttachController(
            DayNightControlSystem controlSystem)
        {
            m_ControlSystem = controlSystem;
        }

        internal void DetachController(
            DayNightControlSystem controlSystem)
        {
            if (ReferenceEquals(m_ControlSystem, controlSystem))
            {
                m_ControlSystem = null;
            }
        }

        internal void BeginNightTransition()
        {
            CancelAutoBrighteningCheck();

            if (!TryGetLightingExposure(out Exposure? exposure) ||
                exposure == null)
            {
                m_NightBridgeActive = false;
                return;
            }

            m_NightBridgeStartMax = exposure.limitMax.value;
            m_NightBridgeFrame = 0;
            m_NightBridgeActive = true;

            m_OriginalLightToDarkSpeed =
                exposure.adaptationSpeedLightToDark.value;
            m_BoostedLightToDarkSpeed =
                Mathf.Max(
                    m_OriginalLightToDarkSpeed,
                    m_OriginalLightToDarkSpeed *
                    kLightToDarkSpeedMultiplier);

            m_NightRecoveryFrame = 0;
            m_NightRecoveryActive = false;

#if DEBUG
            LogUtils.Info(
                string.Format(
                    CultureInfo.InvariantCulture,
                    "[CWD-DN-BRIDGE] NIGHT begin startMin={0:F3} startMax={1:F3} originalLtoD={2:F3} boostedLtoD={3:F3}",
                    exposure.limitMin.value,
                    m_NightBridgeStartMax,
                    m_OriginalLightToDarkSpeed,
                    m_BoostedLightToDarkSpeed));
#endif
        }

        internal void CancelNightTransition()
        {
            bool restoreSpeed =
                m_NightBridgeActive ||
                m_NightRecoveryActive;

            m_NightBridgeActive = false;
            m_NightBridgeFrame = 0;
            m_NightRecoveryActive = false;
            m_NightRecoveryFrame = 0;

            if (restoreSpeed)
            {
                RestoreLightToDarkSpeed();
            }
        }

        internal void ArmAutoBrighteningCheck()
        {
            CancelNightTransition();

            m_AutoCheckPending = true;
            m_AutoBaselineValid =
                TryGetLightingExposure(out Exposure? exposure);

            if (m_AutoBaselineValid && exposure != null)
            {
                m_AutoBeforeMin = exposure.limitMin.value;
                m_AutoBeforeMax = exposure.limitMax.value;
            }
        }

        internal void CancelAutoBrighteningCheck()
        {
            m_AutoCheckPending = false;
            m_AutoBaselineValid = false;
        }

        internal void CancelAll()
        {
            CancelNightTransition();
            CancelAutoBrighteningCheck();
        }

        private void ProcessAutoBrighteningCheck()
        {
            if (!m_AutoCheckPending)
            {
                return;
            }

            m_AutoCheckPending = false;

            if (!TryGetLightingExposure(out Exposure? exposure) ||
                exposure == null)
            {
                return;
            }

            LightingSystem.State state =
                m_LightingSystem.state;

            bool brighterRange =
                m_AutoBaselineValid
                    ? exposure.limitMin.value >
                        m_AutoBeforeMin +
                        kExposureRangeDifference ||
                      exposure.limitMax.value >
                        m_AutoBeforeMax +
                        kExposureRangeDifference
                    : state != LightingSystem.State.Night &&
                      state != LightingSystem.State.Dusk &&
                      state != LightingSystem.State.Invalid;

#if DEBUG
            LogUtils.Info(
                string.Format(
                    CultureInfo.InvariantCulture,
                    "[CWD-DN-BRIDGE] AUTO state={0} beforeMin={1:F3} beforeMax={2:F3} afterMin={3:F3} afterMax={4:F3} reset={5}",
                    state,
                    m_AutoBeforeMin,
                    m_AutoBeforeMax,
                    exposure.limitMin.value,
                    exposure.limitMax.value,
                    brighterRange));
#endif

            if (brighterRange)
            {
                m_ControlSystem?.RequestBrighteningHistoryReset();
            }

            m_AutoBaselineValid = false;
        }

        private void ProcessNightBridge()
        {
            if (!m_NightBridgeActive)
            {
                return;
            }

            if (!(CwdSettings.Instance?
                    .SmoothDayNightTransition ?? true))
            {
                CancelNightTransition();
                return;
            }

            if (!TryGetLightingExposure(out Exposure? exposure) ||
                exposure == null)
            {
                CancelNightTransition();
                return;
            }

            LightingSystem.State state =
                m_LightingSystem.state;

            if (state != LightingSystem.State.Night)
            {
#if DEBUG
                LogUtils.Info(
                    $"[CWD-DN-BRIDGE] NIGHT canceled state={state}");
#endif
                CancelNightTransition();
                return;
            }

            float vanillaNightMax =
                exposure.limitMax.value;

            if (m_NightBridgeStartMax <=
                vanillaNightMax +
                kExposureRangeDifference)
            {
#if DEBUG
                LogUtils.Info(
                    string.Format(
                        CultureInfo.InvariantCulture,
                        "[CWD-DN-BRIDGE] NIGHT not-needed startMax={0:F3} vanillaMax={1:F3}",
                        m_NightBridgeStartMax,
                        vanillaNightMax));
#endif
                CancelNightTransition();
                return;
            }

            // Start moving on the first Night frame instead of holding Day max for a frame.
            float progress =
                kNightBridgeFrameCount <= 1
                    ? 1f
                    : (float)(m_NightBridgeFrame + 1) /
                      kNightBridgeFrameCount;

            float appliedMax =
                Mathf.Lerp(
                    m_NightBridgeStartMax,
                    vanillaNightMax,
                    progress);

            exposure.limitMax.value =
                Mathf.Max(
                    exposure.limitMin.value,
                    appliedMax);

            exposure.adaptationSpeedLightToDark.value =
                m_BoostedLightToDarkSpeed;

            // LightingSystem calls Reset before this system; signal the profile again
            // after changing the value so HDRP sees this frame's bridge limit.
            TryGetLightingProfile()?.Reset();

#if DEBUG
            LogUtils.Info(
                string.Format(
                    CultureInfo.InvariantCulture,
                    "[CWD-DN-BRIDGE] NIGHT frame={0}/{1} state={2} min={3:F3} vanillaMax={4:F3} appliedMax={5:F3} LtoD={6:F3}",
                    m_NightBridgeFrame,
                    kNightBridgeFrameCount - 1,
                    state,
                    exposure.limitMin.value,
                    vanillaNightMax,
                    exposure.limitMax.value,
                    exposure.adaptationSpeedLightToDark.value));
#endif

            m_NightBridgeFrame++;

            if (m_NightBridgeFrame >=
                kNightBridgeFrameCount)
            {
                m_NightBridgeActive = false;
                m_NightBridgeFrame = 0;
                m_NightRecoveryActive = true;
                m_NightRecoveryFrame = 0;

#if DEBUG
                LogUtils.Info(
                    "[CWD-DN-BRIDGE] NIGHT bridge end; boosted recovery active");
#endif
            }
        }

        private void ProcessNightRecovery()
        {
            if (!m_NightRecoveryActive)
            {
                return;
            }

            if (!(CwdSettings.Instance?
                    .SmoothDayNightTransition ?? true) ||
                !TryGetLightingExposure(out Exposure? exposure) ||
                exposure == null ||
                m_LightingSystem.state != LightingSystem.State.Night)
            {
                CancelNightTransition();
                return;
            }

            exposure.adaptationSpeedLightToDark.value =
                m_BoostedLightToDarkSpeed;

            TryGetLightingProfile()?.Reset();

#if DEBUG
            LogUtils.Info(
                string.Format(
                    CultureInfo.InvariantCulture,
                    "[CWD-DN-BRIDGE] NIGHT recovery={0}/{1} EVmax={2:F3} LtoD={3:F3}",
                    m_NightRecoveryFrame,
                    kNightRecoveryFrameCount - 1,
                    exposure.limitMax.value,
                    exposure.adaptationSpeedLightToDark.value));
#endif

            m_NightRecoveryFrame++;

            if (m_NightRecoveryFrame >=
                kNightRecoveryFrameCount)
            {
                m_NightRecoveryActive = false;
                m_NightRecoveryFrame = 0;
                RestoreLightToDarkSpeed();

#if DEBUG
                LogUtils.Info(
                    "[CWD-DN-BRIDGE] NIGHT recovery end");
#endif
            }
        }

        private void RestoreLightToDarkSpeed()
        {
            if (!TryGetLightingExposure(out Exposure? exposure) ||
                exposure == null)
            {
                return;
            }

            exposure.adaptationSpeedLightToDark.value =
                m_OriginalLightToDarkSpeed;

            TryGetLightingProfile()?.Reset();
        }

        private bool TryGetLightingExposure(
            out Exposure? exposure)
        {
            exposure =
                s_LightingExposureField?
                    .GetValue(m_LightingSystem)
                    as Exposure;

            if (exposure != null)
            {
                return true;
            }

            LogUtils.WarnOnce(
                "day-night-lighting-exposure-missing",
                () =>
                    $"Day/Night exposure bridge unavailable: LightingSystem field '{kLightingExposureFieldName}' was not found.");

            return false;
        }

        private VolumeProfile? TryGetLightingProfile()
        {
            VolumeProfile? profile =
                s_LightingProfileField?
                    .GetValue(m_LightingSystem)
                    as VolumeProfile;

            if (profile == null)
            {
                LogUtils.WarnOnce(
                    "day-night-lighting-profile-missing",
                    () =>
                        $"Day/Night exposure bridge could not refresh LightingSystem field '{kLightingProfileFieldName}'.");
            }

            return profile;
        }
    }
}
