using SerializedConfig.Types;
using Xunit;

namespace SerializedConfig.Test.WriteTest
{
    public class WriteConfig
    {
        [Fact]
        public void WriteConfigurationYaml()
        {
            Consts.configManager = new(Consts.SAVE_FILE_PATH_YAML, SerializationFormat.Yaml, Consts.configurationModel);
            Consts.configurationModel.pessoa.name = "Foo";
            
            Consts.configManager.Save();
            Consts.configManager.Load();
            
            Assert.Equal("Foo", Consts.configManager.configuration.pessoa.name);
        }
        
        [Fact]
        public void WriteConfigurationJson()
        {
            Consts.configManager = new(Consts.SAVE_FILE_PATH_JSON, SerializationFormat.Json, Consts.configurationModel);
            Consts.configurationModel.pessoa.name = "Foo";
            
            Consts.configManager.Save();
            Consts.configManager.Load();
            
            Assert.Equal("Foo", Consts.configManager.configuration.pessoa.name);
        }
    }
}