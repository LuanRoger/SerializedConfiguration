using System;
using SerializedConfig.Test.Models.ConfigurationManager;

namespace SerializedConfig.Test.Util
{
    internal static class Consts
    {
        // TODO - Colocar as configurações na pasta de execução
        private static readonly string PROGRAM_PATH = AppDomain.CurrentDomain.BaseDirectory;

        private const string YAML_FILE_NAME = @"\appconfig.yaml";
        private const string JSON_FILE_NAME = @"\appconfig.json";

        internal static readonly string SAVE_FILE_PATH_YAML = PROGRAM_PATH + YAML_FILE_NAME;
        internal static readonly string SAVE_FILE_PATH_JSON = PROGRAM_PATH + JSON_FILE_NAME;
        
        internal static object locker = new();
        
        public static ConfigurationModel configurationModel { get; } = new()
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
        public static ConfigManager<ConfigurationModel> configManager { get; set; }
    }
}