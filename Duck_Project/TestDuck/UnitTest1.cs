using DuckDll;
using GooseDll;
using QuackCounter;

namespace TestDuck;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void TestDuck()
    {
        Mallard mallard = new Mallard(new ActualQuack(), new CanFly());


        Console.WriteLine();



        Assert.Pass();
    }

    [Test]
    public void TestGoose()
    {
        IEnumerable<IQuackable> Quackable = new List<IQuackable>
        {
            new QuackCountDecorator(new HonkAdapter(new Goose(new HonkSound()))),
            new QuackCountDecorator(new Rubberduck(new SqueakQuack(), new CannotFly())),
            new QuackCountDecorator(new Redheadduck(new ActualQuack(), new CanFly())),
            new Decoyduck(new NoQuack(), new CannotFly()),
            new QuackCountDecorator(new Mallard(new SqueakQuack(), new CannotFly())),
        };

        var result = Quackable.Select(p => p.Quack()).ToList();
        Console.WriteLine(Quackable.Count());
        Console.WriteLine(QuackCountDecorator.Counter);
        Assert.That(Quackable.Count(), Is.EqualTo(5));
        Assert.That(QuackCountDecorator.Counter, Is.EqualTo(4));

        foreach (var item in Quackable)
        {
            Console.WriteLine(QuackExtension.QuackAndCount(item));
        }






    }
}