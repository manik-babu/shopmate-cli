using System;
namespace Shopmate.Models
{
    class Order
    {
        public int OrderId;
        public string OrderedBy;
        public string OrderedTo;
        public int Quantity;
        public Product Product;
        public string Address;


        public Order(int orderId, string orderedBy, string orderedTo, int quantity, Product product, string address)
        {
            this.OrderId = orderId;
            this.OrderedBy = orderedBy;
            this.OrderedTo = orderedTo;
            this.Quantity = quantity;
            this.Product = product;
            this.Address = address;
        }
        public void Show()
        {
            Console.WriteLine("Order id: " + OrderId);
            Console.WriteLine($"Ordered by {OrderedBy} and ordered to {OrderedTo}");
            Console.WriteLine("Product: " + Product.Title);
        }
    }
    static class Orders
    {
        private static Order[] orders = new Order[200];
        private static int OrderCount = 0;
        public static void add(string orderedBy, string orderedTo, int quantity, Product product, string address)
        {
            orders[OrderCount] = new Order(++OrderCount, orderedBy, orderedTo, quantity, product, address);
        }
        public static void GetStoreOrder(string userName)
        {
            foreach (Order order in orders)
            {
                if (order.OrderedTo == userName)
                {
                    order.Show();
                }
            }
        }
        public static void GetCustomerOrders(string userName)
        {
            foreach (Order order in orders)
            {
                if (order.OrderedBy == userName)
                {
                    order.Show();
                }
            }
        }
    }
}