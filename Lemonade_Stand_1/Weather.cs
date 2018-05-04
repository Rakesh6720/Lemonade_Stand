using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lemonade_Stand_1
{
    public class Weather
    {
        int temperature;
        bool isSunny;
        bool isRaining;

        public Weather()
        {
            Random random = new Random();
            this.temperature = random.Next(-23, 120);
            if (random.Next(1, 101) % 2 == 0)
            {
                this.isSunny = true;
            }
            if (random.Next(1, 101) % 5 == 0)
            {
                this.isRaining = true;
            }
        }

        public int Temperature
        {
            get
            {
                return temperature;
            }
            set
            {
                temperature = value;
            }
        }

        public bool IsSunny
        {
            get
            {
                return isSunny;
            }
            set
            {
                isSunny = value;
            }
        }

        public bool IsRaining
        {
            get
            {
                return isRaining;
            }
            set
            {
                isRaining = value;
            }
        }
    }
}
