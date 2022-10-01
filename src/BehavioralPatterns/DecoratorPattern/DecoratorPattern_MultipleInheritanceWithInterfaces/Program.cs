namespace DecoratorPattern_MultipleInheritanceWithInterfaces;

public interface ICreature
{
    public int Age { get; set; }
}

public interface IBird : ICreature
{
    void Fly();
}

public class Bird : IBird
{
    public int Age { get; set; }

    public Bird(int age)
    {
        Age = age;
    }

    public void Fly()
    {
        if (Age > 10)
            Console.WriteLine("I am flying!");
    }
}

public interface ILizard : ICreature
{
    void Crawl();
}

public class Lizard : ILizard
{
    public int Age { get; set; }

    public Lizard(int age)
    {
        Age = age;
    }
    
    public void Crawl()
    {
        if (Age < 10)
            Console.WriteLine("I am crawling!");
    }
}

public class Dragon : IBird, ILizard
{
    private readonly IBird _bird;
    private readonly ILizard _lizard;

    public Dragon(IBird bird, ILizard lizard)
    {
        _bird = bird;
        _lizard = lizard;
    }

    public int Age
    {
        get => _bird.Age;
        set => _bird.Age = _lizard.Age = value;
    }

    public void BreathFire()
    {
        Console.WriteLine("Fire!");
    }

    public void Fly()
    {
        _bird.Fly();
    }

    public void Crawl()
    {
        _lizard.Crawl();
    }
}

public static class Program
{
    public static void Main(string[] args)
    {
        Dragon d = new(new Bird(11), new Lizard(9));
        d.Crawl();
        d.Fly();
        d.BreathFire();
    }
}