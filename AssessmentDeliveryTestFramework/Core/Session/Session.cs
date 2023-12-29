using AssessmentDeliveryTestingFramework.Core.Driver.PlatformUtils;
using AssessmentDeliveryTestingFramework.Core.Driver.PlatformUtils.Windows;
using NUnit.Framework;
using OpenQA.Selenium;
using AssessmentDeliveryTestingFramework.Core.TestManagement;
using AssessmentDeliveryTestingFramework.Core.Utils.Config;
using AssessmentDeliveryTestingFramework.Core.Driver.Factory;
using AssessmentDeliveryTestingFramework.Core.Wait;
using AssessmentDeliveryTestingFramework.Core.Driver.DriverContainers;

namespace AssessmentDeliveryTestingFramework.Core.Session
{
    public class Session
    {
        private readonly string _defaultBrowser;

        public DriverFactory driverFactory;

        private PlatformDriverUtils? _platformDriverUtils;

        public List<IDriverContainer> driverContainers;

        public Session()
        {
            driverFactory = new DriverFactory();

            _defaultBrowser = GetDefaultBrowser();
        }

        public T GetDriverFeatures<T>(string browserType = BrowserType.Min)
        {
            switch (browserType)
            {
                case BrowserType.Min:
                    if (driverContainers[0] is MinBrowserDriverContainer minContainer)
                    {
                        //ElectronBrowserFeatures browserFeatures = minContainer.BrowserFeatures;

                        return (T)(object)minContainer.BrowserFeatures;
                    }
                    else
                    {
                        throw new NotSupportedException($"Browser type {browserType} is not supported.");
                    }

                default:
                    throw new NotSupportedException($"Browser type {browserType} is not supported.");
            }
        }

        /*
        public IWebDriver GetDriver(string browserType = BrowserType.Chrome)
        {
            switch (driverContainers.Count)
            {
                //case 0:
                //    _sessionDrivers.Add(_driverFactory.GetDriverContainer());
                //    return _sessionDrivers[0].Driver;

                case 1:
                    return driverContainers[0].Driver;

                default:
                    return driverContainers.OfType<BrowserDriverContainer>().ToList().Where(d => d.BrowserType.Equals(browserType)).First().Driver;
            }
        }
        */

        public PlatformDriverUtils PlatformDriverUtils
        {
            get
            {
                if (_platformDriverUtils == null)
                {
                    if (ConfigurationManager.GetConfigurationModel().Framework.Platform == "Windows")
                    {
                        _platformDriverUtils = new PlatformDriverUtils(new WindowsDriverUtils());
                    }
                }

                return _platformDriverUtils.UpdateSessionDrivers(driverContainers);
            }
        }

        public string GetCurrentTestCategories()
        {
            try
            {
                var cat = TestContext.CurrentContext.Test?.Properties["Category"].ToList();
                var testcat = TestContext.CurrentContext.Test?.Properties["TestCategory"].ToList();


                var categories = TestContext.CurrentContext.Test?.Properties["Category"].ToList();

                if (categories.Count == 1) 
                {
                    categories[0].ToString();
                }

                return TestContext.CurrentContext.Test?.Properties["Category"].FirstOrDefault().ToString();
            }

            catch (InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
            }

            catch (NullReferenceException e)
            {
                Console.WriteLine("Test " + TestContext.CurrentContext.Test?.Name + " doesn't have any test category");
                Console.WriteLine(e.Message);
            }

            return _defaultBrowser;
        }

        public void AddNewWebSession()
        {

        }

        public string GetDefaultBrowser()
        {
            return ConfigurationManager.GetConfigurationModel().Web.DefaultBrowser ?? throw new NullReferenceException("Browser is not supported."); //TODO
        }

        public string GetRunType()
        {
            return ConfigurationManager.GetConfigurationModel().Web.RunType ?? throw new NullReferenceException("Run type is not supported."); //TODO
        }
    }
}
