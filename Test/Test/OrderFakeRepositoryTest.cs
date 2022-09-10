// using System;
// using Xunit;
// using Core;
// using System.Threading.Tasks;

// namespace Test
// {
//     public class OrderFakeRepositoryTest
//     {
//         Random rng = new Random();
//         private OrderFakeRepository sut = new OrderFakeRepository();

//         private Order CreateOrder(int? customerId = null)
//         {
//             if (customerId.HasValue)
//                 return Order.Factory.Create(customerId.Value);
//             else
//                 return Order.Factory.Create(rng.Next());
//         }

//         [Fact]
//         public async Task Save_AssignsId_SequentiallyAsync()
//         {
//             var order0 = CreateOrder();
//             var id0 = await sut.Save(order0);

//             var order1 = CreateOrder();
//             var id1 = await sut.Save(order0);

//             Assert.Equal(id1, id0 + 1);
//         }

//         [Fact]
//         public async Task Get_ReturnsNull_IfNotFoundAsync()
//         {
//             var item = await sut.Get(rng.Next());
//             Assert.Null(item);
//         }
//     }
// }
