using SerializedConfig.Types;
using Xunit;

namespace SerializedConfig.Test.ReadTests
{
    public class ReadConfig
    {
        [Fact]
        public void ReadConfigurationYaml()
        {
            Consts.configManager = new(Consts.SAVE_FILE_PATH_YAML, SerializationFormat.Yaml, Consts.configurationModel);
            Consts.configManager.Save();
            
            string personName = Consts.configManager.configuration.pessoa.name;
            Assert.Equal("Roger", personName);
        }
        
        [Fact]
        public void ReadConfigurationJson()
        {
            Consts.configManager = new(Consts.SAVE_FILE_PATH_JSON, SerializationFormat.Json, Consts.configurationModel);
            Consts.configManager.Save();
            
            string personName = Consts.configManager.configuration.pessoa.name;
            Assert.Equal("Roger", personName);
        }
    }
}