using System;
using System.Collections.Generic;
using System.Linq;

namespace BankAccountTypes
{
    class Customer
    {
        string id;
        string name;
        string contactNo;
        string email;
        DateTime dob;
        HashSet<Account> accounts; 
        
        public Customer(string id, string name, DateTime dob)
        {
            this.id = id;
            this.name = name;
            this.dob = dob;
            accounts = new HashSet<Account>();
        }

        public Customer(string id, string name, DateTime dob, string contact):
             this(id, name, dob)           
        {
            UpdateEmail(contact);
            UpdateContactNo(contact);
        }

        public Customer(string id, string name, DateTime dob, string contactNo, string email): 
            this(id, name, dob)
        {
            UpdateContactNo(contactNo);
            UpdateEmail(email);
        }

        public string Id
        {
            get
            {
                return id;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }
        }

        public DateTime DOB
        {
            get
            {
                return dob;
            }
        }

        public int Age
        {
            get
            {
                return DateTime.Today.Year - dob.Year;
            }
        }

        public string ContactNo
        {
            get
            {
                return contactNo;
            }
        }

        public string Email
        {
            get
            {
                return email;
            }
        }

        public HashSet<Account> Accounts
        {
            get
            {
                return accounts;
            }
        }

        public override string ToString()
        {
            string email, contactNo;
            if (Email is null)
            {
                email = "no email";
            }
            else
            {
                email = Email;
            }

            if (ContactNo is null)
            {
                contactNo = "no contact number";
            }
            else
            {
                contactNo = ContactNo;
            }
            return String.Format("Customer({0}, {1}, {2}, {3}, {4})",
                Id, Name, Age, contactNo, email);
        }

        public bool UpdateContactNo(string contactNo)
        {
            if (ValidateContactNo(contactNo))
            {
                this.contactNo = contactNo;
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool ValidateContactNo(string contactNo)
        {
            if (contactNo.Length == 8 && Int32.TryParse(contactNo, out int temp))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool UpdateEmail(string email)
        {
            if (ValidateEmail(email))
            {
                this.email = email;
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool ValidateEmail(string email)
        {
            bool rv = true;

            String[] splitEmail = email.Split('@');
            if (splitEmail.Length != 2)
            {
                rv = false;
            }
            else if (splitEmail[0].Length == 0)
            {
                rv = false;
            }
            
            if (rv)
            {
                String[] domain = splitEmail[1].Split('.');
                if (domain.Length != 2)
                {
                    rv = false;
                }
                else if (domain[0].Length == 0 || domain[1].Length == 0)
                {
                    rv = false;
                }
            }

            return rv;
        }

        public bool AddAccount(Account acc)
        {
            return accounts.Add(acc);
        }

        public bool RemoveAccount(Account acc)
        {
            int len = accounts.Count;
            accounts.Remove(acc);
            if (len == accounts.Count)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool TransferAccount(Account acc, Customer cust)
        {
            if (RemoveAccount(acc))
            {
                if (cust.AddAccount(acc))
                {
                    acc.ChangeCustomer(cust);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
