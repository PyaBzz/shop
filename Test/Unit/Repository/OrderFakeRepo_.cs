//namespace Unit;

//public class OrderFakeRepo_
//{
//    [Fact]
//    public async void Save_Saves()
//    {
//        var sut = new OrderFakeRepo();

//        var original = new Order(sut);
//        await sut.Save(original);
//        var repoData = await sut.Get();
//        var retrieved = repoData[0];
//        Assert.Equal(original, retrieved);
//    }

//    [Fact]
//    public async void Save_AssignsIdsIncrementally()
//    {
//        var sut = new OrderFakeRepo();
//        var id0 = await sut.Save(new Order(sut));
//        Assert.Equal(0, id0);
//        var id1 = await sut.Save(new Order(sut));
//        Assert.Equal(1, id1);
//    }

//    [Fact]
//    public async void Get_GetsById()
//    {
//        var sut = new OrderFakeRepo();
//        await sut.Save(new Order(sut));

//        var original = new Order(sut);
//        var id = await sut.Save(original);
//        var retrieved = await sut.Get(id);

//        Assert.Equal(original, retrieved);
//    }
//}
