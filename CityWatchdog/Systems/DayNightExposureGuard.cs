// <copyright file="DayNightExposureGuard.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the MIT License. You may not use this file except in compliance with this License.
// See LICENSE file in the project root for full license information.
// This notice and the MIT License notice must be kept with
// all copies or substantial portions of this code.
// ================= </copyright> ======================

// File: Systems/DayNightExposureGuard.cs
// Purpose: Stops the bright exposure flash when the Day/Night switch jumps the sun. See docs/internals.md.

namespace CityWatchdog.Systems
{
    using System;

    using CS2Shared.RiverMochi;

    using Game.Rendering;

    using UnityEngine.Rendering;
    using UnityEngine.Rendering.HighDefinition;

    internal sealed class DayNightExposureGuard
    {
        // Above the game's water volume (5000) and SunGlasses' volume (2500) so our one param wins.
        private const int kVolumePriority = 6000;

        private static bool s_LoggedApply;

        private Volume m_Volume = null!;
        private Exposure m_Exposure = null!;
        private bool m_Unavailable;

        // Build the volume up front (on city/editor load) instead of during a click, so the first
        // switch has no GameObject allocation in the middle of it.
        public void Prepare()
        {
            if (m_Volume != null || m_Unavailable)
            {
                return;
            }

            if (!EnsureVolume())
            {
                // Early creation can fail if the render stack isn't up yet — allow a retry on first use
                // rather than disabling the guard for the whole session.
                m_Unavailable = false;
            }
        }

        // EV offset applied on top of auto-exposure. Used to start the new scene at the OLD scene's
        // brightness, then eased to 0 so brightness ramps one way instead of dipping.
        public void SetCompensation(float ev)
        {
            if (m_Volume == null)
            {
                return;
            }

            try
            {
                m_Exposure.compensation.overrideState = true;
                m_Exposure.compensation.value = ev;
            }
            catch (Exception ex)
            {
                LogUtils.WarnOnce(
                    "day-night-exposure-comp",
                    () => $"Could not set exposure compensation: {ex.GetType().Name}: {ex.Message}",
                    ex);
            }
        }

        // Call right BEFORE changing the time: instant adaptation means the first frame of the new
        // lighting is already exposed correctly, so it never ramps through the flash.
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

                // Belt-and-braces: if anything still honors Progressive, make both speeds effectively
                // instant. Vanilla defaults are 3 (dark->light) and 1 (light->dark) — the slow one is
                // why day->night flashed worst.
                m_Exposure.adaptationSpeedDarkToLight.overrideState = true;
                m_Exposure.adaptationSpeedDarkToLight.value = 100f;
                m_Exposure.adaptationSpeedLightToDark.overrideState = true;
                m_Exposure.adaptationSpeedLightToDark.value = 100f;

                // weight (not `enabled`) so the volume stays registered with VolumeManager the whole
                // time — toggling `enabled` re-registers and can miss the frame we need it on.
                m_Volume.weight = 1f;

                if (!s_LoggedApply)
                {
                    s_LoggedApply = true;
                    LogUtils.Info("[CWD] Day/Night exposure guard applied (volume active).");
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

        // Hand exposure back to vanilla (or whichever lighting mod is installed).
        public void End()
        {
            if (m_Volume == null)
            {
                return;
            }

            try
            {
                m_Exposure.adaptationMode.overrideState = false;
                m_Exposure.adaptationSpeedDarkToLight.overrideState = false;
                m_Exposure.adaptationSpeedLightToDark.overrideState = false;
                m_Exposure.compensation.overrideState = false;
                m_Exposure.compensation.value = 0f;
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
            // Unity's == treats a destroyed object as null, so this also covers a volume the engine
            // already tore down on a scene change; fields are cleared either way below.
            if (m_Volume == null)
            {
                m_Volume = null!;
                m_Exposure = null!;
                m_Unavailable = false;   // let the next load try again
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

            m_Volume = null!;
            m_Exposure = null!;
            m_Unavailable = false;   // let the next load try again
        }

        // Built by Prepare() on load, or lazily on first use as a fallback. Kept at weight 0 between
        // switches, so it costs nothing while idle.
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
                m_Volume.weight = 0f;   // registered but inert until Begin()
                return true;
            }
            catch (Exception ex)
            {
                m_Unavailable = true;
                LogUtils.WarnOnce(
                    "day-night-exposure-create",
                    () => $"Day/Night exposure guard unavailable; switches use vanilla exposure: {ex.GetType().Name}: {ex.Message}",
                    ex);
                return false;
            }
        }
    }
}
