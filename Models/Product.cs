// Creating a Product management database system.
// Where we can store product data and manage adding, and finding product

using System;
namespace Shopmate.Models
{
    abstract class ProductSchema
    {
        public int ProductId;
        public string Owner;
        public string ShopName;
        public string Title;
        public string Description;
        public int Price;
        public abstract void Display();
    }
    class Product : ProductSchema
    {
        public Product(int productId, string owner, string shopName, string title, string description, int price)
        {
            this.ProductId = productId;
            this.Owner = owner;
            this.ShopName = shopName;
            this.Title = title;
            this.Description = description;
            this.Price = price;
        }
        public override void Display()
        {
            Console.WriteLine($"Product ID: {ProductId}\t{ShopName}({Owner})");
            Console.WriteLine("Title: " + Title);
            Console.WriteLine("Description: " + Description);
            Console.WriteLine("Price: " + Price);
        }

    }

    interface IProducts
    {
        public abstract static void Add(string owner, string shopName, string title, string description, int price);
        public abstract static void ShowProducts(int start, int end);
        public abstract static void ShowByUsername(string userName);
        public abstract static Product GetProductById(int id);
    }

    class Products : IProducts
    {
        private static Product[] products = new Product[1000];
        private static int ProductCount = 0;
        public static void Add(string owner, string shopName, string title, string description, int price)
        {
            products[ProductCount] = new Product(++ProductCount, owner, shopName, title, description, price);
        }
        public static void ShowProducts(int start, int end)
        {
            if (start >= ProductCount)
            {
                Console.WriteLine("No more product available in the market!!");
                return;
            }
            Console.WriteLine("---------------------------------------------");
            for (int i = start; i <= end && i < ProductCount; i++)
            {

                products[i].Display();
                Console.WriteLine("---------------------------------------------");
            }
        }
        public static void ShowByUsername(string userName)
        {
            Console.WriteLine("--------------------------------------------------------");
            for (int i = 0; i < ProductCount; i++)
            {
                if (products[i].Owner == userName)
                {
                    Console.WriteLine("Product ID: " + products[i].ProductId);
                    Console.WriteLine("Title: " + products[i].Title);
                    Console.WriteLine("Description: " + products[i].Description);
                    Console.WriteLine("Price: " + products[i].Price);
                    Console.WriteLine("--------------------------------------------------------");
                }
            }
        }
        public static Product GetProductById(int id)
        {
            return products[id - 1];
        }
    }
}