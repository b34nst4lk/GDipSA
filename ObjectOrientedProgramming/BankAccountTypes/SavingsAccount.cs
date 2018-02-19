using System;

namespace BankAccountTypes
{
    class SavingsAccount : Account
    {
        public SavingsAccount(string aN, string aHN, double bal) : base(aN, aHN, bal)
        {
            {
                Deposit(bal);
            }
        }

        public new string ToString()
        {
            return String.Format(String.Format("SavingsAccount({0}, {1}, {2:C})", accNumber, accHolderName, balance));
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
