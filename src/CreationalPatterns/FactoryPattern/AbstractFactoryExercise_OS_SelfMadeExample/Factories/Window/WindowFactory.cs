using AbstractFactoryExercise_OS_SelfMadeExample.Domain.Interfaces;

namespace AbstractFactoryExercise_OS_SelfMadeExample.Factories.Window;

public abstract class WindowFactory : IWindowFactory
{
    public abstract IWindow CreateWindow(int height, int width);
}

public interface IWindowFactory
{
    IWindow CreateWindow(int height, int width);
}