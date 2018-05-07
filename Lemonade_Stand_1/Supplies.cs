using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lemonade_Stand_1
{
    public class Supplies
    {
        string name;
        double price;
        //int amount;

        public Supplies()
        {
            
        }

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
        public double Price
        {
            get
            {
                return price;
            }
            set
            {
                price = value;
            }
        }
        public List<Supplies> CreateInventory(int numCups, int numLemons, int poundsIce, int cupsSugar)
        {
            List<Supplies> suppliesList = new List<Supplies>();
            for (int i = 0; i < numCups; i++)
            {
                Cup cup = new Cup();
                suppliesList.Add(cup);
            }
            for (int i = 0; i < numLemons; i++)
            {
                Lemon lemon = new Lemon();
                suppliesList.Add(lemon);
            }
            for (int i = 0; i < poundsIce; i++)
            {
                Ice ice = new Ice();
                suppliesList.Add(ice);
            }
            for (int i = 0; i < cupsSugar; i++)
            {
                Sugar sugar = new Sugar();
                suppliesList.Add(sugar);
            }
            return suppliesList;
        }
    }
}
