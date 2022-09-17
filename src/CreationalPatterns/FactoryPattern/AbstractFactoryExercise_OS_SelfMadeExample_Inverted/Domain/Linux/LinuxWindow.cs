using AbstractFactoryExercise_OS_SelfMadeExample.Domain.Interfaces;

namespace AbstractFactoryExercise_OS_SelfMadeExample.Domain.Linux;

public class LinuxWindow : IWindow
{
    public int Height { get; set; }

    public int Width { get; set; }

    public string Description { get; set; }

    public LinuxWindow(int height, int width)
    {
        Height = height;
        Width = width;

        Description = "Linux window";
    }
    
    public override string ToString()
    {
        return $"{nameof(Description)}: {Description}, {nameof(Height)}: {Height}, {nameof(Width)}: {Width}";
    }
}