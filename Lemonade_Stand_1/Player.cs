using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lemonade_Stand_1
{
    public class Player
    {
        Wallet playerWallet;
        Inventory playerInventory;
        public string name;

        public Player(string name, Wallet playerWallet, Inventory playerInventory)
        {
            this.name = name;
            this.playerWallet = playerWallet;
            this.playerInventory = playerInventory;
        }

        public Inventory PlayerInventory
        {
            get
            {
                return playerInventory;
            }
            set
            {
                playerInventory = value;
            }
        }

        public Wallet PlayerWallet
        {
            get
            {
                return playerWallet;
            }
            set
            {
                playerWallet = value;
            }
        }

        public void UpdatePlayerInventory(int numCups, int numLemons, int cupsSugar, int numIce)
        {
            playerInventory.numCups = numCups;
            playerInventory.numLemons = numLemons;
            playerInventory.cupsSugar = cupsSugar;
            playerInventory.poundsIce = numIce;
        }
    }
}
