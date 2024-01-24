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
                    Console.WriteLine($"File {filePath} was not loaded.");

                    throw new FileNotFoundException($"File {filePath} was not found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");

                throw new FileNotFoundException($"File {filePath} was not loaded.");
            }
        }
    }
}
