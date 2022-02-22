using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Reflection;
using SerializedConfig.Exceptions;
using SerializedConfig.SectionsAtribute;
using SerializedConfig.Serialization;
using SerializedConfig.Types;
using SerializedConfig.Types.Logical;
using SerializedConfig.Types.Serialization;

namespace SerializedConfig
{
    /// <summary>
    /// Manages settings.
    /// </summary>
    /// <typeparam name="T">Model type <c>IConfigurationModel</c></typeparam>
    public class ConfigManager<T> where T : IConfigurationModel
    {
        /// <summary>
        /// Current settings.
        /// </summary>
        public T configuration {get; set;}
        internal T defaultConfig {get; private set;}
        
        /// <summary>
        /// Path to settings file.
        /// </summary>
        public string filePath { get; }
        
        private SerializationFormat serializationFormat { get; }
        
        /// <summary>
        /// Instance new ConfigManager
        /// </summary>
        /// <param name="filePath">Path to settings file.</param>
        /// <param name="serializationFormat">Settings file serialization format.</param>
        /// <param name="configurationModel">IConfigurationModel base configuration class.</param>
        /// <exception cref="InvalidExtensionException">Occurs when the configuration file extension does not match
        /// the serialization format.</exception>
        public ConfigManager(string filePath, SerializationFormat serializationFormat, [NotNull] T configurationModel)
        {
            SetConfiguration(configurationModel, SetConfigurationMode.Main);
            SetConfiguration(configurationModel, SetConfigurationMode.Default);
            
            if(serializationFormat == SerializationFormat.Yaml && Path.GetExtension(filePath) == ".json" ||
               serializationFormat == SerializationFormat.Json && Path.GetExtension(filePath) == ".yaml" ||
               !Path.GetExtension(filePath).Equals(".yaml") && !Path.GetExtension(filePath).Equals(".json"))
                throw new InvalidExtensionException();
            
            this.filePath = filePath;
            this.serializationFormat = serializationFormat;
        }
        
        private void SetConfiguration(T configurationClass, SetConfigurationMode setConfigurationMode)
        {
            //Get atributes from class
            foreach (object classAtribute in configurationClass.GetType().GetCustomAttributes(true))
            {
                if (classAtribute is not SectionClass) continue;
                
                if(setConfigurationMode == SetConfigurationMode.Main)
                    configuration = configurationClass;
                else defaultConfig = configurationClass;
            }

            //Get atributes from class properties
            foreach (PropertyInfo property in configurationClass.GetType().GetProperties())
            {
                object[] cutomAtributes = property.GetCustomAttributes(true);
                
                if(cutomAtributes.Length == 0)
                    property.SetValue(configurationClass, null);
                
                foreach (object atribute in cutomAtributes) 
                    if(atribute is not Section)
                        property.SetValue(configurationClass, null);
            } 
            
            if(setConfigurationMode == SetConfigurationMode.Main)
                configuration = configurationClass;
            else defaultConfig = configurationClass;
        }
        
        /// <summary>
        /// Resets the current configuration file to the model.
        /// </summary>
        public void Reset()
        {
            configuration = default;

            Save(SerializationMode.SerializeDefault);
            Load();
        }
        
        /// <summary>
        /// Load the configuration file and store it in <c>configuration</c>.
        /// </summary>
        public void Load()
        {
            configuration = serializationFormat switch
            {
                SerializationFormat.Yaml => this.DeserializeYaml(),
                SerializationFormat.Json => this.DeserializeJson()
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
            }
        }
        
        /// <summary>
        /// Save current settings to configuration file.
        /// </summary>
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
            }
        }
    }
}
