using AbstractFactoryExercise_OS_SelfMadeExample.Domain.Interfaces;

namespace AbstractFactoryExercise_OS_SelfMadeExample.Domain.Windows;

public class WindowsWindow : IWindow
{
    public int Height { get; set; }

    public int Width { get; set; }

    public string Description { get; set; }

    public WindowsWindow(int height, int width)
    {
        Height = height;
        Width = width;

        Description = "Windows window";
    }
    
    public override string ToString()
    {
        return $"{nameof(Description)}: {Description}, {nameof(Height)}: {Height}, {nameof(Width)}: {Width}";
    }
}