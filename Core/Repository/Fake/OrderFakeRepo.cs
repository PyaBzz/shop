using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Collections.Concurrent;

namespace Core
{
    public class OrderFakeRepo : IOrderRepo
    {
        private readonly ConcurrentDictionary<int, Order> data = new ConcurrentDictionary<int, Order>();

        public Task<int> Save(Order x)
        {
            int nextId;
            var isSuccess = false;
            do
            {
                nextId = data.Count;
                isSuccess = data.TryAdd(nextId, x);
            }
            while (isSuccess == false);
            return Task.FromResult(nextId);
        }

        public Task<Order> Get(int id)
        {
            if (data.ContainsKey(id))
                return Task.FromResult(data[id]);
            return Task.FromResult<Order>(default);
        }

        public Task<Order[]> Get()
        {
            var arr = data.Values.ToArray();
            return Task.FromResult(arr);
        }
    }
}
