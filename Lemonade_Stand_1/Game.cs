using System;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lemonade_Stand_1
{
    class Game
    {
        Player player1;
        
        public int GetNumOfPlayers()
        {
            UserInterface.Display("Please enter the number of players: ");
            string userInput = Console.ReadLine();
            try
            {
                int numOfPlayers = Int32.Parse(userInput);
                return numOfPlayers;
            }
            catch (FormatException)
            {
                UserInterface.Display("Please enter a valid number of players.  Press any key to try again...");
                Console.ReadLine();
                GetNumOfPlayers();
                return 1;
            }
        }
        public void CreatePlayers(int numOfPlayers)
        {
            try
            {
                if (numOfPlayers == 1)
                {
                    UserInterface.Display("Please enter the name of Player 1: ");
                    string userName = Console.ReadLine();
                    //create player wallet
                    Wallet playerWallet = new Wallet();
                    //2.  Create player1 and pass into player1 object the instance of playerWallet
                    player1 = new Player(userName, playerWallet);
                }
                else
                {
                    UserInterface.Display("Haven't created multiplayer function yet");
                }
            }
            catch (FormatException)
            {
                UserInterface.Display("Enter a valid number of players.");
                CreatePlayers(numOfPlayers);
            }
        }
        public List<Day> CreateGameDayList(int numDays)
        {         
            List<Day> gameDays = new List<Day>();
            for (int i = 0; i < numDays; i++)
            {
                Day day = new Day();
                gameDays.Add(day);
            }
            return gameDays;
        }
        public void CreateWeatherReport(int numDays, List<Day> gameDays)
        {
            for (int i = 0; i < numDays; i++)
            {
                Weather weather = new Weather();
                gameDays[i].Weather = weather;
            }
        }
        public int CalculatePayingCustomers(double lemonadePrice, Day day)
        {
            int numberOfBuyingCustomers = 0;
            foreach (Customer customer in day.Customers)
            {
                if (customer.DetermineIfCustomerBuyWeather(day) == true && customer.DetermineIfCustomerBuyPrice(day, lemonadePrice) == true)
                {
                    //customer.WillBuy = true;
                    numberOfBuyingCustomers++;
                    return numberOfBuyingCustomers;
                }
                else
                {
                    return numberOfBuyingCustomers;
                }
            }
            return numberOfBuyingCustomers;
        }
        public int DetermineNumCupsSold(int numPayingCustomers)
        {
            Random random = new Random();
            int numCupsBuy = random.Next(1, 5);
            return numCupsBuy;
        }
        public static class SaveLoad
        {

            public static List<Game> savedGames = new List<Game>();

        }
        public static void SaveGame(List<Game> savedGames)
        {

            //savedGames.Add(Game.game);
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Create("/savedGames.lemonade");
            bf.Serialize(file, SaveLoad.savedGames);
            file.Close();
        }

    

    public void RunGame()
        {
            int numPlayers = GetNumOfPlayers();
            CreatePlayers(numPlayers);
            int numDays = UserInterface.GetNumGameDays();
            List<Day> gameDays = CreateGameDayList(numDays);

            for (int i = 0; i <= gameDays.Count; i++)
            {
                UserInterface.DisplayWeatherDay(gameDays[i]); 
                UserInterface.DisplayForecast(numDays, gameDays);

                if (i < 1)
                {
                    UserInterface.Display("Welcome to the Peabody General Store!");
                }
                else
                {
                    UserInterface.Display("Welcome back to the Peabody General Store!");
                    
                    int num = 0;
                    foreach(Cup item in player1.PlayerInventory)
                    {
                        num++;
                    }
                    UserInterface.Display("Your current inventory is: " + num + " cups.");

                    num = 0;
                    foreach (Lemon item in player1.PlayerInventory)
                    {
                        num++;
                    }
                    UserInterface.Display("Your current inventory is: " + num + " lemons.");

                    num = 0;
                    foreach (Sugar item in player1.PlayerInventory)
                    {
                        num++;
                    }
                    UserInterface.Display("Your current inventory is: " + num + " cups of sugar.");
                }

                Store store1 = new Store(); 

                UserInterface.AskToBuy(store1, player1);
                
                Stand stand = new Stand();
                UserInterface.DisplayWeatherDay(gameDays[i]);
                
                UserInterface.Display("How many gallons of lemonade would you like to make today?  (1 gallon = 16 cups)");
                string standGallons = Console.ReadLine();
                stand.Gallons = Int32.Parse(standGallons);

                
                UserInterface.AskNumberToUse("lemons");
                int numLemonsUse = Int32.Parse(Console.ReadLine());

                
                player1.RemoveFromInventory(numLemonsUse, "lemon");
                

                UserInterface.AskNumberToUse("sugar");
                int numSugarUse = Int32.Parse(Console.ReadLine());
                player1.RemoveFromInventory(numSugarUse, "sugar");

                UserInterface.AskNumberToUse("ice");
                int numIceUse = Int32.Parse(Console.ReadLine());
                player1.RemoveFromInventory(numIceUse, "ice");

                
                double priceLemonade = UserInterface.AskForLemonadePrice();


                
                int numPayingCustomers = CalculatePayingCustomers(priceLemonade, gameDays[i]);
               
                int numCupsSold = DetermineNumCupsSold(numPayingCustomers);
                UserInterface.Display("You sold " + numCupsSold + " cups of lemonade today.");
                int numCupsLeft = 0;
                foreach(Supplies item in player1.PlayerInventory)
                {
                    if (item.Name == "cup")
                    {
                        numCupsLeft++;
                    }
                }
                if (numCupsSold<numCupsLeft)
                {
                    player1.RemoveFromInventory(numCupsSold, "cup");
                }
                foreach (Lemon item in player1.PlayerInventory)
                {
                    if (item.Name == "lemon")
                    {
                        item.DecayValue--;
                    }
                    if (item.DecayValue == 0)
                    {
                        try
                        {
                            player1.RemoveFromInventory(1, "lemon");
                        }
                        catch (NullReferenceException)
                        {
                            return;
                        }
                    }
                }
                foreach (Ice item in player1.PlayerInventory)
                {
                    if (item.Name == "ice")
                    {
                        try
                        {
                            player1.RemoveFromInventory(1, "ice");
                        }
                        catch (NullReferenceException)
                        {
                            return;
                        }
                    }
                }

                Console.ReadLine();
                
                double amountEarned = priceLemonade * numCupsSold;
                Console.WriteLine($"Today you made a profit of ${amountEarned}");
                Console.ReadLine();

                player1.PlayerWallet.Amount = player1.PlayerWallet.Amount + amountEarned;
                Console.WriteLine($"You have {player1.PlayerWallet.Amount} in your account at the end of today.");
                Console.ReadLine();
                List<Game> savedGames = new List<Game>();
                UserInterface.Display("Would you like to save your progress, " + player1.name + "?  Y/N");
                string userInput = Console.ReadLine();
                if (userInput == "Y" || userInput == "y")
                {
                    SaveGame(savedGames);
                }

            }           
        }

    }
}
