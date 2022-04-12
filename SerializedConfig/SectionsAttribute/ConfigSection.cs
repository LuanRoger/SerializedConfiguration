using System;

namespace SerializedConfig.SectionsAttribute
{
    /// <summary>
    /// Sets all IConfigurationModel properties as sections.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public sealed class ConfigSection : Attribute { }
}