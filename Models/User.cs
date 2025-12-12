// Create a database management system for manage user in our market. 
// We can perform user add, check rather a user exists or not in the database
// and also checking a user exits with a specific username and password.
// Get a user with a specific username
// Get all the user present in the database

using System;
namespace Shopmate.Models
{
    class User
    {
        public string FullName;
        public string UserName;
        private string Password;
        public string ShopName;

        public User(string fullname, string shopName, string username, string password)
        {
            this.FullName = fullname;
            this.ShopName = shopName;
            this.UserName = username;
            this.Password = password;
        }
        public bool PasswordVarify(string password)
        {
            return this.Password == password;
        }
    }
    static class Users
    {
        private static User[] users = new User[100];
        private static int UserCount = 0;
        public static void Add(string fullName, string shopName, string userName, string password)
        {
            users[UserCount++] = new User(fullName, shopName, userName, password);
        }
        public static bool Exists(string username)
        {
            for (int i = 0; i < UserCount; i++)
            {
                if (users[i].UserName == username)
                {
                    return true;
                }
            }
            return false;
        }
        public static bool Exists(string username, string password)
        {
            for (int i = 0; i < UserCount; i++)
            {
                if (users[i].UserName == username && users[i].PasswordVarify(password))
                {
                    return true;
                }
            }
            return false;
        }

        public static User Get(string username)
        {

            foreach (User user in users)
            {
                if (user.UserName == username)
                {
                    return user;
                }
            }
            return new User("null", "null", "null", "null");
        }
    }
}