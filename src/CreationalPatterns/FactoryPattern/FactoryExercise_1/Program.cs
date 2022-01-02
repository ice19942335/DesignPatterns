using System;

namespace FactoryExercise_1
{
    public class Person
    {
        public int Id { get; set; }
        
        public string Name { get; set; }

        public override string ToString()
        {
            return $"Id: {Id}, Name: {Name}";
        }
    }

    public class PersonFactory
    {
        private static int Counter { get; set; } = 0;

        public Person CreatePerson(string name)
        {
            return new Person
            {
                Id = Counter++,
                Name = name
            };
        }
    }
    
    
    class Program
    {
        static void Main(string[] args)
        {
            var factory = new PersonFactory();
            var person = factory.CreatePerson("John");
            var person2 = factory.CreatePerson("Alex");
            Console.WriteLine(person);
            Console.WriteLine(person2);
        }
    }
}