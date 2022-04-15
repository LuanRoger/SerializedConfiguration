using System.IO;
using System.Text;
using System.Threading.Tasks;
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
        internal static async Task SerializeJsonAsync<T>(this ConfigManager<T> configManager, 
            SerializationMode serializationMode = SerializationMode.SerializeConfig) where T : IConfigurationModel
        {
            ConfigPropertyJsonResolver<T> contractResolver = new(configManager.configuration);
            JsonSerializerSettings serializerSettings = new()
            {
                NullValueHandling = NullValueHandling.Ignore,
                ContractResolver = contractResolver
            };
            
            Task<string> jsonText = 
                serializationMode == SerializationMode.SerializeConfig ?
                    Task.Run(() => JsonConvert.SerializeObject(configManager.configuration, Formatting.Indented, serializerSettings)) :
                    Task.Run(() => JsonConvert.SerializeObject(configManager.defaultConfig, Formatting.Indented, serializerSettings));

            byte[] jsonByte = new UTF8Encoding(true).GetBytes(await jsonText);
            await using FileStream fileStream = File.OpenWrite(configManager.filePath);
            
            await fileStream.WriteAsync(jsonByte);
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
            T configObject = JsonConvert.DeserializeObject<T>(jsonText, serializerSettings);
            return configObject;
        }
        internal static async Task<T> DeserializeJsonAsync<T>(this ConfigManager<T> configManager) where T : IConfigurationModel
        {
            ConfigPropertyJsonResolver<T> contractResolver = new(configManager.configuration);
            JsonSerializerSettings serializerSettings = new()
            {
                NullValueHandling = NullValueHandling.Ignore,
                ContractResolver = contractResolver
            };
            
            string jsonText;
            await using (FileStream fileStream = File.OpenRead(configManager.filePath))
            {
                byte[] buffer = new byte[fileStream.Length];
                await fileStream.ReadAsync(buffer);
                jsonText = new UTF8Encoding(true).GetString(buffer);
            }
            
            var configObject = Task.Run(() => JsonConvert.DeserializeObject<T>(jsonText, serializerSettings));
            return await configObject;
        }
    }
}