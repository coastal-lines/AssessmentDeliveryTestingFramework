using System.Xml;

namespace AssessmentDeliveryTestingFramework.Utils.FileUtils
{
    public class XmlUtils
    {
        public XmlDocument LoadXmlFileFromFile(string filePath)
        {
            try
            {
                using (var xmlReader = new XmlTextReader(filePath))
                {
                    var xmlDoc = new XmlDocument();
                    xmlDoc.Load(xmlReader);

                    return xmlDoc;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine($"Error loading XML from file path '{filePath}'");
                throw;
            }
        }

        public XmlElement LoadXmlFromFileAndGetRoot(string filePath)
        {
            var xmlDoc = LoadXmlFileFromFile(filePath);

            return xmlDoc.DocumentElement;
        }
    }
}
