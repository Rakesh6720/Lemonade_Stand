using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lemonade_Stand_1
{
    public class Lemon : Supplies
    {
        string name;
        double price;
        //int amount;
        int decayValue; 


        public Lemon()
        {
            this.name = "lemon";
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
