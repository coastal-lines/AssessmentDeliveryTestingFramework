namespace AssessmentDeliveryTestingFramework.Utils.FileUtils.Text
{
    public class TextFileUtils
    {
        public string ReadTxtFile(string filePath)
        {
            try
            {
                using (var streamReader = new StreamReader(filePath))
                {
                    string text = "";
                    string line;

                    while ((line = streamReader.ReadLine()) != null)
                    {
                        text += line + Environment.NewLine;
                    }

                    return text;
                }
            }
            catch (FileNotFoundException errorMsg)
            {
                Console.WriteLine("Exception: " + errorMsg.Message);
                throw;
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
                Console.WriteLine($"File '{filePath}' was not found.");
                throw;
            }
        }

        public List<string> ReadTextFileAsList(string filePath)
        {
            try
            {
                var listText = new List<string>();
                listText = File.ReadAllLines(filePath).ToList();

                return listText;
            }
            catch (FileNotFoundException errorMsg)
            {
                Console.WriteLine("Exception: " + errorMsg.Message);
                throw;
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
                Console.WriteLine($"File '{filePath}' was not found.");
                throw;
            }
        }

        public void SaveTxtFile(string filePath, List<string> text, bool append = false)
        {
            try
            {
                using (StreamWriter streamWriter = new StreamWriter(filePath, append))
                {
                    foreach (string line in text)
                    {
                        streamWriter.WriteLine(line);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
                Console.WriteLine($"File '{filePath}' was not saved.");
                throw;
            }
        }
    }
}

