using OpenQA.Selenium;

namespace AssessmentDeliveryTestingFramework.Utils.VisionUtils
{
    public class ScreenshotUtils
    {
        public void TakeScreenshotAndSaveAsFile(IWebDriver driver, string filePath = "")
        {
            Screenshot screenshot = ((ITakesScreenshot)driver).GetScreenshot();
            screenshot.SaveAsFile($"screenshot_{DateTime.Now.ToString("dd_MM_yyyy_HH_mm_ss")}.png", ScreenshotImageFormat.Png);
        }
    }
}
