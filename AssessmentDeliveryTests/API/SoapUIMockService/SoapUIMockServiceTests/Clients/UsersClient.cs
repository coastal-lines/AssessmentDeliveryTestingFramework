﻿using AssessmentDeliveryTestingFramework.Utils.FileUtils.Text;
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

        public async Task<UsersResponse> GetUsersAsync()
        {
            var response = await _apiManager.GetAsync("/users");
            return _jsonUtils.Deserialize<UsersResponse>(response.Content);
        }

        public async Task<UsersResponse> GetUserByIDAsync(int id)
        {
            var response = await _apiManager.GetAsync($"/users/{id}");
            return _jsonUtils.Deserialize<UsersResponse>(response.Content);
        }

        public async Task<UsersResponse> PostUsersAsync()
        {
            var response = await _apiManager.PostAsync("/users", "{\r\n    \"user\": Balaji,\r\n    \"id\": 4\r\n}");
            return _jsonUtils.Deserialize<UsersResponse>(response.Content);
        }

        public async Task<RestResponse> PostUsersAsyncEmptyBody()
        {
            return await _apiManager.PostAsync("/users", "");
        }

        public async Task<UsersResponse> PutUser(int id)
        {
            var response = await _apiManager.PutAsync($"/users/{id}", "{\r\n\"users\": [\r\n {\r\n \"id\": 2,\r\n \"name\": \"Olga\"\r\n}\r\n]\r\n}");
            return _jsonUtils.Deserialize<UsersResponse>(response.Content);
        }
    }
}
