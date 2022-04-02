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
    }
}
