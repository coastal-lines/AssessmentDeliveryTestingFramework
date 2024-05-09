using OpenQA.Selenium;
using AssessmentDeliveryTestingFramework.Core.Element.Web;
using AssessmentDeliveryTestingFramework.Core.Wait;
using AssessmentDeliveryTestingFramework.Utils.FileUtils;
using AssessmentDeliveryTestingFramework.Utils.VisionUtils;
using AssessmentDeliveryTestingFramework.Utils;

namespace CanvasTests.Pages
{
    internal class WebBasePage
    {
        public IWebDriver Driver { get; }

        public WebElementWaiting WebElementWaiting { get; }

        public WebElementActions WebElementActions { get; }

        public ScreenshotUtils ScreenshotUtils { get; private set; }

        public SikuliManager SikuliManager { get; private set; }

        public AppiumImagePluginUtils AppiumImagePluginUtils { get; private set; }

        public Base64Utils Base64Utils { get; private set; }

        public LoadFilesUtils LoadFilesUtils { get; private set; }

        public WebBasePage(IWebDriver driver, WebElementWaiting webElementWaiting, WebElementActions webElementActions)
        {
            Driver = driver;

            WebElementWaiting = webElementWaiting;

            WebElementActions = webElementActions;

            ScreenshotUtils = new ScreenshotUtils(Driver);

            SikuliManager = new SikuliManager();

            AppiumImagePluginUtils = new AppiumImagePluginUtils();

            Base64Utils = new Base64Utils();

            LoadFilesUtils = new LoadFilesUtils();
        }
    }
}
