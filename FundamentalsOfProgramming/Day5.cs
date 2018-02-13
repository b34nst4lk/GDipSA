using System;

namespace Workshop
{
    delegate double DoubleOps(double n);
    class SectionH
    {
        public static void Q1()
        {
            Console.WriteLine("Please enter a number: ");
            Console.WriteLine("You entered {0}", Day5Methods.ReadInteger());
        }

        public static void Q2()
        {
            int[] arr = SectionG.CreateRndIntArr(13, 0, 99);
            Day5Methods.PrintArray(arr);
        }

        public static void Q3()
        {
            string str1 = Day5Methods.ReadString("Please enter the string to search in: ");
            string str2 = Day5Methods.ReadString("Please enter the string to find: ");

            if (Day5Methods.InString(str1, str2))
            {
                Console.Write("\"{0}\" can be found in \"{1}\"", str2, str1);
            }
            else
            {
                Console.Write("\"{0}\" cannot be found in \"{1}\"", str2, str1);
            }
        }

        public static void Q4()
        {
            string str1 = Day5Methods.ReadString("Please enter the string to search in: ");
            string str2 = Day5Methods.ReadString("Please enter the string to find: ");

            int pos = Day5Methods.FindString(str1, str2);
            if (pos >= 0)
            {
                Console.Write("\"{0}\" can be found at position {1}", str2, pos);
            }
            else
            {
                Console.Write("\"{0}\" cannot be found in \"{1}\"", str2, str1);
            }
        }

        public static void Q5()
        {
            int input = Day5Methods.ReadInteger();
            string output = Day5Methods.ConvertDecToHex(input);
            Console.WriteLine("{0} in hex is {1}", input, output);
        }

        public static void Q6()
        {
            string str = Day5Methods.ReadString();
            char c1 = Day5Methods.ReadChar("Please enter the character to find: ");
            char c2 = Day5Methods.ReadChar("Please enter the character to replace with: ");

            string output = Day5Methods.Substitute(str, c1, c2);

            Console.WriteLine("Before: {0}", str);
            Console.WriteLine("After : {0}", output);
        }

        public static void Q7()
        {
            int i = Day5Methods.ReadInteger();

            int[] arr = SectionG.CreateRndIntArr(8, 1, 200);
            Console.WriteLine(string.Join(", ", arr)+"\n");
            Console.WriteLine(string.Join(", ", Day5Methods.SetArray(arr, i)) + "\n");
        }

        public static void Q8()
        {
            Console.WriteLine("Randomly generate an int array");
            int[] arr = SectionG.CreateRndIntArr(8, -100, 100);
            Day5Methods.PrintArray(arr);

            Console.WriteLine("\nResize to smaller array");
            int[] smallerArr = Day5Methods.ResizeArray(arr, 4);
            Day5Methods.PrintArray(smallerArr);

            Console.WriteLine("\nResize to larger array");
            int[] largerArr = Day5Methods.ResizeArray(arr, 10);
            Day5Methods.PrintArray(largerArr);
        }

        public static void Q9()
        {
            for (int i=5; i <= 1000; i++)
            {
                if (Day5Methods.IsPrime(i))
                {
                    Console.WriteLine(i);
                }
            }
        }

        public static void Q10()
        {
            //Test case 1 -- return { { 14 } }
            int[,] A = { { 1, 2, 3 } };
            int[,] B = { { 1 }, { 2 }, { 3 } };
            Day5Methods.Print2DArray(Day5Methods.MatrixMultiplication(A, B));

            //Test case 2 --
            int[,] C =  
                {
                    { 53, 49 },
                    { 87, 75 },
                    { 93, 3 },
                    { 70, 12 },
                    { 56, 22 }
                };
            int[,] D =
                {
                    { 96, 26, 81, 90, 19 },
                    { 5, 34, 97, 85, 29 }
                };
            Day5Methods.Print2DArray(Day5Methods.MatrixMultiplication(C, D));
        }

        public static void Q11()
        {
            double[] arr = new double[5];
            for (int i = 0; i < 5; i++)
            {
                arr[i] = Day5Methods.ReadDouble();
            }

            // Double everything in array
            Day5Methods.PrintArray(Day5Methods.ProcessArray(arr, Day5Methods.DoubleTheDouble));

            // Square root everything in array
            Day5Methods.PrintArray(Day5Methods.ProcessArray(arr, Math.Sqrt));
        }
    }


    class Day5Methods
    {
        public static string ReadString(string msg = "Please enter a string: ")
        {
            Console.WriteLine(msg);
            return Console.ReadLine();
        }
        
        public static char ReadChar(string msg = "Please enter a character: ")
        {
            string input = "";
            char rv;

            while (!Char.TryParse(input, out rv))
            {
                Console.WriteLine(msg);
                input = Console.ReadLine();
            }
            return rv;
        }

        public static int ReadInteger(string msg = "Please enter an integer: ")
        {
            string input = "";
            int rv;

            while (!Int32.TryParse(input, out rv))
            {
                Console.WriteLine(msg);
                input = Console.ReadLine();
            }
            return rv;
        }

        public static double ReadDouble(string msg = "Please enter a number: ")
        {
            string input = "";
            double rv;

            while (!Double.TryParse(input, out rv))
            {
                Console.WriteLine(msg);
                input = Console.ReadLine();
            }
            return rv;
        }

        public static void PrintArray(double[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + "\t");
            }
            Console.WriteLine();
        }

        public static void PrintArray(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + "\t");
            }
            Console.WriteLine();
        }

        public static void Print2DArray(int[,] arr)
        {
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j=0; j < arr.GetLength(1); j++)
                {
                    Console.Write(arr[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }

        public static void Print2DArray(double[,] arr)
        {
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j=0; j < arr.GetLength(1); j++)
                {
                    Console.Write(arr[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }

        public static bool InString(string str1, string str2)
        {
            bool rv = false;
            str1 = str1.ToLower();
            str2 = str2.ToLower();

            for (int i = 0; i < str1.Length - str2.Length + 1; i++)
            {
                string substr = str1.Substring(i, str2.Length);
                rv = substr == str2;
                if (rv)
                {
                    break;
                }
            }
            
            return rv;
        }

        public static int FindString(string str1, string str2)
        {
            int rv = -1;
            str1 = str1.ToLower();
            str2 = str2.ToLower();

            for (int i = 0; i < str1.Length - str2.Length + 1; i++)
            {
                string substr = str1.Substring(i, str2.Length);
                if (substr == str2)
                {
                rv = i;
                    break;
                }
            }
            
            return rv;
        }

        public static string ConvertDecToHex(int input)
        {
            string[] hexArr = new string[16] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "A", "B", "C", "D", "E", "F" };
            string rv = "";
            int dividend = input;

            while (dividend > 0)
            {
                int remainder = dividend % 16;
                rv = hexArr[remainder] + rv;
                dividend /= 16;
            }
            return rv;
        }

        public static string Substitute(string s, char c1, char c2)
        {
            string rv = "";

            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == c1)
                {
                    rv += c2;
                }
                else
                {
                    rv += s[i];
                }
            }

            return rv;
        }

        public static int[] SetArray(int[] arr, int value)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = value;
            }

            return arr;
        }

        public static int[] ResizeArray(int[] arr, int newSize)
        {
            int[] newArr = new int[newSize];
            for (int i = 0; i < Math.Min(arr.Length, newSize); i++)
            {
                newArr[i] = arr[i];
            }
            return newArr;
        }

        public static bool IsPrime(int input)
        {
            bool isPrime = true;
            
            if (input == 1 || (input % 2 == 0 && input > 2))
            {
                isPrime = false;
            }
            else
            {
                for (int i = 3; i < input && isPrime; i=i+2)
                {
                    isPrime = true;
                    if (input % i == 0)
                    {
                        isPrime = false;
                    }
                }
            }
            return isPrime;
        }

        public static int[,] MatrixMultiplication(int[,] A, int[,] B)
        {
            // Get outer dimensions
            int lenA = A.GetLength(0);
            int lenB = B.GetLength(1);

            // Get inner dimension
            int innerA = A.GetLength(1);
            int innerB = B.GetLength(0);
            int lenInner;
            
            // Validate inner dimensions are equal, if not then exit
            if (innerA != innerB)
            {
                int[,] rv = new int[1,1] { { -1 } };
                return rv;
            }
            else
            {
                lenInner = innerA;
            }			

            // init return arr
            int[,] C = new int[lenB, lenA];

            // compute return arr
            for (int Ci = 0; Ci < C.GetLength(0); Ci++)
            {
                for (int Cj = 0; Cj < C.GetLength(1); Cj++)
                {
                    int Cvalue = 0;
                    for (int inner = 0; inner < lenInner; inner++)
                    {
                        Cvalue += A[Ci, inner] * B[inner, Cj];
                    }
                    C[Ci, Cj] = Cvalue;
                }
            }
            return C;
        }

        public static double DoubleTheDouble(double theDouble)
        {
            double DoubledDouble = theDouble * 2;
            return DoubledDouble;
        }

        public static double[] ProcessArray(double[] arr, DoubleOps ops)
        {
            for (int i=0; i<arr.Length; i++)
            {
                arr[i] = ops(arr[i]);
            }
            return arr;
        }
    }
}
