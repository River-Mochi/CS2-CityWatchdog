// File: DebugConsole/Attributes/GenerateEnumNameAttribute.cs
// Purpose: Marks debug-console methods with the enum name to generate.

namespace DebugConsole.Attributes
{
    using System;

    [AttributeUsage(AttributeTargets.Method)]
    internal sealed class GenerateEnumNameAttribute : Attribute
    {
        public GenerateEnumNameAttribute(string value)
        {
            EnumName = value;
        }

        public string EnumName { get; }
    }
}
