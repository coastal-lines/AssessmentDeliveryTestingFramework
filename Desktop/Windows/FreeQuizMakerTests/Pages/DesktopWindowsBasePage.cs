using AssessmentDeliveryTestingFramework.Core.Wait;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeQuizMakerTests.Pages
{
    public class DesktopWindowsBasePage
    {
        private WindowsDriver _driver;

        private DesktopWindowsElementWaiting _elementWaiting;

        private WebElementWaiting _webElementWaiting;

        public WindowsDriver Driver => _driver;

        public DesktopWindowsElementWaiting DesktopWindowsElementWaiting => _elementWaiting;

        public WebElementWaiting WebElementWaiting => _webElementWaiting;

        public DesktopWindowsBasePage(WindowsDriver driver)
        {
            _driver = driver ?? throw new ArgumentNullException(nameof(driver)); //TODO message

            _elementWaiting = new DesktopWindowsElementWaiting(driver);

            _webElementWaiting = new WebElementWaiting(driver);
        }
    }
}
