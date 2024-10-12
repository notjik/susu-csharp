using System.Collections.Generic;
using Lab4.Product;

namespace Lab4.Category
{
    public interface ICategory
    {
        string Name { get; }
        List<IProduct> Products { get; }
        void AddProduct(IProduct product);
    }

}