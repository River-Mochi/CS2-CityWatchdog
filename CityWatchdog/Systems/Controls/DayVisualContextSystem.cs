// <copyright file="DayVisualContextSystem.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the MIT License. You may not use this file except in compliance with this License.
// See LICENSE file in the project root for full license information.
// This notice and the MIT License notice must be kept with
// all copies or substantial portions of this code.
// ================= </copyright> ======================

// File: Systems/Controls/DayVisualContextSystem.cs
// Purpose: Applies a cached fixed-Day sun after PlanetarySystem without changing saved map coordinates.

namespace CityWatchdog.Systems
{
    using Game.Simulation;

    using UnityEngine;

    public partial class DayVisualContextSystem : GameSystemBaseExtension
    {
        // Precomputed with vanilla's confirmed fixed-Day context:
        // year 2020, day 177, latitude 51.2277, longitude 6.7735.
        // This avoids running astronomical math every rendered frame.
        private static readonly Vector3 s_BrightSunPosition =
            new(-0.107177803f, 0.880243167f, -0.462260625f);

        private static readonly Vector3 s_VanillaSunPosition =
            new(-0.548586868f, 0.770204342f, -0.325327097f);

        private static readonly Vector3 s_SoftSunPosition =
            new(-0.744488419f, 0.645575483f, -0.170203672f);

        private PlanetarySystem m_PlanetarySystem = null!;

        private Vector3 m_SunPosition;
        private Quaternion m_SunRotation;
        private float m_ExpectedHour;
        private float m_MapLatitudeAtActivation;
        private float m_MapLongitudeAtActivation;

        protected override void OnCreate()
        {
            base.OnCreate();

            m_PlanetarySystem =
                World.GetOrCreateSystemManaged<PlanetarySystem>();

            // Zero update cost until the player actually selects CWD Day.
            Enabled = false;
        }

        protected override void OnUpdate()
        {
            // If another time mod changed the active context after CWD, stop applying CWD's sun.
            // This keeps the existing "last mod wins" behavior.
            if (!m_PlanetarySystem.overrideTime ||
                Mathf.Abs(m_PlanetarySystem.time - m_ExpectedHour) > 0.01f ||
                m_PlanetarySystem.day != DayNightControlSystem.kVanillaDay ||
                m_PlanetarySystem.year != DayNightControlSystem.kVanillaDayYear ||
                Mathf.Abs(
                    m_PlanetarySystem.latitude -
                    m_MapLatitudeAtActivation) > 0.0001f ||
                Mathf.Abs(
                    m_PlanetarySystem.longitude -
                    m_MapLongitudeAtActivation) > 0.0001f)
            {
                Enabled = false;
                return;
            }

            PlanetarySystem.LightData sunLight =
                m_PlanetarySystem.SunLight;

            if (!sunLight.isValid)
            {
                return;
            }

            // PlanetarySystem just recalculated using the map coordinates.
            // Replace only the runtime SunLight with the cached fixed-Day result.
            sunLight.transform.position = m_SunPosition;
            sunLight.transform.rotation = m_SunRotation;

            if (sunLight.additionalData != null)
            {
                // All three Day presets are high enough for vanilla's full daytime intensity.
                sunLight.additionalData.intensity =
                    sunLight.initialIntensity;
            }
        }

        internal void Activate(
            int preset,
            float expectedHour,
            float mapLatitude,
            float mapLongitude)
        {
            m_SunPosition = preset switch
            {
                CwdSettings.kDayVisualPresetBright =>
                    s_BrightSunPosition,
                CwdSettings.kDayVisualPresetSoft =>
                    s_SoftSunPosition,
                _ =>
                    s_VanillaSunPosition,
            };

            m_SunRotation =
                Quaternion.LookRotation(
                    -m_SunPosition,
                    Vector3.up);

            m_ExpectedHour = expectedHour;
            m_MapLatitudeAtActivation = mapLatitude;
            m_MapLongitudeAtActivation = mapLongitude;

            Enabled = true;
        }

        internal void Deactivate()
        {
            Enabled = false;
        }
    }
}
