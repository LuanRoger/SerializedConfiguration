using System;
using System.Collections.Generic;
using System.IO;
using SerializedConfig.Types;
using YamlDotNet.Serialization;

namespace SerializedConfig.Serialization.Yaml
{
    internal static class YamlSerialization
    {
        internal static void SerializeYaml<T>(this ConfigManager<T> configManager, 
            SerializationMode serializationMode = SerializationMode.SerializeConfig) where T : IConfigurationModel
        {
            ISerializer yamlSerializer = new SerializerBuilder()
                .ConfigureDefaultValuesHandling(DefaultValuesHandling.OmitNull)
                .Build();

            string yamlConfigText = serializationMode == SerializationMode.SerializeConfig ? 
                yamlSerializer.Serialize(configManager.configuration) : 
                yamlSerializer.Serialize(configManager.defaultConfig);

            File.WriteAllText(configManager.filePath, yamlConfigText);
        }

        internal static T DeserializeYaml<T>(this ConfigManager<T> configManager) where T : IConfigurationModel
        {
            IDeserializer yamlDeserializer = new DeserializerBuilder().Build();
            
            string yamlText = File.ReadAllText(configManager.filePath);
            
            return yamlDeserializer.Deserialize<T>(yamlText);
        } 
    }
}
