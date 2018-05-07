using System;
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
            if (numDays == 1 || numDays == 7)
            {
                numDays = 7;
                return numDays;
            }
            else if (numDays == 2 || numDays == 14)
            {
                numDays = 14;
                return numDays;
            }
            else if (numDays == 3 || numDays == 21)
            {
                numDays = 21;
                return numDays;
            }
            else
            {
                UserInterface.Display("Please enter a valid number.");
                GetNumGameDays();
                return 0;
            }
        
        }

        public static void DisplayPrices(Store store)
        {
            Display("the price of cup is " + store.cup.Price);
            Display("the price of lemon is " + store.lemon.Price);
            Display("the price of sugar is " + store.sugar.Price);
            Display("the price of ice is " + store.ice.Price);
        }

        public static void AskToBuy(Store store1, Player player)
        {
            Display("Enter the number of the item you'd like to buy: 1) Cups 2) Lemons 3) Sugar 4) Ice 5) exit store ");
            string userInput = Console.ReadLine();
            switch (userInput)
            {
                case "1":
                    {
                        Display("The price per cup is: $" + store1.cup.Price);
                        Display("How many cups would you like to buy?");
                        userInput = Console.ReadLine();
                        int userInputInt = Int32.Parse(userInput);
                        double cupCost = store1.CalculateCost(store1.cup.Price, userInputInt);
                        Display("Your total will be: $" + cupCost + " for " + userInputInt + " cups.");
                        Display("You have $" + player.PlayerWallet.Amount + " in your account.");
                        Display("Would you like to make this purchase?");
                        userInput = Console.ReadLine();
                        if (userInput == "y" || userInput == "Y")
                        {
                            store1.ExecutePurchase(userInputInt, store1.cup.Price, player);
                            for (int i=0; i<userInputInt; i++)
                            {
                                Cup cup = new Cup();
                                player.PlayerInventory.Add(cup);
                            }
                            break;
                        }
                        else
                        {
                            AskToBuy(store1, player);
                            break;
                        }
                    }
                case "2":
                    {
                        Display("The price per lemon is: $" + store1.lemon.Price);
                        Display("How many lemons would you like to buy?");
                        userInput = Console.ReadLine();
                        int userInputInt = Int32.Parse(userInput);
                        double lemonCost = store1.CalculateCost(store1.lemon.Price, userInputInt);
                        Display("Your total will be: $" + lemonCost + " for " + userInputInt + " lemons.");
                        Display("You have $" + player.PlayerWallet.Amount + " in your account.");
                        Display("Would you like to make this purchase?");
                        userInput = Console.ReadLine();
                        if (userInput == "y" || userInput == "Y")
                        {
                            store1.ExecutePurchase(userInputInt, store1.cup.Price, player);
                            for (int i = 0; i < userInputInt; i++)
                            {
                                Cup cup = new Cup();
                                player.PlayerInventory.Add(cup);
                            }
                            break;
                        }
                        else
                        {
                            AskToBuy(store1, player);
                            break;
                        }
                    }
                    
            }
           
        }
        public static void DisplayTransaction(string item, int numItem, double numItemCost, Wallet playerWallet)
          {
            Console.WriteLine($"Cost of {numItem} {item}: ${numItemCost}");
            double theoreticalAmount = playerWallet.Amount - numItemCost;
            Console.WriteLine("Money remaining in your wallet would be: $" + theoreticalAmount + ".");
          }
        public static void ConfirmPurchase(int numItem, double costItem, double playerWalletAmount, string item, Store store, Player player)
        {
            Console.WriteLine("Would you like to confirm this purchase? Y/N");
            string userInput = Console.ReadLine();
            if (userInput == "y" || userInput == "Y")
            {
                store.ExecutePurchase(numItem, costItem, player);
            }
            else if (userInput == "n" || userInput == "N")
            {
                AskToBuy(item);
            }
            else
            {
                Console.WriteLine("Please enter a valid respone: Y/N");
                ConfirmPurchase(numItem, costItem, player.PlayerWallet.Amount, item, store, player);
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

        //public static void AskNumberGallons()
        //{
        //    Console.WriteLine("How many gallons of lemonade would you like to make today?  (1 gallon = 16 cups)");
        //}

        public static void AskNumberToUse(string ingredient)
        {
            if (ingredient == "sugar")
            {
                Console.WriteLine("How many cups of sugar would you like to use?");
            }
            else if (ingredient == "ice")
            {
                Console.WriteLine("How many pounds of ice would you like to use?");
            }
            else
            { 
            Console.WriteLine($"How many {ingredient} would you like to use in your lemonade today?");
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
