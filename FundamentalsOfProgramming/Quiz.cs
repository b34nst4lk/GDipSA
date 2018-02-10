using System;

namespace Workshop
{
    class SectionQ
    {
        public static void Q2()
        {
            // Get length in cm
            Console.Write("Please enter then length in cm: ");
            string cmStr = Console.ReadLine();
            double cm = Double.Parse(cmStr);

            //Convert to inch
            double inch = Math.Round(cm / 2.54, 3);

            // Print result
            Console.WriteLine(inch);
        }

        public static void Q3()
        {
            // Get number of gadget
            Console.WriteLine("Welcome to ISS Gadget Shop");
            Console.Write("Number of items to purchase: ");
            string noOfItemsStr = Console.ReadLine();
            int noOfItems = Int32.Parse(noOfItemsStr);

            // validate
            if (noOfItems < 0)
            {
                Console.WriteLine("\nInvalid number of items.");
            }
            else
            {
                // calculate amount after discount
                double amount = noOfItems * 500;
                double finalPrice;

                if (amount > 6000)
                {
                    finalPrice = amount * 0.92; // 8% discount
                }
                else if (amount > 3000 && amount <= 6000)
                {
                    finalPrice = amount * 0.95; // 5% discount
                }
                else if (amount > 2000 && amount <= 3000)
                {
                    finalPrice = amount * 0.97; // 3% discount
                }
                else
                {
                    finalPrice = amount;
                }

                // Print discounted amount
                Console.WriteLine("\n Please pay {0:C}", finalPrice);
            }
        }

        public static void Q4()
        {
            // hardcoded pin
            string pin = "123456";

            // ask user for pin
            Console.WriteLine("Welcome to the Bank of ISS");

            int attempts = 3;
            bool correctPin = false;

            while (!correctPin && attempts > 0)
            {
                attempts--;
                Console.Write("Enter your PIN: ");
                string entry = Console.ReadLine();
                Console.WriteLine();

                correctPin = entry == pin;
                if (!correctPin && attempts > 0)
                {
                    Console.WriteLine("Incorrect PIN. Please try again. You have {0} more attempts", attempts);
                }
            }

            // print result
            if (correctPin)
            {
                Console.WriteLine("PIN accepted. You can access your account now.");
            }
            else
            {
                Console.WriteLine("Too many wrong PIN entries. Your account is now locked");
            }

        }

        public static void Q5()
        {
            int[,] theArray = new int[,]
               {
                { 5, 3 },
                { 2, 9 },
                { 2, 9 },
                { 5, 1 },
                { 7, 1 },
                { 8, 3 },
                { 0, 3 },
                { 2, 2 },
                { 9, 7 }
               };

            int count = 0;

            Console.Write("Please enter a number (0-9): ");
            int input = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < theArray.GetLength(0); i++)
            {
                for (int j = 0; j < theArray.GetLength(1); j++)
                {
                    if (theArray[i,j] == input)
                    {
                        count++;
                    }
                }
            }

            if (count == 0)
            {
                Console.WriteLine("There is no {0} in the array.", input);
            }
            else
            {
                Console.WriteLine("The number of {0} is {1}", input, count);
            }
        }
    }
}
