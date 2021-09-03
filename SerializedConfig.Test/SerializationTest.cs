using System.IO;
using SerializedConfig.Test.Serialization;
using SerializedConfig.Test.Util;
using Xunit;

namespace SerializedConfig.Test
{
    public class SerializationTest
    {
        [Fact]
        public void SerializationYamlTest()
        {
            SerializationYaml.Serialize();
            
            Assert.True(File.Exists(Consts.SAVE_FILE_PATH_YAML));
        }
        
        [Fact]
        public void SerializatinJsonTest()
        {
            SerializationJson.Serialize();
            
            Assert.True(File.Exists(Consts.SAVE_FILE_PATH_JSON));
        }
        
        [Fact]
        public void DeserializeYamlTest() => SerializationYaml.Deserialize();
        
        [Fact]
        public void DeserializeJsonTest() => SerializationJson.Deserialize();
    }
}