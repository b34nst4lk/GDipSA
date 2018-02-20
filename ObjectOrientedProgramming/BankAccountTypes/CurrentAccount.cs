using System;

namespace BankAccountTypes
{
    class CurrentAccount: SavingsAccount
    {
        protected new static double interest = 0.0025;

        public CurrentAccount(string aN, string aHN, double bal) : base(aN, aHN, bal) {}

        public override double Interest
        {
            get
            {
                return interest;
            }
        }
          
        public new double InterestAmt
        {
            get
            {
                CalculateInterest();
                return interestAmt;
            }
        }

        public override string ToString()
        {
            return String.Format(String.Format("CurrentAccount({0}, {1}, {2:C})", accNumber, accHolderName, balance));
        }

        public override void CalculateInterest()
        {
            interestAmt = Interest * balance;
        }
    }
}
