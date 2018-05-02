using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lemonade_Stand_1
{
    class Weather
    {
        int temperature;
        bool isSunny;
        bool isOvercast;
        bool isRaining;

        public Weather(int temperature, bool isSunny, bool isOvercast, bool isRaining)
        {
            this.temperature = temperature;
            this.isSunny = isSunny;
            this.isOvercast = isOvercast;
            this.isRaining = isRaining;
        }
    }
}
