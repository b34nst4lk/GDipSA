using System;
using NUnit.Framework;

namespace BankAccountTypes.Tests
{
    [TestFixture]
    class TestOverdraftAccount
    {
        OverdraftAccount posAcc;
        OverdraftAccount negAcc;
        OverdraftAccount targetAcc;

        Customer c;
        Customer c2;


        [SetUp]
        public void SetUp()
        {
            c = new Customer("1", "Tan", new DateTime(1996, 1, 1));
            c2 = new Customer("1", "Lim", new DateTime(1996, 1, 1));

            posAcc = new OverdraftAccount("000-001", c, 2000);
            negAcc = new OverdraftAccount("000-001", c2, -3000);
            targetAcc = new OverdraftAccount("000-002", c, 3000);
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
            Assert.AreEqual(c.Name, posAcc.AccHolderName);
        }

        [TestCase]
        public void TestAccountNoConstructor()
        {
            Assert.AreEqual("000-001", posAcc.AccNo);
        }

        [TestCase]
        public void TestAccountPositiveBalanceConstructor()
        {
            Assert.AreEqual(2000, posAcc.Bal);
        }

        [TestCase]
        public void TestAccountNegativeBalanceConstructor()
        {
            Assert.AreEqual(-3000, negAcc.Bal);
        }

        //Interest
        [TestCase]
        public void TestThatInterestRateIsCorrectBalanceIsPostive()
        {
            Assert.AreEqual(0.0025, posAcc.Interest);
        }

        [TestCase]
        public void TestThatInterestRateIsCorrectBalanceIsNegative()
        {
            Assert.AreEqual(0.06, negAcc.Interest);
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
            double correctInterestAmt = posAcc.Bal * posAcc.Interest;

            posAcc.CalculateInterest();

            Assert.AreEqual(correctInterestAmt, posAcc.InterestAmt);
        }

        [TestCase]
        public void TestThatInterestAmountIsCorrectlyCalculatedWhenBalanceLessThanZero()
        {
            double correctInterestAmt = negAcc.Bal * negAcc.Interest;

            negAcc.CalculateInterest();

            Assert.AreEqual(correctInterestAmt, negAcc.InterestAmt);
        }


        //CreditInterest()
        [TestCase]
        public void TestThatInterestAmtIsCreditedWhenBalanceIsMoreThanZero()
        {
            double correctAmountAfterInterestCredit = posAcc.Bal * (1 + posAcc.Interest);

            posAcc.CreditInterest();

            Assert.AreEqual(correctAmountAfterInterestCredit, posAcc.Bal);
        }

        [TestCase]
        public void TestThatInterestAmtIsCreditedWhenBalanceIsLessThanZero()
        {
            double correctAmountAfterInterestCredit = negAcc.Bal * (1 + Math.Abs(negAcc.Interest));

            negAcc.CreditInterest();

            Assert.AreEqual(correctAmountAfterInterestCredit, negAcc.Bal);
        }

        // ChangeCustomer()
        [TestCase]
        public void TestThatCustomerOfAccountUpdatedAfterChanging()
        {
            posAcc.ChangeCustomer(c2);

            Assert.AreEqual(c2, posAcc.Cust);
        }
    }
}