using System;
using System.Linq;
using System.Threading.Tasks;

namespace Core
{
    public interface IOrderItem
    {
        int ProductId { get; }

        IProduct Product { get; }

        int Quantity { get; }

        decimal Price { get; }
    }

    public class OrderItem : IOrderItem
    {
        // ==============================  Interface  ==============================
        public int ProductId
        {
            get
            {
                if (Product.Id.HasValue) return Product.Id.Value;
                throw new Exception("The Product has no Id. This could result from an unpersisted Product object.");
            }
        }

        public IProduct Product { get; private set; }

        public int Quantity { get; private set; }

        public decimal Price => Quantity * Product.Price;

        // ==============================  State  ==============================
        public int? Id { get; private set; }

        // ==============================  Factory  ==============================
        public OrderItem(IProduct prod, int qty, int? id)
        {
            Product = prod;
            Quantity = qty;
            Id = id;
        }
    }

    // ==============================  Required Interfaces  ==============================
    // public interface IOrderItemRepository
    // {
    //     Task<int> Save(OrderItem item);
    //     Task<OrderItem.Dto> Get(int id);
    //     Task<OrderItem.Dto[]> GetForOrder(int orderId);
    // }
    public interface IProductRepo
    {
        Task<int> Save(Product item);

        Task<Product> Get(int id);
    }
}
