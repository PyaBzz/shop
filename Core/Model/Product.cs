using System;

namespace Core
{
    public interface IProduct
    {
        int? Id { get; }
        string Name { get; }
        decimal Price { get; }
    }

    public class Product : IProduct
    {
        // ==============================  Interface  ==============================
        public int? Id { get; private set; }
        public string Name { get; private set; }
        public decimal Price { get; private set; }

        // ==============================  State  ==============================

        // ==============================  Factory  ==============================
        public Product(string name, decimal price, int? id)
        {
            Name = name;
            Price = price;
            Id = id;
        }
    }
}
