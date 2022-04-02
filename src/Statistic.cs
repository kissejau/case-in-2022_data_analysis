using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Analyze.Sources
{

    struct Stats
    {

        public int id;

        public string date;

        public double mileage;

        public int timeInMovement;

        public int timeWorkOfEngine;

        public int timeWorkOfEngineInMovement;

        public int timeWorkOfEngineInIdle;

        public int timeWorkOfEngineInMin;

        public int timeWorkOfEngineInNorm;

        public int timeWorkOfEngineInMax;

        public int timeOffEngine;

        public int timeWorkOfEngineInWorkload;

        public double startVolume;

        public double endVolume;

        public Stats(int id, string date, double mileage, int timeInMovement,
            int timeWorkOfEngine, int timeWorkOfEngineInMovement,
            int timeWorkOfEngineInIdle, int timeWorkOfEngineInMin,
            int timeWorkOfEngineInNorm, int timeWorkOfEngineInMax,
            int timeOffEngine, int timeWorkOfEngineInWorkload,
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

        public int timeInMovement;

        public int timeWorkOfEngine;

        public int timeWorkOfEngineInMovement;

        public int timeWorkOfEngineInIdle;

        public int timeWorkOfEngineInMin;

        public int timeWorkOfEngineInNorm;

        public int timeWorkOfEngineInMax;

        public int timeOffEngine;

        public int timeWorkOfEngineInWorkload;

        public double startVolume;

        public double endVolume;

        public PersonalInfo(string date, double mileage, int timeInMovement,
            int timeWorkOfEngine, int timeWorkOfEngineInMovement,
            int timeWorkOfEngineInIdle, int timeWorkOfEngineInMin,
            int timeWorkOfEngineInNorm, int timeWorkOfEngineInMax,
            int timeOffEngine, int timeWorkOfEngineInWorkload,
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
}
