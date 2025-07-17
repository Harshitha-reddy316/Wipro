using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class UsernameAndPass
    {
        static void Main(string[] args)
        {
            string CorrectUsername = "harshitha";
            string CorrectPassword = "Password";
            int maxchances = 3;

            for(int i=1; i <= maxchances; i++)
            {
                Console.WriteLine("Enter your Username");
                string Username = Console.ReadLine();
                Console.WriteLine("Enter your Password");
                string Password = Console.ReadLine();
                if(Username == CorrectUsername && Password == CorrectPassword)
                {
                    Console.WriteLine(" Login Successfully ");
                    return;
                }
                else
                {
                    Console.WriteLine($"Enter correct Username and Password , you are left with attempts: {maxchances - i} ");
                }
            }
            Console.WriteLine("You have been rejected");
        }
    }
}
