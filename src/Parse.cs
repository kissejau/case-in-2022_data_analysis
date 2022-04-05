
using NPOI.SS.UserModel;

namespace Analyze.Sources
{
    internal class Parser
    {
        private int ConvertTime(string time)
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
        public void Parse(ISheet sheet, List<Stats> stats)
        {
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
        }

        public void RelocateStats(List<Stats> stats, List<PersonalStats> ps)
        {
            for (int i = 0; i < stats.Count; i++)
            {
                if (i == 0)
                {
                    ps.Add(new PersonalStats(stats[i].id, new List<PersonalInfo>()));
                    ps[i].pi.Add(
                        new PersonalInfo(
                            stats[i].date,
                    stats[i].mileage,
                    stats[i].timeInMovement,
                     stats[i].timeWorkOfEngine,
                    stats[i].timeWorkOfEngineInMovement,
                    stats[i].timeWorkOfEngineInIdle,
                    stats[i].timeWorkOfEngineInMin,
                    stats[i].timeWorkOfEngineInNorm,
                    stats[i].timeWorkOfEngineInMax,
                    stats[i].timeOffEngine,
                    stats[i].timeWorkOfEngineInWorkload,
                    stats[i].startVolume,
                    stats[i].endVolume));
                }
                else
                {
                    bool fl = false;
                    for (int j = 0; j < ps.Count; j++)
                    {
                        if (stats[i].id == ps[j].id)
                        {
                            ps[j].pi.Add(
                                new PersonalInfo(
                                    stats[i].date,
                                    stats[i].mileage,
                                    stats[i].timeInMovement,
                                    stats[i].timeWorkOfEngine,
                                    stats[i].timeWorkOfEngineInMovement,
                                    stats[i].timeWorkOfEngineInIdle,
                                    stats[i].timeWorkOfEngineInMin,
                                    stats[i].timeWorkOfEngineInNorm,
                                    stats[i].timeWorkOfEngineInMax,
                                    stats[i].timeOffEngine,
                                    stats[i].timeWorkOfEngineInWorkload,
                                    stats[i].startVolume,
                                    stats[i].endVolume));
                            fl = true;
                        }
                    }

                    if (!fl)
                    {
                        ps.Add(new PersonalStats(stats[i].id, new List<PersonalInfo>()));
                        ps[ps.Count - 1].pi.Add(
                            new PersonalInfo(
                                stats[i].date,
                                stats[i].mileage,
                                stats[i].timeInMovement,
                                stats[i].timeWorkOfEngine,
                                stats[i].timeWorkOfEngineInMovement,
                                stats[i].timeWorkOfEngineInIdle,
                                stats[i].timeWorkOfEngineInMin,
                                stats[i].timeWorkOfEngineInNorm,
                                stats[i].timeWorkOfEngineInMax,
                                stats[i].timeOffEngine,
                                stats[i].timeWorkOfEngineInWorkload,
                                stats[i].startVolume,
                                stats[i].endVolume));
                    }
                }
            }
        }
    }
}
