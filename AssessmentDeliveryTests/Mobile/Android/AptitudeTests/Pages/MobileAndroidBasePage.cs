using AssessmentDeliveryTestingFramework.Core.Driver.DriverUtils;
using AssessmentDeliveryTestingFramework.Core.Session;
using AssessmentDeliveryTestingFramework.Core.Wait;
using OpenQA.Selenium.Appium.Android;

namespace AptitudeTests.Pages
{
    public class MobileAndroidBasePage
    {
        private AndroidDriver _driver;

        private MobileAndroidElementWaiting _elementWaiting;

        private WebElementWaiting _webElementWaiting;

        private AndroidActions _actions;

        private MobileSession _session;

        public AndroidDriver Driver => _driver;

        public MobileAndroidElementWaiting MobileAndroidElementWaiting => _elementWaiting;

        public WebElementWaiting WebElementWaiting => _webElementWaiting;

        //public AndroidActions AndroidActions => _actions;

        public MobileSession Session => _session;

        public MobileAndroidBasePage(MobileSession session)
        {
            _driver = session.GetDriver();

            _elementWaiting = session.GetAndroidWait();

            _webElementWaiting = session.GetWebWait();

            //_actions = session.GetAndroidActions();

            _session = session;
        }
    }
}