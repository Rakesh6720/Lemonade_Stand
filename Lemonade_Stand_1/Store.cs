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
        public void ExecutePurchase(int numItems, double costItems, Player player)
        {
            double paidAmount = player.PlayerWallet.Amount - costItems;
            Console.WriteLine($"{numItems} purchased.\n Money remaining in personal account: ${paidAmount}");
            player.PlayerWallet.Debit(player, player.PlayerWallet.Amount, costItems);
        }
        public double CalculateCost(Supplies supply, int numItems)
        {
            double result = supply.Price * numItems;
            
            return result;
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
