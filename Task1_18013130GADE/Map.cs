using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1_18013130GADE
{
    class Map
    {
        Random r = new Random();
        private Unit[] units;

        public Unit[] Units
        {
            get { return units; }
            set { units = value; }
        }
        
        public Map(int maxX, int maxY, int numUnits)
        {
            units = new Unit[numUnits];
            for (int i = 0; i < numUnits; i++)
            {
                if (i % 2 == 0)
                {  //Places Units on the map.
                    MeleeUnit u = new MeleeUnit(r.Next(0, maxY), r.Next(0, maxX), r.Next(5, 10) * 10, r.Next(5, 20), 1, 1, "M", i % 2);

                    Units[i] = u;
                }

            }
        }
    }
}
