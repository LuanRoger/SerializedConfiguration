using System.IO;
using SerializedConfig.Types;
using Xunit;

namespace SerializedConfig.Test.SerializationTests
{
    public class SerializationTestJson
    {
        [Fact]
        public void SerializationJson()
        {
            Consts.configManager = new(Consts.SAVE_FILE_PATH_JSON, SerializationFormat.Json, Consts.configurationModel);
            Consts.configManager.Save();
            
            Assert.True(File.Exists(Consts.SAVE_FILE_PATH_JSON));
        }
        
        [Fact]
        public void DeserializationJson()
        {
            Consts.configManager = new(Consts.SAVE_FILE_PATH_JSON, SerializationFormat.Json, Consts.configurationModel);
            Consts.configManager.Load();
        }
    }
}