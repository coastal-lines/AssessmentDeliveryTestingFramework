using FluentAssertions;
using NUnit.Framework;
using NUnit.Framework.Constraints;
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
        public async Task Test_Get_AnyUserExists()
        {
            var userResponse = await _usersClient.GetUsersAsync();

            //NUnit
            Assert.True(userResponse.Users.Any());
            //Fluent
            userResponse.Should().NotBeNull();
        }

        #region GET

        [TestCase("Omkar")]
        [TestCase("Hamza")]
        public async Task Test_Get_AllUsersExist(string userName)
        {
            var userResponse = await _usersClient.GetUsersAsync();

            //NUnit
            Assert.True(userResponse.Users.Select(user => user.Name.Equals(userName)).Any());
            //Fluent
            userResponse.Users.Should().Contain(user => user.Name.Equals(userName));
        }

        [TestCase(1, "Omkar")]
        public async Task Test_GetById_ValidUserExists(int userId, string userName)
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

            var userResponse = await _usersClient.GetUserByIDAsync(userId);

            //NUnit
            Assert.That(userResponse.Users.First().Equals(expectedUser.Users.First()));
            //Fluent
            userResponse.Users.First().Should().BeEquivalentTo(expectedUser.Users.First());
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

            //NUnit
            Assert.That(expectedUser.Users[0].Id.Equals(actualUser.Users[0].Id), $"User id should be '{userId}' but was '{actualUser.Users[0].Id}'.");
            Assert.That(expectedUser.Users[0].Name.Equals(actualUser.Users[0].Name), $"User name should be '{userName}' but was '{actualUser.Users[0].Name}.'");
            //Fluent
            actualUser.Should().BeEquivalentTo(expectedUser);
        }

        #endregion

        #region POST

        [TestCase("Balaji")]
        public async Task Test_PostNewUser_ValidNewUserExist(string userName)
        {
            var userResponse = await _usersClient.PostUsersAsync();

            //NUnit
            Assert.True(userResponse.Users.Select(user => user.Name.Equals(userName)).Any());
            //Fluent
            userResponse.Users.Should().Contain(user => user.Name.Equals(userName));
        }

        [Test]
        public async Task Test_PostNewUser_RequestWithoutBody_Validate400BadRequest()
        {
            var userResponse = await _usersClient.PostUsersAsyncEmptyBody();

            //NUnit
            Assert.That(userResponse.StatusCode.Equals(HttpStatusCode.BadRequest));
            //Fluent
            userResponse.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        #endregion

        #region PUT

        [TestCase(2, "Olga")]
        public async Task Test_PutUser_ValidUserExist(int userId, string userName)
        {
            var userResponse = await _usersClient.PutUser(userId);

            //NUnit
            Assert.True(userResponse.Users.Select(user => user.Name.Equals(userName) && user.Id.Equals(userId)).Any());
            //Fluent
            userResponse.Users.Should().Contain(user => user.Name == userName && user.Id == userId);
        }

        #endregion

        #region PATCH

        [TestCase(2, "Chandrakala")]
        public async Task Test_PathUserName(int userId, string userName)
        {
            var userResponse = await _usersClient.PatchUser(userId, userName);

            //NUnit
            Assert.That(userResponse.Users.Where(user => user.Id.Equals(userId)).First().Name.Equals(userName));
            //Fluent
            userResponse.Users.Should().Contain(user => user.Name == userName && user.Id == userId);
        }

        #endregion
    }
}