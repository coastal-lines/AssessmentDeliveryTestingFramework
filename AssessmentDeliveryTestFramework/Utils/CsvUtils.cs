using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssessmentDeliveryTestingFramework.Utils
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
                Console.WriteLine(ex);
                Console.WriteLine($"Can't read csv file from '{filePath}'");
                throw;
            }

            return cellsList;
        }
    }
}
