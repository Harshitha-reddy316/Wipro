using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class ArrayOperations
    {

        static void Main()
        {
            int[] arr = new int[10];

            Console.WriteLine("Enter 10 integers:");
            for (int i = 0; i < 10; i++)
            {
                Console.Write($"Element {i + 1}: ");
                arr[i] = int.Parse(Console.ReadLine());
            }


            for (int i = 0; i < 10 - 1; i++)
            {
                for (int j = 0; j < 10 - i - 1; j++)
                {
                    if (arr[j] < arr[j + 1])
                    {
                        int temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
                }
            }

            int sum = 0;
            int min = arr[0];
            int max = arr[0];

            for (int i = 0; i < 10; i++)
            {
                sum += arr[i];
                if (arr[i] < min)
                    min = arr[i];
                if (arr[i] > max)
                    max = arr[i];
            }
            Console.WriteLine("\nElements in descending order:");
            for (int i = 0; i < 10; i++)
            {
                Console.Write(arr[i] + " ");
            }

            Console.WriteLine("\n\nMinimum value: " + min);
            Console.WriteLine("Maximum value: " + max);
            Console.WriteLine("Sum of all elements: " + sum);
        }
    }

}
