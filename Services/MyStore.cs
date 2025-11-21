using Shopmate.Models;
using Shopmate.Utils;
namespace Shopmate.Services
{
    static class Store
    {
        public static void Interface()
        {
            if (Auth.loggedInUser.ShopName == "-")
            {
                Console.WriteLine("---------------------------------");
                Console.WriteLine($"\tMy Store");
                Console.WriteLine("---------------------------------");
                ShopMateUtils.Loading(500);
                Console.WriteLine("Looks like you don’t have a shop yet.");
                ShopMateUtils.Loading(500);
                Console.WriteLine("Do you want to set up your shop now?");
                Console.WriteLine("1. Yes");
                Console.WriteLine("2. No");
                int choice = ShopMateUtils.ReadChoice(new int[] { 1, 2 });
                if (choice == 1)
                {
                    Console.WriteLine("Let’s get you started!");
                    ShopMateUtils.Loading(500);
                    Console.Write("Enter the desired name for your shop: ");
                    string shopName = Console.ReadLine();
                    Auth.loggedInUser.ShopName = shopName;
                    ShopMateUtils.Loading("Creating", 1500);
                    Console.WriteLine("Great! Your shop is now created and ready to use.");
                    ShopMateUtils.Loading(500);
                    StoreHome();
                }
                else
                {
                    App.Home();
                }
            }
            else
            {
                StoreHome();
            }
        }
        public static void StoreHome()
        {
            Console.WriteLine("---------------------------------");
            Console.WriteLine($"\t{Auth.loggedInUser.ShopName}");
            Console.WriteLine("---------------------------------");
            Console.WriteLine("1. My Products");
            Console.WriteLine("2. Add Products");
            Console.WriteLine("3. Pending Orders");
            Console.WriteLine("4. Confirmed Orders");
            Console.WriteLine("0. Back");
            int choice = ShopMateUtils.ReadChoice(new int[] { 0, 1, 2, 3 });

            if (choice == 0)
            {
                App.Home();
            }
            else if (choice == 1)
            {
                // 
            }
            else if (choice == 2)
            {
                ProductAdd();
            }
            else if (choice == 3)
            {
                // 
            }
            else if (choice == 4)
            {
                // 
            }
        }
        public static void ProductAdd()
        {
            Console.WriteLine("---------------------------------");
            Console.WriteLine("\tAdd Product");
            Console.WriteLine("---------------------------------");
            Console.WriteLine("List a new product for sale");
            Console.Write("Product Title: ");
            string title = Console.ReadLine();
            Console.Write("Product Description: ");
            string description = Console.ReadLine();
            Console.Write("Product Price: ");
            int price = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("---------------------------------");
            Console.WriteLine("\tPreview");
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Title: " + title);
            Console.WriteLine("Description: " + description);
            Console.WriteLine("Price: " + price);
            ShopMateUtils.Loading(1000);
            Console.WriteLine("Ready to sale?");
            Console.WriteLine("1. Add Product");
            Console.WriteLine("2. Cancel");
            int choice = ShopMateUtils.ReadChoice(new int[] { 1, 2 });

            if (choice == 1)
            {
                Shopmate.Models.Products.Add(Auth.loggedInUser.UserName, Auth.loggedInUser.ShopName, title, description, price);
                ShopMateUtils.Loading("Adding", 1500);
                Console.WriteLine("Product listed successfully!");
                ShopMateUtils.Loading(500);
                Console.WriteLine("Would you like to add another?");
                Console.WriteLine("1. Yes");
                Console.WriteLine("2. No");

                int input = ShopMateUtils.ReadChoice(new int[] { 1, 2 });
                if (input == 1)
                    ProductAdd();
                else
                    StoreHome();

            }
            else
            {
                StoreHome();
            }
        }



    }
}