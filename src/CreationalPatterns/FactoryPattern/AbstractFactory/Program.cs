using System;
using System.Collections.Generic;

namespace AbstractFactory
{
    public interface IHotDrink
    {
        void Consume();
    }

    internal class Tea : IHotDrink
    {
        public void Consume()
        {
            Console.WriteLine("This tea is nice but I'd prefer it with milk.");
        }
    }
    
    internal class Coffee : IHotDrink
    {
        public void Consume()
        {
            Console.WriteLine("This coffee is sensational!");
        }
    }

    public interface IHotDrinkFactory
    {
        IHotDrink Prepare(int amount);
    }

    internal class TeaFactory : IHotDrinkFactory
    {
        public IHotDrink Prepare(int amount)
        {
            Console.WriteLine($"Put in a tea bag, boil water, pour {amount} ml, add lemon, enjoy!");
            return new Tea();
        }
    }
    
    internal class CoffeeFactory : IHotDrinkFactory
    {
        public IHotDrink Prepare(int amount)
        {
            Console.WriteLine($"Grind some beans, boil water, pour {amount} ml, add cream and sugar, enjoy!");
            return new Coffee();
        }
    }

    public class HotDrinkMachine
    {
        public enum AvailableDrinks
        {
            Coffee, Tea
        }
        
        private Dictionary<AvailableDrinks, IHotDrinkFactory> _factories
            = new Dictionary<AvailableDrinks, IHotDrinkFactory>();

        public HotDrinkMachine()
        {
            foreach (AvailableDrinks drink in Enum.GetValues(typeof(AvailableDrinks)))
            {
                var factory = (IHotDrinkFactory) Activator.CreateInstance(
                    Type.GetType("AbstractFactory." + Enum.GetName(typeof(AvailableDrinks), drink) + "Factory")
                );
                _factories.Add(drink, factory);
            }
        }

        public IHotDrink MakeDrink(HotDrinkMachine.AvailableDrinks drink, int amount)
        {
            return _factories[drink].Prepare(amount);
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            var machine = new HotDrinkMachine();
            var drink = machine.MakeDrink(HotDrinkMachine.AvailableDrinks.Tea, 100);
            drink.Consume();
        }
    }
}