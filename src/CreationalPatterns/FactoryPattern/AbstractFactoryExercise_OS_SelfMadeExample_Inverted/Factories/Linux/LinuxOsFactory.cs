using AbstractFactoryExercise_OS_SelfMadeExample.Domain.Interfaces;
using AbstractFactoryExercise_OS_SelfMadeExample.Domain.Linux;

namespace AbstractFactoryExercise_OS_SelfMadeExample_Inverted.Factories.Linux;

public class LinuxOsFactory : OSFactory
{
    public override IWindow CreateWindow(int height, int width) => new LinuxWindow(height, width);

    public override IButton CreateButton(int height, int width) => new LinuxButton(height, width);
}