using SerializedConfig.SectionsAtribute;
using SerializedConfig.Types;

namespace SerializedConfig.Test.Models
{
    [SectionClass]
    public class ConfigurationModelClassAtribute : IConfigurationModel, IConfiguration
    {
        public string configurationString { get; set; }
        public bool configurationBool { get; set; }
        public int configurationInt { get; set; }
        public float configurationFloat { get; set; }
        public char configurationChar { get; set; }
        public string[] configurationArray { get; set; }
    }
}