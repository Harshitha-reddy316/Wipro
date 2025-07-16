using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
     class IncrementString
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a String ");
            string input = Console.ReadLine();
            string result = " ";

            for(int i=0 ; i < input.Length; i++)
            {
                char ch = input[i];
                char incremented = (char)(ch + 1);
                if (char.IsLower(incremented)){
                    incremented = char.ToUpper(incremented);
                }
                else if(char.IsUpper(incremented)){
                    incremented = char.ToLower(incremented);
                }
                result = result + incremented;
            }
            Console.WriteLine(result);
        }
    }
}
