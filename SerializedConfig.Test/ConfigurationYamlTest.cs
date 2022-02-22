using System.IO;
using SerializedConfig.Test.Models;
using SerializedConfig.Types.Serialization;
using Xunit;

namespace SerializedConfig.Test
{
    public class ConfigurationYamlTest
    {
        private ConfigurationModelClassAtribute _configurationModelClassAtribute = new()
        {
            configurationString = "configurationString", 
            configurationBool = false,
            configurationInt = 128,
            configurationFloat = 235.35f,
            configurationChar = 'R',
            configurationArray = new[] { "Bob", "Andrew" }
        };
        private ConfigManager<ConfigurationModelClassAtribute> _configManager { get; set; }

        public ConfigurationYamlTest()
        {
            _configManager = new(Consts.SAVE_FILE_PATH_YAML, SerializationFormat.Yaml, _configurationModelClassAtribute);
        }
        
        private void ResetConfigManager()
        {
            _configManager.configuration = null;
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
            ResetConfigManager();
            
            _configManager.Load();
            
            Assert.NotNull(_configManager.configuration);
        }
    }
}