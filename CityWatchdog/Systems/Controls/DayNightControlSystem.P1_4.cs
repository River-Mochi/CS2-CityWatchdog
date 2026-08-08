// <copyright file="DayNightControlSystem.P1_4.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the MIT License. You may not use this file except in compliance with this License.
// See LICENSE file in the project root for full license information.
// This notice and the MIT License notice must be kept with
// all copies or substantial portions of this code.
// ================= </copyright> ======================

// File: Systems/Controls/DayNightControlSystem.P1_4.cs
// Purpose: P1.4 test. Protect Day -> Default with the current clean Day frame.

namespace CityWatchdog.Systems
{
    using CS2Shared.RiverMochi;

    public partial class DayNightControlSystem
    {
        private const double kDayToDefaultCaptureTimeoutSeconds = 1d;

        // Negative tokens cannot collide with the positive Day -> Night safety tokens.
        private int m_DayToDefaultToken;
        private bool m_DayToDefaultPending;
        private bool m_DayToDefaultCaptureDebug;
        private double m_DayToDefaultDeadline;

        private void BeginDayToDefaultTransition(
            bool captureDebug)
        {
            m_ExposureBridgeSystem?.CancelAll();

            m_DayToDefaultToken =
                m_DayToDefaultToken == int.MinValue
                    ? -1
                    : m_DayToDefaultToken - 1;

            m_DayToDefaultPending = true;
            m_DayToDefaultCaptureDebug = captureDebug;
            m_DayToDefaultDeadline =
                UnityEngine.Time.unscaledTimeAsDouble +
                kDayToDefaultCaptureTimeoutSeconds;

            DayNightFrozenFrameTransition.RequestDayCapture(
                m_DayToDefaultToken);

#if DEBUG
            LogUtils.Info(
                $"[CWD-DN-P1.4] Day->Default capture requested token={m_DayToDefaultToken}");
#endif
        }

        private void ApplyPendingDayToDefaultTransition()
        {
            if (!m_DayToDefaultPending)
            {
                return;
            }

            int token = m_DayToDefaultToken;

            if (!DayNightFrozenFrameTransition.IsDayCaptureReady(token))
            {
                if (UnityEngine.Time.unscaledTimeAsDouble <
                    m_DayToDefaultDeadline)
                {
                    return;
                }

                CancelPendingDayToDefaultTransition(
                    restoreDisplayedMode: true);

                LogUtils.WarnOnce(
                    "day-night-p14-default-capture-timeout",
                    () =>
                        "Day/Night P1.4 could not capture the clean Day frame before switching to Default. The Default switch was canceled.");
                return;
            }

            m_DayToDefaultPending = false;
            m_DayToDefaultDeadline = 0d;

            bool resetHistory = false;

            if (m_DayToDefaultCaptureDebug &&
                m_AppliedMode != kModeAuto)
            {
                float beforeHour =
                    NormalizeHour(m_PlanetarySystem?.time ?? 0f);

                BeginExposureDebug(
                    m_AppliedMode,
                    kModeAuto,
                    beforeHour,
                    resetHistory);
            }

            m_DayToDefaultCaptureDebug = false;

            // Default may settle at Day, Dusk, or Night, so use stability only.
            if (!DayNightFrozenFrameTransition.BeginHold(
                    token,
                    requireNightExposure: false))
            {
                if (m_DayNightModeBinding.value != m_AppliedMode)
                {
                    m_DayNightModeBinding.Update(m_AppliedMode);
                }

                LogUtils.WarnOnce(
                    "day-night-p14-default-hold-not-ready",
                    () =>
                        "Day/Night P1.4 could not start the frozen Day hold. The Default switch was canceled.");
                return;
            }

            // Preserve the existing brighter-Default history reset check.
            m_ExposureBridgeSystem?.ArmAutoBrighteningCheck();

            // Release CWD's time override underneath the frozen Day frame.
            ApplyMode(
                kModeAuto,
                resetHistory);
            m_AppliedMode = kModeAuto;

#if DEBUG
            LogUtils.Info(
                $"[CWD-DN-P1.4] Default applied under frozen Day token={token}");
#endif
        }

        private void CancelPendingDayToDefaultTransition(
            bool restoreDisplayedMode)
        {
            if (!m_DayToDefaultPending)
            {
                return;
            }

            int token = m_DayToDefaultToken;

            m_DayToDefaultPending = false;
            m_DayToDefaultCaptureDebug = false;
            m_DayToDefaultDeadline = 0d;

            DayNightFrozenFrameTransition.CancelPendingCapture(token);

            if (restoreDisplayedMode &&
                m_DayNightModeBinding.value != m_AppliedMode)
            {
                m_DayNightModeBinding.Update(m_AppliedMode);
            }

#if DEBUG
            LogUtils.Info(
                $"[CWD-DN-P1.4] Day->Default pending capture canceled token={token}");
#endif
        }
    }
}
