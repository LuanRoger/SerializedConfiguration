using SerializedConfig.SectionsAtribute;
using SerializedConfig.Types;

namespace SerializedConfig.Test.Models
{
    public class ConfigurationModelPropertieAtributesIncomplete : IConfigurationModel
    {
        [Section]
        public string configurationString { get; set; }
        public bool? configurationBool { get; set; }
        [Section]
        public int configurationInt { get; set; }
        public float? configurationFloat { get; set; }
        public char? configurationChar { get; set; }
        [Section]
        public string[] configurationArray { get; set; }
    }
}