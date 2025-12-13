using System;
namespace Shopmate.Models
{
    abstract class OrderSchema
    {
        public int OrderId;
        public string OrderedBy;
        public string OrderedTo;
        public int Quantity;
        public Product Product;
        public string Address;
    }
    class Order : OrderSchema
    {
        public Order(int orderId, string orderedBy, string orderedTo, int quantity, Product product, string address)
        {
            this.OrderId = orderId;
            this.OrderedBy = orderedBy;
            this.OrderedTo = orderedTo;
            this.Quantity = quantity;
            this.Product = product;
            this.Address = address;
        }
    }

    interface IOrders
    {
        public abstract static void add(string orderedBy, string orderedTo, int quantity, Product product, string address);
        public abstract static void ShowStoreOrder(string userName);
        public abstract static void ShowCustomerOrders(string userName);
    }
    class Orders : IOrders
    {
        private static Order[] orders = new Order[200];
        private static int OrderCount = 0;
        public static void add(string orderedBy, string orderedTo, int quantity, Product product, string address)
        {
            orders[OrderCount] = new Order(++OrderCount, orderedBy, orderedTo, quantity, product, address);
        }
        public static void ShowStoreOrder(string userName)
        {
            bool orderFound = false;
            Console.WriteLine("----------------------------------------------------------------");
            for (int i = OrderCount - 1; i >= 0; i--)
            {
                Order order = orders[i];
                if (order.OrderedTo == userName)
                {
                    Console.WriteLine($"Ordered By: \t\t{order.OrderedBy}");
                    Console.WriteLine($"Product ID: \t\t{order.Product.ProductId}");
                    Console.WriteLine($"Product Title: \t\t{order.Product.Title}");
                    Console.WriteLine($"Product Price: \t\t{order.Product.Price}");
                    Console.WriteLine($"Product Quantity: \t{order.Quantity}");
                    Console.WriteLine($"Order Address: \t\t{order.Address}");
                    Console.WriteLine("----------------------------------------------------------------");
                    orderFound = true;
                }
            }
            if (!orderFound)
            {
                Console.WriteLine("No order found!");
            }
        }
        public static void ShowCustomerOrders(string userName)
        {
            bool orderFound = false;
            Console.WriteLine("----------------------------------------------------------------");
            for (int i = OrderCount - 1; i >= 0; i--)
            {
                Order order = orders[i];
                if (order.OrderedBy == userName)
                {
                    Console.WriteLine($"Shop Name: \t\t{order.Product.ShopName}({order.Product.Owner})");
                    Console.WriteLine($"Product ID: \t\t{order.Product.ProductId}");
                    Console.WriteLine($"Product Title: \t\t{order.Product.Title}");
                    Console.WriteLine($"Product Price: \t\t{order.Product.Price}");
                    Console.WriteLine($"Product Quantity: \t{order.Quantity}");
                    Console.WriteLine($"Order Address: \t\t{order.Address}");
                    Console.WriteLine("----------------------------------------------------------------");
                    orderFound = true;
                }
            }
            if (!orderFound)
            {
                Console.WriteLine("No order found!");
            }
        }
    }
}