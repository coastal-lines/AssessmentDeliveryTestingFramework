using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Appium.Service.Options;
using OpenQA.Selenium.Appium.Service;
using OpenQA.Selenium.Appium;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace AssessmentDeliveryTestingFramework.Core.Driver.Factory
{
    public sealed class MobileDriverFactory
    {
        public AndroidDriver CreateMobileDriver()
        {
            var builder = new AppiumServiceBuilder();

            //KeyValuePair<string, string> arguments = new KeyValuePair<string, string>("--use-plugins", "images");
            //builder.WithArguments(new OpenQA.Selenium.Appium.Service.Options.OptionCollector().AddArguments(arguments));


            OptionCollector oc = new OptionCollector();
            oc.AddArguments(new KeyValuePair<string, string>("--use-plugins", "images"));
            //oc.AddArguments(new KeyValuePair<string, string>("--avd", "pixel_2_-_api_28"));
            builder.WithArguments(oc);

            builder.WithLogFile(new FileInfo(@"F:\Data\Work\OwnProjects\AllForSelenium\MobileTestsDemo\appium_log.txt"));
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
            //var driver = new AndroidDriver(new Uri("http://localhost:4723/"), capabilities, TimeSpan.FromSeconds(180));

            //return driver;
        }

        public void StartAndroidEmulator()
        {
            RunCmdScript("/c \"emulator -avd pixel_2_-_api_28", false, false);

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
                        var status = RunCmdScript("/c \"c:\\Program Files (x86)\\Android\\android-sdk\\platform-tools\\adb.exe\" -s emulator-5554 shell getprop init.svc.bootanim", true, true);
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

        private string RunCmdScript(string arguments, bool waitForExit, bool waitForResponse)
        {
            string output = null;
            string error = null;

            ProcessStartInfo processStartInfo = new ProcessStartInfo
            {
                FileName = "cmd.exe",
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true,
                Arguments = arguments
            };

            // Create a new process
            Process process = new Process
            {
                StartInfo = processStartInfo
            };

            // Start the process
            process.Start();

            if (waitForResponse)
            {
                // Read the output and error streams
                output = process.StandardOutput.ReadToEnd();
                error = process.StandardError.ReadToEnd();
            }

            // Wait for the process to exit
            if (waitForExit)
            {
                process.WaitForExit();
            }

            return !string.IsNullOrEmpty(error) ? error : output;
        }
    }
}
