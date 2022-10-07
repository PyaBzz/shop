using System;
using System.Threading.Tasks;
using Core;
using Moq;
using Xunit;

namespace Unit
{
    public class OrderItem_
    {
        private Mock<IProduct> productMocker = new Mock<IProduct>();

        private IProduct productMock => productMocker.Object;

        [Fact]
        public void Price_MultipliesUnitPriceByQuantity()
        {
            var price = Test.Randomiser.APrice;
            var quantity = Test.Randomiser.AQuantity;
            productMocker.SetupGet(x => x.Price).Returns(price);
            var sut = new OrderItem(productMock, quantity, null);

            Assert.Equal(quantity * price, sut.Price, 8);
        }
    }
}
