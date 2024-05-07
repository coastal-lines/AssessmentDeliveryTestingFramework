using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssessmentDeliveryTestingFramework.Core.Utils;
using AssessmentDeliveryTestingFramework.Core.Driver.DriverContainers;
using AssessmentDeliveryTestingFramework.Core.Wait;
using AssessmentDeliveryTestingFramework.Core.Element.Web;
using AssessmentDeliveryTestingFramework.Core.TestManagement;
using AssessmentDeliveryTestingFramework.Core.Logging;

namespace TestingFramework.Core.Session
{
    public class DesktopSession : Session
    {
        private string _categories;

        public WebElementActions WebElementActions { get; private set; }

        public WebElementWaiting WebElementWaiting { get; private set; }

        public DesktopWindowsElementWaiting DesktopWindowsElementWaiting { get; private set; }

        public DesktopSession(string applicationPath)
        {
            _categories = GetCurrentTestCategories();

            AddDriverContainer(applicationPath);
        }

        public void AddDriverContainer(string applicationPath)
        {
            if (driverContainers == null)
            {
                driverContainers = new List<IDriverContainer>();
            }

            driverContainers.Add(driverFactory.CreateDesktopDriverContainer(_categories, applicationPath));

            WebElementActions = new WebElementActions((IWebDriver)driverContainers.OfType<DesktopDriverContainer>().Last().Driver);

            WebElementWaiting = driverContainers.OfType<DesktopDriverContainer>().Last().WebElementWaiting;

            DesktopWindowsElementWaiting = driverContainers.OfType<DesktopDriverContainer>().Last().DesktopWindowsElementWaiting;
        }

        public WindowsDriver GetDriver(string platformType = "Windows")
        {
            switch (driverContainers.Count)
            {
                case 1:
                    if (driverContainers[0] is DesktopDriverContainer)
                    {
                        return (WindowsDriver)driverContainers[0].Driver;
                    }
                    else
                    {
                        string errorMessage = $"Current session doesn't have any container for {platformType}.";
                        Logger.LogError(errorMessage, new NotSupportedException(errorMessage));
                        throw new NotSupportedException(errorMessage);
                    }

                default:
                    return (WindowsDriver)driverContainers.OfType<DesktopDriverContainer>().ToList().Where(d => d.Platform.Equals(platformType)).First().Driver;
            }
        }

        public void TearDown(string windowsApplicationName)
        {
            try
            {
                GetDriver().Quit();
            }
            catch (Exception ex)
            {
                Logger.LogError("Windows driver was closed", ex);
                throw;
            }

            try
            {
                PlatformDriverUtils.TerminateProcess(windowsApplicationName);
            }
            catch (NullReferenceException ex)
            {
                Logger.LogError($"'{windowsApplicationName}' was closed or was not started", ex);
                throw;
            }

            try
            {
                PlatformDriverUtils.TerminateProcess("node");
            }
            catch (NullReferenceException ex)
            {
                Logger.LogError("'node.exe' was closed or was not started", ex);
                throw;
            }
        }
    }
}
