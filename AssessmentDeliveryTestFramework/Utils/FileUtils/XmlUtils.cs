using AssessmentDeliveryTestingFramework.Core.Logging;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;

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
                Logger.LogError($"Error loading XML from file path '{filePath}'", ex);
                throw;
            }
        }

        public XmlElement LoadXmlFromFileAndGetRoot(string filePath)
        {
            var xmlDoc = LoadXmlFileFromFile(filePath);
            return xmlDoc.DocumentElement;
        }

        public void SaveXmlDocument(XDocument xmlDoc, string path)
        {
            xmlDoc.Save(path);
        }

        public XElement GetElementByXPath(XDocument xmlDoc, string xpath = "//*")
        {
            var element = xmlDoc.XPathSelectElement(xpath);

            if (element != null)
            {
                return element;
            }
            else
            {
                Logger.LogInformation($"Element '{xpath}' not found.");
                throw new NullReferenceException();
            }
        }

        public string GetTextFromElementAttributeByXPath(XDocument xmlDoc, string attribute, string xpath = "//*")
        {
            string elementText = null;

            var element = GetElementByXPath(xmlDoc, xpath);

            if (element.Attribute("default-value") != null)
            {
                elementText = element.Attribute(attribute).Value;
                Logger.LogInformation($"Attribute '{attribute}' of element '{xpath}' has next text: '{elementText}'");
            }
            else
            {
                Logger.LogInformation($"Attribute '{attribute}' of element '{xpath}' not found.");
            }

            return elementText;
        }

        /// <summary>
        /// Get text from Element by parameters
        /// </summary>
        /// <param name="xmlDoc">XML document</param>
        /// <param name="elementName">Html elements like div, p, canvas, etc.</param>
        /// <param name="attribute">Any element's attribute like value, name, enabled, etc.</param>
        /// <param name="attributeValue">User data</param>
        /// <returns></returns>
        /// <exception cref="NullReferenceException"></exception>
        public string GetTextFromElementByAttributeValue(XDocument xmlDoc, string elementName, string attribute, string attributeValue)
        {
            var element = xmlDoc.Descendants(elementName);

            if (element.Any())
            {
                return element
                    .Where(x => x.Attribute(attribute).Value == attributeValue)
                    .FirstOrDefault()
                    .Elements("value")
                    .Single().Value;
            }

            Logger.LogError($"Element '{elementName}' not found.", new NullReferenceException());
            throw new NullReferenceException();
        }

        /// <summary>
        /// Method uses for commenting some elements in the xml document.
        /// </summary>
        /// <param name="element"></param>
        public void CommentElement(XElement element)
        {
            element.ReplaceWith(new XComment(element.ToString()));
        }

        public void SetValueToElement(XDocument xmlDoc, string elementName, string attribute, string attributeValue, string attributeForUpdate, string newValue)
        {
            xmlDoc.Descendants(elementName)
                .Where(x => x.Attribute(attribute)
                .Value == attributeValue)
                .FirstOrDefault()
                .Elements(attributeForUpdate)
                .Single()
                .Value = newValue;
        }
    }
}
