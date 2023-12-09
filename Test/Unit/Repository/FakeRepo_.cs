namespace Unit;

public class FakeRepo_
{
    public class Thing { }

    private readonly FakeRepo<Thing> sut = new();

    [Fact]
    public async void Save_Saves()
    {
        Thing original = new();
        var savedId = await sut.Save(original);
        var retrieved = await sut.Get(savedId);
        Assert.Same(original, retrieved);
    }

    [Fact]
    public async void Save_AssignsIdsIncrementally()
    {
        var ida = await sut.Save(new Thing());
        var idb = await sut.Save(new Thing());
        Assert.Equal(ida + 1, idb);
    }
}
