using System.Runtime.InteropServices;
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
                ShopMateUtils.PageName("My Store");
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
            ShopMateUtils.PageName("My Store");
            Console.WriteLine("1. My Products");
            Console.WriteLine("2. Add Products");
            Console.WriteLine("3. Pending Orders");
            Console.WriteLine("4. Confirmed Orders");
            Console.WriteLine("0. Back");
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

            ShopMateUtils.PageName("Preview");
            Console.WriteLine("Title: " + title);
            Console.WriteLine("Description: " + description);
            Console.WriteLine("Price: " + price);
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
                Console.WriteLine("1. Add another product");
                Console.WriteLine("2. View product list");
                Console.WriteLine("0. Go back to my store");

                int input = ShopMateUtils.ReadChoice(new int[] { 1, 2, 3 });
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
            else
            {
                StoreHome();
            }
        }
        public static void MyProductList()
        {

            ShopMateUtils.PageName("My Products");
            Shopmate.Models.Products.ShowByUsername(Auth.loggedInUser.UserName);
            Console.WriteLine("1. Remove product");
            Console.WriteLine("0. Go back to my store");
            int choice = ShopMateUtils.ReadChoice(new int[] { 0, 1 });

            switch (choice)
            {
                case 0:
                    StoreHome();
                    break;
                case 1:
                    RemoveProduct();
                    break;
            }
        }
        public static void RemoveProduct()
        {
            Console.Write("Enter product ID to remove (or 'C' to Cancel): ");
            string choice = Console.ReadLine().ToLower();
            if (choice != "c")
            {
                int productId = Convert.ToInt32(choice);
                bool isRemoveProduct = Shopmate.Models.Products.Remove(productId, Auth.loggedInUser.UserName);
                if (isRemoveProduct)
                {
                    ShopMateUtils.Loading("Removing", 1500);
                    Console.WriteLine("Product removed successfully");
                    ShopMateUtils.Loading(1500);
                }
                else
                {
                    Console.WriteLine("Product not found!");
                }
                MyProductList();
            }
            else
            {
                Console.WriteLine("Canceled!");
            }
            MyProductList();

        }


    }
}