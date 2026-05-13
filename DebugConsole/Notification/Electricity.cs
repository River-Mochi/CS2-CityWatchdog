// File: DebugConsole/Notification/Electricity.cs
// Purpose: Generates electricity notification helper output for City Watchdog development.

namespace DebugConsole.Notification
{
    using Game.Prefabs;
    using System.Collections.Generic;
    using System.Linq;

    internal class Electricity : NotificationBase<ElectricityParameterData>
    {
        public Electricity()
        {
            NotificationRawName.Add("m_LowVoltageNotConnectedPrefab");
            NotificationRawName.Add("m_HighVoltageNotConnectedPrefab");
        }

        protected override List<string> GetEnumList()
        {
            return NotificationRawName.Select(item => item[2..^6]).ToList();
        }

        public override string[] GetPrefabNames()
        {
            return new string[]
            {
                "Electricity Notification",
                "Electricity Bottleneck Notification",
                "Electricity Building Bottleneck Notification",
                "Electricity Not Enough Production Notification",
                "Electricity Transformer Out of Capacity",
                "Electricity Not Enough Connected Notification",
                "Battery Empty",
                "Powerline Not Connected - Low",
                "Powerline Not Connected",
            };
        }

        public override string[] GetSvgSources()
        {
            return new string[]
            {
                "media/Game/Notifications/NotEnoughElectricity.svg",
                "media/Game/Notifications/ElectricityBottleneck.svg",
                "media/Game/Notifications/BadServiceElectricity.svg",
                "media/Game/Notifications/LowProductionElectricity.svg",
                "media/Game/Notifications/OutOfCapacityElectricity.svg",
                "media/Game/Notifications/NotEnoughOutputLinesConnected.svg",
                "media/Game/Notifications/BatteryEmpty.svg",
                "media/Game/Notifications/PowerlineDisconnectedLow.svg",
                "media/Game/Notifications/PowerlineDisconnected.svg",
            };
        }

        public override string[] GetLocalizedId()
        {
            return new string[]
            {
                "Not enough electricity",
                "Electricity bottleneck",
                "Poor electricity flow",
                "Power station overload",
                "Transformer overload",
                "Not enough output lines connected",
                "Battery depleted",
                "Electric Cable not connected",
                "Power Line not connected",
            };
        }
    }
}
