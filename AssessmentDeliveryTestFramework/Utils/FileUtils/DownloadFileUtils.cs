using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using AssessmentDeliveryTestingFramework.Core.Utils.Config;
using AssessmentDeliveryTestingFramework.Core.Logging;

namespace AssessmentDeliveryTestingFramework.Utils.FileUtils
{
    public class DownloadFileUtils
    {
        private string _downloadFolderPath = ConfigurationManager.GetConfigurationModel().Web.DownloadFolder;

        private Func<bool> CheckDownloadFolder()
        {
            return () =>
            {
                //check any temp files
                if (Directory.GetFiles(_downloadFolderPath).Any(f => f.EndsWith(".crdownload") || f.EndsWith(".part") || f.EndsWith(".tmp")))
                {
                    return false;
                }

                //check download folder existed
                if (!Directory.Exists(_downloadFolderPath))
                {
                    return false;
                }

                //check that donload folder has any files
                if (!Directory.GetFiles(_downloadFolderPath).Any())
                {
                    return false;
                }

                return true;
            };
        }

        private Func<bool> CheckDownloadFile(string fileName)
        {
            long previousFileSize = -1;

            return () =>
            {
                var filePath = Path.Combine(_downloadFolderPath, fileName);

                if (File.Exists(filePath))
                {
                    FileInfo fileInfo = new FileInfo(filePath);
                    long currentFileSize = fileInfo.Length;

                    if (currentFileSize == previousFileSize)
                    {
                        return true;
                    }
                    else
                    {
                        previousFileSize = currentFileSize;
                    }
                }
                else
                {
                    return false;
                }

                return false;
            };
        }

        public void WaitUntilDownloadFinished(IWebDriver driver, string fileName)
        {
            try
            {
                var waitDownloadFolder = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
                waitDownloadFolder.Until(wd => CheckDownloadFolder());

                var waitDownloadFile = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
                waitDownloadFile.Until(wd => CheckDownloadFile(fileName));
            }
            catch (WebDriverTimeoutException)
            {
                var existedFiles = Directory.EnumerateFiles(_downloadFolderPath).Select(Path.GetFileName).ToArray();
                string errorMessage = $"Download process was not finished." + $"/n Already existed files are:{string.Join(";", existedFiles)}.";
                Logger.LogError(errorMessage, new NotSupportedException(errorMessage));
                throw new NotSupportedException(errorMessage);
            }
        }
    }
}
