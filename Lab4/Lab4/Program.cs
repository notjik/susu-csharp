using System;
using System.Globalization;
using System.Collections.Generic;
using Lab4.Category;
using Lab4.Product;
using Lab4.ShoppingCart;
using Lab4.Renderer;

namespace Lab4
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            System.Threading.Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");

            // Категория: IDE для разработки
            var ideCategory = new Category.Category("Integrated Development Environments");
            ideCategory.AddProduct(new Product.Product("IntelliJ IDEA", "Integrated Development Environment for Java",
                149.00));
            ideCategory.AddProduct(new Product.Product("PyCharm", "IDE for Python development", 199.00));
            ideCategory.AddProduct(new Product.Product("WebStorm", "IDE for JavaScript development", 149.00));
            ideCategory.AddProduct(new Product.Product("PhpStorm", "IDE for PHP development", 199.00));
            ideCategory.AddProduct(new Product.Product("CLion", "C/C++ IDE", 199.00));
            ideCategory.AddProduct(new Product.Product("Rider", "Cross-platform .NET IDE", 199.00));
            ideCategory.AddProduct(new Product.Product("AppCode", "IDE for iOS/macOS development", 199.00));

            // Категория: Инструменты повышения производительности
            var productivityCategory = new Category.Category("Productivity Tools");
            productivityCategory.AddProduct(new Product.Product("ReSharper", "Productivity tool for .NET developers",
                199.00));
            productivityCategory.AddProduct(new Product.Product("ReSharper C++", "Productivity tool for C++ developers",
                199.00));
            productivityCategory.AddProduct(new Product.Product("dotTrace",
                "Performance profiler for .NET applications", 199.00));
            productivityCategory.AddProduct(new Product.Product("dotMemory", "Memory profiler for .NET applications",
                199.00));

            // Категория: Инструменты для работы с базами данных
            var databaseCategory = new Category.Category("Database Tools");
            databaseCategory.AddProduct(new Product.Product("DataGrip", "Database management tool", 199.00));
            databaseCategory.AddProduct(new Product.Product("DBeaver", "Universal database tool",
                99.00)); // Условный пример

            // Категория: Инструменты для анализа кода
            var codeAnalysisCategory = new Category.Category("Code Analysis Tools");
            codeAnalysisCategory.AddProduct(new Product.Product("TeamCity",
                "Continuous Integration and Delivery server", 299.00));
            codeAnalysisCategory.AddProduct(new Product.Product("YouTrack",
                "Issue tracker designed for development teams", 299.00));

            // Категория: Инструменты для разработки мобильных приложений
            var mobileDevelopmentCategory = new Category.Category("Mobile Development Tools");
            mobileDevelopmentCategory.AddProduct(
                new Product.Product("AppCode", "IDE for iOS/macOS development", 199.00));


            // Добавляем категории в список
            var categories = new List<ICategory>
                { ideCategory, databaseCategory, codeAnalysisCategory, mobileDevelopmentCategory };

            // Инициализация корзины
            var shoppingCart = new ShoppingCart.ShoppingCart();

            // Инициализация рендерера
            var renderer = new Renderer.Renderer();

            // Отрисовка главного меню с динамическими категориями
            renderer.RenderMainMenu(categories, shoppingCart);
        }
    }
}