using System;
using System.Linq;

namespace BankAccountTypes
{
    class OverdraftAccount: Account
    {
        double posInt = 0.0025;
        double negInt = 0.06;
        
        public OverdraftAccount(string aN, Customer cust, double bal)
        {
            accNumber = aN;
            this.cust = cust;
            if (bal > 0)
            {
                Deposit(bal);
            }
            else
            {
                Withdraw(Math.Abs(bal));
            }
        }

        public override double Interest
        {
            get
            {
                if (Bal > 0)
                {
                    return posInt;
                }
                else
                {
                    return negInt;
                }
                
            }
        }

        public override string ToString()
        {
            return String.Format("OverdraftAccount({0}, {1}, {2:C})", AccNo, AccHolderName, Bal);
        }
    }
}