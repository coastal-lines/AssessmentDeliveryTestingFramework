using System.Collections.Generic;
using Newtonsoft.Json;

namespace AzureDevOpsApiTests.Models
{
    public class AzureDevOpsTestCase
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("fields")]
        public Fields Fields { get; set; }
    }

    public class Fields
    {
        [JsonProperty("System.Title")]
        public string SystemTitle { get; set; }

        [JsonProperty("System.State")]
        public string SystemState { get; set; }

        [JsonProperty("System.AreaPath")]
        public string SystemAreaPath { get; set; }

        [JsonProperty("System.IterationPath")]
        public string SystemIterationPath { get; set; }

        [JsonProperty("Microsoft.VSTS.TCM.AutomatedTestType")]
        public string MicrosoftVSTSTCMAutomatedTestType { get; set; }

        [JsonProperty("Microsoft.VSTS.Common.Priority")]
        public int MicrosoftVSTSCommonPriority { get; set; }

        [JsonProperty("System.Tags")]
        public string SystemTags { get; set; }

        [JsonProperty("System.Description")]
        public string SystemDescription { get; set; }

        [JsonProperty("Microsoft.VSTS.TCM.Steps")]
        public List<Step> MicrosoftVSTSTCMSteps { get; set; }
    }

    public class Step
    {
        [JsonProperty("index")]
        public int Index { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("revision")]
        public int Revision { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("expectedResult")]
        public string ExpectedResult { get; set; }
    }

}
