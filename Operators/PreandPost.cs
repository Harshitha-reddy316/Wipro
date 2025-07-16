using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class PreandPost
    {
        static void Main(string[] args)
        {
            int num1, num2;

            Console.Write("Enter value of num1: ");
            num1 = int.Parse(Console.ReadLine());

            Console.Write("Enter value of num2: ");
            num2 = int.Parse(Console.ReadLine());

            int preIncrement = ++num1;
            num2 = preIncrement;
            Console.WriteLine("\nAfter Pre-increment:");
            Console.WriteLine("num1 = " + num1);
            Console.WriteLine("num2 = " + num2);

            Console.Write("\nRe-enter num1: ");
            num1 = int.Parse(Console.ReadLine());

            Console.Write("Re-enter num2: ");
            num2 = int.Parse(Console.ReadLine());

            int postIncrement = num1++;
            num2 = postIncrement;
            Console.WriteLine("\nAfter Post-increment:");
            Console.WriteLine("num1 = " + num1);
            Console.WriteLine("num2 = " + num2);

    
            Console.WriteLine("\nBefore Swap: num1 = " + num1 + ", num2 = " + num2);
            int temp = num1;
            num1 = num2;
            num2 = temp;
            Console.WriteLine("After Swap: num1 = " + num1 + ", num2 = " + num2);
        }
    }

}
