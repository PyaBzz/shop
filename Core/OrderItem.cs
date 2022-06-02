using System;

namespace Core
{
    public class OrderItem
    {
        private OrderItem() { }
        public int OrderId { get; private set; }
        public int ProductId { get; private set; }
        public int Quantity { get; private set; }
        public OrderItem Create(int orderId, int productId, int quantity)
        {
            var instance = new OrderItem
            {
                OrderId = orderId,
                ProductId = productId,
                Quantity = quantity
            };
            return instance;
        }
    }
}
