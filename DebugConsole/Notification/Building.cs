// File: DebugConsole/Notification/Building.cs
// Purpose: Generates building notification helper output for City Watchdog development.

namespace DebugConsole.Notification
{
    using Game.Prefabs;
    using System.Collections.Generic;
    using System.Linq;

    internal class Building : NotificationBase<BuildingConfigurationData>
    {
        public Building()
        {
        }

        protected override List<string> GetEnumList()
        {
            return NotificationRawName.Select(item => item[2..]).ToList();
        }

        public override string[] GetSvgSources()
        {
            return new string[]
            {
                "media/Game/Notifications/BuildingCollapsed.svg",
                "media/Game/Notifications/BuildingAbandoned.svg",
                "media/Game/Notifications/BuildingCondemned.svg",
                "",
                "media/Game/Notifications/TurnedOff.svg",
                "media/Game/Notifications/RentTooHigh.svg",
            };
        }

        public override string[] GetPrefabNames()
        {
            return new string[]
            {
                "Abandoned Collapsed",
                "Abandoned",
                "Condemned",
                "Building Level Up",
                "Turned Off",
                "Rent Too High",
            };
        }

        public override string[] GetLocalizedId()
        {
            return new string[]
            {
                "Collapsed",
                "Abandoned",
                "Condemned",
                "Building Level Up",
                "Deactivated",
                "High rent",
            };
        }
    }
}
