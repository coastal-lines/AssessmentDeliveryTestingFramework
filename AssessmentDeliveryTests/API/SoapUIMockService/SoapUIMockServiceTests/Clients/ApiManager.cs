using RestSharp;
using RestSharp.Authenticators;
using SoapUIMockServiceTests.Models.v1.users.get;

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

        public async Task<UserGetResponse> GetUsersAsync()
        {
            var request = new RestRequest("/users", Method.Get);
            var response = await _client.ExecuteAsync<UserGetResponse>(request);

            return response.Data;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="endPoint">"/users"</param>
        /// <returns></returns>
        public async Task<RestResponse> GetAsync(string endPoint)
        {
            var request = new RestRequest(endPoint, Method.Get);
            var response = await _client.ExecuteAsync(request);

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
