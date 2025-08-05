using System;
using System.Collections;
namespace Milestone2
{
    // Employee class
    public class Employee
    {
        public string EmployeeName { get; set; }
        public int EmployeeID { get; set; }
        public double Salary { get; set; }

        public Employee(string name, int id, double salary)
        {
            EmployeeName = name;
            EmployeeID = id;
            Salary = salary;
        }
    }

    // Employee Data Access Layer
    public class EmployeeDAL
    {
        private ArrayList employees = new ArrayList();

        // Add Employee
        public bool AddEmployee(Employee e)
        {
            employees.Add(e);
            return true;
        }

        // Delete Employee by ID
        public bool DeleteEmployee(int id)
        {
            foreach (Employee emp in employees)
            {
                if (emp.EmployeeID == id)
                {
                    employees.Remove(emp);
                    return true;
                }
            }
            return false;
        }

        // Search Employee by ID
        public string SearchEmployee(int id)
        {
            foreach (Employee emp in employees)
            {
                if (emp.EmployeeID == id)
                {
                    return emp.EmployeeName;
                }
            }
            return null;
        }

        // Get All Employees
        public Employee[] GetAllEmployees()
        {
            return (Employee[])employees.ToArray(typeof(Employee));
        }
    }

    // Test Program
    public class Program
    {
        public static void Main()
        {
            EmployeeDAL dal = new EmployeeDAL();

            // Adding Employees
            dal.AddEmployee(new Employee("Alice", 101, 50000));
            dal.AddEmployee(new Employee("Bob", 102, 60000));
            dal.AddEmployee(new Employee("Charlie", 103, 55000));

            // Searching Employee
            Console.WriteLine("Search ID 102: " + dal.SearchEmployee(102));

            // Deleting Employee
            Console.WriteLine("Deleting ID 101: " + dal.DeleteEmployee(101));

            // Display all Employees
            Console.WriteLine("\nAll Employees:");
            foreach (Employee emp in dal.GetAllEmployees())
            {
                Console.WriteLine($"ID: {emp.EmployeeID}, Name: {emp.EmployeeName}, Salary: {emp.Salary}");
            }
        }
    }
}

