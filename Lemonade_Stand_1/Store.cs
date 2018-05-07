﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lemonade_Stand_1
{
   public class Store
    {
        Cup cup;
        Lemon lemon;
        Sugar sugar;
        Ice ice;

        public Store()
        {
            Cup cup = new Cup();
            Lemon lemon = new Lemon();
            Sugar sugar = new Sugar();
            Ice ice = new Ice();
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
            Cup cup = new Cup();
            Lemon lemon = new Lemon();
            Sugar sugar = new Sugar();
            Ice ice = new Ice();

            double result = (numCups * cup.Price) + (numLemons * lemon.Price) + (cupsSugar * sugar.Price) + (numIce * ice.Price);
            return result;
        }

    }
}
