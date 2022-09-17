using AbstractFactoryExercise_OS_SelfMadeExample.Domain.Interfaces;
using AbstractFactoryExercise_OS_SelfMadeExample.Domain.Linux;

namespace AbstractFactoryExercise_OS_SelfMadeExample.Factories.Window;

public class LinuxWindowFactory : WindowFactory
{
    public override IWindow CreateWindow(int height, int width) => new LinuxWindow(height, width);
}