using System;

namespace BankAccountTypes
{
    class SavingsAccount : Account
    {
        public SavingsAccount(string aN, Customer cust, double bal)
        {
            accNumber = aN;
            Deposit(bal);
            ChangeCustomer(cust);
            cust.AddAccount(this);
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

        public override void Withdraw(double amt)
        {
            if (amt > Bal)
            {
                throw new InsufficientFunds("Withdrawing more funds than available in balance");
            }
            else
            {
                base.Withdraw(amt);
            }
        }

        public override void TransferTo(double amt, Account targetAcc)
        {
            try
            {
                Withdraw(amt);
                targetAcc.Deposit(amt);
            }
            catch (InsufficientFunds)
            {
                throw new InsufficientFunds("Transfer failed due to insufficient funds");
            }
        }
    }
}
