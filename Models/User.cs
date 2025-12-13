/*
- Create a database management system for manage user in our market. 
- We can perform user add, check rather a user exists or not in the database
- and also checking a user exits with a specific username and password.
- Get a user with a specific username
- Get all the user present in the database
*/

using System;
namespace Shopmate.Models
{
    // --------------- Abstraction ------------------
    abstract class UserSchema
    {
        public string FullName;
        public string UserName;
        protected string Password;
        public string ShopName;
        public abstract bool PasswordVarify(string password);

    }
    class User : UserSchema
    {
        public User(string fullname, string shopName, string username, string password)
        {
            this.FullName = fullname;
            this.ShopName = shopName;
            this.UserName = username;
            this.Password = password;
        }
        public override bool PasswordVarify(string password)
        {
            return this.Password == password;
        }
    }

    interface IUsers
    {
        public abstract static void Add(string fullName, string shopName, string userName, string password);
        public abstract static bool Exists(string username);
        public abstract static bool Exists(string username, string password);
        public abstract static User Get(string username);
    }

    class Users : IUsers
    {
        // int nums[100];
        // int[] nums = new int[100];
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