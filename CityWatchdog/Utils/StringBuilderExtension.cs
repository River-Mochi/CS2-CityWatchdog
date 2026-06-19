// <copyright file="StringBuilderExtension.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi, MIT License.
// See LICENSE file in the project root for full license info.
// This copyright notice and the MIT License notice must be kept
// with all copies or substantial portions of this code.
// ================= </copyright> ======================

// File: src/Utils/StringBuilderExtension.cs
// Purpose: Provides legacy StringBuilder extension methods used by City Watchdog debug logging.

namespace CityWatchdog.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public static class StringBuilderExtension
    {
        public static StringBuilder AppendLine(this StringBuilder stringBuilder, Action<StringBuilder> action, bool clearFirst = false)
        {
            if (clearFirst)
            {
                stringBuilder.Clear();
            }

            action(stringBuilder);
            return stringBuilder;
        }

        public static StringBuilder ClearAndAppendLine(this StringBuilder stringBuilder, string value, bool clear = true)
        {
            if (clear)
            {
                stringBuilder.Clear();
            }

            stringBuilder.AppendLine(value);
            return stringBuilder;
        }

        public static string ToString(this StringBuilder stringBuilder, Action<StringBuilder> action, bool clear = true)
        {
            if (clear)
            {
                stringBuilder.Clear();
            }

            action(stringBuilder);
            return stringBuilder.ToString();
        }

        public static string ToString(this StringBuilder stringBuilder, List<Action<StringBuilder>> actions)
        {
            stringBuilder.Clear();

            foreach (Action<StringBuilder> action in actions)
            {
                action(stringBuilder);
            }

            return stringBuilder.ToString();
        }
    }
}
