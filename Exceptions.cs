using System;
namespace oops
{

    class NegativeNumberException : Exception
    {
        public NegativeNumberException(string message) : base(message) { }
    }

    class Exceptions
    {
        static void Main(String [] args)
        {
            try
            {
                
                Console.Write("Enter First Name: ");
                string firstName = Console.ReadLine();

                Console.Write("Enter Last Name: ");
                string lastName = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName))
                {
                    throw new Exception("First Name and Last Name should not be empty.");
                }
                if (!IsAlphabetic(firstName) || !IsAlphabetic(lastName))
                {
                    throw new Exception("First Name and Last Name should only contain alphabets.");
                }
                int[] marks = new int[3];
                for (int i = 0; i < 3; i++)
                {
                    Console.Write($"Enter marks for subject {i + 1}: ");
                    string input = Console.ReadLine();

                    try
                    {
                        marks[i] = int.Parse(input); 
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Invalid input! Please enter only integers.");
                        i--;
                        continue;
                    }

                    
                    if (marks[i] < 0)
                    {
                        throw new NegativeNumberException("Marks cannot be negative.");
                    }
                }

                
                Console.WriteLine("\nStudent Details:");
                Console.WriteLine($"Name: {firstName} {lastName}");
                Console.WriteLine($"Marks: {marks[0]}, {marks[1]}, {marks[2]}");
            }
            catch (NegativeNumberException ex)
            {
                Console.WriteLine("Custom Exception: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

      
        static bool IsAlphabetic(string str)
        {
            foreach (char c in str)
            {
                if (!char.IsLetter(c))
                    return false;
            }
            return true;
        }
    }
}
