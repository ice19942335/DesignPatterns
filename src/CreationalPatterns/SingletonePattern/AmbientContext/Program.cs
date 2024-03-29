﻿using System.Text;

namespace AmbientContext;

public sealed class BuildingContext : IDisposable
{
    public int WallHeight;
    private static Stack<BuildingContext> _stack = new();

    static BuildingContext()
    {
        _stack.Push(new BuildingContext(0));
    }

    public BuildingContext(int wallHeight)
    {
        WallHeight = wallHeight;
        _stack.Push(this);
    }

    public static BuildingContext Current => _stack.Peek();

    public void Dispose()
    {
        if (_stack.Count > 1)
            _stack.Pop();
    }
}

public class Building
{
    public List<Wall> Walls { get; set; } = new();

    public override string ToString()
    {
        var sb = new StringBuilder();
        foreach (var wall in Walls)
            sb.AppendLine(wall.ToString());

        return sb.ToString();
    }
}

public struct Point
{
    private int _x, _y;

    public Point(int x, int y)
    {
        this._x = x;
        this._y = y;
    }

    public override string ToString()
    {
        return $"{nameof(_x)}: {_x}, {nameof(_y)}: {_y}";
    }
}

public class Wall
{
    public Point Start, End;
    public int Height;

    public Wall(Point start, Point end)
    {
        Start = start;
        End = end;
        Height = BuildingContext.Current.WallHeight;
    }

    public override string ToString()
    {
        return $"{nameof(Start)}: {Start}, {nameof(End)}: {End}, {nameof(Height)}: {Height}";
    }
}

class Program
{
    public static void Main(string[] args)
    {
        var house = new Building();
        
        // ground floor 3000
        using (new BuildingContext(3000))
        {
            house.Walls.Add(new Wall(new Point(0, 0), new Point(5000, 0)));
            house.Walls.Add(new Wall(new Point(0, 0), new Point(0, 4000)));

            using (new BuildingContext(3500))
            {
                // 1st floor 3500
                house.Walls.Add(new Wall(new Point(0, 0), new Point(6000, 0)));
                house.Walls.Add(new Wall(new Point(0, 0), new Point(0, 4000)));
            }

            // ground floor 3000
            house.Walls.Add(new Wall(new Point(5000, 0), new Point(5000, 4000)));
        }
        
        Console.WriteLine(house);
    }
}