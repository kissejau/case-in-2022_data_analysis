using System;
using NPOI.SS.UserModel;
using NPOI.HSSF.UserModel;

namespace Analyze
{
    struct Stats
    {

        public int id;

        public string date;

        public float mileage;

        public int timeInMovement;

        public int timeWorkOfEngine;

        public int timeWorkOfEngineInMovement;

        public int timeWorkOfEngineInIdle;

        public int timeWorkOfEngineInMin;

        public int timeWorkOfEngineInNorm;

        public int timeWorkOfEngineInMax;

        public int timeOffEngine;

        public int timeWorkOfEngineInWorkload;

        public float startVolume;

        public float endVolume;

        public Stats(int id, string date, float mileage, int timeInMovement,
            int timeWorkOfEngine, int timeWorkOfEngineInMovement,
            int timeWorkOfEngineInIdle, int timeWorkOfEngineInMin,
            int timeWorkOfEngineInNorm, int timeWorkOfEngineInMax,
            int timeOffEngine, int timeWorkOfEngineInWorkload,
            float startVolume, float endVolume)
        {
            this.id = id;
            this.date = date;
            this.mileage = mileage;
            this.timeInMovement = timeInMovement;
            this.timeWorkOfEngine = timeWorkOfEngine;
            this.timeWorkOfEngine = timeWorkOfEngine;
            this.timeWorkOfEngineInMovement = timeWorkOfEngineInMovement;
            this.timeWorkOfEngineInIdle = timeWorkOfEngineInIdle;
            this.timeWorkOfEngineInMin = timeWorkOfEngineInMin;
            this.timeWorkOfEngineInNorm = timeWorkOfEngineInNorm;
            this.timeWorkOfEngineInMax = timeWorkOfEngineInMax;
            this.timeOffEngine = timeOffEngine;
            this.timeWorkOfEngineInWorkload = timeWorkOfEngineInWorkload;
            this.startVolume = startVolume;
            this.endVolume = startVolume;
        }

    }
    class Program
    {
        public static int ConvertTime(string time)
        {
            int seconds = 0;
            string[] times = time.Split(':');
            seconds += ((Convert.ToInt32(times[0]) * 3600) + (Convert.ToInt32(times[1]) * 60) +
                        Convert.ToInt32(times[2]));
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

            for (int row = 1; row <= 1; row++)
            {
                var currentRow = sheet.GetRow(row);
                if (currentRow != null) 
                {
                    for (int j = 0; j < 14; j++)
                    {
                        //(currentRow.GetCell(j)).SetCellType(cell);
                    }
                    stats.Add(
                        new Stats(
                            Convert.ToInt32(currentRow.GetCell(0).StringCellValue),
                            currentRow.GetCell(1).StringCellValue,
                            float.Parse(currentRow.GetCell(2).StringCellValue),
                            ConvertTime(currentRow.GetCell(3).StringCellValue),
                            ConvertTime(currentRow.GetCell(4).StringCellValue),
                            ConvertTime(currentRow.GetCell(5).StringCellValue),
                            ConvertTime(currentRow.GetCell(6).StringCellValue),
                            ConvertTime(currentRow.GetCell(7).StringCellValue),
                            ConvertTime(currentRow.GetCell(8).StringCellValue),
                            ConvertTime(currentRow.GetCell(9).StringCellValue),
                            ConvertTime(currentRow.GetCell(10).StringCellValue),
                            ConvertTime(currentRow.GetCell(11).StringCellValue),
                            float.Parse(currentRow.GetCell(12).StringCellValue),
                            float.Parse(currentRow.GetCell(13).StringCellValue)
                        ));
                }
            }
            Console.WriteLine(stats[0].id);
        }
    }
}