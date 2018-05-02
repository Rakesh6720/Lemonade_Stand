using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lemonade_Stand_1
{
    public class Player
    {
        public Wallet playerWallet;
        public Inventory playerInventory;
        public string name;

        public Player(string name)
        {
            this.name = name;
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
