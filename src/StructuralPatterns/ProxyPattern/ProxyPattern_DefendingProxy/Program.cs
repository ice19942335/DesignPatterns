public interface ICar
{
    void Drive();
}

public class Car : ICar
{
    public void Drive()
    {
        Console.WriteLine("Car being driven");
    }
}

public class CarProxy : ICar
{
    private Car _car = new();
    private Driver _driver;

    public CarProxy(Driver driver)
    {
        _driver = driver;
    }

    public void Drive()
    {
        if (_driver.Age >= 16)
            _car.Drive();
        else
        {
            Console.WriteLine("Driver is too young");
        }
    }
}

public class Driver
{
    public int Age { get; set; }
}

public static class Program
{
    public static void Main(string[] args)
    {
        ICar car = new CarProxy(new Driver { Age = 18 });
        car.Drive();
    }
}