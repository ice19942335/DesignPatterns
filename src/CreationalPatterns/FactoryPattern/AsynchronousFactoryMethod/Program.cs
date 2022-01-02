using System;
using System.Threading.Tasks;

namespace AsynchronousFactoryMethod
{
    public class Foo
    {
        private string Name, ReturnType;

        private Foo()
        {
        }

        private async Task<Foo> InitAsync(string name, string returnType)
        {
            Name = name;
            ReturnType = returnType;
            await Task.Delay(1000);
            return this;
        }

        public static Task<Foo> CreateAsync(string name, string returnType)
        {
            var result = new Foo();
            return result.InitAsync(name, returnType);
        }

        public override string ToString()
        {
            return $"{nameof(Name)}: {Name}, {nameof(ReturnType)}: {ReturnType}";
        }
    }

    class Program
    {
        static async Task Main(string[] args)
        {
            Foo foo = await Foo.CreateAsync("Calculate age", "double");
            Console.WriteLine(foo);
        }
    }
}