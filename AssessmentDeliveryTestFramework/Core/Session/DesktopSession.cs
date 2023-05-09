using AssessmentDeliveryTestingFramework.Core.Driver;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssessmentDeliveryTestingFramework.Core.Session
{
    public class DesktopSession : Session
    {
        private string _categories;

        public DesktopSession()
        {
            _categories = GetCurrentTestCategories();
            AddDriverContainer();
        }

        public void AddDriverContainer()
        {
            if (driverContainers == null)
            {
                driverContainers = new List<IDriverContainer>();
            }

            driverContainers.Add(driverFactory.CreateDesktopDriverContainer(_categories));
        }

        public WindowsDriver GetDriver(string platformType = "Windows")
        {
            switch (driverContainers.Count)
            {
                //case 0:
                //    _sessionDrivers.Add(_driverFactory.GetDriverContainer());
                //    return _sessionDrivers[0].Driver;

                case 1:
                    if (driverContainers[0] is DesktopDriverContainer)
                    {
                        return (WindowsDriver)driverContainers[0].Driver;
                    }
                    else
                    {
                        throw new NotSupportedException($"Current session doesn't have any container for {platformType}.");
                    }

                default:
                    return (WindowsDriver)driverContainers.OfType<DesktopDriverContainer>().ToList().Where(d => d.Platform.Equals(platformType)).First().Driver;
            }
        }

        /*
        public WindowsDriver<IWebElement> GetDriver(string platformType = "Windows")
        {
            switch (sessionDrivers.Count)
            {
                //case 0:
                //    _sessionDrivers.Add(_driverFactory.GetDriverContainer());
                //    return _sessionDrivers[0].Driver;

                case 1:
                    if (sessionDrivers[0] is DesktopDriverContainer)
                    {
                        return (WindowsDriver<IWebElement>)sessionDrivers[0].Driver;
                    }
                    else
                    {
                        throw new NotSupportedException($"Current session doesn't have any container for {platformType}.");
                    }


                default:
                    return (WindowsDriver<IWebElement>)sessionDrivers.OfType<DesktopDriverContainer>().ToList().Where(d => d.Platform.Equals(platformType)).First().Driver;
            }
        }
        */

        public IWebDriver GetDriver2(string platformType = "Windows")
        {
            switch (driverContainers.Count)
            {
                //case 0:
                //    _sessionDrivers.Add(_driverFactory.GetDriverContainer());
                //    return _sessionDrivers[0].Driver;

                case 1:
                    if (driverContainers[0] is DesktopDriverContainer)
                    {
                        return (IWebDriver)driverContainers[0].Driver;
                    }
                    else
                    {
                        throw new NotSupportedException($"Current session doesn't have any container for {platformType}.");
                    }


                default:
                    return (IWebDriver)driverContainers.OfType<DesktopDriverContainer>().ToList().Where(d => d.Platform.Equals(platformType)).First().Driver;
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
                Console.WriteLine("Windows driver was closed");
            }

            try
            {
                Process.GetProcessesByName("FreeQuizMaker").FirstOrDefault().Kill();
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine("'FreeQuizMaker' was closed or was not started");
            }

            try
            {
                Process.GetProcessesByName("node.exe").FirstOrDefault().Kill();
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine("'node.exe' was closed or was not started");
            }

            driverFactory.WindowsDriverFactory.TearDown();
        }
    }
}
