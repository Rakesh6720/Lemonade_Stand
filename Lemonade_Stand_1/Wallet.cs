using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lemonade_Stand_1
{
    public class Wallet
    {
        double amount;

       public Wallet(double amount)
        {
            this.amount = 30.0;
        }

        public double Amount
        {
            get
            {
                return amount;
            }
            set
            {
                amount = value;
            }
        }

        public double Debit(double walletAmount, double cost)
        {
            double result = walletAmount - cost;
            return result;
        }
    }
}
