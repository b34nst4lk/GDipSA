using System;
using System.Linq;

namespace ShapesProject
{
    class Triangle
    {
        // Attributes
        double[] sides = new double[3];
        double[] angles = new double[3];

        // Constructor. Generates a random right-angled triangle
        public Triangle()
        {
            Random r = new Random();
            angles[0] = 90;
            angles[1] = r.Next(1, 90);
            angles[2] = 90 - angles[1];

            sides[0] = r.Next(1, 100);
            sides[1] = sides[0] / Math.Tan(angles[1]);
            sides[2] = Math.Sqrt(Math.Pow(sides[0], 2) + Math.Pow(sides[1], 2));
        }

        // Get area
        public double Area
        {
            get
            {
                return sides[0] * sides[1] * 0.5;
            }
        }

        // Get perimeter
        public double Perimeter
        {
            get
            {
                return sides.Sum();
            }
        }

        // Get exterior angles
        public double[] ExteriorAngles
        {
            get
            {
                double[] rv = new double[3];
                for (int i = 0; i < 3; i++)
                {
                    rv[i] = 180 - angles[i];
                }
                return rv;
            }
        }

        // Get angles
        public double[] Angles
        {
            get
            {
                return angles;
            }
        }

        // Get sides
        public double[] Sides
        {
            get
            {
                return sides;
            }
        }
    }

    class Rectangle
    {
        // attributes
        double length;
        double breadth;

        // Constructors
        public Rectangle()
        {
            Random r = new Random();
            length = r.Next(1, 100);
            breadth = r.Next(1, Convert.ToInt32(length));
        }

        public Rectangle(double l, double b)
        {
            length = Math.Max(l,b);
            breadth = Math.Min(l,b);
        }

        // Properties
        public double Length
        {
            get
            {
                return length;
            }
            set
            {
                if (value < breadth)
                {
                    length = breadth;
                    breadth = value;
                }
                else
                {
                    length = value;
                }
            }
        }

        public double Breadth
        {
            get
            {
                return breadth;
            }
            set
            {
                if (value > length)
                {
                    breadth = length;
                    length = value;
                }
                else
                {
                    breadth = value;
                }
            }
        }

        public double Area
        {
            get
            {
                return length * breadth;
            }
        }

        public double Perimeter
        {
            get
            {
                return 2 * (length + breadth);
            }
        }
    }

}
