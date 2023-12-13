namespace Unit;

public class Product_ReleaseDate : Product_
{
    [Fact]
    public void WhenReleasedTomorrow_IsInvalid()
    {
        Product.State sutState = new()
        {
            Name = dummyName,
            Price = Randomiser.APrice,
            ReleaseDate = tomorrow
        };
        Product sut = new(sutState);
        ModelStateTester.Do(sut, false);
    }

    [Fact]
    public void WhenReleasedYesterday_IsValid()
    {
        Product.State sutState = new()
        {
            Name = dummyName,
            Price = Randomiser.APrice,
            ReleaseDate = yesterday
        };
        Product sut = new(sutState);
        ModelStateTester.Do(sut, true);
    }
}
