using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Org.BouncyCastle.Crypto.Agreement.JPake;

namespace Analyze.Solution
{
    class Analyze
    {
        public void IdleSearch(List<PersonalStats> ps)
        {
            bool idleFlag;

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
                    Console.WriteLine("Car with id #" + ps[i].id + " was idle the whole time.");
                }
            }
        }
    }
}
