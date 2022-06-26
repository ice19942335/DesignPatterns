using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using static System.Console;

[Serializable] // this is, unfortunately, required when using BinaryFormatter
public class Person
{
    public string Name;
    public string Lastname;

    public override string ToString()
    {
        return $"{nameof(Name)}: {Name}, {nameof(Lastname)}: {Lastname}";
    }
}

public static class ExtensionMethods
{
    public static T DeepCopy<T>(this T self)
    {
        MemoryStream stream = new MemoryStream();
        BinaryFormatter formatter = new BinaryFormatter();
        formatter.Serialize(stream, self);
        stream.Seek(0, SeekOrigin.Begin);
        object copy = formatter.Deserialize(stream);
        stream.Close();
        return (T)copy;
    }

    public static T DeepCopyXml<T>(this T self)
    {
        using var ms = new MemoryStream();
        XmlSerializer s = new XmlSerializer(typeof(T));
        s.Serialize(ms, self);
        ms.Position = 0;
        return (T) s.Deserialize(ms);
    }
}

class Program
{
    public static void Main(string[] args)
    {
        Person person = new Person {Name = "John", Lastname = "Doe"};

        Person deepCopyBinaryFormatter = person.DeepCopy(); // crashes without [Serializable]
        Person deepCopyXml = person.DeepCopyXml();

        WriteLine($"Source: {person}");
        WriteLine($"Copy BinaryFormatter: {deepCopyBinaryFormatter}");
        WriteLine($"Copy XmlSerializer: {deepCopyXml}");
    }
}