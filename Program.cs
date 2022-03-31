using System;

using NPOI.SS.UserModel;
using NPOI.HSSF.UserModel;

namespace Analyze
{
    struct Stats
    {
        public int id;

        public string date;

        public string mileage;

        public string timeInMovement;

        public string timeWorkOfEngine;

        public string timeWorkOfEngineInMovement;

        public string timeWorkOfEngineInIdle;

        public string timeWorkOfEngineInMin;

        public string timeWorkOfEngineInNorm;

        public string timeWorkOfEngineInMax;

        public string timeOffEngine;

        public string timeWorkOfEngineInWorkload;

        public float startVolume;

        public float endVolume;
    }
    class Program
    {
        public static void Main(string[] args)
        {
            HSSFWorkbook xssfwb;

            using (FileStream file = new FileStream(@"C:\Users\hoder\Desktop\CASE_IN\Analyze\stats.xls", FileMode.Open, FileAccess.Read))
            {
                xssfwb = new HSSFWorkbook(file);
            }

            ISheet sheet = xssfwb.GetSheetAt(0);

            for (int row = 0; row <= sheet.LastRowNum; row++)
            {
                var currentRow = sheet.GetRow(row);
                if (currentRow != null) 
                {
                    for (int column = 0; column < 14; column++)
                    {
                        var stringCellValue = currentRow.GetCell(column);

                        Console.Write(string.Format("Ячейка {0}-{1} значение:{2}", row, column, stringCellValue));
                    }
                }
                Console.WriteLine("");
            }
        }
    }
}