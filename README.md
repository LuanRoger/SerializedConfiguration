# SerializedConfiguration
### Create, manage and save settings in .yaml or .json.

![](https://img.shields.io/nuget/dt/SerializedConfig)
![](https://img.shields.io/nuget/v/SerializedConfig)

## Dependencies
- .NET 5
- [Newtonsoft.Json](https://www.nuget.org/packages/Newtonsoft.Json) (>= 13.0.1)
- [YamlDotNet](https://www.nuget.org/packages/YamlDotNet) (>= 11.2.1)

## Installation
### PM
```powershell
Install-Package SerializedConfig
```
### .NET CLI
```powershell
dotnet add package SerializedConfig
```
See also in [NuGet Gallery](https://www.nuget.org/packages/SerializedConfig)

## Simple example:
```csharp
[ConfigSection]
public class ConfigurationModel : IConfigurationModel
{
    public Person person { get; set; }
    public Person anotherPerson { get; set; }
}
```
```csharp
ConfigurationModel configurationModel = new()
{
    person = new()
    {
        name = "Bob",
        age = 68
    },
    anotherPerson = new()
    {
        name = "Anders",
        age = 60
    }
};
            
ConfigManager<ConfigurationModel> configManager = new(Consts.SAVE_FILE_PATH_YAML, SerializationFormat.Yaml, configurationModel);
configManager.Save();
```

## Documentation
Access the documentation on [Wiki](https://github.com/LuanRoger/SerializedConfiguration/wiki)
