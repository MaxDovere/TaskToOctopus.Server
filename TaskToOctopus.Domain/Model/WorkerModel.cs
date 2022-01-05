namespace TaskToOctopus.Domain.Model
{
    public class WorkerModel
    {
        public string UserId { get; }
        public string SSODealerID { get; }
        public string BaseUrl { get; }
        public string Endpoint { get; }
        public string Method { get; }
        public WorkerModel(string userId, string ssoDealerID, string baseUrl, string endpoint, string method)
        {
            UserId = userId;
            SSODealerID = ssoDealerID;
            BaseUrl = baseUrl;
            Endpoint = endpoint;
            Method = method;
        }        
    }
}
