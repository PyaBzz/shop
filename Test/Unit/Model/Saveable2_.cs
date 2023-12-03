namespace Unit;

public class Saveable2_
{
    private static readonly Mock<IRepository> repoMocker = new();
    private static readonly IRepository repo = repoMocker.Object;
    private static SUT sut;

    public Saveable2_()
    {
        repoMocker
            .Setup(x => x.Store(It.IsAny<SUT>()))
            .Returns(Task.FromResult(Randomiser.AnId));
        sut = new(repo);
    }

    private static void SetupRepo(int id) =>
        repoMocker
            .Setup(x => x.Store(It.IsAny<SUT>()))
            .Returns(Task.FromResult(id));

    [Fact]
    public void Id_Defaults_ToNull()
    {
        Assert.Null(sut.Id);
    }

    [Fact]
    public void IsNew_WhenIdIsNull_GetsTrue()
    {
        Assert.True(sut.IsNew);
    }

    [Fact]
    public void IsNew_WhenIdHasValue_GetsFalse()
    {
        sut.AssumedId = Randomiser.AnId;
        Assert.False(sut.IsNew);
    }

    [Fact]
    public async void Save_ReturnsIdFromRepo()
    {
        var expectedId = Randomiser.AnId;
        SetupRepo(expectedId);
        sut.AssumedValidity = true;
        var actualId = await sut.Save();
        Assert.Equal(expectedId, actualId);
    }

    [Fact]
    public async void Save_WhithNewObject_SetsId()
    {
        var expectedId = Randomiser.AnId;
        SetupRepo(expectedId);
        sut.AssumedValidity = true;
        await sut.Save();
        var actualId = sut.Id;
        Assert.Equal(expectedId, actualId);
    }

    [Fact]
    public async void Save_WhenIdHasValue_KeepsIt()
    {
        var expectedId = Randomiser.AnId;
        var unexpectedId = Randomiser.AnId;
        SetupRepo(unexpectedId);
        sut.AssumedId = expectedId;
        sut.AssumedValidity = true;
        await sut.Save();
        var actualId = sut.Id;
        Assert.Equal(expectedId, actualId);
    }

    private class SUT : Saveable2
    {
        public SUT(IRepository repo) : base(repo) { }

        public bool AssumedValidity { get; set; }
        public override bool IsValid => AssumedValidity;

        public int AssumedId { set { Id = value; } }
    }
}
