using System.Collections.Generic;
using TaskToOctopus.Server.ActionModels;

namespace TaskToOctopus.Server.Models
{
    public class WorkerModel
    {
        public string UserId { get; set;}
        public string BaseUrl { get; set; }
        public string Endpoint { get; set; }
        public string Method { get; set; }

    }
}
