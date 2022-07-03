using MoreLinq;

namespace SingletonImplementation
{
    public interface IDatabase
    {
        int GetPopulation(string name);
    }

    public class SingletonDatabase : IDatabase
    {
        private Dictionary<string, int> _captals;
        private static int _instanceCount = 0;
        
        private static Lazy<SingletonDatabase> _instance =
                new Lazy<SingletonDatabase>(() => new SingletonDatabase());
        public static SingletonDatabase Instance => _instance.Value;

        public static int Count => _instanceCount;

        private SingletonDatabase()
        {
            _instanceCount++;
            Console.WriteLine("Initializing database");

            _captals = File.ReadAllLines("capitals.txt")
                .Batch(2)
                .ToDictionary(
                    list => list.ElementAt(0).Trim(),
                    list => int.Parse(list.ElementAt(1)));
        }

        public int GetPopulation(string name)
        {
            return _captals[name];
        }
    }

    class Program
    {
        public static void Main(string[] args)
        {
            var db = SingletonDatabase.Instance;
            var city = "Tokyo";
            Console.WriteLine($"{city} has population {db.GetPopulation(city)}");
        }
    }
}