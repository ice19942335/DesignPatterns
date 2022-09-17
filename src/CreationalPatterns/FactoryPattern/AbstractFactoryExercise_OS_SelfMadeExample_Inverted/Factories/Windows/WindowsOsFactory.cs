using AbstractFactoryExercise_OS_SelfMadeExample.Domain.Interfaces;
using AbstractFactoryExercise_OS_SelfMadeExample.Domain.Windows;

namespace AbstractFactoryExercise_OS_SelfMadeExample_Inverted.Factories.Windows;

public class WindowsOsFactory : OSFactory
{
    public override IWindow CreateWindow(int height, int width) => new WindowsWindow(height, width);

    public override IButton CreateButton(int height, int width) => new WindowsButton(height, width);
}