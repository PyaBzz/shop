// using System;
// using System.Collections.Generic;
// using System.Threading.Tasks;

// namespace Core
// {
//     public class OrderFakeRepository : IOrderRepository
//     {
//         private readonly Dictionary<int, Order.State> data = new Dictionary<int, Order.State>();

//         public Task<int> Save(Order order)
//         {
//             var nextId = data.Count;
//             data.Add(nextId, new Order.State
//             {
//                 Id = nextId,
//                 CustomerId = order.CustomerId
//             });
//             return Task.FromResult(nextId);
//         }

//         public Task<Order.State> Get(int id)
//         {
//             if (data.ContainsKey(id))
//                 return Task.FromResult(data[id]);
//             return Task.FromResult<Order.State>(default);
//         }
//     }
// }
