namespace Unit;

public class Saveable_
{
    private class SUT : Saveable
    {
        public SUT() { }
        public SUT(int id) => Id = id;
        public override bool IsValid => true;
        public override Task<int> Save() => throw new NotImplementedException();
    }

    [Fact]
    public void Id_Defaults_ToNull()
    {
        SUT sut = new();
        Assert.Null(sut.Id);
    }

    [Fact]
    public void IsNew_WhenIdIsNull_GetsTrue()
    {
        SUT sut = new();
        Assert.True(sut.IsNew);
    }

    [Fact]
    public void IsNew_WhenIdHasValue_GetsFalse()
    {
        SUT sut = new(Randomiser.AnId);
        Assert.False(sut.IsNew);
    }
}
