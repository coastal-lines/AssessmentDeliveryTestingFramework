using AssessmentDeliveryTestingFramework.Utils.FileUtils;
using AssessmentDeliveryTestingFramework.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using System.Diagnostics;

namespace AssessmentDeliveryTestingFramework.Core.Wait
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
                throw new Exception();
            }

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
                    Console.WriteLine(ex);

                    Console.WriteLine($"Element for image pattern '{imagePath}' was not found.");

                    throw ex;
                }

                catch (WebDriverTimeoutException ex)
                {
                    Console.WriteLine(ex);

                    Console.WriteLine($"Timeout for waiting image pattern '{imagePath}'.");

                    throw ex;
                }

                catch (InvalidSelectorException ex)
                {
                    Console.WriteLine("Please check Appium Image plugin.");

                    Console.WriteLine(ex);

                    throw ex;
                }
            }

            stopWatch.Stop();

            if (stopWatch.Elapsed.TotalSeconds > waitTimeout)
            {
                throw new Exception("Element was not found.");
            }

            throw new Exception("Element was not found within the specified timeout.");
        }
    }
}
