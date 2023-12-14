namespace Unit;

public class Product_ReleaseDate : Product_
{
    [Fact]
    public void WhenReleasedTomorrow_IsInvalid()
    {
        Product sut = new(dummyName, Randomiser.APrice, tomorrow);
        ModelStateTester.Do(sut, false);
    }

    [Fact]
    public void WhenReleasedYesterday_IsValid()
    {
        Product sut = new(dummyName, Randomiser.APrice, yesterday);
        ModelStateTester.Do(sut, true);
    }
}
