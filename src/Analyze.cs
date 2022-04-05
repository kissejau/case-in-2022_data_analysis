namespace Analyze.Sources
{
    class Analyze
    {
        // tracking running machines
        public int WorkCarsSearch(List<PersonalStats> ps)
        {
            int workCars = 0;
            foreach (var i in ps)
            {
                bool fl = false;
                foreach (var j in i.pi)
                {
                    if (j.timeWorkOfEngine != 0)
                        fl = true;
                }

                if (fl)
                    workCars++;

            }

            return workCars;
        }

        // tracking idle machines
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

        // tracking working days
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

        // calculating efficiencies and other statistics
        public List<OutputStats> ProfitsSearch(List<PersonalStats> ps)
        {
            int workDays;
            List<OutputStats> os = new List<OutputStats>();

            foreach (var i in ps)
            {
                OutputStats output;
                workDays = WorkDaysSearch(i.pi);
                double KPD = 0;
                double tempKPD = 0;
                double temp = 0;
                double workTime = 0;
                double diffVolume = 0;
                double kpd = 0;
                double wear = 0;
                output = new OutputStats(i.id, 0, 0.0, i.pi[0].date, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0);
                foreach (var j in i.pi)
                {
                    if (j.timeWorkOfEngine != 0)
                    {
                        temp = (j.timeWorkOfEngineInMovement + j.timeWorkOfEngineInIdle - j.timeWorkOfEngineInMin) / j.timeWorkOfEngine;
                        workTime += j.timeWorkOfEngine;
                        KPD += temp;
                        if (j.timeWorkOfEngineInWorkload != 0)
                            wear += j.timeWorkOfEngineInMax / j.timeWorkOfEngineInWorkload;
                        if (tempKPD < temp)
                        {

                            if (j.startVolume - j.endVolume > 0)
                            {
                                output = new OutputStats(i.id, workDays, workTime, j.date, 0.0, temp, temp * j.timeWorkOfEngine,
                                    j.startVolume - j.endVolume, temp * j.timeWorkOfEngine / (j.startVolume - j.endVolume),
                                    j.timeWorkOfEngineInMax / j.timeWorkOfEngineInWorkload);
                                diffVolume += j.startVolume - j.endVolume;
                                kpd += temp * j.timeWorkOfEngine / (j.startVolume - j.endVolume);

                            }
                            else
                            {
                                output = new OutputStats(i.id, workDays, workTime, j.date, 0.0, temp, temp * j.timeWorkOfEngine,
                                    j.startVolume - j.endVolume, 0,
                                    j.timeWorkOfEngineInMax / j.timeWorkOfEngineInWorkload);
                            }

                            tempKPD = temp;
                        }

                    }


                }
                output.KPD = Math.Round(KPD / (30), 2);
                output.workTime = Math.Round(workTime / (30 * 3600), 2);

                if (workDays != 0)
                    output.diffVolume = Math.Round(diffVolume / (workDays), 2);
                else
                    output.diffVolume = 0;
                if (diffVolume == 0)
                    output.kpd = 0;
                else
                    output.kpd = kpd / 30;
                output.wear = wear / 30;
                output.averageKPD = Math.Round(tempKPD, 2) * 100;
                os.Add(output);
            }

            return os;
        }
    }
}
