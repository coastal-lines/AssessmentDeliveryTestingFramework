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
        public WindowsDriver Driver { get; }

        public DesktopWindowsElementWaiting ElementWaiting { get; }

        public WebElementWaiting WebElementWaiting { get; }

        public DesktopWindowsBasePage(WindowsDriver driver, DesktopWindowsElementWaiting desktopWindowsElementWaiting, WebElementWaiting webElementWaiting)
        {
            Driver = driver;

            ElementWaiting = desktopWindowsElementWaiting;

            WebElementWaiting = webElementWaiting;
        }
    }
}
