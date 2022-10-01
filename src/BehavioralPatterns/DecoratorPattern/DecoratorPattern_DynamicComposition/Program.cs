namespace DecoratorPattern_DynamicComposition;

public abstract class Shape
{
    public virtual string AsString => string.Empty;
}

public sealed class Circle : Shape
{
    private float _radius;

    public Circle()
    {
    }
    
    public Circle(float radius)
    {
        _radius = radius;
    }

    public void Resize(float factor)
    {
        _radius *= factor;
    }

    public override string AsString => $"A circle of radius {_radius}";
}

public class ColorShape : Shape
{
    private Shape _shape;
    private string _color;

    public ColorShape(Shape shape, string color)
    {
        _shape = shape;
        _color = color;
    }

    public override string AsString => $"{_shape.AsString} has the color {_color}";
}

public class TransparentShape : Shape
{
    private Shape _shape;
    private float _transparency;

    public TransparentShape(Shape shape, float transparency)
    {
        _shape = shape;
        _transparency = transparency;
    }

    public override string AsString => $"{_shape.AsString} has {_transparency * 100}% transparency";
}

public static class Program
{
    public static void Main(string[] args)
    {
        var circle = new Circle(2);
        Console.WriteLine(circle.AsString);

        var redCircle = new ColorShape(circle, "red");
        Console.WriteLine(redCircle.AsString);

        var redHtCircle = new TransparentShape(redCircle, 0.5f);
        Console.WriteLine(redHtCircle.AsString);
    }
}