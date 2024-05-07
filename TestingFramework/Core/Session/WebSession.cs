using TestingFramework.Core.Driver.DriverContainers;
using TestingFramework.Core.Element.Web;
using TestingFramework.Core.Logging;
using TestingFramework.Core.Wait;
using OpenQA.Selenium;

namespace TestingFramework.Core.Session
{
    public class WebSession : Session
    {
        private string _browserType;

        private string _runType;

        public WebElementWaiting WebElementWaiting { get; private set; }

        public WebElementActions WebElementActions { get; private set; }

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

            WebElementWaiting = driverContainers.OfType<BrowserDriverContainer>().Last().WebElementWaiting;

            WebElementActions = driverContainers.OfType<BrowserDriverContainer>().Last().WebElementActions;
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
                Logger.LogError("Driver was closed", ex);
                throw;
            }

            //TODO
            //Add closing 'chromedriver', 'geckodriver', etc by browser type and process ID
            //Actual for multithreading
        }
    }
}
