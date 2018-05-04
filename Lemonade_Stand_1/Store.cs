using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lemonade_Stand_1
{
   public class Store
    {
        List<Supplies>inventory;

        public Store()
        {
            inventory = new List<Supplies>();
            for (int i=0; i<=3; i++)
            {
                inventory.Add(new Cup("cup"));
                inventory.Add(new Lemon("lemon"));
                inventory.Add(new Sugar("sugar"));
                inventory.Add(new Ice("ice"));
            }
        }
        public List<Supplies> Inventory
        {
            get
            {
                return inventory;
            }
            set
            {
                inventory = value;
            }
        }

        public void ExecutePurchase(int numItems, double costItems, Player player)
        {
            //player.PlayerWallet.Amount -= costItems;
            player.PlayerWallet.Debit(player.PlayerWallet, costItems);
            Console.WriteLine($"{numItems} purchased.\n Money remaining in personal account: ${player.PlayerWallet.Amount}.");
            
        }

        public double CalculateCost(double price, int numItems)
        {
            double result = price * numItems;
            
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
