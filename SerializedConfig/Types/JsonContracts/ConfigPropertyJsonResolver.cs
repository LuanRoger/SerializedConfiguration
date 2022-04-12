using System.Linq;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using SerializedConfig.SectionsAtribute;
using SerializedConfig.Types.Model;

namespace SerializedConfig.Types.JsonContracts
{
    internal class ConfigPropertyJsonResolver<T> : DefaultContractResolver where T : IConfigurationModel 
    {
        private T configClassInstance { get; }

        public ConfigPropertyJsonResolver(T configClassInstance)
        {
            this.configClassInstance = configClassInstance;
        }

        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            JsonProperty jsonProperty = base.CreateProperty(member, memberSerialization);
            
            CustomAttributeData customAttributes = member.CustomAttributes
                .FirstOrDefault(attribute => attribute.AttributeType == typeof(ConfigProperty));
            if(customAttributes is null) return jsonProperty;
            
            object propertyName = customAttributes.ConstructorArguments[0].Value;
            if(propertyName is null) return jsonProperty;
            
            jsonProperty.PropertyName = (string)propertyName;

            return jsonProperty;
        }
    }
}