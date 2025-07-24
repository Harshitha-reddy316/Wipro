using System;
namespace ConsoleApp1
{
    class TestRandomHelper
    {
        static void Main()
        {
            int randomInt = RandomHelper.RandInt(1, 10);
            double randomDouble = RandomHelper.RandDouble(1, 10);

            Console.WriteLine("Random Integer between 1 and 10 (inclusive): " + randomInt);
            Console.WriteLine("Random Double between 1 and 10 (exclusive): " + randomDouble.ToString("F2"));
        }
    }
    class RandomHelper
    {

        
        private static Random random = new Random();

        public static int RandInt(int a, int b)
        {
            return random.Next(a, b + 1); 
        }

        public static double RandDouble(int a, int b)
        {
            return random.NextDouble() * (b - a) + a; 
        }
    }

}


