using System;

namespace BankAccountTypes
{
    abstract class Account
    {
        double balance;
        protected string accNumber;
        protected Customer cust;
        protected double interestAmt;
        protected BankBranch branch;

        public string AccNo
        {
            get
            {
                return accNumber;
            }
        }

        public Customer Cust
        {
            get
            {
                return cust;
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

        public BankBranch Branch
        {
            get
            {
                return branch;
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

        public virtual void Withdraw(double amt)
        {
            if (amt <= 0)
            {
                throw new MustBePositive("Withdrawals must be positive.");
            }
            else
            {
                balance -= amt;
            }
        }

        public virtual void Deposit(double amt)
        {
            if (amt <= 0)
            {
                throw new MustBePositive("Deposits must be positive.");
            }
            else
            {
                balance += Math.Max(amt, 0);
            }
        }

        public virtual void TransferTo(double amt, Account target)
        {
            try
            {
                Withdraw(amt);
                target.Deposit(amt);
            }
            catch (MustBePositive)
            {
                throw new MustBePositive("Transfer made must be positive");
            }

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

        public void ChangeCustomer(Customer cust)
        {
            this.cust = cust;
        }

        public void ChangeBranch(BankBranch branch)
        {
            this.branch = branch;
        }
    }
}