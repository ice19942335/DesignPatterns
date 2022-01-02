using System;

namespace PointExample
{
    public enum CoordinatesSystem
    {
        Cartesian,
        Polar
    }
    
    public class Point
    {
        private double x, y;

        // Problem that we can't overload constructors with the same signature but with different parameters names;
        
        /// <summary>
        /// Initializes a point from EITHER cartesian or polar
        /// </summary>
        /// <param name="a">x if cartesian, rho if polar</param>
        /// <param name="b"></param>
        /// <param name="system"></param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public Point(double a, double b,
            CoordinatesSystem system = CoordinatesSystem.Cartesian)
        {
            switch (system)
            {
                case CoordinatesSystem.Cartesian:
                    x = a;
                    y = b;
                    break;
                case CoordinatesSystem.Polar:
                    x = a * Math.Cos(b);
                    x = a * Math.Sin(b);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(system), system, null);
            }
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            
        }
    }
}