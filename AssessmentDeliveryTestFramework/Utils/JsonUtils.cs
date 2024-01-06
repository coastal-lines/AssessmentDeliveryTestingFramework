using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssessmentDeliveryTestingFramework.Utils
{
    public class JsonUtils
    {
        public T Deserialize<T>(string objectContent)
        {
            return (T)(object)Newtonsoft.Json.JsonConvert.DeserializeObject<T>(objectContent);
        }

        public T LoadJsonFromFile<T>(string path)
        {
            return JsonConvert.DeserializeObject<T>(File.ReadAllText(path));
        }
    }
}