using AbstractFactoryExercise_OS_SelfMadeExample.Domain.Interfaces;
using AbstractFactoryExercise_OS_SelfMadeExample.Domain.Linux;

namespace AbstractFactoryExercise_OS_SelfMadeExample.Factories.Button;

public class LinuxButtonFactory : ButtonFactory
{
    public override IButton CreateButton(int height, int width) => new LinuxButton(height, width);
}