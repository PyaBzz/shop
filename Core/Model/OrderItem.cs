using System;

namespace Core
{
    public class ItemDto : Item
    {
        public int? OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }

    }

    public class OrderItem : Item, IOrderItem
    {
        // ==============================  Interface  ==============================
        public int? OrderId { get; private set; }
        public int ProductId { get; private set; }
        public string ProductName => throw new NotImplementedException();
        public decimal UnitPrice => throw new NotImplementedException();
        public int Quantity { get; private set; }
        public decimal Amount => throw new NotImplementedException();

        // ==============================  Factory  ==============================
        private OrderItem() { }

        public static class Factory //todo: unit test the factory
        {
            public static OrderItem Create(int? orderId, int productId, int quantity)
            {
                return new OrderItem
                {
                    OrderId = orderId,
                    ProductId = productId,
                    Quantity = quantity
                };
            }
        }
    }
}
