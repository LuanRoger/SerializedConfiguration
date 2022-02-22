using SerializedConfig.Exceptions;
using SerializedConfig.Test.Models;
using SerializedConfig.Types.Serialization;
using Xunit;
using Xunit.Sdk;

namespace SerializedConfig.Test
{
    public class FileExtensionTest
    {
        private ConfigurationModelClassAtribute configurationModelClassAtribute { get; } = 
            new();
        private ConfigManager<ConfigurationModelClassAtribute> _configManager { get; set; }
        
        private void YamlSerializationJsonFileConstructor()
        {
            _configManager = new(Consts.SAVE_FILE_PATH_JSON, SerializationFormat.Yaml, configurationModelClassAtribute);
        }
        private void JsonSerializationYamlFileConstructor()
        {
            _configManager = new(Consts.SAVE_FILE_PATH_YAML, SerializationFormat.Json, configurationModelClassAtribute);
        }
        
        [Fact]
        public void YamlSerializationJsonFileTest()
        {
            Assert.Throws<InvalidExtensionException>(YamlSerializationJsonFileConstructor);
        }
        [Fact]
        public void JsonSerializationYamlFileTest()
        {
            Assert.Throws<InvalidExtensionException>(JsonSerializationYamlFileConstructor);
        }
    }
}