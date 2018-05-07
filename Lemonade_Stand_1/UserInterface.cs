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
            List<Supplies> inventory = new List<Supplies>();
            player.PlayerInventory = inventory;
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
                            store1.ExecutePurchase(userInputInt, cupCost, player);
                            for (int i = 0; i < userInputInt; i++)
                            {

                                player.PlayerInventory.Add(new Cup());
                            }
                            AskToBuy(store1, player);
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
                            store1.ExecutePurchase(userInputInt, lemonCost, player);
                            for (int i = 0; i < userInputInt; i++)
                            {
                                Lemon lemon = new Lemon();
                                player.PlayerInventory.Add(lemon);
                            }
                            AskToBuy(store1, player);
                            break;
                        }
                        else
                        {
                            AskToBuy(store1, player);
                            break;
                        }
                    }
                case "3":
                    {
                        Display("The price per cup of sugar is: $" + store1.sugar.Price + "(6 cups / pound)");
                        Display("How many cups of sugar would you like to buy?");
                        userInput = Console.ReadLine();
                        int userInputInt = Int32.Parse(userInput);
                        double sugarCost = store1.CalculateCost(store1.sugar.Price, userInputInt);
                        Display("Your total will be: $" + sugarCost + " for " + userInputInt + " cups of sugar.");
                        Display("You have $" + player.PlayerWallet.Amount + " in your account.");
                        Display("Would you like to make this purchase?");
                        userInput = Console.ReadLine();
                        if (userInput == "y" || userInput == "Y")
                        {
                            store1.ExecutePurchase(userInputInt, sugarCost, player);
                            for (int i = 0; i < userInputInt; i++)
                            {
                                Sugar sugar = new Sugar();
                                player.PlayerInventory.Add(sugar);
                            }
                            AskToBuy(store1, player);
                            break;
                        }
                        else
                        {
                            AskToBuy(store1, player);
                            break;
                        }
                    }
                case "4":
                    {
                        Display("The price per pound of ice is: $" + store1.ice.Price + "(20 cups / pound)");
                        Display("How many pounds of ice would you like to buy?");
                        userInput = Console.ReadLine();
                        int userInputInt = Int32.Parse(userInput);
                        double iceCost = store1.CalculateCost(store1.ice.Price, userInputInt);
                        Display("Your total will be: $" + iceCost + " for " + userInputInt + " pounds of ice.");
                        Display("You have $" + player.PlayerWallet.Amount + " in your account.");
                        Display("Would you like to make this purchase?");
                        userInput = Console.ReadLine();
                        if (userInput == "y" || userInput == "Y")
                        {
                            store1.ExecutePurchase(userInputInt, iceCost, player);
                            for (int i = 0; i < userInputInt; i++)
                            {
                                Ice ice = new Ice();
                                player.PlayerInventory.Add(ice);
                            }
                            AskToBuy(store1, player);
                            break;
                        }
                        else
                        {
                            AskToBuy(store1, player);
                            break;
                        }
                    }
                case "5":
                    {
                        break;
                    }
            }
        }
        public static void DisplayTransaction(string item, int numItem, double numItemCost, Wallet playerWallet)
          {
            Console.WriteLine($"Cost of {numItem} {item}: ${numItemCost}");
            double theoreticalAmount = playerWallet.Amount - numItemCost;
            Console.WriteLine("Money remaining in your wallet would be: $" + theoreticalAmount + ".");
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

        public static double AskForLemonadePrice()
        {
            Console.WriteLine("Enter the price of each cup of lemonade: ");
            try
            {
                double priceLemonade = Int32.Parse(Console.ReadLine());
                return priceLemonade;
            }
            catch (FormatException)
            {
                UserInterface.Display("Please enter a valid amount.");
                UserInterface.AskForLemonadePrice();
                return 1.0;
            }
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
