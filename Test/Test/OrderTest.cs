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

        private IOrderItem CreateMockItem(int? productId = null)
        {
            var mocker = new Mock<IOrderItem>();
            if (productId.HasValue)
                mocker.SetupGet(x => x.ProductId).Returns(productId.Value);
            else
                mocker.SetupGet(x => x.ProductId).Returns(aRandomId);
            mocker.SetupGet(x => x.Quantity).Returns(aRandomQty);
            return mocker.Object;
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

            Assert.Equal(true, sut.Add(CreateMockItem()));
            Assert.Equal(true, sut.Add(CreateMockItem()));
        }

        [Fact]
        public void Add_WhenGivenDuplicateItems_ReturnsFalse()
        {
            var sut = new Order();
            var sameProductId = aRandomId;
            Assert.Equal(true, sut.Add(CreateMockItem(sameProductId)));
            Assert.Equal(false, sut.Add(CreateMockItem(sameProductId)));
        }

        // [Fact]
        // public void Add_DoesNotAddDuplicateProduct()
        // {
        //     var sut = GetSut();
        //     var productId = mockedId;

        //     var itemMock0 = CreateMockItem(productId);
        //     sut.Add (itemMock0);
        //     Assert.Equal(1, sut.Items.Length);

        //     var itemMock1 = CreateMockItem(productId);
        //     sut.Add (itemMock1);
        //     Assert.Equal(1, sut.Items.Length);
        // }

        // [Fact]
        // public void Add_ReturnsFalse_IfDuplicateProduct()
        // {
        //     var sut = GetSut();
        //     var productId = mockedId;

        //     var itemMock0 = CreateMockItem(productId);
        //     Assert.True(sut.Add(itemMock0));

        //     var itemMock1 = CreateMockItem(productId);
        //     Assert.False(sut.Add(itemMock1));
        // }

        // [Fact]
        // public void Amount_SumsAmountsOfItems()
        // {
        //     var sut = GetSut();
        //     var amount0 = Utils.GetRandom(0, 200);
        //     var itemMock0 = CreateMockItem(null, amount0);
        //     sut.Add(itemMock0);
        //     var amount1 = Utils.GetRandom(0, 200);
        //     var itemMock1 = CreateMockItem(null, amount1);
        //     sut.Add(itemMock1);
        //     var total = amount0 + amount1;
        //     Assert.Equal(total, sut.Amount);
        // }
        // [Fact]
        // public async Task Submit_AssignsId()
        // {
        //     var sut = GetSut();
        //     var id = mockedId;
        //     repoMocker
        //         .Setup(x => x.Save(It.IsAny<Order>()))
        //         .Returns(Task.FromResult(id));
        //     await sut.Stage(mockedRepo);
        //     Assert.Equal(id, sut.Id);
        // }

        // [Fact]
        // public async Task Submit_ReturnsTheAssignedId()
        // {
        //     var sut = GetSut();
        //     var id = mockedId;
        //     repoMocker
        //         .Setup(x => x.Save(It.IsAny<Order>()))
        //         .Returns(Task.FromResult(id));
        //     Assert.Equal(id, await sut.Stage(mockedRepo));
        // }
    }
}
