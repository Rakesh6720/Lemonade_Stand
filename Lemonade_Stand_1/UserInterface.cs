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
        public static void DisplayStoreTransaction(int numCups, double numCupsCost, Player player)
          {
            Console.WriteLine($"Cost of {numCups} cups: ${numCupsCost}");
            double theoreticalCost = player.PlayerWallet.Amount - numCups;
            Console.WriteLine("Money remaining in your wallet: $" + theoreticalCost + ".");
          }
        public static void DisplayConfirmation(int numItems, double costItems, Player player, string item, Store store)
        {
            Console.WriteLine("Would you like to confirm this purchase? Y/N");
            string userInput = Console.ReadLine();
            if (userInput == "y" || userInput == "Y")
            {
                store.ExecutePurchase(numItems, costItems, player);
            }
            else if (userInput == "n" || userInput == "N")
            {
                AskToBuy(item);
            }
            else
            {
                Console.WriteLine("Please enter a valid respone: Y/N");
                DisplayConfirmation(numItems, costItems, player, item, store);
            }
        }
    public static void DisplayPlayerWalletStatus(Player player)
        {
            Console.WriteLine("You have $" + player.PlayerWallet.Amount + "left in your personal account.");
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

        public static void DisplayWeather(Day day1)
        {
            if (day1.Weather.IsSunny == true && day1.Weather.IsRaining == true)
            {
                string sunny = "sunny";
                string rainy = "rainy";
                Console.WriteLine("The forecast for today is: " + day1.Weather.Temperature + ", " + sunny + " and " + rainy + ".");
            }
            else if (day1.Weather.IsSunny == false && day1.Weather.IsRaining == true)
            {
                string sunny = "cloudy";
                string rainy = "rainy";
                Console.WriteLine("The forecast for today is: " + day1.Weather.Temperature + ", " + sunny + " and " + rainy + ".");
            }

            else if (day1.Weather.IsSunny == false && day1.Weather.IsRaining == false)
            {
                string sunny = "cloudy";
                string rainy = "clear";
                Console.WriteLine("The forecast for today is: " + day1.Weather.Temperature + ", " + sunny + " and " + rainy + ".");
            }
            else
            {
                string sunny = "sunny";
                string rainy = "clear";
                Console.WriteLine("The forecast for today is: " + day1.Weather.Temperature + ", " + sunny + " and " + rainy + ".");
            }
            
        }
    }
}
