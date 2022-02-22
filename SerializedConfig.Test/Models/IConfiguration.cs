namespace SerializedConfig.Test.Models
{
    public interface IConfiguration
    {
        public string configurationString { get; set; }
        public bool configurationBool { get; set; }
        public int configurationInt { get; set; }
        public float configurationFloat { get; set; }
        public char configurationChar { get; set; }
        public string[] configurationArray { get; set; }
    }
}