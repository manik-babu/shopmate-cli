using Shopmate.Utils;
using Shopmate.Models;
namespace Shopmate.Services
{
    static class Market
    {
        public static void MarketHome()
        {
            ShopMateUtils.PageName("Market");

            Console.WriteLine("1. Products");
            Console.WriteLine("2. My carts");
            Console.WriteLine("3. My orders");
            Console.WriteLine("0. Back to home page");
            int choice = ShopMateUtils.ReadChoice(new int[] { 0, 1, 2, 3 });

            switch (choice)
            {
                case 0:
                    App.Home();
                    break;
                case 1:
                    ShopMateUtils.PageName("Products");
                    MarketProducts(0, 5);
                    break;
                case 2:
                    ShowCartItems();
                    break;
                case 3:
                    MyOrders();
                    break;

            }
        }
        public static void MarketProducts(int start, int end)
        {

            Shopmate.Models.Products.ShowProducts(start, end);
            Console.WriteLine("1. See more");
            Console.WriteLine("2. Add to cart");
            Console.WriteLine("0. Back to market");
            int choice = ShopMateUtils.ReadChoice(new int[] { 0, 1, 2 });

            switch (choice)
            {
                case 0:
                    MarketHome();
                    break;
                case 1:
                    MarketProducts(end + 1, end + 5);
                    break;
                case 2:
                    AddToCart(start, end);
                    break;
            }

        }
        public static void AddToCart(int start, int end)
        {
            Console.Write("Enter product ID to add to cart (or 'C' to Cancel): ");
            string choice = Console.ReadLine().ToLower();
            if (choice != "c")
            {
                Console.Write("Product quantity: ");
                int quantity = Convert.ToInt32(Console.ReadLine());
                Product product = Products.GetProductById(Convert.ToInt32(choice));
                Shopmate.Models.Carts.Add(Auth.loggedInUser.UserName, quantity, product);

                Console.WriteLine("Product added to the cart!");


            }
            MarketProducts(start, end);
        }
        public static void ShowCartItems()
        {
            ShopMateUtils.PageName("Carts");

            Carts.GetByCustomer(Auth.loggedInUser.UserName);
            Carts.ShowPriceDetails(Auth.loggedInUser.UserName);

            Console.WriteLine("1. Remove cart");
            Console.WriteLine("2. Place order");
            Console.WriteLine("0. Back");

            int choice = ShopMateUtils.ReadChoice(new int[] { 0, 1, 2 });
            switch (choice)
            {
                case 0:
                    MarketHome();
                    break;
                case 1:
                    RemoveCartItems();
                    break;
                case 2:
                    PlaceOrder();
                    break;
            }
        }
        public static void RemoveCartItems()
        {
            Console.Write("Enter Cart ID to remove (or 'C' to Cancel): ");
            string choice = Console.ReadLine().ToLower();
            if (choice != "c")
            {
                int cartId = Convert.ToInt32(choice);
                Carts.RemoveCart(Auth.loggedInUser.UserName, cartId);

                Console.WriteLine("Cart removed!");
                ShowCartItems();
            }
            ShowCartItems();
        }
        public static void PlaceOrder()
        {
            ShopMateUtils.PageName("Place order");
            Console.WriteLine("Please provide your address");

            Console.Write("Division: ");
            string division = Console.ReadLine();
            Console.Write("District: ");
            string district = Console.ReadLine();
            Console.Write("Upazila: ");
            string upazila = Console.ReadLine();
            Console.Write("Village: ");
            string village = Console.ReadLine();

            string address = $"{division}, {district}, {upazila}, {village}";
            Console.WriteLine("Full address: " + address);
            Console.Write("Place order?(Y/n): ");

            string choice = Console.ReadLine().ToLower();
            if (choice != "n")
            {
                Carts.AddOrder(address, Auth.loggedInUser.UserName);
            }

            MarketHome();


        }
        public static void MyOrders()
        {
            ShopMateUtils.PageName("My Orders");
            Orders.GetCustomerOrders(Auth.loggedInUser.UserName);

            Console.WriteLine("0. Back to home");
            Console.Write("Choose: ");
            string choice = Console.ReadLine();
            MarketHome();
        }

    }
}