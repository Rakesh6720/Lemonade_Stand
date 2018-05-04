using System;
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
            Cup cup = new Cup("cup");
            Lemon lemon = new Lemon("lemon");
            Sugar sugar = new Sugar("sugar");
            Ice ice = new Ice("ice");

            Console.WriteLine("The prices of each item are:\nCups -- " + cup.Price + "\nLemons -- " + lemon.Price + "\nSugar -- " + sugar.Price + " per cup\nIce -- " + ice.Price + " per pound");
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
            playerWallet.Amount -= numItemsCost;
            Console.WriteLine("Money remaining in your wallet: $" + playerWallet.Amount + ".");
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
