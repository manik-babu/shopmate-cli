using Shopmate.Models;
using Shopmate.Utils;
namespace Shopmate.Services
{
    static class Store
    {
        public static void StoreHome()
        {
            ShopMateUtils.PageName("My Store");

            Console.WriteLine("1. My products");
            Console.WriteLine("2. Add products");
            Console.WriteLine("3. Orders");
            Console.WriteLine("0. Back to home page");

            int choice = ShopMateUtils.ReadChoice(new int[] { 0, 1, 2, 3 });

            switch (choice)
            {
                case 0:
                    App.Home();
                    break;
                case 1:
                    MyProductList();
                    break;
                case 2:
                    ProductAdd();
                    break;
                case 3:
                    MyOrders();
                    break;
            }
        }
        public static void ProductAdd()
        {
            ShopMateUtils.PageName("Add Product");

            Console.WriteLine("List a new product for sale");
            Console.Write("Product Title: ");
            string title = Console.ReadLine();

            Console.Write("Product Description: ");
            string description = Console.ReadLine();

            Console.Write("Product Price: ");
            int price = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("---------- Preview ----------");
            Console.WriteLine("Title: " + title);
            Console.WriteLine("Description: " + description);
            Console.WriteLine("Price: " + price);

            Console.WriteLine("Ready to sale?");
            Console.WriteLine("1. Add Product");
            Console.WriteLine("2. Cancel");
            int choice = ShopMateUtils.ReadChoice(new int[] { 1, 2 });

            if (choice == 2)
                StoreHome();
            else
            {
                Products.Add(Auth.loggedInUser.UserName, Auth.loggedInUser.ShopName, title, description, price);
                Console.WriteLine("Product listed successfully!");

                Console.WriteLine("1. Add another product");
                Console.WriteLine("2. View product list");
                Console.WriteLine("0. Go back to my store");

                int input = ShopMateUtils.ReadChoice(new int[] { 0, 1, 2 });
                switch (input)
                {
                    case 0:
                        StoreHome();
                        break;
                    case 1:
                        ProductAdd();
                        break;
                    case 2:
                        MyProductList();
                        break;
                }
            }
        }
        public static void MyProductList()
        {

            ShopMateUtils.PageName("My Products");

            Products.ShowByUsername(Auth.loggedInUser.UserName);

            Console.WriteLine("0. Go back to my store");
            Console.Write("Choose: ");
            Console.ReadLine();

            StoreHome();
        }
        public static void MyOrders()
        {
            ShopMateUtils.PageName("My Orders");
            Orders.ShowStoreOrder(Auth.loggedInUser.UserName);

            Console.WriteLine("0. Back to home");
            Console.Write("Choose: ");
            Console.ReadLine();
            StoreHome();
        }
    }
}