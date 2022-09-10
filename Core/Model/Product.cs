using System;

namespace Core
{
    public class Product
    {
        // ==============================  State  ==============================
        public int? Id { get; private set; }
        public string Name { get; private set; }
        public decimal Price { get; private set; }

        // ==============================  Factory  ==============================
        public Product(int? id, string name, decimal price)
        {
            Id = id;
            Name = name;
            Price = price;
        }
    }
}
