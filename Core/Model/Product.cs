using System;

namespace Core
{
    public class Product
    {
        private Product() { }
        public int Id { get; private set; }
        public string Name { get; private set; }
        public decimal Price { get; private set; }
        public Product Create(string name, decimal price)
        {
            var instance = new Product
            {
                Name = name,
                Price = price
            };
            return instance;
        }
    }
}
