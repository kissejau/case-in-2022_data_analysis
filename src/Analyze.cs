namespace Analyze.Sources
{
    class Analyze
    {
        public List<int> IdleSearch(List<PersonalStats> ps)
        {
            bool idleFlag;
            List<int> idleCars = new List<int>();

            for (int i = 0; i < ps.Count; i++)
            {
                idleFlag = false;

                foreach (var j in ps[i].pi)
                {
                    if (j.timeOffEngine != 0)
                    {
                        idleFlag = true;
                        break;
                    }
                }

                if (!idleFlag)
                {
                    idleCars.Add(ps[i].id);
                }
            }

            return idleCars;
        }

        public int WorkDaysSearch(List<PersonalInfo> pi)
        {
            int workDays = 0;
            foreach (var i in pi)
            {
                if (i.timeWorkOfEngine > 0)
                {
                    workDays++;
                }
            }

            return workDays;
        }

        public List<OutputStats> ProfitsSearch(List<PersonalStats> ps)
        {
            int workDays;
            List<OutputStats> os = new List<OutputStats>();

            foreach (var i in ps)
            {
                OutputStats output;
                workDays = WorkDaysSearch(i.pi);
                double KPD = 0;
                double temp = 0;
                double workTime = 0;
                output = new OutputStats(i.id, 0, 0.0, i.pi[0].date, 0.0, 0.0, 0.0, 0.0, 0.0);
                foreach (var j in i.pi)
                {
                    if (j.timeWorkOfEngine != 0)
                    {
                        temp = Math.Round((j.timeWorkOfEngineInMovement + j.timeWorkOfEngineInIdle - j.timeWorkOfEngineInMin) / j.timeWorkOfEngine, 2);
                        workTime += j.timeWorkOfEngine;
                        if (KPD < temp)
                        {
                            if (j.startVolume - j.endVolume > 0)
                            {
                                output = new OutputStats(i.id, workDays, workTime, j.date, temp, temp * j.timeWorkOfEngine,
                                                            j.startVolume - j.endVolume, temp * j.timeWorkOfEngine / (j.startVolume - j.endVolume),
                                                            j.timeWorkOfEngineInMax / j.timeWorkOfEngineInWorkload);
                            }
                            else
                            {
                                output = new OutputStats(i.id, workDays, workTime, j.date, temp, temp * j.timeWorkOfEngine,
                                    j.startVolume - j.endVolume, 0,
                                    j.timeWorkOfEngineInMax / j.timeWorkOfEngineInWorkload);
                            }

                            KPD = temp;
                        }
                    }

                }

                output.workTime = Math.Round(output.workTime / (30 * 3600), 2);
                os.Add(output);
            }
            /*
            foreach (var i in os)
            {
                Console.Write(i.id + " ");
                Console.Write(i.workDays + " ");
                Console.Write(i.date + " ");
                Console.Write(i.KPD + " ");
                Console.Write(i.usfulWork + " ");
                Console.Write(i.kpd + " ");
                Console.WriteLine(i.wear);
            }
            */
            return os;
        }
    }
}
