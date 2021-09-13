using System.IO;
using SerializedConfig.Types;
using System.Text.Json;
using SerializedConfig.Types.Serialization;

namespace SerializedConfig.Serialization.Json
{
    internal static class JsonSerialization
    {
        internal static void SerializeJson<T>(this ConfigManager<T> configManager, 
            SerializationMode serializationMode = SerializationMode.SerializeConfig) where T : IConfigurationModel
        {
            JsonSerializerOptions serializerOptions = new()
            {
              IgnoreNullValues = true
            };
            
            string jsonText = 
                serializationMode == SerializationMode.SerializeConfig ? 
                JsonSerializer.Serialize(configManager.configuration, serializerOptions) :
                JsonSerializer.Serialize(configManager.defaultConfig, serializerOptions);
            
            File.WriteAllText(configManager.filePath, jsonText);
        }

        internal static T DeserializeJson<T>(this ConfigManager<T> configManager) where T : IConfigurationModel
        {
            string jsonText = File.ReadAllText(configManager.filePath);
            
            return JsonSerializer.Deserialize<T>(jsonText);
        }
    }
}