using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapesProject
{
    class App
    {
        static void Main()
        {
            //Triangles
            Console.WriteLine("Test triangles");
            Triangle tri = new Triangle();
            Console.WriteLine("Triangle's angles: {0}", String.Join(",", tri.Angles));
            Console.WriteLine("Triangle's sides: {0}", String.Join(",", tri.Sides));           
            Console.WriteLine("Triangle's area: {0}", String.Join(",", tri.Area));
            Console.WriteLine("Triangle's perimeter: {0}", String.Join(",", tri.Perimeter));


            // Rectangle
            Console.WriteLine("Test rectangles");
            Rectangle r1 = new Rectangle();
            Console.WriteLine("R1's length: {0}", r1.Length);
            Console.WriteLine("R1's breadth: {0}", r1.Breadth);
            Console.WriteLine("R1's area: {0}", r1.Area);
            Console.WriteLine("R1's perimeter: {0}", r1.Perimeter);

            Console.WriteLine();
            Rectangle r2 = new Rectangle(1, 2);
            Console.WriteLine("Check that rectangle length and breadth assigned properly");
            Console.WriteLine("R2's length: {0}", r2.Length); // should be 2
            Console.WriteLine("R2's breadth: {0}", r2.Breadth); // should be 1

            Console.WriteLine();
            Console.WriteLine("Check that breadth is set properly if longer than length");
            r2.Breadth = 10;
            Console.WriteLine("R2's length: {0}", r2.Length); // should be 10
            Console.WriteLine("R2's breadth: {0}", r2.Breadth); // should be 2

            Console.WriteLine();
            Console.WriteLine("Check that length is set properly if shorter than breadth");
            r2.Length = 1;
            Console.WriteLine("R2's length: {0}", r2.Length); // should be 2
            Console.WriteLine("R2's breadth: {0}", r2.Breadth); // should be 1

            Console.WriteLine();
            Console.WriteLine("Check normal assignment of length and breadth");
            r2.Length = 5;
            r2.Breadth = 2;
            Console.WriteLine("R2's length: {0}", r2.Length); // should be 5
            Console.WriteLine("R2's breadth: {0}", r2.Breadth); // should be 2
        }
    }
}
