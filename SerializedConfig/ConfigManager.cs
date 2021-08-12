using System;
using System.IO;
using System.Reflection;
using SerializedConfig.Serialization;
using SerializedConfig.Serialization.Json;
using SerializedConfig.Serialization.Yaml;
using SerializedConfig.Types;

namespace SerializedConfig
{
    public class ConfigManager<T> where T : IConfigurationModel
    {
        public T configuration {get; set;}
        internal T defaultConfig {get; private set;}
        public string filePath { get; }
        public SerializationFormat serializationFormat { get; set; }
        public ConfigManager(string filePath, SerializationFormat serializationFormat, T configuration)
        {
            SetConfiguration(configuration);
            if(serializationFormat == SerializationFormat.Yaml && Path.GetExtension(filePath) == ".json" ||
               serializationFormat == SerializationFormat.Json && Path.GetExtension(filePath) == ".yaml" ||
               !Path.GetExtension(filePath).Equals(".yaml") && !Path.GetExtension(filePath).Equals(".json"))
            {
                throw new Exception("Extension don't combine with SerializationFormat");
            }
            this.filePath = filePath;
            this.serializationFormat = serializationFormat;
        }
        
        private void SetConfiguration(T configuration)
        {
            foreach (PropertyInfo property in configuration.GetType().GetProperties())
            {
                object[] cutomAtributes = property.GetCustomAttributes(true);
                if(cutomAtributes.Length == 0) 
                    property.SetValue(configuration, null);
                foreach (object atribute in cutomAtributes) 
                    if(atribute.GetType() != typeof(Section))
                        property.SetValue(configuration, null);
            }
            
            this.configuration = configuration;
        }
        //TODO - Criar metodo para setar o default

        public void Reset()
        {
            File.Delete(filePath);
            configuration = default;

            Save(SerializationMode.SerializeDefault);
            Load();
        }
        
        public void Load()
        {
            configuration = serializationFormat switch
            {
                SerializationFormat.Yaml => this.DeserializeYaml(),
                SerializationFormat.Json => this.DeserializeJson(),
                _ => throw new Exception("No format seted")
            };
        }
        private void Save(SerializationMode serializationMode)
        {
            switch (serializationFormat)
            {
                case SerializationFormat.Yaml:
                    this.SerializeYaml(serializationMode);
                    break;
                case SerializationFormat.Json:
                    this.SerializeJson(serializationMode);
                    break;
                default: throw new Exception("No format seted");
            }
        }
        public void Save()
        {
            switch (serializationFormat)
            {
                case SerializationFormat.Yaml:
                    this.SerializeYaml();
                    break;
                case SerializationFormat.Json:
                    this.SerializeJson();
                    break;
                default: throw new Exception("No format seted");
            }
        }
    }
}
