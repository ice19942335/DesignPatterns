using AbstractFactoryExercise_OS_SelfMadeExample.Domain.Interfaces;
using AbstractFactoryExercise_OS_SelfMadeExample.Domain.Windows;

namespace AbstractFactoryExercise_OS_SelfMadeExample.Factories.Button;

public class WindowsButtonFactory : ButtonFactory
{
    public override IButton CreateButton(int height, int width) => new WindowsButton(height, width);
}