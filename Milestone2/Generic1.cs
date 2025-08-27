using System;
using System.Collections;
namespace Milestone2
{
    class Employee1
    {
        public string EmployeeName { get; set; }
        public int EmployeeID { get; set; }
        public double Salary { get; set; }
    }

    class Generic1
    {
        static void Main()
        {
            SortedList employees = new SortedList();

            employees.Add(2, new Employee1 { EmployeeID = 2, EmployeeName = "Anita", Salary = 35000 });
            employees.Add(1, new Employee1 { EmployeeID = 1, EmployeeName = "Ravi", Salary = 30000 });

            Console.WriteLine("All Employees in SortedList:");
            foreach (DictionaryEntry entry in employees)
            {
                Employee1 e = (Employee1)entry.Value;
                Console.WriteLine($"{e.EmployeeID} - {e.EmployeeName} - {e.Salary}");
            }
        }
    }
}


