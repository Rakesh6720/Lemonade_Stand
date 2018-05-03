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

        //1.  Ask the user how many players there will be.
        public int GetNumOfPlayers()
        {
            Console.WriteLine("Please enter the number of players: ");
            string userInput = Console.ReadLine();
            try
            { 
            int numOfPlayers = Int32.Parse(userInput);
            return numOfPlayers;
            }
            catch (FormatException)
            {
                Console.WriteLine("Please enter a valid number of players.  Press any key to try again...");
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
                Console.WriteLine("Please enter the name of Player 1: ");
                string userName = Console.ReadLine();
                //create player wallet and player inventory objects
                Wallet playerWallet = new Wallet();
                Inventory playerInventory = new Inventory();
                //2.  Create player1 and pass into player1 object the instance of playerWallet and playerInventory
                player1 = new Player(userName, playerWallet, playerInventory);
            }
            else
            {
                Console.WriteLine("Haven't created multiplayer function yet");
            }
        }

        public void RunGame()
        {
            int numPlayers = GetNumOfPlayers();
            CreatePlayers(numPlayers);

            //.  Instantiate a DAY object
            Day day1 = new Day();

            //4.  Give the player the forecast for the current day.
            UserInterface.DisplayWeather(day1);

            //.  INSTANTIATE a STORE object that has an inventory object of supplies
            Inventory newStoreInventory = new Inventory();
            Store store1 = new Store(newStoreInventory);

            //5.  Take the plalyer to the STORE.  
            //6.  Display to the player how much eat item costs.
            UserInterface.DisplayPrices();

            //7.  Ask the player how many of each item they would like to buy.
            UserInterface.AskToBuy("cups");
            string numCupsString = Console.ReadLine();
            int numCups = Int32.Parse(numCupsString);
            Cup cup = new Cup();
            double numCupsCost = store1.CalculateCost(cup, numCups);
            Console.WriteLine($"Cost of {numCups} cups: ${numCupsCost}");
            double theoreticalCost = player1.PlayerWallet.Amount - numCups;
            Console.WriteLine("Money remaining in your wallet: $" + theoreticalCost + ".");
            Console.WriteLine("Would you like to confirm this purchase? Y/N");
            string userInput = Console.ReadLine();
            if (userInput == "y" || userInput == "Y")
            {
                Console.WriteLine($"{numCups} purchased.\n Money remaining in personal account: ${theoreticalCost}");
                player1.PlayerWallet.Debit(player1, player1.PlayerWallet.Amount, numCupsCost);
            }

            UserInterface.AskToBuy("lemons"); 
            string numLemonsString = Console.ReadLine();
            int numLemons = Int32.Parse(numLemonsString);
            Lemon lemon = new Lemon();
            double numLemonsCost = store1.CalculateCost(lemon, numLemons);

            UserInterface.AskToBuy("sugar");
            string cupsSugarString = Console.ReadLine();
            int cupsSugar = Int32.Parse(cupsSugarString);
            Sugar sugar = new Sugar();
            double cupsSugarCost = store1.CalculateCost(sugar, cupsSugar);

            UserInterface.AskToBuy("ice");
            string numIceString = Console.ReadLine();
            int numIce = Int32.Parse(numIceString);
            Ice ice = new Ice();
            double numIceCost = store1.CalculateCost(ice, numIce);

            //8.  Tally the total amount owed by the Player to the Store.
            double totalCheckOutPrice = store1.Checkout(numCups, numLemons, cupsSugar, numIce);

            //DISPLAY total check out price
            UserInterface.DisplayCheckoutPrice(totalCheckOutPrice);

            //9.  Subtract the total amount owed from the Player Wallet.  
            try
            { 
            player1.PlayerWallet.Debit(player1.PlayerWallet.Amount, totalCheckOutPrice);
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
            player1.UpdatePlayerInventory(numCups, numLemons, cupsSugar, numIce);

            //.  INSTANTIATE a STAND object and CREATE its own INVENTORY object
            Inventory standInventory = new Inventory();
            standInventory = standInventory.CreateInventory(standInventory, numCups, numLemons, numIce, cupsSugar);
            Stand stand = new Stand(standInventory, 0);

            //10.  Ask the PLAYER OBJECT how many GALLONS (16 cups of lemonade in one gallon) of lemonade she would like to make for THE STAND OBJECT
            UserInterface.AskNumberGallons();
            string standGallons = Console.ReadLine();
            stand.gallons = Int32.Parse(standGallons);

            //-- AND ask the Player Object how many items of EACH SUPPLY she would like to use FROM HER INVENTORY
            UserInterface.AskNumberToUse("lemons");
            int numLemonsUse = Int32.Parse(Console.ReadLine());

            //-- Subtract the number of cups, lemons, sugar, and ice from the PLAYER OBJECT INVENTORY OBJECT
            player1.PlayerInventory.numLemons -= numLemonsUse;

            UserInterface.AskNumberToUse("sugar");
            int numSugarUse = Int32.Parse(Console.ReadLine());
            player1.PlayerInventory.cupsSugar -= numSugarUse;

            UserInterface.AskNumberToUse("ice");
            int numIceUse = Int32.Parse(Console.ReadLine());
            player1.PlayerInventory.poundsIce -= numIceUse;

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
