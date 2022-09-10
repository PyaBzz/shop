using System;
using Xunit;
using Core;
using Moq;
using System.Threading.Tasks;

namespace Test
{
    public class OrderItemTest
    {
        private int aRandomId => Rand.Int.Get();
        private string productName = "A random product";
        private decimal aRandomPrice => Rand.Decimal.Get(1.2m, 100.7m);
        private int aRandomQuantity => Rand.Int.Get();
        private Mock<IProductRepository> productRepoMocker = new Mock<IProductRepository>();
        private IProductRepository productRepoMock => productRepoMocker.Object;

        // private OrderItem GetSut() => Order.Factory.Create(aRandomId);

        [Fact]
        public void Price_MultipliesUnitPriceByQuantity()
        {
            var price = aRandomPrice;
            var quantity = aRandomQuantity;

            productRepoMocker
                .Setup(r => r.Get(It.IsAny<int>()))
                .Returns(Task.FromResult(new Product(aRandomId, productName, aRandomPrice)));
            var sut = new OrderItem(productRepoMock, null, aRandomId, quantity);

            Assert.Equal(quantity * price, sut.Price, 8);
        }
    }
}
