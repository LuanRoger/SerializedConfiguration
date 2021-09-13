using System;

namespace SerializedConfig.Exceptions
{
    public class InvalidExtensionException : Exception
    {
        private const string ExceptionMessage = "Settings file extension is not valid for SerializationFormat";
        
        /// <summary>
        /// Occurs when the configuration file extension does not match the serialization format.
        /// </summary>
        public InvalidExtensionException() : base(ExceptionMessage) {}
    }
}