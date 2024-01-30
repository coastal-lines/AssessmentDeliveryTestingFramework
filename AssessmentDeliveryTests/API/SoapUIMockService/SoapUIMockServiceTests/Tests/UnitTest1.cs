using NUnit.Framework;
using SoapUIMockServiceTests.Clients;

namespace SoapUIMockServiceTests.Tests
{
    public class Tests
    {
        private ApiManager _apiManager;

        [SetUp]
        public void Setup()
        {
            _apiManager = new ApiManager("http://localhost:3000");
        }

        [TearDown]
        public void TearDown() 
        {
            _apiManager.Dispose();
        }

        [Test]
        public async Task Test_GetUsers()
        {
            // Act
            var response = await _apiManager.GetUsersAsync();

            // Assert
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.User);
            Assert.AreEqual("Bob", response.User);
        }
    }
}