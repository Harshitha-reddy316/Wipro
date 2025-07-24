using System;
namespace ConsoleApp1
{

    class EmployeeSalary
    {
        string EmployeeName;
        decimal BasicSalary, HRA, DA, Tax, GrossPay, netPay;
        public EmployeeSalary(string name, decimal salary)
        {
            EmployeeName = name;
            BasicSalary = salary;
        }

        public void CalculateNetPay()
        {
            HRA = 0.15m * BasicSalary;  
            DA = 0.10m * BasicSalary;   
            GrossPay = BasicSalary + HRA + DA;
            Tax = 0.08m * GrossPay;    
            netPay = GrossPay - Tax;
        }


        public void Display()
        {
            Console.WriteLine("\nEmployee Salary Structure:");
            Console.WriteLine($"Name       : {EmployeeName}");
            Console.WriteLine($"Basic Pay  : {BasicSalary:C}");
            Console.WriteLine($"HRA (15%)  : {HRA:C}");
            Console.WriteLine($"DA (10%)   : {DA:C}");
            Console.WriteLine($"Gross Pay  : {GrossPay:C}");
            Console.WriteLine($"Tax (8%)   : {Tax:C}");
            Console.WriteLine($"Net Pay    : {netPay:C}");
        }
        static void Main()
        {
            Console.Write("Enter Employee Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter Basic Salary: ");
            decimal salary = Convert.ToDecimal(Console.ReadLine());

            EmployeeSalary emp = new EmployeeSalary(name, salary);
            emp.CalculateNetPay();
            emp.Display();
        }
    }
}

