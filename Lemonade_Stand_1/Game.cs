using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lemonade_Stand_1
{
    class Game
    {
        Player player1;
        //Player player2;


        //member methods

        //1.  Ask the user how many players there will be.
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

        //  Assume it is one player for now.
        public void CreatePlayers(int numOfPlayers)
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

        


        public List<Day> CreateGameDayList(int numDays)
        {
            
            List<Day> gameDays = new List<Day>();
            for (int i = 0; i <= numDays; i++)
            {
                Day day = new Day();
                gameDays.Add(day);
            }
            return gameDays;
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

        public void CreateWeatherReport(int numDays, List<Day> gameDays)
        {
            for(int i = 0; i<numDays; i++)
            {
                Weather weather = new Weather();
                gameDays[i].Weather = weather;
            }
            
        }


        public void RunGame()
        {
            int numPlayers = GetNumOfPlayers();
            CreatePlayers(numPlayers);
            int numDays = UserInterface.GetNumGameDays(); //Get number of days from player
            List<Day> gameDays = CreateGameDayList(numDays);
            UserInterface.DisplayWeatherDay(gameDays[0]); // Give the player the weather for the day
            UserInterface.DisplayForecast(numDays, gameDays); //Give the player the forecast for the coming week
            UserInterface.Display("Welcome to the Peabody General Store!"); // Welcome the playe to the store
            Store store1 = new Store(); // instantiate a new store with its own inventory
            UserInterface.DisplayInventoryPrices(store1.Inventory);

            UserInterface.AskToBuy(store1.Inventory[0].Name);
            string numString = Console.ReadLine();
            int numItem = Int32.Parse(numString);
            double numItemCost = store1.CalculateCost(store1.Inventory[0].Price, numItem);
            UserInterface.DisplayTransaction(store1.Inventory[0].Name, numItem, numItemCost, player1.PlayerWallet);
            UserInterface.ConfirmPurchase(numItem, numItemCost, player1.PlayerWallet.Amount, store1.Inventory[0].Name, store1, player1);
        }
        public void GoShopping(List<Supplies> inventory, Store store1, Player player1)
        {
            foreach (Supplies item in inventory)
            {
                UserInterface.AskToBuy(item.Name);
                string numString = Console.ReadLine();
                int numItem = Int32.Parse(numString);
                double numItemCost = store1.CalculateCost(store1.Inventory[0].Price, numItem);
                UserInterface.DisplayTransaction(store1.Inventory[0].Name, numItem, numItemCost, player1.PlayerWallet);
                UserInterface.ConfirmPurchase(numItem, numItemCost, player1.PlayerWallet.Amount, store1.Inventory[0].Name, store1, player1);
                double runningTotal = 0;
                runningTotal += item.Price;
            }

            //START HERE AFTER MAY 4 DOGGY!!!
            double totalCheckOutPrice = store1.Checkout(numCups, numLemons, cupsSugar, numIce);

            //DISPLAY total check out price
            UserInterface.DisplayCheckoutPrice(totalCheckOutPrice);

            //9.  Subtract the total amount owed from the Player Wallet.  
            try
            {
                player1.PlayerWallet.Debit(player1.PlayerWallet, totalCheckOutPrice);
            }
            catch (Exception)
            {
                Console.WriteLine("You ran out of money!\nGAME OVER!");
                Console.ReadLine();
            }

            //DISPLAY the player's wallet status
            UserInterface.DisplayPlayerWalletStatus(player1);

            //10.  MOVE the items FROM the STORE INVENTORY OBJECT to the PLAYER INVENTORY OBJECT
            //create player method that updates player inventory
            List<Supplies> playerInventory = supplies.CreateInventory(numCups, numLemons, numIce, cupsSugar);
            player1.PlayerInventory = playerInventory;
        }

        
            


            
     
        
           

            UserInterface.AskToBuy("lemons");
            supplyItem = "lemons";
            string numLemonsString = Console.ReadLine();
            int numLemons = Int32.Parse(numLemonsString);
            Lemon lemon = new Lemon(supplyItem);
            double numLemonsCost = store1.CalculateCost(lemon.Price, numLemons);
            UserInterface.DisplayStoreTransaction(supplyItem, numLemons, numLemonsCost, player1.PlayerWallet);
            UserInterface.DisplayConfirmation(numLemons, numLemonsCost, player1.PlayerWallet.Amount, supplyItem, store1, player1);

            UserInterface.AskToBuy("sugar");
            supplyItem = "sugar";
            string cupsSugarString = Console.ReadLine();
            int cupsSugar = Int32.Parse(cupsSugarString);
            Sugar sugar = new Sugar(supplyItem);
            double cupsSugarCost = store1.CalculateCost(sugar.Price, cupsSugar);
            UserInterface.DisplayStoreTransaction(supplyItem, cupsSugar, cupsSugarCost, player1.PlayerWallet);
            UserInterface.DisplayConfirmation(cupsSugar, cupsSugarCost, player1.PlayerWallet.Amount, supplyItem, store1, player1);

            UserInterface.AskToBuy("ice");
            supplyItem = "ice";
            string numIceString = Console.ReadLine();
            int numIce = Int32.Parse(numIceString);
            Ice ice = new Ice(supplyItem);
            double numIceCost = store1.CalculateCost(ice.Price, numIce);
            UserInterface.DisplayStoreTransaction(supplyItem, numIce, numIceCost, player1.PlayerWallet);
            UserInterface.DisplayConfirmation(numIce, numIceCost, player1.PlayerWallet.Amount, supplyItem, store1, player1);

            //8.  Tally the total amount owed by the Player to the Store.


            //.  INSTANTIATE a STAND object and CREATE its own INVENTORY object
            Inventory standInventory = new Inventory();
            //standInventory = standInventory.CreateInventory(standInventory, numCups, numLemons, numIce, cupsSugar);
            Stand stand = new Stand();

            //10.  Ask the PLAYER OBJECT how many GALLONS (16 cups of lemonade in one gallon) of lemonade she would like to make for THE STAND OBJECT
            UserInterface.AskNumberGallons();
            string standGallons = Console.ReadLine();
            stand.Gallons = Int32.Parse(standGallons);

            //-- AND ask the Player Object how many items of EACH SUPPLY she would like to use FROM HER INVENTORY
            UserInterface.AskNumberToUse("lemons");
            int numLemonsUse = Int32.Parse(Console.ReadLine());

            //-- Subtract the number of cups, lemons, sugar, and ice from the PLAYER OBJECT INVENTORY OBJECT
            player1.RemoveFromInventory(player1, numLemonsUse, lemon);
            //player1.PlayerInventory.numLemons -= numLemonsUse;

            UserInterface.AskNumberToUse("sugar");
            int numSugarUse = Int32.Parse(Console.ReadLine());
            player1.RemoveFromInventory(player1, numSugarUse, sugar);

            UserInterface.AskNumberToUse("ice");
            int numIceUse = Int32.Parse(Console.ReadLine());
            player1.RemoveFromInventory(player1, numIceUse, ice);

            //ask the player to set the price of each cup of lemonade
            UserInterface.AskForLemonadePrice();
            double priceLemonade = Int32.Parse(Console.ReadLine());

            //11.  CREATE LOOP METHODS in CUSTOMER CLASS to determine how many customers will buy and how many cups they will buy
            int numPayingCustomers = CalculatePayingCustomers(priceLemonade, day1);
            int numCupsSold = DetermineNumCupsSold(numPayingCustomers);
            //MUST ADD METHOD TO DETERMINE HOW PLAYER RECIPE INFLUENCES CUSTOMER PURCHASE

            //13.  Tally the Total Amount of money earned by the STAND object's WALLET object.  
            double amountEarned = priceLemonade * numCupsSold;
            Console.WriteLine($"You sold {numCupsSold} cups of lemonade today for a profit of ${amountEarned}");
            player1.PlayerWallet.Amount = player1.PlayerWallet.Amount + amountEarned;
            Console.WriteLine($"You have {player1.PlayerWallet.Amount} in your treasury.");
            //14.   Add / Subtract the Stand Object's Wallet Object's contents to the Player Object's Wallet Object
            //15.  Move the cups, sugar, and lemons FROM the STORE INVENTORY OBJECT to the PLAYER INVENTORY OBJECT
        }
    }
}
