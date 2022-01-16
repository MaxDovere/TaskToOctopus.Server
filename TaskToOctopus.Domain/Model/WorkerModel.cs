namespace TaskToOctopus.Domain.Model
{
    public class WorkerModel
    {
        public string SSODealerID { get; }
        public string ConnName { get; set; }
        public string BaseUrl { get; }
        public string Endpoint { get; }
        public string Method { get; }
        public WorkerModel(string ssoDealerID, string connName, string baseUrl, string endpoint, string method)
        {
            ConnName = connName;
            SSODealerID = ssoDealerID;
            BaseUrl = baseUrl;
            Endpoint = endpoint;
            Method = method;
        }        
    }
}
