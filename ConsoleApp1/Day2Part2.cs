using System;

namespace Workshop
{
    class SectionC
    {
        public static void Q1()
        {
            // Get name and gentder
            Console.WriteLine("What is your name?");
            string name = Console.ReadLine();

            Console.WriteLine("What is your gender? M/F?");
            string sex = Console.ReadLine().ToUpper();

            // Get salutation base on gender
            string salutation = "";
            if (sex == "M")
            {
                salutation = "Mr. ";
            }
            else if (sex == "F")
            {
                salutation = "Ms. ";
            }

            Console.WriteLine("\t\t Good Morining {0}{1}", salutation, name);
        }

        public static void Q2()
        {
            // Get name, gender and age
            Console.WriteLine("What is your name?");
            string name = Console.ReadLine();

            Console.WriteLine("What is your gender? M/F?");
            string sex = Console.ReadLine().ToUpper();

            Console.WriteLine("What is your age?");
            string ageStr = Console.ReadLine();
            int age = Int16.Parse(ageStr);
            if (age < 0)
            {

                Console.WriteLine("Age cannot be less than 0.");
            }
            else
            {
                // Get salutation base on gender and age
                string salutation = "";

                if (sex == "M" && age < 40)
                {
                    salutation = "Mr. ";
                }
                else if (sex == "F" && age < 40)
                {
                    salutation = "Ms. ";
                }
                if (sex == "M" && age >= 40)
                {
                    salutation = "Uncle ";
                }
                else if (sex == "F" && age >= 40)
                {
                    salutation = "Aunty ";
                }

                Console.WriteLine("\t\t Good Morining {0}{1}", salutation, name);
            }
        }

        public static void Q3()
        {
            // Get marks from user
            Console.Write("What is your grade?: ");
            string marksStr = Console.ReadLine();
            int marks = Convert.ToInt32(marksStr);

            // Check if valid marks, if invalid, raise error and exit, else return grade
            if (marks < 0 || marks > 100)
            {
                Console.WriteLine("Marks should be from 0 to 100.");
            }
            else
            {
                string grade = "";
                if (marks >= 80 && marks <= 100)
                {
                    grade = "A";
                }
                else if (marks >= 60 && marks <= 79)
                {
                    grade = "B";
                }
                else if (marks >= 40 && marks <= 59)
                {
                    grade = "C";
                }
                else
                {
                    grade = "F";
                }

                Console.WriteLine("You scored {0} marks which is {1} grade", marks, grade);
            }
        }

        public static void Q4()
        {
            // Get distance travelled
            Console.Write("How long was your cab ride in kilometers? : ");
            string distanceStr = Console.ReadLine();
            double distanceInKm = Double.Parse(distanceStr);
            double distance = Math.Ceiling(distanceInKm * 10);

            // Caculate fare
            double maxFareForFirst85 = 0.04 * 85;
            double flatFee = 2.4;
            double first85Fee = Math.Min((distance - 5) * 0.04, maxFareForFirst85); // First 500m is not included.
            double subsequentFee = Math.Max((distance - 5 - 85) * 0.05, 0); // Fee after the first 500m and the subsequent 8500m

            double totalFee = flatFee + first85Fee + subsequentFee;

            Console.Write("Your total travel fee is {0:C}", totalFee);
        }

        public static void Q5()
        {
            // Get 3 digit number from user
            Console.WriteLine("Please enter a 3 digit number");
            string numberStr = Console.ReadLine();
            int number = Int32.Parse(numberStr);

            // Split string into its individual digits
            char[] numberArr = numberStr.ToCharArray();
            double sum = 0;
            Console.WriteLine(numberArr);
            foreach (char numChr in numberArr)
            {
                double num = Char.GetNumericValue(numChr);
                sum = sum + Math.Pow(num, 3);
                Console.WriteLine(sum);
            }

            // Check if sum of cubes and number are equal and output accordingly
            if (sum == number)
            {
                Console.WriteLine("{0} is an Armstrong number", number);
            }
            else
            {
                Console.WriteLine("{0} is NOT an Armstrong number", number);
            }
        }

    }
}
