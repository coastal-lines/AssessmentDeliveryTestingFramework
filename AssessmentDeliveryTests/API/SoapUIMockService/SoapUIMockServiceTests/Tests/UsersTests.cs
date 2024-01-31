using NUnit.Framework;
using SoapUIMockServiceTests.Clients;

namespace SoapUIMockServiceTests.Tests
{
    public class UsersTests
    {
        private ApiManager _apiManager;
        private UsersClient _usersClient;

        [SetUp]
        public void Setup()
        {
            _apiManager = new ApiManager("http://localhost:3000");

            _usersClient = new UsersClient(_apiManager);
        }

        [TearDown]
        public void TearDown() 
        {
            _apiManager.Dispose();
        }

        [Test]
        public async Task Test_GetUsers()
        {
            var userGetResponse = await _usersClient.GetUsersAsync();

            Assert.AreEqual("Hamza", userGetResponse.User);
        }
    }
}