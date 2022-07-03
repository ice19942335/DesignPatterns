using Autofac;
using NUnit.Framework;
using SingletonInDependencyInjection;

namespace SingletonInDependencyInjectionTests;

[TestFixture]
public class SingletonTests
{
    [Test]
    public void ConfigurablePopulationTests()
    {
        var recordFinder = new ConfigurableRecordFinder(new DummyDatabase());
        var names = new[] { "alpha", "gamma" };
        int totalPopulation = recordFinder.GetTotalPopulation(names);
        Assert.That(totalPopulation, Is.EqualTo(4));
    }
    
    [Test]
    public void DIPopulationTests()
    {
        var containerBuilder = new ContainerBuilder();
        containerBuilder.RegisterType<OrdinaryDatabase>()
            .As<IDatabase>()
            .SingleInstance();
        containerBuilder.RegisterType<ConfigurableRecordFinder>();

        using var container = containerBuilder.Build();
        var recordFinder = container.Resolve<ConfigurableRecordFinder>();
            
        var names = new[] { "Seoul", "Mexico City" };
        int totalPopulation = recordFinder.GetTotalPopulation(names);
        Assert.That(totalPopulation, Is.EqualTo(17500000 + 17400000));
    }
}