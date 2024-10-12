using System;

namespace Lab4.Product
{
    public class Product : IProduct
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public double Price { get; private set; }

        public Product(string name, string description, double price)
        {
            Name = name;
            Description = description;
            Price = price;
        }

        public override bool Equals(object obj)
        {
            if (obj is Product other)
            {
                return this.Name == other.Name && this.Description == other.Description &&
                       Math.Abs(this.Price - other.Price) < 0.1;
            }

            return false;
        }

        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }
    }
}