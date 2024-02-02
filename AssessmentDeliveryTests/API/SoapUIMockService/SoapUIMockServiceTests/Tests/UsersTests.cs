using NUnit.Framework;
using SoapUIMockServiceTests.Clients;
using System.Net;

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
        public async Task Test_UsersExists()
        {
            var userResponse = await _usersClient.GetUsersAsync();
            Assert.True(userResponse.Users.Any());
        }

        #region GET

        [TestCase("Omkar")]
        [TestCase("Hamza")]
        public async Task Test_GetAllUsers_WithValidUserExists(string userName)
        {
            var userResponse = await _usersClient.GetUsersAsync();
            Assert.True(userResponse.Users.Select(user => user.Name.Equals(userName)).Any());
        }

        [TestCase(1, "Omkar")]
        public async Task Test_GetUserByID_WithValidUserExists(int userId, string userName)
        {
            var userResponse = await _usersClient.GetUserByIDAsync(userId);
            Assert.True(userResponse.Users.Select(user => user.Name.Equals(userName)).Any());
        }

        #endregion

        #region POST

        [TestCase("Balaji")]
        public async Task Test_PostNewUser_ValidNewUserExist(string userName)
        {
            var userResponse = await _usersClient.PostUsersAsync();
            Assert.True(userResponse.Users.Select(user => user.Name.Equals(userName)).Any());
        }

        [Test]
        public async Task Test_PostNewUser_RequestWithoutBody_Validate400BadRequest()
        {
            var userResponse = await _usersClient.PostUsersAsyncEmptyBody();
            Assert.That(userResponse.StatusCode.Equals(HttpStatusCode.BadRequest));
        }

        #endregion

        #region PUT

        [TestCase(2, "Olga")]
        public async Task Test_PutUser_ValidUserExist(int userId, string userName)
        {
            var userResponse = await _usersClient.PutUser(userId);
            Assert.True(userResponse.Users.Select(user => user.Name.Equals(userName) && user.Id.Equals(userId)).Any());
        }

        #endregion
    }
}