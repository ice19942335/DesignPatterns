using AbstractFactoryExercise_OS_SelfMadeExample.Domain.Interfaces;
using AbstractFactoryExercise_OS_SelfMadeExample.Domain.OSX;

namespace AbstractFactoryExercise_OS_SelfMadeExample.Factories.Window;

public class OSXWindowFactory : WindowFactory
{
    public override IWindow CreateWindow(int height, int width) => new OSXWindow(height, width);
}