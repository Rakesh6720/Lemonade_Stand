using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lemonade_Stand_1
{
   public class Inventory
    {
        int numCups;
        int numLemons;
        int poundsIce;
        int cupsSugar;

        public Inventory(int numCups, int numLemons, int poundsIce, int cupsSugar)
        {
            this.numCups = 0;
            this.numLemons = 0;
            this.poundsIce = 0;
            this.cupsSugar = 0;
        }
    }
}
