// using System;
// using Xunit;
// using Core;
// using Moq;
// using System.Threading.Tasks;

// namespace Test
// {
//     public class OrderFactoryTest
//     {
//         private readonly Random rng = new Random();
//         private readonly Mock<IOrderRepository> repoMocker = new Mock<IOrderRepository>();
//         private IOrderRepository mockedRepo => repoMocker.Object;
//         private int mockedId => rng.Next();

//         [Fact]
//         public void Create_InitialisesState()
//         {
//             var customerId = mockedId;
//             var order = Order.Factory.Create(customerId);
//             Assert.Null(order.Id);
//             Assert.Equal(customerId, order.CustomerId);
//             Assert.Equal(0, order.Items.Length);
//         }

//         [Fact]
//         public async void Retrieve_RetrievesState()
//         {
//             var id = mockedId;
//             var customerId = mockedId;
//             repoMocker
//               .Setup(x => x.Get(It.IsAny<int>()))
//               .Returns(Task.FromResult(new Order.State { Id = id, CustomerId = customerId }));
//             var order = await Order.Factory.Retrieve(mockedRepo, id);
//             Assert.Equal(id, order.Id);
//             Assert.Equal(customerId, order.CustomerId);
//         }
//     }
// }
