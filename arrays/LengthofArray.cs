using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
     class LengthofArray
    {
        static void Main(string[] args)
            {
                int[] arr = { 10, 20, 30, 40, 50 };
                int count = 0;

                foreach (int item in arr)
                {
                    count++;
                }

                Console.WriteLine("Number of elements in the array: " + count);
            }
        }

    }
