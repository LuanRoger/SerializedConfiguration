using SerializedConfig.Test.Models.Sections;
using SerializedConfig.Types;

namespace SerializedConfig.Test.Models.ConfigurationManager
{
    public class ConfigurationModel : IConfigurationModel
    {
        [Section]
        public Person pessoa { get; set; }
        public Person outraPessoa {get; set;}
    }
}