using TestingFramework.Core.Logging;
using System.IO;

namespace TestingFramework.Utils.FileUtils.Text
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
            catch (FileNotFoundException ex)
            {
                Logger.LogError($"File '{filePath}' was not found.", ex);
                throw;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.Message, ex);
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
            catch (FileNotFoundException ex)
            {
                Logger.LogError($"File '{filePath}' was not found.", ex);
                throw;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.Message, ex);
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
            catch (Exception ex)
            {
                Logger.LogError($"File '{filePath}' was not saved.", ex);
                throw;
            }
        }
    }
}

