using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lemonade_Stand_1
{
    class Cup : Supplies
    {
        double price;
        string name;
        
        public Cup(string name)
        {
            this.name = name;
            this.price = 0.15;
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
