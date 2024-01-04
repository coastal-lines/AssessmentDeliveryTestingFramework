using AzureDevOpsApiTests.Clients;
using NUnit.Framework;

namespace AzureDevOpsApiTests.Tests.Mock
{
    public static class TestCaseData
    {
        public static int TestCaseId = 12345;

        public static string ExpectedTestCaseName = "Verify Login Functionality";
    }

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
        public void Get_TestCaseById_ValidId()
        {
            _wireMockClient.GetWireMockServer()
                .Given(WireMock.RequestBuilders.Request.Create().WithPath($"/api/testcases/{TestCaseData.TestCaseId}").UsingGet())
                .RespondWith(WireMock.ResponseBuilders.Response.Create().WithStatusCode(200).WithBody($@"
                    {{
                        ""id"": {TestCaseData.TestCaseId}
                    }}
                "));

            var response = _restClient.Get($"/api/testcases/{TestCaseData.TestCaseId}");

            Assert.AreEqual(response.StatusCode, System.Net.HttpStatusCode.OK);
        }

        [Test]
        public void Get_TestCaseById_ValidTestCaseName()
        {
            _wireMockClient.GetWireMockServer()
                .Given(WireMock.RequestBuilders.Request.Create().WithPath($"/api/testcases/{TestCaseData.TestCaseId}").UsingGet())
                .RespondWith(WireMock.ResponseBuilders.Response.Create().WithStatusCode(200).WithBody($@"
                    {{
                        ""name"": ""{TestCaseData.ExpectedTestCaseName}""
                    }}
                "));

            var response = _restClient.Get($"/api/testcases/{TestCaseData.TestCaseId}");

            var testCase = Newtonsoft.Json.JsonConvert.DeserializeObject<Models.TestCase>(response.Content);

            Assert.AreEqual(TestCaseData.ExpectedTestCaseName, testCase.Name);
        }
    }
}