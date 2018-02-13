using System;

namespace Bank
{
    class Program
    {
        static void Main(string[] args)
        {
            Customer y = new Customer("Tan Ah Kow", "20, Seaside Road", "XXX20", new DateTime(1989,10,11));
            Customer z = new Customer("Kim Lee Keng", "2, Rich View", "XXX9F", new DateTime(1993, 4, 25));
            Account a = new Account("001-001-001", y, 2000);
            Account b = new Account("001-001-002", z, 5000);

            Console.WriteLine("\nAccount and Customer Setup");
            Console.WriteLine(a.Show());

            Console.WriteLine("\nDeposit and withdrawal from a");
            Console.WriteLine(b.Show());
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
