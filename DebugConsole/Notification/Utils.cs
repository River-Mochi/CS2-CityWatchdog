// File: DebugConsole/Notification/Utils.cs
// Purpose: Provides shared helper methods for debug-console notification generators.

namespace DebugConsole.Notification
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    internal static class Utils
    {
        public static Dictionary<string, string> CombineListsToDictionary(List<string> keys, List<string> values)
        {
            if (keys == null)
            {
                throw new ArgumentNullException(nameof(keys));
            }

            if (values == null)
            {
                throw new ArgumentNullException(nameof(values));
            }

            if (keys.Count != values.Count)
            {
                throw new ArgumentException("Both lists must be the same length.");
            }

            return keys.Zip(values, (key, value) => new { key, value })
                .ToDictionary(x => x.key, x => x.value);
        }

        public static List<string> GetNotificationRawName<T>()
        {
            List<string> list = new List<string>();

            IEnumerable<string> fieldsWithNotification = typeof(T)
                .GetFields(BindingFlags.Public | BindingFlags.Instance)
                .Where(field => field.Name.Contains("Notification"))
                .Select(field => field.Name);

            foreach (string fieldName in fieldsWithNotification)
            {
                list.Add(fieldName);
            }

            return list;
        }
    }
}
