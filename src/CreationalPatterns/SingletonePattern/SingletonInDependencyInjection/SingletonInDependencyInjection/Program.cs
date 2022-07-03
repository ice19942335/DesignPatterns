using MoreLinq;

namespace SingletonInDependencyInjection
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

    public class OrdinaryDatabase : IDatabase
    {
        private Dictionary<string, int> _captals;

        public OrdinaryDatabase()
        {
            Console.WriteLine("Initializing ordinary database");

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

    public class SingletonRecordFinder
    {
        public int GetTotalPopulation(IEnumerable<string> names)
        {
            int result = 0;
            foreach (var name in names)
            {
                // Here is the main issue with this implementation
                // We are dependent on live database.
                result += SingletonDatabase.Instance.GetPopulation(name);
            }

            return result;
        }
    }

    public class ConfigurableRecordFinder
    {
        private IDatabase _database;

        public ConfigurableRecordFinder(IDatabase database)
        {
            _database = database ?? throw new ArgumentNullException(paramName: nameof(database));
        }
        
        public int GetTotalPopulation(IEnumerable<string> names)
        {
            int result = 0;
            foreach (var name in names)
            {
                result += _database.GetPopulation(name);
            }

            return result;
        }
    }

    public class DummyDatabase : IDatabase
    {
        public int GetPopulation(string name)
        {
            return new Dictionary<string, int>()
            {
                ["alpha"] = 1,
                ["beta"] = 2,
                ["gamma"] = 3,
            }[name];
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