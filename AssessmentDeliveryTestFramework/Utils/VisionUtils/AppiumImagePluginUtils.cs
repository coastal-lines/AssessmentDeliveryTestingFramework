using AssessmentDeliveryTestingFramework.Utils.FileUtils;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;

namespace AssessmentDeliveryTestingFramework.Utils.VisionUtils
{
    public class AppiumImagePluginUtils
    {
        private Base64Utils _base64Utils;

        private LoadFilesUtils _loadFilesUtils;

        public AppiumImagePluginUtils()
        {
            _base64Utils = new Base64Utils();

            _loadFilesUtils = new LoadFilesUtils();
        }

        public IWebElement FindElementByImagePattern(WindowsDriver windowsDriver, string imagePath)
        {
            var imageFile = _loadFilesUtils.ReadFileAsByteArray(imagePath);

            var base64ImageRepresentation = _base64Utils.ConvertByteArrayToBase64(imageFile);

            try
            {
                return windowsDriver.FindElement(MobileBy.Image(base64ImageRepresentation));
            }
            catch (InvalidSelectorException ex)
            {
                Console.WriteLine("Please check Appium Image plugin.");

                Console.WriteLine(ex);

                throw ex;
            }
        }
    }
}
