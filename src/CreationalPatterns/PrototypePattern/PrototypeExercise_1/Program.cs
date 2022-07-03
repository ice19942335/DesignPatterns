public class Point
{
    public int X, Y;
}

public class Line
{
    public Point Start, End;

    public Line DeepCopy()
    {
        return new Line
        {
            Start = new Point
            {
                X = this.Start.X,
                Y = this.Start.Y
            },
            End = new Point
            {
                X = this.End.X,
                Y = this.End.Y
            }
        };
    }

    public override string ToString()
    {
        return $"{nameof(Start)}: X-{Start.X}:Y-{Start.Y}, {nameof(End)}: X-{End.X}:Y-{End.Y}";
    }
}

class Program
{
    public static void Main(string[] args)
    {
        Point start = new Point
        {
            X = 1,
            Y = 0
        };
        
        Point end = new Point
        {
            X = 2,
            Y = 0
        };

        Line sourceLine = new Line
        {
            Start = start,
            End = end
        };

        Line copyOfTheLine = sourceLine.DeepCopy();

        Console.WriteLine(sourceLine);
        Console.WriteLine(copyOfTheLine);
    }
}