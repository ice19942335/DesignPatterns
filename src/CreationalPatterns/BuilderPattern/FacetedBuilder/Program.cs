using System;

namespace FacetedBuilder
{
    public class Person
    {
        // Address
        public string StreetAddress, PostCode, City;
        
        // Employment
        public string CompanyName, Position;
        public decimal AnnualIncome;

        public override string ToString()
        {
            return $"{nameof(StreetAddress)}: {StreetAddress}, {nameof(PostCode)}: {PostCode}, {nameof(City)}: {City}, {nameof(CompanyName)}: {CompanyName}, {nameof(Position)}: {Position}, {nameof(AnnualIncome)}: {AnnualIncome}";
        }
    }

    public class PersonBuilder // Facade
    {
        // Reference!
        protected Person Person = new Person();

        public PersonJobBuilder Works => new PersonJobBuilder(Person);
        public PersonAddressBuilder Lives => new PersonAddressBuilder(Person);

        public static implicit operator Person(PersonBuilder pb)
        {
            return pb.Person;
        }
    }

    public class PersonJobBuilder : PersonBuilder
    {
        public PersonJobBuilder(Person person)
        {
            this.Person = person;
        }

        public PersonJobBuilder At(string companyName)
        {
            this.Person.CompanyName = companyName;
            return this;
        }

        public PersonJobBuilder AsA(string position)
        {
            this.Person.Position = position;
            return this;
        }
        
        public PersonJobBuilder Earning(decimal amount)
        {
            this.Person.AnnualIncome = amount;
            return this;
        }
    }
    
    public class PersonAddressBuilder : PersonBuilder
    {
        public PersonAddressBuilder(Person person)
        {
            this.Person = person;
        }

        public PersonAddressBuilder At(string streetAddress)
        {
            this.Person.StreetAddress = streetAddress;
            return this;
        }

        public PersonAddressBuilder WithPostCode(string postCode)
        {
            this.Person.PostCode = postCode;
            return this;
        }
        
        public PersonAddressBuilder In(string city)
        {
            this.Person.City = city;
            return this;
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            var pb = new PersonBuilder();
            Person person = pb
                .Lives.At("123 London Road")
                    .In("London")
                    .WithPostCode("SW12AC")
                .Works.At("Fabricam")
                    .AsA("Egeneer")
                    .Earning(123000);
            
            Console.WriteLine(person);
        }
    }
}