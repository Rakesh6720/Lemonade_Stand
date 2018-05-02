using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lemonade_Stand_1
{
    public class Player
    {
        Wallet wallet;
        Inventory inventory;
        string name;

        public Player(Wallet playerWallet, Inventory playerInventory, string playerName)
        {
            this.wallet = playerWallet;
            this.inventory = playerInventory;
            this.name = playerName;

        }
    }
}
