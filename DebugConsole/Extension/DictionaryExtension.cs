// File: DebugConsole/Extension/DictionaryExtension.cs
// Purpose: Provides dictionary iteration helpers for debug-console generators.

namespace DebugConsole.Extension
{
    using System;
    using System.Collections.Generic;

    public static class DictionaryExtensions
    {
        public static void ForEach<TKey, TValue>(
            this Dictionary<TKey, TValue> dictionary,
            Action<TKey, TValue> action)
            where TKey : notnull
        {
            if (dictionary == null)
            {
                throw new ArgumentNullException(nameof(dictionary));
            }

            if (action == null)
            {
                throw new ArgumentNullException(nameof(action));
            }

            foreach (KeyValuePair<TKey, TValue> kvp in dictionary)
            {
                action(kvp.Key, kvp.Value);
            }
        }
    }
}
