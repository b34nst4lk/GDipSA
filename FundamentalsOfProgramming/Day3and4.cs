using System;
using System.Linq;

namespace Workshop
{
    class SectionD
    {
        public static void Q1()
        {
            // Repeatedly ask user to enter an integer until he enters 88
            int number = 0;

            while (number != 88)
            {
                Console.Write("Enter a number: ");
                string numberStr = Console.ReadLine();
                number = Int32.Parse(numberStr);
            }

            Console.WriteLine("Lucky you...");
        }

        public static void Q2()
        {
            // Get two numbers and find HCF and LCM using Euclid's algorithm
            Console.Write("Enter the first number: ");
            string num1Str = Console.ReadLine();
            int num1 = Int32.Parse(num1Str);

            Console.Write("Enter the second number: ");
            string num2Str = Console.ReadLine();
            int num2 = Int32.Parse(num2Str);

            int largerNum = Math.Max(num1, num2);
            int smallerNum = Math.Min(num1, num2);
            int tempNum;

            // Reduce both numbers till they are equal or below zero
            while (smallerNum != largerNum)
            {
                tempNum = largerNum - smallerNum;

                if (smallerNum < tempNum)
                {
                    largerNum = tempNum;
                }
                else
                {
                    largerNum = smallerNum;
                    smallerNum = tempNum;
                }

                if (smallerNum <= 0) break;
            }

            // Calculate HCF and LCM
            int HCF;
            if (smallerNum > 0)
            {
                HCF = smallerNum;
           }
            else
            {
                HCF = 1;
            }

            int LCM = num1 * num2 / HCF;
        
            Console.WriteLine("The HCF is {0}", HCF);
            Console.WriteLine("The LCM is {0}", LCM);
        }

        public static void Q3()
        {
            //Create random number
            Random r = new Random();
            int ans = r.Next(0, 9);

            //Start guessing
            Console.Write("Guess a number! : ");
            string guessStr = Console.ReadLine();
            int guess = Int32.Parse(guessStr);
            int attempts  = 1;

            while (guess != ans)
            {
                Console.Write("Try again! : ");
                guessStr = Console.ReadLine();
                guess = Int32.Parse(guessStr);
                attempts++; 
            }

            if (attempts <=  2)
            {
                Console.WriteLine("You're a wizard!");
            }
            else if (attempts <= 5)
            {
                Console.WriteLine("You are a good guess");
            }
            else
            {
                Console.WriteLine("You are lousy!");
            }
        }

        public static void Q4()
        {
            // Get user to enter number
            Console.Write("Choose a number: ");
            string numStr = Console.ReadLine();
            double num = Double.Parse(numStr);

            Random r = new Random();
            double guess = r.Next(1, (int) num);

            while (Math.Abs(num - Math.Pow(guess, 2)) > 0.00001)
            {
                guess = (guess + num / guess) / 2;
            }

            Console.Write("The estimated square root of {0} is {1}", num, Math.Round(guess, 5));
        }
    }
    
    class SectionE
    {
        public static void Q1()
        {
            // Get a number
            Console.WriteLine("Please enter an int ");
            int input = -1;
            while (input < 0)
            {
                Console.Write("Int should be >= 0: ");
                string inputStr = Console.ReadLine();
                input = Int32.Parse(inputStr);
            }
            int factorial = 1;

            // increment method
            for (int i = 1; i <= input; i++)
            {
                factorial = factorial * i;
            }
            Console.WriteLine("Using increment method, you get {0}", factorial);

            factorial = 1;

            // decrement method
            for (int i = input ; i > 0; i--)
            {
                factorial = factorial * i;
            }
            Console.WriteLine("Using decrement method, you get {0}", factorial);
        }

        public static void Q2()
        {
            Console.WriteLine(" NO\t\tINVERSE\t\tSQUARE ROOT\tSQUARE");
            Console.WriteLine("-----------------------------------------------------------------");

            for (int i = 1; i <= 10; i++)
            {
                double inverse = 1.0 / i;
                double sqrt = Math.Sqrt(i);
                double square = Math.Pow(i,2);

                Console.WriteLine(" {0:0.0}\t\t {1:0.0##}\t\t {2:0.0##}\t\t {3:0.0##}", i, inverse, sqrt, square);
            }
        }

        public static void Q3()
        {
            // Get int from user
            int input = GetPositiveInteger();

            // Check if prime.
            if (IsPrime(input))
            {
                Console.WriteLine("{0} is prime", input);
            }
            else 
            {
                Console.WriteLine("{0} is not prime", input);
            }
        }
       
        public static void Q4()
        {
            // Get int from user
            int input = GetPositiveInteger();

            if (IsPerfect(input))
            {
                Console.WriteLine("{0} is a perfect number", input);
            }
            else
            {
                Console.WriteLine("{0} is not a perfect number", input);
            }
        }

        public static void Q5()
        {
            // print all primes from 5 to 10000
            for (int i = 5; i <= 10000; i += 2)
            {
                if (IsPrime(i))
                {
                    Console.WriteLine(i);
                }
            }
        }
        
        public static void Q6()
        {
            // print all perfect numbers from 1 to 1000
            for (int i = 1; i <= 1000; i++)
            {
                if (IsPerfect(i))
                {
                    Console.WriteLine(i);
                }
            }
        }

        
        public static bool IsPrime(int input)
        {
            // Used in Q3 and Q5
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

        public static bool IsPerfect(int input)
        {
            // used in Q4 and Q6
            int sum = 0;
            for (int i = 1; i < input; i++)
            {
                if (input % i == 0)
                {
                    sum += i;
                }
            }

            return sum == input;
        }

        public static int GetInteger(string message = "Please enter an integer: ")
        {
            bool isInt = false;
            int rv = 0;

            do
            {
                Console.Write(message);
                string inputStr = Console.ReadLine();
                isInt = Int32.TryParse(inputStr, out rv);
            }
            while (isInt == false) ;

            return rv;
        }

        public static int GetPositiveInteger()
        {
            int rv = 0;
            do
            {
                rv = GetInteger("Please enter a positive integer: ");
            }
            while (rv < 0) ;
            return rv;
        }

    } 

    class SectionF
    {
        public static void Q1()
        {
            // Get string from user.
            Console.WriteLine("Please enter a message: ");
            string input = Console.ReadLine().ToUpper();

            // Set up arrays
            char[] vowels = new char[5] { 'A', 'E', 'I', 'O', 'U' };
            int[] counts = new int[5] { 0, 0, 0, 0, 0 };

            char[] inputChr = input.ToCharArray();
            
            for (int i = 0; i < 5; i++)
            {
                foreach (char chr in inputChr)
                {
                    if (chr == vowels[i])
                    {
                        counts[i]++;
                    }
                }
            }

            int totalVowels = counts.Sum();

            Console.WriteLine("Total Vowels: {0}", totalVowels);

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("{0}: {1}", vowels[i], counts[i]);
            }


        }

        public static void Q2()
        {
             // Get string from user.
            Console.WriteLine("Please enter a message: ");
            string input = Console.ReadLine();
            string upperInput = input.ToUpper();

            if (IsPalindrome(input))
            {
                Console.WriteLine("{0} is a palindrome.", input);
            }
            else
            {
                Console.WriteLine("{0} is not a palindrome.", input);
            }

            if (IsPalindrome(upperInput))
            {
                Console.WriteLine("Ignoring casing, {0} is a palindrome.", input);
            }
            else
            {
                Console.WriteLine("Ignoring casing, {0} is not a palindrome.", input);
            }
        }

        public static void Q3()
        {
            // Get string from user.
            Console.WriteLine("Please enter a message: ");
            string input = Console.ReadLine();
            string upperInput = input.ToUpper();

            string cleanedInput = RemoveNonLettersFromString(upperInput);

            if (IsPalindrome(cleanedInput))
            {
                Console.WriteLine("{0} is a palindrome.", input);
            }
            else
            {
                Console.WriteLine("{0} is not a palindrome.", input);
            }
        }

        public static void Q4()
        {
            // Get string from user.
            Console.WriteLine("Please enter a message: ");
            string input = Console.ReadLine().ToLower();

            string output = input.Substring(0, 1).ToUpper();
            for (int i = 1; i < input.Length; i++)
            {
                string currentChr = input.Substring(i, 1);
                string previousChr = input.Substring(i - 1, 1);

                if (previousChr == " ")
                {
                    output += currentChr.ToUpper();
                }
                else
                {
                    output += currentChr;
                }
            }

            Console.WriteLine("\n{0}", output);
        }

        public static void Q5()
        {
            string[] students = new string[5] { "John", "Venkat", "Mary", "Victor", "Betty" };
            int[] marks = new int[5] { 63, 29, 75, 82, 55 };

            Array.Sort(marks, students);

            Console.WriteLine("Report One\n");
            Console.WriteLine("Name\t|\tMark");          
            Console.WriteLine("----------------");          

            for (int i = 4; i >= 0; i--)
            {
                Console.WriteLine("{0}\t|\t{1}", students[i], marks[i]);
            }

            Console.WriteLine("----------------");
            
            Array.Sort(students, marks);

            Console.WriteLine("\n\nReport Two\n");
            Console.WriteLine("Name\t|\tMark");          
            Console.WriteLine("----------------");          

            for (int i =0; i < 5; i++)
            {
                Console.WriteLine("{0}\t|\t{1}", students[i], marks[i]);
            }

            Console.WriteLine("----------------");
        }

        public static void Q6()
        {
            // Get string from user.
            bool isValidMatric = false;
            while (!isValidMatric)
            {
                Console.WriteLine("\nPlease enter a matric number: ");
                string matric = Console.ReadLine().ToUpper();
                isValidMatric = IsValidMatric(matric);
            }
            Console.WriteLine("Valid");
        }
        
        public static string RemoveNonLettersFromString(string input)
        {
            string rv = "";
            for (int i = 0; i < input.Length; i++)
            {
                if (Char.IsLetter(input, i))
                {
                    rv += input[i];                   
                }
            }
            return rv;
        }

        public static bool IsPalindrome(string input)
        {
            int lastPos = input.Length - 1;
            int noOfLoops = input.Length / 2;
            bool isPalindrome = true;

            for (int i = 0; i < noOfLoops && isPalindrome; i++)
            {
                if (input.Substring(i, 1) != input.Substring(lastPos - i, 1))
                {
                    isPalindrome = false;
                }
            }
            return isPalindrome;
        }

        public static bool IsValidMatric(string input)
        {
            // 
            string[] checksum = { "O", "P", "Q", "R", "S" };
            input = input.ToUpper();
            bool isValidMatric = true;
            string err = "";

            // Verify length and lettering
            if (input.Length != 7)
            {
                err += "- Length of matriculation number should be 7.\n";
                isValidMatric = false;
            }
            else if (!checksum.Contains(input.Substring(6, 1)))
            {
                err += "- Matriculation number should end with 'O', 'P', 'Q', 'R' or 'S'.\n";
                isValidMatric = false;
            } 

            if (input.Substring(0, 1) != "A")
            {
                err += "- Matriculation number should start with 'A'.\n";
                isValidMatric = false;
            }

            // Verify checksum
            if (isValidMatric)
            {
                int multiplier = 6;
                double sum = 0;
                foreach (char chr in input.Substring(1, 5))
                {
                    sum += Char.GetNumericValue(chr) * multiplier;
                    multiplier--;
                }

                string correctChecksum = checksum[Convert.ToInt32(sum) % 5];
                if (input.Substring(6,1) != correctChecksum)
                {
                    err += "- Invalid matriculation number";
                    isValidMatric = false;
                }
            }

            if (!isValidMatric)
            {
                Console.WriteLine(err);
            }

            return isValidMatric;
        }
    }
}

