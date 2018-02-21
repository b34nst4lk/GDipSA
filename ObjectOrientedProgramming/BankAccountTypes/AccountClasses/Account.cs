﻿using System;

namespace BankAccountTypes
{
    class Account
    {
        protected string accNumber;
        protected string accHolderName;
        protected double balance;
        protected static double interest = 0.01;
        protected double interestAmt;

        public Account() { } 

        public Account(string aN, string aHN, double bal)
        {
            accNumber = aN;
            accHolderName = aHN;
            Deposit(bal);
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

        public virtual double Interest
        {
            get
            {
                return interest;
            }
        }

        public double InterestAmt
        {
            get
            {
                CalculateInterest();
                return interestAmt;
            }
        }

        public override string ToString()
        {
            return String.Format("Account({0}, {1}, {2:C})", accNumber, accHolderName, balance);
        }

        public void Withdraw(double amt)
        {
            balance -= Math.Max(amt, 0);
        }

        public void Deposit(double amt)
        {
            balance += Math.Max(amt, 0);
        }

        public void TransferTo(double amt, Account target)
        {
            Withdraw(amt);
            target.Deposit(amt);
        }

        public virtual void CalculateInterest()
        {
            interestAmt = Interest * balance;
        }

        public void CreditInterest()
        {
            CalculateInterest();
            balance += interestAmt;
        }
    }
}