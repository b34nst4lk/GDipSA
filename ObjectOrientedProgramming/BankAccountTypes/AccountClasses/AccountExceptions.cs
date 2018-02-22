using System;

namespace BankAccountTypes
{
    public class InsufficientFunds : Exception
    {
        public InsufficientFunds() { }

        public InsufficientFunds(string message) : base(message) { }
    }
}
