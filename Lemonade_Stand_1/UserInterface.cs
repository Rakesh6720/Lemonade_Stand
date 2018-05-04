﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lemonade_Stand_1
{
    public static class UserInterface
    {
        public static void Display(string phrase)
        {
            Console.WriteLine(phrase);
        }

        public static int GetNumGameDays()
        {
            UserInterface.Display("How long would you like to play for?\n1) 7 days\n2) 14 days\n 3) 21 days\n");
            string userInput = Console.ReadLine();
            int numDays = Int32.Parse(userInput);
            //INSERT A VALIDATION METHOD HERE
            return numDays;
        }
        public static void DisplayInventoryPrices(List<Supplies> inventory)
        {
            Display($"The prices of each item are:\nCups -- ${inventory[0].Price} per cup.");
            Display($"\nLemons -- ${inventory[1].Price} per lemon.");
            Display($"Sugar -- ${inventory[2].Price} per pound of sugar (2 cups/pound).");
            Display($"Ice -- {inventory[3].Price} per pound of ice (20 cups/pound.)");
        }

        public static void AskToBuy(string item)
        {
            if (item == "sugar")
            {
                Console.WriteLine($"How many cups of {item} would you like to buy (4 cups per pound)?");
            }
            else if (item == "ice")
            {
                Console.WriteLine($"How many pounds of {item} would you like to buy?");
            }
            else
            {
                Console.WriteLine($"How many {item} would you like to buy?");
            }
        }
        public static void DisplayStoreTransaction(string item, int numItems, double numItemsCost, Wallet playerWallet)
          {
            Console.WriteLine($"Cost of {numItems} {item}: ${numItemsCost}");
            double theoreticalAmount = playerWallet.Amount - numItemsCost;
            Console.WriteLine("Money remaining in your wallet: $" + theoreticalAmount + ".");
          }
        public static void DisplayConfirmation(int numItems, double costItems, double playerWalletAmount, string item, Store store, Player player)
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
                DisplayConfirmation(numItems, costItems, player.PlayerWallet.Amount, item, store, player);
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
        public static void DisplayForecast(int numDays, List<Day> gameDays)
        {
            Display("Would you like to see the forecast for the coming week?\n1) YES\n2) NO\n");
            string userInput = Console.ReadLine();
            if (userInput == "1")
            {
                for (int i = 0; i <= 6; i++)
                {
                    Display($"Weather for day {i}\n");
                    DisplayWeatherDay(gameDays[i]);
                    Display("\n");
                }
            }
            else if (userInput == "2")
            {
                return;
            }
            else
            {
                Display($"''{userInput}'' is not a valid respone.");
                DisplayForecast(numDays, gameDays);
            }

            
                
         }
        public static void DisplayWeatherDay(Day day)
        {
            if (day.Weather.IsSunny == true && day.Weather.IsRaining == true)
            {
                string sunny = "sunny";
                string rainy = "rainy";
                Console.WriteLine("The forecast for today is: " + day.Weather.Temperature + ", " + sunny + " and " + rainy + ".");
            }
            else if (day.Weather.IsSunny == false && day.Weather.IsRaining == true)
            {
                string sunny = "cloudy";
                string rainy = "rainy";
                Console.WriteLine("The forecast for today is: " + day.Weather.Temperature + ", " + sunny + " and " + rainy + ".");
            }

            else if (day.Weather.IsSunny == false && day.Weather.IsRaining == false)
            {
                string sunny = "cloudy";
                string rainy = "clear";
                Console.WriteLine("The forecast for today is: " + day.Weather.Temperature + ", " + sunny + " and " + rainy + ".");
            }
            else
            {
                string sunny = "sunny";
                string rainy = "clear";
                Console.WriteLine("The forecast for today is: " + day.Weather.Temperature + ", " + sunny + " and " + rainy + ".");
            }
            
        }
    }
}
