using Shopmate.Models;
namespace Shopmate.Helpers
{
    static class DammyData
    {
        public static void AddUser()
        {
            Users.Add("Md Manik", "Tomato", "manik", "1234");
            User user = Users.Get("manik");
            user.ShopName = "Tomato";
        }
        public static void AddProduct()
        {
            Products.Add("manik", "Tomato", "First", "First product by manik", 100);
            Products.Add("manik", "Tomato", "Second", "Second product by manik", 100);
            Products.Add("manik", "Tomato", "Third", "Third product by manik", 100);
            Products.Add("manik", "Tomato", "Fourth", "Fourth product by manik", 100);
            Products.Add("manik", "Tomato", "Fifth", "Fifth product by manik", 100);
            Products.Add("manik", "Tomato", "Sixth", "Sixth product by manik", 100);
            Products.Add("manik", "Tomato", "Seventh", "Seventh product by manik", 100);
            Products.Add("manik", "Tomato", "Eightth", "Eithth product by manik", 100);
        }
    }
}