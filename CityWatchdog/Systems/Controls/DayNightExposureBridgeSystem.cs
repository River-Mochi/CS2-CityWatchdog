// <copyright file="DayNightExposureBridgeSystem.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the MIT License. You may not use this file except in compliance with this License.
// See LICENSE file in the project root for full license information.
// This notice and the MIT License notice must be kept with
// all copies or substantial portions of this code.
// ================= </copyright> ======================

// File: Systems/Controls/DayNightExposureBridgeSystem.cs
// Purpose: H3 diagnostic — briefly disables the vanilla OutlinesWorldUIPass
// during Day -> Night, then checks real vanilla Auto exposure changes.

namespace CityWatchdog.Systems
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Reflection;

    using CS2Shared.RiverMochi;

    using Game.Rendering;

    using UnityEngine.Rendering.HighDefinition;

    public partial class DayNightExposureBridgeSystem : GameSystemBaseExtension
    {
        private const string kLightingExposureFieldName = "m_Exposure";
        private const float kExposureRangeDifference = 0.05f;
        private const double kOutlinePassDisableMaxSeconds = 0.35d;

        private static readonly FieldInfo? s_LightingExposureField =
            typeof(LightingSystem).GetField(
                kLightingExposureFieldName,
                BindingFlags.Instance | BindingFlags.NonPublic);

        private readonly List<OutlinesWorldUIPass> m_OutlinePasses = new();
        private readonly List<bool> m_OutlinePassOriginalEnabled = new();

        private LightingSystem m_LightingSystem = null!;
        private DayNightControlSystem? m_ControlSystem;

        private bool m_OutlinePassSuppressed;
        private double m_OutlinePassDisabledAt;

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
            ProcessOutlinePassFailSafe();
        }

        protected override void OnDestroy()
        {
            CancelAll();
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
            RestoreOutlinePasses();

            CustomPassVolume[] volumes =
                UnityEngine.Object.FindObjectsOfType<CustomPassVolume>();

            int originallyEnabled = 0;

            for (int i = 0; i < volumes.Length; i++)
            {
                CustomPassVolume volume = volumes[i];
                if (volume == null || volume.customPasses == null)
                {
                    continue;
                }

                for (int j = 0; j < volume.customPasses.Count; j++)
                {
                    if (volume.customPasses[j] is not OutlinesWorldUIPass pass)
                    {
                        continue;
                    }

                    bool wasEnabled = pass.enabled;

                    m_OutlinePasses.Add(pass);
                    m_OutlinePassOriginalEnabled.Add(wasEnabled);

                    if (wasEnabled)
                    {
                        originallyEnabled++;
                    }

                    // H3 diagnostic: remove the entire pass, not just its colors.
                    pass.enabled = false;
                }
            }

            if (m_OutlinePasses.Count == 0)
            {
                LogUtils.WarnOnce(
                    "day-night-outline-pass-missing",
                    () =>
                        "Day/Night H3 diagnostic could not find OutlinesWorldUIPass.");

                return;
            }

            m_OutlinePassSuppressed = true;
            m_OutlinePassDisabledAt =
                UnityEngine.Time.unscaledTimeAsDouble;

#if DEBUG
            LogUtils.Info(
                $"[CWD-DN-OUTLINE] disabled count={m_OutlinePasses.Count} originallyEnabled={originallyEnabled}");
#endif
        }

        internal void CancelNightTransition()
        {
            RestoreOutlinePasses();
        }

        internal void ArmAutoBrighteningCheck()
        {
            RestoreOutlinePasses();

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
            RestoreOutlinePasses();
            CancelAutoBrighteningCheck();
        }

        private void ProcessOutlinePassFailSafe()
        {
            if (!m_OutlinePassSuppressed)
            {
                return;
            }

            double elapsed =
                UnityEngine.Time.unscaledTimeAsDouble -
                m_OutlinePassDisabledAt;

            if (elapsed < kOutlinePassDisableMaxSeconds)
            {
                return;
            }

#if DEBUG
            LogUtils.Info(
                string.Format(
                    CultureInfo.InvariantCulture,
                    "[CWD-DN-OUTLINE] fail-safe restore elapsedMs={0:F1}",
                    elapsed * 1000d));
#endif

            RestoreOutlinePasses();
        }

        private void RestoreOutlinePasses()
        {
            if (m_OutlinePasses.Count == 0)
            {
                m_OutlinePassSuppressed = false;
                m_OutlinePassDisabledAt = 0d;
                return;
            }

            int restoredEnabled = 0;

            for (int i = 0; i < m_OutlinePasses.Count; i++)
            {
                OutlinesWorldUIPass pass =
                    m_OutlinePasses[i];

                bool originalEnabled =
                    i < m_OutlinePassOriginalEnabled.Count &&
                    m_OutlinePassOriginalEnabled[i];

                pass.enabled = originalEnabled;

                if (originalEnabled)
                {
                    restoredEnabled++;
                }
            }

#if DEBUG
            if (m_OutlinePassSuppressed)
            {
                double elapsed =
                    UnityEngine.Time.unscaledTimeAsDouble -
                    m_OutlinePassDisabledAt;

                LogUtils.Info(
                    string.Format(
                        CultureInfo.InvariantCulture,
                        "[CWD-DN-OUTLINE] restored count={0} enabled={1} elapsedMs={2:F1}",
                        m_OutlinePasses.Count,
                        restoredEnabled,
                        elapsed * 1000d));
            }
#endif

            m_OutlinePasses.Clear();
            m_OutlinePassOriginalEnabled.Clear();
            m_OutlinePassSuppressed = false;
            m_OutlinePassDisabledAt = 0d;
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
