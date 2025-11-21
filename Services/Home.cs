namespace Shopmate.Services
{
    static class App
    {
        public static void Home()
        {
            Console.WriteLine("---------------------------------");
            Console.WriteLine($"\tHome");
            Console.WriteLine("---------------------------------");
            Console.WriteLine("1. Profile");
            Console.WriteLine("2. My store");
            Console.WriteLine("3. Market place");
            Console.WriteLine("0. Logout");
            int choice;
            Console.Write("=> ");
            choice = Convert.ToInt32(Console.ReadLine());
            while (choice != 0 && choice != 1 && choice != 2 && choice != 3)
            {
                Console.WriteLine("Invalid option!");
                Console.Write("=> ");
                choice = Convert.ToInt32(Console.ReadLine());
            }

            if (choice == 0)
            {
                Auth.Authinticate();
            }
            else if (choice == 1)
            {
                Profile();
            }
            else if (choice == 2)
            {
                Store.Interface();
            }
            else if (choice == 3)
            {
                // MarketPlace();
            }

        }
        public static void Profile()
        {
            Console.WriteLine("---------------------------------");
            Console.WriteLine($"\tProfile");
            Console.WriteLine("---------------------------------");
            string shopName = Auth.loggedInUser.ShopName == "-" ? "You'r not a seller!" : Auth.loggedInUser.ShopName;
            Console.WriteLine($"Shop Name\t{shopName}");
            Console.WriteLine($"Name     \t{Auth.loggedInUser.FullName}");
            Console.WriteLine($"Username \t{Auth.loggedInUser.UserName}");
            Console.WriteLine();
            Console.WriteLine("0. Back");
            int choice;
            Console.Write("=> ");
            choice = Convert.ToInt32(Console.ReadLine());
            while (choice != 0)
            {
                Console.WriteLine("Invalid option! Please enter correct option.");
                Console.Write("=> ");
                choice = Convert.ToInt32(Console.ReadLine());
            }
            Home();
        }
    }
}