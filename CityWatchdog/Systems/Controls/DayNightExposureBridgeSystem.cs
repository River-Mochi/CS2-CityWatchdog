// <copyright file="DayNightExposureBridgeSystem.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the MIT License. You may not use this file except in compliance with this License.
// See LICENSE file in the project root for full license information.
// This notice and the MIT License notice must be kept with
// all copies or substantial portions of this code.
// ================= </copyright> ======================

// File: Systems/Controls/DayNightExposureBridgeSystem.cs
// Purpose: Tests instant HDRP exposure adaptation during the direct Day -> Night switch.

namespace CityWatchdog.Systems
{
    using System;
    using System.Globalization;
    using System.Reflection;

    using CS2Shared.RiverMochi;

    using Game.Rendering;

    using UnityEngine.Rendering;
    using UnityEngine.Rendering.HighDefinition;

    public partial class DayNightExposureBridgeSystem : GameSystemBaseExtension
    {
        private const string kLightingExposureFieldName = "m_Exposure";
        private const string kLightingProfileFieldName = "m_Profile";

        // Let the new dark scene settle with instant exposure before restoring
        // the profile's normal Progressive adaptation.
        private const double kNightFixedAdaptationSeconds = 0.5d;
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

        private bool m_NightTransitionActive;
        private double m_NightReleaseTime;
        private bool m_NightOriginalAdaptationValid;
        private AdaptationMode m_NightOriginalAdaptationMode;
        private bool m_NightOriginalAdaptationOverrideState;

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
            ProcessNightTransition();
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
            CancelNightTransition();

            if (!TryGetLightingExposure(out Exposure? exposure) ||
                exposure == null)
            {
                return;
            }

            m_NightOriginalAdaptationMode =
                exposure.adaptationMode.value;
            m_NightOriginalAdaptationOverrideState =
                exposure.adaptationMode.overrideState;
            m_NightOriginalAdaptationValid = true;

            m_NightReleaseTime =
                World.Time.ElapsedTime +
                kNightFixedAdaptationSeconds;
            m_NightTransitionActive = true;

            // This runs immediately before DayNightControlSystem changes the hour.
            ApplyFixedAdaptation(exposure);

#if DEBUG
            LogUtils.Info(
                string.Format(
                    CultureInfo.InvariantCulture,
                    "[CWD-DN-FIXED] NIGHT begin original={0} override={1} releaseIn={2:F2}s min={3:F3} max={4:F3}",
                    m_NightOriginalAdaptationMode,
                    m_NightOriginalAdaptationOverrideState,
                    kNightFixedAdaptationSeconds,
                    exposure.limitMin.value,
                    exposure.limitMax.value));
#endif
        }

        internal void CancelNightTransition()
        {
            if (m_NightTransitionActive ||
                m_NightOriginalAdaptationValid)
            {
                RestoreNightAdaptation();
            }

            m_NightTransitionActive = false;
            m_NightOriginalAdaptationValid = false;
            m_NightReleaseTime = 0d;
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
                    "[CWD-DN-FIXED] AUTO state={0} beforeMin={1:F3} beforeMax={2:F3} afterMin={3:F3} afterMax={4:F3} reset={5}",
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

        private void ProcessNightTransition()
        {
            if (!m_NightTransitionActive)
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

            double elapsedTime =
                World.Time.ElapsedTime;

            if (elapsedTime >= m_NightReleaseTime)
            {
#if DEBUG
                LogUtils.Info(
                    string.Format(
                        CultureInfo.InvariantCulture,
                        "[CWD-DN-FIXED] NIGHT release state={0} current={1} min={2:F3} max={3:F3}",
                        m_LightingSystem.state,
                        exposure.adaptationMode.value,
                        exposure.limitMin.value,
                        exposure.limitMax.value));
#endif

                CancelNightTransition();
                return;
            }

            // LightingSystem may copy profile values each frame, so reapply Fixed
            // after LightingSystem until the short hold has completed.
            ApplyFixedAdaptation(exposure);

#if DEBUG
            LogUtils.Info(
                string.Format(
                    CultureInfo.InvariantCulture,
                    "[CWD-DN-FIXED] NIGHT hold state={0} remaining={1:F3}s adaptation={2} min={3:F3} max={4:F3}",
                    m_LightingSystem.state,
                    Math.Max(
                        0d,
                        m_NightReleaseTime -
                        elapsedTime),
                    exposure.adaptationMode.value,
                    exposure.limitMin.value,
                    exposure.limitMax.value));
#endif
        }

        private void ApplyFixedAdaptation(
            Exposure exposure)
        {
            bool changed =
                exposure.adaptationMode.value !=
                    AdaptationMode.Fixed ||
                !exposure.adaptationMode.overrideState;

            exposure.adaptationMode.overrideState = true;
            exposure.adaptationMode.value =
                AdaptationMode.Fixed;

            if (changed)
            {
                // Tell HDRP that this frame's runtime profile value changed.
                TryGetLightingProfile()?.Reset();
            }
        }

        private void RestoreNightAdaptation()
        {
            if (!m_NightOriginalAdaptationValid ||
                !TryGetLightingExposure(out Exposure? exposure) ||
                exposure == null)
            {
                return;
            }

            exposure.adaptationMode.value =
                m_NightOriginalAdaptationMode;
            exposure.adaptationMode.overrideState =
                m_NightOriginalAdaptationOverrideState;

            TryGetLightingProfile()?.Reset();

#if DEBUG
            LogUtils.Info(
                string.Format(
                    CultureInfo.InvariantCulture,
                    "[CWD-DN-FIXED] NIGHT restored adaptation={0} override={1}",
                    exposure.adaptationMode.value,
                    exposure.adaptationMode.overrideState));
#endif
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
                    $"Day/Night exposure test unavailable: LightingSystem field '{kLightingExposureFieldName}' was not found.");

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
                        $"Day/Night exposure test could not refresh LightingSystem field '{kLightingProfileFieldName}'.");
            }

            return profile;
        }
    }
}
