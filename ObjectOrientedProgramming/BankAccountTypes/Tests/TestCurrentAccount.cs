using System;
using NUnit.Framework;

namespace BankAccountTypes
{
    [TestFixture]
    class TestCurrentAccount
    {
        CurrentAccount acc;
        CurrentAccount targetAcc;

        Customer c;
        Customer c2;

        BankBranch branch;

        Random r = new Random();

        [SetUp]
        public void SetUp()
        {
            c = new Customer("1", "Tan", new DateTime(1996, 1, 1));
            c2 = new Customer("1", "Lim", new DateTime(1996, 1, 1));
            acc = new CurrentAccount("000-001", c, 2000);
            targetAcc = new CurrentAccount("000-002", c2, 3000);
            branch = new BankBranch("JE", "012", "Teo");
        }

        [TearDown]
        public void TearDown()
        {
            acc = null;
            targetAcc = null;
        }

        //Constructor
        [TestCase]
        public void TestAccountHolderNameConstructor()
        {
            Assert.AreEqual(c.Name, acc.AccHolderName);
        }

        [TestCase]
        public void TestAccountNoConstructor()
        {
            Assert.AreEqual("000-001", acc.AccNo);
        }

        [TestCase]
        public void TestAccountBalanceConstructor()
        {
            Assert.IsNull(acc.Branch);
        }

        //Interest
        [TestCase]
        public void TestThatInterestRateIsCorrect()
        {
            Assert.AreEqual(0.0025, acc.Interest);
        }

        //ToString()
        [TestCase]
        public void TestTheReturnValueOfToString()
        {
            string correctString = String.Format("CurrentAccount({0}, {1}, {2:C})", acc.AccNo, acc.AccHolderName, acc.Bal);

            Assert.AreEqual(acc.ToString(), correctString);
        }

        // Withdraw()
        [TestCase]
        public void TestForSuccessfulWithdrawWhenAmtLessThanBalance()
        {
            double withdrawAmt = acc.Bal - 1;
            double correctBalance = acc.Bal - withdrawAmt;

            acc.Withdraw(withdrawAmt);

            Assert.AreEqual(correctBalance, acc.Bal);
        }

        [TestCase]
        public void TestForInsufficientFundsThrownWithdrawalWhenAmtMoreThanBalance()
        {
            double withdrawAmt = acc.Bal + 1;
            double correctBalance = acc.Bal;

            Assert.Throws<InsufficientFunds>(() => acc.Withdraw(withdrawAmt));
        }

        [TestCase]
        public void TestThatBalanceUnachangedAfterFailedWithdrawal()
        {
            double initialBal = acc.Bal;
            double withdrawAmt = acc.Bal + 1;
            double correctBalance = acc.Bal;

            try
            {
                acc.Withdraw(withdrawAmt);
            }
            catch { }

            Assert.AreEqual(initialBal, acc.Bal);
        }

        [TestCase]
        public void TestThatNegativeWithdrawalThrowsMustBePositiveException()
        {
            Assert.Throws<MustBePositive>(() => acc.Withdraw(-1));
        }

        [TestCase]
        public void TestThatNegativeWithdrawalDoesNotChangeBalance()
        {
            double initialBal = acc.Bal;

            try
            {
                acc.Withdraw(-1);
            }
            catch { }

            Assert.AreEqual(initialBal, acc.Bal);
        }

        // Deposit()
        [TestCase]
        public void TestThatDepositAddsCorrectAmountToBalance()
        {
            double depositAmt = r.NextDouble() * (4999) + 1;
            double correctBal = acc.Bal + depositAmt;

            acc.Deposit(depositAmt);

            Assert.AreEqual(acc.Bal, correctBal);
        }

        [TestCase]
        public void TestThatNegativeDepositThrowsMustBePositiveException()
        {
            Assert.Throws<MustBePositive>(() => acc.Deposit(-1));
        }

        [TestCase]
        public void TestThatNegativeDepositDoesNotChangeBalance()
        {
            double initialBal = acc.Bal;

            try
            {
                acc.Deposit(-1);
            }
            catch { }

            Assert.AreEqual(initialBal, acc.Bal);
        }


        // TransferTo()
        [TestCase]
        public void TestThatTransferWithdrawsFromAccountWhenAmtLessThanBalance()
        {
            double transferAmt = r.NextDouble() * (acc.Bal - 1) + 1;
            double correctAccBal = acc.Bal - transferAmt;

            acc.TransferTo(transferAmt, targetAcc);

            Assert.AreEqual(acc.Bal, correctAccBal);
        }

        [TestCase]
        public void TestThatTransferDepositsToTargetAccountWhenAmtLessThanBalance()
        {
            double transferAmt = r.NextDouble() * (acc.Bal - 1) + 1;
            double correctTargetBal = targetAcc.Bal + transferAmt;

            acc.TransferTo(transferAmt, targetAcc);

            Assert.AreEqual(targetAcc.Bal, correctTargetBal);
        }
        
        [TestCase]
        public void TestThatTransferFailsWhenAmtMoreThanBalance()
        {
            double transferAmt = r.NextDouble() * 1000 + acc.Bal;
            double correctTargetBal = targetAcc.Bal;

            Assert.Throws<InsufficientFunds>(() => acc.TransferTo(transferAmt, targetAcc));
        }

        [TestCase]
        public void TestThatNegativeTransferThrowsMustBePositiveException()
        {
            Assert.Throws<MustBePositive>(() => acc.TransferTo(-1, targetAcc));
        }

        [TestCase]
        public void TestThatNegativeTransferDoesNotWithdrawMoneyFromAcc()
        {
            double initialBal = acc.Bal;
            try
            {
                acc.TransferTo(-1, targetAcc);
            }
            catch { }

            Assert.AreEqual(initialBal, acc.Bal);
        }

        [TestCase]
        public void TestThatNegativeTransferDoesNotDepositMoneyIntoTargetAcc()
        {
            double initialBal = targetAcc.Bal;
            try
            {
                acc.TransferTo(-1, targetAcc);
            }
            catch { }

            Assert.AreEqual(initialBal, targetAcc.Bal);
        }

        //CalculateInterest()
        [TestCase]
        public void TestThatInterestAmountIsCorrectlyCalculated()
        {
            double correctInterestAmt = acc.Bal * acc.Interest;

            acc.CalculateInterest();

            Assert.AreEqual(acc.InterestAmt, correctInterestAmt);
        }

        //CreditInterest()
        [TestCase]
        public void TestThatInterestAmtIsCredited()
        {
            double correctAmountAfterInterestCredit = acc.Bal * (1 + acc.Interest);

            acc.CreditInterest();

            Assert.AreEqual(acc.Bal, correctAmountAfterInterestCredit);
        }

        // ChangeCustomer()
        [TestCase]
        public void TestThatCustomerOfAccountUpdatedAfterChanging()
        {
            acc.ChangeCustomer(c2);

            Assert.AreEqual(c2, acc.Cust);
        }

        // ChangeBranch()
        [TestCase]
        public void TestThatBranchIsAssignedAfterChanging()
        {
            acc.ChangeBranch(branch);

            Assert.AreEqual(branch, acc.Branch);
        }
    }
}
