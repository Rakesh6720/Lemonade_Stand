using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lemonade_Stand_1
{
    public class Inventory
    {
        public Cup cup;
        public Lemon lemon;
        public Ice ice;
        public  Sugar sugar;


        public Inventory()
        {
            this.cup = new Cup();
            this.lemon = new Lemon();
            this.ice = new Ice();
            this.sugar = new Sugar();
        }

        
        
    }
}


