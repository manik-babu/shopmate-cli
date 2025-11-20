// Creating a Product management database system.
// Where we can store product data and manage adding, and finding product

using System;
namespace Shopmate.Models
{
    class Product
    {
        public int ProductId { get; set; }
        public string Owner { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }

        public Product(int productId, string owner, string title, string description, int price)
        {
            this.ProductId = productId;
            this.Owner = owner;
            this.Title = title;
            this.Description = description;
            this.Price = price;
        }

        public void Details()
        {
            Console.WriteLine("Product id: " + ProductId);
            Console.WriteLine("Owner Name: " + Owner);
            Console.WriteLine("Title: " + Title);
            Console.WriteLine("Description: " + Description);
            Console.WriteLine("Price: " + Price);
        }

    }
    static class Products
    {
        private static Product[] products = new Product[1000];
        private static int ProductCount = 0;
        public static void Add(string owner, string title, string description, int price)
        {
            products[ProductCount] = new Product(++ProductCount, owner, title, description, price);
        }
        public static void ShowAll(int start, int end)
        {
            for (int i = start; i <= end; i++)
            {
                products[i].Details();
            }
        }
        public static Product Get(int id)
        {
            return products[id - 1];
        }
    }
}