using TestingFramework.Utils.FileUtils;
using TestingFramework.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using System.Diagnostics;
using TestingFramework.Core.Logging;

namespace TestingFramework.Core.Wait
{
    public class DesktopWindowsElementWaiting : ElementWaiting<WindowsDriver>
    {
        private Base64Utils _base64Utils;

        private LoadFilesUtils _loadFilesUtils;

        public DesktopWindowsElementWaiting(WindowsDriver webDriver) : base(webDriver)
        {
            _base64Utils = new Base64Utils();

            _loadFilesUtils = new LoadFilesUtils();
        }

        /// <summary>
        /// 'WindowsElement' not supported yet. Selenium4 doesn't work with W3C 'winappdriver'.
        /// </summary>
        public IWebElement WaitElementDisplayedByImagePattern(string base64ImageRepresentation, int waitTimeout = 30)
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();

            while (stopWatch.Elapsed.TotalSeconds <= waitTimeout)
            {
                try
                {
                    return GetDriver().FindElement(MobileBy.Image(base64ImageRepresentation));
                }
                catch (NoSuchElementException)
                {
                    
                }
            }

            stopWatch.Stop();

            if (stopWatch.Elapsed.TotalSeconds > waitTimeout)
            {
                Logger.LogError($"Element was not found by image pattern.", new Exception());
                throw new Exception();
            }

            Logger.LogError($"Element was not found by image pattern.", new Exception());
            throw new Exception();
        }

        public IWebElement FindElementByImagePattern(string imagePath, int waitTimeout = 30)
        {
            var imageFile = _loadFilesUtils.ReadFileAsByteArray(imagePath);

            var base64ImageRepresentation = _base64Utils.ConvertByteArrayToBase64(imageFile);

            var stopWatch = new Stopwatch();
            stopWatch.Start();

            while (stopWatch.Elapsed.TotalSeconds <= waitTimeout)
            {
                try
                {
                    return GetDriver().FindElement(MobileBy.Image(base64ImageRepresentation));
                }

                catch (NoSuchElementException ex)
                {
                    Logger.LogError($"Element for image pattern '{imagePath}' was not found.", ex);
                    throw;
                }

                catch (WebDriverTimeoutException ex)
                {
                    Logger.LogError($"Timeout for waiting image pattern '{imagePath}'.", ex);
                    throw;
                }

                catch (InvalidSelectorException ex)
                {
                    Logger.LogError("Please check Appium Image plugin.", ex);
                    throw;
                }
            }

            stopWatch.Stop();

            if (stopWatch.Elapsed.TotalSeconds > waitTimeout)
            {
                Logger.LogError("Element was not found within the specified timeout.", new Exception("Element was not found within the specified timeout."));
                throw new Exception("Element was not found within the specified timeout.");
            }

            string errorMessage = "Element was not found within the specified timeout.";
            Logger.LogError(errorMessage, new Exception(errorMessage));
            throw new Exception(errorMessage);
        }
    }
}
