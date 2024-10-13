using System;
using System.Collections.Generic;
using System.Linq;
using Lab4.Category;
using Lab4.Product;
using Lab4.ShoppingCart;

namespace Lab4.Renderer
{
    public class Renderer : IRenderer
    {
        // Метод отрисовки разделительной линии
        private void RenderLine()
        {
            Console.WriteLine(new string('-', 50));
        }

        private void RenderTitle(string title)
        {
            Console.WriteLine($"| {title,-46} |");
        }

        private void RenderCalculateCart(IShoppingCart cart)
        {
            Console.WriteLine($"| {"Итого",-16}{cart.CalculateTotal(),30:C} |");
        }

        private void RenderProducts(List<IProduct> products, int selectedIndex = -1)
        {
            for (int i = 0; i < products.Count; i++)
            {
                if (i == selectedIndex)
                {
                    Console.BackgroundColor = ConsoleColor.DarkGray;
                    Console.ForegroundColor = ConsoleColor.Black;
                }

                var product = products[i];
                Console.WriteLine($"| {product.Name,-31} | {product.Price,12:C} |");

                Console.ResetColor();
            }
        }


        public void RenderProduct(IProduct product)
        {
            Console.Clear();
            RenderLine();
            Console.WriteLine($"| {product.Name,-46} |");
            RenderLine();
            Console.WriteLine($"| {product.Description,-46} |");
            RenderLine();
            Console.WriteLine($"| {"Цена:",-34}{product.Price,12:C} |");
            RenderLine();
            Console.ReadKey(true);
        }

        private void RenderButtonsAnnotate(List<(ConsoleKey button, string title)> buttons)
        {
            foreach (var button in buttons)
            {
                Console.WriteLine($"| {button.button.ToString(),-20}{button.title,26} |");
            }
        }

        // Отрисовка категории
        public void RenderCategory(ICategory category, IShoppingCart cart)
        {
            int selectedIndex = 0;
            bool exit = false;
            List<(ConsoleKey button, string title)> buttons = new List<(ConsoleKey button, string title)>()
            {
                (ConsoleKey.Enter, "Добавить в корзину"),
                (ConsoleKey.Tab, "Описание товара"),
                (ConsoleKey.Escape, "Назад")
            };

            while (!exit)
            {
                Console.Clear();

                RenderLine();
                RenderTitle("Категория: " + category.Name);
                RenderLine();
                // Отрисовка товаров категории
                RenderProducts(category.Products, selectedIndex);
                RenderLine();
                RenderButtonsAnnotate(buttons);
                RenderLine();

                // Полный просмотр корзины, если в ней есть товары
                if (cart.Items.Count > 0)
                {
                    RenderTitle("Товары в корзине");
                    RenderLine();
                    RenderProducts(cart.Items.Where(cartProduct =>
                        category.Products.Any(categoryProduct => Equals(categoryProduct, cartProduct))).ToList());
                    RenderLine();
                    RenderCalculateCart(cart);
                    RenderLine();
                }
                else
                {
                    RenderTitle("Корзина пуста");
                    RenderLine();
                }

                var key = Console.ReadKey(true).Key;

                switch (key)
                {
                    case ConsoleKey.UpArrow:
                        if (selectedIndex > 0) selectedIndex--;
                        break;
                    case ConsoleKey.DownArrow:
                        if (selectedIndex < category.Products.Count - 1) selectedIndex++;
                        break;
                    case ConsoleKey.Enter:
                        cart.AddItem(category.Products[selectedIndex]);
                        break;
                    case ConsoleKey.Tab:
                        RenderProduct(category.Products[selectedIndex]);
                        break;
                    case ConsoleKey.Escape:
                        exit = true;
                        break;
                }
            }
        }

        // Отрисовка корзины
        public void RenderCart(IShoppingCart cart)
        {
            int selectedIndex = 0;
            bool exit = false;
            List<(ConsoleKey button, string title)> buttons = new List<(ConsoleKey button, string title)>()
            {
                (ConsoleKey.Enter, "Удалить из корзины"),
                (ConsoleKey.Tab, "Описание товара"),
                (ConsoleKey.Spacebar, "Оформить заказ"),
                (ConsoleKey.Escape, "Назад")
            };

            while (!exit)
            {
                Console.Clear();
                RenderLine();
                RenderTitle("Корзина");
                RenderLine();

                var items = cart.Items;

                if (items.Count == 0)
                {
                    RenderTitle("Козина пуста");
                }
                else
                {
                    RenderProducts(items, selectedIndex);
                }

                RenderLine();
                RenderButtonsAnnotate(buttons);
                RenderLine();
                RenderCalculateCart(cart);
                RenderLine();

                var key = Console.ReadKey(true).Key;

                switch (key)
                {
                    case ConsoleKey.UpArrow:
                        if (selectedIndex > 0) selectedIndex--;
                        break;
                    case ConsoleKey.DownArrow:
                        if (selectedIndex < items.Count - 1) selectedIndex++;
                        break;
                    case ConsoleKey.Enter:
                        if (items.Count > 0)
                            cart.RemoveItem(items[selectedIndex]);
                        selectedIndex = 0;
                        break;
                    case ConsoleKey.Tab:
                        RenderProduct(items[selectedIndex]);
                        break;
                    case ConsoleKey.Spacebar:
                        RenderReceipt(cart);
                        cart.Clear(); // Очищаем корзину после оформления заказа
                        exit = true; // Выходим из корзины
                        break;
                    case ConsoleKey.Escape:
                        exit = true;
                        break;
                }
            }
        }

        // Отрисовка главного меню с динамическими категориями
        public void RenderMainMenu(List<ICategory> categories, IShoppingCart cart)
        {
            int selectedIndex = 0;
            bool exit = false;

            while (!exit)
            {
                Console.Clear();

                RenderLine();
                RenderTitle("Главное меню магазина JetBrainsProduct");
                RenderLine();

                string[] options = new string[categories.Count + 2]; // Опции для категорий и корзины/выхода
                for (int i = 0; i < categories.Count; i++)
                {
                    options[i] = $"{categories[i].Name}";
                }

                options[categories.Count] = "Просмотр корзины";
                options[categories.Count + 1] = "Выход";

                for (int i = 0; i < options.Length; i++)
                {
                    if (i == selectedIndex)
                    {
                        Console.BackgroundColor = ConsoleColor.DarkGray;
                        Console.ForegroundColor = ConsoleColor.Black;
                    }

                    RenderTitle($"{i + 1}. {options[i]}");
                    Console.ResetColor();
                }

                RenderLine();

                var key = Console.ReadKey(true).Key;
                switch (key)
                {
                    case ConsoleKey.UpArrow:
                        if (selectedIndex > 0) selectedIndex--;
                        break;
                    case ConsoleKey.DownArrow:
                        if (selectedIndex < options.Length - 1) selectedIndex++;
                        break;
                    case ConsoleKey.Enter:
                        if (selectedIndex < categories.Count)
                        {
                            RenderCategory(categories[selectedIndex], cart);
                        }
                        else if (selectedIndex == categories.Count)
                        {
                            RenderCart(cart);
                        }
                        else if (selectedIndex == categories.Count + 1)
                        {
                            exit = true;
                        }

                        break;
                }
            }
        }

        // Отрисовка чека и завершение покупки
        public void RenderReceipt(IShoppingCart cart)
        {
            Console.Clear();
            RenderLine();
            RenderTitle("Чек");
            RenderLine();
            RenderProducts(cart.Items);
            RenderLine();
            RenderCalculateCart(cart);
            RenderLine();

            Console.WriteLine("Покупка завершена. Нажмите любую клавишу для выхода.");
            Console.ReadKey(true);
        }
    }
}