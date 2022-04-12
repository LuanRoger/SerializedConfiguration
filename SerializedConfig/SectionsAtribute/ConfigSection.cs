using System;

namespace SerializedConfig.SectionsAtribute
{
    /// <summary>
    /// Sets all IConfigurationModel properties as sections.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public sealed class ConfigSection : Attribute { }
}