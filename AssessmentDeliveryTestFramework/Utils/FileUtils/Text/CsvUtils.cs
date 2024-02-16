using AssessmentDeliveryTestingFramework.Core.Logging;
using System.IO;

namespace AssessmentDeliveryTestingFramework.Utils.FileUtils.Text
{
    public class CsvUtils
    {
        public List<string> GetAllCellsFromCsvFile(string filePath, char delimeter = ';')
        {
            var cellsList = new List<string>();

            try
            {
                using (var reader = new StreamReader(filePath))
                {
                    string line;

                    while ((line = reader.ReadLine()) != null)
                    {
                        var cells = line.Split(delimeter);
                        foreach (var cell in cells)
                        {
                            cellsList.Add(cell);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogError($"Can't read csv file from '{filePath}'", ex);
                throw;
            }

            return cellsList;
        }
    }
}
