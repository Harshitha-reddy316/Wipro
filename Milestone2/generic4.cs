using System;
using System.Collections.Generic;
using System.IO;
namespace Milestone2
{
    class Employee4
    {
        public int EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public string Designation { get; set; }
        public DateTime JoiningDate { get; set; }
        public string DepartmentName { get; set; }
    }

    class EmployeeData
    {
        public List<Employee4> EmployeeInfo { get; set; } = new List<Employee4>();

        public void AddEmployee(Employee4 e)
        {
            EmployeeInfo.Add(e);
            SaveToFile();
        }

        private void SaveToFile()
        {
            using (StreamWriter sw = new StreamWriter("employees.csv", true))
            {
                foreach (var e in EmployeeInfo)
                {
                    sw.WriteLine($"{e.EmployeeID},{e.EmployeeName},{e.Designation},{e.JoiningDate},{e.DepartmentName}");
                }
            }
            EmployeeInfo.Clear();
        }
    }

    class generic4
    {
        static void Main()
        {
            EmployeeData data = new EmployeeData();

            data.AddEmployee(new Employee4
            {
                EmployeeID = 1,
                EmployeeName = "Ravi",
                Designation = "Developer",
                JoiningDate = DateTime.Now,
                DepartmentName = "IT"
            });

            data.AddEmployee(new Employee4
            {
                EmployeeID = 2,
                EmployeeName = "Anita",
                Designation = "Tester",
                JoiningDate = DateTime.Now,
                DepartmentName = "QA"
            });

            Console.WriteLine("Employee data saved to employees.csv");
        }
    }
}

