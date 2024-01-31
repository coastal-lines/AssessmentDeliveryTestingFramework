using NUnit.Framework;
using SoapUIMockServiceTests.Clients;
using SoapUIMockServiceTests.Models.v1.users.get;

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

        [TestCase("Omkar")]
        [TestCase("Hamza")]
        public async Task Test_UserExists_WithValidName(string userName)
        {
            var userResponse = await _usersClient.GetUsersAsync();
            Assert.True(userResponse.Users.Select(user => user.Name.Equals(userName)).Any());
        }

        [TestCase("Balaji")]
        public async Task TestPost(string userName)
        {
            var userResponse = await _usersClient.PostUsersAsync();
            Assert.True(userResponse.Users.Select(user => user.Name.Equals(userName)).Any());
        }

        [Test]
        public async Task TestPo()
        {
            var userResponse = await _usersClient.PostUsersAsync();
            Assert.True(userResponse.Users.Any());
        }
    }
}