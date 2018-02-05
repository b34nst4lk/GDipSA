using System;
using System.Reflection;

namespace Workshop
{
    class Workshop
    {
        static void Main()
        {
            bool keepGoing = true;
            while (keepGoing) {
                GetAndRunExercise();

                Console.Write("Enter 'y' if you want to run another exercise: ");
                string keepGoingStr = Console.ReadLine();
                if (keepGoingStr != "y")
                {
                    keepGoing = false;
                }
                Console.Clear();
            }
            Console.WriteLine("Bye~");
        }

        static void GetAndRunExercise()
        {
            // Asks user which section and question number to run
            Console.WriteLine("Please enter the Section alphabet");
            string exercise = Console.ReadLine().ToUpper();
            Console.WriteLine("Please enter the question number");
            string question = Console.ReadLine();

            string classToCall = "Workshop.Section" + exercise;
            string methodToCall = "Q" + question;

            // Get the class and method to call
            Type t = Type.GetType(classToCall);
            MethodInfo method = t.GetMethod(methodToCall, BindingFlags.Public | BindingFlags.Static);
            Console.Clear();


            // Run the class method until user chooses to stop
            Console.WriteLine("Running {0} of {1} \n", methodToCall, classToCall);

            bool keepGoing = true;
            while (keepGoing)
            {
                Console.WriteLine("\n+++++++++++++++++++++++++++++++++++++++++++++++\n\n\n");
                method.Invoke(null, null);
                Console.WriteLine("\n\n\n+++++++++++++++++++++++++++++++++++++++++++++++\n");

                Console.Write("Enter 'y' if you wish to repeat the exercise: ");
                string keepGoingStr = Console.ReadLine();
                if (keepGoingStr != "y") {
                    keepGoing = false;     
                }
            }

            Console.WriteLine("Completed run");
        }
    }
}
