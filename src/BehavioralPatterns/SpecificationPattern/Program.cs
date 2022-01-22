using System;
using System.Collections.Generic;

namespace SpecificationPattern
{
    public interface IEmployeeSpecification
    {
        bool IsSatisfiedBy(Employee employee);
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

    public class Employee
    {
        public string Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Department { get; set; }

        public int EmployedYear { get; set; }
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
        static void Main(string[] args)
        {
            Employee employee1 = new Employee {LastName = "Jones", FirstName = "Fidel", Department = "Maths", EmployedYear = 2017};
            Employee employee2 = new Employee {LastName = "Jenkins", FirstName = "Francis", Department = "Software", EmployedYear = 2018};
            Employee employee3 = new Employee {LastName = "Smith", FirstName = "Sam", Department = "Maths", EmployedYear = 2018};
            Employee employee4 = new Employee {LastName = "Wilson", FirstName = "Michael", Department = "Software", EmployedYear = 2017};
            Employee[] employees = {employee1, employee2, employee3, employee4};

            Console.WriteLine("Software Department");
            List<Employee> softwareEmployees = GetEmployee.GetEmployeeBy(new EmployeeDepartmentSpecification("Software"), employees);
            foreach (var employee in softwareEmployees)
            {
                Console.WriteLine(employee.FirstName);
            }

            Console.WriteLine();

            Console.WriteLine("Employed in 2017");
            List<Employee> employedIn2017 = GetEmployee.GetEmployeeBy(new EmployeeEmployedYearSpecification(2017), employees);
            foreach (var employee in employedIn2017)
            {
                Console.WriteLine(employee.FirstName);
            }

            Console.ReadKey();
        }
    }
}