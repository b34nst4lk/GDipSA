using System;

namespace Workshop
{
    class SectionB
    {
        public static void Q1()
        {
            Console.WriteLine("Enter a number: ");
            string inputStr = Console.ReadLine();
            double input = Double.Parse(inputStr);
            double sqrt = Math.Sqrt(input);

            Console.WriteLine("Square root of {0} is {1:0.###}", input, sqrt);
        }

        public static void Q2()
        {
            Console.WriteLine("Enter a number: ");
            string inputStr = Console.ReadLine();
            double input = Double.Parse(inputStr);
            double roundedSqrt = Math.Round(Math.Sqrt(input), 3);

            Console.WriteLine("Square root of {0} rounded to 3dp is {1:0.000}", input, roundedSqrt);
        }

        public static void Q3()
        {
            Console.WriteLine("Enter your salary: ");
            string salaryStr = Console.ReadLine();
            double salary = Double.Parse(salaryStr);
            double transport = 0.03 * salary;
            double housing = 0.1 * salary;
            double total = salary + transport + housing;

            Console.WriteLine("Your total income is {0:C}", total);
        }

        public static void Q4()
        {
            Console.WriteLine("Enter the temparature in Centigrade:");
            string centigradeStr = Console.ReadLine();
            double centigrade = Double.Parse(centigradeStr);
            double farenheit = centigrade * 1.8 + 32;

            Console.WriteLine("{0:0} deg C is {1:0} deg F", centigrade, farenheit);
        }

        public static void Q5()
        {
            Console.WriteLine("Enter a value for x:");
            string xStr = Console.ReadLine();
            double x = Double.Parse(xStr);
            double output = 5 * x * x - 4 * x + 3;

            Console.WriteLine("5x^2 - 4x + 3 = {0}", output);
        }

        public static void Q6()
        {
            Console.Write("Enter a value for x1: ");
            string x1Str = Console.ReadLine();

            Console.Write("Enter a value for y1: ");
            string y1Str = Console.ReadLine();

            Console.Write("Enter a value for x2: ");
            string x2Str = Console.ReadLine();

            Console.Write("Enter a value for y2: ");
            string y2Str = Console.ReadLine();

            double x1 = Double.Parse(x1Str);
            double y1 = Double.Parse(y1Str);
            double x2 = Double.Parse(x2Str);
            double y2 = Double.Parse(y2Str);

            double output = Math.Sqrt(Math.Pow(x1 - x2, 2) + Math.Pow(y1 - y2, 2));

            Console.WriteLine("The distance between ({0}, {1}) and ({2}, {3}) is {4}", x1, y1, x2, y2, output);
        }
            
        public static void Q7()
        {
            Console.Write("Enter the distance of your cab journey: ");
            string distanceStr = Console.ReadLine();
            double distance = Double.Parse(distanceStr);
            double cabFare = 2.4 + 0.4 * distance;

            Console.WriteLine("Your cab fare is {0}.", cabFare);
        }

        public static void Q8()
        {
            Console.Write("Enter the distance of your cab journey: ");
            string distanceStr = Console.ReadLine();
            double distance = Double.Parse(distanceStr);
            double cabFare = Math.Round(2.4 + 0.4 * distance, 1);

            Console.WriteLine("Your cab fare is {0:C}.", cabFare);           
        }

        public static void Q9()
        {
            Console.Write("Enter the distance of your cab journey: ");
            string distanceStr = Console.ReadLine();
            double distance = Double.Parse(distanceStr);
            double cabFare = Math.Round(2.4 + 0.4 * distance + 0.049, 1);

            Console.WriteLine("Your cab fare is {0:0.0}.", cabFare);                      
        }

        public static void Q10()
        {
            Console.WriteLine("Calculate triangle with sqrt(s(s-a)(s-b)(s-c)) where s = (a+b+c)/2");
            
            Console.WriteLine("Enter the length of each edge of triangle.");
            Console.Write("The first edge: ");
            string aStr = Console.ReadLine();
            double a = Double.Parse(aStr);

            Console.Write("The second edge: ");
            string bStr = Console.ReadLine();
            double b = Double.Parse(bStr);

            Console.Write("The second edge: ");
            string cStr = Console.ReadLine();
            double c = Double.Parse(cStr);

            double s = (a + b + c) / 2;
            double sq = s * (s - a) * (s - b) * (s - c);

            if (sq < 0)
            {
                Console.WriteLine("This formula does not work when the sides are {0}, {1}, and {2}", a, b, c);
            }
            else
            {
                double sqrt = Math.Sqrt(sq);
                Console.WriteLine("The area of the triangle is {0}", sqrt);
            }
       }
    }
}
