using Lab4.Category;
using Lab4.ShoppingCart;
using System.Collections.Generic;
using Lab4.Product;

namespace Lab4.Renderer
{
    public interface IRenderer
    {
        // Отрисовка категории с товарами и просмотром корзины
        void RenderCategory(ICategory category, IShoppingCart cart);

        // Отрисовка полной корзины (при отдельном просмотре корзины)
        void RenderProduct(IProduct product);

        // Отрисовка полной корзины (при отдельном просмотре корзины)
        void RenderCart(IShoppingCart cart);

        // Отрисовка главного меню с категориями
        void RenderMainMenu(List<ICategory> categories, IShoppingCart cart);
    }
}