using System.Collections.Generic;
using Lab4.Product;

namespace Lab4.ShoppingCart
{
    public interface IShoppingCart
    {
        List<IProduct> Items { get; }
        void AddItem(IProduct product);
        void RemoveItem(IProduct product);  
        void Clear();
        decimal CalculateTotal();
    }
}