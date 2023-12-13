namespace Unit;

public class Product_Name : Product_
{
    [Fact]
    public void WhenNameIsNull_BecomesInvalid()
    {
        Product.State sutState = new()
        {
            Price = Randomiser.APrice,
            ReleaseDate = yesterday
        };
        Product sut = new(sutState);
        ModelStateTester.Do(sut);
    }

    [Fact]
    public void WhenNameIsEmpty_BecomesInvalid()
    {
        Product.State sutState = new()
        {
            Name = empty,
            Price = Randomiser.APrice,
            ReleaseDate = yesterday
        };
        Product sut = new(sutState);
        ModelStateTester.Do(sut);
    }

    [Fact]
    public void WhenNameIsSpace_BecomesInvalid()
    {
        Product.State sutState = new()
        {
            Name = space,
            Price = Randomiser.APrice,
            ReleaseDate = yesterday
        };
        Product sut = new(sutState);
        ModelStateTester.Do(sut);
    }

    [Fact]
    public void WhenNameIsInvalid_GivesTheRightValidationMessage()
    {
        Product.State sutState = new()
        {
            Name = empty,
            Price = Randomiser.APrice,
            ReleaseDate = yesterday
        };
        Product sut = new(sutState);
        ModelStateTester.Do(sut, false, Message.required_title);
    }

    [Fact]
    public void WhenNameIsNonEmpty_IsValid()
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
