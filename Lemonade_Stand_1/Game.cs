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
        Store store1;

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
                player1 = new Player(playerWallet, playerInventory, userName);
            }
            else
            {
                Console.WriteLine("Haven't created multiplayer function yet");
            }
        }

        public void RunGame()
        { 
            //.  Instantiate a DAY object
            Day day1 = new Day();


            //4.  Give the player the forecast for the current day.
            Weather weatherDay1 = new Weather(80, true, false, false, false);

            //.  INSTANTIATE a STORE object that has an inventory object of supplies
            Inventory newStoreInventory = new Inventory(0, 0, 0, 0);
            store1 = new Store(newStoreInventory);

            //5.  Take the plalyer to the STORE.  
            //6.  Display to the player how much eat item costs.
            Console.WriteLine("The prices of each item are:\nCups -- 0.15\nLemons -- 0.25\nSugar -- 0.15 per cup\nIce -- .10 per pound");
            //7.  Ask the player how many of each item they would like to buy.
            Console.WriteLine("How many cups would you like to buy?");
            string numCupsString = Console.ReadLine();
            int numCups = Int32.Parse(numCupsString);
            Console.WriteLine("How many lemon would you like to buy?");
            string numLemonsString = Console.ReadLine();
            int numLemons = Int32.Parse(numLemonsString);
            Console.WriteLine("How many cups of sugar would you like to buy (4 cups per pound)?");
            string numSugarString = Console.ReadLine();
            int numSugar = Int32.Parse(numSugarString);
            Console.WriteLine("How many pounds of ice would you like to buy?");
            string numIceString = Console.ReadLine();
            int numIce = Int32.Parse(numIceString);
            //8.  Tally the total amount owed by the Player to the Store.
            double totalPriceCups = numCups * 0.15;
            double totalPriceLemons = numLemons * .25;
            double totalPriceSugar = numSugar * .15;
            double totalPriceIce = numIce * .10;
            double totalCheckoutPrice = totalPriceCups + totalPriceLemons + totalPriceSugar + totalPriceIce;
            //9.  Subtract the total amount owed from the Player Wallet.
            player1.playerwallet = player1.playerwallet - totalCheckoutPrice;
            //10.  MOVE the items FROM the STORE INVENTORY OBJECT to the PLAYER INVENTORY OBJECT

            //.  INSTANTIATE a STAND object as a VARIABLE of the PLAYER CLASS
            //10.  Ask the PLAYER OBJECT how many PITCHERS of lemonade she would like to make for THE DAY OBJECT
            //      -- AND ask the Player Object how many items of EACH SUPPLY she would like to use FROM HER INVENTORY
            //      -- Subtract the number of cups, lemons, sugar, and ice from the PLAYER OBJECT INVENTORY OBJECT
            //      -- 
            //11.  INSTANTIATE a CUSTOMER object from the CUSTOMER CLASS.
            //      -- does the customer have a wallet object, too?
            //      -- if the customer does have a wallet object then how much is inside of it?
            //      -- what is the upper limit of how many cups of lemonade a customer can buy?
            //12.  Call a method from the CUSTOMER CLASS that take into account the PRESENT WEATHER to inform her DECISION to BUY lemonade FROM STAND object
            //13.  Tally the Total Amount of money earned by the STAND object's WALLET object.  
            //14.   Add / Subtract the Stand Object's Wallet Object's contents to the Player Object's Wallet Object
            //15.  Move the cups, sugar, and lemons FROM the STORE INVENTORY OBJECT to the PLAYER INVENTORY OBJECT
        }
    }
}
