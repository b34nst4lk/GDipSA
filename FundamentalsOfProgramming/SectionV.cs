using System;
using System.Linq;

namespace Workshop
{
    class SectionV
    {
        public static void Q1()
        {
            for (int i=1; i <= 20; i++)
            {
                Console.Write(i + " ");
            }
        }

        public static void Q2()
        {
            for (int i=20; i > 0; i--)
            {
                Console.Write(i + " ");
            }
        }

        public static void Q3()
        {
            Console.WriteLine("Without using reminder");
            for (int i=1; i <= 20; i += 2)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine("\n");

            Console.WriteLine("Using reminder");
            for (int i=1; i <= 20; i++)
            {
                if (i % 2 == 1)
                {
                    Console.Write(i + " ");
                }
            }
            Console.WriteLine();
        }

        public static void Q4()
        {
            Console.WriteLine("Fibonacci Number");

            int smallerNum = 0;
            int biggerNum = 1;
            int temp;
            Console.Write(smallerNum + " ");

            for (int i=0; i < 11; i++)
            {
                Console.Write(biggerNum + " ");
                temp = biggerNum;
                biggerNum += smallerNum;
                smallerNum = temp;
            }
        }

        public static void Q5()
        {
            Console.WriteLine("Alternating Numbers");

            for (int i = 0; i < 10; i++)
            {
                Console.Write((1 + i) + " ");
                Console.Write((20 - i) + " ");
            }
        }

        public static void Q6()
        {
            Console.WriteLine("Printing asterisk triangles\n");
            
            for (int i = 1; i <= 6; i++)
            {
                Console.WriteLine(new String('*', i));
            }

            Console.WriteLine();

            int padding = 6;
            for (int i = 1; i <=6; i++)
            {
                Console.WriteLine(new String('*', i).PadLeft(padding));
            }
        }

        public static void Q7()
        {
            Console.WriteLine("Printing asterisk triangles\n");
            
            for (int i = 6; i >= 1; i--)
            {
                Console.WriteLine(new String('*', i));
            }

            Console.WriteLine();

            int padding = 6;
            for (int i = 6; i >= 1; i--)
            {
                Console.WriteLine(new String('*', i).PadLeft(padding));
            }
        }
    }
}
