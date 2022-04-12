using SerializedConfig.SectionsAttribute;
using SerializedConfig.Types.Model;

namespace SerializedConfig.Test.Models.ConfigModelClassAttrib
{
    public class ConfigurationModelPropertieAttribute : IConfigurationModel, IConfiguration
    {
        [ConfigProperty]
        public string configurationString { get; set; }
        [ConfigProperty]
        public bool configurationBool { get; set; }
        [ConfigProperty]
        public int configurationInt { get; set; }
        [ConfigProperty]
        public float configurationFloat { get; set; }
        [ConfigProperty]
        public char configurationChar { get; set; }
        [ConfigProperty]
        public string[] configurationArray { get; set; }
    }
}