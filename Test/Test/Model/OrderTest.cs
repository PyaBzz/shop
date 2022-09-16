using System;
using System.Threading.Tasks;
using Core;
using Moq;
using Xunit;

namespace Test
{
    public class OrderTest
    {
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

            var item1 = Mocker.MakeItem();
            sut.Add (item1);

            var item2 = Mocker.MakeItem();
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

            Assert.True(sut.Add(Mocker.MakeItem()));
            Assert.True(sut.Add(Mocker.MakeItem()));
        }

        [Fact]
        public void Add_WhenGivenDuplicateItems_DoesNotAppendToItems()
        {
            var sut = new Order();
            var sameProductId = Randomiser.AnId;
            sut.Add(Mocker.MakeItem(sameProductId));
            sut.Add(Mocker.MakeItem(sameProductId));
            Assert.Single(sut.Items);
        }

        [Fact]
        public void Add_WhenGivenDuplicateItems_ReturnsFalse()
        {
            var sut = new Order();
            var sameProductId = Randomiser.AnId;
            Assert.True(sut.Add(Mocker.MakeItem(sameProductId)));
            Assert.False(sut.Add(Mocker.MakeItem(sameProductId)));
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
            var item1 = Mocker.MakeItem(Randomiser.AnId, Randomiser.APrice);
            sut.Add (item1);
            var item2 = Mocker.MakeItem(Randomiser.AnId, Randomiser.APrice);
            sut.Add (item2);
            Assert.Equal(item1.Price + item2.Price, sut.Price);
        }

        [Fact]
        public async void Stage_WhithNewOrder_ReturnsId()
        {
            var sut = new Order();
            var expectedId = Randomiser.AnId;
            var repo = Mocker.MakeRepo(expectedId);
            var actualId = await sut.Stage(repo);
            Assert.Equal (expectedId, actualId);
        }

        [Fact]
        public async void Stage_WhithNewOrder_SetsId()
        {
            var sut = new Order();
            var expectedId = Randomiser.AnId;
            var repo = Mocker.MakeRepo(expectedId);
            await sut.Stage(repo);
            var actualId = sut.Id;
            Assert.Equal (expectedId, actualId);
        }

        private static class Mocker
        {
            private static readonly Mock<IOrderItem>
                itemMocker = new Mock<IOrderItem>();

            private static readonly Mock<IOrderRepo>
                repoMocker = new Mock<IOrderRepo>();

            public static IOrderItem
            MakeItem(int? productId = null, decimal price = 0)
            {
                if (productId.HasValue)
                    itemMocker
                        .SetupGet(x => x.ProductId)
                        .Returns(productId.Value);
                else
                    itemMocker.SetupGet(x => x.ProductId).Returns(Randomiser.AnId);
                itemMocker.SetupGet(x => x.Price).Returns(price);
                itemMocker.SetupGet(x => x.Quantity).Returns(Randomiser.AQuantity);
                return itemMocker.Object;
            }

            public static IOrderRepo MakeRepo(int? orderId)
            {
                if (orderId.HasValue)
                    repoMocker
                        .Setup(x => x.Save(It.IsAny<Order>()))
                        .Returns(Task.FromResult(orderId.Value));
                else
                    repoMocker
                        .Setup(x => x.Save(It.IsAny<Order>()))
                        .Returns(Task.FromResult(Randomiser.AnId));
                return repoMocker.Object;
            }
        }
    }
}
