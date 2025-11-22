// Creating a Product management database system.
// Where we can store product data and manage adding, and finding product

using System;
namespace Shopmate.Models
{
    class Product
    {
        public int ProductId { get; set; }
        public string Owner { get; set; }
        public string ShopName { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }

        public Product(int productId, string owner, string shopName, string title, string description, int price)
        {
            this.ProductId = productId;
            this.Owner = owner;
            this.ShopName = shopName;
            this.Title = title;
            this.Description = description;
            this.Price = price;
        }

        public void Details()
        {
            Console.WriteLine("Product id: " + ProductId);
            Console.WriteLine("Owner Name: " + Owner);
            Console.WriteLine("Shop Name: " + ShopName);
            Console.WriteLine("Title: " + Title);
            Console.WriteLine("Description: " + Description);
            Console.WriteLine("Price: " + Price);
        }

    }
    static class Products
    {
        private static Product[] products = new Product[1000];
        private static int ProductCount = 0;
        public static void Add(string owner, string shopName, string title, string description, int price)
        {
            products[ProductCount] = new Product(++ProductCount, owner, shopName, title, description, price);
        }
        public static void ShowAll(int start, int end)
        {
            for (int i = start; i <= end; i++)
            {
                products[i].Details();
            }
        }
        public static void ShowByUsername(string userName)
        {
            Console.WriteLine("--------------------------------------------------------");
            for (int i = 0; i < ProductCount; i++)
            {
                if (products[i].Owner == userName)
                {
                    Console.WriteLine("Title: " + products[i].Title);
                    Console.WriteLine("Description: " + products[i].Description);
                    Console.WriteLine("Price: " + products[i].Price);
                    Console.WriteLine("--------------------------------------------------------");
                }
            }
        }
        public static Product Get(int id)
        {
            return products[id - 1];
        }
        public static void Remove(int id)
        {

            products[id - 1].ProductId = -1;
            products[id - 1].Owner = "null";

        }
    }
}