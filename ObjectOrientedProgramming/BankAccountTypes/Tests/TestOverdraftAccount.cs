using System;
using NUnit.Framework;

namespace BankAccountTypes.Tests
{
    [TestFixture]
    class TestOverdraftAccount
    {
        OverdraftAccount posAcc;
        OverdraftAccount targetAcc;


        [SetUp]
        public void SetUp()
        {
            posAcc = new OverdraftAccount("000-001", "Tan", 2000);
            targetAcc = new OverdraftAccount("000-002", "Lim", 3000);
        }

        [TearDown]
        public void TearDown()
        {
            posAcc = null;
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

            Assert.AreEqual(0.0025, tempAcc.Interest);
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
            string correctString = String.Format("OverdraftAccount({0}, {1}, {2:C})", posAcc.AccNo, posAcc.AccHolderName, posAcc.Bal);

            Assert.AreEqual(correctString, posAcc.ToString());
        }


        // Withdraw()
        [TestCase]
        public void TestForWithdrawWhenAmtLessThanBalance()
        {
            double correctBalance = posAcc.Bal - 1000;

            posAcc.Withdraw(1000);

            Assert.AreEqual(1000, posAcc.Bal);
        }

        [TestCase]
        public void TestForWithdrawWhenAmtMoreThanBalance()
        {
            double correctBalance = posAcc.Bal - 3000;

            posAcc.Withdraw(3000);

            Assert.AreEqual(-1000, posAcc.Bal);
        }


        // Deposit()
        [TestCase]
        public void TestThatDepositAddsCorrectAmountToBalance()
        {
            double correctBal = posAcc.Bal + 1000;

            posAcc.Deposit(1000);

            Assert.AreEqual(correctBal, posAcc.Bal);
        }

        // TransferTo()
        [TestCase]
        public void TestThatTransferWithdrawsFromAccount()
        {
            double correctAccBal = posAcc.Bal - 1000;

            posAcc.TransferTo(1000, targetAcc);

            Assert.AreEqual(correctAccBal, posAcc.Bal);
        }

        //CalculateInterest()
        [TestCase]
        public void TestThatInterestAmountIsCorrectlyCalculatedWhenBalanceMoreThanZero()
        {
            OverdraftAccount tempAcc = new OverdraftAccount("000-001", "Tan", 2000);
            double correctInterestAmt = tempAcc.Bal * tempAcc.Interest;

            posAcc.CalculateInterest();

            Assert.AreEqual(correctInterestAmt, posAcc.InterestAmt);
        }

        [TestCase]
        public void TestThatInterestAmountIsCorrectlyCalculatedWhenBalanceLessThanZero()
        {
            OverdraftAccount tempAcc = new OverdraftAccount("000-001", "Tan", -2000);
            double correctInterestAmt = tempAcc.Bal * tempAcc.Interest;

            tempAcc.CalculateInterest();

            Assert.AreEqual(correctInterestAmt, tempAcc.InterestAmt);
        }


        //CreditInterest()
        [TestCase]
        public void TestThatInterestAmtIsCreditedWhenBalanceIsMoreThanZero()
        {
            OverdraftAccount tempAcc = new OverdraftAccount("000-001", "Tan", 2000);
            double correctAmountAfterInterestCredit = tempAcc.Bal * (1 + tempAcc.Interest);

            tempAcc.CreditInterest();

            Assert.AreEqual(correctAmountAfterInterestCredit, tempAcc.Bal);
        }

        [TestCase]
        public void TestThatInterestAmtIsCreditedWhenBalanceIsLessThanZero()
        {
            OverdraftAccount tempAcc = new OverdraftAccount("000-001", "Tan", -2000);
            double correctAmountAfterInterestCredit = tempAcc.Bal * (1 + Math.Abs(tempAcc.Interest));

            tempAcc.CreditInterest();

            Assert.AreEqual(correctAmountAfterInterestCredit, tempAcc.Bal);
        }
    }
}
