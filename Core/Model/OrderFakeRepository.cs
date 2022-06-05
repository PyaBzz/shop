using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core
{
    public class OrderFakeRepository : IOrderRepository
    {
        private readonly Dictionary<int, Order> data = new Dictionary<int, Order>();

        public Task<int> Save(Order order)
        {
            var nextId = data.Count;
            data.Add(nextId, order);
            return Task.FromResult(nextId);
        }

        public Task<Order> Get(int id)
        {
            if (data.ContainsKey(id))
                return Task.FromResult(data[id]);
            return Task.FromResult<Order>(default);
        }
    }
}
