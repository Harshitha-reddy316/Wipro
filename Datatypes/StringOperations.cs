
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class StringOperations

    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a string:");
            string original = Console.ReadLine();

            string reversed = "";
            for (int i = original.Length - 1; i >= 0; i--)
            {
                reversed += original[i];
            }
            Console.WriteLine("1) Reversed String: " + reversed);

            if (original.Length >= 2)
            {
                string substring = original.Substring(1);
                Console.WriteLine("2) Substring from 2nd character: " + substring);
            }
            else
            {
                Console.WriteLine("2) String is too short to extract from 2nd position.");
            }
            Console.WriteLine("Enter a character to replace with '$':");
            char toReplace = Convert.ToChar(Console.ReadLine());
            string replaced = original.Replace(toReplace, '$');
            Console.WriteLine("3) After replacement: " + replaced);
            string copy = original; 
            string modifiedCopy = copy + "_modified"; 

            Console.WriteLine("4) Original string: " + original);
            Console.WriteLine("   Modified copy: " + modifiedCopy);

            Console.ReadLine();
        }
    }

}

