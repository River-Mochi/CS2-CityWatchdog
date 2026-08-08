// <copyright file="DayNightExposureBridgeSystem.VanillaProbe.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the MIT License. You may not use this file except in compliance with this License.
// See LICENSE file in the project root for full license information.
// This notice and the MIT License notice must be kept with
// all copies or substantial portions of this code.
// ================= </copyright> ======================

// File: Systems/Controls/DayNightExposureBridgeSystem.VanillaProbe.cs
// Purpose: DEBUG-only runtime evidence for the vanilla Day/night visuals Gameplay toggle.

#if DEBUG

namespace CityWatchdog.Systems
{
    using System.Globalization;

    using CS2Shared.RiverMochi;

    using Game;
    using Game.SceneFlow;
    using Game.Settings;
    using Game.Simulation;

    using UnityEngine;

    public partial class DayNightExposureBridgeSystem
    {
        private PlanetarySystem? m_VanillaProbePlanetarySystem;
        private bool m_VanillaProbeHasState;
        private bool m_VanillaProbeLastDayNightVisual;

        private void ProbeVanillaFixedDay()
        {
            if (GameManager.instance?.gameMode != GameMode.Game)
            {
                return;
            }

            GameplaySettings? gameplay =
                SharedSettings.instance?.gameplay;

            if (gameplay == null)
            {
                return;
            }

            bool dayNightVisual =
                gameplay.dayNightVisual;

            if (m_VanillaProbeHasState &&
                dayNightVisual ==
                m_VanillaProbeLastDayNightVisual)
            {
                return;
            }

            m_VanillaProbeHasState = true;
            m_VanillaProbeLastDayNightVisual =
                dayNightVisual;

            m_VanillaProbePlanetarySystem ??=
                World.GetOrCreateSystemManaged<PlanetarySystem>();

            PlanetarySystem planetarySystem =
                m_VanillaProbePlanetarySystem;

            PlanetarySystem.LightData sunLight =
                planetarySystem.SunLight;

            bool sunValid =
                sunLight.isValid;

            Vector3 sunPosition =
                sunValid
                    ? sunLight.transform.position
                    : default;

            Vector3 sunForward =
                sunValid
                    ? sunLight.transform.forward
                    : default;

            float sunIntensity =
                sunValid &&
                sunLight.additionalData != null
                    ? sunLight.additionalData.intensity
                    : float.NaN;

            LogUtils.Info(
                string.Format(
                    CultureInfo.InvariantCulture,
                    "[CWD-DN-VANILLA] dayNightVisual={0} overrideTime={1} time={2:F3} day={3} dayOfYear={4:F3} year={5} storedLat={6:F4} storedLon={7:F4} debugTimeMultiplier={8:F3} sunLimit=({9:F6},{10:F6}) sunValid={11} sunPos=({12:F6},{13:F6},{14:F6}) sunForward=({15:F6},{16:F6},{17:F6}) sunIntensity={18:F3}",
                    dayNightVisual,
                    planetarySystem.overrideTime,
                    planetarySystem.time,
                    planetarySystem.day,
                    planetarySystem.dayOfYear,
                    planetarySystem.year,
                    planetarySystem.latitude,
                    planetarySystem.longitude,
                    planetarySystem.debugTimeMultiplier,
                    planetarySystem.sunLimit.x,
                    planetarySystem.sunLimit.y,
                    sunValid,
                    sunPosition.x,
                    sunPosition.y,
                    sunPosition.z,
                    sunForward.x,
                    sunForward.y,
                    sunForward.z,
                    sunIntensity));
        }
    }
}

#endif
