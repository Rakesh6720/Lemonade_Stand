using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lemonade_Stand_1
{
   public class Store
    {
        Inventory inventory;

        public Store(Inventory storeInventory)
        {
            this.inventory = storeInventory;

        }

        public double Checkout(int numCups, int numLemons, int cupsSugar, int numIce)
        {
            Cup cup = new Cup();
            Lemon lemon = new Lemon();
            Sugar sugar = new Sugar();
            Ice ice = new Ice();

            double result = (numCups * cup.Price) + (numLemons * lemon.Price) + (cupsSugar * sugar.Price) + (numIce * ice.Price);
            return result;
        }
    }
}
