using System;
using System.Linq;

namespace Workshop
{
    class SectionG
    {
        public static void Q1() 
        {
            // Get and validate user input
            bool isValidSalesData = false;
            string salesStr = "";

            while (!isValidSalesData)
            {
                Console.WriteLine("Enter the data from Jan to Dec in order and separated by commas (,).");
                salesStr = Console.ReadLine();
                isValidSalesData = IsValidSalesData(salesStr);
            }

            // Transform user string to array
            string[] salesStrArr = salesStr.Split(',');
            double[] salesArr = new double[12];

            for (int i= 0; i < 12; i++)
            {
                salesArr[i] = Double.Parse(salesStrArr[i]);
            }

            // Get sales statistics
            double maxSales = salesArr.Max();
            double minSales = salesArr.Min();
            double avgSales = salesArr.Average();

            // Months array
            string[] months = new string[12] { "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" };

            // Get months with maximum sales
            string maxMonths = "";
            for (int i = 0; i < 12; i++)
            {
                if (salesArr[i] == maxSales)
                {
                    maxMonths += months[i] + ", "; 
                }
            }
            maxMonths = maxMonths.Trim();
            maxMonths = maxMonths.TrimEnd(',');

            // Get months with minimum sales
            string minMonths = "";
            for (int i = 0; i < 12; i++)
            {
                if (salesArr[i] == minSales)
                {
                    minMonths += months[i] + ", "; 
                }
            }
            minMonths = minMonths.Trim();
            minMonths = minMonths.TrimEnd(',');

            // Print output
            Console.WriteLine("Months with highest sales: {0}", maxMonths);
            Console.WriteLine("Months with lowest sales: {0}", minMonths);
            Console.WriteLine("Average sales: {0:C}", avgSales);
        }

        public static void Q2()
        {
            // Get and validate user input
            bool isNumericArray = false;
            string[] inputStrArr = { };

            while (!isNumericArray)
            {
                Console.WriteLine("Enter the data from Jan to Dec in order and separated by commas (,).");
                string inputStr = Console.ReadLine();
                inputStrArr = inputStr.Split(',');
                isNumericArray = IsNumericArray(inputStrArr);
            }

            // Convert to numeric array
            double[] inputArr = new double[inputStrArr.Length];
            for (int i=0;i<inputStrArr.Length; i++)
            {
                inputArr[i] = Double.Parse(inputStrArr[i]);
            }

            // Sort
            double[] outputArr = NumericSelectionSort(inputArr, true);
            Console.WriteLine(string.Join(",", outputArr));
        }

        public static void Q3()
        {
            // Test data
            int[,] marks = new int[,] {
                                        {56, 84, 68, 29},
                                        {94, 73, 31, 96},
                                        {41, 63, 36, 90},
                                        {99, 9, 18, 17},
                                        {62, 3, 65, 75},
                                        {40, 96, 53, 23},
                                        {81, 15, 27, 30},
                                        {21, 70, 100, 22},
                                        {88, 50, 13, 12},
                                        {48, 54, 52, 78},
                                        {64, 71, 67, 25},
                                        {16, 93, 46, 72},
                                    };

            // Print Total score of each student
            Console.WriteLine("Total score of students.\n");

            for (int i = 0; i < marks.GetLength(0); i++)
            {
                int total_marks = 0;
                for (int j=0; j<marks.GetLength(1); j++)
                {
                    total_marks += marks[i, j];
                }
                Console.WriteLine("Student {0}: {1}", i, total_marks);
            }

            // Print average score of each subject
            Console.WriteLine("Average score of each subject.\n");
            Console.WriteLine(" Subject | Average | Std Dev ");
            Console.WriteLine("-----------------------------");
            double overall_total = 0;
            for (int j = 0; j < marks.GetLength(1); j++)
            {
                double total_marks = 0;
                int i;

                for (i = 0; i < marks.GetLength(0); i++)
                {
                    total_marks += marks[i, j];
                }
                overall_total += total_marks;
                double average_marks = total_marks / i;

                double total_squared_diff = 0;

                for (i = 0; i < marks.GetLength(0); i++)
                {
                    total_squared_diff += Math.Pow(marks[i, j] - average_marks, 2);
                }
                double std_dev_marks = total_squared_diff / i;
                Console.WriteLine(" {0} \t   {1:0.00}     {2:0.00}", j, average_marks, std_dev_marks);
            }

            double overall_average = overall_total / marks.Length;
            Console.WriteLine("\n\nOverall Average: {0:0.00}", overall_average);
        }

        public static void Q4()
        {
            Console.WriteLine(string.Join(",", CreateRndIntArr(10, 0, 10)));
        }

        public static void Q5()
        {
            // Get user input
            Console.WriteLine("Please enter the number you wish to find: ");
            string inputStr = Console.ReadLine();
            int input = Int32.Parse(inputStr);

            // Create and print range
            int[] range = new int[10];
            range = CreateRndIntArr(10, 0, 10);

            Console.WriteLine(string.Join(",", range));

            // Find in range
            Console.WriteLine(IntPosInArr(range, input));
        }

        public static void Q6()
        {
            // Create and print range
            double[] range = new double[10];
            range = CreateRndDoubleArr(10, 0, 10);
            Console.WriteLine("Unsorted array");
            Console.WriteLine(string.Join(",", range));
            Console.WriteLine();

            // Sort ascending
            Console.WriteLine("Sorted array ascending");
            Console.WriteLine(string.Join(",", NumericSelectionSort(range)));

            Console.WriteLine("Sorted array descending");
            Console.WriteLine(string.Join(",", NumericSelectionSort(range, true)));
        }

        public static void Q7()
        {
            // Create arrays
            string[] name = new string[7] { "Bob", "Alice", "Eli", "Gina", "Charlie", "Dennis", "Frank" };
            int[] score = new int[7] { 90, 100, 76, 88, 120, 80, 66 };

            // Sort
            Array.Sort(name, score);
            for (int i=0; i<name.Length; i++)
            {
                Console.WriteLine("{0}\t{1}", name[i], score[i]);
            }
        }

        public static void Q8()
        {
            // create and print range
            int[,] range = new int[10, 10];
            range = CreateRnd2dIntArr(10, 10, 0, 100);
            for (int i = 0; i < range.GetLength(0); i++)
            {
                for (int j = 0; j < range.GetLength(1); j++)
                {
                    Console.Write(range[i, j] + "\t");
                }
                Console.Write("\n");
            }

            // Ask for input
            Console.WriteLine("Please enter the value you wish to find: ");
            string inputStr = Console.ReadLine();
            int input = Int32.Parse(inputStr);


            // Search
            int posI = -1;
            int posJ = -1;

            for (int i = 0; i < range.GetLength(0); i++)
            {
                for (int j = 0; j < range.GetLength(1); j++)
                {
                    if (range[i, j] == input)
                    {
                        posI = i;
                        posJ = j;
                        break;
                    }
                }
            }

            Console.WriteLine(posI + ", " + posJ);
        }

        public static int[] CreateRndIntArr(int arr_len, int from, int to)
        {
            Random rnd = new Random();
            int[] range = new int[arr_len];
            for (int i=0; i < arr_len; i++)
            {
                range[i] = rnd.Next(from, to);
            }
            return range;
        }

        public static int[,] CreateRnd2dIntArr(int arr_len1, int arr_len2, int from, int to)
        {
            Random rnd = new Random();
            int[,] range = new int[arr_len1, arr_len2];
            for (int i=0; i < arr_len1; i++)
            {
                for (int j = 0; j < arr_len2; j++)
                {
                    range[i, j] = rnd.Next(from, to);
                }
            }
            return range;
        }

        public static double[] CreateRndDoubleArr(int arr_len, int from, int to)
        {
            Random rnd = new Random();
            double[] range = new double[arr_len];
            for (int i=0; i < arr_len; i++)
            {
                range[i] = rnd.NextDouble() * (to - from) + from;
            }
            return range;
        }

        public static int IntPosInArr(int[] arr, int target)
        {
            int pos = -1;

            for (int i=0; i<arr.Length; i++)
            {
                if (arr[i] == target)
                {
                    pos = i;
                    break;
                }
            }

            return pos;
        }
        
        public static bool IsNumericArray(string[] inputArr)
        {

            bool isNumericArray = true;
            string err = ""; // Used for collating validation errors

            // Check for non-numeric values 
            foreach (string input in inputArr)
            {
                bool isDouble = Double.TryParse(input, out double output);
                if (!isDouble)
                {
                    isNumericArray= false;
                    err += "- Data should be numeric";
                    break;
                }
            }

            // Print error messages
            if (err != "")
            {
                Console.WriteLine("\n" + err);
            }

            return isNumericArray;
        }

        public static bool IsValidSalesData(string input)
        {

            bool validSalesData = true;
            string err = ""; // Used for collating validation errors

            string[] salesStrArr = input.Split(',');

            // Check if correct number of months
            if (salesStrArr.Length != 12)
            {
                err += "- There should be 12 data sales data point\n";
                validSalesData = false;
            }

            // Check for non-numeric values
            validSalesData = IsNumericArray(salesStrArr);

            // Print error messages
            if (err != "")
            {
                Console.WriteLine("\n" + err);
            }

            return validSalesData;
        }

        public static double[] NumericSelectionSort(double[] inputArr, bool descending=false)
        {
            double temp;
            int pos, finalPos = inputArr.Length - 1;
            
            for (int i = 0; i <= finalPos - 1; i++)
            {
                temp = inputArr[i];
                pos = i;
                for (int j = i; j <= finalPos; j++)
                {
                    if (inputArr[j] < temp)
                    {
                        pos = j;
                        temp = inputArr[j];
                    }
                }
                inputArr[pos] = inputArr[i];
                inputArr[i] = temp;
            }

            if (descending)
            {
                double[] tempArr = new double[finalPos+1];
                Array.Copy(inputArr, tempArr, finalPos+1);

                for (int i = 0; i <= finalPos; i++)
                {
                    inputArr[i] = tempArr[finalPos - i];
                }
            }
            return inputArr;
        }
    }
}
