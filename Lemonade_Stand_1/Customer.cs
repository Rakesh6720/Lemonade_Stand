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

        public bool DetermineIfCustomerBuy(Weather weather)
        {
            if (weather.Temperature > 80 && weather.IsSunny = true && weather.IsRaining = false)
            {
                Random random = new Random();
                int result = random.Next(6, 10) / 10 * 100;
                if (result > 70)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            else if (weather.Temperature > 80 && weather.IsSunny = true && weather.IsRaining = true)
            {
                Random random = new Random();
                int result = random.Next(2, 7) / 10 * 100;
                if (result > 40)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if (weather.Temperature<80 && weather.IsSunny = true && weather.IsRaining = false)
            {
                Random random = new Random();
                int result = random.Next(1, 8) / 10 * 100;
                if (result > 50)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        //    Random random = new Random();
        //    int randomNum = random.Next(1, 11);
        //    if (randomNum % 2 == 0)
        //    {
        //        this.willBuy = true;
        //    }
        //    else
        //    {
        //        this.willBuy = false;
        //    }
        //    return this.willBuy;
        //}

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
