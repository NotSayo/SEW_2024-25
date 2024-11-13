using DuckDll;

namespace QuackCounter;

public static class QuackExtension
{
    private static int quackCount = 0;

    public static string QuackAndCount(this IQuackable quackable)
    {
        quackCount++;
        return $"{quackable.Quack()} Quack Count: {quackCount}";
    }

    public static int GetQuackCount()
    {
        return quackCount;
    }
}