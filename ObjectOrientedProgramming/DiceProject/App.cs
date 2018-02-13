using System;

namespace DiceProject
{
    class App
    {
        static void Main()
        {
            Dice d1 = new Dice();
            Dice d2 = new Dice(20);

            Console.WriteLine("Test instatiation and construction");
            Console.WriteLine("d1 number of faces: {0}", d1.GetNoOfFaces()); // should be 6
            Console.WriteLine("d2 number of faces: {0}", d2.GetNoOfFaces()); // should be 20
            Console.WriteLine();

            Console.WriteLine("Test rolling of dice");
            int[] d1Arr = new int[20];
            int[] d2Arr = new int[20];
            for (int i = 0; i < 20; i++)
            {
                d1.Throw();
                d2.Throw();
                d1Arr[i] = d1.GetFace();
                d2Arr[i] = d2.GetFace();
            }

            Console.WriteLine("d1 dice rolls: {0}", String.Join(",", d1Arr));
            Console.WriteLine("d2 dice rolls: {0}", String.Join(",", d2Arr));
            Console.WriteLine();

            Console.WriteLine("Check probability");
            int count = 0;
            for (int i=0; i < 20000; i++)
            {
                d2.Throw();
                if (d2.GetFace() == 8)
                {
                    count++;
                }
            }
            double average = count / 20000.0;
            Console.WriteLine("Probability of getting 8 on 20 sided dice: {0:0.000000000}", average);
        }
    }
}
