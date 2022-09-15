using System;
using System.Threading.Tasks;
using Core;
using Moq;
using Xunit;

namespace Test
{
    public class OrderTest
    {
        private int aRandomId => Rand.Int.Get();

        private int aRandomQty => Rand.Int.Get();

        private decimal aRandomPrice => Rand.Decimal.Get(10, 20);

        private IOrderItem
        CreateMockItem(int? productId = null, decimal price = 0)
        {
            var mocker = new Mock<IOrderItem>();
            if (productId.HasValue)
                mocker.SetupGet(x => x.ProductId).Returns(productId.Value);
            else
                mocker.SetupGet(x => x.ProductId).Returns(aRandomId);
            mocker.SetupGet(x => x.Price).Returns(price);
            mocker.SetupGet(x => x.Quantity).Returns(aRandomQty);
            return mocker.Object;
        }

        private IOrderRepo CreateMockRepo(int? orderId)
        {
            var mocker = new Mock<IOrderRepo>();
            if (orderId.HasValue)
                mocker
                    .Setup(x => x.Save(It.IsAny<Order>()))
                    .Returns(Task.FromResult(orderId.Value));
            else
                mocker
                    .Setup(x => x.Save(It.IsAny<Order>()))
                    .Returns(Task.FromResult(aRandomId));
            return mocker.Object;
        }

        [Fact]
        public void Ctor_ByDefault_SetsNoId()
        {
            var sut = new Order();
            Assert.Null(sut.Id);
        }

        [Fact]
        public void Add_WhenGivenDistinctItems_AppendsToItems()
        {
            var sut = new Order();

            var item1 = CreateMockItem();
            sut.Add (item1);

            var item2 = CreateMockItem();
            sut.Add (item2);

            Assert
                .Collection(sut.Items,
                x => Assert.Equal(item1, x),
                x => Assert.Equal(item2, x));
        }

        [Fact]
        public void Add_WhenGivenDistinctItems_ReturnsTrue()
        {
            var sut = new Order();

            Assert.True(sut.Add(CreateMockItem()));
            Assert.True(sut.Add(CreateMockItem()));
        }

        [Fact]
        public void Add_WhenGivenDuplicateItems_DoesNotAppendToItems()
        {
            var sut = new Order();
            var sameProductId = aRandomId;
            sut.Add(CreateMockItem(sameProductId));
            sut.Add(CreateMockItem(sameProductId));
            Assert.Single(sut.Items);
        }

        [Fact]
        public void Add_WhenGivenDuplicateItems_ReturnsFalse()
        {
            var sut = new Order();
            var sameProductId = aRandomId;
            Assert.True(sut.Add(CreateMockItem(sameProductId)));
            Assert.False(sut.Add(CreateMockItem(sameProductId)));
        }

        [Fact]
        public void Price_WhithoutItems_ReturnsZero()
        {
            var sut = new Order();
            Assert.Equal(0, sut.Price);
        }

        [Fact]
        public void Price_WhithItems_ReturnsTheirSum()
        {
            var sut = new Order();
            var item1 = CreateMockItem(aRandomId, aRandomPrice);
            sut.Add (item1);
            var item2 = CreateMockItem(aRandomId, aRandomPrice);
            sut.Add (item2);
            Assert.Equal(item1.Price + item2.Price, sut.Price);
        }

        [Fact]
        public async void Stage_WhithNewOrder_ReturnsId()
        {
            var sut = new Order();
            var expectedId = aRandomId;
            var repo = CreateMockRepo(expectedId);
            var actualId = await sut.Stage(repo);
            Assert.Equal (expectedId, actualId);
        }

        [Fact]
        public async void Stage_WhithNewOrder_SetsId()
        {
            var sut = new Order();
            var expectedId = aRandomId;
            var repo = CreateMockRepo(expectedId);
            await sut.Stage(repo);
            var actualId = sut.Id;
            Assert.Equal (expectedId, actualId);
        }
    }
}
