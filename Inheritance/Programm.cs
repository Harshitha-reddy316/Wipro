
using System;

namespace oops
{
    class Personn
    {
        public string firstName;
        public string lastName;
        public string email;
        public DateTime dob;

        public Personn(string fName, string lName, string mail, DateTime birthDate)
        {
            firstName = fName;
            lastName = lName;
            email = mail;
            dob = birthDate;
        }

        public string FullName()
        {
            return firstName + " " + lastName;
        }
    }

    // Interface
    interface IPayable
    {
        double CalculatePay();
    }

    // Derived class 1: HourlyEmployee
    class HourlyEmployee : Personn, IPayable
    {
        public double hoursWorked;
        public double payPerHour;

        public HourlyEmployee(string fName, string lName, string mail, DateTime birthDate,
                              double hours, double rate)
            : base(fName, lName, mail, birthDate)
        {
            hoursWorked = hours;
            payPerHour = rate;
        }

        public double CalculatePay()
        {
            return hoursWorked * payPerHour;
        }
    }

    // Derived class 2: PermanentEmployee
    class PermanentEmployee : Personn, IPayable
    {
        public double HRA;
        public double DA;
        public double Tax;
        public double NetPay;
        public double TotalPay;

        public PermanentEmployee(string fName, string lName, string mail, DateTime birthDate,
                                 double hra, double da, double tax)
            : base(fName, lName, mail, birthDate)
        {
            HRA = hra;
            DA = da;
            Tax = tax;
        }

        public double CalculatePay()
        {
            TotalPay = HRA + DA;
            NetPay = TotalPay - Tax;
            return NetPay;
        }
    }

    // Main Program
    class Programm
    {
        static void Main(string[] args)
        {
            // Test Hourly Employee
            HourlyEmployee hourlyEmp = new HourlyEmployee("John", "Doe", "john@example.com",
                                                         new DateTime(1990, 1, 1), 40, 20);
            Console.WriteLine("Hourly Employee: " + hourlyEmp.FullName());
            Console.WriteLine("Pay: " + hourlyEmp.CalculatePay());

            // Test Permanent Employee
            PermanentEmployee permEmp = new PermanentEmployee("Jane", "Smith", "jane@example.com",
                                                              new DateTime(1985, 5, 10), 5000, 2000, 1000);
            Console.WriteLine("\nPermanent Employee: " + permEmp.FullName());
            Console.WriteLine("Net Pay: " + permEmp.CalculatePay());
        }
    }
}

