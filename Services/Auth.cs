using System.Threading;
using Shopmate.Models;
using Shopmate.Utils;

namespace Shopmate.Services
{
    static class Auth
    {
        public static User loggedInUser { get; set; }

        public static void Authinticate()
        {
            ShopMateUtils.PageName("Authenthication");
            Console.WriteLine("1. Login\n2. Signup");
            Console.WriteLine("Choose one (1/2)");
            Console.Write("=> ");
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
        public static void Login()
        {
            ShopMateUtils.PageName("Login");
            Console.WriteLine("Welcome back!");
            ShopMateUtils.Loading(500);
            Console.WriteLine("Please enter your details to login.");
            ShopMateUtils.Loading(1000);
            Console.Write("Username: ");
            string userName = Console.ReadLine();
            Console.Write("Password: ");
            string password = Console.ReadLine();
            ShopMateUtils.Loading("Logging in", 1500);
            if (Users.Exists(userName, password))
            {
                loggedInUser = Users.Get(userName);
                Console.WriteLine("Login Successfull!");
                Console.WriteLine($"Welcome back {loggedInUser.FullName}");
                App.Home();
            }
            else
            {
                ShopMateUtils.Loading(500);
                Console.WriteLine("Username or password incorrect!");
                ShopMateUtils.Loading(1000);
                Authinticate();
            }
        }

        public static void Signup()
        {
            ShopMateUtils.PageName("Sign up");
            Console.WriteLine("Let's get you set up!");
            ShopMateUtils.Loading(500);
            Console.WriteLine("Please enter the following details to create an account.");
            ShopMateUtils.Loading(1000);
            Console.Write("Full name: ");
            string fullName = Console.ReadLine();
            Console.Write("Create a password: ");
            string password = Console.ReadLine();
            Console.Write("Create an username: ");
            string userName;
            userName = Console.ReadLine();
            while (Users.Exists(userName))
            {
                Console.WriteLine("Username already exist! Please choose another.");
                ShopMateUtils.Loading(500);
                Console.Write("Create an username: ");
                userName = Console.ReadLine();
            }
            Users.Add(fullName, userName, password);
            ShopMateUtils.Loading("Creating account", 1500);
            Console.WriteLine("Signup successfull!");
            ShopMateUtils.Loading(500);
            Console.WriteLine("Please login with your username and password");
            ShopMateUtils.Loading(1000);
            Authinticate();
        }
    }

}