using System;

namespace BankAccount
{
    class App
    {
        static void Main(string[] args)
        {
            Account a = new Account("001-001-001", "Tan Ah Kow", 2000);
            Account b = new Account("001-001-002", "Kim Keng Lee", 5000);
            Console.WriteLine("\nAccount set-up:");
            Console.WriteLine(a.Show());
            Console.WriteLine(b.Show());

            Console.WriteLine("\nDeposit and withdrawal from account a");
            a.Deposit(100);
            Console.WriteLine(a.Show());
            a.Withdraw(200);
            Console.WriteLine(a.Show());

            Console.WriteLine("\nTransfer from a to b");
            a.TransferTo(300, b);
            Console.WriteLine(a.Show());
            Console.WriteLine(b.Show());
        }
    }
}
