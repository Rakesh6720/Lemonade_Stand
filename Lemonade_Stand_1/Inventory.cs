using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lemonade_Stand_1
{
   public class Inventory
    {
        public int numCups;
        public int numLemons;
        public int poundsIce;
        public int cupsSugar;

        public Inventory()
        {
            this.numCups = 0;
            this.numLemons = 0;
            this.poundsIce = 0;
            this.cupsSugar = 0;
        }

        public Inventory CreateInventory(Inventory inventory, int numCups, int numLemons, int poundsIce, int cupsSugar)
        {
            inventory.numCups = numCups;
            inventory.numLemons = numLemons;
            inventory.poundsIce = poundsIce;
            inventory.cupsSugar = cupsSugar;

            return inventory;
        }
    }
}
