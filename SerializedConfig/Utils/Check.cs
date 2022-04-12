using System.IO;

namespace SerializedConfig.Utils
{
    internal static class Check
    {
        internal static bool CheckFileExtension(string filepath, string expected) =>
            Path.GetExtension(filepath).Equals(expected);
    }
}