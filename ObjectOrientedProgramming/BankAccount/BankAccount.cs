using System;

namespace BankAccount
{
    class Account
    {
        private string accountNumber;
        private string accountHolderName;
        private double balance;

        public Account(string aN, string aHN, double bal)
        {
            accountNumber = aN;
            accountHolderName = aHN;
            balance = bal;
        }

        public string Show()
        {
            return String.Format("{0}\t{1}\t{2:C}", accountNumber, accountHolderName, balance);
        }

        public void Withdraw(double amt)
        {
            balance -= amt;
        }

        public void Deposit(double amt)
        {
            balance += amt;
        }

        public void TransferTo(double amt, Account target)
        {
            Withdraw(amt);
            target.Deposit(amt);
        }
    }
}
