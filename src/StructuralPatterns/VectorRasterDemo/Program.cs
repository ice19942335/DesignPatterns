using System.Collections.ObjectModel;
using MoreLinq.Extensions;

public class Point
{
    public int X, Y;

    public Point(int x, int y)
    {
        X = x;
        Y = y;
    }
}

public class Line
{
    public Point Start, End;

    public Line(Point start, Point end)
    {
        Start = start;
        End = end;
    }
}

public class VectorObject : Collection<Line>
{
}

public class VectorRectangle : VectorObject
{
    public VectorRectangle(int x, int y, int width, int height)
    {
        Add(new Line(new Point(x, y), new Point(x + width, y)));
        Add(new Line(new Point(x + width, y), new Point(x + width, y + height)));
        Add(new Line(new Point(x, y), new Point(x, y + height)));
        Add(new Line(new Point(x, y + height), new Point(x + width, y + height)));
    }
}

public class LineToPointAdapter : Collection<Point>
{
    private static int _count;

    public LineToPointAdapter(Line line)
    {
        Console.WriteLine($"{++_count}: Generating points for line [{line.Start.X},{line.Start.Y}]-[{line.End.X},{line.End.Y}] (no caching)");

        int left = Math.Min(line.Start.X, line.End.X);
        int right = Math.Max(line.Start.X, line.End.X);
        int top = Math.Min(line.Start.Y, line.End.Y);
        int bottom = Math.Max(line.Start.Y, line.End.Y);
        int dx = right - left;
        int dy = line.End.Y - line.Start.Y;

        if (dx == 0)
        {
            for (int y = top; y <= bottom; ++y)
            {
                Add(new Point(left, y));
            }
        }
        else if (dy == 0)
        {
            for (int x = left; x <= right; ++x)
            {
                Add(new Point(x, top));
            }
        }
    }
}

class Program
{
    private static readonly List<VectorObject> VectorObjects = new List<VectorObject>()
    {
        new VectorRectangle(1, 1, 10, 10),
        new VectorRectangle(3, 3, 6, 6)
    };

    public static void DrawPoint(Point p)
    {
        Console.Write(".");
    }

    public static void Main(string[] args)
    {
        Draw();
    }

    private static void Draw()
    {
        foreach (var vo in VectorObjects)
        {
            foreach (var line in vo)
            {
                var adapter = new LineToPointAdapter(line);
                adapter.ForEach(DrawPoint);
            }
        }
    }
}