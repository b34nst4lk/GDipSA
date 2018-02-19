using System;

namespace BankAccountTypes
{
    class Account
    {
        protected string accNumber;
        protected string accHolderName;
        protected double balance;
        protected double interestAmt;

        public Account(string aN, string aHN, double bal)
        {
            accNumber = aN;
            accHolderName = aHN;
            balance = bal;
        }

        public string AccNo
        {
            get
            {
                return accNumber;
            }
        }

        public string AccHolderName
        {
            get
            {
                return accHolderName;
            }
        }

        public double Bal
        {
            get
            {
                return balance;
            }
        }

        public double InterestAmt
        {
            get
            {
                return interestAmt;
            }
        }

        public new string ToString()
        {
            return String.Format("{0}\t{1}\t{2:C}", accNumber, accHolderName, balance);
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

        public void CalculateInterest(double interest)
        {
            interestAmt = interest * balance;
        }

        public void CreditInterest(double interest)
        {
            CalculateInterest(interest);
            balance += interestAmt;
        }
    }
}