using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
     class DigitChecker
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a number");
            int Number =int.Parse( Console.ReadLine());
            Console.WriteLine("Enter a digit ");
            int Digit =int.Parse( Console.ReadLine());
            if (Number < 9999 && Digit <9)
            {
                if (Digit == Number % 10)
                {
                    Console.WriteLine("Given digit is in unit's place");
                }
                else if (Digit == (Number / 10) % 10)
                {
                    Console.WriteLine("Given digit is in ten's place");
                }
                else if (Digit == (Number / 100) % 10)
                {
                    Console.WriteLine("Given digit is in hundred's place");
                }
                else if (Digit == (Number / 1000) % 10)
                {
                    Console.WriteLine("Given digit is in thousand's place");
                }
                else
                {
                    Console.WriteLine("The Entered Digit is not present in the number");
                }
            }
            else
            {
                Console.WriteLine("you have entered a large digit or last number, Enter correct number and digit");
            }
        }
    }
}
