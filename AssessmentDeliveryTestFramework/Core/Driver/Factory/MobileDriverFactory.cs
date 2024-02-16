using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Appium.Service.Options;
using OpenQA.Selenium.Appium.Service;
using OpenQA.Selenium.Appium;
using System.Diagnostics;
using OpenQA.Selenium;
using AssessmentDeliveryTestingFramework.Utils.System;
using AssessmentDeliveryTestingFramework.Core.Logging;
using AssessmentDeliveryTestingFramework.Core.Utils.Config;
using AssessmentDeliveryTestingFramework.Utils;

namespace AssessmentDeliveryTestingFramework.Core.Driver.Factory
{
    public sealed class MobileDriverFactory
    {
        private WindowsSystemUtils _windowsSystemUtils;

        public MobileDriverFactory() 
        {
            _windowsSystemUtils = new WindowsSystemUtils();
        }

        public void StartAppiumService()
        {
            var oc = new OptionCollector();
            oc.AddArguments(new KeyValuePair<string, string>("--use-plugins", "images"));

            var builder = new AppiumServiceBuilder();
            builder.WithArguments(oc);
            builder.WithLogFile(new FileInfo(Path.Join(DirectoryUtils.GetTemporaryResourcesPath(), $"appium_log_{DateTimeUtils.GetCurrentDate()}.txt")));

            var service = builder.Build();
            service.Start();

            _windowsSystemUtils.WaitProcessStarted("nodejs");
        }

        public AndroidDriver CreateMobileDriver()
        {
            var capabilities = new AppiumOptions();
            capabilities.DeviceName = ConfigurationManager.GetConfigurationModel().Mobile.DeviceName;
            capabilities.PlatformName = "Android";
            capabilities.AutomationName = AutomationName.AndroidUIAutomator2;

            try
            {
                return new AndroidDriver(
                    new Uri($"http://{ConfigurationManager.GetConfigurationModel().Mobile.Host}:{ConfigurationManager.GetConfigurationModel().Mobile.Port}/"), 
                    capabilities, TimeSpan.FromSeconds(90));
            }
            catch (WebDriverException ex)
            {
                Logger.LogError($"Android driver was not created", ex);
                throw;
            }
        }

        public void StartAndroidEmulator()
        {
            _windowsSystemUtils.RunCmdScript($"/c \"emulator -avd {ConfigurationManager.GetConfigurationModel().Mobile.AvdName}", false, false);

            var timer = new Stopwatch();
            timer.Start();

            var attepmts = 12;
            try
            {
                while (attepmts > 0)
                {
                    if (timer.Elapsed.Seconds >= 5)
                    {
                        timer.Stop();
                        var status = _windowsSystemUtils.RunCmdScript($"/c \"\\android-sdk\\platform-tools\\adb.exe\" -s {ConfigurationManager.GetConfigurationModel().Mobile.DeviceName} shell getprop init.svc.bootanim", true, true);
                        if (status.Equals("stopped\r\n"))
                        {
                            timer.Stop();
                            attepmts = 0;
                        }
                        else
                        {
                            attepmts -= 1;
                            timer.Restart();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                timer.Stop();
                attepmts = 0;

                Logger.LogError($"AVD '{ConfigurationManager.GetConfigurationModel().Mobile.AvdName}' was not started.", ex);
                throw ex;
            }
        }
    }
}
