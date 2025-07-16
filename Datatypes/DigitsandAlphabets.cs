using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
     class DigitsandAlphabets
    {
        static void Main(String[] args)
        {
            Console.WriteLine("Enter a String : ");
            string input = Console.ReadLine();

            int alphabetcount = 0;
            int digitcount = 0;

            for(int i = 0; i < input.Length; i++)
            {
                if (char.IsLetter(input[i]))
                {
                    alphabetcount++;

                }
                if (char.IsDigit(input[i]))
                {
                    digitcount++;
                }
            }
            Console.WriteLine("Number of Alphabets : " + alphabetcount);
            Console.WriteLine("Number of digits : " + digitcount);
        }
    }
}
