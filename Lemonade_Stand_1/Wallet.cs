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

        public void Debit(Player player, double walletAmount, double cost)
        {
            double result = walletAmount - cost;
            result = player.PlayerWallet.Amount;
        }
    }
}
