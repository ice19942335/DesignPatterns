using NUnit.Framework;
using TestabilityIssues;
using SingletonDatabase = SingletonImplementation.SingletonDatabase;

namespace TestabilityIssuesTests;

[TestFixture]
public class SingletonTests
{
    [Test]
    public void IsSingletonTest()
    {
        var db = SingletonDatabase.Instance;
        var db2 = SingletonDatabase.Instance;

        Assert.That(db, Is.SameAs(db2));
        Assert.That(SingletonDatabase.Count, Is.EqualTo(1));
    }

    [Test]
    public void SingletonTotalPopulationTests()
    {
        var recordFinder = new SingletonRecordFinder();
        var names = new[] { "Seoul", "Mexico City" };
        int totalPopulation = recordFinder.GetTotalPopulation(names);
        // Here is the main issue with this implementation
        // We are dependent on Live database.
        Assert.That(totalPopulation, Is.EqualTo(17500000 + 17400000));
    }
}