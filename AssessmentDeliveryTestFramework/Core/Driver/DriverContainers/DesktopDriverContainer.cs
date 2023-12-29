using OpenQA.Selenium.Appium.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssessmentDeliveryTestingFramework.Core.Driver.DriverContainers
{
    public class DesktopDriverContainer : DriverContainer<WindowsDriver>
    {
        //Appium 4.4.5
        /*
        public DesktopDriverContainer(WindowsDriver<IWebElement> driver, string name, string platform, string currentTestType) : base(driver, name, platform)
        {
            CurrentTestType = currentTestType;
        }
        */

        //Appium 2.x
        public DesktopDriverContainer(WindowsDriver driver, string name, string platform, string currentTestType) : base(driver, name, platform, currentTestType)
        {
            
        }
    }
}
