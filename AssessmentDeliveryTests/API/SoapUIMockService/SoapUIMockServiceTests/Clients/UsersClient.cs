using AssessmentDeliveryTestingFramework.Utils.FileUtils.Text;
using SoapUIMockServiceTests.Models.v1.users;

namespace SoapUIMockServiceTests.Clients
{
    internal class UsersClient
    {
        private ApiManager _apiManager;

        private JsonUtils _jsonUtils;

        public UsersClient(ApiManager apiManager)
        {
            _apiManager = apiManager;

            _jsonUtils = new JsonUtils();
        }

        public async Task<UsersResponse> GetUsersAsync()
        {
            var response = await _apiManager.GetAsync("/users");

            if (!response.IsSuccessful)
            {
                throw new Exception($"Error: {response.ErrorMessage}");
            }

            return _jsonUtils.Deserialize<UsersResponse>(response.Content);
        }

        public async Task<UsersResponse> PostUsersAsync()
        {
            var response = await _apiManager.PostAsync("", "");

            if (!response.IsSuccessful)
            {
                throw new Exception($"Error: {response.ErrorMessage}");
            }

            return _jsonUtils.Deserialize<UsersResponse>(response.Content);
        }
    }
}
