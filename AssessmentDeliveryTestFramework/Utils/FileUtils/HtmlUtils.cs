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
                Console.WriteLine("Error loading HTML: " + ex.Message);
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
                Console.WriteLine(ex.Message);
                Console.WriteLine($"Error loading HTML from file path 'filePath'");
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
