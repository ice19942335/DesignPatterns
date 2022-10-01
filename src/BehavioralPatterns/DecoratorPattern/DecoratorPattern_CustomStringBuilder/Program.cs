using System.Text;

namespace DecoratorPattern_CustomStringBuilder;

public class CodeBuilder
{
    private StringBuilder _builder = new ();
    private int _indentLevel = 0;
    private readonly string _indentValue = "    ";

    public CodeBuilder Indent(int level)
    {
        _indentLevel = level;
        return this;
    }

    public override string ToString()
    {
        return _builder.ToString();
    }

    public CodeBuilder AppendLine(string? value)
    {
        StringBuilder sb = new();
        for (int i = 0; i < _indentLevel; i++)
        {
            sb.Append(_indentValue);
        }
        
        _builder.AppendLine(sb + value);
        return this;
    }
}

public static class Program
{
    public static void Main(string[] args)
    {
        var cb = new CodeBuilder();
        cb.AppendLine("class Foo");
        cb.AppendLine("{");
        cb.Indent(1);
        cb.AppendLine("public Foo()");
        cb.AppendLine("{");
        cb.AppendLine("}");
        cb.Indent(0);
        cb.AppendLine("}");
        
        Console.WriteLine(cb);
    }
}