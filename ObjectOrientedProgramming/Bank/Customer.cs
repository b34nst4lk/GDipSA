using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    class Customer
    {
        private string name;
        private string address;
        private string pportNo;
        private DateTime dateOfBirth;

        // constructor
        public Customer(string nm, string add, string ppNo, DateTime dob)
        {
            name = nm;
            address = add;
            pportNo = ppNo;
            dateOfBirth = dob;
        }

        // methods
        public int GetAge()
        {
            return DateTime.Today.Year - dateOfBirth.Year;
        }

        public string Show()
        {
            return String.Format("{0}\t{1}\t{2}\t{3}", name, address, pportNo, GetAge());
        }
    }
}
