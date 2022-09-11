using System;
using System.Linq;
using System.Threading.Tasks;

namespace Core
{
    public class OrderItem : IOrderItem
    {
        // ==============================  State  ==============================
        public int? orderId;
        public int? productId;
        private IProduct product;
        private IProductRepo productRepo;

        // ==============================  Dto  ==============================
        public class Dto
        {
            public int OrderId { get; set; }
            public int Id { get; set; }
            public int ProductId { get; set; }
            public int Quantity { get; set; }
        }

        // ==============================  Interface  ==============================
        public int? Id { get; private set; }
        public IProduct Product => throw new NotImplementedException(); //todo: cache product from db
        public int Quantity { get; private set; }
        public decimal Price => Quantity * Product.Price;

        // ==============================  Factory  ==============================
        public OrderItem(IProductRepo product_repo, int? order_id, int product_id, int quantity)
        {
            productRepo = product_repo;
            orderId = order_id;
            productId = product_id;
            Quantity = quantity;
        }
    }

    // ==============================  Required Interfaces  ==============================
    // public interface IOrderItemRepository
    // {
    //     Task<int> Save(OrderItem item);
    //     Task<OrderItem.Dto> Get(int id);
    //     Task<OrderItem.Dto[]> GetForOrder(int orderId);
    // }

    public interface IProduct
    {
        string Name { get; }
        decimal Price { get; }
    }

    public interface IProductRepo
    {
        Task<int> Save(Product item);
        Task<Product> Get(int id);
    }
}
