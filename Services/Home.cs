using Shopmate.Utils;
namespace Shopmate.Services
{
    static class App
    {
        public static void Home()
        {
            ShopMateUtils.PageName("Home");

            Console.WriteLine("1. Profile");
            Console.WriteLine("2. My store");
            Console.WriteLine("3. Market place");
            Console.WriteLine("0. Logout");

            Console.Write("Choose: ");
            int choice = ShopMateUtils.ReadChoice(new int[] { 0, 1, 2, 3 });

            switch (choice)
            {
                case 0:
                    Auth.Authinticate();
                    break;
                case 1:
                    Profile();
                    break;
                case 2:
                    Store.StoreHome();
                    break;
                case 3:
                    Market.MarketHome();
                    break;
            }
        }
        public static void Profile()
        {
            ShopMateUtils.PageName("Profile");
            Console.WriteLine($"Shop Name\t{Auth.loggedInUser.ShopName}");
            Console.WriteLine($"Name     \t{Auth.loggedInUser.FullName}");
            Console.WriteLine($"Username \t{Auth.loggedInUser.UserName}");
            Console.WriteLine();

            Console.WriteLine("0. Back to home page");
            int choice = ShopMateUtils.ReadChoice(new int[] { 0 });
            Home();
        }
    }
}