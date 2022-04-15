using System.IO;
using System.Text;
using System.Threading.Tasks;
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
        private static readonly IDeserializer yamlDeserializer = new DeserializerBuilder()
            .Build();
        
        internal static void SerializeYaml<T>(this ConfigManager<T> configManager, 
            SerializationMode serializationMode = SerializationMode.SerializeConfig) where T : IConfigurationModel
        {
            string yamlConfigText = serializationMode == SerializationMode.SerializeConfig ? 
                yamlSerializer.Serialize(configManager.configuration) : 
                yamlSerializer.Serialize(configManager.defaultConfig);

            File.WriteAllText(configManager.filePath, yamlConfigText);
        }
        internal static async Task SerializeYamlAsync<T>(this ConfigManager<T> configManager, 
            SerializationMode serializationMode = SerializationMode.SerializeConfig) where T : IConfigurationModel
        {
            string yamlConfigText = serializationMode == SerializationMode.SerializeConfig ? 
                yamlSerializer.Serialize(configManager.configuration) : 
                yamlSerializer.Serialize(configManager.defaultConfig);

            byte[] yamlByte = new UTF8Encoding(true).GetBytes(yamlConfigText);
            await using FileStream fileStream = File.OpenWrite(configManager.filePath);
            await fileStream.WriteAsync(yamlByte);
        }

        internal static T DeserializeYaml<T>(this ConfigManager<T> configManager) where T : IConfigurationModel
        {
            string yamlText = File.ReadAllText(configManager.filePath);
            
            return yamlDeserializer.Deserialize<T>(yamlText);
        }
        internal static async Task<T> DeserializeYamlAsync<T>(this ConfigManager<T> configManager) 
            where T : IConfigurationModel
        {
            string yamlText;
            await using (FileStream fileStream = File.OpenRead(configManager.filePath))
            {
                byte[] buffer = new byte[fileStream.Length];
                await fileStream.ReadAsync(buffer);
                
                yamlText = new UTF8Encoding(true).GetString(buffer);
            }
            
            var yamlObject = Task.Run(() => yamlDeserializer.Deserialize<T>(yamlText));
            return await yamlObject;
        }
    }
}
