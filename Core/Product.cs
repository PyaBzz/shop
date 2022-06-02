using System;

namespace Core
{
    public class Product
    {
        private Product() { }
        public int Id { get; private set; }
        public string Name { get; private set; }
        public Product Create(string name)
        {
            var instance = new Product
            {
                Name = name
            };
            return instance;
        }
    }
}
