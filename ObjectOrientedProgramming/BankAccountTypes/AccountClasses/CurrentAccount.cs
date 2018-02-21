using System;

namespace BankAccountTypes
{
    class CurrentAccount: SavingsAccount
    {
        public CurrentAccount(string aN, Customer cust, double bal) : base(aN, cust, bal) {}

        public override double Interest
        {
            get
            {
                return 0.0025;
            }
        }

        public override string ToString()
        {
            return String.Format(String.Format("CurrentAccount({0}, {1}, {2:C})", AccNo, AccHolderName, Bal));
        }
    }
}
