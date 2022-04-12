using SerializedConfig.SectionsAttribute;
using SerializedConfig.Types.Model;

namespace SerializedConfig.Test.Models.ConfigModelClassParamAttrib
{
    public class ConfigurationModelParamAttrib : IConfiguration, IConfigurationModel
    {
        [ConfigProperty("stringConfigurationProp")]
        public string configurationString { get; set; }
        [ConfigProperty("boolConfigurationProp")]
        public bool configurationBool { get; set; }
        [ConfigProperty("intConfigurationProp")]
        public int configurationInt { get; set; }
        [ConfigProperty("floatConfigurationProp")]
        public float configurationFloat { get; set; }
        [ConfigProperty("charConfigurationProp")]
        public char configurationChar { get; set; }
        [ConfigProperty("arrayConfigurationProp")]
        public string[] configurationArray { get; set; }
    }
}