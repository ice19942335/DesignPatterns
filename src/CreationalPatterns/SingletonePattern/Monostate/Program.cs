// See https://aka.ms/new-console-template for more information

public class CEO
{
    private static string _name;
    private static int _age;

    public string Name
    {
        get => _name;
        set => _name = value ?? throw new ArgumentNullException(nameof(value));
    }

    public int Age
    {
        get => _age;
        set => _age = value;
    }

    public override string ToString()
    {
        return $"{nameof(Name)}: {Name}, {nameof(Age)}: {Age}";
    }
}

class Program
{
    public static void Main(string[] args)
    {
        var ceo = new CEO();
        ceo.Name = "Adam Smith";
        ceo.Age = 55;
        
        var ceo2 = new CEO();
        
        Console.WriteLine(ceo2);
    }
}