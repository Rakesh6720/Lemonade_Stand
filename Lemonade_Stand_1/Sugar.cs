using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lemonade_Stand_1
{
    class Sugar : Supplies
    {
        string name;
        double price; //price per a cup?

        public Sugar(string name)
        {
            this.name = name;
            this.price = .25;
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
        
    }
}
