using System;

namespace SerializedConfig.SectionsAtribute
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    public sealed class Section : Attribute
    {
        
    }
}