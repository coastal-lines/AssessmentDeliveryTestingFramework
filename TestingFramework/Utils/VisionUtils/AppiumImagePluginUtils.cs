using TestingFramework.Core.Element.Web;
using TestingFramework.Core.Logging;
using TestingFramework.Utils.FileUtils;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;

namespace TestingFramework.Utils.VisionUtils
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

        /// <summary>
        /// Method doesn't have any waiting for the element. Use 'ElementWaitFactory' class instead of.
        /// </summary>
        /// <param name="windowsDriver"></param>
        /// <param name="imagePath"></param>
        /// <returns></returns>
        public IWebElement FindElementByImagePattern(WindowsDriver windowsDriver, string imagePath)
        {
            var imageFile = _loadFilesUtils.ReadFileAsByteArray(imagePath);
            var base64ImageRepresentation = _base64Utils.ConvertByteArrayToBase64(imageFile);

            try
            {
                return windowsDriver.FindElement(MobileBy.Image(base64ImageRepresentation));
            }

            catch (NoSuchElementException ex)
            {
                Logger.LogError($"Element for image pattern '{imagePath}' was not found.", ex);
                throw;
            }

            catch (WebDriverTimeoutException ex)
            {
                Logger.LogError($"Timeout for waiting image pattern '{imagePath}'.", ex);
                throw ex;
            }

            catch (InvalidSelectorException ex)
            {
                Logger.LogError("Please check Appium Image plugin.", ex);
                throw ex;
            }
        }

        public void DragAndDropByCoordinatesInFrame(IWebDriver driver, IWebElement frame, Func<IWebElement> FindCanvasElement, WebElementActions webElementActions, IWebElement sourceElement, IWebElement destinationElement)
        {
            //Calculate coordinates for the source and the destination
            var xSource = Math.Abs(frame.Location.X - sourceElement.Location.X) + (sourceElement.Size.Width / 2);
            var ySource = Math.Abs(frame.Location.Y - sourceElement.Location.Y) + (sourceElement.Size.Height / 2);

            var xDest = Math.Abs(frame.Location.X - destinationElement.Location.X) + (destinationElement.Size.Width / 2);
            var yDest = Math.Abs(frame.Location.Y - destinationElement.Location.Y) + (destinationElement.Size.Height / 2);

            //Switch into desired frame
            driver.SwitchTo().Frame(frame);

            //Set zero coordinates for the canvas
            var canvas = FindCanvasElement();
            var xZero = -(canvas.Size.Width / 2);
            var yZero = -(canvas.Size.Height / 2);

            //Drag and Drop action
            webElementActions.DragAndDropFromsourceToDestinationByCoordinates(canvas, xZero + xSource, yZero + ySource, xZero + xDest, yZero + yDest);

            //Switch back into default frame
            driver.SwitchTo().DefaultContent();
        }
    }
}
