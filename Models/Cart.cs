namespace Shopmate.Models
{
    abstract class CartSchema
    {
        public int CartId;
        public string Customer;
        public int Quantity;
        public Product product;
    }
    class Cart : CartSchema
    {
        public Cart(int cartId, string customer, int quantity, Product product)
        {
            this.CartId = cartId;
            this.Customer = customer;
            this.Quantity = quantity;
            this.product = product;
        }
    }

    interface ICarts
    {
        public abstract static void Add(string customer, int quantity, Product product);
        public abstract static void ShowCartItems(string customer);
        public abstract static void RemoveCartItem(string customer, int cartId);
        public abstract static void ShowPriceDetails(string customer);
        public abstract static void PlaceOrder(string address, string customer);
    }

    class Carts : ICarts
    {
        public static Cart[] carts = new Cart[100];
        public static int CartCount = 0;
        public static void Add(string customer, int quantity, Product product)
        {
            carts[CartCount] = new Cart(CartCount + 1, customer, quantity, product);
            CartCount++;
        }
        public static void ShowCartItems(string customer)
        {
            bool cartFound = false;
            Console.WriteLine("---------------------------------------------------");
            for (int i = CartCount - 1; i >= 0; i--)
            {
                if (carts[i].Customer == customer)
                {
                    Console.WriteLine($"Cart ID: {carts[i].CartId}");
                    Console.WriteLine($"ID: {carts[i].product.ProductId}\t{carts[i].product.ShopName}({carts[i].product.Owner})");
                    Console.WriteLine("Title: " + carts[i].product.Title);
                    Console.WriteLine("Quantity: " + carts[i].Quantity);
                    Console.WriteLine("Price: " + carts[i].product.Price);
                    Console.WriteLine("---------------------------------------------------");
                    cartFound = true;
                }
            }
            if (!cartFound)
            {
                Console.WriteLine("You have no cart yet");
            }
        }
        public static void RemoveCartItem(string customer, int cartId)
        {
            if (cartId > 0 && cartId < CartCount && carts[cartId - 1].Customer == customer)
            {
                carts[cartId - 1].Customer = "-";
            }
            else
            {
                Console.WriteLine("Something went wrong!");
            }
        }
        public static void ShowPriceDetails(string customer)
        {
            bool cartFound = false;
            int total = 0;
            for (int i = CartCount - 1; i >= 0; i--)
            {
                Cart cart = carts[i];
                if (cart.Customer == customer)
                {
                    Console.WriteLine($"{cart.product.Price}x{cart.Quantity}\t\t{cart.product.Title}");
                    total += cart.product.Price * cart.Quantity;
                    cartFound = true;
                }
            }
            if (cartFound)
            {
                Console.WriteLine("60\t\tDelivery charge");
                total += 60;
                Console.WriteLine("-------------------------------------------------");
                Console.WriteLine(total);
                Console.WriteLine("Total = " + total);

            }

        }
        public static void PlaceOrder(string address, string customer)
        {
            bool cartFound = false;
            for (int i = 0; i < CartCount; i++)
            {
                Cart cart = carts[i];
                if (cart.Customer == customer)
                {
                    Orders.add(customer, cart.product.Owner, cart.Quantity, cart.product, address);
                    cart.Customer = "-";
                    cartFound = true;
                }
            }
            if (cartFound)
            {
                Console.WriteLine("Order successfull!");
            }
            else
            {
                Console.WriteLine("No cart found! order failed!");
            }
        }


    }
}