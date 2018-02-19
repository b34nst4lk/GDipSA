using System;
using NUnit.Framework;

namespace BankAccountTypes
{
    [TestFixture]
    class TestAccount
    {
        Account acc, targetAcc;
        Random r = new Random();

        [SetUp]
        public void SetUp()
        {
            acc = new Account("Tan", "000-001", 2000);
            targetAcc = new Account("Lee", "000-002", 3000);
        }

        [TearDown]
        public void TearDown()
        {
            acc = null;
        }


        //ToString()
        [TestCase]
        public void TestTheReturnValueOfToString()
        {
            string correctString = String.Format("{0}\t{1}\t{2:C}", acc.AccNo, acc.AccHolderName, acc.Bal);

            Assert.AreEqual(acc.ToString(), correctString);
        }

        //Withdraw()
        [TestCase]
        public void TestThatWithdrawDeductsTheRightAmountFromBalance()
        {
            double withdrawAmt = r.Next() * (4999) + 1;
            double correctBal = acc.Bal - withdrawAmt;

            acc.Withdraw(withdrawAmt);

            Assert.AreEqual(acc.Bal, correctBal);
        }

        //Deposit()
        [TestCase]
        public void TestThatDepositAddsCorrectAmountToBalance()
        {
            double depositAmt = r.Next() * (4999) + 1;
            double correctBal = acc.Bal + depositAmt;

            acc.Deposit(depositAmt);

            Assert.AreEqual(acc.Bal, correctBal);
        }

        //TransferTo()
        [TestCase]
        public void TestThatTransferDeductsFromAccountAndAddsToTargetAccountBalance()
        {
            double transferAmt = r.Next() * (4999) + 1;
            double correctAccBal = acc.Bal - transferAmt;
            double correctTargetBal = targetAcc.Bal + transferAmt;

            acc.TransferTo(transferAmt, targetAcc);

            Assert.AreEqual(acc.Bal, correctAccBal);
            Assert.AreEqual(targetAcc.Bal, correctTargetBal);
        }

        //CalculateInterest()
        [TestCase]
        public void TestThatInterestAmountIsCorrectlyCalculated()
        {
            double interest = r.Next() * 0.03;
            double correctInterestAmt = acc.Bal * interest;

            acc.CalculateInterest(interest);

            Assert.AreEqual(acc.InterestAmt, correctInterestAmt);
        }

        //CreditInterest()
        [TestCase]
        public void TestThatInterestAmtIsCredited()
        {
            double interest = r.Next() * 0.03;
            double correctAmountAfterInterestCredit = acc.Bal * (1 + interest);

            acc.CreditInterest(interest);

            Assert.AreEqual(acc.Bal, correctAmountAfterInterestCredit);
        }
    }
}