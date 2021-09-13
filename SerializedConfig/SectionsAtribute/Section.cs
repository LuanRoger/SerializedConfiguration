using System;

namespace SerializedConfig.SectionsAtribute
{
    /// <summary>
    /// Defines a property of the IConfigurationModel class as the configuration section.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    public sealed class Section : Attribute { }
}