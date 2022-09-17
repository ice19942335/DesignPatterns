using AbstractFactoryExercise_OS_SelfMadeExample_Inverted.Enums;
using AbstractFactoryExercise_OS_SelfMadeExample_Inverted.Factories;
using AbstractFactoryExercise_OS_SelfMadeExample_Inverted.Factories.Linux;
using AbstractFactoryExercise_OS_SelfMadeExample_Inverted.Factories.OSX;
using AbstractFactoryExercise_OS_SelfMadeExample_Inverted.Factories.Windows;

class Program
{
    private static Dictionary<string, OSType> _availableOsList = new()
    {
        { "L", OSType.Linux },
        { "O", OSType.OSX },
        { "W", OSType.Windows }
    };
    
    public static void Main(string[] args)
    {
        Console.WriteLine(">>>  Welcome to OS emulator <<<\n");

        Console.WriteLine("Please enter the OS you want to be loaded.");
        Console.WriteLine("Available OS list:");
        foreach (var item in _availableOsList)
        {
            Console.WriteLine($"{item.Key}:\t{item.Value}");
        }
        
        
        var selectedOs = Console.ReadLine();
        var os = _availableOsList.FirstOrDefault(x => x.Key.ToLower() == selectedOs.ToLower());
        
        Console.WriteLine($@"You selected ""{os.Value}""");
        Console.WriteLine($@"Creating ""{os.Value}"" window...");
        OSFactory factory = GetOSFactory(os.Value);
        Console.WriteLine(factory.CreateButton(100, 100));
        Console.WriteLine(factory.CreateButton(200, 200));
        
        Console.ReadKey();
    }

    private static OSFactory GetOSFactory(OSType osType)
    {
        var os = _availableOsList.FirstOrDefault(x => x.Value == osType);

        return os.Value switch
        {
            OSType.Linux => new LinuxOsFactory(),
            OSType.OSX => new OsxOsFactory(),
            OSType.Windows => new WindowsOsFactory(),
            _ => throw new ArgumentOutOfRangeException("Not existing factory")
        };
    }
}

