using System;
using System.Collections.Generic;

namespace Core
{
    public class Order
    {
        private Order() { }
        public int Id { get; private set; }
        public int CustomerId { get; private set; }
        public List<int> ItemIds { get; private set; }
        public Order Create(int customerId)
        {
            var instance = new Order
            {
                CustomerId = customerId
            };
            return instance;
        }
    }
}
