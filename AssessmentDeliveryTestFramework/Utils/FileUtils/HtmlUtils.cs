using AssessmentDeliveryTestingFramework.Core.Logging;
using HtmlAgilityPack;

namespace AssessmentDeliveryTestingFramework.Utils.FileUtils
{
    public class HtmlUtils
    {
        public HtmlDocument ReadHtmlFromText(string html)
        {
            var doc = new HtmlDocument();

            try
            {
                doc.LoadHtml(html);
                return doc;
            }
            catch (Exception ex)
            {
                Logger.LogError("Error loading HTML: " + ex.Message, ex);
                throw;
            }
        }

        public HtmlDocument ReadHtmlFromFile(string filePath)
        {
            var doc = new HtmlDocument();

            try
            {
                doc.Load(filePath);
                return doc;
            }
            catch (Exception ex)
            {
                Logger.LogError($"Error loading HTML from file path 'filePath'", ex);
                throw;
            }
        }

        public string GetTextBySelector(HtmlDocument doc, string selector)
        {
            string elementText = null;

            HtmlNode selectedNode = doc.DocumentNode.SelectSingleNode(selector);
            if (selectedNode != null)
            {
                elementText = selectedNode.InnerText.Trim();
            }

            return elementText;
        }
    }
}
