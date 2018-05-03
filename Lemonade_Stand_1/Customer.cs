using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lemonade_Stand_1
{
    public class Customer
    {
        bool willBuy;
        //double maxPrice;

        public Customer()
        {
            this.willBuy = false;
        }
        public bool WillBuy
        {
            get
            {
                return willBuy;
            }
            set
            {
                willBuy = value;
            }
        }

        public int CalculateBuyingCustomers(Day day, List<Customer> Customers, double lemonadePrice)
        {
            int numberOfBuyingCustomers = 0;
            foreach (Customer customer in Customers)
            {
                if (DetermineIfCustomerBuyWeather(day) == true && DetermineIfCustomerBuyPrice(day, lemonadePrice) == true)
                {
                    //customer.WillBuy = true;
                    numberOfBuyingCustomers++;
                    return numberOfBuyingCustomers;
                }
                else
                {
                    return numberOfBuyingCustomers;
                }
            }
            return numberOfBuyingCustomers;
        }

        public bool DetermineIfCustomerBuyPrice(Day day, double lemonadePrice)
        {
            int probabilityOfBuying;
            Random random = new Random();
            if (lemonadePrice >= 2.49 && lemonadePrice <= 4.99)
            {
                probabilityOfBuying = random.Next(1, 10) * 10 / 100;
                if (probabilityOfBuying > 39)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if (lemonadePrice >= 5 && lemonadePrice <= 7.50)
            {
                probabilityOfBuying = random.Next(1, 10) * 10 / 100;
                if (probabilityOfBuying > 79)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if (lemonadePrice < 2.49 && lemonadePrice >= .75)
            {
                probabilityOfBuying = random.Next(1, 10) * 10 / 100;
                if (probabilityOfBuying > 19)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if (lemonadePrice < .75)
            {
                probabilityOfBuying = random.Next(1, 10) * 10 / 100;
                if (probabilityOfBuying > 9)
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

        public bool DetermineIfCustomerBuyWeather(Day day)
        {
            if (day.Weather.Temperature > 80 && day.Weather.IsSunny == true && day.Weather.IsRaining == false)
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
            else if (day.Weather.Temperature > 80 && day.Weather.IsSunny == true && day.Weather.IsRaining == true)
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
            else if (day.Weather.Temperature < 80 && day.Weather.IsSunny == true && day.Weather.IsRaining == false)
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

        public int DetermineNumCupsWillBuy(List<Customer> customers)
        {
            if (customer.willBuy == true)
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
