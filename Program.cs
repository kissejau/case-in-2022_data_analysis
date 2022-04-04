using System;
using Analyze.Sources;

namespace Analyze
{
    class Program
    {

        public static void Main(string[] args)
        {

            var parser = new Parser();
            var analyze = new Sources.Analyze();
            var excel = new ExcelController();

            List<Stats> stats = new List<Stats>();
            List<PersonalStats> ps = new List<PersonalStats>();
            var sheet = excel.UploadExcel();


            parser.Parse(sheet, stats);
            parser.RelocateStats(stats, ps);

            excel.UnloadExcel(ps);

            double maxKpd = 0.0;
            int bestTemp = 0;
            double kpd = 0;
            for (int j = 0; j < ps[0].pi.Count; j++)
            {
                var temp = ps[0].pi[j];
                if (temp.timeWorkOfEngineInWorkload != 0)
                    kpd = (temp.timeWorkOfEngineInMovement + temp.timeWorkOfEngineInIdle - temp.timeWorkOfEngineInMin) / (temp.startVolume - temp.endVolume);
                if (maxKpd < kpd)
                {
                    maxKpd = kpd;
                    bestTemp = j + 1 + 1;
                }
            }
            /*
            Console.WriteLine(ps[0].pi[5].timeWorkOfEngineInMovement);
            Console.WriteLine(ps[0].pi[5].timeWorkOfEngineInIdle);
            Console.WriteLine(ps[0].pi[5].timeWorkOfEngineInMin);
            Console.WriteLine(ps[0].pi[5].timeWorkOfEngine);
            */
            //Console.WriteLine("Car with best kpd at " + bestTemp + "th row, with kpd = " + maxKpd);
        }
    }
}