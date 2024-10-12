using System;
using System.Collections.Generic;
using Lab4.Product;

namespace Lab4.Category
{
    public class Category : ICategory
    {
        public string Name { get; private set; }
        public List<IProduct> Products { get; private set; }

        public Category(string name)
        {
            Name = name;
            Products = new List<IProduct>();
        }

        public void AddProduct(IProduct product)
        {
            Products.Add(product);
        }
    }

}