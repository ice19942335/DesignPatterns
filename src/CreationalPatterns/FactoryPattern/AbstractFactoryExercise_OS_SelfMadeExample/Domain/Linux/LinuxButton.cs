using AbstractFactoryExercise_OS_SelfMadeExample.Domain.Interfaces;

namespace AbstractFactoryExercise_OS_SelfMadeExample.Domain.Linux;

public class LinuxButton : IButton
{
    public int Height { get; set; }

    public int Width { get; set; }

    public string Description { get; set; }

    public LinuxButton(int height, int width)
    {
        Height = height;
        Width = width;

        Description = "Linux button";
    }
    
    public override string ToString()
    {
        return $"{nameof(Description)}: {Description}, {nameof(Height)}: {Height}, {nameof(Width)}: {Width}";
    }
}