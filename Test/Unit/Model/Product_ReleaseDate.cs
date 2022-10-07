using Core;
using Test;
using Xunit;

namespace Unit
{
    public class Product_ReleaseDate : Product_Test
    {
        [Fact]
        public void WhenPublishedTomorrow_IsInvalid()
        {
            Product sut = new Product(dummyName, Randomiser.APrice, tomorrow);
            ModelStateTester.Do(sut, false);
        }

        [Fact]
        public void WhenPublishedInvalid_GivesTheRightValidationMessage()
        {
            Product sut = new Product(dummyName, Randomiser.APrice, tomorrow);
            ModelStateTester.Do(sut, false, Message.invalid_release_date);
        }

        [Fact]
        public void WhenPublishedYesterday_IsValid()
        {
            Product sut = new Product(dummyName, Randomiser.APrice, yesterday);
            ModelStateTester.Do(sut, true);
        }
    }
}
