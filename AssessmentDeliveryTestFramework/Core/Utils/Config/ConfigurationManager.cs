using AssessmentDeliveryTestingFramework.Models.Config;
using Microsoft.Extensions.Configuration;

namespace AssessmentDeliveryTestingFramework.Core.Utils.Config
{
    public class ConfigurationManager
    {
        private readonly IConfiguration _configuration;

        private static ConfigurationManager _instance;

        private static readonly object _lock = new object();

        public ConfigModel ConfigModel { get; private set; }

        private ConfigurationManager()
        {
            _configuration = LoadConfiguration();

            InitConfigModel();
        }

        public static ConfigModel GetConfigurationModel()
        {
            return GetInstance().ConfigModel;
        }

        private static ConfigurationManager GetInstance()
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new ConfigurationManager();
                    }
                }
            }

            return _instance;
        }

        private IConfiguration LoadConfiguration()
        {
            try
            {
                var configurationBuilder = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("Resources/appconfig.json");

                return configurationBuilder.Build();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading configuration: {ex.Message}");

                return null;
            }
        }

        private IConfiguration GetConfiguration()
        {
            return _configuration;
        }

        private void InitConfigModel()
        {
            ConfigModel = new ConfigModel
            {
                Framework = GetConfiguration().GetSection(ConfigurationTypes.Framework).Get<FrameworkConfig>(),
                Web = GetConfiguration().GetSection(ConfigurationTypes.Web).Get<WebConfig>(),
                Desktop = GetConfiguration().GetSection(ConfigurationTypes.Desktop).Get<DesktopConfig>(),
                Mobile = GetConfiguration().GetSection(ConfigurationTypes.Mobile).Get<MobileConfig>(),
                Resources = GetConfiguration().GetSection(ConfigurationTypes.Resources).Get<ResourcesConfig>()
            };
        }
    }
}
