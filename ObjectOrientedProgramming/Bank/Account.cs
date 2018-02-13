using System;

namespace Bank
{
    class Account
    {
        private string accountNumber;
        private Customer accountCust;
        private double balance;

        public Account(string aN, Customer aHN, double bal)
        {
            accountNumber = aN;
            accountCust = aHN;
            balance = bal;
        }

        public string Show()
        {
            return String.Format("{0}\t{1}\t{2:C}", accountNumber, accountCust.Show(), balance);
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
