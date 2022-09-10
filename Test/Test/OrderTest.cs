// using System;
// using Xunit;
// using Core;
// using Moq;
// using System.Threading.Tasks;

// namespace Test
// {
//     public class OrderTest
//     {
//         private readonly Random rng = new Random();
//         private readonly Mock<IOrderRepository> repoMocker = new Mock<IOrderRepository>();
//         private IOrderRepository mockedRepo => repoMocker.Object;
//         private int mockedId => rng.Next(); //todo: rename to someRandomId

//         private Order GetSut() => Order.Factory.Create(mockedId);

//         private Item CreateMockItem(int? productId = null, int? quantity = null)
//         {
//             var mocker = new Mock<Item>();
//             if (productId.HasValue)
//                 mocker.SetupGet(x => x.ProductId).Returns(productId.Value);
//             else
//                 mocker.SetupGet(x => x.ProductId).Returns(mockedId);

//             if (quantity.HasValue)
//                 mocker.SetupGet(x => x.Quantity).Returns(quantity.Value);
//             else
//                 mocker.SetupGet(x => x.Quantity).Returns(mockedId);
//             return mocker.Object;
//         }

//         [Fact]
//         public void Add_AppendsToItems()
//         {
//             var sut = GetSut();

//             var prodcutId0 = mockedId;
//             var itemMock0 = CreateMockItem(prodcutId0);
//             sut.Add(itemMock0);
//             Assert.Equal(1, sut.Items.Length);
//             var productId1 = mockedId;
//             var itemMock1 = CreateMockItem(productId1);
//             sut.Add(itemMock1);
//             Assert.Equal(2, sut.Items.Length);

//             Assert.Collection(
//                 sut.Items,
//                 x => Assert.Equal(prodcutId0, x.ProductId),
//                 x => Assert.Equal(productId1, x.ProductId)
//                 );
//         }

//         [Fact]
//         public void Add_ReturnsTrue_IfAppendsSuccessfully()
//         {
//             var sut = GetSut();

//             var itemMock0 = CreateMockItem();
//             var result = sut.Add(itemMock0);

//             Assert.True(result);
//             Assert.Equal(1, sut.Items.Length);
//         }

//         [Fact]
//         public void Add_DoesNotAddDuplicateProduct()
//         {
//             var sut = GetSut();
//             var productId = mockedId;

//             var itemMock0 = CreateMockItem(productId);
//             sut.Add(itemMock0);
//             Assert.Equal(1, sut.Items.Length);

//             var itemMock1 = CreateMockItem(productId);
//             sut.Add(itemMock1);
//             Assert.Equal(1, sut.Items.Length);
//         }

//         [Fact]
//         public void Add_ReturnsFalse_IfDuplicateProduct()
//         {
//             var sut = GetSut();
//             var productId = mockedId;

//             var itemMock0 = CreateMockItem(productId);
//             Assert.True(sut.Add(itemMock0));

//             var itemMock1 = CreateMockItem(productId);
//             Assert.False(sut.Add(itemMock1));
//         }

//         // [Fact]
//         // public void Amount_SumsAmountsOfItems()
//         // {
//         //     var sut = GetSut();

//         //     var amount0 = Utils.GetRandom(0, 200);
//         //     var itemMock0 = CreateMockItem(null, amount0);
//         //     sut.Add(itemMock0);

//         //     var amount1 = Utils.GetRandom(0, 200);
//         //     var itemMock1 = CreateMockItem(null, amount1);
//         //     sut.Add(itemMock1);

//         //     var total = amount0 + amount1;
//         //     Assert.Equal(total, sut.Amount);
//         // }

//         [Fact]
//         public async Task Submit_AssignsId()
//         {
//             var sut = GetSut();
//             var id = mockedId;
//             repoMocker.Setup(x => x.Save(It.IsAny<Order>())).Returns(Task.FromResult(id));
//             await sut.Stage(mockedRepo);
//             Assert.Equal(id, sut.Id);
//         }

//         [Fact]
//         public async Task Submit_ReturnsTheAssignedId()
//         {
//             var sut = GetSut();
//             var id = mockedId;
//             repoMocker.Setup(x => x.Save(It.IsAny<Order>())).Returns(Task.FromResult(id));
//             Assert.Equal(id, await sut.Stage(mockedRepo));
//         }
//     }
// }
