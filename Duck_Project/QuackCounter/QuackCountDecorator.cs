using DuckDll;

namespace QuackCounter;

public class QuackCountDecorator : IQuackable
{
    protected IQuackable QuackType { get; set; }
    public static int Counter;

    public QuackCountDecorator(IQuackable quackType)
    {
        QuackType = quackType;
    }

    public string Quack()
    {
        QuackCountDecorator.Counter++;
        return QuackType.Quack();
    }

}