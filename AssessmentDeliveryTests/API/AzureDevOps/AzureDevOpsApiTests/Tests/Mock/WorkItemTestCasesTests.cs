using AzureDevOpsApiTests.Clients;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using NUnit.Framework;
using RestSharp;
using WireMock.Server;

namespace AzureDevOpsApiTests.Tests.Mock
{
    public class WorkItemTestCasesTests
    {
        private RestClientWrapper _restClient;

        private WireMockClient _wireMockClient;

        [SetUp]
        public void Setup()
        {
            _wireMockClient = new WireMockClient(8080);

            _restClient = new RestClientWrapper("http://localhost:8080");
        }

        [TearDown]
        public void TearDown()
        {
            _wireMockClient.Stop();
        }

        [Test]
        public void GetTestCaseById_ValidId_ReturnsTestCaseName()
        {
            int testCaseId = 12345;

            string expectedTestCaseName = "Verify Login Functionality";

            _wireMockClient.GetWireMockServer()
                .Given(WireMock.RequestBuilders.Request.Create().WithPath($"/api/testcases/{testCaseId}").UsingGet())
                .RespondWith(WireMock.ResponseBuilders.Response.Create().WithStatusCode(200).WithBody($@"
                    {{
                        ""id"": {testCaseId},
                        ""name"": ""{expectedTestCaseName}""
                    }}
                "));

            var response = _restClient.Get($"/api/testcases/{testCaseId}");

            Assert.AreEqual(response.StatusCode, System.Net.HttpStatusCode.OK);

            var testCase = Newtonsoft.Json.JsonConvert.DeserializeObject<Models.TestCase>(response.Content);

            Assert.AreEqual(expectedTestCaseName, testCase.Name);
        }
    }
}