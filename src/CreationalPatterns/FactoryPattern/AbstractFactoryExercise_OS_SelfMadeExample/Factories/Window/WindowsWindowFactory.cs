using AbstractFactoryExercise_OS_SelfMadeExample.Domain.Interfaces;
using AbstractFactoryExercise_OS_SelfMadeExample.Domain.Windows;

namespace AbstractFactoryExercise_OS_SelfMadeExample.Factories.Window;

public class WindowsWindowFactory : WindowFactory
{
    public override IWindow CreateWindow(int height, int width) => new WindowsWindow(height, width);
}