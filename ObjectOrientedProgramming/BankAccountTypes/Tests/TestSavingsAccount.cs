using System;
using NUnit.Framework;

namespace BankAccountTypes
{
    [TestFixture]
    class TestSavingsAccount
    {
        SavingsAccount acc;
        SavingsAccount targetAcc;
        Random r = new Random();

        [SetUp]
        public void SetUp()
        {
            acc = new SavingsAccount("Tan", "000-001", 2000);
            targetAcc = new SavingsAccount("Lim", "000-002", 3000);
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
            SavingsAccount tempAcc = new SavingsAccount("000-001", "Tan", 2000);

            Assert.AreEqual("Tan", tempAcc.AccHolderName);
        }

        [TestCase]
        public void TestAccountNoConstructor()
        {
            SavingsAccount tempAcc = new SavingsAccount("000-001", "Tan", 2000);

            Assert.AreEqual("000-001", tempAcc.AccNo);
        }

        [TestCase]
        public void TestAccountBalanceConstructor()
        {
            SavingsAccount tempAcc = new SavingsAccount("000-001", "Tan", 2000);

            Assert.AreEqual(2000, tempAcc.Bal);
        }

        //ToString()
        [TestCase]
        public void TestTheReturnValueOfToString()
        {
            string correctString = String.Format("SavingsAccount({0}, {1}, {2:C})", acc.AccNo, acc.AccHolderName, acc.Bal);

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
    }
}
