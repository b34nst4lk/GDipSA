using System;

namespace Workshop
{
    public class SectionA
    {
        public static void Q1()
        {
            Console.WriteLine("John Smith");
            Console.WriteLine("johnsmith@gmail.com");
        }

        public static void Q2()
        {
            Console.Write("Please enter you name: ");
            string name = Console.ReadLine();
            Console.WriteLine("\t\tGood Morning {0}", name);
        }

        public static void Q3()
        {
            Console.Write("Please enter a number: ");
            string inputStr = Console.ReadLine();
            int input = Int32.Parse(inputStr);
            int squared = input * input;
            Console.WriteLine("The square of {0} is {1}", inputStr, squared);
 
        }

        public static void Q4()
        {
            Console.Write("Please enter a number: ");
            string inputStr = Console.ReadLine();
            double input = Math.Pow(Double.Parse(inputStr), 2);
            Console.WriteLine("The square of {0} is {1}", inputStr, input);
        }
        
        public static void Q5()
        {
            Console.WriteLine("Please enter a number");
            string inputStr = Console.ReadLine();
            double input = Double.Parse(inputStr);

            Console.WriteLine("Converted value is {0:0.00}", input);
        }
    }
}
