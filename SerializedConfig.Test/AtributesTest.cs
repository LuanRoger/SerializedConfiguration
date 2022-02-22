using System;
using System.IO;
using SerializedConfig.Test.Models;
using SerializedConfig.Types.Serialization;
using Xunit;

namespace SerializedConfig.Test
{
    public class AtributesTest
    {
        private readonly string JSON_FILE_PATH = 
            $"{AppDomain.CurrentDomain.BaseDirectory}appsettings_json_atributes_test.json";

        private ConfigurationModelClassAtribute _configurationModelClassAtribute = new()
        {
            configurationString = "configurationString",
            configurationBool = false,
            configurationInt = 128,
            configurationFloat = 235.35f,
            configurationChar = 'R',
            configurationArray = new[] { "Bob", "Andrew" }
        };
        private ConfigurationModelPropertieAtribute _configurationModelPropertieAtribute = new() 
        {
            configurationString = "configurationString", 
            configurationBool = false,
            configurationInt = 128,
            configurationFloat = 235.35f,
            configurationChar = 'R',
            configurationArray = new[] { "Bob", "Andrew" }
        };
        private ConfigurationModelPropertieAtributesIncomplete _configurationModelPropertieAtribWithNull = new()
        {
            configurationString = "configurationString", 
            configurationBool = false,
            configurationInt = 128,
            configurationFloat = 235.35f,
            configurationChar = 'R',
            configurationArray = new[] { "Bob", "Andrew" }
        };

        [Fact]
        public void SerializeModelWithClassAtribTest()
        {
            ConfigManager<ConfigurationModelClassAtribute> _configManager = 
                new(JSON_FILE_PATH, SerializationFormat.Json, _configurationModelClassAtribute);
            _configManager.Save();
            
            Assert.True(File.Exists(JSON_FILE_PATH));
            File.Delete(JSON_FILE_PATH);
        }
        [Fact]
        public void SerializationModelWithPropertieAtribTest()
        {
            ConfigManager<ConfigurationModelPropertieAtributesIncomplete> _configManager =
                new(JSON_FILE_PATH, SerializationFormat.Json, _configurationModelPropertieAtribWithNull);
            _configManager.Save();
            
            Assert.True(File.Exists(JSON_FILE_PATH));
            File.Delete(JSON_FILE_PATH);
        }
        
        [Fact]
        public void SerializeModelWithNullPropertieTest()
        {
            ConfigManager<ConfigurationModelPropertieAtributesIncomplete> _configManager = 
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