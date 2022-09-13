using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Core
{
    public interface IOrderRepo
    {
        Task<int> Save(Order x);
        Task<Order> Get(int id);
        Task<Order[]> Get();
    }

    public class OrderFakeRepo : IOrderRepo
    {
        private readonly Dictionary<int, Order> data = new Dictionary<int, Order>();

        public Task<int> Save(Order x)
        {
            var nextId = data.Count;
            data.Add(nextId, x);
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
