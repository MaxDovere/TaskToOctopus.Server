using System;

namespace TaskToOctopus.Server
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Properties
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }

    public class NlogModel
    {
        public DateTime Timestamp { get; set; }
        public string Level { get; set; }
        public string Logger { get; set; }
        public string Message { get; set; }
        public Properties Properties { get; set; }
    }
}
