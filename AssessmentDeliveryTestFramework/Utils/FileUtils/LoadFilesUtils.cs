using AssessmentDeliveryTestingFramework.Core.Logging;

namespace AssessmentDeliveryTestingFramework.Utils.FileUtils
{
    public class LoadFilesUtils
    {
        public byte[] ReadFileAsByteArray(string filePath)
        {
            try
            {
                if (File.Exists(filePath))
                {
                    byte[] fileBytes = File.ReadAllBytes(filePath);

                    Console.WriteLine($"File {filePath} was loaded.");

                    return fileBytes;
                }
                else
                {
                    string errorMessage = $"File {filePath} was not loaded.";
                    Logger.LogError(errorMessage, new FileNotFoundException(errorMessage));
                    throw new FileNotFoundException(errorMessage);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.Message, ex);
                throw;
            }
        }
    }
}
