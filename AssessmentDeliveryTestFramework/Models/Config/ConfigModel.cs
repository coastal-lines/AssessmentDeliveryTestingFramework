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

        public string RemoteUrl { get; set; }

        public string RemotePort { get; set; }

        public string ChromeDriverPath { get; set; }

        public string FirefoxDriverPath { get; set; }

        public string DownloadFolder { get; set; }

        public MinBrowserSettings MinBrowser { get; set; }
    }

    public class DesktopConfig
    {
        public string Host { get; set; }

        public string Port { get; set; }

        public string TestType { get; set; }

        public string Platform { get; set; }

        public string ApplicationPath { get; set; }
    }

    public class MobileConfig
    {
        public string Host { get; set; }

        public string Port { get; set; }

        public string DeviceName { get; set; }

        public string AvdName { get; set; }
    }

    public class ResourcesConfig
    {
        public VisualTests VisualTests { get; set; }
    }

    public class VisualTests
    {
        public string KonvaDragAndDropPatternImagesPath { get; set; }
    }

    public class ConfigModel
    {
        public FrameworkConfig Framework { get; set; }

        public WebConfig Web { get; set; }

        public DesktopConfig Desktop { get; set; }

        public MobileConfig Mobile { get; set; }

        public ResourcesConfig Resources { get; set; }
    }
}
