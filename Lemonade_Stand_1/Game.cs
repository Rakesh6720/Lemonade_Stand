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
            Console.WriteLine("Please enter the number of players: ");
            string userInput = Console.ReadLine();
            int numOfPlayers = Int32.Parse(userInput);
            return numOfPlayers;
        }

        //.  Assume it is one player for now.
        public void CreatePlayers(int numOfPlayers)
        {
            if (numOfPlayers == 1)
            {
                Console.WriteLine("Please enter the name of Player 1: ");
                string userName = Console.ReadLine();
                //create player wallet and player inventory objects
                Wallet playerWallet = new Wallet(0);
                Inventory playerInventory = new Inventory(0, 0, 0, 0);
                //2.  Create player1 and pass into player1 object the instance of playerWallet and playerInventory
                player1 = new Player(userName);
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
            Weather weatherDay1 = new Weather(80, true, false);
            

            //.  INSTANTIATE a STORE object that has an inventory object of supplies
            Inventory newStoreInventory = new Inventory(0, 0, 0, 0);
            Store store1 = new Store(newStoreInventory);

            //5.  Take the plalyer to the STORE.  
            //6.  Display to the player how much eat item costs.
            UserInterface.DisplayPrices();

            //7.  Ask the player how many of each item they would like to buy.
            UserInterface.AskToBuy("cups");
            string numCupsString = Console.ReadLine();
            int numCups = Int32.Parse(numCupsString);

            UserInterface.AskToBuy("lemons"); 
            string numLemonsString = Console.ReadLine();
            int numLemons = Int32.Parse(numLemonsString);

            UserInterface.AskToBuy("sugar");
            
            string cupsSugarString = Console.ReadLine();
            int cupsSugar = Int32.Parse(cupsSugarString);

            UserInterface.AskToBuy("ice");
            
            string numIceString = Console.ReadLine();
            int numIce = Int32.Parse(numIceString);

            //8.  Tally the total amount owed by the Player to the Store.
            double totalCheckOutPrice = store1.Checkout(numCups, numLemons, cupsSugar, numIce);

            //DISPLAY total check out price
            UserInterface.DisplayCheckoutPrice(totalCheckOutPrice);

            //9.  Subtract the total amount owed from the Player Wallet.  
            player1.playerWallet.Debit(player1.playerWallet.Amount, totalCheckOutPrice);

            //DISPLAY the player's wallet status
            UserInterface.DisplayPlayerWalletStatus(player1);
            
            //10.  MOVE the items FROM the STORE INVENTORY OBJECT to the PLAYER INVENTORY OBJECT
            //create player method that updates player inventory
            player1.UpdatePlayerInventory(numCups, numLemons, cupsSugar, numIce);

            //.  INSTANTIATE a STAND object and CREATE its own INVENTORY object
            Inventory standInventory = new Inventory(numCups, numLemons, numIce, cupsSugar);
            Stand stand = new Stand(standInventory, 0);

            //10.  Ask the PLAYER OBJECT how many GALLONS (16 cups of lemonade in one gallon) of lemonade she would like to make for THE STAND OBJECT
            UserInterface.AskNumberGallons();
            string standGallons = Console.ReadLine();
            stand.gallons = Int32.Parse(standGallons);

            //-- AND ask the Player Object how many items of EACH SUPPLY she would like to use FROM HER INVENTORY
            UserInterface.AskNumberToUse("lemons");
            int numLemonsUse = Int32.Parse(Console.ReadLine());

            //-- Subtract the number of cups, lemons, sugar, and ice from the PLAYER OBJECT INVENTORY OBJECT
            player1.playerInventory.numLemons -= numLemonsUse;

            UserInterface.AskNumberToUse("sugar");
            int numSugarUse = Int32.Parse(Console.ReadLine());
            player1.playerInventory.cupsSugar -= numSugarUse;

            UserInterface.AskNumberToUse("ice");
            int numIceUse = Int32.Parse(Console.ReadLine());
            player1.playerInventory.poundsIce -= numIceUse;

            //ask the player to set the price of each cup of lemonade
            UserInterface.AskForLemonadePrice();
            double priceLemonade = Int32.Parse(Console.ReadLine());

            //11.  INSTANTIATE a CUSTOMER object from the CUSTOMER CLASS.
            //  determine the number of CUSTOMER OBJECTS to INSTANTIATE based on PRICE and WEATHER
            Customer customer1 = new Customer(false);
            //      -- what is the likelihood that a customer will buy?  true/false = willBuy
            bool willBuy = customer1.DetermineIfCustomerBuy();
            int numCupsBought = customer1.DetermineNumCupsWillBuy(willBuy);
            //      -- how will the weather affect the customer's decision to buy?
            //      -- how will the price of the lemonade impact the customer's decision to buy?
            //      -- how will the taste of the lemonade impact the customer's decision to buy?
            //12.  Call a method from the CUSTOMER CLASS that take into account the PRESENT WEATHER to inform her DECISION to BUY lemonade FROM STAND object
            //13.  Tally the Total Amount of money earned by the STAND object's WALLET object.  
            double amountEarned = priceLemonade * numCupsBought;
            Console.WriteLine($"You sold {numCupsBought} cups of lemonade today for a profit of ${amountEarned}");
            player1.playerWallet.Amount = player1.playerWallet.Amount + amountEarned;
            Console.WriteLine($"You have {player1.playerWallet.Amount} in your treasury.");
            //14.   Add / Subtract the Stand Object's Wallet Object's contents to the Player Object's Wallet Object
            //15.  Move the cups, sugar, and lemons FROM the STORE INVENTORY OBJECT to the PLAYER INVENTORY OBJECT
        }
    }
}
