using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Appium.Service.Options;
using OpenQA.Selenium.Appium.Service;
using OpenQA.Selenium.Appium;
using System.Diagnostics;
using OpenQA.Selenium;
using AssessmentDeliveryTestingFramework.Utils.System;

namespace AssessmentDeliveryTestingFramework.Core.Driver.Factory
{
    public sealed class MobileDriverFactory
    {
        private WindowsSystemUtils _windowsSystemUtils;

        public MobileDriverFactory() 
        {
            _windowsSystemUtils = new WindowsSystemUtils();
        }

        public AndroidDriver CreateMobileDriver()
        {
            var builder = new AppiumServiceBuilder();

            //KeyValuePair<string, string> arguments = new KeyValuePair<string, string>("--use-plugins", "images");
            //builder.WithArguments(new OpenQA.Selenium.Appium.Service.Options.OptionCollector().AddArguments(arguments));


            OptionCollector oc = new OptionCollector();
            oc.AddArguments(new KeyValuePair<string, string>("--use-plugins", "images"));
            //oc.AddArguments(new KeyValuePair<string, string>("--avd", "pixel_2_-_api_28"));
            builder.WithArguments(oc);

            builder.WithLogFile(new FileInfo(@"\MobileTestsDemo\appium_log.txt"));
            var service = builder.Build();
            service.Start();

            Thread.Sleep(5000);

            var capabilities = new AppiumOptions();
            capabilities.DeviceName = "emulator-5554";
            capabilities.PlatformName = "Android";
            capabilities.AutomationName = AutomationName.AndroidUIAutomator2;
            //capabilities.AddAdditionalAppiumOption("noReset", true);

            try
            {
                return new AndroidDriver(new Uri("http://localhost:4723/"), capabilities, TimeSpan.FromSeconds(180));
            }
            catch (WebDriverException ex)
            {
                //TODO
                throw;
            }
        }

        public void StartAndroidEmulator()
        {
            _windowsSystemUtils.RunCmdScript("/c \"emulator -avd pixel_2_-_api_28", false, false);

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
                        //timer.Restart();
                        var status = _windowsSystemUtils.RunCmdScript("/c \"\\android-sdk\\platform-tools\\adb.exe\" -s emulator-5554 shell getprop init.svc.bootanim", true, true);
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
            }
        }
    }
}
