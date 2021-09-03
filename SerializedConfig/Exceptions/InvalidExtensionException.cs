using System;

namespace SerializedConfig.Exceptions
{
    public class InvalidExtensionException : Exception
    {
        private const string ExceptionMessage = "Settings file extension is not valid for SerializationFormat";
        public InvalidExtensionException() : base(ExceptionMessage) {}
    }
}