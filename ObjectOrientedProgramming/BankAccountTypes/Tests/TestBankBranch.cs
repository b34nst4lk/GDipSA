using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace BankAccountTypes.Tests
{
    [TestFixture]
    class TestBankBranch
    {
        BankBranch branch;

        Customer sC;

        SavingsAccount sAcc, sAcc2;
        OverdraftAccount oAcc, oAcc2;

        [SetUp]
        public void SetUp()
        {
            branch = new BankBranch("Jurong West", "JW-001", "Lim");

            sC = new Customer("01", "Yeo", new DateTime(1987, 5, 6));

            sAcc = new SavingsAccount("001", sC, 2000);
            sAcc2 = new SavingsAccount("002", sC, 2000);
            oAcc = new OverdraftAccount("002", sC, -1000);
            oAcc2= new OverdraftAccount("002", sC, -2000);
        }

        [TearDown]
        public void TearDown()
        {
            branch = null;

            sC = null;

            sAcc = null;
            sAcc2 = null;
        }

        // Constructors
        [TestCase]
        public void TestBranchNameConstructor()
        {
            Assert.AreEqual("Jurong West", branch.BranchName);
        }

        [TestCase]
        public void TestBranchIdConstructor()
        {
            Assert.AreEqual("JW-001", branch.BranchId);
        }

        [TestCase]
        public void TestBranchManagerConstructor()
        {
            Assert.AreEqual("Lim", branch.BranchManager);
        }

        [TestCase]
        public void TestAccountsCountConstructor()
        {
            Assert.AreEqual(0, branch.AccountCount);
        }

        [TestCase]
        public void TestAccountsConstructor()
        {
            Assert.IsInstanceOf<HashSet<Account>>(branch.Accounts);
        }

        // ToString
        [TestCase]
        public void TestToString()
        {
            string correctString = String.Format("BankBranch({0}, {1}, {2}, {3}"
                , branch.BranchId, branch.BranchName, branch.BranchManager, branch.AccountCount);

            Assert.AreEqual(correctString, branch.ToString());
        }

        // AddAccount
        [TestCase]
        public void TestReturnTrueIfAccountAdded()
        {
            bool rv = branch.AddAccount(sAcc);

            Assert.IsTrue(rv);
        }
        
        [TestCase]
        public void TestAccountInBankBranchAfterAdding()
        {
            branch.AddAccount(sAcc);

            Assert.IsTrue(branch.Accounts.Contains(sAcc));
        }

        [TestCase]
        public void TestThatAccountAssignedToBranchAfterAdding()
        {
            branch.AddAccount(sAcc);

            Assert.AreEqual(branch, sAcc.Branch);
        }

        [TestCase]
        public void TestReturnFalseIfAccountAlreadyAdded()
        {
            branch.AddAccount(sAcc);
            bool rv = branch.AddAccount(sAcc);

            Assert.IsFalse(rv);
        }

        [TestCase]
        public void TestAccountInBankBranchAfterDoublyAdded()
        {
            branch.AddAccount(sAcc);
            branch.AddAccount(sAcc);

            Assert.IsTrue(branch.Accounts.Contains(sAcc));
        }

        // RemoveAccount
        [TestCase]
        public void TestReturnTrueIfAccountRemoved()
        {
            branch.AddAccount(sAcc);
            bool rv = branch.RemoveAccount(sAcc);

            Assert.IsTrue(rv);
        }

        [TestCase]
        public void TestAccountNotInBranchAfterRemoval()
        {
            branch.AddAccount(sAcc);
            branch.RemoveAccount(sAcc);

            Assert.IsFalse(branch.Accounts.Contains(sAcc));
        }

        [TestCase]
        public void TestReturnFalseAtRemoveAccoountIfNotInBranch()
        {
            bool rv = branch.RemoveAccount(sAcc);

            Assert.IsFalse(rv);
        }

        [TestCase]
        public void TestAccountStillNotInBranchAfterRemoval()
        {
            branch.RemoveAccount(sAcc);

            Assert.IsFalse(branch.Accounts.Contains(sAcc));
        }

        // IfAccountInBranch
        [TestCase]
        public void TestReturnTrueIfAccountInBranch()
        {
            branch.AddAccount(sAcc);

            Assert.IsTrue(branch.IfAccountInBranch(sAcc));
        }

        [TestCase]
        public void TestReturnFalseIfAccountNotInBranch()
        {
            Assert.IsFalse(branch.IfAccountInBranch(sAcc));
        }

        // GetCustomers
        [TestCase]
        public void TestCustomerReturned()
        {
            branch.AddAccount(sAcc);

            HashSet<Customer> customers = branch.GetCustomers();

            Assert.IsTrue(customers.Contains(sC));
        }

        [TestCase]
        public void TestCustomerIsUniqueInList()
        {
            branch.AddAccount(sAcc);
            branch.AddAccount(sAcc2);
            int count = 0;

            HashSet<Customer> customers = branch.GetCustomers();

            foreach (Customer customer in customers)
            {
                if (customer == sC)
                {
                    count++;
                }
            }

            Assert.AreEqual(1, count);           
        }

        // TotalDeposits
        [TestCase]
        public void TestTotalDepositsSumsUpCorrectly()
        {
            branch.AddAccount(sAcc);
            branch.AddAccount(sAcc2);
            branch.AddAccount(oAcc);
            branch.AddAccount(oAcc2);
            double correctSum = sAcc.Bal + sAcc2.Bal;

            double totalDeposits = branch.TotalDeposits();

            Assert.AreEqual(correctSum, totalDeposits);
        }

        // TotalLoans
        [TestCase]
        public void TestTotalLoansSumUpCorrectly()
        {
            branch.AddAccount(sAcc);
            branch.AddAccount(sAcc2);
            branch.AddAccount(oAcc);
            branch.AddAccount(oAcc2);
            double correctSum = oAcc.Bal + oAcc2.Bal;

            double totalLoans = branch.TotalLoans();

            Assert.AreEqual(correctSum, totalLoans);
        }

        // TotalBalance
        [TestCase]
        public void TestTotalBalanceSumUpCorrectly()
        {
            branch.AddAccount(sAcc);
            branch.AddAccount(sAcc2);
            branch.AddAccount(oAcc);
            branch.AddAccount(oAcc2);
            double correctSum = sAcc.Bal + sAcc2.Bal + oAcc.Bal + oAcc2.Bal;

            double totalBalance = branch.TotalBalance();

            Assert.AreEqual(correctSum, totalBalance);
        }

        [TestCase]
        public void TestTotalInterestPaidSumUpCorrectly()
        {
            branch.AddAccount(sAcc);
            branch.AddAccount(sAcc2);
            branch.AddAccount(oAcc);
            branch.AddAccount(oAcc2);
            double correctSum = sAcc.InterestAmt + sAcc2.InterestAmt;

            double totalBalance = branch.TotalInterestPaid();

            Assert.AreEqual(correctSum, totalBalance);
        }

        [TestCase]
        public void TestTotalInterestEarnedSumUpCorrectly()
        {
            branch.AddAccount(sAcc);
            branch.AddAccount(sAcc2);
            branch.AddAccount(oAcc);
            branch.AddAccount(oAcc2);
            double correctSum = Math.Abs(oAcc.InterestAmt + oAcc2.InterestAmt);

            double totalBalance = branch.TotalInterestEarned();

            Assert.AreEqual(correctSum, totalBalance);
        }
    }
}
