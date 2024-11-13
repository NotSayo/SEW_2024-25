namespace DuckDll;

public class ActualQuack : IQuackable
{
    public string Quack() => "Quack!";
}

public class SqueakQuack : IQuackable
{
    public string Quack() => "Squeak!";
}
public class NoQuack : IQuackable
{
    public string Quack() => "...";
}