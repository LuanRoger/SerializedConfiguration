using System;
using System.IO;
using SerializedConfig.Test.Models.ConfigModelClassAttrib;
using SerializedConfig.Types.Serialization;
using Xunit;

namespace SerializedConfig.Test
{
    public class ConfigurationYamlAsyncTest
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
        
        private readonly string SAVE_FILE_PATH_YAML_ASYNC_TASK = AppDomain.CurrentDomain.BaseDirectory + "appsettings_async.yaml";

        public ConfigurationYamlAsyncTest()
        {
            _configManager = new(SAVE_FILE_PATH_YAML_ASYNC_TASK, SerializationFormat.Yaml, configurationModelClassAttribute);
        }
        
        [Fact]
        public async void SaveConfigurationYamlTest()
        {
            await _configManager.SaveAsync();
            
            Assert.True(File.Exists(SAVE_FILE_PATH_YAML_ASYNC_TASK));
            
            File.Delete(SAVE_FILE_PATH_YAML_ASYNC_TASK);
        }
        
        [Fact]
        public async void LoadConfigurationYam()
        {
            _configManager.Save();
            _configManager.configuration = null;
            await _configManager.LoadAsync();
            
            Assert.NotNull(_configManager.configuration);
            File.Delete(SAVE_FILE_PATH_YAML_ASYNC_TASK);
        }
    }
}