// <copyright file="DayNightExposureBridgeSystem.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the MIT License. You may not use this file except in compliance with this License.
// See LICENSE file in the project root for full license information.
// This notice and the MIT License notice must be kept with
// all copies or substantial portions of this code.
// ================= </copyright> ======================

// File: Systems/Controls/DayNightExposureBridgeSystem.cs
// Purpose: Temporarily darkens the real rendered scene during Day -> Night,
// then checks real vanilla Auto exposure changes after LightingSystem.

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
        private const float kExposureRangeDifference = 0.05f;

        // D1 sunglasses test. Post Exposure is ordinary EV, not the EV100
        // number stored in HDRP automatic-exposure history.
        private const float kNightShadePostExposure = -3f;
        private const double kNightShadeFadeInSeconds = 0.05d;
        private const double kNightShadeFadeOutStartSeconds = 0.175d;
        private const double kNightShadeEndSeconds = 0.255d;
        private const int kNightShadeVolumePriority = 3000;

        private static readonly FieldInfo? s_LightingExposureField =
            typeof(LightingSystem).GetField(
                kLightingExposureFieldName,
                BindingFlags.Instance | BindingFlags.NonPublic);

        private LightingSystem m_LightingSystem = null!;
        private DayNightControlSystem? m_ControlSystem;

        private Volume m_NightShadeVolume = null!;
        private ColorAdjustments m_NightShadeColor = null!;
        private bool m_NightShadeActive;
        private bool m_NightShadeFullLogged;
        private bool m_NightShadeReleaseLogged;
        private double m_NightShadeStartTime;

        private bool m_AutoCheckPending;
        private bool m_AutoBaselineValid;
        private float m_AutoBeforeMin;
        private float m_AutoBeforeMax;

        protected override void OnCreate()
        {
            base.OnCreate();

            m_LightingSystem =
                World.GetOrCreateSystemManaged<LightingSystem>();

            m_NightShadeVolume =
                VolumeHelper.CreateVolume(
                    "CWD-DayNightSunglasses",
                    kNightShadeVolumePriority);

            VolumeHelper.GetOrCreateVolumeComponent(
                m_NightShadeVolume,
                ref m_NightShadeColor);

            // Only Post Exposure is overridden. The scene, color, sky,
            // water, shadows, LUT, and automatic exposure stay untouched.
            m_NightShadeColor.postExposure.Override(
                kNightShadePostExposure);
            m_NightShadeVolume.weight = 0f;
        }

        protected override void OnUpdate()
        {
            ProcessAutoBrighteningCheck();
            ProcessNightShade();
        }

        protected override void OnDestroy()
        {
            CancelAll();
            VolumeHelper.DestroyVolume(m_NightShadeVolume);
            base.OnDestroy();
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

            m_NightShadeActive = true;
            m_NightShadeFullLogged = false;
            m_NightShadeReleaseLogged = false;
            m_NightShadeStartTime =
                UnityEngine.Time.unscaledTimeAsDouble;
            m_NightShadeVolume.weight = 0f;

#if DEBUG
            LogUtils.Info(
                string.Format(
                    CultureInfo.InvariantCulture,
                    "[CWD-DN-SHADE] begin postEV={0:F1} fadeInMs={1:F0} releaseMs={2:F0} endMs={3:F0}",
                    kNightShadePostExposure,
                    kNightShadeFadeInSeconds * 1000d,
                    kNightShadeFadeOutStartSeconds * 1000d,
                    kNightShadeEndSeconds * 1000d));
#endif
        }

        internal void CancelNightTransition()
        {
            m_NightShadeActive = false;
            m_NightShadeFullLogged = false;
            m_NightShadeReleaseLogged = false;
            m_NightShadeStartTime = 0d;

            if (m_NightShadeVolume != null)
            {
                m_NightShadeVolume.weight = 0f;
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

        private void ProcessNightShade()
        {
            if (!m_NightShadeActive)
            {
                return;
            }

            double elapsed =
                UnityEngine.Time.unscaledTimeAsDouble -
                m_NightShadeStartTime;

            float weight;

            if (elapsed < kNightShadeFadeInSeconds)
            {
                weight = Mathf.SmoothStep(
                    0f,
                    1f,
                    (float)(elapsed /
                        kNightShadeFadeInSeconds));
            }
            else if (elapsed < kNightShadeFadeOutStartSeconds)
            {
                weight = 1f;

#if DEBUG
                if (!m_NightShadeFullLogged)
                {
                    m_NightShadeFullLogged = true;
                    LogUtils.Info(
                        string.Format(
                            CultureInfo.InvariantCulture,
                            "[CWD-DN-SHADE] full elapsedMs={0:F1} weight=1.000",
                            elapsed * 1000d));
                }
#endif
            }
            else if (elapsed < kNightShadeEndSeconds)
            {
                weight = Mathf.SmoothStep(
                    1f,
                    0f,
                    (float)((elapsed -
                        kNightShadeFadeOutStartSeconds) /
                        (kNightShadeEndSeconds -
                         kNightShadeFadeOutStartSeconds)));

#if DEBUG
                if (!m_NightShadeReleaseLogged)
                {
                    m_NightShadeReleaseLogged = true;
                    LogUtils.Info(
                        string.Format(
                            CultureInfo.InvariantCulture,
                            "[CWD-DN-SHADE] release elapsedMs={0:F1}",
                            elapsed * 1000d));
                }
#endif
            }
            else
            {
#if DEBUG
                LogUtils.Info(
                    string.Format(
                        CultureInfo.InvariantCulture,
                        "[CWD-DN-SHADE] end elapsedMs={0:F1}",
                        elapsed * 1000d));
#endif

                CancelNightTransition();
                return;
            }

            m_NightShadeVolume.weight =
                Mathf.Clamp01(weight);
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
                    "[CWD-DN-AUTO] state={0} beforeMin={1:F3} beforeMax={2:F3} afterMin={3:F3} afterMax={4:F3} reset={5}",
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
                    $"Day/Night Auto exposure check unavailable: LightingSystem field '{kLightingExposureFieldName}' was not found.");

            return false;
        }
    }
}
