using System;
using NPOI.SS.UserModel;
using NPOI.HSSF.UserModel;

namespace Analyze
{
    class Program
    {
        
        public static void Main(string[] args)
        {

            Parser parser = new Parser();

            HSSFWorkbook xssfwb;
            List<Stats> stats = new List<Stats>();
            List<PersonalStats> ps = new List<PersonalStats>();

            using (FileStream file = new FileStream(@"C:\Users\hoder\Desktop\CASE_IN\Analyze\stats.xls", FileMode.Open, FileAccess.Read))
            {
                xssfwb = new HSSFWorkbook(file);
            }
            ISheet sheet = xssfwb.GetSheetAt(0);


            parser.Parse(sheet, stats);
            parser.RelocateStats(stats, ps);
            
            Console.WriteLine("End..");

            Console.WriteLine(ps[0].id + " " + ps[1].id + " " + ps[2].id);

        }
    }
}