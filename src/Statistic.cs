using NPOI.SS.Formula.Functions;

namespace Analyze.Sources
{

    struct Stats
    {

        public int id;

        public string date;

        public double mileage;

        public double timeInMovement;

        public double timeWorkOfEngine;

        public double timeWorkOfEngineInMovement;

        public double timeWorkOfEngineInIdle;

        public double timeWorkOfEngineInMin;

        public double timeWorkOfEngineInNorm;

        public double timeWorkOfEngineInMax;

        public double timeOffEngine;

        public double timeWorkOfEngineInWorkload;

        public double startVolume;

        public double endVolume;

        public Stats(int id, string date, double mileage, double timeInMovement,
            double timeWorkOfEngine, double timeWorkOfEngineInMovement,
            double timeWorkOfEngineInIdle, double timeWorkOfEngineInMin,
            double timeWorkOfEngineInNorm, double timeWorkOfEngineInMax,
            double timeOffEngine, double timeWorkOfEngineInWorkload,
            double startVolume, double endVolume)
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
            this.endVolume = endVolume;
        }

    }

    struct PersonalInfo
    {

        public string date;

        public double mileage;

        public double timeInMovement;

        public double timeWorkOfEngine;

        public double timeWorkOfEngineInMovement;

        public double timeWorkOfEngineInIdle;

        public double timeWorkOfEngineInMin;

        public double timeWorkOfEngineInNorm;

        public double timeWorkOfEngineInMax;

        public double timeOffEngine;

        public double timeWorkOfEngineInWorkload;

        public double startVolume;

        public double endVolume;

        public PersonalInfo(string date, double mileage, double timeInMovement,
            double timeWorkOfEngine, double timeWorkOfEngineInMovement,
            double timeWorkOfEngineInIdle, double timeWorkOfEngineInMin,
            double timeWorkOfEngineInNorm, double timeWorkOfEngineInMax,
            double timeOffEngine, double timeWorkOfEngineInWorkload,
            double startVolume, double endVolume)
        {
            this.date = date;
            this.mileage = mileage;
            this.timeInMovement = timeInMovement;
            this.timeWorkOfEngine = timeWorkOfEngine;
            this.timeWorkOfEngineInMovement = timeWorkOfEngineInMovement;
            this.timeWorkOfEngineInIdle = timeWorkOfEngineInIdle;
            this.timeWorkOfEngineInMin = timeWorkOfEngineInMin;
            this.timeWorkOfEngineInNorm = timeWorkOfEngineInNorm;
            this.timeWorkOfEngineInMax = timeWorkOfEngineInMax;
            this.timeOffEngine = timeOffEngine;
            this.timeWorkOfEngineInWorkload = timeWorkOfEngineInWorkload;
            this.startVolume = startVolume;
            this.endVolume = endVolume;
        }

    }

    struct PersonalStats
    {
        public PersonalStats(int id, List<PersonalInfo> pi)
        {
            this.id = id;
            this.pi = pi;
        }

        public int id;

        public List<PersonalInfo> pi;
    }

    struct OutputStats
    {
        public OutputStats(int id, int workDays, double workTime, string date, double averageKPD, double KPD, double usfulWork, double diffVolume, double kpd, double wear)
        {
            this.id = id;
            this.workDays = workDays;
            this.workTime = workTime;
            this.date = date;
            this.averageKPD = averageKPD;
            this.KPD = KPD;
            this.usfulWork = diffVolume;
            this.diffVolume = diffVolume;
            this.kpd = kpd;
            this.wear = wear;
        }

        public int id;
        public int workDays;
        public double workTime;
        public string date;
        public double averageKPD;
        public double KPD;
        public double usfulWork;
        public double diffVolume;
        public double kpd;
        public double wear;
    }
}
