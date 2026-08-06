// <copyright file="DayNightExposureBridgeSystem.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the MIT License. You may not use this file except in compliance with this License.
// See LICENSE file in the project root for full license information.
// This notice and the MIT License notice must be kept with
// all copies or substantial portions of this code.
// ================= </copyright> ======================

// File: Systems/Controls/DayNightExposureBridgeSystem.cs
// Purpose: Stages Day-to-Night through vanilla Dusk while automatic exposure settles.

namespace CityWatchdog.Systems
{
    using System;
    using System.Globalization;
    using System.Reflection;

    using CS2Shared.RiverMochi;

    using Game.Rendering;
    using Game.Simulation;

    using UnityEngine;
    using UnityEngine.Rendering;
    using UnityEngine.Rendering.HighDefinition;

    public partial class DayNightExposureBridgeSystem : GameSystemBaseExtension
    {
        private const string kLightingExposureFieldName = "m_Exposure";
        private const string kLightingProfileFieldName = "m_Profile";

        // This is the earlier no-X-ray limit sequence: 14, 13, ... 6.
        private const int kDuskLimitBridgeFrameCount = 9;

        // 8:15 PM was still Sunset in the test city. Move later in small steps
        // until vanilla reports its actual Dusk state for the current date/location.
        private const float kDuskSearchStepHours = 0.25f;
        private const float kDuskSearchBackoffHours = 0.125f;
        private const int kDuskSearchMaxAttempts = 12;

        // After reaching the Night range, keep vanilla Dusk for several rendered
        // frames so both alternating exposure histories can approach Night EV.
        private const int kDuskSettleFrameCount = 10;
        private const int kNightArrivalWaitFrameCount = 4;

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
        private PlanetarySystem m_PlanetarySystem = null!;
        private DayNightControlSystem? m_ControlSystem;

        private bool m_DuskLimitBridgeActive;
        private int m_DuskSearchAttempt;
        private int m_DuskLimitBridgeFrame;
        private float m_DuskStartMax;

        private bool m_DuskSettleActive;
        private int m_DuskSettleFrame;

        private bool m_WaitingForNight;
        private int m_NightArrivalWaitFrame;

        private bool m_AutoCheckPending;
        private bool m_AutoBaselineValid;
        private float m_AutoBeforeMin;
        private float m_AutoBeforeMax;

        protected override void OnCreate()
        {
            base.OnCreate();

            m_LightingSystem =
                World.GetOrCreateSystemManaged<LightingSystem>();

            m_PlanetarySystem =
                World.GetOrCreateSystemManaged<PlanetarySystem>();
        }

        protected override void OnUpdate()
        {
            ProcessAutoBrighteningCheck();

            if (m_DuskLimitBridgeActive)
            {
                ProcessDuskLimitBridge();
            }
            else if (m_DuskSettleActive)
            {
                ProcessDuskSettle();
            }
            else if (m_WaitingForNight)
            {
                ProcessNightArrival();
            }
        }

        internal void AttachController(
            DayNightControlSystem controlSystem)
        {
            m_ControlSystem = controlSystem;
        }

        internal void DetachController(
            DayNightControlSystem controlSystem)
        {
            if (ReferenceEquals(
                    m_ControlSystem,
                    controlSystem))
            {
                m_ControlSystem = null;
            }
        }

        internal void BeginNightTransition()
        {
            CancelAutoBrighteningCheck();
            CancelNightTransition();

            if (!TryGetLightingExposure(
                    out Exposure? exposure) ||
                exposure == null)
            {
                return;
            }

            m_DuskStartMax =
                exposure.limitMax.value;

            m_DuskLimitBridgeFrame = 0;
            m_DuskSearchAttempt = 0;
            m_DuskLimitBridgeActive = true;

#if DEBUG
            LogUtils.Info(
                string.Format(
                    CultureInfo.InvariantCulture,
                    "[CWD-DN-BRIDGE] DUSK begin startMin={0:F3} startMax={1:F3}",
                    exposure.limitMin.value,
                    m_DuskStartMax));
#endif
        }

        internal void CancelNightTransition()
        {
            m_DuskLimitBridgeActive = false;
            m_DuskLimitBridgeFrame = 0;
            m_DuskSearchAttempt = 0;

            m_DuskSettleActive = false;
            m_DuskSettleFrame = 0;

            m_WaitingForNight = false;
            m_NightArrivalWaitFrame = 0;
        }

        internal void ArmAutoBrighteningCheck()
        {
            CancelNightTransition();

            m_AutoCheckPending = true;
            m_AutoBaselineValid =
                TryGetLightingExposure(
                    out Exposure? exposure);

            if (m_AutoBaselineValid &&
                exposure != null)
            {
                m_AutoBeforeMin =
                    exposure.limitMin.value;

                m_AutoBeforeMax =
                    exposure.limitMax.value;
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

            if (!TryGetLightingExposure(
                    out Exposure? exposure) ||
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
                m_ControlSystem?
                    .RequestBrighteningHistoryReset();
            }

            m_AutoBaselineValid = false;
        }

        private void ProcessDuskLimitBridge()
        {
            if (!SmootherSwitchEnabled() ||
                !TryGetLightingExposure(
                    out Exposure? exposure) ||
                exposure == null)
            {
                CancelNightTransition();
                return;
            }

            LightingSystem.State state =
                m_LightingSystem.state;

            if (state == LightingSystem.State.Day ||
                state == LightingSystem.State.Sunset)
            {
                SearchForDusk(
                    moveLater: true,
                    state);

                return;
            }

            if (state == LightingSystem.State.Night)
            {
                // A 15-minute step can cross the narrow Dusk interval.
                // Move back by half a step and check again next frame.
                SearchForDusk(
                    moveLater: false,
                    state);

                return;
            }

            if (state != LightingSystem.State.Dusk)
            {
#if DEBUG
                LogUtils.Info(
                    $"[CWD-DN-BRIDGE] DUSK search canceled state={state}");
#endif

                FallBackToNight();
                return;
            }

#if DEBUG
            if (m_DuskSearchAttempt > 0)
            {
                LogUtils.Info(
                    string.Format(
                        CultureInfo.InvariantCulture,
                        "[CWD-DN-BRIDGE] DUSK found hour={0:F3} attempts={1}",
                        m_PlanetarySystem.time,
                        m_DuskSearchAttempt));
            }
#endif

            float vanillaDuskMax =
                exposure.limitMax.value;

            if (m_DuskStartMax <=
                vanillaDuskMax +
                kExposureRangeDifference)
            {
                StartDuskSettle();
                return;
            }

            float progress =
                kDuskLimitBridgeFrameCount <= 1
                    ? 1f
                    : (float)m_DuskLimitBridgeFrame /
                      (kDuskLimitBridgeFrameCount - 1);

            float appliedMax =
                Mathf.Lerp(
                    m_DuskStartMax,
                    vanillaDuskMax,
                    progress);

            exposure.limitMax.value =
                Mathf.Max(
                    exposure.limitMin.value,
                    appliedMax);

            // LightingSystem resets its profile before this system.
            // Refresh it after changing this frame's maximum EV.
            TryGetLightingProfile()?.Reset();

#if DEBUG
            LogUtils.Info(
                string.Format(
                    CultureInfo.InvariantCulture,
                    "[CWD-DN-BRIDGE] DUSK bridge={0}/{1} state={2} min={3:F3} vanillaMax={4:F3} appliedMax={5:F3}",
                    m_DuskLimitBridgeFrame,
                    kDuskLimitBridgeFrameCount - 1,
                    state,
                    exposure.limitMin.value,
                    vanillaDuskMax,
                    exposure.limitMax.value));
#endif

            m_DuskLimitBridgeFrame++;

            if (m_DuskLimitBridgeFrame >=
                kDuskLimitBridgeFrameCount)
            {
                StartDuskSettle();
            }
        }

        private void SearchForDusk(
            bool moveLater,
            LightingSystem.State currentState)
        {
            if (m_DuskSearchAttempt >=
                kDuskSearchMaxAttempts)
            {
#if DEBUG
                LogUtils.Info(
                    string.Format(
                        CultureInfo.InvariantCulture,
                        "[CWD-DN-BRIDGE] DUSK search timed out state={0} hour={1:F3}",
                        currentState,
                        m_PlanetarySystem.time));
#endif

                FallBackToNight();
                return;
            }

            float step =
                moveLater
                    ? kDuskSearchStepHours
                    : -kDuskSearchBackoffHours;

            m_PlanetarySystem.overrideTime = true;
            m_PlanetarySystem.time =
                NormalizeHour(
                    m_PlanetarySystem.time +
                    step);

            m_DuskSearchAttempt++;

#if DEBUG
            LogUtils.Info(
                string.Format(
                    CultureInfo.InvariantCulture,
                    "[CWD-DN-BRIDGE] DUSK search={0}/{1} state={2} nextHour={3:F3}",
                    m_DuskSearchAttempt,
                    kDuskSearchMaxAttempts,
                    currentState,
                    m_PlanetarySystem.time));
#endif
        }

        private void FallBackToNight()
        {
            m_DuskLimitBridgeActive = false;
            m_DuskLimitBridgeFrame = 0;
            m_DuskSearchAttempt = 0;

            m_WaitingForNight = true;
            m_NightArrivalWaitFrame = 0;

            m_ControlSystem?
                .CompleteDuskToNightTransition();
        }

        private static float NormalizeHour(
            float hour)
        {
            return Mathf.Repeat(
                hour,
                24f);
        }

        private void StartDuskSettle()
        {
            m_DuskLimitBridgeActive = false;
            m_DuskLimitBridgeFrame = 0;

            m_DuskSettleActive = true;
            m_DuskSettleFrame = 0;

#if DEBUG
            LogUtils.Info(
                "[CWD-DN-BRIDGE] DUSK limit bridge end; vanilla Dusk settling.");
#endif
        }

        private void ProcessDuskSettle()
        {
            if (!SmootherSwitchEnabled() ||
                !TryGetLightingExposure(
                    out Exposure? exposure) ||
                exposure == null)
            {
                CancelNightTransition();
                return;
            }

            LightingSystem.State state =
                m_LightingSystem.state;

            if (state != LightingSystem.State.Dusk)
            {
#if DEBUG
                LogUtils.Info(
                    $"[CWD-DN-BRIDGE] DUSK settle canceled state={state}");
#endif

                CancelNightTransition();
                return;
            }

#if DEBUG
            LogUtils.Info(
                string.Format(
                    CultureInfo.InvariantCulture,
                    "[CWD-DN-BRIDGE] DUSK settle={0}/{1} min={2:F3} max={3:F3}",
                    m_DuskSettleFrame,
                    kDuskSettleFrameCount - 1,
                    exposure.limitMin.value,
                    exposure.limitMax.value));
#endif

            m_DuskSettleFrame++;

            if (m_DuskSettleFrame <
                kDuskSettleFrameCount)
            {
                return;
            }

            m_DuskSettleActive = false;
            m_DuskSettleFrame = 0;

            m_WaitingForNight = true;
            m_NightArrivalWaitFrame = 0;

#if DEBUG
            LogUtils.Info(
                "[CWD-DN-BRIDGE] DUSK settled; requesting final 1 AM Night.");
#endif

            // This runs after LightingSystem. PlanetarySystem sees 1 AM next frame.
            m_ControlSystem?
                .CompleteDuskToNightTransition();
        }

        private void ProcessNightArrival()
        {
            LightingSystem.State state =
                m_LightingSystem.state;

            if (state == LightingSystem.State.Night)
            {
#if DEBUG
                LogUtils.Info(
                    "[CWD-DN-BRIDGE] NIGHT arrived after Dusk.");
#endif

                m_WaitingForNight = false;
                m_NightArrivalWaitFrame = 0;
                return;
            }

            m_NightArrivalWaitFrame++;

            if (m_NightArrivalWaitFrame <
                kNightArrivalWaitFrameCount)
            {
                return;
            }

#if DEBUG
            LogUtils.Info(
                $"[CWD-DN-BRIDGE] NIGHT arrival timed out state={state}");
#endif

            m_WaitingForNight = false;
            m_NightArrivalWaitFrame = 0;
        }

        private static bool SmootherSwitchEnabled()
        {
            return
                CwdSettings.Instance?
                    .SmoothDayNightTransition ??
                true;
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
