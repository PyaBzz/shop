namespace Unit;

public class Saveable2_
{
    private class SUT : Saveable2
    {
        public SUT(IRepository repo) : base(repo) { }

        public SUT(IRepository repo, int? id = null) : this(repo) => Id = id;

        public override bool IsValid => Validity;

        public bool Validity { get; set; }
    }

    [Fact]
    public void Id_Defaults_ToNull()
    {
        SUT sut = new(It.IsAny<IRepository>()); //todo: Don't repeat this line, can be written once somewhere in test fixture, do some research on that
        Assert.Null(sut.Id);
    }

    [Fact]
    public void IsNew_WhenIdIsNull_GetsTrue()
    {
        SUT sut = new(It.IsAny<IRepository>());
        Assert.True(sut.IsNew);
    }

    [Fact]
    public void IsNew_WhenIdHasValue_GetsFalse()
    {
        SUT sut = new(It.IsAny<IRepository>(), Randomiser.AnId);
        Assert.False(sut.IsNew);
    }

    [Fact]
    public async void Save_ReturnsIdFromRepo()
    {
        var expectedId = Randomiser.AnId;
        var repo = Mocker.MakeRepo(expectedId);
        SUT sut = new(repo) { Validity = true };
        var actualId = await sut.Save();
        Assert.Equal(expectedId, actualId);
    }

    [Fact]
    public async void Save_WhithNewObject_SetsId()
    {
        var expectedId = Randomiser.AnId;
        var repo = Mocker.MakeRepo(expectedId);
        SUT sut = new(repo) { Validity = true };
        await sut.Save();
        var actualId = sut.Id;
        Assert.Equal(expectedId, actualId);
    }

    [Fact]
    public async void Save_WhenIdHasValue_KeepsIt()
    {
        var expectedId = Randomiser.AnId;
        var unexpectedId = Randomiser.AnId;
        var repo = Mocker.MakeRepo(unexpectedId);
        SUT sut = new(repo, id: expectedId) { Validity = true };
        await sut.Save();
        var actualId = sut.Id;
        Assert.Equal(expectedId, actualId);
    }

    private static class Mocker
    {
        private static readonly Mock<IRepository> repoMocker = new();

        public static IRepository MakeRepo(int? id = null)
        {
            if (id.HasValue)
                repoMocker
                    .Setup(x => x.Store(It.IsAny<SUT>()))
                    .Returns(Task.FromResult(id.Value));
            else
                repoMocker
                    .Setup(x => x.Store(It.IsAny<SUT>()))
                    .Returns(Task.FromResult(Randomiser.AnId));
            return repoMocker.Object;
        }
    }
}
