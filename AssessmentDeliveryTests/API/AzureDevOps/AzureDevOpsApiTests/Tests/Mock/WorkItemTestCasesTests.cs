using AzureDevOpsApiTests.Clients;
using NUnit.Framework;
using System.Net;

namespace AzureDevOpsApiTests.Tests.Mock
{
    public static class TestCaseData
    {
        public static string Server = "http://localhost";

        public static int Port = 8090;

        public static string ExpectedTestCaseName = "Verify Login Functionality";
    }

    public class WorkItemTestCasesTests
    {
        private RestClientWrapper _restClient;

        private WireMockClient _wireMockClient;

        private string _testCaseEndPoint = "/_apis/test/plans/1/suites/1/cases/1";


        [SetUp]
        public void Setup()
        {
            _wireMockClient = new WireMockClient(TestCaseData.Port);

            _restClient = new RestClientWrapper($"{TestCaseData.Server}:{TestCaseData.Port}");
        }

        [TearDown]
        public void TearDown()
        {
            _wireMockClient.Stop();
        }

        private void SetupGetTestCaseStub()
        {
            var mappingAzureDevOpsTest1Path = Path.Combine(Directory.GetCurrentDirectory(), "Resources", "WireMockFiles", "mapping-get-azure-devops-testcase-1.json");

            _wireMockClient.GetWireMockServer()
                .Given(WireMock.RequestBuilders.Request.Create().WithPath("/_apis/test/plans/1/suites/1/cases/1").UsingGet())
                .RespondWith(WireMock.ResponseBuilders.Response.Create()
                    .WithHeader("Content-Type", "text/plain")
                    .WithStatusCode(200)
                    .WithBodyFromFile(mappingAzureDevOpsTest1Path));
        }

        private void SetupPatchTestCaseStub()
        {
            var mappingAzureDevOpsTest1Path = Path.Combine(Directory.GetCurrentDirectory(), "Resources", "WireMockFiles", "mapping-path-name-azure-devops-testcase-1.json");

            _wireMockClient.GetWireMockServer()
                .Given(WireMock.RequestBuilders.Request.Create().WithPath("/_apis/test/plans/1/suites/1/cases/1").UsingPatch())
                .RespondWith(WireMock.ResponseBuilders.Response.Create()
                    .WithHeader("Content-Type", "text/plain")
                    .WithStatusCode(201)
                    .WithBodyFromFile(mappingAzureDevOpsTest1Path));
        }

        [Test]
        public void Get_TestCaseById_Valid_200OK()
        {
            SetupGetTestCaseStub();

            var response = _restClient.Get(_testCaseEndPoint);

            Assert.AreEqual(response.StatusCode, System.Net.HttpStatusCode.OK);
        }

        [Test]
        public void Get_TestCaseById_Valid_TestCaseName()
        {
            SetupGetTestCaseStub();

            var response = _restClient.Get("http://localhost:8090/" + _testCaseEndPoint);

            var content = _wireMockClient.JsonUtils.GetValueFromResponse(response.Content, "response.body");

            var testCase = _wireMockClient.JsonUtils.Deserialize<Models.AzureDevOpsTestCase>(content);

            Assert.AreEqual("Login test", testCase.Fields.SystemTitle);
        }

        [Test]
        public void Patch_TestCaseName_Valid_201OK()
        {
            SetupPatchTestCaseStub();

            _wireMockClient.GetWireMockServer()
            .Given(WireMock.RequestBuilders.Request.Create().WithPath("/_apis/test/plans/1/suites/1/cases/1").UsingPatch()
                .WithHeader("Content-Type", "text/plain")
                .WithBody(@"{
                    ""bodyPatterns"": [
                        {
                            ""contains"": {
                                ""path"": ""$.fields['System.Title']"",
                                ""value"": ""New Test Case Name""
                            }
                        }
                    ]
                }"));

            var response = _restClient.Patch("http://localhost:8090" + _testCaseEndPoint);

            Assert.AreEqual((int)HttpStatusCode.Created, (int)response.StatusCode, "Expected 201 but was " + (int)response.StatusCode);
        }
    }
}