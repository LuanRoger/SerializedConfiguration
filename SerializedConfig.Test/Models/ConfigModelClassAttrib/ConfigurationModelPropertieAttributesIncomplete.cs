using SerializedConfig.SectionsAttribute;
using SerializedConfig.Types.Model;

namespace SerializedConfig.Test.Models.ConfigModelClassAttrib
{
    public class ConfigurationModelPropertieAttributesIncomplete : IConfigurationModel
    {
        [ConfigProperty]
        public string configurationString { get; set; }
        public bool? configurationBool { get; set; }
        [ConfigProperty]
        public int configurationInt { get; set; }
        public float? configurationFloat { get; set; }
        public char? configurationChar { get; set; }
        [ConfigProperty]
        public string[] configurationArray { get; set; }
    }
}