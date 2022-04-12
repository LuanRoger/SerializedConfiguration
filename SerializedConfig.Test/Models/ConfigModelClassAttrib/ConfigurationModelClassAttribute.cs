using SerializedConfig.SectionsAttribute;
using SerializedConfig.Types.Model;
using YamlDotNet.Serialization;

namespace SerializedConfig.Test.Models.ConfigModelClassAttrib
{
    [ConfigSection]
    public class ConfigurationModelClassAttribute : IConfigurationModel, IConfiguration
    {
        public string configurationString { get; set; }
        public bool configurationBool { get; set; }
        public int configurationInt { get; set; }
        public float configurationFloat { get; set; }
        public char configurationChar { get; set; }
        public string[] configurationArray { get; set; }
    }
}