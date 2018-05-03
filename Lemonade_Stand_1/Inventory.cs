using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lemonade_Stand_1
{
    public class Inventory
    {


        public Inventory()
        {
            Cup cup = new Cup("cup");
            Lemon lemon = new Lemon("lemon");
            Ice ice = new Ice("ice");
            Sugar sugar = new Sugar("sugar");
        }
    }
}


