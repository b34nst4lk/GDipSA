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
            Random r = new Random();
            int rn = 0, sn = 0;

            do
            {
                sn = rn;
                rn = r.Next(1, 7);

                Console.WriteLine("{0}", rn);
            } while (rn != 2 || sn != 1);
        }

        //1D array manipulation
        public static void Q15()
        {
            int[] arr = SectionG.CreateRndIntArr(30, -1000, 1000);
            Day5Methods.PrintArray(arr);

            Console.WriteLine();
            int input = Day5Methods.ReadInteger("Please enter an integer to find in the array: ");
            int pos = -1;

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == input)
                {
                    pos = i;
                    break;
                }
            }
            
            if (pos >= 0)
            {
                Console.WriteLine("{0} can be found in position {1}.", input, pos);
            }
            else
            {
                Console.WriteLine("{0} does not exist in the above array", input);
            }
        }

        public static void Q16()
        {
            int[] arr = SectionG.CreateRndIntArr(5, -1000, 1000);
            Day5Methods.PrintArray(arr);

            // Descending sort
            for (int i = 0; i < arr.Length -1; i++)
            {
                int temp = arr[i];
                int pos = i;

                for (int j = i; j < arr.Length; j++)
                {
                    if (arr[j] > temp)
                    {
                        temp = arr[j];
                        pos = j;
                    }
                }

                arr[pos] = arr[i];
                arr[i] = temp;
                Day5Methods.PrintArray(arr);
            }
            Day5Methods.PrintArray(arr);
        }

        public static void Q17()
        {
            int[] arr = SectionG.CreateRndIntArr(10, -10, 10);
            Day5Methods.PrintArray(arr);

            // Descending sort
            for (int i = 0; i < arr.Length -1; i++)
            {
                int temp = arr[i];
                int pos = i;

                for (int j = i; j < arr.Length; j++)
                {
                    if (arr[j] > temp)
                    {
                        temp = arr[j];
                        pos = j;
                    }
                }

                arr[pos] = arr[i];
                arr[i] = temp;
                Day5Methods.PrintArray(arr);
            }
           
            Day5Methods.PrintArray(arr);

            // Binary Search
            int target = Day5Methods.ReadInteger();
            bool found = false;
            int left = 0;
            int right = arr.Length - 1;
            int mid = arr.Length / 2;
            int foundPos = -1;
            do
            {
                if (arr[mid] == target) // if target found 
                {
                    found = true;
                    foundPos = mid;
                }
                else if (arr[mid] > target) // if target is smaller than mid, move left pointer to right of mid
                {
                    left = mid + 1;
                }
                else if (arr[mid] < target) // if target is bigger than mid, move right pointer to left of mid
                {
                    right = mid - 1;
                }
 
                if (left > right) // if left pointer and right pointer have swapped sides, break as nothing left to search
                {
                    break;
                }
                
                mid = (right + left) / 2; // get new mid

            } while (!found);

            if (foundPos >= 0)
            {
                Console.WriteLine("{0} is in foundPosition {1}.", target, foundPos);
            }
            else
            {
                Console.WriteLine("{0} cannot be found in the array", target);
            }
        }

        //Multidimensional arrays
        public static void Q18()
        {
            int[,] arr = SectionG.CreateRnd2dIntArr(3, 5, 0, 10);
            Day5Methods.Print2DArray(arr);

            double[] avgArr = new double[arr.GetLength(0)];

            int dim0 = arr.GetLength(0);
            int dim1 = arr.GetLength(1);

            for (int i = 0; i < dim0; i++)
            {
                int sum = 0;
                for (int j = 0; j < dim1; j++)
                {
                    sum += arr[i, j];
                }
                avgArr[i] = (double)sum / dim1;
            }

            Day5Methods.PrintArray(avgArr);
        }

        public static void Q19()
        {
            int[,] arr = SectionG.CreateRnd2dIntArr(3, 5, 0, 10);
            Day5Methods.Print2DArray(arr);

            double[] maxArr = new double[arr.GetLength(0)];

            int dim0 = arr.GetLength(0);
            int dim1 = arr.GetLength(1);

            for (int i = 0; i < dim0; i++)
            {
                int max = Int32.MinValue;
                for (int j = 0; j < dim1; j++)
                {
                    if (max < arr[i, j])
                    {
                        max = arr[i, j];
                    }
                }
                maxArr[i] = max;
            }

            Day5Methods.PrintArray(maxArr);
 
        }

        public static void Q20()
        {
            int[,,] arr = SectionVMethods.CreateRnd3DIntArr(3, 8, 5, 0, 100);

            int dim0 = arr.GetLength(0), dim1 = arr.GetLength(1), dim2 = arr.GetLength(2);
            double[,] avgArr = new double[dim0, dim1];

            for (int i =0; i < dim0; i++)
            {
                for (int j=0; j<dim1; j++)
                {
                    double sum = 0;
                    for (int k = 0; k < dim2; k++)
                    {
                        sum += arr[i, j, k];
                    }
                    avgArr[i, j] = sum / dim2;
                }
            }

            Day5Methods.Print2DArray(avgArr);
        }

        //Methods
        public static void Q21()
        {

            int triangleType = Day5Methods.ReadInteger("Enter the type of triangle you want (1 - 4)");
            int triangleHeight = Day5Methods.ReadInteger("Enter the height you want: ");

            SectionVMethods.PrintTriangle(triangleType, triangleHeight);
        }

        public static void Q22()
        {
            Console.WriteLine("Test extend string array");
            string[] strArr = new string[] { "a", "2", "3" };
            Console.WriteLine(String.Join(",", strArr));
            Console.WriteLine(String.Join(",", SectionVMethods.ResizeArray(strArr, 8)));
            Console.WriteLine();

            Console.WriteLine("Test reduce string array");
            Console.WriteLine(String.Join(",", strArr));
            Console.WriteLine(String.Join(",", SectionVMethods.ResizeArray(strArr, 2)));
            Console.WriteLine();

            Console.WriteLine("Test extend string array");
            int[] intArr= new int[] {1, 2, 3};
            Console.WriteLine(String.Join(",", intArr));
            Console.WriteLine(String.Join(",", SectionVMethods.ResizeArray(intArr, 8)));
            Console.WriteLine();

            Console.WriteLine("Test reduce string array");
            Console.WriteLine(String.Join(",", intArr));
            Console.WriteLine(String.Join(",", SectionVMethods.ResizeArray(intArr, 2)));
            Console.WriteLine();
        }

        public static void Q23()
        {
            Console.WriteLine("Reassign integers between two variables using ref");
            int a = 1, b = 10;
            Console.WriteLine("{0}\t{1}", a, b);
            SectionVMethods.Reassign(ref a, ref b);
            Console.WriteLine("{0}\t{1}", a, b);
        }

    }

    class SectionVMethods
    {
        public static int[,,] CreateRnd3DIntArr(int dim0, int dim1, int dim2, int minVal, int maxVal)
        {
            int[,,] arr = new int[dim0, dim1, dim2];
            Random r = new Random();

            for (int i=0; i < dim0; i++)
            {
                for (int j=0; j < dim1; j++)
                {
                    for (int k=0; k < dim2; k++)
                    {
                        arr[i, j, k] = r.Next(minVal, maxVal);
                    }
                }
            }

            return arr;
        }

        public static void PrintTriangle(int type, int height)
        {
            Console.WriteLine("Printing asterisk triangles\n");

            if (type == 1)

            {
                for (int i = 1; i <= height; i++)
                {
                    Console.WriteLine(new String('*', i));
                }
            }
            else if (type == 2)
            {
                for (int i = 1; i <= height; i++)
                {
                    Console.WriteLine(new String('*', i).PadLeft(Console.WindowWidth - 1));
                }
            }
            else if (type ==3)
            {
                for (int i = height; i >= 1; i--)
                {
                    Console.WriteLine(new String('*', i));
                }
            }
            else if (type == 4)
            {
                for (int i = height; i >= 1; i--)
                {
                    Console.WriteLine(new String('*', i).PadLeft(Console.WindowWidth - 1));
                }
            }
        }

        public static object[] ResizeArray(object[] arr, int len)
        {
            object[] newArr = new object[len];

            for (int i = 0; i < Math.Min(arr.Length, len); i++)
            {
                newArr[i] = arr[i];
            }


            return newArr;
        }

        public static int[] ResizeArray(int[] arr, int len)
        {
            int[] newArr = new int[len];

            for (int i = 0; i < Math.Min(arr.Length, len); i++)
            {
                newArr[i] = arr[i];
            }


            return newArr;
        }

        public static void Reassign(ref int max, ref int min)
        {
            int temp = Math.Min(max, min);
            max = Math.Max(max, min);
            min = temp;
        }
    }
}
