using Shopmate.Utils;
using Shopmate.Models;
namespace Shopmate.Services
{
    static class Market
    {
        public static void Interface()
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

            }
        }
        public static void MarketProducts(int start, int end)
        {
            Console.WriteLine("---------------------------------------------");
            Shopmate.Models.Products.ShowProducts(start, end);
            Console.WriteLine("1. See more");
            Console.WriteLine("2. Add to cart");
            Console.WriteLine("0. Back to market");
            int choice = ShopMateUtils.ReadChoice(new int[] { 0, 1, 2 });

            switch (choice)
            {
                case 0:
                    Interface();
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
                Shopmate.Models.Carts.Add(product.Owner, Auth.loggedInUser.UserName, quantity, product);
                ShopMateUtils.Loading("Adding to cart", 1000);
                Console.WriteLine("Product added to the cart!");
                ShopMateUtils.Loading("Redirecting to product page", 1000);

            }
            MarketProducts(start, end);
        }

    }
}