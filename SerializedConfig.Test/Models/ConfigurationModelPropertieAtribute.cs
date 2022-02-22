using SerializedConfig.SectionsAtribute;
using SerializedConfig.Types;

namespace SerializedConfig.Test.Models
{
    public class ConfigurationModelPropertieAtribute : IConfigurationModel, IConfiguration
    {
        [Section]
        public string configurationString { get; set; }
        [Section]
        public bool configurationBool { get; set; }
        [Section]
        public int configurationInt { get; set; }
        [Section]
        public float configurationFloat { get; set; }
        [Section]
        public char configurationChar { get; set; }
        [Section]
        public string[] configurationArray { get; set; }
    }
}