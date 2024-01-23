using ImageMagick;
using NUnit.Framework;
using OpenQA.Selenium;
using System.Drawing;

namespace AssessmentDeliveryTestingFramework.Utils.VisionUtils
{
    public class ScreenshotUtils
    {
        private IWebDriver _driver;

        public ScreenshotUtils(IWebDriver driver)
        {
            _driver = driver;
        }

        public Screenshot TakeScreenshot()
        {
            return ((ITakesScreenshot)_driver).GetScreenshot();
        }

        public void TakeScreenshotAndSaveAsFile(string filePath = "")
        {
            var screenshot = TakeScreenshot();

            screenshot.SaveAsFile($"screenshot_{DateTime.Now.ToString("dd_MM_yyyy_HH_mm_ss")}.png", ScreenshotImageFormat.Png);
        }

        public void SaveDifferenceBetweenScreenshots(MagickImage actualScreenshot, MagickImage expectedScreenshot)
        {
            int width = actualScreenshot.Width * 2;
            int height = actualScreenshot.Height;

            using (MagickImage resultImage = new MagickImage(MagickColor.FromRgb(255, 255, 255), width, height))
            {
                //Put expected image into result image
                resultImage.Composite(expectedScreenshot, 0, 0, CompositeOperator.Over);

                //Find difference between images
                expectedScreenshot.Composite(actualScreenshot, CompositeOperator.Difference, Channels.RGB);

                //Put image with difference into result image
                resultImage.Composite(expectedScreenshot, actualScreenshot.Width, 0, CompositeOperator.Over);

                resultImage.Write($"{TestContext.CurrentContext.Test.Name}_{DateTime.Now.ToString("dd_MM_yyyy_HH_mm_ss")}.png");
            }
        }

        public MagickImage TakeScreenshotAndCutRoi(int x, int y, int w, int h)
        {
            var screenshot = TakeScreenshot();

            var magickImageScreenshot = new MagickImage(new MemoryStream(screenshot.AsByteArray));

            magickImageScreenshot.Crop(new MagickGeometry(x, y, w, h));

            return magickImageScreenshot;
        }

        public MagickImage LoadImageFromFile(string filePath)
        {
            return new MagickImage(filePath);
        }

        /// <summary>
        /// Method compares two images.
        /// </summary>
        /// <param name="actualScreenshot">Current image..</param>
        /// <param name="expectedScreenshot">Expected image..</param>
        /// <param name="expectedDifference">Max difference between two images. Using 'ErrorMetric.MeanAbsolute' metric.</param>
        /// <returns>If no difference return 'True'.</returns>
        public bool CompareTwoScreenshots(MagickImage actualScreenshot, MagickImage expectedScreenshot, double expectedDifference = 0.005)
        {
            double actualDifference = actualScreenshot.Compare(expectedScreenshot, ErrorMetric.MeanAbsolute);

            if (actualDifference > expectedDifference)
            {
                SaveDifferenceBetweenScreenshots(actualScreenshot, expectedScreenshot);
            }

            return actualDifference < expectedDifference;
        }
    }
}