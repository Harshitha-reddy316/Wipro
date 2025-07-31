using System;
namespace oops
{
    class MathOperations
    {
        // Add methods
        public int Add(int a, int b)
        {
            return a + b;
        }

        public int Add(int a, int b, int c)
        {
            return a + b + c;
        }

        // Multiply methods
        public int Multiply(int a, int b)
        {
            return a * b;
        }

        public int Multiply(int a, int b, int c)
        {
            return a * b * c;
        }

        // Subtract methods
        public int Subtract(int a, int b)
        {
            return a - b;
        }

        public int Subtract(int a, int b, int c)
        {
            return a - b - c;
        }

        // Divide methods
        public int Divide(int a, int b)
        {
            return a / b;
        }

        public int Divide(int a, int b, int c)
        {
            return (a / b) / c;
        }
    }

    class Maths
    {
        static void Main()
        {
            MathOperations math = new MathOperations();

            Console.WriteLine("Add 2 numbers: " + math.Add(5, 3));
            Console.WriteLine("Add 3 numbers: " + math.Add(5, 3, 2));

            Console.WriteLine("Multiply 2 numbers: " + math.Multiply(4, 3));
            Console.WriteLine("Multiply 3 numbers: " + math.Multiply(4, 3, 2));

            Console.WriteLine("Subtract 2 numbers: " + math.Subtract(10, 4));
            Console.WriteLine("Subtract 3 numbers: " + math.Subtract(10, 4, 2));

            Console.WriteLine("Divide 2 numbers: " + math.Divide(20, 5));
            Console.WriteLine("Divide 3 numbers: " + math.Divide(20, 5, 2));
        }
    }
}

