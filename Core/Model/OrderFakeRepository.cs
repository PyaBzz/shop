using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core
{
    public class OrderFakeRepository : IOrderRepository
    {
        private readonly Dictionary<int, OrderDto> data = new Dictionary<int, OrderDto>();

        public Task<int> Save(Order order)
        {
            var nextId = data.Count;
            data.Add(nextId, new OrderDto
            {
                Id = nextId,
                CustomerId = order.CustomerId
            });
            return Task.FromResult(nextId);
        }

        public Task<OrderDto> Get(int id)
        {
            if (data.ContainsKey(id))
                return Task.FromResult(data[id]);
            return Task.FromResult<OrderDto>(default);
        }
    }
}
