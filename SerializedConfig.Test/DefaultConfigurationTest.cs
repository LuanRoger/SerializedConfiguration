using System;
using SerializedConfig.Test.Models;
using SerializedConfig.Types.Serialization;
using Xunit;

namespace SerializedConfig.Test
{
    public class DefaultConfigurationTest
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
        private readonly string JSON_FILE_TO_DEFAULT = $"{AppDomain.CurrentDomain.BaseDirectory}appsettings_default.json";
        
        public DefaultConfigurationTest()
        {
            _configManager = new(JSON_FILE_TO_DEFAULT, SerializationFormat.Json, configurationModelClassAtribute);
            _configManager.Save();
        }

        [Fact]
        public void ModifyMainConfigurationAndResetTest()
        {
            const string newString = "Hello World";
            const float newFloat = 578.78f;
            const char newChar = 'S';

            _configManager.configuration.configurationString = newString;
            _configManager.configuration.configurationFloat = newFloat;
            _configManager.configuration.configurationChar = newChar;
            
            Assert.Equal(newString, _configManager.configuration.configurationString);
            Assert.Equal(newFloat, _configManager.configuration.configurationFloat);
            Assert.Equal(newChar, _configManager.configuration.configurationChar);
            
            _configManager.Reset();
            
            Assert.Equal(configurationModelClassAtribute.configurationString,
                _configManager.configuration.configurationString);
            Assert.Equal(configurationModelClassAtribute.configurationFloat,
                _configManager.configuration.configurationFloat);
            Assert.Equal(configurationModelClassAtribute.configurationChar,
                _configManager.configuration.configurationChar);
        }
    }
}