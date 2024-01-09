using RestSharp;
using RestSharp.Authenticators;
using System.Net;

namespace AssessmentDeliveryTestingFramework.Utils
{
    public class RestUtils
    {
        public RestClient CreateRestClient(string url)
        {
            return new RestClient(url);
        }

        public RestClient CreateRestClient(string url, bool isTLS)
        {
            if (isTLS)
            {
                ServicePointManager.SecurityProtocol |= SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
            }

            var options = new RestClientOptions(url)
            {
                ThrowOnAnyError = true,
                MaxTimeout = 90 * 1000
            };

            var client = new RestClient(options);

            return client;
        }

        public RestClient CreateRestClient(string url, string userName, string userPassword, bool isTLS = false)
        {
            if (isTLS)
            {
                ServicePointManager.SecurityProtocol |= SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
            }

            var options = new RestClientOptions(url)
            {
                ThrowOnAnyError = true,
                MaxTimeout = 90 * 1000,
                Authenticator = new HttpBasicAuthenticator(userName, userPassword)
            };

            var client = new RestClient(options);

            return client;
        }

        public RestResponse ExecureRequest(RestClient client, string endPoint, RestSharp.Method method)
        {
            var request = new RestRequest(endPoint, method);

            return client.Execute(request);
        }
    }
}
