using AssessmentDeliveryTestingFramework.Utils.FileUtils.Text;
using SoapUIMockServiceTests.Models.v1.users.get;

namespace SoapUIMockServiceTests.Clients
{
    internal class UsersClient
    {
        private ApiManager _apiManager;

        private JsonUtils _jsonUtils;

        public UsersClient(ApiManager apiManager)
        {
            _apiManager = apiManager;
        }

        public async Task<UserGetResponse> GetUsersAsync()
        {
            var response = await _apiManager.GetAsync("/users");

            if (!response.IsSuccessful)
            {
                throw new Exception($"Error: {response.ErrorMessage}");
            }

            return _jsonUtils.Deserialize<UserGetResponse>(response.Content);
        }
    }
}
