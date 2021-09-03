using SerializedConfig.Test.Util;
using SerializedConfig.Types.Serialization;

namespace SerializedConfig.Test.Serialization
{
    public static class SerializationJson
    {
        public static void Serialize()
        {
            Consts.configManager = new(Consts.SAVE_FILE_PATH_JSON, SerializationFormat.Json, Consts.configurationModel);

            lock (Consts.locker)
            {
                Consts.configManager.Save();   
            }
        }
        
        public static void Deserialize()
        {
            Consts.configManager = new(Consts.SAVE_FILE_PATH_JSON, SerializationFormat.Json, Consts.configurationModel);

            lock (Consts.locker)
            {
                Consts.configManager.Load();   
            }
        }
    }
}