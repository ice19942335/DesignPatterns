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

public class ColoredShape<T> : Shape
    where T : Shape, new()
{
    private string _color;
    private T _shape = new T();

    public ColoredShape() : this("black")
    {
    }

    public ColoredShape(string color)
    {
        _color = color;
    }

    public override string AsString => $"{_shape.AsString} has the color {_color}";
}

public class TransparentShape<T> : Shape
    where T : Shape, new()
{
    private float _transparency;
    private T _shape = new T();

    public TransparentShape(float transparency)
    {
        _transparency = transparency;
    }

    public override string AsString => $"{_shape.AsString} has {_transparency * 100}% transparency";
}

public static class Program
{
    public static void Main(string[] args)
    {
        var blueCircle = new ColoredShape<Circle>("blue");
        Console.WriteLine(blueCircle.AsString);

        var blackHalfTransparentCircle = new TransparentShape<ColoredShape<Circle>>(0.5f);
    }
}