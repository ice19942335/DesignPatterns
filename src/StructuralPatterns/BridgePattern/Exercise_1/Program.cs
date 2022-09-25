public interface IRenderer
{
    string WhatToRenderAs { get; }
}

public abstract class Shape
{
    private IRenderer _renderer;
    
    public virtual string Name { get; set; }

    protected Shape(IRenderer renderer)
    {
        _renderer = renderer;
    }

    public override string ToString()
    {
        return $"Drawing {Name} as {_renderer.WhatToRenderAs}";
    }
}

public class Triangle : Shape
{
    public override string Name { get; set; }
    
    public Triangle(IRenderer renderer) : base(renderer)
    {
        Name = "Triangle";
    }
}

public class Square : Shape
{
    public override string Name { get; set; }
    
    public Square(IRenderer renderer) : base(renderer)
    {
        Name = "Square";
    }
}

public class RasterSquare : Square
{
    public RasterSquare(IRenderer renderer) : base(renderer)
    {
    }
}

public class VectorSquare : Square
{
    public VectorSquare(IRenderer renderer) : base(renderer)
    {
    }
}

public class RasterRenderer : IRenderer
{
    public string WhatToRenderAs { get; }

    public RasterRenderer()
    {
        WhatToRenderAs = "pixels";
    }
}

public class VectorRenderer : IRenderer
{
    public string WhatToRenderAs { get; }

    public VectorRenderer()
    {
        WhatToRenderAs = "lines";
    }
}

// imagine VectorTriangle and RasterTriangle are here too
class Program
{
    public static void Main(string[] args)
    {
        Triangle triangle = new Triangle(new RasterRenderer());
        string result = triangle.ToString();
        Console.WriteLine(result);
    }
}