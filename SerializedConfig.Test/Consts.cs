using System;
using SerializedConfig.Test.Models.ConfigurationManager;
using SerializedConfig.Types;

namespace SerializedConfig.Test
{
    internal static class Consts
    {
        internal static string DESKTOP_PATH = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        
        internal static string YAML_FILE_NAME = @"\appconfig.yaml";
        internal static string JSON_FILE_NAME = @"\appconfig.json";
        
        internal static string SAVE_FILE_PATH_YAML = DESKTOP_PATH + YAML_FILE_NAME;
        internal static string SAVE_FILE_PATH_JSON = DESKTOP_PATH + JSON_FILE_NAME;
        
        public static ConfigurationModel configurationModel {get; set;} = new()
        {
            pessoa = new()
            {
                name = "Roger",
                age = 18
            },
            outraPessoa = new()
            {
                name = "Rian",
                age = 10
            }
        };
        public static ConfigManager<ConfigurationModel> configManager { get; set; }
    }
}