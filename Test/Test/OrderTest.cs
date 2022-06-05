using System;
using Xunit;
using Core;
using Moq;
using System.Threading.Tasks;

namespace Test
{
    public class OrderTest
    {
        private readonly Random rng = new Random();
        private readonly Mock<IOrderRepository> repoMocker = new Mock<IOrderRepository>();
        private IOrderRepository mockedRepo => repoMocker.Object;
        private int mockedId => rng.Next();

        private Order GetSut() => Order.Create(mockedRepo, mockedId);

        private IOrderItem CreateMockItem(int? id = null, decimal? amount = null)
        {
            var mocker = new Mock<IOrderItem>();
            if (id.HasValue)
                mocker.SetupGet(x => x.ProductId).Returns(id.Value);
            else
                mocker.SetupGet(x => x.ProductId).Returns(mockedId);

            if (amount.HasValue)
            {
                mocker.SetupGet(x => x.Amount).Returns(amount.Value);
                return mocker.Object;
            }
            return mocker.Object;
        }

        [Fact]
        public void Create_InitialisesState()
        {
            var id = mockedId;
            var mockedRepo = new Mock<IOrderRepository>().Object;
            var sut = Order.Create(mockedRepo, id);
            Assert.Equal(0, sut.Items.Length);
            Assert.Equal(id, sut.CustomerId);
        }

        [Fact]
        public void Add_AppendsToItems()
        {
            var sut = GetSut();

            var itemMock0 = CreateMockItem();
            sut.Add(itemMock0);
            Assert.Equal(1, sut.Items.Length);
            var itemMock1 = CreateMockItem();
            sut.Add(itemMock1);
            Assert.Equal(2, sut.Items.Length);

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

            var itemMock0 = CreateMockItem();
            var result = sut.Add(itemMock0);

            Assert.True(result);
            Assert.Equal(1, sut.Items.Length);
        }

        [Fact]
        public void Add_DoesNotAddDuplicateProduct()
        {
            var sut = GetSut();
            var productId = mockedId;

            var itemMock0 = CreateMockItem(productId);
            sut.Add(itemMock0);
            Assert.Equal(1, sut.Items.Length);

            var itemMock1 = CreateMockItem(productId);
            sut.Add(itemMock1);
            Assert.Equal(1, sut.Items.Length);
        }

        [Fact]
        public void Add_ReturnsFalse_IfDuplicateProduct()
        {
            var sut = GetSut();
            var productId = mockedId;

            var itemMock0 = CreateMockItem(productId);
            Assert.True(sut.Add(itemMock0));

            var itemMock1 = CreateMockItem(productId);
            Assert.False(sut.Add(itemMock1));
        }

        [Fact]
        public void Amount_SumsAmountsOfItems()
        {
            var sut = GetSut();

            var amount0 = Utils.GetRandom(0, 200);
            var itemMock0 = CreateMockItem(null, amount0);
            sut.Add(itemMock0);

            var amount1 = Utils.GetRandom(0, 200);
            var itemMock1 = CreateMockItem(null, amount1);
            sut.Add(itemMock1);

            var total = amount0 + amount1;
            Assert.Equal(total, sut.Amount);
        }

        [Fact]
        public async Task Submit_ReturnsTheAssignedIdAsync()
        {
            var sut0 = GetSut();
            var id0 = mockedId;
            repoMocker.Setup(x => x.Save(It.IsAny<Order>())).Returns(Task.FromResult(id0));
            Assert.Equal(id0, await sut0.Submit());

            var sut1 = GetSut();
            var id1 = mockedId;
            repoMocker.Setup(x => x.Save(It.IsAny<Order>())).Returns(Task.FromResult(id1));

            Assert.Equal(id1, await sut1.Submit());
        }
    }
}
