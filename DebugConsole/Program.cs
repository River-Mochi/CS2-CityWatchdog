// File: DebugConsole/Program.cs
// Purpose: Keeps the optional DebugConsole helper project buildable without compiling stale generator sources.

namespace DebugConsole
{
    using System;

    internal static class Program
    {
        public static void Main()
        {
            Console.WriteLine("CityWatchdog.DebugConsole is currently disabled.");
            Console.WriteLine("The archived generator sources are kept in the repo but are not required for the City Watchdog mod build.");
        }
    }
}
