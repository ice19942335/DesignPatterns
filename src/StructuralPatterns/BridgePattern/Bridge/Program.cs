﻿using Autofac;

public interface IRenderer
{
    void RenderCircle(float radius);
}

public class VectorRenderer : IRenderer
{
    public void RenderCircle(float radius)
    {
        Console.WriteLine($"Drawing a circle of radius {radius}");
    }
}

public class RasterRenderer : IRenderer
{
    public void RenderCircle(float radius)
    {
        Console.WriteLine($"Drawing pixels for circle with radius {radius}");
    }
}

public abstract class Shape
{
    protected IRenderer _renderer;

    protected Shape(IRenderer renderer)
    {
        _renderer = renderer;
    }

    public abstract void Draw();
    public abstract void Resize(float factor);
}

public class Circle : Shape
{
    private float _radius;
    
    public Circle(IRenderer renderer, float radius) : base(renderer)
    {
        _radius = radius;
    }

    public override void Draw()
    {
        _renderer.RenderCircle(_radius);
    }

    public override void Resize(float factor)
    {
        _radius *= factor;
    }
}

class Program
{
    public static void Main(string[] args)
    {
        // //IRenderer renderer = new RasterRenderer();
        // IRenderer renderer = new VectorRenderer();
        // var circle = new Circle(renderer, 5);
        //
        // circle.Draw();
        // circle.Resize(2);
        // circle.Draw();

        var cb = new ContainerBuilder();
        cb.RegisterType<VectorRenderer>().As<IRenderer>().AsSelf();
        cb.Register((c, p) => new Circle(c.Resolve<IRenderer>(), p.Positional<float>(0)));

        using (var c = cb.Build())
        {
            var circle = c.Resolve<Circle>(new PositionalParameter(0, 5.0f));
            circle.Draw();
            circle.Resize(2.0f);
            circle.Draw();
        }
    }
}