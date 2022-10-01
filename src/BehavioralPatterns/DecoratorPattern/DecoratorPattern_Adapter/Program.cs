using System.Runtime.Serialization;
using System.Text;

namespace DecoratorPattern_Adapter;

public class MyStringBuilder
{

    public static implicit operator MyStringBuilder(string s)
    {
        var msb = new MyStringBuilder();
        msb.Append(s);
        return msb;
    }

    public static MyStringBuilder operator +(MyStringBuilder msb, string s)
    {
        msb.Append(s);
        return msb;
    }

    public override string ToString()
    {
        return _stringBuilder.ToString();
    }

    // Decorator
    
    private StringBuilder _stringBuilder = new();
    
    public void GetObjectData(SerializationInfo info, StreamingContext context)
    {
        ((ISerializable)_stringBuilder).GetObjectData(info, context);
    }

    public StringBuilder Append(bool value)
    {
        return _stringBuilder.Append(value);
    }

    public StringBuilder Append(byte value)
    {
        return _stringBuilder.Append(value);
    }

    public StringBuilder Append(char value)
    {
        return _stringBuilder.Append(value);
    }

    // public StringBuilder Append(char* value, int valueCount)
    // {
    //     return _builder.Append(value, valueCount);
    // }

    public StringBuilder Append(char value, int repeatCount)
    {
        return _stringBuilder.Append(value, repeatCount);
    }

    public StringBuilder Append(char[]? value)
    {
        return _stringBuilder.Append(value);
    }

    public StringBuilder Append(char[]? value, int startIndex, int charCount)
    {
        return _stringBuilder.Append(value, startIndex, charCount);
    }

    public StringBuilder Append(decimal value)
    {
        return _stringBuilder.Append(value);
    }

    public StringBuilder Append(double value)
    {
        return _stringBuilder.Append(value);
    }

    public StringBuilder Append(short value)
    {
        return _stringBuilder.Append(value);
    }

    public StringBuilder Append(int value)
    {
        return _stringBuilder.Append(value);
    }

    public StringBuilder Append(long value)
    {
        return _stringBuilder.Append(value);
    }

    public StringBuilder Append(object? value)
    {
        return _stringBuilder.Append(value);
    }

    public StringBuilder Append(ReadOnlyMemory<char> value)
    {
        return _stringBuilder.Append(value);
    }

    public StringBuilder Append(ReadOnlySpan<char> value)
    {
        return _stringBuilder.Append(value);
    }

    public StringBuilder Append(sbyte value)
    {
        return _stringBuilder.Append(value);
    }

    public StringBuilder Append(float value)
    {
        return _stringBuilder.Append(value);
    }

    public StringBuilder Append(string? value)
    {
        return _stringBuilder.Append(value);
    }

    public StringBuilder Append(string? value, int startIndex, int count)
    {
        return _stringBuilder.Append(value, startIndex, count);
    }

    public StringBuilder Append(StringBuilder? value)
    {
        return _stringBuilder.Append(value);
    }

    public StringBuilder Append(StringBuilder? value, int startIndex, int count)
    {
        return _stringBuilder.Append(value, startIndex, count);
    }

    public StringBuilder Append(ushort value)
    {
        return _stringBuilder.Append(value);
    }

    public StringBuilder Append(uint value)
    {
        return _stringBuilder.Append(value);
    }

    public StringBuilder Append(ulong value)
    {
        return _stringBuilder.Append(value);
    }

    public StringBuilder Append(ref StringBuilder.AppendInterpolatedStringHandler handler)
    {
        return _stringBuilder.Append(ref handler);
    }

    public StringBuilder Append(IFormatProvider? provider, ref StringBuilder.AppendInterpolatedStringHandler handler)
    {
        return _stringBuilder.Append(provider, ref handler);
    }

    public StringBuilder AppendFormat(IFormatProvider? provider, string format, object? arg0)
    {
        return _stringBuilder.AppendFormat(provider, format, arg0);
    }

    public StringBuilder AppendFormat(IFormatProvider? provider, string format, object? arg0, object? arg1)
    {
        return _stringBuilder.AppendFormat(provider, format, arg0, arg1);
    }

    public StringBuilder AppendFormat(IFormatProvider? provider, string format, object? arg0, object? arg1, object? arg2)
    {
        return _stringBuilder.AppendFormat(provider, format, arg0, arg1, arg2);
    }

    public StringBuilder AppendFormat(IFormatProvider? provider, string format, params object?[] args)
    {
        return _stringBuilder.AppendFormat(provider, format, args);
    }

    public StringBuilder AppendFormat(string format, object? arg0)
    {
        return _stringBuilder.AppendFormat(format, arg0);
    }

    public StringBuilder AppendFormat(string format, object? arg0, object? arg1)
    {
        return _stringBuilder.AppendFormat(format, arg0, arg1);
    }

    public StringBuilder AppendFormat(string format, object? arg0, object? arg1, object? arg2)
    {
        return _stringBuilder.AppendFormat(format, arg0, arg1, arg2);
    }

    public StringBuilder AppendFormat(string format, params object?[] args)
    {
        return _stringBuilder.AppendFormat(format, args);
    }

    public StringBuilder AppendJoin(char separator, params object?[] values)
    {
        return _stringBuilder.AppendJoin(separator, values);
    }

    public StringBuilder AppendJoin(char separator, params string?[] values)
    {
        return _stringBuilder.AppendJoin(separator, values);
    }

    public StringBuilder AppendJoin(string? separator, params object?[] values)
    {
        return _stringBuilder.AppendJoin(separator, values);
    }

    public StringBuilder AppendJoin(string? separator, params string?[] values)
    {
        return _stringBuilder.AppendJoin(separator, values);
    }

    public StringBuilder AppendJoin<T>(char separator, IEnumerable<T> values)
    {
        return _stringBuilder.AppendJoin(separator, values);
    }

    public StringBuilder AppendJoin<T>(string? separator, IEnumerable<T> values)
    {
        return _stringBuilder.AppendJoin(separator, values);
    }

    public StringBuilder AppendLine()
    {
        return _stringBuilder.AppendLine();
    }

    public StringBuilder AppendLine(string? value)
    {
        return _stringBuilder.AppendLine(value);
    }

    public StringBuilder AppendLine(ref StringBuilder.AppendInterpolatedStringHandler handler)
    {
        return _stringBuilder.AppendLine(ref handler);
    }

    public StringBuilder AppendLine(IFormatProvider? provider, ref StringBuilder.AppendInterpolatedStringHandler handler)
    {
        return _stringBuilder.AppendLine(provider, ref handler);
    }

    public StringBuilder Clear()
    {
        return _stringBuilder.Clear();
    }

    public void CopyTo(int sourceIndex, char[] destination, int destinationIndex, int count)
    {
        _stringBuilder.CopyTo(sourceIndex, destination, destinationIndex, count);
    }

    public void CopyTo(int sourceIndex, Span<char> destination, int count)
    {
        _stringBuilder.CopyTo(sourceIndex, destination, count);
    }

    public int EnsureCapacity(int capacity)
    {
        return _stringBuilder.EnsureCapacity(capacity);
    }

    public bool Equals(ReadOnlySpan<char> span)
    {
        return _stringBuilder.Equals(span);
    }

    public bool Equals(StringBuilder? sb)
    {
        return _stringBuilder.Equals(sb);
    }

    public StringBuilder.ChunkEnumerator GetChunks()
    {
        return _stringBuilder.GetChunks();
    }

    public StringBuilder Insert(int index, bool value)
    {
        return _stringBuilder.Insert(index, value);
    }

    public StringBuilder Insert(int index, byte value)
    {
        return _stringBuilder.Insert(index, value);
    }

    public StringBuilder Insert(int index, char value)
    {
        return _stringBuilder.Insert(index, value);
    }

    public StringBuilder Insert(int index, char[]? value)
    {
        return _stringBuilder.Insert(index, value);
    }

    public StringBuilder Insert(int index, char[]? value, int startIndex, int charCount)
    {
        return _stringBuilder.Insert(index, value, startIndex, charCount);
    }

    public StringBuilder Insert(int index, decimal value)
    {
        return _stringBuilder.Insert(index, value);
    }

    public StringBuilder Insert(int index, double value)
    {
        return _stringBuilder.Insert(index, value);
    }

    public StringBuilder Insert(int index, short value)
    {
        return _stringBuilder.Insert(index, value);
    }

    public StringBuilder Insert(int index, int value)
    {
        return _stringBuilder.Insert(index, value);
    }

    public StringBuilder Insert(int index, long value)
    {
        return _stringBuilder.Insert(index, value);
    }

    public StringBuilder Insert(int index, object? value)
    {
        return _stringBuilder.Insert(index, value);
    }

    public StringBuilder Insert(int index, ReadOnlySpan<char> value)
    {
        return _stringBuilder.Insert(index, value);
    }

    public StringBuilder Insert(int index, sbyte value)
    {
        return _stringBuilder.Insert(index, value);
    }

    public StringBuilder Insert(int index, float value)
    {
        return _stringBuilder.Insert(index, value);
    }

    public StringBuilder Insert(int index, string? value)
    {
        return _stringBuilder.Insert(index, value);
    }

    public StringBuilder Insert(int index, string? value, int count)
    {
        return _stringBuilder.Insert(index, value, count);
    }

    public StringBuilder Insert(int index, ushort value)
    {
        return _stringBuilder.Insert(index, value);
    }

    public StringBuilder Insert(int index, uint value)
    {
        return _stringBuilder.Insert(index, value);
    }

    public StringBuilder Insert(int index, ulong value)
    {
        return _stringBuilder.Insert(index, value);
    }

    public StringBuilder Remove(int startIndex, int length)
    {
        return _stringBuilder.Remove(startIndex, length);
    }

    public StringBuilder Replace(char oldChar, char newChar)
    {
        return _stringBuilder.Replace(oldChar, newChar);
    }

    public StringBuilder Replace(char oldChar, char newChar, int startIndex, int count)
    {
        return _stringBuilder.Replace(oldChar, newChar, startIndex, count);
    }

    public StringBuilder Replace(string oldValue, string? newValue)
    {
        return _stringBuilder.Replace(oldValue, newValue);
    }

    public StringBuilder Replace(string oldValue, string? newValue, int startIndex, int count)
    {
        return _stringBuilder.Replace(oldValue, newValue, startIndex, count);
    }

    public string ToString(int startIndex, int length)
    {
        return _stringBuilder.ToString(startIndex, length);
    }

    public int Capacity
    {
        get => _stringBuilder.Capacity;
        set => _stringBuilder.Capacity = value;
    }

    public char this[int index]
    {
        get => _stringBuilder[index];
        set => _stringBuilder[index] = value;
    }

    public int Length
    {
        get => _stringBuilder.Length;
        set => _stringBuilder.Length = value;
    }

    public int MaxCapacity => _stringBuilder.MaxCapacity;
}

public static class Program
{
    public static void Main(string[] args)
    {
        MyStringBuilder s = "Hello ";
        s += "world!";
        Console.WriteLine(s);
    }
}