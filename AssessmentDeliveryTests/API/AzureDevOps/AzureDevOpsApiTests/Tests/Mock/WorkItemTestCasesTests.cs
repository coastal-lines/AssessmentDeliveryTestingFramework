using AngleSharp.Common;
using AssessmentDeliveryTestingFramework.Core.Browsers.Min;
using AssessmentDeliveryTestingFramework.Core.Session;
using AzureDevOpsApiTests.Clients;
using NUnit.Framework;

namespace AzureDevOpsApiTests.Tests.Mock
{
    public static class TestCaseData
    {
        public static string TestCaseEndPoint = "/api/testcases/";

        public static int TestCaseId = 12345;

        public static string ExpectedTestCaseName = "Verify Login Functionality";
    }

    public class WorkItemTestCasesTests
    {
        private RestClientWrapper _restClient;

        private WireMockClient _wireMockClient;

        private readonly string EndPointGetTestById = string.Concat(TestCaseData.TestCaseEndPoint, TestCaseData.TestCaseId);

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
        public void GetTestCaseById_Valid_Returns200Ok()
        {
            _wireMockClient.GetWireMockServer().Given(
                WireMock.RequestBuilders.Request.Create()
                .WithPath(EndPointGetTestById)
                .UsingGet()
            )
            .RespondWith(
                WireMock.ResponseBuilders.Response.Create()
                .WithStatusCode(200)
                .WithBody($@"
                    {{
                        ""id"": {TestCaseData.TestCaseId}
                    }}
            "));

            var response = _restClient.Get(EndPointGetTestById);

            Assert.AreEqual(response.StatusCode, System.Net.HttpStatusCode.OK);
        }

        [Test]
        public void Get_TestCaseById_Valid_TestCaseName()
        {
            _wireMockClient.GetWireMockServer().Given(
                WireMock.RequestBuilders.Request.Create()
                .WithPath(EndPointGetTestById)
                .UsingGet()
            )
            .RespondWith(
                WireMock.ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody($@"
                    {{
                        ""name"": ""{TestCaseData.ExpectedTestCaseName}""
                    }}
            "));

            var response = _restClient.Get(EndPointGetTestById);

            var testCase = _wireMockClient.JsonUtils.Deserialize<Models.TestCase>(response.Content);

            Assert.AreEqual(TestCaseData.ExpectedTestCaseName, testCase.Name);
        }
    }
}