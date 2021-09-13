using SerializedConfig.SectionsAtribute;
using SerializedConfig.Test.Models.Sections;
using SerializedConfig.Types;

namespace SerializedConfig.Test.Models.ConfigurationManager
{
    [SectionClass]
    public class ConfigurationModel : IConfigurationModel
    {
        public Person person { get; init; }
        public Person anotherPerson {get; init;}
    }
}