using System;
using SerializedConfig.Test.Models;

namespace SerializedConfig.Test
{
    internal static class Consts
    {
        // TODO - Colocar as configurações na pasta de execução
        private static readonly string PROGRAM_PATH = AppDomain.CurrentDomain.BaseDirectory;

        private const string YAML_FILE_NAME = @"appconfig.yaml";
        private const string JSON_FILE_NAME = @"appconfig.json";

        internal static readonly string SAVE_FILE_PATH_YAML = PROGRAM_PATH + YAML_FILE_NAME;
        internal static readonly string SAVE_FILE_PATH_JSON = PROGRAM_PATH + JSON_FILE_NAME;
    }
}