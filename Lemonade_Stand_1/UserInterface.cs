﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lemonade_Stand_1
{
    public static class UserInterface
    {
        public static void DisplayPrices()
        {
            Cup cup = new Cup();
            Lemon lemon = new Lemon();
            Sugar sugar = new Sugar();
            Ice ice = new Ice();

            Console.WriteLine("The prices of each item are:\nCups -- " + cup.Price + "\nLemons -- " + lemon.Price + "\nSugar -- " + sugar.Price + " per cup\nIce -- " + ice.Price + " per pound");
        }

        public static void AskToBuy(string item)
        {
            if (item == "sugar")
            {
                Console.WriteLine("How many cups of {0} would you like to buy (4 cups per pound)?", item);
            }
            else if (item == "ice")
            {
                Console.WriteLine("How many pounds of {0} would you like to buy?", item);
            }
            else
            { 
            Console.WriteLine("How many {0} would you like to buy?", item);
            }
        }

        public static void DisplayPlayerWalletStatus(Player player)
        {
            Console.WriteLine("You have $" + player.playerWallet.Amount + "left in your treasury.");
        }

        public static void DisplayCheckoutPrice(double checkoutPrice)
        {
            Console.WriteLine("Your total bill is: $" + checkoutPrice);
        }

        public static void AskNumberGallons()
        {
            Console.WriteLine("How many gallons of lemonade would you like to make today?  (1 gallon = 16 cups)");
        }

        public static void AskNumberToUse(string ingredients)
        {
            if (ingredients == "sugar")
            {
                Console.WriteLine("How many cups of sugar would you like to use?");
            }
            else if (ingredients == "ice")
            {
                Console.WriteLine("How many pounds of ice would you like to use?");
            }
            else
            { 
            Console.WriteLine($"How many {ingredients} would you like to use in your lemonade today?");
            }
        }

        public static void AskForLemonadePrice()
        { 
            Console.WriteLine("Enter the price of each cup of lemonade: ");
        }
    }
}
