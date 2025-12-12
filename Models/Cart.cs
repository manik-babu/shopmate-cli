namespace Shopmate.Models
{
    class Cart
    {
        public int CartId;
        public string Customer;
        public int Quantity;
        public Product product;

        public Cart(int cartId, string customer, int quantity, Product product)
        {
            this.CartId = cartId;
            this.Customer = customer;
            this.Quantity = quantity;
            this.product = product;
        }
    }
    static class Carts
    {
        public static Cart[] carts = new Cart[100];
        public static int CartCount = 0;
        public static void Add(string customer, int quantity, Product product)
        {
            carts[CartCount] = new Cart(CartCount + 1, customer, quantity, product);
            CartCount++;
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