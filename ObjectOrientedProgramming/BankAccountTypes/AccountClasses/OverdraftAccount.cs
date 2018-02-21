using System;
using System.Linq;

namespace BankAccountTypes
{
    class OverdraftAccount: Account
    {
        double posInt = 0.0025;
        double negInt = 0.06;
        
        public OverdraftAccount(string aN, string aHN, double bal)
        {
            accNumber = aN;
            accHolderName = aHN;
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
            return String.Format("OverdraftAccount({0}, {1}, {2:C})", accNumber, accHolderName, Bal);
        }
    }
}