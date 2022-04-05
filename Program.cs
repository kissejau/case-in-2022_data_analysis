using Analyze.Sources;

namespace Analyze
{
    class Program
    {

        public static void Main(string[] args)
        {

            var parser = new Parser();
            var excel = new ExcelController();

            List<Stats> stats = new List<Stats>();
            List<PersonalStats> ps = new List<PersonalStats>();
            var sheet = excel.UploadExcel();

            parser.Parse(sheet, stats);
            parser.RelocateStats(stats, ps);

            excel.UnloadExcel(ps);
        }
    }
}