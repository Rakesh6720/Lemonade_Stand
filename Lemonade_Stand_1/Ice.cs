using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lemonade_Stand_1
{
    class Ice : Supplies
    {
        string name;
        double price;
        int decayValue;

        public Ice(string name)
        {
            this.name = name;
            this.price = 0.10; // cost per pound
            this.decayValue = 1; //ice will only last one day
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

        public int DecayValue
        {
            get
            {
                return decayValue;
            }
            set
            {
                decayValue = value;
            }
        }
    }
}
