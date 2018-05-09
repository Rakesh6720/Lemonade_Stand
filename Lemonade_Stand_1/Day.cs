using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lemonade_Stand_1
{
    [Serializable]
    public class Day
    {
        Weather weather;
        List<Customer> customers;
     
        public Day()
        {
            this.weather = new Weather();

            this.customers = CreateCustomerList();

        }

        public Weather Weather
        {
            get
            {
                return weather;
            }
            set
            {
                weather = value;
            }
        }

        public List<Customer>Customers
        {
            get
            {
                return customers;
            }
            set
            {
                customers = value;
            }
        }

        public List<Customer> CreateCustomerList()
        {
            List<Customer> customerList = new List<Customer>();
            Random random = new Random();
            int number;

            if (weather.Temperature >= 40 || weather.Temperature <= 60)
                {
                number = random.Next(1, 25);
            }
            else if(weather.Temperature >=61)
            {
                number = random.Next(25, 200);
            }
            else
            {
                number = random.Next(1, 25);
            }
            

            for (int i = 0; i < number; i++)
            {
                Customer customer = new Customer();
                customerList.Add(customer);
            }
            return customerList;
        }
    }
    
}
