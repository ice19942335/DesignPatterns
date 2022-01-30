using System;
using System.Collections.Generic;

namespace SpecificationPattern
{
    public interface IEmployeeSpecification
    {
        bool IsSatisfiedBy(Employee employee);
    }

    public class Employee
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Department { get; set; }

        public int EmployedYear { get; set; }
    }

    public class EmployeeDepartmentSpecification : IEmployeeSpecification
    {
        private readonly string _department;

        public EmployeeDepartmentSpecification(string department)
        {
            _department = department;
        }

        public bool IsSatisfiedBy(Employee employee)
        {
            return employee.Department.Equals(_department);
        }
    }

    public class EmployeeFirstNameSpecification : IEmployeeSpecification
    {
        private readonly string _name;

        public EmployeeFirstNameSpecification(string name)
        {
            _name = name;
        }

        public bool IsSatisfiedBy(Employee employee)
        {
            return employee.FirstName.Equals(_name);
        }
    }

    public class EmployeeEmployedYearSpecification : IEmployeeSpecification
    {
        private readonly int _year;

        public EmployeeEmployedYearSpecification(int year)
        {
            _year = year;
        }

        public bool IsSatisfiedBy(Employee employee)
        {
            return employee.EmployedYear.Equals(_year);
        }
    }

    public class GetEmployee
    {
        public static List<Employee> GetEmployeeBy(IEmployeeSpecification specification, Employee[] employees)
        {
            List<Employee> neededEmployees = new List<Employee>();

            foreach (Employee employee in employees)
            {
                if (specification.IsSatisfiedBy(employee))
                {
                    neededEmployees.Add(employee);
                }
            }

            return neededEmployees;
        }
    }

    class Program
    {
        private static readonly Employee[] Employees =
        {
            new() {FirstName = "Fidel", LastName = "Jones", Department = "Maths", EmployedYear = 2017},
            new() {FirstName = "Francis", LastName = "Jenkins", Department = "Software", EmployedYear = 2018},
            new() {FirstName = "Sam", LastName = "Smith", Department = "Maths", EmployedYear = 2016},
            new() {FirstName = "Michael", LastName = "Wilson", Department = "Software", EmployedYear = 2017},
            new() {FirstName = "Alfred", LastName = "Williams", Department = "Sales", EmployedYear = 2016}
        };

        static void Main(string[] args)
        {
            Console.WriteLine("Software Department:");
            List<Employee> softwareEmployees = GetEmployee.GetEmployeeBy(new EmployeeDepartmentSpecification("Software"), Employees);
            foreach (var employee in softwareEmployees)
            {
                Console.WriteLine($"{employee.FirstName} {employee.LastName}");
            }

            Console.WriteLine();

            Console.WriteLine("Employees named Fidel:");
            List<Employee> namedEmployees = GetEmployee.GetEmployeeBy(new EmployeeFirstNameSpecification("Fidel"), Employees);
            foreach (var employee in namedEmployees)
            {
                Console.WriteLine($"{employee.FirstName} {employee.LastName}");
            }

            Console.WriteLine();

            Console.WriteLine("Employed in 2017:");
            List<Employee> employedIn2017 = GetEmployee.GetEmployeeBy(new EmployeeEmployedYearSpecification(2017), Employees);
            foreach (var employee in employedIn2017)
            {
                Console.WriteLine($"{employee.FirstName} {employee.LastName}");
            }

            Console.ReadKey();
        }
    }
}