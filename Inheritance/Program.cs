using System;
namespace oops
{
    class Person
    {
      
        private string _firstName;
        private string _lastName;
        private string _emailAddress;
        private DateTime _dateOfBirth;


        public Person(string firstName, string lastName, string email, DateTime dob)
        {
            _firstName = firstName;
            _lastName = lastName;
            _emailAddress = email;
            _dateOfBirth = dob;
        }


        public bool IsAdult
        {
            get
            {
                return (DateTime.Now.Year - _dateOfBirth.Year) > 18 ||
                       ((DateTime.Now.Year - _dateOfBirth.Year) == 18 &&
                        DateTime.Now.Date >= _dateOfBirth.AddYears(18));
            }
        }

        public string SunSign
        {
            get
            {
                int day = _dateOfBirth.Day;
                int month = _dateOfBirth.Month;
                return month switch
                {
                    1 => (day < 20) ? "Capricorn" : "Aquarius",
                    2 => (day < 19) ? "Aquarius" : "Pisces",
                    3 => (day < 21) ? "Pisces" : "Aries",
                    4 => (day < 20) ? "Aries" : "Taurus",
                    5 => (day < 21) ? "Taurus" : "Gemini",
                    6 => (day < 21) ? "Gemini" : "Cancer",
                    7 => (day < 23) ? "Cancer" : "Leo",
                    8 => (day < 23) ? "Leo" : "Virgo",
                    9 => (day < 23) ? "Virgo" : "Libra",
                    10 => (day < 23) ? "Libra" : "Scorpio",
                    11 => (day < 22) ? "Scorpio" : "Sagittarius",
                    12 => (day < 22) ? "Sagittarius" : "Capricorn",
                    _ => "Unknown"
                };
            }
        }

        public bool IsBirthDay
        {
            get
            {
                return (DateTime.Now.Day == _dateOfBirth.Day &&
                        DateTime.Now.Month == _dateOfBirth.Month);
            }
        }

        public string ScreenName
        {
            get
            {
                string shortFirst = _firstName.Length >= 3 ? _firstName.Substring(0, 3) : _firstName;
                string shortLast = _lastName.Length >= 2 ? _lastName.Substring(0, 2) : _lastName;
                return shortFirst.ToLower() + shortLast.ToLower() + _dateOfBirth.ToString("ddMMyy");
            }
        }
    }


    class Employee : Person
    {
        public double Salary { get; set; }

        public Employee(string firstName, string lastName, string email, DateTime dob, double salary)
            : base(firstName, lastName, email, dob)
        {
            Salary = salary;
        }
    }

    class Program 
    {
        static void Main(string[] args)
        {
            Employee emp = new Employee("Hari", "Joe", "hari.joe@example.com", new DateTime(1980, 5, 25), 50000);

            Console.WriteLine("Is Adult: " + emp.IsAdult);
            Console.WriteLine("Sun Sign: " + emp.SunSign);
            Console.WriteLine("Is Birthday Today: " + emp.IsBirthDay);
            Console.WriteLine("Screen Name: " + emp.ScreenName);
            Console.WriteLine("Salary: " + emp.Salary);
        }
    }
}

