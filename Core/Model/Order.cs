using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core
{
    public interface IOrder
    {
        bool Add(IOrderItem item);
        IOrderItem[] Items {get; } //todo: make it ImmutableDictionary
        decimal Amount { get; }
        Task<int> Stage();
    }

    public class Order : IOrder
    {
        // ==============================  Interface  ==============================
        public IOrderItem[] Items => items.Values.ToArray();
        public bool Add(IOrderItem item)
        {
            if(items.ContainsKey(item.ProductId))
            return false;
            items.Add(item.ProductId,item);
            return true;
        }
        public decimal Amount => throw new NotImplementedException();
        public async Task<int> Stage() => throw new NotImplementedException();

        // ==============================  State  ==============================
        public int? Id { get; private set; }
        private Dictionary<int, IOrderItem> items;

        // ==============================  Factory  ==============================
        public Order()
        {
            items = new Dictionary<int, IOrderItem>();
        }

        public Order(Dictionary<int, IOrderItem> itmz, int? id)
        {
            items = itmz;
            Id = id;
        }
    }
}
