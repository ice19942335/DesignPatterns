using AbstractFactoryExercise_OS_SelfMadeExample.Domain.Interfaces;
using AbstractFactoryExercise_OS_SelfMadeExample.Domain.OSX;

namespace AbstractFactoryExercise_OS_SelfMadeExample_Inverted.Factories.OSX;

public class OsxOsFactory : OSFactory
{
    public override IWindow CreateWindow(int height, int width) => new OSXWindow(height, width);

    public override IButton CreateButton(int height, int width) => new OSXButton(height, width);
}