using RestSharp;
using RestSharp.Authenticators;

namespace SoapUIMockServiceTests.Clients
{
    internal class ApiManager : IDisposable
    {
        private RestClient _client;

        public ApiManager()
        {
            _client = new RestClient();
        }

        public ApiManager(string baseUrl)
        {
            _client = new RestClient(baseUrl);
        }

        public ApiManager(string authUrl, string userName, string password)
        {
            var options = new RestClientOptions(authUrl)
            {
                Authenticator = new HttpBasicAuthenticator(userName, password)
            };

            _client = new RestClient(options);
        }

        public RestClient GetApiClient()
        {
            return _client;
        }

        private async Task HandleResponseSuccessful(RestResponse response)
        {
            if (!response.IsSuccessful)
            {
                throw new Exception($"Error: {response.ErrorMessage}");
            }
        }

        private async Task HandleSoapUIResponseErrorsAsync(RestResponse response)
        {
            if (response.ErrorMessage != null && response.ErrorMessage.Contains("No connection could be made because the target machine actively refused it."))
            {
                Console.WriteLine("Please check that SoapUI is already opened.");
                throw new Exception(response.ErrorMessage);
            }

            if (response.Content.Contains("There are currently 0 running SoapUI MockServices"))
            {
                Console.WriteLine("Please check that you started SoapUI MockService.");
                throw new Exception(response.Content);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="endpoint">"/users"</param>
        /// <returns></returns>
        public async Task<RestResponse> GetAsync(string endpoint)
        {
            var request = new RestRequest(endpoint, Method.Get);
            var response = await _client.ExecuteAsync(request);

            await HandleResponseSuccessful(response);
            await HandleSoapUIResponseErrorsAsync(response);

            return response;
        }

        public async Task<RestResponse> PostAsync(string endpoint, string body)
        {
            var request = new RestRequest(endpoint).AddJsonBody(body);
            var response = await _client.ExecutePostAsync(request);

            await HandleSoapUIResponseErrorsAsync(response);

            return response;
        }

        public async Task<RestResponse> PutAsync(string endpoint, string body)
        {
            var request = new RestRequest(endpoint, Method.Put).AddJsonBody(body);
            var response = await _client.ExecuteAsync(request);

            await HandleResponseSuccessful(response);
            await HandleSoapUIResponseErrorsAsync(response);

            return response;
        }

        public async Task<RestResponse> PatchAsync(string endpoint, string body)
        {
            var request = new RestRequest(endpoint, Method.Patch).AddJsonBody(body);
            var response = await _client.ExecuteAsync(request);

            await HandleResponseSuccessful(response);
            await HandleSoapUIResponseErrorsAsync(response);

            return response;
        }

        public T GetResource<T>() where T : class
        {
            var obj = (T)Activator.CreateInstance(typeof(T));
            return obj;
        }

        /// <summary>
        /// 'GC.SuppressFinalize(this)' informs the garbage collector that the object 
        /// has been explicitly disposed (the Dispose() method was called), 
        /// and that there is no need to invoke the object's finalization. 
        /// This helps to avoid unnecessary finalization operations 
        /// and improves performance when releasing resources.
        /// </summary>
        public void Dispose()
        {
            _client?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
