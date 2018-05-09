using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lemonade_Stand_1
{
    [Serializable]
    public class Player
    {
        Wallet playerWallet;
        List<Supplies> playerInventory;
        public string name;

        public Player(string name, Wallet playerWallet)
        {
            this.name = name;
            this.playerWallet = playerWallet;
            
        }

        public List<Supplies> PlayerInventory
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
           
        }

        public void RemoveFromInventory(int numItems, string itemName)
        {
            int itemsRemoved = 0;
            for (int i = 0; i <= numItems; i++)
            {
                foreach (Supplies item in playerInventory)
                {
                    if (itemName == item.Name)
                    {
                        playerInventory.Remove(item);
                        itemsRemoved++;
                    }
                }
            }
        }
    }
}
