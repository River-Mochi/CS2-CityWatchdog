// File: DebugConsole/Notification/Traffic.cs
// Purpose: Generates traffic notification helper output for City Watchdog development.

namespace DebugConsole.Notification
{
    using Game.Prefabs;
    using System.Collections.Generic;
    using System.Linq;

    internal class Traffic : NotificationBase<TrafficConfigurationData>
    {
        public Traffic()
        {
        }

        protected override List<string> GetEnumList()
        {
            return NotificationRawName.Select(item => item[2..]).ToList();
        }

        public override string[] GetPrefabNames()
        {
            return new string[]
            {
                "Traffic Bottleneck Notification",
                "Dead End",
                "No Road Access",
                "Track Not Connected",
                "No Car Access",
                "No Watercraft Access",
                "No Train Access",
                "No Pedestrian Access",
            };
        }

        public override string[] GetLocalizedId()
        {
            return new string[]
            {
                "Traffic jam",
                "Dead end",
                "Road required",
                "Track not connected",
                "No car access",
                "No waterway connection",
                "No track connection",
                "No pedestrian access",
            };
        }

        public override string[] GetSvgSources()
        {
            return new string[]
            {
                "media/Game/Notifications/TrafficBottleneck.svg",
                "media/Game/Notifications/DeadEnd.svg",
                "media/Game/Notifications/RoadNotConnected.svg",
                "media/Game/Notifications/TrackNotConnected.svg",
                "media/Game/Notifications/NoCarAccess.svg",
                "media/Game/Notifications/NoBoatAccess.svg",
                "media/Game/Notifications/NoTrainAccess.svg",
                "media/Game/Notifications/NoPedestrianAccess.svg",
            };
        }
    }
}
