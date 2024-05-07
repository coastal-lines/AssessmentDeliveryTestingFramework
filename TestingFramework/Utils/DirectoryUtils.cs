using AssessmentDeliveryTestingFramework.Utils.System;

namespace TestingFramework.Utils
{
    public static class DirectoryUtils
    {
        private const string FrameworkRootName = "AssessmentDeliveryTestFramework";
        private const string TemporaryResourcesPath = "AssessmentDeliveryTestFramework\\Resources\\TemporaryResources\\";
        private const string AppConfigPath = "AssessmentDeliveryTestFramework\\Resources\\appconfig.json";
        private const string CustomDriversPath = "AssessmentDeliveryTestFramework\\Files\\Files\\CustomDrivers\\";

        public static List<string> GetListFilesFromDirectory(string path)
        {
            var directory = new DirectoryInfo(path);
            var listFiles = directory.GetFiles().Select(file => file.Name).ToList();

            return listFiles;
        }

        public static string GetRootSolutionPath()
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            return currentDirectory.Substring(0, currentDirectory.IndexOf(FrameworkRootName)) + FrameworkRootName;
        }

        public static string GetAppConfigPath()
        {
            return String.Concat(GetRootSolutionPath(), "\\", AppConfigPath);
        }

        public static string GetCustomDriversPath()
        {
            return Path.Combine(GetRootSolutionPath(), CustomDriversPath);
        }

        public static string GetTemporaryResourcesPath()
        {
            return Path.Combine(GetRootSolutionPath(), TemporaryResourcesPath);
        }

        public static string GetLogFilePath()
        {
            string fileName = "logfile_" + DateTimeUtils.GetCurrentDate().Replace(":", "_") + ".txt";
            return Path.Combine(GetTemporaryResourcesPath(), fileName);
        }
    }
}