using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Core
{
    public class OrderItemFakeRepo : IOrderItemRepo
    {
        // ==============================  Interface  ==============================
        public Task<IEnumerable<int>> Save(IEnumerable<OrderItem> items)
            => throw new NotImplementedException();
        public Task<IEnumerable<OrderItem>> Get(int orderId)
            => throw new NotImplementedException();
    }
}
