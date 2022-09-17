using AbstractFactoryExercise_OS_SelfMadeExample.Factories.Button;
using AbstractFactoryExercise_OS_SelfMadeExample.Factories.Enums;
using AbstractFactoryExercise_OS_SelfMadeExample.Factories.Window;

class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine(">>>  Welcome to OS emulator <<<\n");
        
        Console.WriteLine();
        Console.WriteLine("Windows");
        ButtonFactory windowsButtonFactory = GetButtonFactory(ButtonOSType.Windows);
        WindowFactory windowsWindowFactory = GetWindowFactory(WindowOSType.Windows);
        Console.WriteLine(windowsButtonFactory.CreateButton(100, 100));
        Console.WriteLine(windowsWindowFactory.CreateWindow(100, 100));
        
        Console.WriteLine();
        Console.WriteLine("Linux");
        ButtonFactory linuxButtonFactory = GetButtonFactory(ButtonOSType.Linux);
        WindowFactory linuxWindowFactory = GetWindowFactory(WindowOSType.Linux);
        Console.WriteLine(linuxButtonFactory.CreateButton(100, 100));
        Console.WriteLine(linuxWindowFactory.CreateWindow(100, 100));
        
        Console.WriteLine();
        Console.WriteLine("OSX");
        ButtonFactory osxButtonFactory = GetButtonFactory(ButtonOSType.OSX);
        WindowFactory osxWindowFactory = GetWindowFactory(WindowOSType.OSX);
        Console.WriteLine(osxButtonFactory.CreateButton(100, 100));
        Console.WriteLine(osxWindowFactory.CreateWindow(100, 100));
    }
    
    private static WindowFactory GetWindowFactory(WindowOSType type)
    {
        switch (type)
        {
            case WindowOSType.Linux:
                return new LinuxWindowFactory();
            case WindowOSType.OSX:
                return new OSXWindowFactory();
            case WindowOSType.Windows:
                return new WindowsWindowFactory();
            default: throw new ArgumentException("Not existing type");
        }
    }

    private static ButtonFactory GetButtonFactory(ButtonOSType type)
    {
        switch (type)
        {
            case ButtonOSType.Linux:
                return new LinuxButtonFactory();
            case ButtonOSType.OSX:
                return new OSXButtonFactory();
            case ButtonOSType.Windows:
                return new WindowsButtonFactory();
            default: throw new ArgumentException("Not existing type");
        }
    }
}