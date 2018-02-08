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
            
            for (int i = 0; i <= finalPos; i++)
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
