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

            for (int i = 1; i <=6; i++)
            {
                Console.WriteLine(new String('*', i).PadLeft(Console.WindowWidth));
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

        public static void Q8()
        {
            for (int i = 1; i <= 5; i++)
            {
                for (int j = 1; j <= i; j++)
                {
                    Console.Write(j + " ");
                }
                Console.WriteLine();
            }
        }

        public static void Q9()
        {
            int lastInt = 1;
            int i, j;
            for (i = 0; i <= 4; i++)
            {
                for (j = lastInt; j <= i + lastInt; j++)
                {
                    Console.Write(j + " ");
                }
                lastInt = j;
                Console.WriteLine();
            }
        }

        public static void Q10()
        {
            Random r = new Random();
            int rn;
            do
            {
                rn = r.Next(1, 7);
                Console.WriteLine(rn);
            } while (rn != 6);
        }

        public static void Q11()
        {
            Random r = new Random();
            int rn, sn;
            do
            {
                rn = r.Next(1, 7);
                sn = r.Next(1, 7);

                Console.WriteLine("{0}\t{1}", rn, sn);
            } while (rn != sn);
        }

        public static void Q12()
        {
            Random r = new Random();
            int rn = 0, sn = 0;

            do
            {
                sn = rn;
                rn = r.Next(1, 7);

                Console.WriteLine("{0}", rn);
            } while (rn != sn);
        }

        public static void Q13()
        {
            Random r = new Random();
            int rn = 0, sn = 0, tn = 0;

            do
            {
                tn = sn;
                sn = rn;
                rn = r.Next(1, 7);

                Console.WriteLine("{0}", rn);
            } while (rn != sn | sn != tn);
        }

        public static void Q14()
        {

        }
    }
}
