namespace Unit;

public class Product_Name : Product_
{
    [Fact]
    public void WhenNameIsNull_BecomesInvalid()
    {
        Product sut = new(null, Randomiser.APrice, yesterday);
        ModelStateTester.Do(sut);
    }

    [Fact]
    public void WhenNameIsEmpty_BecomesInvalid()
    {
        Product sut = new(empty, Randomiser.APrice, yesterday);
        ModelStateTester.Do(sut);
    }

    [Fact]
    public void WhenNameIsSpace_BecomesInvalid()
    {
        Product sut = new(space, Randomiser.APrice, yesterday);
        ModelStateTester.Do(sut);
    }

    [Fact]
    public void WhenNameIsInvalid_GivesTheRightValidationMessage()
    {
        Product sut = new(empty, Randomiser.APrice, yesterday);
        ModelStateTester.Do(sut, false, Message.required_title);
    }

    [Fact]
    public void WhenNameIsNonEmpty_IsValid()
    {
        Product sut = new(dummyName, Randomiser.APrice, yesterday);
        ModelStateTester.Do(sut, true);
    }
}
