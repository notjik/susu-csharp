using System;
using System.Collections.Generic;
using System.Linq;
using Lab4.Product;

namespace Lab4.ShoppingCart
{
    public class ShoppingCart : IShoppingCart
    {
        public List<IProduct> Items { get; private set; } = new List<IProduct>();

        public void AddItem(IProduct product)
        {
            Items.Add(product);
        }

        public void RemoveItem(IProduct product)
        {
            Items.Remove(product);
        }

        public void Clear()
        {
            Items.Clear();
        }

        public decimal CalculateTotal()
        {
            return (decimal)Items.Sum(product => product.Price);
        }
    }
}