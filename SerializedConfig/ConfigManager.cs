using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Reflection;
using SerializedConfig.Exceptions;
using SerializedConfig.SectionsAtribute;
using SerializedConfig.Serialization;
using SerializedConfig.Serialization.Json;
using SerializedConfig.Serialization.Yaml;
using SerializedConfig.Types;
using SerializedConfig.Types.Logical;
using SerializedConfig.Types.Serialization;

namespace SerializedConfig
{
    public class ConfigManager<T> where T : IConfigurationModel
    {
        public T configuration {get; set;}
        internal T defaultConfig {get; private set;}
        public string filePath { get; }
        private SerializationFormat serializationFormat { get; }
        
        public ConfigManager(string filePath, SerializationFormat serializationFormat, [NotNull] T configuration)
        {
            SetConfiguration(configuration, SetConfigurationMode.Main);
            SetConfiguration(configuration, SetConfigurationMode.Default);
            
            if(serializationFormat == SerializationFormat.Yaml && Path.GetExtension(filePath) == ".json" ||
               serializationFormat == SerializationFormat.Json && Path.GetExtension(filePath) == ".yaml" ||
               !Path.GetExtension(filePath).Equals(".yaml") && !Path.GetExtension(filePath).Equals(".json"))
                throw new InvalidExtensionException();
            
            this.filePath = filePath;
            this.serializationFormat = serializationFormat;
        }
        
        private void SetConfiguration(T configurationClass, SetConfigurationMode setConfigurationMode)
        {
            if(configurationClass.GetType().GetCustomAttributes(true).Any())
            {
                object[] cutomAtributes = configurationClass.GetType().GetCustomAttributes(true);
                foreach (object atribute in cutomAtributes)
                    if(atribute is SectionClass)
                    {
                        if(setConfigurationMode == SetConfigurationMode.Main)
                            configuration = configurationClass;
                        else defaultConfig = configurationClass;   
                    }
                return;
            }
            
            foreach (PropertyInfo property in configurationClass.GetType().GetProperties())
            {
                object[] cutomAtributes = property.GetCustomAttributes(true);
                if(cutomAtributes.Length == 0) 
                    property.SetValue(configurationClass, null);
                
                foreach (object atribute in cutomAtributes) 
                    if(atribute.GetType() != typeof(Section))
                        property.SetValue(configurationClass, null);
            } 
            
            if(setConfigurationMode == SetConfigurationMode.Main)
                configuration = configurationClass;
            else defaultConfig = configurationClass;
        }

        public void Reset()
        {
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
