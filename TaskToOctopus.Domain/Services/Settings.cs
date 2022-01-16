namespace TaskToOctopus.Domain.Services
{
    public class Settings
    {
        public int QueueCapacity { get; set; }
        public string DefaultEndpoint { get; set; }
        public string DefaultNotificator { get; set; }
        public string Method { get; set; }
    }
}
