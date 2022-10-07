using Core;
using Test;
using Xunit;

namespace Unit
{
    public class Product_Name : Product_
    {
        [Fact]
        public void WhenNameIsNull_BecomesInvalid()
        {
            Product sut = new Product(null, Test.Randomiser.APrice, yesterday);
            ModelStateTester.Do(sut);
        }

        [Fact]
        public void WhenNameIsEmpty_BecomesInvalid()
        {
            Product sut = new Product(empty, Test.Randomiser.APrice, yesterday);
            ModelStateTester.Do(sut);
        }

        [Fact]
        public void WhenNameIsSpace_BecomesInvalid()
        {
            Product sut = new Product(space, Test.Randomiser.APrice, yesterday);
            ModelStateTester.Do(sut);
        }

        [Fact]
        public void WhenNameIsInvalid_GivesTheRightValidationMessage()
        {
            Product sut = new Product(empty, Test.Randomiser.APrice, yesterday);
            ModelStateTester.Do(sut, false, Message.required_title);
        }

        [Fact]
        public void WhenNameIsNonEmpty_IsValid()
        {
            Product sut = new Product(dummyName, Test.Randomiser.APrice, yesterday);
            ModelStateTester.Do(sut, true);
        }
    }
}
