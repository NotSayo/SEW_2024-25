using DuckDll;

namespace GooseDll;

public class HonkAdapter : IHonkAble, IQuackable
{
    public IHonkAble HonkType { get; set; }

    public HonkAdapter(IHonkAble honkType)
    {
        HonkType = honkType;
    }

    public string Honk() => HonkType.Honk();

    public string Quack() => HonkType.Honk();
}