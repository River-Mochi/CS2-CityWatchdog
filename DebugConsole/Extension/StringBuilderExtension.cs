// File: DebugConsole/Extension/StringBuilderExtension.cs
// Purpose: Provides StringBuilder helper methods for debug-console generators.

namespace DebugConsole.Extension
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public static class StringBuilderExtension
    {
        public static StringBuilder AppendLine(this StringBuilder stringBuilder, Action<StringBuilder> action, bool clearFirst = false)
        {
            if (stringBuilder == null)
            {
                throw new ArgumentNullException(nameof(stringBuilder));
            }

            if (action == null)
            {
                throw new ArgumentNullException(nameof(action));
            }

            if (clearFirst)
            {
                stringBuilder.Clear();
            }

            action(stringBuilder);
            return stringBuilder;
        }

        public static StringBuilder ClearAndAppendLine(this StringBuilder stringBuilder, string value, bool clear = true)
        {
            if (stringBuilder == null)
            {
                throw new ArgumentNullException(nameof(stringBuilder));
            }

            if (clear)
            {
                stringBuilder.Clear();
            }

            stringBuilder.AppendLine(value);
            return stringBuilder;
        }

        public static string ToString(this StringBuilder stringBuilder, Action<StringBuilder> action, bool clear = true)
        {
            if (stringBuilder == null)
            {
                throw new ArgumentNullException(nameof(stringBuilder));
            }

            if (action == null)
            {
                throw new ArgumentNullException(nameof(action));
            }

            if (clear)
            {
                stringBuilder.Clear();
            }

            action(stringBuilder);
            return stringBuilder.ToString();
        }

        public static string ToString(this StringBuilder stringBuilder, List<Action<StringBuilder>> actions)
        {
            if (stringBuilder == null)
            {
                throw new ArgumentNullException(nameof(stringBuilder));
            }

            if (actions == null)
            {
                throw new ArgumentNullException(nameof(actions));
            }

            stringBuilder.Clear();

            foreach (Action<StringBuilder> action in actions)
            {
                action(stringBuilder);
            }

            return stringBuilder.ToString();
        }
    }
}
