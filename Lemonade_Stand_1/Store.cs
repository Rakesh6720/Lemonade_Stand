using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lemonade_Stand_1
{
   public class Store
    {
        List<Supplies> inventory;

        public Store(List<Supplies> inventory)
        {
            this.inventory = inventory;

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
            Cup cup = new Cup("cup");
            Lemon lemon = new Lemon("lemon");
            Sugar sugar = new Sugar("sugar");
            Ice ice = new Ice("ice");

            double result = (numCups * cup.Price) + (numLemons * lemon.Price) + (cupsSugar * sugar.Price) + (numIce * ice.Price);
            return result;
        }
    }
}
