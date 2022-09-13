using System;
using System.Threading.Tasks;
using Core;
using Moq;
using Xunit;

namespace Test
{
    public class OrderItemTest
    {
        private int aRandomId => Rand.Int.Get();

        private decimal aRandomPrice => Rand.Decimal.Get(1.2m, 100.7m);

        private int aRandomQuantity => Rand.Int.Get();

        private Mock<IProduct> productMocker = new Mock<IProduct>();

        private IProduct productMock => productMocker.Object;

        [Fact]
        public void Price_MultipliesUnitPriceByQuantity()
        {
            var price = aRandomPrice;
            var quantity = aRandomQuantity;
            productMocker.SetupGet(x => x.Price).Returns(price);
            var sut = new OrderItem(productMock, quantity, null);

            Assert.Equal(quantity * price, sut.Price, 8);
        }
    }
}
