// <copyright file="GameSystemBaseExtension.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the MIT License; you may not use this file except in compliance with this License.
// See LICENSE file in the project root for full license information.
// This notice and the MIT License notice must be kept with
// all copies or substantial portions of this code.
// ================= </copyright> ======================

// File: src/Systems/GameSystemBaseExtension.cs
// Purpose: Small local system base helper so CityWatchdog does not depend on Mbyron26 CS2Shared.

namespace CityWatchdog.Systems
{
    using Colossal.Serialization.Entities;
    using Game;
    using System;

    public abstract partial class GameSystemBaseExtension : GameSystemBase
    {
        protected Type? SystemType { get; private set; }

        protected string SystemName => SystemType?.Name ?? string.Empty;

        protected GameMode Mode { get; private set; }

        protected bool InMainMenu => Mode == GameMode.MainMenu;

        protected bool InGame => Mode == GameMode.Game;

        protected bool NotInGame => !InGame;

        protected bool InEditor => Mode == GameMode.Editor;

        protected bool InGameOrEditor => Mode == GameMode.GameOrEditor;

        protected override void OnCreate()
        {
            base.OnCreate();
            SystemType = GetType();
            CityWatchdog.Mod.DebugLog(() => $"System created: {SystemName}");
        }

        protected override void OnDestroy()
        {
            CityWatchdog.Mod.DebugLog(() => $"System destroyed: {SystemName}");
            base.OnDestroy();
        }

        protected override void OnUpdate()
        {
        }

        protected override void OnGamePreload(Purpose purpose, GameMode mode)
        {
            base.OnGamePreload(purpose, mode);
            Mode = mode;
        }
    }
}
