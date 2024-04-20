using AssessmentDeliveryTestingFramework.Utils.FileUtils.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WireMock.Server;

namespace AzureDevOpsApiTests.Clients
{
    public class WireMockClient
    {
        private readonly WireMockServer _wireMockServer;

        private readonly string MappingPath = Path.Combine(Directory.GetCurrentDirectory(), "AzureDevOpsApiTests", "Resources", "WireMockFiles");

        public JsonUtils JsonUtils => new JsonUtils();

        public WireMockClient(int port)
        {
            _wireMockServer = WireMockServer.Start(port);
            _wireMockServer.ReadStaticMappings(MappingPath);
        }

        public WireMockServer GetWireMockServer()
        {
            return _wireMockServer;
        }

        public void Stop()
        {
            _wireMockServer.Stop();
            _wireMockServer.Dispose();
        }
    }
}
