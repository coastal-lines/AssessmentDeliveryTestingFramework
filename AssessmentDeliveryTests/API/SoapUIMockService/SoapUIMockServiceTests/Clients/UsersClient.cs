using AssessmentDeliveryTestingFramework.Utils.FileUtils.Text;
using RestSharp;
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

        public async Task<UsersObject> GetUsersAsync()
        {
            var response = await _apiManager.GetAsync("/users");
            return _jsonUtils.Deserialize<UsersObject>(response.Content);
        }

        public async Task<UsersObject> GetUserByIDAsync(int userId)
        {
            var response = await _apiManager.GetAsync($"/users/{userId}");
            return _jsonUtils.Deserialize<UsersObject>(response.Content);
        }

        public async Task<UsersObject> PostUsersAsync()
        {
            var response = await _apiManager.PostAsync("/users", "{\r\n    \"user\": Balaji,\r\n    \"id\": 4\r\n}");
            return _jsonUtils.Deserialize<UsersObject>(response.Content);
        }

        public async Task<RestResponse> PostUsersAsyncEmptyBody()
        {
            return await _apiManager.PostAsync("/users", "");
        }

        public async Task<UsersObject> PutUser(int userId)
        {
            var response = await _apiManager.PutAsync($"/users/{userId}", "{\r\n\"users\": [\r\n {\r\n \"id\": 2,\r\n \"name\": \"Olga\"\r\n}\r\n]\r\n}");
            return _jsonUtils.Deserialize<UsersObject>(response.Content);
        }

        public async Task<UsersObject> PatchUser(int userId, string userName)
        {
            string jsonString = $@"{{
                ""name"": ""{userName}""
            }}";

            var response = await _apiManager.PutAsync($"/users/{userId}", jsonString);
            return _jsonUtils.Deserialize<UsersObject>(response.Content);
        }
    }
}
