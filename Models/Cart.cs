namespace Shopmate.Models
{
    interface ICart
    {
        public string ShopOwner { get; set; }
        public string Customer { get; set; }
        public int Quantity { get; set; }
        public Product product { get; set; }
    }
    class Cart : ICart
    {
        public string ShopOwner { get; set; }
        public string Customer { get; set; }
        public int Quantity { get; set; }
        public Product product { get; set; }

        public Cart(string shopOwner, string customer, int quantity, Product product)
        {
            this.ShopOwner = shopOwner;
            this.Customer = customer;
            this.Quantity = quantity;
            this.product = product;
        }
    }
    static class Carts
    {
        public static Cart[] carts = new Cart[100];
        public static int CartCount = 0;
        public static void Add(string shopOwner, string customer, int quantity, Product product)
        {
            carts[CartCount++] = new Cart(shopOwner, customer, quantity, product);
        }
        public static void GetByCustomer(string customer)
        {
            Console.WriteLine("---------------------------------------------------");
            for (int i = CartCount - 1; i >= 0; i--)
            {
                if (carts[i].Customer == customer)
                {
                    Console.WriteLine($"Product ID: {carts[i].product.ProductId}\t{carts[i].product.ShopName}");
                    Console.WriteLine("Product Title: " + carts[i].product.Title);
                    Console.WriteLine("Product Quantity: " + carts[i].Quantity);
                    Console.WriteLine("---------------------------------------------------");
                }
            }
        }
    }
}