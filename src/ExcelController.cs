using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;


namespace Analyze.Sources
{
    // uploading and unloading excel information
    class ExcelController
    {
        private Analyze analyze = new Analyze();
        public ISheet UploadExcel()
        {
            HSSFWorkbook workbook;
            using (FileStream file = new FileStream(@"C:\Users\hoder\Desktop\CASE_IN\Analyze\Solution\stats.xls", FileMode.Open, FileAccess.Read))
            {
                workbook = new HSSFWorkbook(file);
            }
            return workbook.GetSheetAt(0);
        }

        public void UnloadExcel(List<PersonalStats> ps)
        {
            string filePath = @"C:\Users\hoder\Desktop\CASE_IN\Analyze\Solution\solution.xls";

            XSSFWorkbook workbook;
            XSSFSheet sheet;
            List<OutputStats> os = analyze.ProfitsSearch(ps);
            IRow currentRow;

            workbook = new XSSFWorkbook();
            sheet = (XSSFSheet)workbook.CreateSheet("IdleCars");



            int col = 8;
            int row = os.Count + 1;
            Console.WriteLine(row);

            currentRow = sheet.CreateRow(0);
            currentRow.CreateCell(0).SetCellValue("id");
            currentRow.CreateCell(1).SetCellValue("Рабочие дни");
            currentRow.CreateCell(2).SetCellValue("Среднее время работы");
            currentRow.CreateCell(3).SetCellValue("Дата");
            currentRow.CreateCell(4).SetCellValue("Лучшее КПД");
            currentRow.CreateCell(5).SetCellValue("КПД (полезная работа / время)");
            currentRow.CreateCell(6).SetCellValue("Потраченное топливо");
            currentRow.CreateCell(7).SetCellValue("Полезная работа / топливо");
            currentRow.CreateCell(8).SetCellValue("Предельные обороты / Нагрузка");


            for (int i = 1; i < row; i++)
            {
                currentRow = sheet.CreateRow(i);

                currentRow.CreateCell(0).SetCellValue(os[i - 1].id);
                currentRow.CreateCell(1).SetCellValue(os[i - 1].workDays);
                currentRow.CreateCell(2).SetCellValue(os[i - 1].workTime);
                currentRow.CreateCell(3).SetCellValue(os[i - 1].date);
                currentRow.CreateCell(4).SetCellValue(os[i - 1].averageKPD + "%");
                currentRow.CreateCell(5).SetCellValue(os[i - 1].KPD * 100 + "%");
                currentRow.CreateCell(6).SetCellValue(os[i - 1].diffVolume);
                currentRow.CreateCell(7).SetCellValue(os[i - 1].kpd);
                currentRow.CreateCell(8).SetCellValue(os[i - 1].wear);
                if (i == 3)
                    currentRow.CreateCell(10).SetCellValue("Всего работало машин в этом месяце: " + analyze.WorkCarsSearch(ps));
            }


            for (int i = 0; i < col; i++)
            {
                sheet.AutoSizeColumn(i);
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
