using System;
using System.IO;
using SerializedConfig.Test.Models.ConfigModelClassAttrib;
using SerializedConfig.Types.Serialization;
using Xunit;

namespace SerializedConfig.Test
{
    public class AttributesTest
    {
        private readonly string JSON_FILE_PATH = 
            $"{AppDomain.CurrentDomain.BaseDirectory}appsettings_json_atributes_test.json";

        private ConfigurationModelClassAttribute _configurationModelClassAttribute = new()
        {
            configurationString = "configurationString",
            configurationBool = false,
            configurationInt = 128,
            configurationFloat = 235.35f,
            configurationChar = 'R',
            configurationArray = new[] { "Bob", "Andrew" }
        };
        private ConfigurationModelPropertieAttribute _configurationModelPropertieAttribute = new() 
        {
            configurationString = "configurationString", 
            configurationBool = false,
            configurationInt = 128,
            configurationFloat = 235.35f,
            configurationChar = 'R',
            configurationArray = new[] { "Bob", "Andrew" }
        };
        private ConfigurationModelPropertieAttributesIncomplete _configurationModelPropertieAtribWithNull = new()
        {
            configurationString = "configurationString", 
            configurationBool = false,
            configurationInt = 128,
            configurationFloat = 235.35f,
            configurationChar = 'R',
            configurationArray = new[] { "Bob", "Andrew" }
        };

        [Fact]
        public void SerializeModelWithClassAttribTest()
        {
            ConfigManager<ConfigurationModelClassAttribute> _configManager = 
                new(JSON_FILE_PATH, SerializationFormat.Json, _configurationModelClassAttribute);
            _configManager.Save();
            
            Assert.True(File.Exists(JSON_FILE_PATH));
            File.Delete(JSON_FILE_PATH);
        }
        [Fact]
        public void SerializationModelWithPropertieAttribTest()
        {
            ConfigManager<ConfigurationModelPropertieAttribute> _configManager =
                new(JSON_FILE_PATH, SerializationFormat.Json, _configurationModelPropertieAttribute);
            _configManager.Save();
            
            Assert.True(File.Exists(JSON_FILE_PATH));
            File.Delete(JSON_FILE_PATH);
        }
        
        [Fact]
        public void SerializeModelWithNullPropertieTest()
        {
            ConfigManager<ConfigurationModelPropertieAttributesIncomplete> _configManager = 
                new(JSON_FILE_PATH, SerializationFormat.Json, _configurationModelPropertieAtribWithNull);
            _configManager.Save();
            
            Assert.True(File.Exists(JSON_FILE_PATH));
            
            _configManager.configuration = null;
            _configManager.Load();
            
            Assert.Null(_configManager.configuration.configurationBool);
            Assert.Null(_configManager.configuration.configurationFloat);
            Assert.Null(_configManager.configuration.configurationChar);
            
            File.Delete(JSON_FILE_PATH);
        }
    }
}