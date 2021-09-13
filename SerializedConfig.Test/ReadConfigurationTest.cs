﻿using SerializedConfig.Test.Serialization;
using SerializedConfig.Test.Util;
using Xunit;

namespace SerializedConfig.Test
{
    public class ReadConfigurationTest
    {
        [Fact]
        public void ReadConfigurationYamlTest()
        {
            SerializationYaml.Serialize();
            
            Consts.configManager.configuration = null;
            
            SerializationYaml.Deserialize();
            
            Assert.Equal("Bob", Consts.configManager.configuration.person.name);
        }
        
        [Fact]
        public void ReadConfigurationJsonTest()
        {
            SerializationJson.Serialize();
            
            Consts.configManager.configuration = null;
            
            SerializationJson.Deserialize();
            
            Assert.True(Consts.configManager.configuration.anotherPerson.name == "Anders");
        }
    }
}