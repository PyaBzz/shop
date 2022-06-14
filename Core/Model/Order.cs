﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core
{
    public class OrderDto
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
    }

    public class Order : IOrder
    {
        // ==============================  Interface  ==============================

        public int? Id { get; private set; }
        public int CustomerId { get; private set; }
        public IOrderItem[] Items =>
            items.Values.Select(x => OrderItem.Factory.Create(this.Id, x.ProductId, x.Quantity))
            .ToArray();
        public bool Add(Item item)
        {
            if (items.ContainsKey(item.ProductId))
                return false;
            items.Add(item.ProductId, item);
            return true;
        }
        public decimal Amount => Items.Sum(x => x.Amount);

        public async Task<int> Stage(IOrderRepository r)
        {
            Id = await r.Save(this);
            return Id.Value;
        }

        // ==============================  State  ==============================

        private readonly Dictionary<int, Item> items = new Dictionary<int, Item>();

        // ==============================  Factory  ==============================

        private Order() { }

        public static class Factory //todo: unit test the factory
        {
            public static Order Create(int customerId) =>
                new Order() { CustomerId = customerId };

            public static async Task<Order> Retrieve(IOrderRepository r, int id)
            {
                var dto = await r.Get(id);
                return Create(dto);
            }

            private static Order Create(OrderDto dto) =>
                new Order() { Id = dto.Id, CustomerId = dto.CustomerId };
        }
    }

    public interface IOrderRepository
    {
        Task<int> Save(Order order);
        Task<OrderDto> Get(int id);
    }

    public interface IOrderItem
    {
        int ProductId { get; }
        int Quantity { get; }
        string ProductName { get; }
        decimal UnitPrice { get; }
        decimal Amount { get; }
    }
}
