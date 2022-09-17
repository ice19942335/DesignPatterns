using AbstractFactoryExercise_OS_SelfMadeExample.Domain.Interfaces;

namespace AbstractFactoryExercise_OS_SelfMadeExample.Factories.Button;

public abstract class ButtonFactory : IButtonFactory
{
    public abstract IButton CreateButton(int height, int width);
}

public interface IButtonFactory
{
    IButton CreateButton(int height, int width);
}