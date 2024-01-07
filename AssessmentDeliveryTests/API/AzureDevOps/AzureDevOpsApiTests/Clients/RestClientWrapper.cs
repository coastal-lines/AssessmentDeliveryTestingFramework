using RestSharp;

namespace AzureDevOpsApiTests.Clients
{
    public class RestClientWrapper
    {
        private readonly RestClient _client;

        public RestClientWrapper(string baseUrl)
        {
            _client = new RestClient(baseUrl);
        }

        public RestResponse Get(string endPoint)
        {
            var request = new RestRequest(endPoint, Method.Get);

            return _client.Execute(request);
        }

        public RestResponse Patch(string endPoint)
        {
            var request = new RestRequest(endPoint, Method.Patch);

            return _client.Execute(request);
        }
    }
}
