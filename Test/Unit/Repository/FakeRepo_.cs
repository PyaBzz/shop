namespace Unit;

public class FakeRepo_
{
    public class Thing { }

    private const int MULTI_ELEMENT_COUNT = 6;
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

    [Fact]
    public async void Get_WhenNotFound_GetsNull()
    {
        var nonExistentId = Rand.Int.Get();
        var result = await sut.Get(nonExistentId);
        Assert.Null(result);
    }

    [Fact]
    public async void Get_WhithMultipleIds_WhenNotFound_GetsEmptyArray()
    {
        var nonExistentIds = Rand.Int.GetMulti(MULTI_ELEMENT_COUNT);
        var result = await sut.Get(nonExistentIds);
        Assert.NotNull(result);
        Assert.Empty(result);
    }

    [Fact]
    public async void Get_WhithMultipleIds_WhenSomeFound_GetsThem()
    {
        Thing existingItem = new();
        var existingId = await sut.Save(existingItem);
        var nonExistentIds = Rand.Int.GetMulti(MULTI_ELEMENT_COUNT);
        var ids = nonExistentIds.Append(existingId).ToArray();
        var result = await sut.Get(ids);
        Assert.Single(result);
        Assert.Same(existingItem, result[0]);
    }
}
