using SerializedConfig.Test.Util;
using SerializedConfig.Types.Serialization;

namespace SerializedConfig.Test.Serialization
{
    public static class SerializationYaml
    {
        public static void Serialize()
        {
            Consts.configManager = new(Consts.SAVE_FILE_PATH_YAML, SerializationFormat.Yaml, Consts.configurationModel);

            lock (Consts.locker)
            {
                Consts.configManager.Save();   
            }
        }
        
        public static void Deserialize()
        {
            Consts.configManager = new(Consts.SAVE_FILE_PATH_YAML, SerializationFormat.Yaml, Consts.configurationModel);

            lock (Consts.locker)
            {
                Consts.configManager.Load();   
            }
        }
    }
}