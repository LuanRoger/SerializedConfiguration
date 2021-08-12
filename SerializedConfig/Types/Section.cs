using System;

namespace SerializedConfig.Types
{
    [AttributeUsage(AttributeTargets.Property)]
    public sealed class Section : Attribute
    {
    }
}