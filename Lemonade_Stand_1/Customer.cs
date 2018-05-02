using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lemonade_Stand_1
{
    public class Customer
    {
        public bool willBuy;

        public Customer(bool willBuy)
        {
            this.willBuy = willBuy;
        }

        public bool DetermineIfCustomerBuy()
        {
            Random random = new Random();
            int randomNum = random.Next(1, 11);
            if (randomNum % 2 == 0)
            {
                this.willBuy = true;
            }
            else
            {
                this.willBuy = false;
            }
            return this.willBuy;
        }

        public int DetermineNumCupsWillBuy(bool willBuy)
        {
            if (willBuy == true)
            {
                Random random = new Random();
                int numCupsBuy = random.Next(1, 5);
                return numCupsBuy;
            }
            else
            {
                int numCupsBuy = 0;
                return numCupsBuy;
            }

        }
    }
}
