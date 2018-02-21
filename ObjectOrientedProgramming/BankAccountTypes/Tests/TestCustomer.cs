using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace BankAccountTypes.Tests
{
    [TestFixture]
    class TestCustomer
    {
        Customer cust;
        Customer custEmail;
        Customer custNo;
        Customer custContact;

        SavingsAccount acc;

        [SetUp]
        public void SetUp()
        {
            cust = new Customer("0001", "Tan", new DateTime(1997, 1, 1));
            custEmail = new Customer("0001", "Tan", new DateTime(1997, 1, 1), "js@a.com");
            custNo = new Customer("0001", "Tan", new DateTime(1997, 1, 1), "92345678");
            custContact = new Customer("0001", "Tan", new DateTime(1997, 1, 1),"92345678" ,"js@a.com");

            acc = new SavingsAccount("1", cust, 2000);
        }

        [TearDown]
        public void TearDown()
        {
            cust = null;
            custEmail = null;
            custNo = null;
            custContact = null;

            acc = null;
        }

        // Basic Constructor
        [TestCase]
        public void TestIdInConstructor()
        {
            Assert.AreEqual("0001", cust.Id);
        }        

        [TestCase]
        public void TestNameInConstructor()
        {
            Assert.AreEqual("Tan", cust.Name);
        }

        [TestCase]
        public void TestDobInConstructor()
        {
            Assert.AreEqual(new DateTime(1997, 1, 1), cust.DOB);
        }

        [TestCase]
        public void TestAgeInConstructor()
        {
            int correctAge = DateTime.Today.Year - new DateTime(1997, 1, 1).Year;

            Assert.AreEqual(correctAge, cust.Age);
        }

        [TestCase]
        public void TestContactNoBasicConstructor()
        {
            Assert.IsNull(cust.ContactNo);
        }

        [TestCase]
        public void TestEmailInBasicConstructor()
        {
            Assert.IsNull(cust.Email);
        }


        // Constructor with one contact field
        [TestCase]
        public void TestContactNoInIncompleteContactsConstructor()
        {
            Assert.AreEqual("92345678", custNo.ContactNo);
        }

        [TestCase]
        public void TestEmailInIncompleteContactsConstructor()
        {
            Assert.AreEqual("js@a.com", custEmail.Email);
        }

        // Constructor with both contact fields
        [TestCase]
        public void TestContactNoInFullContactsConstructor()
        {
            Assert.AreEqual("92345678", custContact.ContactNo);
        }

        [TestCase]
        public void TestEmailFullContactsConstructor()
        {
            Assert.AreEqual("js@a.com", custContact.Email);
        }

        // Age
        [TestCase]
        public void TestGetAge()
        {
            int correctAge = DateTime.Today.Year - cust.DOB.Year;

            Assert.AreEqual(correctAge, cust.Age);
        }

        // ToString
        [TestCase]
        public void TestToStringWhenNoContacts()
        {
            string correctString = String.Format("Customer({0}, {1}, {2}, {3}, {4})",
                cust.Id, cust.Name, cust.Age, "no contact number", "no email");

            Assert.AreEqual(correctString, cust.ToString());
        }

        [TestCase]
        public void TestToStringWhenOnlyEmail()
        {
            string correctString = String.Format("Customer({0}, {1}, {2}, {3}, {4})",
                custEmail.Id, custEmail.Name, custEmail.Age, "no contact number", custEmail.Email);

            Assert.AreEqual(correctString, custEmail.ToString());
        }
        
        [TestCase]
        public void TestToStringWhenOnlyContactNo()
        {
            string correctString = String.Format("Customer({0}, {1}, {2}, {3}, {4})",
                custNo.Id, custNo.Name, custNo.Age, custNo.ContactNo, "no email");

            Assert.AreEqual(correctString, custNo.ToString());
        }

        [TestCase]
        public void TestToStringWithFullContactDetails()
        {
            string correctString = String.Format("Customer({0}, {1}, {2}, {3}, {4})",
                custContact.Id, custContact.Name, custContact.Age, custContact.ContactNo, custContact.Email);

            Assert.AreEqual(correctString, custContact.ToString());
        }

        // UpdateEmail
        [TestCase]
        public void TestReturnTrueIfValidEmailIsUpdated()
        {
            string newEmail = "js2@a.com";

            bool rv = cust.UpdateEmail(newEmail);

            Assert.IsTrue(rv);
        }
        
        [TestCase]
        public void TestThatEmailIsUpdatedIfValid()
        {
            string newEmail = "js2@a.com";

            cust.UpdateEmail(newEmail);

            Assert.AreEqual(newEmail, cust.Email);
        }

        [TestCase]
        public void TestReturnFalseIfEmailIsInvalid()
        {
            string newEmail = "js2@a.c.om";

            bool rv = cust.UpdateEmail(newEmail);

            Assert.IsFalse(rv);
        }
        
        [TestCase]
        public void TestThatEmailIsNotUpdatedIfInvalid()
        {
            string newEmail = "js2@a.c.om";

            cust.UpdateEmail(newEmail); // cust email = null.

            Assert.IsNull(cust.Email);
        }

        // UpdateContact
        [TestCase]
        public void TestReturnTrueIfValidContactIsUpdated()
        {
            string newContact = "99887766";

            bool rv = cust.UpdateContactNo(newContact);

            Assert.IsTrue(rv);
        }

        [TestCase]
        public void TestThatValidContactNoIsUpdated()
        {
            string newContact = "99887766";

            cust.UpdateContactNo(newContact);

            Assert.AreEqual(newContact, cust.ContactNo);
        }

        [TestCase]
        public void TestReturnFalseIfInvalidContactNo()
        {
            string newContact = "998877";

            bool rv = cust.UpdateContactNo(newContact);

            Assert.IsFalse(rv);
        }

        [TestCase]
        public void TestThatInvalidContactNoIsNotUpdated()
        {
            string newContact = "998877";

            cust.UpdateContactNo(newContact);

            Assert.IsNull(cust.ContactNo);
        }

        // AddAccount
        [TestCase]
        public void TestReturnTrueWhenNewAccountAdded()
        {
            bool rv = cust.AddAccount(acc);

            Assert.IsTrue(rv);
        }

        [TestCase]
        public void TestThatNewAccountIsAdded()
        {
            cust.AddAccount(acc);

            Assert.IsTrue(cust.Accounts.Contains(acc));
        }

        [TestCase]
        public void TestReturnFalseWhenAccountAlreadyExists()
        {
            cust.AddAccount(acc);
            bool rv = cust.AddAccount(acc);

            Assert.IsFalse(rv);
        }

        [TestCase]
        public void TestThatAccountExistsAfterDoubleAdding()
        {
            cust.AddAccount(acc);
            cust.AddAccount(acc);

            Assert.IsTrue(cust.Accounts.Contains(acc));
        }

        // RemoveAccount
        [TestCase]
        public void TestReturnFalseWhenNoAccountToRemove()
        {
            bool rv = cust.RemoveAccount(acc);

            Assert.IsFalse(rv);
        }

        [TestCase]
        public void TestReturnTrueWhenAccountIsRemoved()
        {
            cust.AddAccount(acc);
            bool rv = cust.RemoveAccount(acc);

            Assert.IsTrue(rv);
        }

        [TestCase]
        public void TestAccountNoLongerExistsWhenRemoved()
        {
            cust.AddAccount(acc);
            cust.RemoveAccount(acc);

            Assert.IsFalse(cust.Accounts.Contains(acc));
        }

        // TransferAccount
        [TestCase]
        public void TestReturnTrueIfAccountSuccesfullyTransferred()
        {
            cust.AddAccount(acc);
            custEmail.RemoveAccount(acc);

            bool rv = cust.TransferAccount(acc, custEmail);

            Assert.IsTrue(rv);
        }

        [TestCase]
        public void TestThatOriginalCustomerNoLongerHasAccountAfterTransfer()
        {
            cust.AddAccount(acc);
            custEmail.RemoveAccount(acc);

            bool rv = cust.TransferAccount(acc, custEmail);

            Assert.IsFalse(cust.Accounts.Contains(acc));
        }
 
  
        [TestCase]
        public void TestThatTargetCustomerHasAccountAfterTransfer()
        {
            cust.AddAccount(acc);
            custEmail.RemoveAccount(acc);

            bool rv = cust.TransferAccount(acc, custEmail);

            Assert.IsTrue(custEmail.Accounts.Contains(acc));
        }

        [TestCase]
        public void TestReturnTrueIfAccountAlreadyExistsForCustomer()
        {
            cust.AddAccount(acc);
            custEmail.AddAccount(acc);

            bool rv = cust.TransferAccount(acc, custEmail);

            Assert.IsFalse(rv);
        }

        [TestCase]
        public void TestReturnTrueIfFailsAsCustomerDoesNotOwnAccount()
        {
            bool rv = cust.TransferAccount(acc, custEmail);

            Assert.IsFalse(rv);
        }
    }
}
