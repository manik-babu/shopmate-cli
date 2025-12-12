using System;
using Shopmate.Services;
using Shopmate.Models;
using Shopmate.Utils;
class Program
{
    static void Main(string[] args)
    {
        ShopMateUtils.PageName("ShopMate CLI");
        Console.WriteLine("Buy and sell anytime, anythings, anywhere!");
        Shopmate.Helpers.DammyData.AddUser();
        Shopmate.Helpers.DammyData.AddProduct();
        Auth.Authinticate();
    }
}