using NPOI.HSSF.UserModel;
using System.IO;

namespace AssessmentDeliveryTestingFramework.Utils.FileUtils.Office
{
    public class Excel
    {
        public Dictionary<string, string> GetAddressesAndCellsFromXls(string fileName, string sheetName, int row)
        {
            var file = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            var excel = new HSSFWorkbook(file);
            var addresses = excel.GetSheet(sheetName).GetRow(row).Cells.Select(c => c.Address.FormatAsString());
            var names = excel.GetSheet(sheetName).GetRow(row).Cells.Select(c => c.StringCellValue);
            file.Close();

            return new Dictionary<string, string>(addresses.Zip(names, (k, v) => new { k, v }).ToDictionary(x => x.k, x => x.v));
        }

        public string GetCellCommentFromXls(string fileName, string sheetName, int row, int cellNumber)
        {
            var file = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            var excel = new HSSFWorkbook(file);
            var cells = excel.GetSheet(sheetName).GetRow(row).Cells;
            file.Close();

            return cells[cellNumber].CellComment.String.ToString();
        }

        public void UpdateCellInXlsAndSaveFile(string fileName, string sheetName, int row, int cellNumber, string text)
        {
            var file = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            var excel = new HSSFWorkbook(file);
            var cells = excel.GetSheet(sheetName).GetRow(row).Cells;
            cells[cellNumber].SetCellValue(text);
            file.Close();

            var wstr = new FileStream(fileName, FileMode.Create, FileAccess.Write);
            excel.Write(wstr);
            wstr.Close();
        }
    }
}
