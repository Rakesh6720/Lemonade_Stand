using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lemonade_Stand_1
{
    public static class UserInterface
    {
        public static void DisplayPrices()
        {
            Cup cup = new Cup();
            Lemon lemon = new Lemon();
            Sugar sugar = new Sugar();
            Ice ice = new Ice();

            Console.WriteLine("The prices of each item are:\nCups -- " + cup.Price + "\nLemons -- " + lemon.Price + "\nSugar -- " + sugar.Price + " per cup\nIce -- " + ice.Price + " per pound");
        }

        public static void AskToBuy(string item)
        {
            if (item == "sugar")
            {
                Console.WriteLine("How many cups of {0} would you like to buy (4 cups per pound)?", item);
            }
            else if (item == "ice")
            {
                Console.WriteLine("How many pounds of {0} would you like to buy?", item);
            }
            else
            { 
            Console.WriteLine("How many {0} would you like to buy?", item);
            }
        }
    }
}
