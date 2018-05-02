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
        bool isCloudy;
        bool isRaining;
        bool isWindy;

        public Weather(int temperature, bool isSunny, bool isCloudy, bool isRaining, bool isWindy)
        { 
            this.temperature = temperature;
            this.isSunny = isSunny;
            this.isCloudy = isCloudy;
            this.isRaining = isRaining;
            this.isWindy = isWindy;
        }
    }
}
