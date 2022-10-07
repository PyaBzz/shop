using Core;
using Test;
using Xunit;

namespace Unit
{
    public class Product_ReleaseDate : Product_
    {
        [Fact]
        public void WhenReleasedTomorrow_IsInvalid()
        {
            Product sut = new Product(dummyName, Randomiser.APrice, tomorrow);
            ModelStateTester.Do(sut, false);
        }

        [Fact]
        public void WhenReleasedInvalid_GivesTheRightValidationMessage()
        {
            Product sut = new Product(dummyName, Randomiser.APrice, tomorrow);
            ModelStateTester.Do(sut, false, Message.invalid_release_date);
        }

        [Fact]
        public void WhenReleasedYesterday_IsValid()
        {
            Product sut = new Product(dummyName, Randomiser.APrice, yesterday);
            ModelStateTester.Do(sut, true);
        }
    }
}
