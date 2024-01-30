using RestSharp;
using RestSharp.Authenticators;


namespace SoapUIMockServiceTests.Clients
{
    internal class ApiClient : IDisposable
    {
        private RestClient _client;

        public ApiClient(string authUrl, string userName, string password)
        {
            var options = new RestClientOptions(authUrl)
            {
                Authenticator = new HttpBasicAuthenticator(userName, password)
            };

            _client = new RestClient(options);
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
