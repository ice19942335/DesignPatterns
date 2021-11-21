using System;

namespace StepwiseBuilder
{
    public enum CarType
    {
        Sedan,
        Crossover
    }
    
    public class Car
    {
        public CarType Type;
        public int WheelSize;
    }

    public interface ISpecifyCarType
    {
        ISpecifyWheelSize OfType(CarType type);
    }
    
    public interface ISpecifyWheelSize
    {
        IBuildCar WithWheels(int size);
    }
    
    public interface IBuildCar
    {
        public Car Build();
    }

    public class CarBuilder
    {
        /// <summary>
        /// Why do we need a private Impl class? To make sure that it is never exposed in a public way.
        /// </summary>
        private class Impl :
            ISpecifyCarType,
            ISpecifyWheelSize,
            IBuildCar
        {
            private Car _car = new Car();
            
            public ISpecifyWheelSize OfType(CarType type)
            {
                _car.Type = type;
                return this;
            }

            public IBuildCar WithWheels(int size)
            {
                switch (_car.Type)
                {
                    case CarType.Crossover when size < 17 || size > 20: 
                    case CarType.Sedan when size < 15 || size > 17: 
                        throw new ArgumentException($"Wrong size of wheel for {_car.Type}");
                }

                _car.WheelSize = size;
                return this;
            }

            public Car Build()
            {
                return _car;
            }
        }
        
        public static ISpecifyCarType Create()
        {
            return new Impl();
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            var car = CarBuilder.Create()   // ISpecifyCarType
                .OfType(CarType.Crossover)  // ISpecifyWheelSize
                .WithWheels(18)         // IBuildCar
                .Build();
        }
    }
}