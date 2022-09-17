using AbstractFactoryExercise_OS_SelfMadeExample.Domain.Interfaces;

namespace AbstractFactoryExercise_OS_SelfMadeExample.Domain.OSX;

public class OSXWindow : IWindow
{
    public int Height { get; set; }

    public int Width { get; set; }

    public string Description { get; set; }

    public OSXWindow(int height, int width)
    {
        Height = height;
        Width = width;

        Description = "OSX window";
    }
    
    public override string ToString()
    {
        return $"{nameof(Description)}: {Description}, {nameof(Height)}: {Height}, {nameof(Width)}: {Width}";
    }
}