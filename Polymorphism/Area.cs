using System;
namespace oops
{
    class CalculatingArea
    {
        // Area of Circle
        public double Area(double radius)
        {
            return 3.14 * radius * radius;
        }

        // Area of Rectangle
        public int Area(int length, int width)
        {
            return length * width;
        }

        // Area of Triangle
        public double Area(double b, double h)
        {
            return 0.5 * b * h;
        }
    }

    class Area
    {
        static void Main()
        {
            CalculatingArea calc = new CalculatingArea();

            Console.WriteLine("Area of Circle: " + calc.Area(5.0));
            Console.WriteLine("Area of Rectangle: " + calc.Area(4, 6));
            Console.WriteLine("Area of Triangle: " + calc.Area(4.0, 3.0));
        }
    }
}
