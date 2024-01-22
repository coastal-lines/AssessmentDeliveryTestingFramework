using ImageMagick;
using OpenQA.Selenium;

namespace AssessmentDeliveryTestingFramework.Utils.VisionUtils
{
    public class ScreenshotUtils
    {
        public Screenshot TakeScreenshot(IWebDriver driver)
        {
            return ((ITakesScreenshot)driver).GetScreenshot();
        }

        public void TakeScreenshotAndSaveAsFile(IWebDriver driver, string filePath = "")
        {
            var screenshot = TakeScreenshot(driver);

            screenshot.SaveAsFile($"screenshot_{DateTime.Now.ToString("dd_MM_yyyy_HH_mm_ss")}.png", ScreenshotImageFormat.Png);
        }

        public MagickImage TakeScreenshotAndCutRoi(IWebDriver driver, int x, int y, int w, int h)
        {
            var screenshot = TakeScreenshot(driver);

            var magickImageScreenshot = new MagickImage(new MemoryStream(screenshot.AsByteArray));

            magickImageScreenshot.Crop(new MagickGeometry(x, y, w, h));

            return magickImageScreenshot;
        }

        public MagickImage LoadImageFromFile(string filePath)
        {
            return new MagickImage(filePath);
        }

        public bool CompareTwoScreenshots(MagickImage actualScreenshot, MagickImage expectedScreenshot, double expectedDifference = 0.05)
        {
            double actualDifference = actualScreenshot.Compare(expectedScreenshot, ErrorMetric.MeanAbsolute);

            return actualDifference < expectedDifference;
        }
    }
}
