﻿using System;

namespace FluentBuilderInheritanceWithRecursiveGenerics
{
    public class Person
    {
        public string Name;
        public string Position;

        public class Builder : PersonJobBuilder<Builder>
        {
            
        }

        public static Builder New => new Builder();

        public override string ToString()
        {
            return $"{nameof(Name)}: {Name}, {nameof(Position)}: {Position}";
        }
    }
    
    public abstract class PersonBuilder
    {
        protected Person person = new Person();

        public Person Build() => person;
    }

    
    public class PersonInfoBuilder<TSelf>
        : PersonBuilder
        where TSelf : PersonInfoBuilder<TSelf>
    {
        public TSelf Called(string name)
        {
            person.Name = name;
            return (TSelf) this;
        }
    }

    public class PersonJobBuilder<TSelf> : PersonInfoBuilder<PersonJobBuilder<TSelf>>
        where TSelf : PersonJobBuilder<TSelf>
    {
        public TSelf WorksAsA(string position)
        {
            person.Position = position;
            return (TSelf) this;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var person = Person.New
                .Called("Aleksejs")
                .WorksAsA(".NET Developer")
                .Build();
            
            Console.WriteLine(person.ToString());
        }
    }
}