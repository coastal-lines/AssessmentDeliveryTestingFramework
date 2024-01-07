using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace AssessmentDeliveryTestingFramework.Utils
{
    public class JsonUtils
    {
        public T Deserialize<T>(string jsonResponse)
        {
            return (T)(object)Newtonsoft.Json.JsonConvert.DeserializeObject<T>(jsonResponse);
        }

        public T LoadJsonFromFile<T>(string filePath)
        {
            return JsonConvert.DeserializeObject<T>(File.ReadAllText(filePath));
        }

        public string GetValueFromResponse(string response, string path)
        {
            var token = JObject.Parse(response).SelectToken(path);

            return token?.ToString() ?? string.Empty;
        }
    }
}