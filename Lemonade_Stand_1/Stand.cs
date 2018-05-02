using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lemonade_Stand_1
{
    public class Stand
    {
        public Inventory inventory;
        public int gallons;

        public Stand(Inventory standInventory, int gallons)
        {
            this.inventory = standInventory;
            this.gallons = gallons;
        }
    }
}
