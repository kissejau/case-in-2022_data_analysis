using System;
using System.Security;
using NPOI.SS.UserModel;
using NPOI.HSSF.UserModel;
using NPOI.OpenXmlFormats.Dml.Chart;

namespace Analyze
{
    struct Stats
    {

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

            for (int row = 0; row <= sheet.LastRowNum; row++)
            {
                var currentRow = sheet.GetRow(row);
                if (currentRow != null) 
                {

                }
                Console.WriteLine("");
            }
        }
    }
}