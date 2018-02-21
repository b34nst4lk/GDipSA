using System;

namespace BankAccountTypes
{
    class SavingsAccount : Account
    {
        public SavingsAccount(string aN, Customer cust, double bal)
        {
            accNumber = aN;
            this.cust = cust;
            Deposit(bal);
        }

        public override double Interest
        {
            get
            {
                return 0.01;
            }
        }


        public override string ToString()
        {
            return String.Format(String.Format("SavingsAccount({0}, {1}, {2:C})", AccNo, AccHolderName, Bal));
        }

        public new bool Withdraw(double amt)
        {
            if (amt > Bal)
            {
                Console.WriteLine("There is insufficient funds in your account");
                return false;
            }
            else
            {
                base.Withdraw(amt);
                return true;
            }
        }

        public new void TransferTo(double amt, Account targetAcc)
        {
            if (Withdraw(amt))
            {
                targetAcc.Deposit(amt);
            }
        }
    }
}
