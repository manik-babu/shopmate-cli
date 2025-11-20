using System.Threading;
using Shopmate.Models;

namespace Shopmate.Services
{
    static class Auth
    {
        public static User loggedInUser { get; set; }

        public static void Authinticate()
        {
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
        public static void Loading(string topic, int time)
        {
            Console.Write(topic);
            Thread.Sleep(time / 4);
            Console.Write(".");
            Thread.Sleep(time / 4);
            Console.Write(".");
            Thread.Sleep(time / 4);
            Console.Write(".");
            Thread.Sleep(time / 4);
            Console.WriteLine();
        }
        public static void Login()
        {
            Console.WriteLine("Welcome back!");
            Thread.Sleep(500);
            Console.WriteLine("Please enter your details to login.");
            Thread.Sleep(1000);
            Console.Write("Username: ");
            string userName = Console.ReadLine();
            Console.Write("Password: ");
            string password = Console.ReadLine();
            Loading("Logging in", 2000);
            if (Users.Exists(userName, password))
            {
                loggedInUser = Users.Get(userName);
                Console.WriteLine("Login Successfull!");
                // Home();
            }
            else
            {
                Thread.Sleep(500);
                Console.WriteLine("Username or password incorrect!");
                Thread.Sleep(1000);
                Authinticate();
            }
        }

        public static void Signup()
        {
            Console.WriteLine("Let's get you set up!");
            Thread.Sleep(500);
            Console.WriteLine("Please enter the following details to create an account.");
            Thread.Sleep(1000);
            Console.Write("Full name: ");
            string fullName = Console.ReadLine();
            Console.Write("Create a password: ");
            string password = Console.ReadLine();
            Console.Write("Create an username: ");
            string userName;
            userName = Console.ReadLine();
            while (Users.Exists(userName))
            {
                Console.WriteLine("Username already exist!");
                Thread.Sleep(300);
                Console.WriteLine("Please choose another.");
                Thread.Sleep(300);
                Console.WriteLine("Create an username: ");
                userName = Console.ReadLine();
            }
            Users.Add(fullName, userName, password);
            Loading("Creating account", 2000);
            Console.WriteLine("Signup successfull!");
            Thread.Sleep(500);
            Console.WriteLine("Please login with your username and password");
            Thread.Sleep(1000);
            Authinticate();
        }
    }

}