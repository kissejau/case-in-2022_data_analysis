using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;

namespace Analyze.Sources
{
    class ExcelController
    {
        public ISheet UploadExcel()
        {
            HSSFWorkbook workbook;
            using (FileStream file = new FileStream(@"C:\Users\hoder\Desktop\CASE_IN\Analyze\Solution\stats.xls", FileMode.Open, FileAccess.Read))
            {
                workbook = new HSSFWorkbook(file);
            }
            return workbook.GetSheetAt(0);
        }

        public void UnloadExcel(List<int> idleCars)
        {
            string filePath = @"C:\Users\hoder\Desktop\CASE_IN\Analyze\Solution\solution.xls";

            XSSFWorkbook workbook;
            XSSFSheet sheet;

            workbook = new XSSFWorkbook();
            sheet = (XSSFSheet)workbook.CreateSheet("IdleCars");

            int col = idleCars.Count;


                var currentRow = sheet.CreateRow(0);
                for (int j = 0; j < col; j++)
                {
                    var currentCol = currentRow.CreateCell(j);
                    currentCol.SetCellValue(idleCars[j]);
                }

                if (!File.Exists(filePath))
                {
                    File.Delete(filePath);
                }

                using (var fs = new FileStream(filePath, FileMode.Create, FileAccess.Write))
                {
                    workbook.Write(fs);
                }

        }
    }
}
