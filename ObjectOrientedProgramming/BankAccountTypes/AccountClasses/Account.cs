﻿using System;

namespace BankAccountTypes
{
    abstract class Account
    {
        double balance;
        protected string accNumber;
        protected Customer cust;
        protected double interestAmt;

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
                return cust.Name;
            }
        }

        public double Bal
        {
            get
            {
                return balance;
            }
        }

        public abstract double Interest { get; }

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
            return String.Format("Account({0}, {1}, {2:C})", AccNo, AccHolderName, Bal);
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

        public void CalculateInterest()
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