using AssessmentDeliveryTestingFramework.Utils.FileUtils.Text;
using System.Text;

namespace AssessmentDeliveryTestingFramework.Utils
{
    public class Base64Utils
    {
        public TextFileUtils TextFileUtils { get; } = new TextFileUtils();

        public string ConvertByteArrayToBase64(byte[] bytesArray)
        {
            return Convert.ToBase64String(bytesArray);
        }

        public string ConvertStringToBase64(string text)
        {
            var textBase64 = Encoding.UTF8.GetBytes(text);
            return Convert.ToBase64String(textBase64);
        }

        public string ConvertBase64ToString(string textInBase64)
        {
            var encodedText = Convert.FromBase64String(textInBase64);
            return Encoding.UTF8.GetString(encodedText);
        }

        public string ConvertTextFileToBase64(string filePath)
        {
            var text = TextFileUtils.ReadTxtFile(filePath);
            string base64String = Convert.ToBase64String(Encoding.UTF8.GetBytes(text));
            return base64String;
        }
    }
}