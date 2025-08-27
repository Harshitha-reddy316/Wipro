using System;
using System.Collections.Generic;
namespace Milestone2
{
    class generic3
    {
        static void Main()
        {
            string input = "Hello123 World45";
            List<char> alphaList = new List<char>();
            List<char> digitList = new List<char>();

            foreach (char c in input)
            {
                if (Char.IsLetter(c))
                    alphaList.Add(c);
                else if (Char.IsDigit(c))
                    digitList.Add(c);
            }

            alphaList.Sort();
            digitList.Sort();

            Console.WriteLine("Alphabets: " + string.Join(", ", alphaList));
            Console.WriteLine("Digits: " + string.Join(", ", digitList));
        }
    }
}
