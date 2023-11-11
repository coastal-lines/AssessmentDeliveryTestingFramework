using AssessmentDeliveryTestingFramework.Core.Wait;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GorillaTests.Pages.GorillaExams
{
    public class WebBasePage
    {
        private IWebDriver _driver;

        private WebElementWaiting _elementWait;

        public IWebDriver Driver => _driver;

        public WebElementWaiting WebElementWaiting => _elementWait;

        public WebBasePage(IWebDriver driver)
        {
            _driver = driver ?? throw new ArgumentNullException(nameof(driver)); //TODO message

            _elementWait = new WebElementWaiting(driver);
        }
    }
}
