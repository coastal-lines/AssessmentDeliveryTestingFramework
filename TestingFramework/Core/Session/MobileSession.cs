using TestingFramework.Core.Driver.DriverContainers;
using TestingFramework.Core.Wait;
using OpenQA.Selenium.Appium.Android;

namespace TestingFramework.Core.Session
{
    public class MobileSession : Session
    {
        private string _categories;

        public MobileSession()
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

            driverContainers.Add(driverFactory.CreateMobileDriverContainer(_categories));
        }

        public AndroidDriver GetDriver()
        {
            return (AndroidDriver)driverContainers.OfType<MobileAndroidDriverContainer>().ToList().Where(d => d.Platform.Equals("android")).First().Driver;
        }

        public MobileAndroidElementWaiting GetAndroidWait()
        {
            return driverContainers.OfType<MobileAndroidDriverContainer>().ToList().Where(d => d.Platform.Equals("android")).First().MobileAndroidElementWaiting;
        }

        public WebElementWaiting GetWebWait()
        {
            return driverContainers.OfType<MobileAndroidDriverContainer>().ToList().Where(d => d.Platform.Equals("android")).First().WebElementWaiting;
        }
    }
}
