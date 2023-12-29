using AssessmentDeliveryTestingFramework.Core.Browsers.Min;
using AssessmentDeliveryTestingFramework.Core.Driver.DriverUtils;
using AssessmentDeliveryTestingFramework.Core.TestManagement;
using AssessmentDeliveryTestingFramework.Core.Wait;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssessmentDeliveryTestingFramework.Core.Driver.DriverContainers
{


    public class DriverContainer<TDriver> : IDriverContainer where TDriver : IWebDriver
    {
        private object _driver;
        private string _name;
        private string _platform;
        private string _currentTestType;

        public DriverContainer(TDriver driver, string name, string platform, string currentTestType)
        {
            _driver = driver;
            _name = name;
            _platform = platform;
            _currentTestType = currentTestType;
        }

        public object Driver => _driver;

        public string Name => _name;

        public string Platform => _platform;

        public string CurrentTestType => _currentTestType;
    }
}