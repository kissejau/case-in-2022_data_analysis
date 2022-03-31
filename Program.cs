using System;
using NPOI.SS.UserModel;
using NPOI.HSSF.UserModel;

namespace Analyze
{
    class Program
    {
        public static int ConvertTime(string time)
        {
            int seconds = 0;
            string[] times = time.Split(':');
            if (times.Length == 3)
            {
                seconds += ((Convert.ToInt32(times[0]) * 3600) + (Convert.ToInt32(times[1]) * 60) +
                            Convert.ToInt32(times[2]));
            }

            return seconds;
        }
        public static void Main(string[] args)
        {
            
            HSSFWorkbook xssfwb;

            List<Stats> stats = new List<Stats>();

            using (FileStream file = new FileStream(@"C:\Users\hoder\Desktop\CASE_IN\Analyze\stats.xls", FileMode.Open, FileAccess.Read))
            {
                xssfwb = new HSSFWorkbook(file);
            }

            ISheet sheet = xssfwb.GetSheetAt(0);

            for (int row = 1; row <= sheet.LastRowNum; row++)
            {
                var currentRow = sheet.GetRow(row);
                if (currentRow != null) 
                {
                    for (int j = 0; j < 14; j++)
                    {
                        //(currentRow.GetCell(j)).SetCellType(cell);
                    }

                    try
                    {
                        var i1 = Convert.ToInt32(currentRow.GetCell(0).NumericCellValue);
                        //Console.WriteLine(i1);
                        var i2 = currentRow.GetCell(1).StringCellValue;
                        //Console.WriteLine(i2);
                        var i3 = currentRow.GetCell(2).NumericCellValue;
                        //Console.WriteLine(i3);
                        var i4 = ConvertTime(currentRow.GetCell(3).StringCellValue);
                        //Console.WriteLine(i4);
                        var i5 = ConvertTime(currentRow.GetCell(4).StringCellValue);
                        //Console.WriteLine(i5);
                        var i6 = ConvertTime(currentRow.GetCell(5).StringCellValue);
                        //Console.WriteLine(i6);
                        var i7 = ConvertTime(currentRow.GetCell(6).StringCellValue);
                        //Console.WriteLine(i7);
                        var i8 = ConvertTime(currentRow.GetCell(7).StringCellValue);
                        //Console.WriteLine(i8);
                        var i9 = ConvertTime(currentRow.GetCell(8).StringCellValue);
                        //Console.WriteLine(i9);
                        var i10 = ConvertTime(currentRow.GetCell(9).StringCellValue);
                        //Console.WriteLine(i10);
                        var i11 = ConvertTime(currentRow.GetCell(10).StringCellValue);
                        //Console.WriteLine(i11);
                        var i12 = ConvertTime(currentRow.GetCell(11).StringCellValue);
                        //Console.WriteLine(i12);
                        var i13 = currentRow.GetCell(12).NumericCellValue;
                        //Console.WriteLine(i13);
                        var i14 = currentRow.GetCell(13).NumericCellValue;
                        //Console.WriteLine(i14);
                        stats.Add(
                            new Stats(
                                i1, i2, i3, i4, i5, i6, i7, i8, i9, i10, i11, i12, i13, i14
                            )
                        );
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(row);
                        Console.WriteLine(e.Message);
                        return;
                    }

                }
            }
            Console.WriteLine("End..");
            Console.Write(stats[stats.Count-1].timeWorkOfEngineInMin);

        }
    }
}