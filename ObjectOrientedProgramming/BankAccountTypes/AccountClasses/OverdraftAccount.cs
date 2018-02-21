using System;
using System.Linq;

namespace BankAccountTypes
{
    class OverdraftAccount: Account
    {
        protected static double negInterest = 0.06;
        protected new static double interest = 0.0025;

        public OverdraftAccount(string aN, string aHN, double bal)
        {
            accNumber = aN;
            accHolderName = aHN;
            balance = bal;
        }

        public override string ToString()
        {
            return String.Format("OverdraftAccount({0}, {1}, {2:C})", accNumber, accHolderName, balance);
        }

        public override double Interest
        {
            get
            {
                if (balance < 0)
                {
                    return negInterest;
                }
                else
                {
                    return interest;
                }
            }
        }

        public override void CalculateInterest()
        {
            interestAmt = Interest * balance;
        }
    }
}