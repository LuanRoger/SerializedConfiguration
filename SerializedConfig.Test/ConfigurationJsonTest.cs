using System.IO;
using SerializedConfig.Test.Models;
using SerializedConfig.Types.Serialization;
using Xunit;

namespace SerializedConfig.Test
{
    public class ConfigurationJsonTest
    {
        private ConfigurationModelClassAtribute configurationModelClassAtribute { get; } = new()
        {
            configurationString = "configurationString", 
            configurationBool = false,
            configurationInt = 128,
            configurationFloat = 235.35f,
            configurationChar = 'R',
            configurationArray = new[] { "Bob", "Andrew" }
        };
        private ConfigManager<ConfigurationModelClassAtribute> _configManager { get; }

        public ConfigurationJsonTest()
        {
            _configManager = new(Consts.SAVE_FILE_PATH_JSON, SerializationFormat.Json, configurationModelClassAtribute);
        }
        
        private void ResetConfigManager()
        {
            _configManager.configuration = null;
        }
        
        [Fact]
        public void SaveConfigurationJson()
        {
            _configManager.Save();
            
            Assert.True(File.Exists(Consts.SAVE_FILE_PATH_JSON));
        }
        
        [Fact]
        public void LoadConfigurationJson()
        {
            ResetConfigManager();
            
            _configManager.Load();
            
            Assert.NotNull(_configManager.configuration);
        }
    }
}