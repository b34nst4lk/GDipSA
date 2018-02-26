using System;

namespace BankAccountTypes
{
    public class InsufficientFunds : Exception
    {
        public InsufficientFunds() { }

        public InsufficientFunds(string message) : base(message) { }
    }

    public class MustBePositive : ApplicationException
    {
        public MustBePositive() { }

        public MustBePositive(string message) : base(message) { }
    }

}
