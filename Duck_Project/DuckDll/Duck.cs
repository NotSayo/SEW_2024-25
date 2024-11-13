namespace DuckDll;

public abstract class Duck : IQuackable, IFlyAble
{
    protected IQuackable QuackType { get; set; }
    protected IFlyAble FlyType { get; set; }

    protected Duck(IQuackable quackType, IFlyAble flyType)
    {
        QuackType = quackType;
        FlyType = flyType;
    }

    public string Quack() => QuackType.Quack();
    public string Fly() => FlyType.Fly();

}