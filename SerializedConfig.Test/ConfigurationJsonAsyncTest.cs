using System;
using System.IO;
using SerializedConfig.Test.Models.ConfigModelClassAttrib;
using SerializedConfig.Types.Serialization;
using Xunit;

namespace SerializedConfig.Test
{
    public class ConfigurationJsonAsyncTest
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
        
        private readonly string SAVE_FILE_PATH_JSON_ASYNC_TASK = AppDomain.CurrentDomain.BaseDirectory + "appsettings_async.json";

        public ConfigurationJsonAsyncTest()
        {
            _configManager = new(SAVE_FILE_PATH_JSON_ASYNC_TASK, SerializationFormat.Json, configurationModelClassAttribute);
        }
        
        [Fact]
        public async void SaveConfigurationJsonAsyncTest()
        {
            await _configManager.SaveAsync();
            
            Assert.True(File.Exists(SAVE_FILE_PATH_JSON_ASYNC_TASK));
            
            File.Delete(SAVE_FILE_PATH_JSON_ASYNC_TASK);
        }
        [Fact]
        public async void LoadConfigurationJsonAsyncTest()
        {
            _configManager.Save();
            _configManager.configuration = null;
            await _configManager.LoadAsync();
                
            Assert.NotNull(_configManager.configuration);
            
            File.Delete(SAVE_FILE_PATH_JSON_ASYNC_TASK);
        }
    }
}