public class Property<T> where T : new()
{
    private T _value;
    private readonly string _name;

    public T Value
    {
        get => _value;
        set
        {
            if (Equals(this._value, value))
                return;
            Console.WriteLine($"Assigning {value} to {_name}");
            _value = value;
        }
    }
    
    public Property() : this(default(T))
    {
    }

    public Property(T value, string name = "")
    {
        _value = value;
        _name = name;
    }

    public static implicit operator T(Property<T> p)
    {
        return p.Value;
    }

    public static implicit operator Property<T>(T value)
    {
        return new Property<T>(value);
    }
    
    protected bool Equals(Property<T> other)
    {
        return EqualityComparer<T>.Default.Equals(_value, other._value);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((Property<T>) obj);
    }

    public override int GetHashCode()
    {
        return EqualityComparer<T>.Default.GetHashCode(_value);
    }
}

public class Creature
{
    private readonly Property<int> _agility = new Property<int>(10, nameof(Agility));

    public int Agility
    {
        get => _agility.Value;
        set => _agility.Value = value;
    }
}

public static class Program
{
    public static void Main(string[] args)
    {
        var c = new Creature();
        c.Agility = 12;
        int n = c.Agility;
    }
}