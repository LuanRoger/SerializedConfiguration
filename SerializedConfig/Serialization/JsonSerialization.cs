using System.IO;
using Newtonsoft.Json;
using SerializedConfig.Types.JsonContracts;
using SerializedConfig.Types.Model;
using SerializedConfig.Types.Serialization;

namespace SerializedConfig.Serialization
{
    internal static class JsonSerialization
    {
        internal static void SerializeJson<T>(this ConfigManager<T> configManager, 
            SerializationMode serializationMode = SerializationMode.SerializeConfig) where T : IConfigurationModel
        {
            ConfigPropertyJsonResolver<T> contractResolver = new(configManager.configuration);
            JsonSerializerSettings serializerSettings = new()
            {
                NullValueHandling = NullValueHandling.Ignore,
                ContractResolver = contractResolver
            };
            
            string jsonText = 
                serializationMode == SerializationMode.SerializeConfig ?
                JsonConvert.SerializeObject(configManager.configuration, Formatting.Indented, serializerSettings) :
                JsonConvert.SerializeObject(configManager.defaultConfig, Formatting.Indented, serializerSettings);
            
            File.WriteAllText(configManager.filePath, jsonText);
        }

        internal static T DeserializeJson<T>(this ConfigManager<T> configManager) where T : IConfigurationModel
        {
            ConfigPropertyJsonResolver<T> contractResolver = new(configManager.configuration);
            JsonSerializerSettings serializerSettings = new()
            {
                NullValueHandling = NullValueHandling.Ignore,
                ContractResolver = contractResolver
            };
            
            string jsonText = File.ReadAllText(configManager.filePath);
            T ronaldo = JsonConvert.DeserializeObject<T>(jsonText, serializerSettings);
            return ronaldo;
        }
    }
}