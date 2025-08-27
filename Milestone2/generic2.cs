using System;
using System.Collections.Generic;

namespace Milestone2
{
    class Employee2
    {
        // Properties with default initialization
        public string EmployeeName { get; set; } = "";
        public int EmployeeID { get; set; }
        public double Salary { get; set; }
    }

    class generic2
    {
        static void Main()
        {
            // Create a generic list of employees
            List<Employee2> employees = new List<Employee2>
            {
                new Employee2 { EmployeeID = 1, EmployeeName = "Ravi", Salary = 30000 },
                new Employee2 { EmployeeID = 2, EmployeeName = "Anita", Salary = 35000 }
            };

            // Print all employees
            Console.WriteLine("All Employees from List:");
            foreach (Employee2 e in employees)
            {
                Console.WriteLine($"{e.EmployeeID} - {e.EmployeeName} - {e.Salary}");
            }
        }
    }
}

