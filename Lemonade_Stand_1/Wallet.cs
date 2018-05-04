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

       public Wallet()
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

        public void Debit(Wallet wallet, double cost)
        {
            double result = wallet.Amount - cost;
            wallet.Amount = result;
        }
    }
}
