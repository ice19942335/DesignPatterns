namespace AbstractFactoryExercise_OS_SelfMadeExample.Domain.Interfaces;

public interface IWindow : ISize
{
    public string Description { get; set; }
}