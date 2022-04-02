using System;
using NPOI.SS.UserModel;
using NPOI.HSSF.UserModel;

namespace Analyze
{
    class Program
    {
        
        public static void Main(string[] args)
        {

            var parser = new Parser();
            var analyze = new Solution.Analyze();

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
            
            Console.WriteLine("Кол-во техники: " + ps.Count);
            Console.WriteLine("Кол-во статистики по второй единице техники: " + ps[1].pi.Count);

            analyze.IdleSearch(ps);
        }
    }
}