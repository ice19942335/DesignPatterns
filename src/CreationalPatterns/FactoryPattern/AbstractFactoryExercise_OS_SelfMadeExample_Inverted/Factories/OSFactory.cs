using AbstractFactoryExercise_OS_SelfMadeExample.Domain.Interfaces;

namespace AbstractFactoryExercise_OS_SelfMadeExample_Inverted.Factories;

public abstract class OSFactory : IFactory
{
    public abstract IWindow CreateWindow(int height, int width);

    public abstract IButton CreateButton(int height, int width);
}

public interface IFactory
{
    IWindow CreateWindow(int height, int width);

    IButton CreateButton(int height, int width);
}