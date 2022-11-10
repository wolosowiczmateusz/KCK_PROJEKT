using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KCK_PROJEKT
{
    public class Formation
    {
        public string Name { get; set; }
        public int DEFCount { get; set; }
        public int MIDCount { get; set; }
        public int STCount { get; set; }

        public List<string> Positions = new List<string>();

        public Formation(string name) {
            this.Name = name;
        }
        public Formation() { }

        public string getPositions()
        {
            string positions = "GK\n";
            int tmp = 0;
            for(int i = 1; i < DEFCount + 1; i++)
            {
                positions += Positions[i] + " ";
                tmp = i;
            }
            tmp++;
            positions += "\n";

            for(int i = tmp; i < DEFCount + MIDCount + 1; i++)
            {
                positions += Positions[i] + " ";
                tmp = i;
            }
            tmp++;
            positions += "\n";

            for (int i = tmp; i < DEFCount + MIDCount + STCount + 1; i++)
            {
                positions += Positions[i] + " ";
            }
            return positions;
        }

    }
}
