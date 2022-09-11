using System;

namespace Core
{
    public interface IProduct
    {
        string Name { get; }

        decimal Price { get; }
    }

    public class Product : IProduct
    {
        // ==============================  Interface  ==============================
        public string Name { get; private set; }

        public decimal Price { get; private set; }

        // ==============================  State  ==============================
        public int? Id { get; private set; }

        // ==============================  Factory  ==============================
        public Product(string name, decimal price, int? id)
        {
            Name = name;
            Price = price;
            Id = id;
        }
    }
}
