using SerializedConfig.Exceptions;
using SerializedConfig.Test.Models.ConfigModelClassAttrib;
using SerializedConfig.Types.Serialization;
using Xunit;

namespace SerializedConfig.Test
{
    public class ExceptionsTest
    {
        private ConfigurationModelClassAttribute configurationModelClassAttribute { get; } = new();
        private ConfigManager<ConfigurationModelClassAttribute> _configManager { get; set; }
        
        private void YamlSerializationJsonFileConstructor()
        {
            _configManager = new(Consts.SAVE_FILE_PATH_JSON, SerializationFormat.Yaml, configurationModelClassAttribute);
        }
        private void JsonSerializationYamlFileConstructor()
        {
            _configManager = new(Consts.SAVE_FILE_PATH_YAML, SerializationFormat.Json, configurationModelClassAttribute);
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