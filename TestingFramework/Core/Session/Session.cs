using TestingFramework.Core.Driver.PlatformUtils;
using TestingFramework.Core.Driver.PlatformUtils.Windows;
using NUnit.Framework;
using TestingFramework.Core.TestManagement;
using TestingFramework.Core.Utils.Config;
using TestingFramework.Core.Driver.Factory;
using TestingFramework.Core.Driver.DriverContainers;
using TestingFramework.Core.Driver.DriverContainers.CustomContainers;
using TestingFramework.Core.Logging;

namespace TestingFramework.Core.Session
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
                        return (T)(object)minContainer.BrowserFeatures;
                    }
                    else
                    {
                        Logger.LogError($"Browser type {browserType} is not supported.", new NotSupportedException());
                        throw new NotSupportedException();
                    }

                default:
                    Logger.LogError($"Browser type {browserType} is not supported.", new NotSupportedException());
                    throw new NotSupportedException();
            }
        }

        public IDriverContainer GetDriverContainer<T>(string containerType)
        {
            switch (containerType)
            {
                case "Windows":
                    return driverContainers.OfType<DesktopDriverContainer>().FirstOrDefault();

                default:
                    Logger.LogError($"Driver container {containerType} not supported.", new Exception());
                    throw new Exception();
            }
        }

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
                var categories = TestContext.CurrentContext.Test?.Properties["Category"].ToList();

                if (categories.Any()) 
                {
                    return TestContext.CurrentContext.Test?.Properties["Category"].FirstOrDefault().ToString();
                }
                else
                {
                    return GetDefaultBrowser();
                }
            }

            catch (InvalidOperationException ex)
            {
                Logger.LogError(ex.Message, ex);
                throw;
            }

            catch (NullReferenceException ex)
            {
                Logger.LogError("Test " + TestContext.CurrentContext.Test?.Name + " doesn't have any test category", ex);
                throw;
            }

            return _defaultBrowser;
        }

        public void AddAdditionalDesktopContainer(string browserType, string titleTextContains)
        {
            driverContainers.Add(
                new DesktopDriverContainer(
                    driverFactory.WindowsDriverFactory.CreateWindowsDriverForBrowserConnecting(browserType, titleTextContains), 
                    "desktop_test_name", 
                    ConfigurationManager.GetConfigurationModel().Desktop.Platform, 
                    "Windows"));
        }

        public string GetDefaultBrowser()
        {
            return ConfigurationManager.GetConfigurationModel().Web.DefaultBrowser ?? throw new NullReferenceException("Browser is not supported.");
        }

        public string GetRunType()
        {
            return ConfigurationManager.GetConfigurationModel().Web.RunType ?? throw new NullReferenceException("Run type is not supported.");
        }
    }
}
