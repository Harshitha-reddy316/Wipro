using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
    {
        class Square
        {
            // Private field to store the side length of the square
            private double sideOfSquare;

            // Method to get the side length from the user
            public void GetDetails()
            {
                Console.Write("Enter the side length of the square: ");
                string input = Console.ReadLine();
                sideOfSquare = double.Parse(input);
            }

            // Method to calculate the area of the square
            public double Area()
            {
                return sideOfSquare * sideOfSquare;
            }

            // Main method - Entry point of the program
            static void Main(string[] args)
            {
                Square square = new Square();       // Create object of Square
                square.GetDetails();                // Get side length from user
                double area = square.Area();        // Calculate area
                Console.WriteLine("Area of the square: " + area);  // Display result
            }
        }
    }

