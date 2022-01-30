using System;

namespace CompositeSpecifications
{
    public class Employee
    {
        public string Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Department { get; set; }

        public int EmployedYear { get; set; }
    }

    public interface ISpecification<T>
    {
        bool IsSatisfiedBy(T item);
    }

    public abstract class Specification<T> : ISpecification<T>
    {
        public static Specification<T> operator &(Specification<T> left, Specification<T> right) =>
            new PredicateSpecification<T>(t => left.IsSatisfiedBy(t) && right.IsSatisfiedBy(t));

        public static Specification<T> operator |(Specification<T> left, Specification<T> right) =>
            new PredicateSpecification<T>(t => left.IsSatisfiedBy(t) || right.IsSatisfiedBy(t));

        public static Specification<T> operator !(Specification<T> left) =>
            new PredicateSpecification<T>(t => !left.IsSatisfiedBy(t));

        public static bool operator true(Specification<T> specification) => false;

        public static bool operator false(Specification<T> specification) => false;


        public abstract bool IsSatisfiedBy(T item);
    }

    public class PredicateSpecification<T> : Specification<T>
    {
        private Predicate<T> predicate;

        public PredicateSpecification(Predicate<T> predicate)
        {
            this.predicate = predicate;
        }

        public override bool IsSatisfiedBy(T item)
        {
            return predicate(item);
        }
    }

    class Program
    {
        private static readonly Employee[] Employees =
        {
            new Employee {FirstName = "Fidel", LastName = "Jones", Department = "Maths", EmployedYear = 2017},
            new Employee {FirstName = "Francis", LastName = "Jenkins", Department = "Software", EmployedYear = 2018},
            new Employee {FirstName = "Sam", LastName = "Smith", Department = "Maths", EmployedYear = 2016},
            new Employee {FirstName = "Michael", LastName = "Wilson", Department = "Software", EmployedYear = 2017},
            new Employee {FirstName = "Alfred", LastName = "Williams", Department = "Sales", EmployedYear = 2016}
            
        };

        static void Main(string[] args)
        {
            PredicateSpecification<Employee> firstnameFidel = new PredicateSpecification<Employee>(e => e.FirstName == "Fidel");
            PredicateSpecification<Employee> firstnameFrancis = new PredicateSpecification<Employee>(e => e.FirstName == "Francis");
            PredicateSpecification<Employee> firstnameSam = new PredicateSpecification<Employee>(e => e.FirstName == "Sam");

            ISpecification<Employee> compositeSpecification1 = firstnameFidel || firstnameFrancis || firstnameSam;

            Console.WriteLine("Filtered by FirstName: operator ||");
            foreach (var employee in Employees)
            {
                if (compositeSpecification1.IsSatisfiedBy(employee))
                {
                    Console.WriteLine($"{nameof(employee.FirstName)}: {employee.FirstName} {nameof(employee.LastName)}: {employee.LastName}");
                }
            }
            
            PredicateSpecification<Employee> lastnameJones = new PredicateSpecification<Employee>(e => e.LastName == "Jones");
            PredicateSpecification<Employee> employedYearLessThan2018 = new PredicateSpecification<Employee>(e => e.EmployedYear < 2018);
            PredicateSpecification<Employee> departmentMaths = new PredicateSpecification<Employee>(e => e.Department == "Maths");
            PredicateSpecification<Employee> departmentSoftware = new PredicateSpecification<Employee>(e => e.Department == "Software");
            PredicateSpecification<Employee> departmentSales = new PredicateSpecification<Employee>(e => e.Department == "Sales");

            ISpecification<Employee> compositeSpecification2 = employedYearLessThan2018 && departmentMaths || departmentSales;
            
            Console.WriteLine();
            Console.WriteLine("Filtered by FirstName, EmployedYear, Department: operator &&");
            foreach (var employee in Employees)
            {
                if (compositeSpecification2.IsSatisfiedBy(employee))
                {
                    Console.WriteLine($"{nameof(employee.FirstName)}: {employee.FirstName} {nameof(employee.LastName)}: {employee.LastName}");
                }
            }

            Console.ReadKey();
        }
    }
}