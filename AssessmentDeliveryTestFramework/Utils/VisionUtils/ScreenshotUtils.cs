using ImageMagick;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.ImageComparison;

namespace AssessmentDeliveryTestingFramework.Utils.VisionUtils
{
    public class ScreenshotUtils
    {
        private IWebDriver _driver;

        private JavaScriptUtils _javaScriptUtils;

        public ScreenshotUtils(IWebDriver driver)
        {
            _driver = driver;

            _javaScriptUtils = new JavaScriptUtils();
        }

        public Screenshot TakeScreenshot()
        {
            return ((ITakesScreenshot)_driver).GetScreenshot();
        }

        public string TakeScreenshotAsBase64()
        {
            return ((ITakesScreenshot)_driver).GetScreenshot().AsBase64EncodedString;
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

        /// <summary>
        /// Vertical Difference needs for calculate total Horizontal coordinate.
        /// </summary>
        /// <param name="element"></param>
        public MagickImage TakeElementScreenshot(IWebElement element)
        {
            var vertical_difference = _javaScriptUtils.GetVerticalDifferenceBetweenTopAndCurrentPagePosition(_driver);

            var x = element.Location.X;
            var y = element.Location.Y - vertical_difference;
            var w = element.Size.Width;
            var h = element.Size.Height;

            return TakeScreenshotAndCutRoi(x, y, w, h);
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
        public bool MagickImageCompareTwoScreenshots(MagickImage actualScreenshot, MagickImage expectedScreenshot, double expectedDifference = 0.05)
        {
            double actualDifference = actualScreenshot.Compare(expectedScreenshot, ErrorMetric.MeanAbsolute);

            if (actualDifference > expectedDifference)
            {
                SaveDifferenceBetweenScreenshots(actualScreenshot, expectedScreenshot);
            }

            return actualDifference < expectedDifference;
        }

        public bool AppiumCompareTwoScreenshots(AppiumDriver appiumDriver, string actualScreenshotBase64, string expectedScreenshotBase64)
        {
            var featuresMatchingOptions = new FeaturesMatchingOptions()
            {
                DetectorName = "ORB",
                MatchFunc = "BruteForce",
                GoodMatchesFactor = 250,
                Visualize = true
            };

            var compareResult = appiumDriver.MatchImageFeatures(actualScreenshotBase64, expectedScreenshotBase64, featuresMatchingOptions);

            if (compareResult.Visualization.Length <= 0)
            {
                try
                {
                    compareResult.SaveVisualizationAsFile($"{TestContext.CurrentContext.Test.Name}_{DateTime.Now.ToString("dd_MM_yyyy_HH_mm_ss")}.png");
                }
                catch (KeyNotFoundException ex)
                {
                    Console.WriteLine(ex);

                    Console.WriteLine("Please check 'FeaturesMatchingOptions' object. Parameter 'Visualize' should be 'true'.");

                    Console.WriteLine($"Logging screenshot for '{TestContext.CurrentContext.Test.Name}' was not saved.");
                }
            }

            compareResult.SaveVisualizationAsFile($"{TestContext.CurrentContext.Test.Name}_{DateTime.Now.ToString("dd_MM_yyyy_HH_mm_ss")}.png");

            return compareResult.Visualization.Length > 0;
        }
    }
}