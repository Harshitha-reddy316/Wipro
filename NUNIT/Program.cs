using System;

namespace ConsoleCalculator
{
    public class Calculator
    {
        public double Add(double a, double b) => a + b;
        public double Subtract(double a, double b) => a - b;
        public double Multiply(double a, double b) => a * b;
        public double Divide(double a, double b)
        {
            if (b == 0)
                throw new DivideByZeroException("Cannot divide by zero.");
            return a / b;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Calculator calc = new Calculator();
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("\n*** Calculator ***");
                Console.WriteLine("1. Add");
                Console.WriteLine("2. Subtract");
                Console.WriteLine("3. Multiply");
                Console.WriteLine("4. Divide");
                Console.WriteLine("5. Exit");
                Console.Write("Choose an option: ");

                int choice;
                bool isValid = int.TryParse(Console.ReadLine(), out choice);

                if (!isValid || choice < 1 || choice > 5)
                {
                    Console.WriteLine("Invalid input. Try again.");
                    continue;
                }

                if (choice == 5)
                {
                    exit = true;
                    break;
                }

                Console.Write("Enter first number: ");
                double num1 = Convert.ToDouble(Console.ReadLine());
                Console.Write("Enter second number: ");
                double num2 = Convert.ToDouble(Console.ReadLine());

                try
                {
                    double result = choice switch
                    {
                        1 => calc.Add(num1, num2),
                        2 => calc.Subtract(num1, num2),
                        3 => calc.Multiply(num1, num2),
                        4 => calc.Divide(num1, num2),
                        _ => 0
                    };
                    Console.WriteLine($"Result: {result}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }

            Console.WriteLine("Goodbye!");
        }
    }
}
