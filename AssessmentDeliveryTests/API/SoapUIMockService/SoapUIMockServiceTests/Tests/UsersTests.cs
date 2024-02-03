using FluentAssertions;
using NUnit.Framework;
using SoapUIMockServiceTests.Clients;
using SoapUIMockServiceTests.Models.v1.users;
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
            var testUser = new UsersObject();
            testUser.Users = new List<User>();
            testUser.Users.Add(new User()
            {
                Id = userId,
                Name = "iii"
            });

            var userResponse = await _usersClient.GetUserByIDAsync(userId);
            Assert.AreEqual(userResponse.Users[0], testUser.Users[0], "");
        }


        [TestCase(1, "Omkar")]
        public async Task Test_GetUserByID_WithValidUserExists_Fluent(int userId, string userName)
        {
            var expectedUser = new UsersObject
            {
                Users = new List<User>
                {
                    new User
                    {
                        Id = userId,
                        Name = userName
                    }
                }
            };

            var actualUser = await _usersClient.GetUserByIDAsync(userId);

            //FluentAssertions
            //actualUser.Should().BeEquivalentTo(expectedUser);

            //NUnit
            //Assert.That(expectedUser.Users[0].Id.Equals(actualUser.Users[0].Id), $"User id should be '{userId}' but was '{actualUser.Users[0].Id}'.");
            //Assert.That(expectedUser.Users[0].Name.Equals(actualUser.Users[0].Name), $"User name should be '{userName}' but was '{actualUser.Users[0].Name}.'");
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

        #region PATCH

        [TestCase(2, "Chandrakala")]
        public async Task Test_PathUserName(int userId, string userName)
        {
            var userResponse = await _usersClient.PatchUser(userId, userName);
            Assert.That(userResponse.Users.Where(user => user.Id.Equals(userId)).First().Name.Equals(userName));
        }

        #endregion
    }
}