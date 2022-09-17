using AbstractFactoryExercise_OS_SelfMadeExample.Domain.Interfaces;
using AbstractFactoryExercise_OS_SelfMadeExample.Domain.OSX;

namespace AbstractFactoryExercise_OS_SelfMadeExample.Factories.Button;

public class OSXButtonFactory : ButtonFactory
{
    public override IButton CreateButton(int height, int width) => new OSXButton(height, width);
}