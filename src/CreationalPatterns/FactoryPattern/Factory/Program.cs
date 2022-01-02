using System;

namespace Factory
{
    public enum CoordinatesSystem
    {
        Cartesian,
        Polar
    }

    // Factory is the separate component that knows how to construct the object in a particular way.
    public static class PointFactory
    {
        public static Point NewCartesianPoint(double x, double y)
        {
            return new Point(x, y);
        }

        public static Point NewPolarPoint(double rho, double theta)
        {
            return new Point(rho * Math.Cos(theta), rho * Math.Sin(rho));
        }
    }

    public class Point
    {
        private double _x, _y;

        public Point(double x, double y)
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
            var point = PointFactory.NewCartesianPoint(1.0, Math.PI / 2);
            Console.WriteLine(point);
        }
    }
}