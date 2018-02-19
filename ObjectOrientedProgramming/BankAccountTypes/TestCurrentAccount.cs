using System;
using NUnit.Framework;

namespace BankAccountTypes
{
    [TestFixture]
    class TestCurrentAccount
    {
        CurrentAccount acc;
        CurrentAccount targetAcc;
        Account parentTargetAcc;
        Random r = new Random();

        [SetUp]
        public void SetUp()
        {
            acc = new CurrentAccount("000-001", "Tan", 2000);
            targetAcc = new CurrentAccount("000-002", "Lim", 3000);
            parentTargetAcc = new Account("000-000", "Sim", 5000);
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
            CurrentAccount tempAcc = new CurrentAccount("000-001", "Tan", 2000);

            Assert.AreEqual("Tan", tempAcc.AccHolderName);
        }

        [TestCase]
        public void TestAccountNoConstructor()
        {
            CurrentAccount tempAcc = new CurrentAccount("000-001", "Tan", 2000);

            Assert.AreEqual("000-001", tempAcc.AccNo);
        }

        [TestCase]
        public void TestAccountBalanceConstructor()
        {
            CurrentAccount tempAcc = new CurrentAccount("000-001", "Tan", 2000);

            Assert.AreEqual(2000, tempAcc.Bal);
        }

        //Interest
        [TestCase]
        public void TestThatInterestRateIsCorrect()
        {
            Assert.AreEqual(0.0025, CurrentAccount.Interest);
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
            int accBal = (int)acc.Bal;
            double withdrawAmt = r.Next(1, accBal);
            double correctBalance = acc.Bal - withdrawAmt;

            acc.Withdraw(withdrawAmt);

            Assert.AreEqual(correctBalance, acc.Bal);
        }

        [TestCase]
        public void TestThatSuccessfulWithdrawalReturnsTrue()
        {
            int accBal = (int)acc.Bal;
            double withdrawAmt = r.Next(1, accBal);

            bool rv = acc.Withdraw(withdrawAmt);

            Assert.IsTrue(rv);
        }

        [TestCase]
        public void TestForFailedWithdrawalWhenAmtMoreThanBalance()
        {
            int accBal = (int)acc.Bal;
            double withdrawAmt = r.Next(accBal + 1, accBal+1000);
            double correctBalance = acc.Bal;

            acc.Withdraw(withdrawAmt);

            Assert.AreEqual(correctBalance, acc.Bal);
        }

        [TestCase]
        public void TestThatFailedWithdrawalReturnsFalse()
        {
            int accBal = (int)acc.Bal;
            double withdrawAmt = r.Next(accBal + 1, accBal+1000);

            bool rv = acc.Withdraw(withdrawAmt);

            Assert.IsFalse(rv);
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
        public void TestThatTrasferWithdrawalFailsWhenAmtMoreThanBalance()
        {
            double transferAmt = r.NextDouble() * 1000 + acc.Bal;
            double correctAccBal = acc.Bal;

            acc.TransferTo(transferAmt, targetAcc);

            Assert.AreEqual(acc.Bal, correctAccBal);
        }

        public void TestThatTransferDepositFailsWhenAmtMoreThanBalance()
        {
            double transferAmt = r.NextDouble() * 1000 + acc.Bal;
            double correctTargetBal = targetAcc.Bal;

            acc.TransferTo(transferAmt, targetAcc);

            Assert.AreEqual(targetAcc.Bal, correctTargetBal);
        }

        //CalculateInterest()
        [TestCase]
        public void TestThatInterestAmountIsCorrectlyCalculated()
        {
            double correctInterestAmt = acc.Bal * CurrentAccount.Interest;

            acc.CalculateInterest();

            Assert.AreEqual(acc.InterestAmt, correctInterestAmt);
        }

        //CreditInterest()
        [TestCase]
        public void TestThatInterestAmtIsCredited()
        {
            double correctAmountAfterInterestCredit = acc.Bal * (1 + CurrentAccount.Interest);

            acc.CreditInterest();

            Assert.AreEqual(acc.Bal, correctAmountAfterInterestCredit);
        }
    }
}
