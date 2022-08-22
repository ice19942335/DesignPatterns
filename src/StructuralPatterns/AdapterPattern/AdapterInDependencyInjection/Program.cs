using Autofac;
using Autofac.Features.Metadata;

public interface ICommand
{
    void Execute();
}

public class SaveCommand : ICommand
{
    public void Execute()
    {
        Console.WriteLine("Saving a file");
    }
}

public class OpenCommand : ICommand
{
    public void Execute()
    {
        Console.WriteLine("Opening a file");
    }
}

public class Button
{
    private ICommand _command;
    private string _name;

    public Button(ICommand command, string name)
    {
        this._command = command;
        this._name = name;
    }

    public void Click()
    {
        _command.Execute();
    }

    public void PrintMe()
    {
        Console.WriteLine($"I am a button called {_name}");
    }
}

public class Editor
{
    private IEnumerable<Button> buttons;

    public IEnumerable<Button> Buttons => buttons;

    public Editor(IEnumerable<Button> buttons)
    {
        this.buttons = buttons;
    }

    public void ClickAll()
    {
        foreach (var button in buttons)
        {
            button.Click();
        }
    }
}

class Program
{
    public static void Main(string[] args)
    {
        var b = new ContainerBuilder();
        b.RegisterType<SaveCommand>().As<ICommand>().WithMetadata("Name", "Save");
        b.RegisterType<OpenCommand>().As<ICommand>().WithMetadata("Name", "Open");
        //b.RegisterType<Button>();
        //b.RegisterAdapter<ICommand, Button>(cmd => new Button(cmd));
        b.RegisterAdapter<Meta<ICommand>, Button>(cmd => new Button(cmd.Value, (string)cmd.Metadata["Name"]));
        b.RegisterType<Editor>();

        using (var c = b.Build())
        {
            var editor = c.Resolve<Editor>();
            //editor.ClickAll();

            foreach (var button in editor.Buttons)
            {
                button.PrintMe();
            }
        }
    }
}