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
        Player player2;

        //member methods

        //1.  Ask the user how many players there will be.
        public int GetNumOfPlayers()
        {
            Console.WriteLine("Please enter the number of players: ");
            string userInput = Console.ReadLine();
            int numOfPlayers = Int32.Parse(userInput);
            return numOfPlayers;
        }

        public void CreatePlayers()
        {
            if (numOfPlayers == 1)
            {
                Console.WriteLine("Please enter the name of Player 1: ");
                string userName = Console.ReadLine();
                Wallet playerWallet = new Wallet(30);
                Inventory playerInventory = new Inventory(0, 0, 0, 0);
                Player player1 = new Player(playerWallet, playerInventory, userName);
            }
            else
            {
                Console.WriteLine("Haven't created multiplayer function yet)";
            }
        }
        //.  Assume it is one player for now.
        //.  Instantiate a DAY object
        //2.  Create player1.
        //3.  Give player1 a wallet object and an inventory object.
        //4.  Give the player the forecast for the current day.
        //.  INSTANTIATE a STORE object that has an inventory object of supplies
        //.  INSTANTIATE the Store Object's INVENTORY OBJECT
        //      -- give lemons, sugar, and ice a member variable that indicates decay in number of days
        //5.  Take the plalyer to the STORE.  
        //6.  Display to the player how much eat item costs.
        //7.  Ask the player how many of each item they would like to buy.
        //8.  Tally the total amount owed by the Player to the Store.
        //9.  Subtract the total amount owed from the Player Wallet.
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
