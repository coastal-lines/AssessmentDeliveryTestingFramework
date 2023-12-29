﻿using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssessmentDeliveryTestingFramework.Core.Utils;
using AssessmentDeliveryTestingFramework.Core.Driver.DriverContainers;

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

        public void TearDown(string windowsApplicationName)
        {
            try
            {
                GetDriver().Quit();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Console.WriteLine("Windows driver was closed");
            }

            try
            {
                PlatformDriverUtils.TerminateProcess(windowsApplicationName);
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine(ex);
                Console.WriteLine("'FreeQuizMaker' was closed or was not started");
            }

            try
            {
                PlatformDriverUtils.TerminateProcess("node");
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine(ex);
                Console.WriteLine("'node.exe' was closed or was not started");
            }
        }
    }
}
