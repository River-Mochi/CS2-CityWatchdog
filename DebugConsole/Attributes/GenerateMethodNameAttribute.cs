// File: DebugConsole/Attributes/GenerateMethodNameAttribute.cs
// Purpose: Marks debug-console methods with the output method name to generate.

namespace DebugConsole.Attributes
{
    using System;

    [AttributeUsage(AttributeTargets.Method)]
    internal sealed class GenerateMethodNameAttribute : Attribute
    {
        public GenerateMethodNameAttribute(string value)
        {
            Value = value;
        }

        public string Value { get; }
    }
}
