﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssessmentDeliveryTestingFramework.Models.Config
{
    public class Timeouts
    {
        public int ImplicitWait { get; set; }
        public int PageLoad { get; set; }
    }

    public class MinBrowserSettings
    {
        public string NavigationPageUrl { get; set; }
        public string DocumentPageUrl { get; set; }
    }

    public class FrameworkConfig
    {
        
        public string Platform { get; set; }
        public Timeouts Timeouts { get; set; }
    }

    public class WebConfig : FrameworkConfig
    {
        public string RunType { get; set; }

        public string DefaultBrowser { get; set; }

        public string DownloadFolder { get; set; }

        public MinBrowserSettings MinBrowser { get; set; }
    }

    public class DesktopConfig
    {
        public string TestType { get; set; }
        public string Platform { get; set; }
    }

    public class MobileConfig
    {
        
    }

    public class ConfigModel
    {
        public FrameworkConfig Framework { get; set; }
        public WebConfig Web { get; set; }
        public DesktopConfig Desktop { get; set; }
        public MobileConfig Mobile { get; set; }
    }
}
