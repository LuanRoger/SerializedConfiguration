using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using SerializedConfig.Test.Models.ConfigModelClassParamAttrib;
using SerializedConfig.Types.Serialization;
using Xunit;

namespace SerializedConfig.Test
{
    [SuppressMessage("Assertions", "xUnit2002:Do not use null check on value type")]
    public class AttributesWithParameterJsonTest
    {
        private readonly string JSON_FILE_PATH = 
            $"{AppDomain.CurrentDomain.BaseDirectory}appsettings_json_param_atributes_test.json";
        private ConfigurationModelParamAttrib _configurationModelParamAttrib = new()
        {
            configurationString = "configurationString",
            configurationBool = false,
            configurationInt = 128,
            configurationFloat = 235.35f,
            configurationChar = 'R',
            configurationArray = new[] { "Bob", "Andrew" }
        };
        private ConfigurationModelIncompleteParamAttrib _configurationModelIncompleteParamAttrib = new()
        {
            configurationString = "configurationString",
            configurationBool = false,
            configurationInt = 128,
            configurationFloat = 235.35f,
            configurationChar = 'R',
            configurationArray = new[] { "Bob", "Andrew" }
        };
        
        [Fact]
        public void SaveConfigTest()
        {
            ConfigManager<ConfigurationModelParamAttrib> _configManager = new(JSON_FILE_PATH, SerializationFormat.Json,
                _configurationModelParamAttrib);
            _configManager.Save();
            
            Assert.True(File.Exists(JSON_FILE_PATH));
            File.Delete(JSON_FILE_PATH);
        }
        
        [Fact]
        public void CheckAllPropertiesNameTest()
        {
            ConfigManager<ConfigurationModelParamAttrib> _configManager = new(JSON_FILE_PATH, SerializationFormat.Json,
                _configurationModelParamAttrib);
            _configManager.Save();
            
            string configFileText = File.ReadAllText(JSON_FILE_PATH);
            File.Delete(JSON_FILE_PATH);
            
            Assert.Contains("stringConfigurationProp", configFileText);
            Assert.Contains("boolConfigurationProp", configFileText);
            Assert.Contains("intConfigurationProp", configFileText);
            Assert.Contains("floatConfigurationProp", configFileText);
            Assert.Contains("charConfigurationProp", configFileText);
            Assert.Contains("arrayConfigurationProp", configFileText);
        }
        [Fact]
        public void CheckAllPropertiesNameIncompleteModelTest()
        {
            ConfigManager<ConfigurationModelIncompleteParamAttrib> _configManager = new(JSON_FILE_PATH, SerializationFormat.Json,
                _configurationModelIncompleteParamAttrib);
            _configManager.Save();

            string configFileText = File.ReadAllText(JSON_FILE_PATH);
            File.Delete(JSON_FILE_PATH);
            
            Assert.Contains("configurationString", configFileText);
            Assert.Contains("boolConfigurationProp", configFileText);
            Assert.Contains("intConfigurationProp", configFileText);
            Assert.Contains("floatConfigurationProp", configFileText);
            Assert.Contains("charConfigurationProp", configFileText);
            Assert.DoesNotContain("configurationArray", configFileText);
        }
        
        [Fact]
        public void LoadPropertiesCheckNameValueTest()
        {
            ConfigManager<ConfigurationModelParamAttrib> _configManager = new(JSON_FILE_PATH, SerializationFormat.Json,
                _configurationModelParamAttrib);
            _configManager.Save();
            _configManager.configuration = null;
            _configManager.Load();
            
            Assert.NotNull(_configManager.configuration.configurationString);
            Assert.False(_configManager.configuration.configurationBool);
            Assert.NotNull(_configManager.configuration.configurationInt);
            Assert.NotNull(_configManager.configuration.configurationFloat);
            Assert.NotNull(_configManager.configuration.configurationChar);
            Assert.NotNull(_configManager.configuration.configurationArray);
        }
        [Fact]
        public void LadPropertiesCheckNameValueIncompleteModelTest()
        {
            ConfigManager<ConfigurationModelIncompleteParamAttrib> _configManager = new(JSON_FILE_PATH, SerializationFormat.Json,
                _configurationModelIncompleteParamAttrib);
            _configManager.Save();
            _configManager.configuration = null;
            _configManager.Load();
            
            Assert.NotNull(_configManager.configuration.configurationString);
            Assert.False(_configManager.configuration.configurationBool);
            Assert.NotNull(_configManager.configuration.configurationInt);
            Assert.NotNull(_configManager.configuration.configurationFloat);
            Assert.NotNull(_configManager.configuration.configurationChar);
            Assert.Null(_configManager.configuration.configurationArray);
        }
    }
}