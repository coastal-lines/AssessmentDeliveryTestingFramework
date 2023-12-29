using AssessmentDeliveryTestingFramework.Core.Driver;
using AssessmentDeliveryTestingFramework.Core.TestManagement;
using AssessmentDeliveryTestingFramework.Core.Wait;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssessmentDeliveryTestingFramework.Core.Session
{
    public class WebSession : Session
    {
        private string _browserType;

        private string _runType;

        public WebSession()
        {
            _browserType = GetCurrentTestCategories();

            _runType = GetRunType();

            AddDriverContainer();
        }

        public void AddDriverContainer()
        {
            if (driverContainers == null)
            {
                driverContainers = new List<IDriverContainer>();
            }

            if (_runType == "Local")
            {
                driverContainers.Add(driverFactory.CreateBrowserDriverContainer(_browserType));
            }
            else if(_runType == "Docker")
            {
                driverContainers.Add(driverFactory.CreateBrowserRemoteDriverContainer(_browserType));
            }
        }

        public IWebDriver GetDriver()
        {
            switch (driverContainers.Count)
            {
                case 0:
                    throw new NotSupportedException($"Current session doesn't have any driver container");

                case 1:
                    if (driverContainers[0] is BrowserDriverContainer)
                    {
                        return (IWebDriver)driverContainers[0].Driver;
                    }
                    else
                    {
                        throw new NotSupportedException($"Current session doesn't have any container for {_browserType} browser.");
                    }

                default:
                    return (IWebDriver)driverContainers.OfType<BrowserDriverContainer>().ToList().Where(d => d.BrowserType.Equals(_browserType)).First().Driver;
            }
        }

        public void TearDown()
        {
            try
            {
                GetDriver().Quit();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Console.WriteLine("Driver was closed");
            }

            //TODO
            //Add closing 'chromedriver', 'geckodriver', etc by browser type and process ID
            //Actual for multithreading
        }
    }
}
