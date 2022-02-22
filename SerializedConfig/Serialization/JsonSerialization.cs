using System.IO;
using Newtonsoft.Json;
using SerializedConfig.Types;
using SerializedConfig.Types.Serialization;

namespace SerializedConfig.Serialization
{
    internal static class JsonSerialization
    {
        private static readonly JsonSerializerSettings serializerSettings = new()
        {
            NullValueHandling = NullValueHandling.Ignore
        };
        internal static void SerializeJson<T>(this ConfigManager<T> configManager, 
            SerializationMode serializationMode = SerializationMode.SerializeConfig) where T : IConfigurationModel
        {
            string jsonText = 
                serializationMode == SerializationMode.SerializeConfig ?
                JsonConvert.SerializeObject(configManager.configuration, Formatting.Indented, serializerSettings) :
                JsonConvert.SerializeObject(configManager.defaultConfig, Formatting.Indented, serializerSettings);
            
            File.WriteAllText(configManager.filePath, jsonText);
        }

        internal static T DeserializeJson<T>(this ConfigManager<T> configManager) where T : IConfigurationModel
        {
            string jsonText = File.ReadAllText(configManager.filePath);
            var ronaldo = JsonConvert.DeserializeObject<T>(jsonText, serializerSettings);
            return ronaldo;
        }
    }
}