namespace GooseDll;

public class Goose : IHonkAble
{
    protected IHonkAble HonkType { get; set; }

    public Goose(IHonkAble honkType)
    {
        HonkType = honkType;
    }

    public string Honk() => HonkType.Honk();
}