using AssessmentDeliveryTestingFramework.Core.Driver;
using AssessmentDeliveryTestingFramework.Core.Driver.DriverUtils;
using AssessmentDeliveryTestingFramework.Core.Wait;
using OpenQA.Selenium.Appium.Android;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssessmentDeliveryTestingFramework.Core.Session
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
