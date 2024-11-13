namespace DuckDll;

public class CanFly : IFlyAble
{
    public string Fly() => "The Duck is flying!";
}

public class CannotFly : IFlyAble
{
    public string Fly() => "The Duck cannot fly!";
}