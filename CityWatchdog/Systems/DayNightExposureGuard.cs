// <copyright file="DayNightExposureGuard.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the MIT License. You may not use this file except in compliance with this License.
// See LICENSE file in the project root for full license information.
// This notice and the MIT License notice must be kept with
// all copies or substantial portions of this code.
// ================= </copyright> ======================

// File: Systems/DayNightExposureGuard.cs
// Purpose: Prevents HDR exposure lag while the Day/Night transition moves the sun.

namespace CityWatchdog.Systems
{
    using System;

    using CS2Shared.RiverMochi;

    using Game.Rendering;

    using UnityEngine.Rendering;
    using UnityEngine.Rendering.HighDefinition;

    internal sealed class DayNightExposureGuard
    {
        // Above the game's water volume and common lighting-mod volumes while active.
        private const int kVolumePriority = 6000;

        private static bool s_LoggedApply;

        private Volume m_Volume = null!;
        private Exposure m_Exposure = null!;
        private bool m_Unavailable;

        // Build on city/editor load so the first click does not allocate a GameObject mid-transition.
        public void Prepare()
        {
            if (m_Volume != null || m_Unavailable)
            {
                return;
            }

            if (!EnsureVolume())
            {
                // The render stack may not be ready yet. First use gets another attempt.
                m_Unavailable = false;
            }
        }

        // Fixed adaptation prevents the previous scene's exposure history from trailing the moving sun.
        public bool Begin()
        {
            if (!EnsureVolume())
            {
                return false;
            }

            try
            {
                m_Exposure.adaptationMode.overrideState = true;
                m_Exposure.adaptationMode.value = AdaptationMode.Fixed;

                // Keep the volume registered between switches; weight makes it active only here.
                m_Volume.weight = 1f;

                if (!s_LoggedApply)
                {
                    s_LoggedApply = true;
                    LogUtils.Info("[CWD] Day/Night exposure guard applied.");
                }

                return true;
            }
            catch (Exception ex)
            {
                m_Unavailable = true;
                LogUtils.WarnOnce(
                    "day-night-exposure-begin",
                    () => $"Could not apply Day/Night exposure guard: {ex.GetType().Name}: {ex.Message}",
                    ex);
                return false;
            }
        }

        // Hand exposure back after the final lighting state has settled.
        public void End()
        {
            if (m_Volume == null)
            {
                return;
            }

            try
            {
                m_Exposure.adaptationMode.overrideState = false;
                m_Volume.weight = 0f;
            }
            catch (Exception ex)
            {
                LogUtils.WarnOnce(
                    "day-night-exposure-end",
                    () => $"Could not release Day/Night exposure guard: {ex.GetType().Name}: {ex.Message}",
                    ex);
            }
        }

        public void Dispose()
        {
            if (m_Volume == null)
            {
                ResetFields();
                return;
            }

            try
            {
                VolumeHelper.DestroyVolume(m_Volume);
            }
            catch (Exception ex)
            {
                LogUtils.WarnOnce(
                    "day-night-exposure-dispose",
                    () => $"Could not destroy Day/Night exposure volume: {ex.GetType().Name}: {ex.Message}",
                    ex);
            }

            ResetFields();
        }

        // The volume stays registered at weight 0, so idle mode does not override HDRP settings.
        private bool EnsureVolume()
        {
            if (m_Volume != null)
            {
                return true;
            }

            if (m_Unavailable)
            {
                return false;
            }

            try
            {
                m_Volume = VolumeHelper.CreateVolume("CwdDayNightExposure", kVolumePriority);
                VolumeHelper.GetOrCreateVolumeComponent(m_Volume, ref m_Exposure);
                m_Volume.isGlobal = true;
                m_Volume.weight = 0f;
                return true;
            }
            catch (Exception ex)
            {
                m_Unavailable = true;
                LogUtils.WarnOnce(
                    "day-night-exposure-create",
                    () => $"Day/Night exposure guard unavailable; transitions use vanilla exposure: {ex.GetType().Name}: {ex.Message}",
                    ex);
                return false;
            }
        }

        private void ResetFields()
        {
            m_Volume = null!;
            m_Exposure = null!;
            m_Unavailable = false;
        }
    }
}
