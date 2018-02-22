using System;
using System.Collections.Generic;
using System.Linq;

namespace BankAccountTypes
{
    class BankBranch
    {
        string branchName;
        string branchId;
        string branchManager;
        HashSet<Account> accounts = new HashSet<Account>();

        public BankBranch(string branchName, string branchId, string branchManager)
        {
            this.branchName = branchName;
            this.branchId = branchId;
            this.branchManager = branchManager;
        }

        public string BranchName
        {
            get
            {
                return branchName;
            }
        }

        public string BranchId
        {
            get
            {
                return branchId;
            }
        }

        public string BranchManager
        {
            get
            {
                return branchManager;
            }
        }

        public HashSet<Account> Accounts
        {
            get
            {
                return accounts;
            }
        }

        public int AccountCount
        {
            get
            {
                return accounts.Count();
            }
        }

        public override string ToString()
        {
            return String.Format("BankBranch({0}, {1}, {2}, {3}", BranchId, BranchName, BranchManager, AccountCount);
        }

        public bool AddAccount(Account acc)
        {
            return accounts.Add(acc);
        }

        public bool RemoveAccount(Account acc)
        {
            return accounts.Remove(acc);
        }

        public bool IfAccountInBranch(Account acc)
        {
            return accounts.Contains(acc);
        }

        public HashSet<Customer> GetCustomers()
        {
            HashSet<Customer> customers = new HashSet<Customer>();
            foreach (Account acc in Accounts)
            {
                customers.Add(acc.Cust);
            }
            return customers;
        }

        public void PrintCustomers()
        {
            foreach (Customer cust in GetCustomers())
            {
                Console.WriteLine(cust.ToString());
            }
        }

        public double TotalDeposits()
        {
            double totalDeposits = 0;
            foreach (Account acc in Accounts)
            {
                if (acc.Bal > 0)
                {
                    totalDeposits += acc.Bal;
                }
            }

            return totalDeposits;
        }

        public double TotalLoans()
        {
            double totalLoans = 0;
            foreach (Account acc in Accounts)
            {
                if (acc.Bal < 0)
                {
                    totalLoans += acc.Bal;
                }
            }

            return totalLoans;
        }

        public double TotalBalance()
        {
            double totalBalance = 0;
            foreach (Account acc in Accounts)
            {
                totalBalance += acc.Bal;
            }
            return totalBalance;
        }

        public double TotalInterestPaid()
        {
            double totalInterestPaid = 0;
            foreach (Account acc in Accounts)
            {
                if (acc.Bal > 0)
                {
                    totalInterestPaid += acc.InterestAmt;
                }
            }
            return totalInterestPaid;
        }

        public double TotalInterestEarned()
        {
            double totalInterestEarned = 0;
            foreach (Account acc in Accounts)
            {
                if (acc.Bal < 0)
                {
                    totalInterestEarned += Math.Abs(acc.InterestAmt);
                }
            }
            return totalInterestEarned;
        }
    }
}
