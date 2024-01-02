using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using NUnit.Framework;
using RestSharp;
using WireMock.Server;

namespace AzureDevOpsApiTests.Tests.Mock
{
    public class WorkItemTestCasesTests
    {
        private WireMockServer wireMockServer;

        [SetUp]
        public void Setup()
        {
            wireMockServer = WireMockServer.Start(8080);

            string mappingsPath = Path.Combine(Directory.GetCurrentDirectory(), "AzureDevOpsApiTests", "Resources", "WireMockFiles");

            wireMockServer.ReadStaticMappings(mappingsPath);
        }

        [TearDown]
        public void TearDown()
        {
            wireMockServer.Stop();
            wireMockServer.Dispose();
        }

        [Test]
        public void GetTestCaseById_ValidId_ReturnsTestCaseName()
        {
            int testCaseId = 12345;

            string expectedTestCaseName = "Verify Login Functionality";

            wireMockServer
                .Given(WireMock.RequestBuilders.Request.Create().WithPath($"/api/testcases/{testCaseId}").UsingGet())
                .RespondWith(WireMock.ResponseBuilders.Response.Create().WithStatusCode(200).WithBody($@"
                    {{
                        ""id"": {testCaseId},
                        ""name"": ""{expectedTestCaseName}""
                    }}
                "));

            var client = new RestClient(wireMockServer.Urls[0]);
            var request = new RestRequest($"/api/testcases/{testCaseId}", Method.Get);

            var response = client.Execute(request);

            Assert.AreEqual(response.StatusCode, System.Net.HttpStatusCode.OK);

            var testCase = Newtonsoft.Json.JsonConvert.DeserializeObject<Models.TestCase>(response.Content);

            Assert.AreEqual(expectedTestCaseName, testCase.Name);
        }
    }
}