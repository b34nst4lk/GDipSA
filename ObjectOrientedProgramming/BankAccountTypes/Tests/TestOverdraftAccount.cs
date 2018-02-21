using System;
using NUnit.Framework;

namespace BankAccountTypes.Tests
{
    [TestFixture]
    class TestOverdraftAccount
    {
        OverdraftAccount acc;
        OverdraftAccount targetAcc;
        Account parentTargetAcc;
        Random r = new Random();


        [SetUp]
        public void SetUp()
        {
            acc = new OverdraftAccount("000-001", "Tan", 2000);
            targetAcc = new OverdraftAccount("000-002", "Lim", 3000);
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
            OverdraftAccount tempAcc = new OverdraftAccount("000-001", "Tan", 2000);

            Assert.AreEqual("Tan", tempAcc.AccHolderName);
        }

        [TestCase]
        public void TestAccountNoConstructor()
        {
            OverdraftAccount tempAcc = new OverdraftAccount("000-001", "Tan", 2000);

            Assert.AreEqual("000-001", tempAcc.AccNo);
        }

        [TestCase]
        public void TestAccountPositiveBalanceConstructor()
        {
            OverdraftAccount tempAcc = new OverdraftAccount("000-001", "Tan", 2000);

            Assert.AreEqual(2000, tempAcc.Bal);
        }

        [TestCase]
        public void TestAccountBalanceConstructor()
        {
            OverdraftAccount tempAcc = new OverdraftAccount("000-001", "Tan", -2000);

            Assert.AreEqual(-2000, tempAcc.Bal);
        }

        //Interest
        [TestCase]
        public void TestThatInterestRateIsCorrectBalanceIsPostive()
        {
            OverdraftAccount tempAcc = new OverdraftAccount("000-001", "Tan", 2000);

            Assert.AreEqual(0.01, tempAcc.Interest);
        }

        [TestCase]
        public void TestThatInterestRateIsCorrectBalanceIsNegative()
        {
            OverdraftAccount tempAcc = new OverdraftAccount("000-001", "Tan", -2000);

            Assert.AreEqual(0.06, tempAcc.Interest);
        }


        //ToString()
        [TestCase]
        public void TestTheReturnValueOfToString()
        {
            string correctString = String.Format("OverdraftAccount({0}, {1}, {2:C})", acc.AccNo, acc.AccHolderName, acc.Bal);

            Assert.AreEqual(acc.ToString(), correctString);
        }


        // Withdraw()
        [TestCase]
        public void TestForWithdrawWhenAmtLessThanBalance()
        {
            int accBal = (int)acc.Bal;
            double withdrawAmt = r.Next(1, accBal);
            double correctBalance = acc.Bal - withdrawAmt;

            acc.Withdraw(withdrawAmt);

            Assert.AreEqual(correctBalance, acc.Bal);
        }

        [TestCase]
        public void TestForWithdrawWhenAmtMoreThanBalance()
        {
            int accBal = (int)acc.Bal;
            double withdrawAmt = r.Next(accBal, accBal+1000);
            double correctBalance = acc.Bal - withdrawAmt;

            acc.Withdraw(withdrawAmt);

            Assert.AreEqual(correctBalance, acc.Bal);
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
        public void TestThatTransferWithdrawsFromAccount()
        {
            double transferAmt = r.NextDouble() * (acc.Bal + 1000) + 1;
            double correctAccBal = acc.Bal - transferAmt;

            acc.TransferTo(transferAmt, targetAcc);

            Assert.AreEqual(acc.Bal, correctAccBal);
        }

        //CalculateInterest()
        [TestCase]
        public void TestThatInterestAmountIsCorrectlyCalculatedWhenBalanceMoreThanZero()
        {
            OverdraftAccount tempAcc = new OverdraftAccount("000-001", "Tan", 2000);
            double correctInterestAmt = tempAcc.Bal * tempAcc.Interest;

            acc.CalculateInterest();

            Assert.AreEqual(acc.InterestAmt, correctInterestAmt);
        }

        [TestCase]
        public void TestThatInterestAmountIsCorrectlyCalculatedWhenBalanceLessThanZero()
        {
            OverdraftAccount tempAcc = new OverdraftAccount("000-001", "Tan", -2000);
            double correctInterestAmt = tempAcc.Bal * tempAcc.Interest;

            tempAcc.CalculateInterest();

            Assert.AreEqual(tempAcc.InterestAmt, correctInterestAmt);
        }


        //CreditInterest()
        [TestCase]
        public void TestThatInterestAmtIsCreditedWhenBalanceIsMoreThanZero()
        {
            OverdraftAccount tempAcc = new OverdraftAccount("000-001", "Tan", 2000);
            double correctAmountAfterInterestCredit = tempAcc.Bal * (1 + tempAcc.Interest);

            tempAcc.CreditInterest();

            Assert.AreEqual(tempAcc.Bal, correctAmountAfterInterestCredit);
        }

        [TestCase]
        public void TestThatInterestAmtIsCreditedWhenBalanceIsLessThanZero()
        {
            OverdraftAccount tempAcc = new OverdraftAccount("000-001", "Tan", -2000);
            double correctAmountAfterInterestCredit = tempAcc.Bal * (1 + Math.Abs(tempAcc.Interest));

            tempAcc.CreditInterest();

            Assert.AreEqual(tempAcc.Bal, correctAmountAfterInterestCredit);
        }
    }
}
