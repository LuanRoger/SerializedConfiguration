using System.IO;
using SerializedConfig.Types.Model;
using SerializedConfig.Types.Serialization;
using YamlDotNet.Serialization;

namespace SerializedConfig.Serialization
{
    internal static class YamlSerialization
    {
        private static readonly ISerializer yamlSerializer = new SerializerBuilder()
            .ConfigureDefaultValuesHandling(DefaultValuesHandling.OmitNull)
            .Build();
        private static readonly IDeserializer yamlDeserializer = new DeserializerBuilder().Build();
        internal static void SerializeYaml<T>(this ConfigManager<T> configManager, 
            SerializationMode serializationMode = SerializationMode.SerializeConfig) where T : IConfigurationModel
        {
            string yamlConfigText = serializationMode == SerializationMode.SerializeConfig ? 
                yamlSerializer.Serialize(configManager.configuration) : 
                yamlSerializer.Serialize(configManager.defaultConfig);

            File.WriteAllText(configManager.filePath, yamlConfigText);
        }

        internal static T DeserializeYaml<T>(this ConfigManager<T> configManager) where T : IConfigurationModel
        {
            string yamlText = File.ReadAllText(configManager.filePath);
            
            return yamlDeserializer.Deserialize<T>(yamlText);
        } 
    }
}
