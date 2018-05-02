using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lemonade_Stand_1
{
    class Lemon : Fruits
    {
        double price;
        //int amount;
        int decayValue; 


        public Lemon()
        {
            this.price = 0.25;
            this.decayValue = 3; //this indicates that lemons spoil after 3 days
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
