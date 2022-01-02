using System;
using System.Reflection.Metadata;

namespace FactoryMethod
{
    public enum CoordinatesSystem
    {
        Cartesian,
        Polar
    }
    
    public class Point
    {
        private double _x, _y;
        
        // Factory method
        public static Point NewCartesianPoint(double x, double y)
        {
            return new Point(x, y);
        }

        public static Point NewPolarPoint(double rho, double theta)
        {
            return new Point(rho * Math.Cos(theta), rho * Math.Sin(rho));
        }
        
        private Point(double x, double y)
        {
            _x = x;
            _y = y;
        }

        public override string ToString()
        {
            return $"{nameof(_x)}: {_x}, {nameof(_y)}: {_y}";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var point = Point.NewPolarPoint(1.0, Math.PI / 2);
            Console.WriteLine(point);
        }
    }
}