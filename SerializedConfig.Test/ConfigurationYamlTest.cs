using System.IO;
using SerializedConfig.Test.Models.ConfigModelClassAttrib;
using SerializedConfig.Types.Serialization;
using Xunit;

namespace SerializedConfig.Test
{
    public class ConfigurationYamlTest
    {
        private ConfigurationModelClassAttribute _configurationModelClassAttribute = new()
        {
            configurationString = "configurationString", 
            configurationBool = false,
            configurationInt = 128,
            configurationFloat = 235.35f,
            configurationChar = 'R',
            configurationArray = new[] { "Bob", "Andrew" }
        };
        private ConfigManager<ConfigurationModelClassAttribute> _configManager { get; set; }

        public ConfigurationYamlTest()
        {
            _configManager = new(Consts.SAVE_FILE_PATH_YAML, SerializationFormat.Yaml, _configurationModelClassAttribute);
        }

        [Fact]
        public void SaveConfigurationYaml()
        {
            _configManager.Save();
            
            Assert.True(File.Exists(Consts.SAVE_FILE_PATH_YAML));
        }
        
        [Fact]
        public void LoadConfigurationYaml()
        {
            _configManager.Save();
            _configManager.configuration = null;
            
            Assert.True(File.Exists(Consts.SAVE_FILE_PATH_YAML));
            Assert.Null(_configManager.configuration);

            _configManager.Load();
            
            Assert.NotNull(_configManager.configuration);
        }
    }
}