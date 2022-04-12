using System.IO;
using SerializedConfig.Test.Models.ConfigModelClassAttrib;
using SerializedConfig.Types.Serialization;
using Xunit;

namespace SerializedConfig.Test
{
    public class ConfigurationJsonTest
    {
        private ConfigurationModelClassAttribute configurationModelClassAttribute { get; } = new()
        {
            configurationString = "configurationString", 
            configurationBool = false,
            configurationInt = 128,
            configurationFloat = 235.35f,
            configurationChar = 'R',
            configurationArray = new[] { "Bob", "Andrew" }
        };
        private ConfigManager<ConfigurationModelClassAttribute> _configManager { get; }

        public ConfigurationJsonTest()
        {
            _configManager = new(Consts.SAVE_FILE_PATH_JSON, SerializationFormat.Json, configurationModelClassAttribute);
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
            _configManager.Save();
            _configManager.configuration = null;
            
            Assert.True(File.Exists(Consts.SAVE_FILE_PATH_JSON));
            Assert.Null(_configManager.configuration);
            
            _configManager.Load();
            
            Assert.NotNull(_configManager.configuration);
        }
    }
}