using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lemonade_Stand_1
{
    public class Ice : Supplies
    {
        int cost; // cost per pound
        int amount; //amount in pounds
        int decayValue = 1; //ice will only last one day
    }
}
