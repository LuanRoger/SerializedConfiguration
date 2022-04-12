using System;

namespace SerializedConfig.SectionsAttribute
{
    /// <summary>
    /// Defines a property of the IConfigurationModel class as the configuration section.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public sealed class ConfigProperty : Attribute
    {
        private string? propertyName { get; }

        public ConfigProperty(string? propertyName = null)
        {
            this.propertyName = propertyName;
        }
    }
}