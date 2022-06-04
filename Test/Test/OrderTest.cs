using System;
using Xunit;
using Core;
using Moq;

namespace Test
{
    public class OrderTest
    {
        Random rng = new Random();

        private Order GetSut()
        {
            var id = rng.Next();
            return Order.Create(id);
        }

        [Fact]
        public void Create_InitialisesState()
        {
            var id = rng.Next();
            var sut = Order.Create(id);
            Assert.Equal(id, sut.CustomerId);
        }

        [Fact]
        public void Add_AppendsToItems()
        {
            var sut = GetSut();

            var itemMocker0 = new Mock<IOrderItem>();
            itemMocker0.SetupGet(x => x.ProductId).Returns(rng.Next());
            var itemMock0 = itemMocker0.Object;
            sut.Add(itemMock0);

            var itemMocker1 = new Mock<IOrderItem>();
            itemMocker1.SetupGet(x => x.ProductId).Returns(rng.Next());
            var itemMock1 = itemMocker1.Object;
            sut.Add(itemMock1);

            Assert.Collection(
                sut.Items,
                x => Assert.Same(itemMock0, x),
                x => Assert.Same(itemMock1, x)
                );
        }

        [Fact]
        public void Add_ReturnsTrue_IfAppendsSuccessfully()
        {
            var sut = GetSut();

            var itemMocker0 = new Mock<IOrderItem>();
            var itemMock0 = itemMocker0.Object;
            var result = sut.Add(itemMock0);

            Assert.True(result);
            Assert.Collection(sut.Items, x => Assert.Same(itemMock0, x));
        }

        [Fact]
        public void Add_ReturnsFalse_IfDuplicateProduct()
        {
            var sut = GetSut();
            var productId = rng.Next();

            var itemMocker0 = new Mock<IOrderItem>();
            itemMocker0.SetupGet(x => x.ProductId).Returns(productId);
            var itemMock0 = itemMocker0.Object;
            Assert.True(sut.Add(itemMock0));

            var itemMocker1 = new Mock<IOrderItem>();
            itemMocker1.SetupGet(x => x.ProductId).Returns(productId);
            var itemMock1 = itemMocker1.Object;
            Assert.False(sut.Add(itemMock1));
        }

        [Fact]
        public void Amount_SumsAmountsOfItems()
        {
            var sut = GetSut();

            var amount0 = Utils.GetRandom(0, 200);
            var itemMocker0 = new Mock<IOrderItem>();
            itemMocker0.SetupGet(x => x.ProductId).Returns(rng.Next());
            itemMocker0.SetupGet(x => x.Amount).Returns(amount0);
            var itemMock0 = itemMocker0.Object;
            sut.Add(itemMock0);

            var amount1 = Utils.GetRandom(0, 200);
            var itemMocker1 = new Mock<IOrderItem>();
            itemMocker1.SetupGet(x => x.ProductId).Returns(rng.Next());
            itemMocker1.SetupGet(x => x.Amount).Returns(amount1);
            var itemMock1 = itemMocker1.Object;
            sut.Add(itemMock1);

            var total = amount0 + amount1;
            Assert.Equal(total, sut.Amount);
        }
    }
}
