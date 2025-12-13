using Shopmate.Models;
using Shopmate.Utils;

namespace Shopmate.Services
{
    static class Auth
    {
        public static User loggedInUser;

        public static void Authinticate()
        {
            try
            {
                ShopMateUtils.PageName("Authenthication");
                Console.WriteLine("1. Login\n2. Signup");
                Console.Write("Choose: ");
                int input;
                do
                {
                    input = Convert.ToInt16(Console.ReadLine());
                }
                while (input != 1 && input != 2);
                if (input == 1)
                {
                    Login();
                }
                else
                {
                    Signup();
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Something went wrong! Please log in again");
                Authinticate();
            }
        }
        public static void Login()
        {
            ShopMateUtils.PageName("Login");
            Console.WriteLine("Welcome back!");
            Console.WriteLine("Please enter your details to login.");
            Console.Write("Username: ");
            string userName = Console.ReadLine();
            Console.Write("Password: ");
            string password = Console.ReadLine();
            if (Users.Exists(userName, password))
            {
                loggedInUser = Users.Get(userName);
                Console.WriteLine("Login Successfull!");
                App.Home();
            }
            else
            {
                Console.WriteLine("Username or password incorrect!");
                Authinticate();
            }
        }

        public static void Signup()
        {
            ShopMateUtils.PageName("Sign up");

            Console.WriteLine("Let's get you set up!");
            Console.WriteLine("Please enter the following details to create an account.");

            Console.Write("Full name: ");
            string fullName = Console.ReadLine();
            Console.Write("Shop name: ");
            string shopName = Console.ReadLine();

            Console.Write("Create a password: ");
            string password = Console.ReadLine();

            Console.Write("Create an username: ");
            string userName;
            userName = Console.ReadLine();
            while (Users.Exists(userName))
            {
                Console.WriteLine("Username already exist! Please choose another.");
                Console.Write("Create an username: ");
                userName = Console.ReadLine();
            }

            Users.Add(fullName, shopName, userName, password);
            Console.WriteLine("Signup successfull!");
            Console.WriteLine("Please login with your username and password");
            Authinticate();
        }
    }

}