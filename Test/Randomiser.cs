namespace Test;

public static class Randomiser
{
    public static int AnId => Rand.Int.Get();

    public static int AQuantity => Rand.Int.Get();

    public static decimal APrice => Rand.Decimal.Get(1.2m, 100.7m);
}
