using System;
using Xunit;
using Core;
using Moq;

namespace Test
{
    public class OrderTest
    {
        Random rng = new Random();

        [Fact]
        public void Create_InitialisesState()
        {
            var id = rng.Next();
            var instance = Order.Create(id);
            Assert.Equal(id, instance.CustomerId);
        }

        [Fact]
        public void Add_AppendsToItems()
        {
            var id = rng.Next();
            var instance = Order.Create(id);

            var itemMocker0 = new Mock<IOrderItem>();
            var itemMock0 = itemMocker0.Object;
            instance.Add(itemMock0);

            var itemMocker1 = new Mock<IOrderItem>();
            var itemMock1 = itemMocker1.Object;
            instance.Add(itemMock1);

            Assert.Collection(
                instance.Items,
                x => Assert.Same(itemMock0, x),
                x => Assert.Same(itemMock1, x)
                );
        }

        [Fact]
        public void Amount_SumsAmountsOfItems()
        {
            var id = rng.Next();
            var instance = Order.Create(id);

            var amount0 = Utils.GetRandom(0, 200);
            var itemMocker0 = new Mock<IOrderItem>();
            itemMocker0.SetupGet(x => x.Amount).Returns(amount0);
            var itemMock0 = itemMocker0.Object;
            instance.Add(itemMock0);

            var amount1 = Utils.GetRandom(0, 200);
            var itemMocker1 = new Mock<IOrderItem>();
            itemMocker1.SetupGet(x => x.Amount).Returns(amount1);
            var itemMock1 = itemMocker1.Object;
            instance.Add(itemMock1);

            var total = amount0 + amount1;
            Assert.Equal(total, instance.Amount);
        }
    }
}
