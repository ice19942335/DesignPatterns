namespace AbstractFactoryExercise_OS_SelfMadeExample.Domain.Interfaces;

public interface IButton : ISize
{
    public string Description { get; set; }
}