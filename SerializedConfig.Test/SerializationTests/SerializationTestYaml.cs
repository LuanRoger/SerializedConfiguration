using System.IO;
using SerializedConfig.Types;
using Xunit;

namespace SerializedConfig.Test.SerializationTests
{
    public class SerializationTestYaml //TODO - Tornar os testes modulares
    {
        [Fact]
        public void SerializationYaml()
        {
            Consts.configManager = new(Consts.SAVE_FILE_PATH_YAML, SerializationFormat.Yaml, Consts.configurationModel);
            Consts.configManager.Save();
            
            Assert.True(File.Exists(Consts.SAVE_FILE_PATH_YAML));
        }
        
        [Fact]
        public void DeserializationYaml()
        {
            Consts.configManager = new(Consts.SAVE_FILE_PATH_YAML, SerializationFormat.Yaml, Consts.configurationModel);
            Consts.configManager.Load();
        }
    }
}